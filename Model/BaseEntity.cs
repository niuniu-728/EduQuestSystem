﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
public class BaseEntity<Tkey>
{
    /// <summary>
    /// 主键
    /// </summary>
    public Tkey? Id { get; set; }

    /// <summary>
    /// 排序
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// 数据创建时间
    /// </summary>
    public DateTime CreateTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 数据修改时间
    /// </summary>
    public DateTime UpdateTime { get; set; } = DateTime.Now;

    /// <summary>
    /// 创建人id
    /// </summary>
    public long? UserId { get; set; }

    /// <summary>
    /// 创建人名称
    /// </summary>
    public string? UserName { get; set; }

    /// <summary>
    /// 是否伪删除
    /// </summary>
    public bool IsDelete { get; set; }
}
