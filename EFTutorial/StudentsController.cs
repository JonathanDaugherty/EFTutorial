using EFTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFTutorial {
    public class StudentsController {

        private readonly eddbContext _context;

        public IEnumerable<Student>GetBySATRange(int LowSAT, int HighSAT) {
            return _context.Students
                .Where(s => s.Sat >= LowSAT && s.Sat <= HighSAT)
                .OrderByDescending(s => s.Sat)
                .ToList();
        }


        
        
        public IEnumerable<Student> GetAll() {
            return _context.Students.ToList();
        }

        public Student GetByPK(int id) {
            return _context.Students.Find(id);
        }

        public Student Create(Student student) {
            if(student == null) {
                throw new Exception("Student cannot be NULL");
            } 
            if(student.Id != 0) {
                throw new Exception("Student.Id must be zero!");
            }
            _context.Students.Add(student);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1) {
                throw new Exception("Create Failed");
            }
            return student;
        }

        public void change(Student student) {
            if (student == null) {
                throw new Exception("Student cannot be NULL");
            }
            if(student.Id <= 0) {
                throw new Exception("Student.Id must be greater than zero!");
            }
            _context.Entry(student).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1) {
                throw new Exception("Change failed!");
            }
            return;
        }

        public Student Remove(int id) {
            var student = _context.Students.Find(id);
            if (student == null ) {
                return null;
            }
            _context.Students.Remove(student);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1) {
                throw new Exception("Remove Failed!!!!!");
            }
            return student;
        } 

        public StudentsController() {
           _context = new eddbContext();
        }

    }
}
