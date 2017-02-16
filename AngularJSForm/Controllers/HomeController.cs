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
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;

    using Models;

    /// <summary>
    /// The home controller.
    /// </summary>
    public class HomeController : Controller
    {
        /// <summary>
        /// The data base.
        /// </summary>
        private readonly Entities db = new Entities();

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
            if (ModelState.IsValid)
            {
                this.db.Customer.Add(customer);
                try
                {
                    this.db.SaveChanges();
                }
                catch (Exception e)
                {
                    if (CustomerExists(customer.CustEmail))
                    {
                        return
                            Json(
                                new
                                    {
                                        success = false,
                                        errors =
                                        ModelState.Keys.SelectMany(i => ModelState[i].Errors)
                                            .Select(m => m.ErrorMessage)
                                            .ToArray()
                                    });
                    }
                }
                var RedirectUrl = Url.Action("Welcome", "Home", new
                {
                    area = ""
                });
                return Json(new
                {
                    success = true,
                    redirectUrl=RedirectUrl
                });
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
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
        /// The customer exists.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool CustomerExists(string id)
        {
            return this.db.Customer.Count(e => e.CustEmail == id) > 0;
        }
    }



}