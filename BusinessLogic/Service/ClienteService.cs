using ApiBit.Interface;
using DataAccess.Data;
using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BusinessLogic.Service
{
    public class ClienteService : ICliente
    {
        private readonly ApplicationDbContext ctx;
        public IConfiguration Configuration { get; }

        public ClienteService(ApplicationDbContext ctx, IConfiguration Configuration)
        {
            this.ctx = ctx;
            this.Configuration = Configuration;
        }

        /// <summary>
        /// Obtiene información de cliente por identificación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Cliente> GetClienteId(int id)
        {
            try
            {
                var list = await ctx.Clientes.Where(x => x.IdCliente.Equals(id) && x.Estado == true).FirstOrDefaultAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un listado de clientes
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Cliente>> GetCliente()
        {
            try
            {
                var list = await ctx.Clientes.Where(x => x.Estado == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Cliente> PostCliente(ClienteViewModel cliente)
        {
            try
            {
                Cliente _cliente = new Cliente();

                _cliente.NombreCliente = cliente.Nombres;
                _cliente.Correo = cliente.Correo;
                _cliente.Estado = true;

                ctx.Clientes.Add(_cliente);

                await ctx.SaveChangesAsync();
                return _cliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cliente> PutCliente(ClienteViewModel cliente)
        {
            try
            {
                var dataCliente = await ctx.Clientes.Where(x => x.IdCliente == cliente.Id).SingleOrDefaultAsync();

                dataCliente.NombreCliente = cliente.Nombres;
                dataCliente.Correo = cliente.Correo;

                await ctx.SaveChangesAsync();
                return dataCliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task<Cliente> DeleteCliente(int id)
        {
            try
            {
                var dataCliente = await ctx.Clientes.Where(x => x.IdCliente == id).SingleOrDefaultAsync();

                dataCliente.Estado = false;

                await ctx.SaveChangesAsync();
                return dataCliente;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new Exception("ErrorConcurrencia");
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("ErrorIngresoDatos");
            }
            catch (SqlException ex)
            {
                throw new Exception("ErrorConexionBaseDatos");
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
