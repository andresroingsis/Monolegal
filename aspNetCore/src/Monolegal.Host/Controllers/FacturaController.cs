using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Monolegal.Host.Controllers
{
    /// <summary>
    /// Controlador de facturas
    /// </summary>
    public class FacturaController : MonolegalController
    {
        /// <summary>
        /// Obtiene lista de string
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        [HttpGet("Obtener")]
        public async Task<List<string>> ObtenerAsync(int numero)
        {
            return await Task.FromResult(new List<string> { "Hola", "Chao" });
        }
    }
}