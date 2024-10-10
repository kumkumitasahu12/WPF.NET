using System.Windows;
using System.Windows.Input;
using WPF.Models;
using WPF.Services;

namespace WPF.Viewmodels
{
    public class UpdatePersonViewModel : BaseViewModel
    {
        private readonly PersonService _personService;
        private Person _personToUpdate;

        public Person PersonToUpdate
        {
            get => _personToUpdate;
            set => SetProperty(ref _personToUpdate, value);
        }

        public ICommand SaveCommand { get; }

        public UpdatePersonViewModel(Person selectedPerson)
        {
            _personService = new PersonService();
            PersonToUpdate = selectedPerson;

            // Initialize SaveCommand
            SaveCommand = new RelayCommand(SavePerson);
        }

        private async void SavePerson()
        {
            if (PersonToUpdate != null)
            {
                // Assuming you have a method to update the person in your service
                await _personService.UpdatePersonAsync(PersonToUpdate);
                // Close the window after saving
                Application.Current.Windows[0].Close(); // Close the current window
            }
        }
    }
}
