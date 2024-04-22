using _05._04.UseCases;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _05._04
{
    public partial class MainWindow : Window
    {
        StudentService StudentService { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            StudentService = new StudentService();
        }

        // Реалізація обробників подій
        private void AddStudent_Click(object sender, RoutedEventArgs e)
        {
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();

            if (!string.IsNullOrWhiteSpace(firstName) && !string.IsNullOrWhiteSpace(lastName))
            {
                firstNameTextBox.Text = string.Empty;
                lastNameTextBox.Text = string.Empty;

                StudentService.AddStudent(firstName, lastName);
                dgStudents.ItemsSource = StudentService.GetAllStudents();
                dgStudents.Items.Refresh();
                MessageBox.Show("Student added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please enter both first name and last name.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void DeleteStudent_Click(object sender, RoutedEventArgs e)
        { 
            if (dgStudents.SelectedItem != null)
            {
                StudentUseCase item = (StudentUseCase)dgStudents.SelectedItem;
                StudentService.DeleteStudent(item.Id);
                dgStudents.ItemsSource = StudentService.GetAllStudents();
                dgStudents.Items.Refresh();
                MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Please select a student to delete.", "Input Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void dgStudents_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            StudentUseCase item = (StudentUseCase)dgStudents.SelectedItem;
            if (item != null)
            {
                MessageBox.Show($"{item.Id} {item.FirstName} {item.Grades}");
            }
        }
    }
}