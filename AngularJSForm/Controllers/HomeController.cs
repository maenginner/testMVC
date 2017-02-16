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
        /// The Data Base Service for Customer.
        /// </summary>
        private readonly ICustomerService icb = new CustomerServiceDB();

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

            if (ModelState.IsValid && this.icb.CreateCustomer(customer))
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
            return this.icb.GetAllCustomers();
        }
    }



}