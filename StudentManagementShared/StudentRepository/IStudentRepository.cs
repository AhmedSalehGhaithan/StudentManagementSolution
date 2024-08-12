using StudentManagementShared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementShared.StudentRepository
{
    public interface IStudentRepository
    {
        Task<StudentTable> AddStudentAsync(StudentTable student);
        Task<StudentTable> UpdateStudentAsync(StudentTable student);
        Task<StudentTable> DeleteStudentAsync(int studentId);
        Task<List<StudentTable>> GetAllStudentsAsync();
        Task<StudentTable> GetStudentByIdAsync(int studentId);
    }
}
