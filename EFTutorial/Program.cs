using EFTutorial.Models;
using System;
using System.Linq;

namespace EFTutorial {
    class Program {
        static void Main(string[] args) {


            var mctrl = new MajorController();
            var majors = mctrl.GetAll();
            foreach(var m in majors) {
                //Console.WriteLine($"{m.Code} | {m.Description}");
            }

            var pk = mctrl.GetByPK(1);
            if(pk == null) {
                Console.WriteLine("Not Found");
            } else {

                Console.WriteLine($"{pk.Id}, {pk.Description}");
            }

            var newmajor = new Major {
                Id = 0, Code = "BIKE", Description = "Biking", MinSat = 1000
            };
            //var BIKE = mctrl.Create(newmajor);

            //Console.WriteLine($"{BIKE.Id}, {BIKE.Description}");

            var mup = mctrl.GetByPK(13);
            //mup.Code = "RUN";
            //mup.Description = "Running";
            //mctrl.change(mup);

            //var majordeleted = mctrl.Remove(mup.Id);


            //var sctrl = new StudentsController();
            //var students = sctrl.GetAll();
            //foreach (var s in students) {
            //    //Console.WriteLine($"{s.Firstname} {s.Lastname}");
            //}



            //var sJon = new Student {
            //    Id = 0, Firstname = "Jon", Lastname = "Daugherty", StateCode = "OH", Gpa = 3.2m, Sat = 1650, MajorId = 1
            //};
            ////var sJonNew = sctrl.Create(sJon);
            ////Console.WriteLine($" {sJonNew.Id} | {sJonNew.Firstname} | {sJonNew.Lastname}");


            //var std = sctrl.GetByPK(65);
            //std.StateCode = "DC";
            //sctrl.change(std);

            ////var studentdeleted = sctrl.Remove(std.Id);

            //var st = sctrl.GetByPK(std.Id);
            //if(st == null) {
            //    Console.WriteLine("Not Found");
            //} else {
            //    Console.WriteLine($"{st.Firstname} | {st.Lastname}");
            //}


            //var students1 = sctrl.GetBySATRange(1000, 1200);
            //foreach(var s in students1) {
            //    Console.WriteLine($"{s.Firstname} | {s.Lastname}");
            //}


        }
        static void Run1() { 
            var _context = new eddbContext();
            //_context.Students.ToList()
            //    .ForEach(s => Console.WriteLine($"{s.Firstname} {s.Lastname}"));

            //var majors = from m in _context.Majors
            //             where m.MinSat > 1000
            //             orderby m.Description
            //             select m;

            //foreach(var m in majors) {
            //    Console.WriteLine($"{m.Description} | {m.MinSat}");
            //}

            var studentmajor = (from s in _context.Students
                               join m in _context.Majors
                               on s.MajorId equals m.Id 
                                select new {
                                   Name = s.Firstname + " " + s.Lastname,
                                   Major = m.Description
                               }).ToList();
                                    
            studentmajor.ForEach(s => Console.WriteLine($"{s.Name} | {s.Major}"));


            


        }
    }
}





            
