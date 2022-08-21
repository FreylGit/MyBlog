using Microsoft.AspNetCore.Mvc;
using MyBlog.Models.ViewModels;

namespace MyBlog.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedLink = RouteData.Values["NavItem"];
            var listItem = new List<NavigationLinkViewModel>();
            listItem.Add(new NavigationLinkViewModel { Title="Создать блог",Action="Create",Controller="Blog"});
            return View(listItem);
        }
    }
}
