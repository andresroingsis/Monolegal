using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monolegal.Host.Models.Facturas
{
    /// <summary>
    /// Representa una factura en el sistema
    /// </summary>
    public class RegistrarFactura
    {
        public string Id { get; set; }

        public string Codigo { get; set; }

        public decimal ValorTotal { get; set; }

        public decimal ValorSubTotal { get; set; }

        public decimal ValorIva { get; set; }

        public decimal ValorRetencion { get; set; }

        public DateTime FechaDeRegistro { get; set; }

        public string Estado { get; set; }

        public bool FacturaPagada { get; set; }

        public DateTime? FechaDePago { get; set; }
    }
}
