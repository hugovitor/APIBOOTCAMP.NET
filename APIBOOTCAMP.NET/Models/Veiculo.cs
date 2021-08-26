using System;
using System.Collections.Generic;

#nullable disable

namespace APIBOOTCAMP.NET.Models
{
    public partial class Veiculo
    {
        public int VeiculoId { get; set; }
        public string Placa { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Ano { get; set; }
        public string Cor { get; set; }
        public string Combustivel { get; set; }
    }
}
