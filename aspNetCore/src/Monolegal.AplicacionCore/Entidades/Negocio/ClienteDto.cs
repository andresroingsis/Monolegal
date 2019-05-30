using System;
using System.Collections.Generic;

namespace Monolegal.AplicacionCore.Entidades.Negocio
{
    /// <summary>
    /// Representa un cliente en la capa de dominio
    /// </summary>
    public class ClienteDto
    {
        public string Id { get; set; }

        public long NumeroDeCedula { get; set; }

        public string NombreCompleto { get; set; }

        public bool Activo { get; set; }
        
        public ICollection<FacturaDto> Facturas { get; set; }
    }
}
