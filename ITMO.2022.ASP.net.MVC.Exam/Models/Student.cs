using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ITMO._2022.ASP.net.MVC.Exam.Models
{
    public class Student
    {
        public  int Id { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        public  string Name { get; set; }
        
        [Required(ErrorMessage = "Поле обязательно для заполнения")]
        [DataType(DataType.Text)]
        public string Surname { get; set; }
        public int Mark1 { get; set; }
        public  int Mark2 { get; set; }
        public  int Mark3 { get; set; }
        public int Mark4 { get; set; }
        public  int Mark5 { get; set; }
       public virtual int Sum
        {
            get
            {
                int s = Mark1 + Mark2 + Mark3 + Mark4 + Mark5;
                return s;
            }
            set { }
        }   


    }



}