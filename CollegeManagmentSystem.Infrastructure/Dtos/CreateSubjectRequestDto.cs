namespace CollegeManagementSystem.Infrastructure.Dtos
{
    public class CreateSubjectRequestDto
    {
        public string Name { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
    }
}
