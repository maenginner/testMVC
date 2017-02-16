// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICustomerService.cs" company="Giraldo INC">
//   Giraldo
// </copyright>
// <summary>
//   The CustomerService interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularJSForm.Persistence
{
    using System.Web.Mvc;

    using AngularJSForm.Models;

    /// <summary>
    /// The CustomerService interface.
    /// </summary>
    public interface ICustomerService
    {
        /// <summary>
        /// The create customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CreateCustomer(Customer customer);
    }
}