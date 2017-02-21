using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularJSForm.Persistence
{
    

    /// <summary>
    /// The Service interface.
    /// </summary>
    /// <typeparam name="T">
    /// class type
    /// </typeparam>
    public interface IService<T> where T : class
    {
        /// <summary>
        /// The get all.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        IEnumerable<T> GetAll(object[] parameters);

        /// <summary>
        /// The get by id.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        T GetById (object[] parameters);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Insert(object[] parameters);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Update(object[] parameters);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        int Delete(object[] parameters);
    }
}
