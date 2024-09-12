using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class QuestionType
    {
        public int Id { get; set; }               // 题型ID
        public string QuestionTypeName { get; set; } // 题型名称
        public List<PaperQuestion> PaperQuestions { get; set; } = new List<PaperQuestion>();
    }
}
