using System.Collections.ObjectModel;
using WPF.Models;
using WPF.Services;

namespace WPF.Viewmodels
{
    public class DepartmentViewModel : BaseViewModel
    {
        private readonly DepartmentService _departmentService;

        public ObservableCollection<Department> Departments { get; set; }

        public DepartmentViewModel()
        {
            _departmentService = new DepartmentService();
            Departments = new ObservableCollection<Department>();
            LoadDepartments();
        }

        public async void LoadDepartments()
        {
            var departments = await _departmentService.GetDepartmentsAsync();
            Departments.Clear();
            foreach (var department in departments)
            {
                Departments.Add(department);
            }
        }

        public async Task AddDepartment(Department department)
        {
            await _departmentService.AddDepartmentAsync(department);
            LoadDepartments();
        }

        public async Task UpdateDepartment(Department department)
        {
            await _departmentService.UpdateDepartmentAsync(department);
            LoadDepartments();
        }

        public async Task DeleteDepartment(int departmentId)
        {
            await _departmentService.DeleteDepartmentAsync(departmentId);
            LoadDepartments();
        }
    }
}
