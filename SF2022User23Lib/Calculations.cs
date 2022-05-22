using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF2022User23Lib
{
    public class Calculations
    {
        /// <summary>
        /// Рассчитывает список свободных временных интервалов (заданного размера) в графике сотрудника ООО «Парфюмер».
        /// </summary>
        /// <param name="startTimes">Время начала в списке занятых промежутков времени.</param>
        /// <param name="durations">Длительность в списке занятых промежутков времени.</param>
        /// <param name="beginWorkingTime">Время начала рабочего дня сотрудника.</param>
        /// <param name="endWorkingTime">Время завершения рабочего дня сотрудника.</param>
        /// <param name="consultationTime">Минимальное необходимое время для работы менеджера.</param>
        /// <returns>Список свободных временных интервалов в графике сотрудника ООО «Парфюмер».</returns>
        public string[] AvailablePeriods(TimeSpan[] startTimes,
            int[] durations,
            TimeSpan beginWorkingTime,
            TimeSpan endWorkingTime,
            int consultationTime)
        {
            if (startTimes.Length != durations.Length)
                throw new Exception("Время начала и длительность должны иметь одинаковое количество");
            if (endWorkingTime < beginWorkingTime)
                throw new Exception("Завершение рабочего дня не может быть, меньше времени начала рабочего дня");
            if (beginWorkingTime > endWorkingTime)
                throw new Exception("Начало рабочего дня не может быть, больше времени завершения рабочего дня");
            if (consultationTime < 0)
                throw new Exception("Минимальное необходимо время для работы менеджера не может быть отрицательным");

            var periods = new List<string>();
            var beginAvailable = new List<TimeSpan>();
            var endAvailable = new List<TimeSpan>();
            for (var workingTime = beginWorkingTime; workingTime < endWorkingTime;
                workingTime += TimeSpan.FromMinutes(consultationTime))
            {
                var beginAvailableTime = workingTime;
                var endAvailableTime = workingTime + TimeSpan.FromMinutes(consultationTime);

                beginAvailable.Add(beginAvailableTime);
                endAvailable.Add(endAvailableTime);
            }

            var endTimes = new TimeSpan[startTimes.Length];
            for (var i = 0; i < startTimes.Length; i++)
            {
                endTimes[i] = startTimes[i].Add(TimeSpan.FromMinutes(durations[i]));
            }

            beginAvailable = beginAvailable.Except(startTimes).Except(endTimes).ToList();
            endAvailable = endAvailable.Union(beginAvailable).Except(endTimes).Except(startTimes).ToList();

            for (var interval = 0; interval < endAvailable.Count(); interval++)
            {
                //periods.Add($"{beginAvailable[interval].ToString(@"hh\:mm")}-{endAvailable[interval].ToString(@"hh\:mm")}");
                periods.Add($"{endAvailable[interval]}");

            }

            return periods.ToArray();
        }
    }
}
