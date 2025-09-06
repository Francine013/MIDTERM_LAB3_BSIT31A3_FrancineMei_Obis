using System.ComponentModel.DataAnnotations;

namespace StudentMvcApp.Entities.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Course { get; set; }
    }

}