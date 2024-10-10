using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WPF.Models;

namespace WPF.Services
{
    public class PersonService
    {
        private readonly HttpClient _httpClient;

        public PersonService()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("http://localhost:5045/api/") };
        }

        public async Task<List<Person>> GetPersonsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Person>>("Person");
        }

        public async Task AddPersonAsync(Person person)
        {
            await _httpClient.PostAsJsonAsync("Person", person);
        }

        public async Task UpdatePersonAsync(Person person)
        {
            await _httpClient.PutAsJsonAsync("Person", person);
        }

        public async Task DeletePersonAsync(int id)
        {
            await _httpClient.DeleteAsync($"Person/{id}");
        }
    }
}
