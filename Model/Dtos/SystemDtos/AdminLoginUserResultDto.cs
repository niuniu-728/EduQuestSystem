using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoYuJi.Entity.Dtos.SystemDtos;
public class AdminLoginUserResultDto
{
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

    /// <summary>
    /// QQ
    /// </summary>
    [StringLength(10)]
    public string? QQ { get; set; }

    /// <summary>
    /// 微信号
    /// </summary>
    [StringLength(20)]
    public string? WeChatNumber { get; set; }

}
