using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static Lab6.Blue2;

namespace Lab6
{
    public class Blue2
    {
        public struct Participant
        {
            private string _name;
            private string _surname;
            private int[,] _marks;

            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int[,] Marks
            {
                get
                {
                    if (_marks == null) return null;
                    int[,] newMarks = new int[2, 5];
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                            newMarks[i, j] = _marks[i, j];
                    }
                    return newMarks;
                }
            }
            public int TotalScore
            {
                get
                {
                    if (_marks == null) return 0;
                    int total = 0;
                    for (int i = 0; i < 2; i++)
                    {
                        for (int j = 0; j < 5; j++)
                            total += _marks[i, j];
                    }
                    return total;
                }
            }

            public Participant(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _marks = new int[2, 5];
            }

            public void Jump(int[] result)
            {
                if (result == null || _marks == null)
                    return;
                int sum1 = 0; int sum2 = 0;
                for (int i = 0; i < 5; i++)
                {
                    sum1 += _marks[0, i];
                    sum2 += _marks[1, i];
                }
                if (sum1 == 0 && sum2 == 0)
                {
                    for (int i = 0; i < 5; i++)
                        _marks[0, i] = result[i];
                }
                else if (sum1 != 0 && sum2 == 0)
                {
                    for (int i = 0; i < 5; i++)
                        _marks[1, i] = result[i];
                }
            }

            public static void Sort(Participant[] array)
            {
                if (array == null || array.Length <= 1) return;
                var sortedArray = array.OrderByDescending(partic => partic.TotalScore).ToArray();
                Array.Copy(sortedArray, array, array.Length);
            }

            public void Print()
            {
                WriteLine($"{_name} {_surname}");
                Write("First: ");
                for (int i = 0; i < 5; i++)
                    Write($"{_marks[0, i]} ");
                WriteLine("");
                Write("Second: ");
                for (int i = 0; i < 5; i++)
                    Write($"{_marks[1, i]} ");
                WriteLine("");
            }
        }
    }
}

