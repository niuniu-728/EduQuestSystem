using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.SysEntitys;
/// <summary>
/// 角色菜单关系对应表
/// </summary>
[Table("Sys_RoleMenu")]
public class SysRoleMenu:BaseEntity<int>
{
    /// <summary>
    /// 角色id
    /// </summary>
    [ForeignKey("SysRole")]
    public int RoleId { get; set; }
    public virtual SysRole SysRole { get; set; }

    /// <summary>
    /// 菜单id
    /// </summary>
    [ForeignKey("SysMenu")]
    public int MenuId { get; set; }
    public virtual SysMenu SysMenu { get;}

}
