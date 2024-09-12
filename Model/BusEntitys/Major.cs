using Model.SysEntitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Major
    {
        public int Id { get; set; }               // 专业ID
        public string MajorName { get; set; }     // 专业名称
        public List<SysUser> sysUsers { get; set; }=new List<SysUser>();
    }
}
