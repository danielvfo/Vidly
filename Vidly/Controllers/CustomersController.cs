using System.Collections.Generic;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private static readonly List<Customer> Customers = new List<Customer>
        {
            new Customer {Id = 1, Name = "Marinho"},
            new Customer {Id = 2, Name = "Cacetinha"}
        };

        private static readonly CustomersListViewModel CustomersList = new CustomersListViewModel
        {
            Customers = Customers
        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(CustomersList);
        }

        [Route("Customers/Details/{id:regex(\\d{1}):range(1, 2)}")]
        public ActionResult Details(int id)
        {
            var selectedCustomer = new Customer();
            foreach (var customer in Customers)
            {
                if (customer.Id == id)
                {
                    selectedCustomer = customer;
                }
            }
            return View(selectedCustomer);
        }
    }
}