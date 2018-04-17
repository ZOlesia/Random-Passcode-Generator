using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

 
namespace random_passcode.Controllers
{

    public class PasscodeController : Controller
    {
        string [] character = new string [] {"0","1","2","3","4","5","6","7","8","9","A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","X","Y","Z"};
        string passcode;
        
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            int count = HttpContext.Session.GetInt32("countNum")?? 1;
            HttpContext.Session.SetInt32("countNum", count);
            // int? y = HttpContext.Session.GetInt32("countNum");
            ViewBag.FinalCount = count;

            
            Random rand = new Random();
            for(var i = 0; i < 14; i++)
            {
                int j = rand.Next(0, 35);
                passcode += character[j];
            }

            ViewBag.Passcode = passcode;
            return View("index");
        }


        [HttpPost]
        [Route("proccess")]
        public IActionResult Proccess()
        {
            int qqq = (int)HttpContext.Session.GetInt32("countNum");
            qqq++;
            HttpContext.Session.SetInt32("countNum", qqq);
            return RedirectToAction("Index");
        }
    }
}
