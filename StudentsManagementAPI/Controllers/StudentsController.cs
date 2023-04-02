using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentsManagementAPI.DTOs.Student;
using StudentsManagementAPI.Models;
using StudentsManagementAPI.Services.StudentService;

namespace StudentsManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentsController(IStudentService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> GetAllStudents()
        {
            return Ok(await _service.GetAllStudents());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> GetSingleStudent(int id)
        {           
            return Ok(await _service.GetStudentById(id));
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetStudentDto>>>> AddStudent(AddStudentDto student)
        {            
            return Ok(await _service.AddStudent(student));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> UpdateStudent(UpdateStudentDto student, int id)
        {
            var response = await _service.UpdateStudent(student);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<GetStudentDto>>> DeleteStudent(int id)
        {
            var response = await _service.DeleteStudent(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}
