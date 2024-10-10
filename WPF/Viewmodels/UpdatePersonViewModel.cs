using System.Windows.Input;
using WPF.Models;
using WPF.Services;
using WPF.Viewmodels;

namespace DepartmentPersonWPF.ViewModels
{
    public class UpdatePersonViewModel : BaseViewModel
    {
        public Person SelectedPerson { get; set; }
        public ICommand SavePersonCommand { get; }

        private readonly PersonService _personService;

        public UpdatePersonViewModel(Person person)
        {
            SelectedPerson = person;
            _personService = new PersonService();

            SavePersonCommand = new RelayCommand(UpdatePerson);
        }

        private async void UpdatePerson()
        {
            await _personService.UpdatePersonAsync(SelectedPerson);
            // Close window or notify that update was successful
        }
    }
}
