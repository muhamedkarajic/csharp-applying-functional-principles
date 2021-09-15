using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using PrimitiveObsession.Logic;

namespace PrimitiveObsession.UI.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDatabase _database;

        public CustomerController(IDatabase database)
        {
            _database = database;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateCustomer(CustomerModel customerModel)
        {
            Result<CustomerName> customerNameResult = CustomerName.Create(customerModel.Name);
            Result<Email> emailResult = Email.Create(customerModel.Email);

            if (customerNameResult.IsFailure)
                ModelState.AddModelError("Name", customerNameResult.Error);
            if (emailResult.IsFailure)
                ModelState.AddModelError("Email", emailResult.Error);

            if (!ModelState.IsValid)
                return View(customerModel);

            var customer = new Customer(customerNameResult.Value, emailResult.Value); 
            _database.Save(customer);

            return RedirectToAction("Index");
        }
    }


    public class CustomerModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
