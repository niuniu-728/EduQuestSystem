using Model.SysEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BusEntitys
{
    public class ExamRecord
    {
        // 属性
        public int Id { get; set; }
        public int  ExamId { get; set; }
        public Exam Exam { get; set; }
        public DateTime ExamDate { get; set; } = DateTime.Now;
        public int Status {  get; set; }
        public int StudentId {  get; set; }
        public SysUser User { get; set; }
    }
}
