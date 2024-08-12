using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagementShared.Models;
using StudentManagementShared.StudentRepository;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController(IStudentRepository _studentRepository) : ControllerBase
    {
        [HttpGet("all-Student")]
        public async Task<ActionResult<List<StudentTable>>> GetAllStudentAsync()
        {
            var student = await _studentRepository.GetAllStudentsAsync();
            return Ok(student);
        }
        [HttpGet("Single-Student/{studentId}")]
        public async Task<ActionResult<StudentTable>> GetStudentByIdAsync(int studentId)
        {
            var student = await _studentRepository.GetStudentByIdAsync(studentId);
            return Ok(student);
        }

        [HttpPost("Add-Student")]
        public async Task<ActionResult<StudentTable>> AddStudentAsync(StudentTable student)
        {
            var studentOb = await _studentRepository.AddStudentAsync(student);
            return Ok(studentOb);
        }

        [HttpPut("Update-Student")]
        public async Task<ActionResult<StudentTable>> UpdateStudentAsync(StudentTable student)
        {
            var studentOb = await _studentRepository.UpdateStudentAsync(student);
            return Ok(studentOb);
        }

        [HttpDelete("Delete-Student/{studentId}")]
        public async Task<ActionResult<StudentTable>> DeleteStudentAsync(int studentId)
        {
            var studentOb = await _studentRepository.DeleteStudentAsync(studentId);
            return Ok(studentOb);
        }
    }
}
