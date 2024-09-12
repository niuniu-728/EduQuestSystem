using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers;
/// <summary>
/// 日期时间帮助类
/// </summary>
public static class DateTimeHelper
{
    /// <summary>
    /// 获取当前时间
    /// </summary>
    /// <returns></returns>
    public static DateTime GetThisDateTime()
    {
        return Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
    }



}
