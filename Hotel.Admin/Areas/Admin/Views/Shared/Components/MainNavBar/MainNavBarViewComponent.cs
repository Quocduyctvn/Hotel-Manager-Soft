﻿using Microsoft.AspNetCore.Mvc;

namespace Hotel.Admin.Areas.Admin.Views.Shared.Components.MainNavBar
{
	public class MainNavBarViewComponent : ViewComponent
	{
		public MainNavBarViewComponent()
		{
		}
		public async Task<IViewComponentResult> InvokeAsync()
		{
			var navBar = new NavBarViewModel();
			navBar.Items.AddRange(new MenuItem[]
			{
				new MenuItem
				{
					Action = "Index",
					Controller = "AdminRentalPackage",
					DisplayText = "Quản lý gói cho thuê",
					Icon = "fas fa-stream",
					Permission = 0
				},
                new MenuItem
                {
                    Action = "Index",
                    Controller = "AdminArticleCate",
                    DisplayText = "Quản lý danh mục tin tức",
                    Icon = "fas fa-bed",
                    Permission = 0
                },
                 new MenuItem
                {
                    Action = "Index",
                    Controller = "AdminArticle",
                    DisplayText = "Quản lý tin tức",
                    Icon = "fas fa-newspaper",
                    Permission = 0
                },
                 new MenuItem
                {
                    Action = "Index",
                    Controller = "AdminContact",
                    DisplayText = "Quản lý liên hệ",
                    Icon = "fas fa-address-book",
                    Permission = 0
                },
				//new MenuItem
				//{
				//	Action = "Index",
				//	Controller = "AdminAmenity",
				//	DisplayText = "Quản lý tiện nghi",
				//	Icon = "fa-network-wired",
				//	Permission = AuthConst.AdminAmenity_Auth.VIEW_LIST,
				//},
			});
			return View(navBar);
		}
	}
}
