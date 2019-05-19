using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Monolegal.AplicacionCore.Entidades.Persistencia
{
    /// <summary>
    /// Representa una factura realizada a un cliente
    /// </summary>
    public class Factura
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement()]
        public string Codigo { get; set; }

        [BsonElement()]
        public decimal ValorTotal { get; set; }

        [BsonElement()]
        public decimal ValorSubTotal { get; set; }

        [BsonElement()]
        public decimal ValorIva { get; set; }

        [BsonElement()]
        public decimal ValorRetencion { get; set; }

        [BsonElement()]
        public DateTime FechaDeRegistro { get; set; }

        [BsonElement()]
        public string Estado { get; set; }

        [BsonElement()]
        public bool FacturaPagada { get; set; }

        [BsonElement()]
        public DateTime? FechaDePago { get; set; }
    }
}
