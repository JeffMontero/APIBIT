using BusinessLogic.Interface;
using DataAccess.Data;
using DataAccess.Model;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Service
{
    public class ServicioService : IServicio
    {
        private readonly ApplicationDbContext ctx;
        public IConfiguration Configuration { get; }

        public ServicioService(ApplicationDbContext ctx, IConfiguration Configuration)
        {
            this.ctx = ctx;
            this.Configuration = Configuration;
        }

        /// <summary>
        /// Obtiene información de servicio por identificación
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Servicio> GetServicioId(int id)
        {
            try
            {
                var list = await ctx.Servicios.Where(x => x.IdServicio.Equals(id) && x.Estado == true).FirstOrDefaultAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// Obtiene un listado de servicios
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Servicio>> GetServicio()
        {
            try
            {
                var list = await ctx.Servicios.Where(x => x.Estado == true).ToListAsync();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Servicio> PostServicio(ServicioViewModel servicio)
        {
            try
            {
                Servicio _servicio = new Servicio();

                _servicio.NombreServicio = servicio.Servicio;
                _servicio.Descripcion = servicio.Descripcion;
                _servicio.Estado = true;

                ctx.Servicios.Add(_servicio);

                await ctx.SaveChangesAsync();
                return _servicio;
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

        public async Task<Servicio> PutServicio(ServicioViewModel servicio)
        {
            try
            {
                var dataServicio = await ctx.Servicios.Where(x => x.IdServicio == servicio.Id).SingleOrDefaultAsync();

                dataServicio.NombreServicio = servicio.Servicio;
                dataServicio.Descripcion = servicio.Descripcion;
           
                await ctx.SaveChangesAsync();
                return dataServicio;
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

        public async Task<Servicio> DeleteServicio(int id)
        {
            try
            {
                var dataServicio = await ctx.Servicios.Where(x => x.IdServicio == id).SingleOrDefaultAsync();

                dataServicio.Estado = false;

                await ctx.SaveChangesAsync();
                return dataServicio;
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
