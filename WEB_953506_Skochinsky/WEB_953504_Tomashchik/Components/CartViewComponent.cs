using System;
using Microsoft.AspNetCore.Mvc;

namespace WEB_953506_Skochinsky.Components
{
    public class CartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
        public CartViewComponent()
        {
        }
    }
}
