using Monolegal.Host.Models.Facturas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolegal.Host.Models.Clientes
{
    public class RegistrarCliente
    {
        public string Id { get; set; }
        
        public long NumeroDeCedula { get; set; }
        
        public string NombreCompleto { get; set; }

        public bool Activo { get; set; }

        public ICollection<RegistrarFactura> Facturas { get; set; }
    }
}
