using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCApp2.Models
{
    public class GameModel
    {

        public int Seed { get; set; }

        public int Guess { get; set; }
        
        public string HighOrLow { get; set; }

        public bool Winner { get; set; }
    }
}