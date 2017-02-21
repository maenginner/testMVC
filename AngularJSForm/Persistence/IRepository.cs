using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSForm.Persistence
{
    /// <summary>
    /// The Repository interface.
    /// </summary>
    /// <typeparam name="T">
    /// where T is a class
    /// </typeparam>
    public interface IRepository<T> : IDisposable where T : class
    {
        /// <summary>
        /// The execute query.
        /// </summary>
        /// <param name="spQuery">
        /// The stored procedure query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> ExecuteQuery(string spQuery, object[] parameters);

        /// <summary>
        /// The execute query single.
        /// </summary>
        /// <param name="spQuery">
        /// The stored procedure query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T ExecuteQuerySingle(string spQuery, object[] parameters);

        /// <summary>
        /// The execute command.
        /// </summary>
        /// <param name="spQuery">
        /// The stored procedure query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int ExecuteCommand(string spQuery, object[] parameters);
    }
}
