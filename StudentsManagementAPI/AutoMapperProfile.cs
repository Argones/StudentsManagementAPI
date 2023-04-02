using AutoMapper;
using StudentsManagementAPI.DTOs.Student;
using StudentsManagementAPI.Models;

namespace StudentsManagementAPI
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, GetStudentDto>();
            CreateMap<AddStudentDto, Student>();
            CreateMap<UpdateStudentDto, Student>();
        }
    }
}
