using Microsoft.AspNetCore.Mvc;
using StudentMvcApp.Entities.DTOs;
using StudentMvcApp.Services;

namespace StudentMvcApp.Web.Controllers
{
    [Route("Students")]
    public class StudentsController : Controller
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
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
