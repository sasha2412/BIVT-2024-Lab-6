using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab6
{
    public class Blue1
    {
        public struct Response
        {
            private string _name;
            private string _surname;
            private int _votes;
            public string Name { get { return _name; } }
            public string Surname { get { return _surname; } }
            public int Votes => _votes;

            public Response(string name, string surname)
            {
                _name = name;
                _surname = surname;
                _votes = 0;
            }
            public int CountVotes(Response[] responses)
            {
                if (responses == null || responses.Length == 0)
                    return 0;

                foreach (var response in responses)
                {
                    if (response.Name == _name && response.Surname == _surname)
                        _votes++;
                }
                return _votes;
            }
            public void Print()
            {
                WriteLine($"{_name} {_surname}: {_votes}");
            }
        }
    }
}
