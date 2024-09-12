using Model.BusEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Exam
    {
        public int Id { get; set; }               // 考试ID
        public string ExamName { get; set; }      // 考试名称
        public DateTime ExamTime { get; set; }    // 考试时间
        // 外键
        public Term Term { get; set; }
        public int PaperId { get; set; }          // 试卷ID
        public Paper Paper { get; set; }          // 导航属性，表示与 Paper 表的关系
        public List<ExamRecord> ExamRecords { get; set; }=new List<ExamRecord>();
    }
}
