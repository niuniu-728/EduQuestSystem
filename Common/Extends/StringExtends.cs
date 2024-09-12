using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Extens;
public static class StringExtends
{
    /// <summary>
    /// 判断字符串是否为null或空
    /// </summary>
    /// <param name="str">要判断的字符串</param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this string str)
    {
        if (string.IsNullOrEmpty(str))
            return true;
        else
            return false;
    }


}
