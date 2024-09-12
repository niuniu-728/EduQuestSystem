using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Term
    {
        public int Id {  get; set; }    
        public string TermName {  get; set; }   
        public List<Exam> exams { get; set; }=new List<Exam>();
    }
}
