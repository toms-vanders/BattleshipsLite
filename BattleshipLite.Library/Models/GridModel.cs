using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.Library.Models
{
    public class GridModel
    {
        public string SpotLetter { get; set; }
        public int SpotNumber { get; set; }
        public enum Status
        {
            Empty,
            Hit,
            Miss,
        }

    }
}
