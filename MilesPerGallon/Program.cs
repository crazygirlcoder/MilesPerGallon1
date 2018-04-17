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
            PersonDetails person = new PersonDetails();

            Dictionary<string, List<PersonDetails>> dictionary = new Dictionary<string, List<PersonDetails>>();

            foreach (var row in csvRows.Skip(1))
            {
                var columns = row.Split(',');
                person.PersonName = columns[0];
                person.CarName = columns[1];
                person.MilesDriven = float.Parse(columns[2]);
                person.Gallons = Convert.ToInt32(columns[3]);
                person.DateFilled = Convert.ToDateTime(columns[4]);
                if (!dictionary.Keys.Contains(person.PersonName))
                    dictionary.Add(person.PersonName, new List<PersonDetails>());

                dictionary[person.PersonName].Add(person);

                var rangeMPGs = GetRange("jack", DateTime.Now, DateTime.Now);

            }

            List<CarNameMPG> GetRange(string personName, DateTime startDate, DateTime endDate)
            {
                var carNameMPG = new CarNameMPG();
                List<PersonDetails> persondriving = dictionary[personName];
                List<CarNameMPG> carRecords = new List<CarNameMPG>();

                foreach (var entry in persondriving)
                {
                    if (entry.DateFilled < endDate && entry.DateFilled > startDate)
                    {
                        var milesPerGallon = CalculateMilesPerGallon(entry.MilesDriven, entry.Gallons);
                        carNameMPG.CarName = entry.CarName;
                        carNameMPG.MilesPerGallon = milesPerGallon;
                        carRecords.Add(carNameMPG);
                    }

                }
                return carRecords;
            }

            float CalculateMilesPerGallon(float Totalmiles, int Totalgallons)
            {

                var milesPerGallon = Totalmiles / Totalgallons;
                return milesPerGallon;

            }


        }


    }
}
