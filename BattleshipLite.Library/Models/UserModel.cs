using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipLite.Library.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public List<GridModel> UserGrid { get; set; }
        public List<string> ShipLocations { get; set; }
        public List<string> ShotGrid { get; set; }
    }
}
