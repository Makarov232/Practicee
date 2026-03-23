using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace game
{
    internal class Settings
    {
        public static int width { get; set; }
        public static int height { get; set; }
        public static int food_width { get; set; }
        public static int food_height { get; set; }
        public static string directions;

        public Settings() 
        { 
            width = 20; 
            height = 20;
            food_height = 15;
            food_width = 15;
            directions = "down";
            
        }
    }
}
