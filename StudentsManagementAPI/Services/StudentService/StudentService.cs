using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentsManagementAPI.Data;
using StudentsManagementAPI.DTOs.Student;
using StudentsManagementAPI.Models;
using System.Diagnostics;

namespace StudentsManagementAPI.Services.StudentService
{
    public class StudentService : IStudentService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public StudentService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }       

        public async Task<ServiceResponse<List<GetStudentDto>>> AddStudent(AddStudentDto newStudent)
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            var student = _mapper.Map<Student>(newStudent);
            
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
           
            serviceResponse.Data = await _context.Students
                .Select(s => _mapper.Map<GetStudentDto>(s))
                .ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> GetAllStudents()
        {
            var serviceResponse = new ServiceResponse<List<GetStudentDto>>();
            var students = await _context.Students.ToListAsync();
            serviceResponse.Data = students.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> GetStudentById(int id)
        {
            var serviceResponse = new ServiceResponse<GetStudentDto>();
            var student = await _context.Students.FindAsync(id);
            serviceResponse.Data = _mapper.Map<GetStudentDto>(student);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetStudentDto>> UpdateStudent(UpdateStudentDto updatedStudent, int id)
        {
            ServiceResponse<GetStudentDto> response = new ServiceResponse<GetStudentDto>();

            try
            {
                Student student = await _context.Students.FirstOrDefaultAsync(c => c.Id == updatedStudent.Id);

                if (student != null)
                {
                    _mapper.Map(updatedStudent, student);

                    _context.Students.Update(student);
                    await _context.SaveChangesAsync();

                    response.Data = _mapper.Map<GetStudentDto>(student);
                }
                else
                {
                    response.Success = false;
                    response.Message = "Student not found.";
                }
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }

        public async Task<ServiceResponse<List<GetStudentDto>>> DeleteStudent(int id)
        {
            ServiceResponse<List<GetStudentDto>> response = new ServiceResponse<List<GetStudentDto>>();

            try
            {
                var student = await _context.Students.FindAsync(id);

                if (student == null)
                {
                    response.Success = false;
                    response.Message = "Student not found";
                    return response;
                }

                _context.Students.Remove(student);
                await _context.SaveChangesAsync();

                response.Data = await _context.Students.Select(s => _mapper.Map<GetStudentDto>(s)).ToListAsync();
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
