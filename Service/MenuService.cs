using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using Model.Dtos.SysMenuDtos;
using Model.SysEntitys;
using XiaoYuJi.Service.IServices;

namespace XiaoYuJi.Service.SysServices;
public class MenuService :IMenuService
{

  

    public async Task<ApiResult<object>> GetSystemMenu(long userId)
    {
        SysUser user = await _userRepository.SingleOrDefaultAsync(x => x.Id == userId);
        ApiResult<object> apiResult = new();

        if (user == null)
        {
            apiResult.Code = -1;
            apiResult.Message = "当前登录用户信息不存在！";
            return apiResult;
        }
        //通过用户的角色id，去从角色菜单中间关系表获取拥有的菜单权限，返回菜单id集合
        List<int> menuIds = await _roleMenuRepository.Query(e => e.RoleId == user.RoleId)
            .Select(e => e.MenuId)
            .ToListAsync();

        //通过menuid集合，查询拥有的菜单实体对象列表
        List<SysMenu> haveMenuList = await base._repository
            .Query(e => menuIds.Contains(e.Id))
            .ToListAsync();

        if (haveMenuList.Any())
        {
            //递归，通过排序生成侧边栏菜单，
            List<SystemMenuDto> createMenuInfos = new();
            List<SystemMenuDto> menuInfos = await GetSysMenuInfoDtosAsync(haveMenuList,0
                , createMenuInfos);

            apiResult.Data = menuInfos;
            apiResult.Message = "获取系统侧边栏菜单成功！";

            return apiResult;
        }

        apiResult.Message = "当前用户没有系统侧边栏数据！";
        return apiResult;
    }

    /// <summary>
    /// 递归生成后台管理系统侧边栏菜单列表
    /// </summary>
    /// <param name="haveMenus">拥有的菜单数据</param>
    /// <param name="parent_id">父级id</param>
    /// <param name="menuInfoDtos">生成的菜单列表集合</param>
    /// <returns></returns>
    private async Task<List<SystemMenuDto>> GetSysMenuInfoDtosAsync(List<SysMenu> haveMenus, int parent_id
        , List<SystemMenuDto> menuInfoDtos)
    {
        //通过父级id查询菜单数据
        List<SysMenu> menus = haveMenus.Where(e => e.Parent_Id == parent_id)
            .OrderByDescending(e => e.Sort).ToList();
        if (menus.Any())
        {
            foreach (SysMenu menu in menus)
            {
                //MenuInfoDto menuInfo = _mapper.Map<MenuInfoDto>(menu);

                SystemMenuDto sldebarMenuDto = new SystemMenuDto
                {
                    Id = menu.Id,
                    Name = menu.Name,
                    UserId = menu.UserId,
                    UserName = menu.UserName,
                    UpdateTime = menu.UpdateTime,
                    Type_Key = menu.Type_Key,
                    Title = menu.Title,
                    Path = menu.Path,
                    Parent_Id = menu.Parent_Id,
                    Sort = menu.Sort,
                    Icon = menu.Icon,
                    IsDelete = menu.IsDelete,
                    Description = menu.Description,
                    ComponentName = menu.ComponentName,
                    ComponentFolderPath = menu.ComponentFolderPath,
                    Hidden = menu.Hidden,
                    CreateTime = menu.CreateTime,
                };

                //获取当前循环中菜单数据的子级菜单
                List<SysMenu> childMenus = haveMenus.Where(e => e.Parent_Id == menu.Id
                    && e.Type_Key == "1")
                    .OrderBy(e => e.Sort)
                    .ToList();

                sldebarMenuDto.Children = new List<SystemMenuDto>();    //初始化子级菜单
                //递归调用自己查询子级菜单
                if (childMenus.Any())
                {
                    await GetSysMenuInfoDtosAsync(childMenus, menu.Id
                        , sldebarMenuDto.Children);
                }
                menuInfoDtos.Add(sldebarMenuDto);
            }
        }

        return menuInfoDtos;
    }

}
