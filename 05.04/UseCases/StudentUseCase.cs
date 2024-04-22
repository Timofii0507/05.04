using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05._04.UseCases
{
    
    public class StudentUseCase : Student, INotifyPropertyChanged
    {
        Student student { get; set; }
        public StudentUseCase(int studentId, string firstName, string lastName, int grades) : base(studentId, firstName, lastName, grades)
        {
            student = new Student(studentId, firstName, lastName, grades);
        }

        public int Id
        {
            get
            {
                return _studentId;
            }
            set
            {
                _studentId = value;
                OnPropertyChanged("Id");
            }
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public int Grades
        {
            get
            {
                return _grades;
            }
            set
            {
                _grades = value;
                OnPropertyChanged("Grades");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
