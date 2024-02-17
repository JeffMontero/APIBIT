using DataAccess.Data;
using DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interface
{
    public interface IServicio
    {
        /// <summary>
        /// Obtiene un servicio por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Servicio> GetServicioId(int id);

        /// <summary>
        /// Obtiene todos los servicios
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Servicio>> GetServicio();

        /// <summary>
        /// Inserta servicio
        /// </summary>
        /// <returns></returns>
        Task<Servicio> PostServicio(ServicioViewModel servicio);

        /// <summary>
        /// Modifica servicio
        /// </summary>
        /// <returns></returns>
        Task<Servicio> PutServicio(ServicioViewModel servicio);

        /// <summary>
        /// Eliminacion servicio
        /// </summary>
        /// <returns></returns>
        Task<Servicio> DeleteServicio(int id);
    }
}
