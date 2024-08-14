using System.Linq;
using System.Web.Mvc;
using NorthwindMVC.Models; 

namespace YourProjectName.Controllers
{
    public class CodeController : Controller
    {
        private northwindDBEntities db = new northwindDBEntities(); 

        // CustomersInGermany
        public ActionResult CustomersInGermany()
        {
            var customers = db.Customers.Where(c => c.Country == "Germany").ToList();
            return View(customers);
        }

        // CustomerDetails
        public ActionResult CustomerDetails(int orderId)
        {
            var customer = db.Orders
                .Where(o => o.OrderID == orderId)
                .Select(o => o.Customer)
                .FirstOrDefault();
            if (customer == null)
            {
                return HttpNotFound();
            }

            return View(customer);
        }
    }
}

