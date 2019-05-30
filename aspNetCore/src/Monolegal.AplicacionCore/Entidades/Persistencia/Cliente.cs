using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace Monolegal.AplicacionCore.Entidades.Persistencia
{
    /// <summary>
    /// Representa un cliente en el sistema
    /// </summary>
    public class Cliente
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement()]
        public long NumeroDeCedula { get; set; }

        [BsonElement()]
        public string NombreCompleto { get; set; }

        [BsonElement()]
        public bool Activo { get; set; }

        [BsonElement()]
        public ICollection<Factura> Facturas { get; set; }
    }
}
