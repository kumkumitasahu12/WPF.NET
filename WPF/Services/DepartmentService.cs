using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using WPF.Models;

namespace WPF.Services
{
    public class DepartmentService
    {
        private readonly HttpClient _httpClient;

        public DepartmentService()
        {
            _httpClient = new HttpClient { BaseAddress = new System.Uri("http://localhost:5045/api/") };
        }

        public async Task<List<Department>> GetDepartmentsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Department>>("Department");
        }

        public async Task AddDepartmentAsync(Department department)
        {
            await _httpClient.PostAsJsonAsync("Department", department);
        }

        public async Task UpdateDepartmentAsync(Department department)
        {
            await _httpClient.PutAsJsonAsync("Department", department);
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            await _httpClient.DeleteAsync($"Department/{id}");
        }
    }
}
