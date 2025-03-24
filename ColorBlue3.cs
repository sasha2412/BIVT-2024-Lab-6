using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using System.Collections.ObjectModel;


namespace Lab6
{
    class Blue3
    {

        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[] _penaltyTimes;

            public string Name => _name;
            public string Surname => _surname;
            public ReadOnlyCollection<int> PenaltyTimes
            {
                get
                {
                    if (_penaltyTimes == null)
                    {
                        return null;
                    }
                    return new ReadOnlyCollection<int>(new List<int>(_penaltyTimes));
                }

            }
            public int TotalTime
            {
                get
                {
                    if (_penaltyTimes == null)
                        return 0;
                    int total = 0;
                    foreach (int time in _penaltyTimes)
                        total += time;
                    return total;
                }
            }
            public bool IsExpelled
            {
                get
                {
                    if (_penaltyTimes.Length == 0 || _penaltyTimes == null)
                    {
                        return true;
                    }
                    foreach (int i in PenaltyTimes)
                    {
                        if (i == 10)
                        {
                            return false;
                        }

                    }
                    return true;
                }
            }
            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _penaltyTimes = new int[0];
            }
            public void PlayMatch(int time)
            {
                if (_penaltyTimes == null)
                {
                    return;
                }
                int[] newPenaltytimes = new int[PenaltyTimes.Count];
                for (int i = 0; i < PenaltyTimes.Count; i++)
                {
                    newPenaltytimes[i] = PenaltyTimes[i];
                }
                newPenaltytimes[PenaltyTimes.Count] = time;
            }
            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length == 0)
                {
                    return;
                }
                var sortedArray = array.OrderBy(a => a.TotalTime).ToArray();
                Array.Copy(sortedArray, array, array.Length);
            }

            public void Print()
            {
                WriteLine($"{_name} {_surname}: ");
                foreach (int time in _penaltyTimes)
                    Write($"{time} ");
                WriteLine("");
                WriteLine($"Total time: {TotalTime} - {this.IsExpelled}");
            }
        }
    }
}
