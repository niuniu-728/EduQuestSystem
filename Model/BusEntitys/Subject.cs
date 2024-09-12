using Model.SysEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Subject
    {
        public int Id { get; set; }               // 科目ID
        public string SubjectName { get; set; }   // 科目名称
        public List<SysUser> Users { get; set; }//针对老师
        public List<KnowledgePoints> KnowledgePoints { get; set; } = new List<KnowledgePoints>();
        public List<Paper> Papers { get; set; } = new List<Paper>();

    }
}
