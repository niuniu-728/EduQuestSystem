using Model.SysEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Paper
    {
        public int Id { get; set; }               // 试卷ID
        public string PaperName { get; set; }     // 试卷名称

        // 外键
        public int StudentId {  get; set; } 
        public SysUser Student { get; set; }    
        public int SubjectId { get; set; }        // 科目ID
        public Subject Subject { get; set; }      // 导航属性，表示与 Subject 表的关系
        public List<PaperQuestion> paperQuestions { get; set; }=new List<PaperQuestion>();
        //public List<Exam> Exams { get; set; }=new List<Exam>();
    }
}
