using StudentsManagementAPI.Models;

namespace StudentsManagementAPI.DTOs.Student
{
    public class GetStudentDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public Gender Gender { get; set; } = Gender.Male;
        public string Class { get; set; } = string.Empty;
        public FavoredSubject Subject { get; set; } = FavoredSubject.ICT;
    }
}
