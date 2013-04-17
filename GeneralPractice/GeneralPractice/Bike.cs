using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GeneralPractice
{
    class Bike
    {
        public int NumberOfWheels { get; set; }
        public bool HasALight { get; set; }
        public string Colour { get; set; }
        public int MilesOnTheClock { get; set; }

        public void GoForARide(int HowManyMiles)
        {
            MilesOnTheClock += HowManyMiles;
        }

        public Bike(string colour, int numberOfWheels)
        {
            this.Colour = Colour;
            this.NumberOfWheels = 2;
        }


    }
}
