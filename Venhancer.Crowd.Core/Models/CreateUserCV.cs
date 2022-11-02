using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Venhancer.Crowd.Core.Models
{
    public class CreateUserCV
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
            public string? Id { get; set; }
            public string? Name { get; set; }
        }
        public CvType? cvType { get; set; }
        public PersonalInformation? personalInformation { get; set; }
        public List<Experience>? experiences { get; set; }
        public List<Skills>? skills { get; set; }
    }
}
