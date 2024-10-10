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

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OpenDepartmentView(object sender, RoutedEventArgs e)
        {
            var departmentView = new Views.Department();
            departmentView.DataContext = new Viewmodels.DepartmentViewModel();
            departmentView.Show();
        }

        private void OpenPersonView(object sender, RoutedEventArgs e)
        {
            var personView = new Views.Person();
            personView.DataContext = new Viewmodels.PersonViewModel();
            personView.Show();
        }

    }
}