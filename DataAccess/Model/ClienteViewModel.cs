using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Model
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string? Nombres{ get; set; }
        public string? Correo { get; set; }
    }
}
