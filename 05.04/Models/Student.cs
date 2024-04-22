using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04
{
    public class Student
    {
        protected int _studentId { get; set; }
        protected string _firstName { get; set; }
        protected string _lastName { get; set; } = ""; // Дефолтне значення для LastName
        protected int _grades { get; set; } // Спрощена ініціалізація

        public Student(int studentId, string firstName, string lastName, int grades)
        {
            _studentId = studentId;
            _firstName = firstName;
            _lastName = lastName;
        }

        public override string ToString()
        {
            return $"{_firstName} {_lastName}";
        }
    }
}