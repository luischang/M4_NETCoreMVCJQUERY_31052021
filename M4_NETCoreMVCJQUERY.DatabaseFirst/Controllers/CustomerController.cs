using M4_NETCoreMVCJQUERY.DatabaseFirst.Models;
using M4_NETCoreMVCJQUERY.DatabaseFirst.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M4_NETCoreMVCJQUERY.DatabaseFirst.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Listado()
        {
            var listado =await CustomerRepo.GetCustomersAsync();            
            return PartialView(listado);
        }



    }
}
