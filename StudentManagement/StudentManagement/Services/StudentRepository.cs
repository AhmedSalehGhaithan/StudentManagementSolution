using Microsoft.EntityFrameworkCore;
using StudentManagement.Data;
using StudentManagementShared.Models;
using StudentManagementShared.StudentRepository;

namespace StudentManagement.Services
{
    public class StudentRepository(ApplicationDbContext _dbContext) : IStudentRepository
    {
        public async Task<StudentTable> AddStudentAsync(StudentTable student)
        {
            if (student == null) return null;
            
            var newStudent =  _dbContext.Add(student).Entity;
            await _dbContext.SaveChangesAsync();
            return newStudent;
        }

        public async Task<StudentTable> DeleteStudentAsync(int studentId)
        {
            var student = await _dbContext.StudentsTable.FirstOrDefaultAsync(_s_ => _s_.Id == studentId);
            if (student == null) return null!;
            var delStudent = _dbContext.Remove(student).Entity;
            await _dbContext.SaveChangesAsync();
            return delStudent;
        }

        public async Task<List<StudentTable>> GetAllStudentsAsync() => await _dbContext.StudentsTable.ToListAsync();

        public async Task<StudentTable> GetStudentByIdAsync(int studentId)
        {
            var student = await _dbContext.StudentsTable.Where(_s_ => _s_.Id == studentId).FirstOrDefaultAsync();
            if (student == null) return null!;
            return student;
        }

        public async Task<StudentTable> UpdateStudentAsync(StudentTable student)
        {
            if (student == null) return null!;
            var studentToUpdate = await _dbContext.StudentsTable.Where(_s_ => _s_.Id == student.Id).FirstOrDefaultAsync();
            if (studentToUpdate == null) return null!;

            var stup = _dbContext.StudentsTable.Update(student).Entity;
            await _dbContext.SaveChangesAsync();
            return stup;

        }
    }
}
