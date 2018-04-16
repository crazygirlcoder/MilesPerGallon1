using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MilesPerGallon
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = "C:/Users/sharmishta/Downloads/Book1.csv";
            var csvRows = System.IO.File.ReadAllLines(path, Encoding.Default).ToArray();
            Person person = new Person();
            Dictionary<string, Person> dictionary = new Dictionary<string, Person>();

            foreach (var row in csvRows.Skip(1))
            {
                var columns = row.Split(',');
                person.PersonName = columns[0];
                person.CarName = columns[1];
                person.MilesDriven = float.Parse(columns[2]);
                person.Gallons = Convert.ToInt32(columns[3]);
                person.DateFilled = Convert.ToDateTime(columns[4]);

                dictionary.Add(person.PersonName,person);
                GetRange("jack", DateTime.Now,DateTime.Now);

            }

             CarNameMPG GetRange(string personName, DateTime startDate, DateTime endDate)
            {

                CarNameMPG carNameMPG = new CarNameMPG();
                Person persondriving = dictionary[personName];
                if(persondriving.DateFilled<endDate && persondriving.DateFilled > startDate)
                {
                    var milesPerGallon = CalculateMilesPerGallon(persondriving.MilesDriven, persondriving.Gallons);
                    
                    carNameMPG.CarName = persondriving.CarName;
                    carNameMPG.MilesPerGallon = milesPerGallon;
                }
                               
                return carNameMPG;

            }

             float CalculateMilesPerGallon(float Totalmiles, int Totalgallons)
            {

                var milesPerGallon = Totalmiles / Totalgallons;
                return milesPerGallon;

            }


        }
            
    }
}
