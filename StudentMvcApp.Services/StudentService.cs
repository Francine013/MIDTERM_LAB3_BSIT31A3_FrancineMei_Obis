using StudentMvcApp.Data; // tama, dito kasi nakadeclare ang StudentDbContext
using StudentMvcApp.Entities.DTOs;
using StudentMvcApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StudentMvcApp.Services
{
    public class StudentService : IStudentService
    {
        private readonly StudentDbContext _context;

        public StudentService(StudentDbContext context)
        {
            _context = context;
        }

        public List<StudentDto> GetAll()
        {
            var students = _context.Students
                .Select(s => new StudentDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    Age = s.Age,
                    Course = s.Course
                })
                .ToList();

            return students;
        }

        public StudentDto GetById(int id)
        {
            var student = _context.Students.Find(id);
            
            if (student == null)
                return null;

            return new StudentDto
            {
                Id = student.Id,
                Name = student.Name,
                Age = student.Age,
                Course = student.Course
            };
        }

        public void Add(StudentDto studentDto)
        {
            if (studentDto == null)
                throw new ArgumentNullException(nameof(studentDto));

            var student = new Student
            {
                Name = studentDto.Name,
                Age = studentDto.Age,
                Course = studentDto.Course
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            // Update the DTO with the generated ID
            studentDto.Id = student.Id;
        }

        public void Update(StudentDto studentDto)
        {
            if (studentDto == null)
                throw new ArgumentNullException(nameof(studentDto));

            var student = _context.Students.Find(studentDto.Id);
            
            if (student == null)
                throw new ArgumentException($"Student with ID {studentDto.Id} not found");

            // Update the entity with new values
            student.Name = studentDto.Name;
            student.Age = studentDto.Age;
            student.Course = studentDto.Course;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            
            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
        }

        // Additional helper method to check if student exists
        public bool Exists(int id)
        {
            return _context.Students.Any(s => s.Id == id);
        }
    }
}