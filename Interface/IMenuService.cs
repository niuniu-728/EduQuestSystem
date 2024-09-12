using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XiaoYuJi.Service.IServices;
public interface IMenuService
{
    /// <summary>
    /// 通过用户id获取所拥有的系统侧边栏菜单权限
    /// </summary>
    /// <param name="userId"></param>
    /// <returns></returns>
    Task<ApiResult<object>> GetSystemMenu(long userId);


}
