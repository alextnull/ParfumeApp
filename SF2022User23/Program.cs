using SF2022User23Lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User23
{
    class Program
    {
        static void Main(string[] args)
        {
            var calc = new Calculations();
            TimeSpan[] startTime = new TimeSpan[5]
            {
                TimeSpan.Parse("10:00"),
                TimeSpan.Parse("11:00"),
                TimeSpan.Parse("15:00"),
                TimeSpan.Parse("15:30"),
                TimeSpan.Parse("16:50")
            };
            int[] durations = new int[5]
            {
                60,
                30,
                10,
                10,
                40,
            };
            TimeSpan beginWorkingTime = TimeSpan.Parse("08:00");
            TimeSpan endWorkingTime = TimeSpan.Parse("18:00");

            var availabelPerdiods = calc.AvailablePeriods(startTime, durations, beginWorkingTime, endWorkingTime, 30);
            foreach (var period in availabelPerdiods)
            {
                Console.WriteLine(period);
            }
            Console.ReadKey();
        }
    }
}
