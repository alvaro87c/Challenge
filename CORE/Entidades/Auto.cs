using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Entidades
{
    public class Auto : BaseEntity
    {
        public string Marca { get; set; }
        public string Modelo { get; set; }

        public string Placa { get; set; }

        public int ClienteId { get; set; }


    }
}
