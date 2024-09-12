using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class PaperQuestion
    {
        public int Id { get; set; }               // 主键ID

        // 外键
        public int PaperId { get; set; }          // 试卷ID
        public Paper Paper { get; set; }          // 导航属性，表示与 Paper 表的关系
        public List<Option> Options { get; set; } // 导航属性，表示与 MultipleChoiceQuestion 表的关系
        public List<KnowledgePoints> KnowledgePoints { get; set; } = new List<KnowledgePoints>();
        public List<Paper> Papers { get; set; }
        public QuestionType QuestionType { get; set; } = new QuestionType();

    }
}
