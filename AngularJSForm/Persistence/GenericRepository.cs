using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSForm.Persistence
{

    using AngularJSForm.Models;

    /// <summary>
    /// The generic Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// where T: class
    /// </typeparam>
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        /// <summary>
        /// The context.
        /// </summary>
        private Entities context = null;

        /// <summary>
        /// The disposed.
        /// </summary>
        private bool disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericRepository{T}"/> class.
        /// </summary>
        /// <param name="context">
        /// The context.
        /// </param>
        public GenericRepository(Entities context)
        {
            this.context = context;
            this.disposed = false;
        }

        /// <summary>
        /// The execute query.
        /// </summary>
        /// <param name="spQuery">
        /// The sp query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters)
        {
            using (this.context = new Entities())
            {
                return this.context.Database.SqlQuery<T>(spQuery, parameters).ToList();
            }
        }

        /// <summary>
        /// The execute query single.
        /// </summary>
        /// <param name="spQuery">
        /// The sp query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public T ExecuteQuerySingle(string spQuery, object[] parameters)
        {
            using (this.context = new Entities())
            {
                return this.context.Database.SqlQuery<T>(spQuery, parameters).FirstOrDefault();
            }
        }

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="spQuery">
        /// The sp query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int ExecuteCommand(string spQuery, object[] parameters)
        {
            int result = 0;
            try
            {
                using (this.context = new Entities())
                {
                    result = this.context.Database.SqlQuery<int>(spQuery, parameters).FirstOrDefault();
                }
            }
            catch { }
            return result;
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="v">
        /// The v.
        /// </param>
        private void Dispose(bool v)
        {
            if (!this.disposed && v)
            {
                this.context.Dispose();
            }
            this.disposed = true;
        }
    }
}