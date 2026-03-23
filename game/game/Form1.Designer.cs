namespace game
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.field = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.score_points = new System.Windows.Forms.Label();
            this.start_button = new System.Windows.Forms.Button();
            this.points = new System.Windows.Forms.Label();
            this.traps_count = new System.Windows.Forms.Label();
            this.game_time = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.field)).BeginInit();
            this.SuspendLayout();
            // 
            // timer
            // 
            this.timer.Interval = 40;
            this.timer.Tick += new System.EventHandler(this.timer_event);
            // 
            // field
            // 
            this.field.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.field.Location = new System.Drawing.Point(295, 45);
            this.field.Name = "field";
            this.field.Size = new System.Drawing.Size(400, 400);
            this.field.TabIndex = 0;
            this.field.TabStop = false;
            this.field.Click += new System.EventHandler(this.field_Click);
            this.field.Paint += new System.Windows.Forms.PaintEventHandler(this.update_gamefield_graphics);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(833, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Очки: ";
            // 
            // score_points
            // 
            this.score_points.AutoSize = true;
            this.score_points.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.score_points.Location = new System.Drawing.Point(946, 69);
            this.score_points.Name = "score_points";
            this.score_points.Size = new System.Drawing.Size(0, 37);
            this.score_points.TabIndex = 2;
            // 
            // start_button
            // 
            this.start_button.Location = new System.Drawing.Point(53, 113);
            this.start_button.Name = "start_button";
            this.start_button.Size = new System.Drawing.Size(139, 57);
            this.start_button.TabIndex = 3;
            this.start_button.Text = "начать";
            this.start_button.UseVisualStyleBackColor = true;
            this.start_button.Click += new System.EventHandler(this.start_button_Click);
            // 
            // points
            // 
            this.points.AutoSize = true;
            this.points.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.points.Location = new System.Drawing.Point(952, 69);
            this.points.Name = "points";
            this.points.Size = new System.Drawing.Size(35, 37);
            this.points.TabIndex = 4;
            this.points.Text = "0";
            this.points.Click += new System.EventHandler(this.label2_Click);
            // 
            // traps_count
            // 
            this.traps_count.AutoSize = true;
            this.traps_count.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.traps_count.Location = new System.Drawing.Point(946, 215);
            this.traps_count.Name = "traps_count";
            this.traps_count.Size = new System.Drawing.Size(35, 37);
            this.traps_count.TabIndex = 5;
            this.traps_count.Text = "0";
            // 
            // game_time
            // 
            this.game_time.Interval = 1000;
            this.game_time.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1135, 657);
            this.Controls.Add(this.traps_count);
            this.Controls.Add(this.points);
            this.Controls.Add(this.start_button);
            this.Controls.Add(this.score_points);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.field);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.key_is_down);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.key_is_up);
            ((System.ComponentModel.ISupportInitialize)(this.field)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.PictureBox field;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label score_points;
        private System.Windows.Forms.Button start_button;
        private System.Windows.Forms.Label points;
        private System.Windows.Forms.Label traps_count;
        private System.Windows.Forms.Timer game_time;
    }
}

