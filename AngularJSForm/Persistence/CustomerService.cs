using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSForm.Persistence
{
    using AngularJSForm.Models;

    /// <summary>
    /// The customer service.
    /// </summary>
    public class CustomerService : IService<Customer>
    {
        /// <summary>
        /// The customer repository.
        /// </summary>
        private readonly GenericRepository<Customer> custRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerService"/> class.
        /// </summary>
        public CustomerService()
        {
            this.custRepository = new GenericRepository<Customer>(new Entities());
        }

        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<Customer> GetAll(object[] parameters)
        {
            string spQuery = "[Get_Customer] {0}";
            return this.custRepository.ExecuteQuery(spQuery, parameters);
        }

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="Customer"/>.
        /// </returns>
        public Customer GetById(object[] parameters)
        {
            string spQuery = "[Get_CustomerbyID] {0}";
            return this.custRepository.ExecuteQuerySingle(spQuery, parameters);
        }

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Insert(object[] parameters)
        {
            string spQuery = "[Set_Customer] {0}, {1}";
            return this.custRepository.ExecuteCommand(spQuery, parameters);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Update(object[] parameters)
        {
            string spQuery = "[Update_Customer] {0}, {1}, {2}";
            return this.custRepository.ExecuteCommand(spQuery, parameters);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Delete(object[] parameters)
        {
            string spQuery = "[Delete_Customer] {0}";
            return this.custRepository.ExecuteCommand(spQuery, parameters);
        }
    }
}