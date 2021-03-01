using EFTutorial.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFTutorial {
    public class MajorController {

        private readonly eddbContext _context;

        public IEnumerable<Major> GetAll() {
            return _context.Majors.ToList();
        }

        public Major GetByPK(int id) {
            return _context.Majors.Find(id);
        }

        public Major Create(Major major) {
            if (major == null) {
                throw new Exception("Major cannot be NULL");
            }
            if (major.Id != 0) {
                throw new Exception("Major.Id has to be zero");
            }
            _context.Majors.Add(major);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1) {
                throw new Exception("Create failed");
            } 
            return major;
        }

        public void change(Major major) {
            if(major == null) {
                throw new Exception("Major cannot be NULL");
            }
            if(major.Id <= 0) {
                throw new Exception("Major.Id has to be greater than zero");
            }
            _context.Entry(major).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1) {
                throw new Exception("Change Failed");
            }
            return;
        }

        public Major Remove(int id) {
            var major = _context.Majors.Find(id);
            if(major == null) {
                return null;
            }
            _context.Majors.Remove(major);
            var rowsAffected = _context.SaveChanges();
            if(rowsAffected != 1) {
                throw new Exception("Delete FAILED");
            }
            return major;
        }


        public MajorController() {
            _context = new eddbContext();
        }
    }
}
