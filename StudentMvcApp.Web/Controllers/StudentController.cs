using Microsoft.AspNetCore.Mvc;
using StudentMvcApp.Entities.DTOs;
using StudentMvcApp.Services;

namespace StudentMvcApp.Web.Controllers
{
    [Route("Student")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            var students = _studentService.GetAll();
            return View(students);
        }
    }
}
