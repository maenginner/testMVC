// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CustomerServiceDB.cs" company="Inc">
//   Giraldo
// </copyright>
// <summary>
//   The customer service data base.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace AngularJSForm.Persistence
{
    
    using System.Linq;
    using Models;

    /// <summary>
    /// The customer service data base.
    /// </summary>
    public class CustomerServiceDB : ICustomerService
    {

        /// <summary>
        /// The data base.
        /// </summary>
        private readonly Entities db = new Entities();

        /// <summary>
        /// The create customer.
        /// </summary>
        /// <param name="customer">
        /// The customer.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CreateCustomer(Customer customer)
        {
            bool success = true;
            this.db.Customer.Add(customer);
            try
            {
                this.db.SaveChanges();
            }
            catch
            {
                // ignored
            }
            if (CustomerExists(customer.CustEmail))
            {
                success = false;
            }
            return success;
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