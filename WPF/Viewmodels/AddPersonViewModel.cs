using System.Windows.Input;
using WPF.Models;
using WPF.Services;

namespace WPF.Viewmodels
{
    public class AddPersonViewModel : BaseViewModel
    {
        public Person NewPerson { get; set; }
        public ICommand SavePersonCommand { get; }

        private readonly PersonService _personService;

        public AddPersonViewModel()
        {
            NewPerson = new Person();
            _personService = new PersonService();

            SavePersonCommand = new RelayCommand(SavePerson);
        }

        private async void SavePerson()
        {
            await _personService.AddPersonAsync(NewPerson);
            // Close window or notify that save was successful
        }
    }
}
