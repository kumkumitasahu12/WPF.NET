using System.Collections.ObjectModel;
using System.Windows.Input;
using WPF.Models;
using WPF.Services;

namespace WPF.Viewmodels
{
    public class PersonViewModel : BaseViewModel
    {
        private ObservableCollection<Person> _persons;
        private Person _selectedPerson;

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            set => SetProperty(ref _persons, value);
        }

        public Person SelectedPerson
        {
            get => _selectedPerson;
            set
            {
                SetProperty(ref _selectedPerson, value);
                // Notify command that SelectedPerson has changed, reevaluating CanExecute
                CommandManager.InvalidateRequerySuggested();
            }
        }

        public ICommand AddPersonCommand { get; }
        public ICommand UpdatePersonCommand { get; }
        public ICommand DeletePersonCommand { get; }

        private readonly PersonService _personService;

        public PersonViewModel()
        {
            _personService = new PersonService();
            Persons = new ObservableCollection<Person>();

            // Commands for CRUD operations
            AddPersonCommand = new RelayCommand(OpenAddPersonWindow);
            UpdatePersonCommand = new RelayCommand(OpenUpdatePersonWindow, () => SelectedPerson != null);
            DeletePersonCommand = new RelayCommand(DeletePerson, () => SelectedPerson != null);

            LoadPersons();
        }

        public async void LoadPersons()
        {
            var persons = await _personService.GetPersonsAsync();
            Persons.Clear();
            foreach (var person in persons)
            {
                Persons.Add(person);
            }
        }

        private void OpenAddPersonWindow()
        {
            var addPersonWindow = new Views.AddPersonWindow();
            addPersonWindow.ShowDialog();
            LoadPersons(); // Reload after adding new person
        }

        private void OpenUpdatePersonWindow()
        {
            if (SelectedPerson != null)
            {
                var updatePersonWindow = new Views.UpdatePersonWindow(); // Pass selected person for update
                updatePersonWindow.ShowDialog();
                LoadPersons(); // Reload after updating the person
            }
        }

        private async void DeletePerson()
        {
            if (SelectedPerson != null)
            {
                await _personService.DeletePersonAsync(SelectedPerson.Id);
                LoadPersons(); // Reload after deleting the person
            }
        }
    }
}
