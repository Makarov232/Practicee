using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game
{
    public partial class Form1 : Form
    {
        private int seconds = 0;
        private Player player = new Player();
        private List<Food> foods = new List<Food>();
        private List<Trap> traps = new List<Trap>();

        int maxWidth;
        int maxHeight;

        int score;

        Random rand = new Random();

        bool goLeft, goRight, goDown, goUp;
        private const int MAX_TRAPS = 20;

        public Form1()
        {
            InitializeComponent();
            new Settings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void key_is_down(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = true;
            if (e.KeyCode == Keys.Right) goRight = true;
            if (e.KeyCode == Keys.Up) goUp = true;
            if (e.KeyCode == Keys.Down) goDown = true;
            if (e.KeyCode == Keys.Space) place_trap();
        }

        private void key_is_up(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Left) goLeft = false;
            if (e.KeyCode == Keys.Right) goRight = false;
            if (e.KeyCode == Keys.Up) goUp = false;
            if (e.KeyCode == Keys.Down) goDown = false;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            restart();
        }

        private void restart()
        {
            maxWidth = field.Width / Settings.width - 1;
            maxHeight = field.Height / Settings.height - 1;

            start_button.Enabled = false;
            score = 0;
            seconds = 0;
            points.Text = "0";
            traps_count.Text = "0";

            player.x = 10;
            player.y = 5;

            foods.Clear();
            traps.Clear();


            Food initialFood = new Food();
            initialFood.x = rand.Next(0, maxWidth + 1);
            initialFood.y = rand.Next(0, maxHeight + 1);
            initialFood.directionX = rand.Next(-1, 2);
            initialFood.directionY = rand.Next(-1, 2);

  
            if (initialFood.directionX == 0 && initialFood.directionY == 0)
            {
                initialFood.directionX = 1;
            }

            foods.Add(initialFood);

            timer.Start();
            game_time.Start();
        }

        private void timer_event(object sender, EventArgs e)
        {
            if (goLeft) Settings.directions = "left";
            if (goRight) Settings.directions = "right";
            if (goUp) Settings.directions = "up";
            if (goDown) Settings.directions = "down";

            switch (Settings.directions)
            {
                case "left":
                    player.x--;
                    break;
                case "right":
                    player.x++;
                    break;
                case "up":
                    player.y--;
                    break;
                case "down":
                    player.y++;
                    break;
            }

            if (player.x < 0) player.x = maxWidth;
            if (player.x > maxWidth) player.x = 0;
            if (player.y < 0) player.y = maxHeight;
            if (player.y > maxHeight) player.y = 0;

            Rectangle playerRect = new Rectangle(player.x * Settings.width, player.y * Settings.height, Settings.width, Settings.height);


            for (int i = foods.Count - 1; i >= 0; i--)
            {

                foods[i].x += foods[i].directionX;
                foods[i].y += foods[i].directionY;

                if (foods[i].x <= 0 || foods[i].x >= maxWidth)
                    foods[i].directionX *= -1;
                if (foods[i].y <= 0 || foods[i].y >= maxHeight)
                    foods[i].directionY *= -1;

                if (foods[i].x < 0) foods[i].x = 0;
                if (foods[i].x > maxWidth) foods[i].x = maxWidth;
                if (foods[i].y < 0) foods[i].y = 0;
                if (foods[i].y > maxHeight) foods[i].y = maxHeight;

                Rectangle foodRect = new Rectangle(
                    foods[i].x * Settings.food_width,
                    foods[i].y * Settings.food_height,
                    Settings.food_width,
                    Settings.food_height);

                if (playerRect.IntersectsWith(foodRect))
                {
                    game_over();
                    return;
                }

                bool foodHit = false;
                for (int j = traps.Count - 1; j >= 0; j--)
                {
                    Rectangle trapRect = new Rectangle(
                        traps[j].x * Settings.width,
                        traps[j].y * Settings.height,
                        Settings.width,
                        Settings.height);

                    if (trapRect.IntersectsWith(foodRect))
                    {
                        foodHit = true;
                        score += 5;
                        points.Text = score.ToString();
                        break;
                    }
                   
                }

                if (foodHit)
                {
                    foods.RemoveAt(i);
                    add_food();
                }
            }
            int remainingTraps = MAX_TRAPS - traps.Count;
    traps_count.Text = remainingTraps.ToString();
            field.Invalidate();
        }

        private void update_gamefield_graphics(object sender, PaintEventArgs e)
        {
            Graphics canvas = e.Graphics;

            canvas.FillEllipse(Brushes.Red, new Rectangle(
                player.x * Settings.width,
                player.y * Settings.height,
                Settings.width,
                Settings.height));

            foreach (var food in foods)
            {
                canvas.FillEllipse(Brushes.Blue, new Rectangle(
                    food.x * Settings.food_width,
                    food.y * Settings.food_height,
                    Settings.food_width,
                    Settings.food_height));
            }

            foreach (var trap in traps)
            {
                canvas.FillRectangle(Brushes.Yellow, new Rectangle(
                    trap.x * Settings.width,
                    trap.y * Settings.height,
                    Settings.width,
                    Settings.height));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (score == 20)
            {
                game_over();
            }

            if (score == 10)
            {
                for (int i = 0; i < 3; i++)
                {
                    add_food();
                }
            }
        }

        private void game_over()
        {
            timer.Stop();
            game_time.Stop();
            seconds = 0;
            start_button.Enabled = true;
            MessageBox.Show($"Игра окончена! Финальный счет: {score}");
        }

        private void add_food()
        {
            Food newFood = new Food();
            newFood.x = rand.Next(0, maxWidth + 1);
            newFood.y = rand.Next(0, maxHeight + 1);
            newFood.directionX = rand.Next(-1, 2);
            newFood.directionY = rand.Next(-1, 2);

            if (newFood.directionX == 0 && newFood.directionY == 0)
            {
                newFood.directionX = 1;
            }

            foods.Add(newFood);
        }

        private void place_trap()
        {
            if (traps.Count < MAX_TRAPS)
            {
                traps.Add(new Trap { x = player.x, y = player.y });
            }
        }

        private void field_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click_1(object sender, EventArgs e)
        {
        }
    }

    public class Food
    {
        public int x { get; set; }
        public int y { get; set; }
        public int directionX { get; set; }
        public int directionY { get; set; }
    }

    public class Trap
    {
        public int x { get; set; }
        public int y { get; set; }
    }
}
