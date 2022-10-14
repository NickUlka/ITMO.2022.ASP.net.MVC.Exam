using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ITMO._2022.ASP.net.MVC.Exam.Models;


namespace ITMO._2022.ASP.net.MVC.Exam.Controllers
{
    public class HomeController : Controller
    {
        StudentContext db = new StudentContext();

        private void AllStudents()
        {
            var allStudents = db.Students.ToList<Student>();
            ViewBag.Students = allStudents;
        }
        public ActionResult Index()
        {
                 return View();
        }

        [HttpGet]
        public ActionResult InputData()
        {
           AllStudents();
     
            return View();
        }

        public ActionResult OutputData()
        {
            AllStudents();
                
            return View("OutputData");
        }

        [HttpPost]
        public ActionResult InputData(Student newStudent)
        {
          if (!ModelState.IsValid)
            {
                return View();
            }
                db.Students.Add(newStudent);
            
                db.SaveChanges();
           
            return View();
 }

        public ActionResult BestStudents()
        {
      
            var bestFive = (from student in db.Students
                            orderby student.Sum descending
                            select student.Surname).Take(5);

          
            ViewBag.Students = bestFive;
            return View("BestStudents");
        }

        public ActionResult WorstStudents()
        {

            var worstFive = (from student in db.Students
                            orderby student.Sum ascending
                            select student.Surname).Take(5);


            ViewBag.Students = worstFive;
            return View("WorstStudents");
        }
    }
}