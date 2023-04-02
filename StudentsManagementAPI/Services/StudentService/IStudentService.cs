using StudentsManagementAPI.DTOs.Student;
using StudentsManagementAPI.Models;

namespace StudentsManagementAPI.Services.StudentService
{
    public interface IStudentService
    {
        Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents();
        Task<ServiceResponse<GetStudentDto>> GetStudentById(int id);
        Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto student);
        Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto student);
        Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id);
    }
}
