using System;
using System.Web.Http;
using System.Linq;

namespace jQuery_AJAX_WebAPI_CRUD_MVC.Controllers
{
    public class AjaxAPIController : ApiController
    {
        [Route("api/AjaxAPI/InsertCustomer")]
        [HttpPost]
        public Customer InsertCustomer(Customer _customer)
        {
            using (customerEntities entities = new customerEntities())
            {
                entities.Customers.Add(_customer);
                entities.SaveChanges();
            }

            return _customer;
        }

        [Route("api/AjaxAPI/UpdateCustomer")]
        [HttpPost]
        public bool UpdateCustomer(Customer _customer)
        {
            using (customerEntities entities = new customerEntities())
            {
                Customer updatedCustomer = (from c in entities.Customers
                                            where c.CustomerId == _customer.CustomerId
                                            select c).FirstOrDefault();
                updatedCustomer.Name = _customer.Name;
                updatedCustomer.Country = _customer.Country;
                entities.SaveChanges();
            }

            return true;
        }

        [Route("api/AjaxAPI/DeleteCustomer")]
        [HttpPost]
        public void DeleteCustomer(Customer _customer)
        {
            using (customerEntities entities = new customerEntities())
            {
                Customer customer = (from c in entities.Customers
                                     where c.CustomerId == _customer.CustomerId
                                     select c).FirstOrDefault();
                entities.Customers.Remove(customer);
                entities.SaveChanges();
            }
        }
    }
}
