namespace Venhancer.Crowd.Identity.Core.Dtos
{
    public class CreateUserCVDto:BaseDto
    {
        public class CvType
        {
            public string? Id { get; set; }
            public string? Name { get; set; }
        }
        public class PersonalInformation
        {
            public string? Id { get; set; }
            public string? Avatar { get; set; }
            public string? FirstName { get; set; }
            public string? LastName { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string? HomeAddress { get; set; }
        }
        public class Experience
        {
            public string? CompanyName { get; set; }
            public DateTime DateOfStart { get; set; }
            public DateTime DateofEnd { get; set; }
            public string? Description { get; set; }
        }
        public class Skills
        {
            public string? CompanyName { get; set; }
            public DateTime DateOfStart { get; set; }
            public DateTime DateofEnd { get; set; }
            public string? Description { get; set; }
        }
        public CvType? cvType { get; set; }
        public List<Experience>? experiences { get; set; }
    }
}
