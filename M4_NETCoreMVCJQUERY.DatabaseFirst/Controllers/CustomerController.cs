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
            var listado = await CustomerRepo.GetCustomersAsync();
            return PartialView(listado);
        }

        [HttpPost]
        public async Task<IActionResult> Grabar(int idCliente,
                                                string nombres,
                                                string apellidos,
                                                string pais,
                                                string ciudad,
                                                string telefono)
        {
            var customer = new Customer()
            {
                FirstName = nombres,
                LastName = apellidos,
                Country = pais,
                City = ciudad,
                Phone = telefono
            };

            bool exito = true;

            if (idCliente == -1)
                exito = await CustomerRepo.Insert(customer);
            else
            {
                customer.Id = idCliente;
                exito = await CustomerRepo.Update(customer);
            }

            return Json(exito);
        }


    }
}
