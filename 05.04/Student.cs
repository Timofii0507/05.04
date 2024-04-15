using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } = ""; // Дефолтне значення для LastName
        public List<int> Grades { get; set; } = new(); // Спрощена ініціалізація

        public string FullName => $"{FirstName} {LastName}";

        public Student()
        {
            FirstName = ""; // Ініціалізуємо FirstName пустим рядком
        }
    }
}