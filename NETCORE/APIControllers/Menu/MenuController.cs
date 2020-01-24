
using CORE.BL.Dto;
using CORE.BL.Dto.Menu;
using CORE.BL.GenericClasses;
using CORE.BL.Services;
using CORE.BL.Services.Menu;
using log4net;
using Target_NETCORE.ActionFilters;
using Target_NETCORE.Models.ViewModels.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
namespace Target_NETCORE.APIControllers.Menu
{

    public class MenuController : APIBaseController
    {
        private readonly IService_Menu _service_Menu;

        public MenuController(IService_Menu service_Menu, ILog log)
        {
            _log = log;
            _service_Menu = service_Menu;
            base._baseservice = _service_Menu;
        }
        [JWTAuthentication_HS256]
        public IActionResult GetMenuItems()
        {
            GenericResponse res = new GenericResponse();
            res.FillSuccess();
            var MenuItems = _service_Menu.GetMenuItems();
            FilterPrivilligedMenu(MenuItems);
            GetOnlyParentsMenu(MenuItems);

            //var MenuView = Mapper.Map<List<MenuItemViewModel>>(MenuItems); 
            foreach (var item in MenuItems)
            {
                RemoveEmptyChildObject(item);
            }
            res.data = MenuItems;

            return Ok(res);
        }

        public void RemoveEmptyChildObject(dto_Menu model)
        {
            if (model != null && model.children != null)
            {
                if (model.children.Count == 0)
                {
                    model.children = null;
                }
                else
                {
                    foreach (var item in model.children)
                    {
                        RemoveEmptyChildObject(item);
                    }
                }
            }

        }
        public void FilterPrivilligedMenu(List<dto_Menu> Menu)
        {

            //List<dto_Menu> src = _service_Menu.GetPrivateMenuItems();
            #region Handle_Menu_Privilliges
            if (Menu != null && Menu.Count > 0)
            {
                for (int i = Menu.Count() - 1; i >= 0; i--)
                {
                    if (Menu[i].Privillige != null && !this.CurrenUserPrivilliges.Select(c => c.Key).Contains(Menu[i].Privillige.Key))
                    {
                        Menu.Remove(Menu[i]);
                    }
                    else
                    {
                        FilterPrivilligedMenu(Menu[i].children);
                    }

                }

            }
            #endregion

        }
        public void GetOnlyParentsMenu(List<dto_Menu> Menu)
        {

            //List<dto_Menu> src = _service_Menu.GetPrivateMenuItems();
            #region GetOnlyParentsMenu
            if (Menu != null && Menu.Count > 0)
            {
                Menu.RemoveAll(c =>c.ParentID.HasValue);

            }
            #endregion
        }





    }
}