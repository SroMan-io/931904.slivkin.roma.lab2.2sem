using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;


namespace WebApplication1.Controllers
{
    public class CalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Manual()
        {
            var calc1 = new CalcServices();
            ViewData["Title"] = "Manual";

            if (Request.Method == "POST")
            {
                _ = int.TryParse(HttpContext.Request.Form["x"], out int x);
                _ = int.TryParse(HttpContext.Request.Form["y"], out int y);
                _ = char.TryParse(HttpContext.Request.Form["sign"], out char sign);
                calc1.res=calc1.Calculate(x, y, sign);
                calc1.x = x;
                calc1.y = y;
                calc1.sign = sign;

                ViewData["Title"] = "Result";
            }
            return View("Main", calc1);
        }

        [HttpGet]
        public IActionResult ManualWithSeparateHandlers()
        {
            ViewData["Title"] = "ManualWithSeparateHandlers";
            return View("Main");
        }

        [HttpPost]
        public IActionResult ManualWithSeparateHandlers(int? __)
        {
            var calc1 = new CalcServices();
            _ = int.TryParse(HttpContext.Request.Form["x"], out int x);
            _ = int.TryParse(HttpContext.Request.Form["y"], out int y);
            _ = char.TryParse(HttpContext.Request.Form["sign"], out char sign);
            calc1.res = calc1.Calculate(x, y, sign);
            calc1.x = x;
            calc1.y = y;
            calc1.sign = sign;

            ViewData["Title"] = "Result";
            return View("Main",calc1);
        }

        [HttpGet]
        public IActionResult ModelBindingInParameters()
        {
            ViewData["Title"] = "ModelBindingInParameters";
            return View("Main");
        }

        [HttpPost]
        public IActionResult ModelBindingInParameters(int x, int y, char sign)
        {
            var calc1 = new CalcServices();
            calc1.res = calc1.Calculate(x, y, sign);
            ViewData["Title"] = "Result2";

            return View("Main",calc1);
        }

        [HttpGet]
        public IActionResult ModelBindingInSeparateModel()
        {
            ViewData["Title"] = "ModelBindingInSeparateModel";
            return View("Main");
        }

        [HttpPost]
        public IActionResult ModelBindingInSeparateModel(CalcServices calc1)
        {         
            calc1.res = calc1.Calculate(calc1);
            ViewData["Title"] = "Result2";
            return View("Main", calc1);
        }     
    }
}