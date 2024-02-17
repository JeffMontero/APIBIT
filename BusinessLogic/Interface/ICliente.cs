using DataAccess.Data;
using DataAccess.Model;

namespace ApiBit.Interface
{
    public interface ICliente
    {
        /// <summary>
        /// Obtiene un cliente por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Cliente> GetClienteId(int id);

        /// <summary>
        /// Obtiene todos los clientes
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Cliente>> GetCliente();

        /// <summary>
        /// Inserta cliente
        /// </summary>
        /// <returns></returns>
        Task<Cliente> PostCliente(ClienteViewModel cliente);

        /// <summary>
        /// Modifica Cliente
        /// </summary>
        /// <returns></returns>
        Task<Cliente> PutCliente(ClienteViewModel cliente);

        /// <summary>
        /// Eliminacion cliente
        /// </summary>
        /// <returns></returns>
        Task<Cliente> DeleteCliente(int id);
    }
}
