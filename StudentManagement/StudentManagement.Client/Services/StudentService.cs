using StudentManagementShared.Models;
using StudentManagementShared.StudentRepository;
using System.Net.Http.Json;

namespace StudentManagement.Client.Services
{
    public class StudentService(HttpClient _httpClient) : IStudentRepository
    {
        private const string BaseAddress = "api/Student";
        public async Task<StudentTable> AddStudentAsync(StudentTable student)
        {
            var newtudent = await _httpClient.PostAsJsonAsync($"{BaseAddress}/Add-Student", student);
            var response = await newtudent.Content.ReadFromJsonAsync<StudentTable>();
            return response!;
        }

        public async Task<StudentTable> DeleteStudentAsync(int studentId)
        {
            var delStudent = await _httpClient.DeleteAsync($"{BaseAddress}/Delete-Student/{studentId}");
            var response = await delStudent.Content.ReadFromJsonAsync<StudentTable>();
            return response!;
        }

        public async Task<List<StudentTable>> GetAllStudentsAsync()
        {
            var allStudent = await _httpClient.GetAsync($"{BaseAddress}/All-Student");
            var response = await allStudent.Content.ReadFromJsonAsync<List<StudentTable>>();
            return response!;
        }

        public async Task<StudentTable> GetStudentByIdAsync(int studentId)
        {
            var singleStudent = await _httpClient.GetAsync($"{BaseAddress}/Single-Student/{studentId}");
            var response = await singleStudent.Content.ReadFromJsonAsync<StudentTable>();
            return response!;
        }

        public async Task<StudentTable> UpdateStudentAsync(StudentTable student)
        {
            var updateStudent = await _httpClient.PostAsJsonAsync($"{BaseAddress}/Update-Student/", student);
            var response = await updateStudent.Content.ReadFromJsonAsync<StudentTable>();
            return response!;
        }
    }
}
