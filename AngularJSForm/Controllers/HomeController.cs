// --------------------------------------------------------------------------------------------------------------------
// <copyright file="HomeController.cs" company="Mauricio">
//   All rights reserved
// </copyright>
// <summary>
//   The home controller.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularJSForm.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using AngularJSForm.Models;
    using AngularJSForm.Persistence;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The service.
        /// </summary>
        private readonly IService<Customer> service;

        /// <summary>
        /// Initializes a new instance of the <see cref="HomeController"/> class.
        /// </summary>
        public HomeController()
        {
            this.service = new CustomerService();
        }

        /// <summary>
        /// GET: Home
        /// The user registration.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult UserRegistration()
        {
            return View();
        }


        /// <summary>
        /// POST: Home/CreateCustomer
        /// The create customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult CreateCustomer(Customer customer)
        {
            JsonResult res = Json(new {success = false});
            object[] parameters = { customer.CustName, customer.CustEmail };
            if (ModelState.IsValid && this.service.Insert(parameters) == 1)
            {
                res = Json(new { success = true, redirectUrl = "/Home/Welcome" });
            }
            return res;
        }

        /// <summary>
        /// The welcome.
        /// </summary>
        /// <returns>
        /// The <see cref="ActionResult"/>.
        /// </returns>
        public ActionResult Welcome()
        {
            return View();
        }

        /// <summary>
        /// GET: Home/GetAllCustomers
        /// The get all customers.
        /// </summary>
        /// <returns>
        /// The <see cref="JsonResult"/>.
        /// </returns>
        public JsonResult GetAllCustomers()
        {
            int Count = 20;
            IEnumerable<object> customers = null;
            try
            {
                object[] parameters = { Count };
                customers = this.service.GetAll(parameters);
            }
            catch { }
            return Json(customers.ToList(), JsonRequestBehavior.AllowGet);
        }
    }



}