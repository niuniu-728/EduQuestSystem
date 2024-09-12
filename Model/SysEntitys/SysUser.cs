using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SysEntitys;

/// <summary>
/// 用户表
/// </summary>
[Table("Sys_User")]
public class SysUser : BaseEntity<long>
{
    /// <summary>
    /// 角色id
    /// </summary>
    [ForeignKey(nameof(SysRole))]   //"SysRole"
    public int RoleId { get; set; }
    public virtual SysRole? SysRole { get; set; }

    /// <summary>
    /// 用户密码
    /// </summary>
    [Required, StringLength(30)]
    public string UserPwd { get; set; } = null!;
    /// <summary>
    /// 用户名称
    /// </summary>
    [Required, StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 用户头像
    /// </summary>
    [StringLength(200)]
    public string? Avatar { get; set; }

    /// <summary>
    /// 性别
    /// </summary>
    public int Sex { get; set; }

    /// <summary>
    /// 邮箱号
    /// </summary>
    [StringLength(20)]
    public string? Email { get; set; }
    public int MajorId {  get; set; }   
    public Major Major { get; set; }
    public List<Paper> Papers { get; set; }= new List<Paper>();
    public List<Subject> Subjects { get; set; }= new List<Subject>();//针对老师
}
