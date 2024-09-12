using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model;
/// <summary>
/// 分页通用返回类
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class PageData<TEntity>
{
    public List<TEntity> List { get; set; }
    public int Total { get; set; }
    public int PageIndex { get; set; }

    public int PageSize { get; set; }


}
