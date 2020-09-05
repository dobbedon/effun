using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using effun.Models;
using System.IO;
using effun.Data;

namespace effun.Controllers
{
    public class HomeController : Controller
    {
        private peopleContext _context;

        public HomeController(peopleContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var test = _context.People.Any();
            if (test != true)
            {
                List<person> people = new List<person>();
                string Line;
                StreamReader kartotek = new StreamReader(@"c:\test.csv");
                while ((Line = kartotek.ReadLine()) != null)
                {
                    var ting = Line.Split(new[] { ',' });
                    people.Add(new person
                    {
                        firstName = ting[1],
                        lastName = ting[2],
                        Email = ting[3],
                        Gender = ting[4],
                        ip_adress = ting[5]
                    });
                }

                foreach (var item in people)
                {
                    _context.Add(item);
                }
                _context.SaveChanges();
            }

           


            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
