using Microsoft.AspNetCore.Mvc;
using System;

namespace MarketWB.Web.Views.Components
{
    public class OrderFormComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
