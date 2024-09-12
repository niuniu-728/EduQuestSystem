using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class KnowledgePoints
    {
        public int Id {  get; set; }
        public string Title {  get; set; }
        public string Description { get; set; } 
        public Subject Subject { get; set; }
        public List<PaperQuestion> PaperQuestions { get; set; } = new List<PaperQuestion>();
    }
}
