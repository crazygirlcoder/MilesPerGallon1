using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesPerGallon
{
    class PersonDetails
    {
        public string PersonName { get; set; }
        public string CarName { get; set; }
        public float MilesDriven { get; set; }
        public int Gallons { get; set; }
        public DateTime DateFilled { get; set; }
    }

    class CarNameMPG
    {
       
        public string CarName { get; set; }
        public float MilesPerGallon { get; set; }
       
    }
}
