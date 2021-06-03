using M4_NETCoreMVCJQUERY.DatabaseFirst.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace M4_NETCoreMVCJQUERY.DatabaseFirst.Repository
{
    public class CustomerRepo
    {

        public static IEnumerable<Customer> GetCustomers()
        {
            using var data = new SalesContext();
            return data.Customer.ToList();
        }

        public static async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            using var data = new SalesContext();
            return await data.Customer.Include(x=>x.Order).ToListAsync();
        }

        public static IEnumerable<Customer> GetCustomersStoredProcedure()
        {
            using var data = new SalesContext();
            return data.Customer.FromSqlRaw("SP_GET_CUSTOMERS");
        }

        public static async Task<Customer> GetCustomerById(int id)
        {
            using var data = new SalesContext();
            return await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public static async Task<bool> Insert(Customer customer)
        {
            bool exito = true;

            try
            {
                using var data = new SalesContext();
                data.Customer.Add(customer);
                await data.SaveChangesAsync();
            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }


        public static async Task<bool> Update(Customer customer)
        {
            bool exito = true;

            try
            {
                using var data = new SalesContext();

                var customerNow = await data.Customer.Where(x => x.Id == customer.Id).FirstOrDefaultAsync(); //await GetCustomerById(customer.Id);

                customerNow.FirstName = customer.FirstName;
                customerNow.LastName = customer.LastName;
                customerNow.City = customer.City;
                customerNow.Country = customer.Country;
                customerNow.Phone = customer.Phone;

                await data.SaveChangesAsync();


            }
            catch (Exception)
            {
                exito = false;
            }

            return exito;
        }


        public static async Task<bool> Delete(int id)
        {
            bool exito = true;

            try
            {
                using var data = new SalesContext();

                var customerNow = await data.Customer.Where(x => x.Id == id).FirstOrDefaultAsync();//await GetCustomerById(id);
                data.Customer.Remove(customerNow);
                await data.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                exito = false;
            }
            return exito;
        }


    }
}
