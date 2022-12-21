using System.ComponentModel.DataAnnotations;

namespace WebApi.Domain
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public int Age { get; set; }

        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? TelNumber { get; set; }
    }
}