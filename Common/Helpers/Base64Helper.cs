using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers;
public static class Base64Helper
{
    /// <summary>
    /// 判断字符串是否是base64码
    /// </summary>
    /// <param name="value">需要验证的字符串值</param>
    /// <returns></returns>
    public static bool IsBase64(string value)
    {
        return value.IndexOf("base64") > 0;
    }

}
