using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace УП_Субботин_5
{
    public class Astronaut
    {
        public string Name;
        public int Age;
        public int NumOfFlight;
        public int DayOfFlight;

        public Astronaut(string name, int age, int numberofflight, int dayofflight)
        {
            this.Name = name;
            this.Age = age;
            this.NumOfFlight = numberofflight;
            this.DayOfFlight = dayofflight;
        }

        public string GetInfo()
        {
            return $"Космонавт {Name}, которому {Age}, бывавший в полетах {NumOfFlight} раз, провел {DayOfFlight} дней в полете.";
        }

        public string GetHours()
        {
            return $"Космонавт {Name} летал {DayOfFlight * 24} часов";
        }

        public int GetAverage()
        {
            return (DayOfFlight - 1 * 24) / NumOfFlight;
        }

        public string GetFlight()
        {
            DayOfFlight ++;
            NumOfFlight ++;
            return $"Космонавт {Name}, которому {Age} лет, с числом полетов: {NumOfFlight} и дней проведенных в полете: {DayOfFlight}. Полетел!";
        }
    }
}
