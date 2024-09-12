using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.SysEntitys;
/// <summary>
/// 菜单表
/// </summary>
[Table("Sys_Menu")]
public class SysMenu:BaseEntity<int>
{
    /// <summary>
    /// 菜单标题
    /// </summary>
    [Required, StringLength(50)]
    public string Title { get; set; } = null!;

    /// <summary>
    /// 菜单名称
    /// </summary>
    [StringLength(50)]
    public string Name { get; set; } = null!;

    /// <summary>
    /// 图标
    /// </summary>
    [StringLength(50)]
    public string? Icon { get; set; }

    /// <summary>
    /// 路由访问路径
    /// </summary>
    [Required,StringLength(100)]
    public string Path { get; set; } = null!;

    /// <summary>
    /// 组件名称
    /// </summary>
    [StringLength(50)]
    public string? ComponentName { get; set; }

    /// <summary>
    /// 组件所在的文件夹路径
    /// </summary>
    [StringLength(50)]
    public string? ComponentFolderPath { get; set; }

    /// <summary>
    /// 父级菜单
    /// </summary>
    public int Parent_Id { get; set; }
    /// <summary>
    /// 是否隐藏
    /// </summary>
    public bool Hidden { get; set; }

    /// <summary>
    /// 菜单描述
    /// </summary>
    [StringLength(50)]
    public string? Description { get; set; }


    /// <summary>
    /// 菜单标识，0=目录，1=菜单，2=按钮
    /// </summary>
    public string? Type_Key { get; set; }

}
