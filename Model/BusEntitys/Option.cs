using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Option
    {
        public int Id {  get; set; }
        public string OptionName {  get; set; }
        public bool TrueOrFalse {  get; set; }
        public int QuestionId {  get; set; }    
        public PaperQuestion PaperQuestion { get; set; }
       
    }
}
