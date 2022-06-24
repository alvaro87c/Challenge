using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Entidades
{
    public  class Parking : BaseEntity
    {
        public DateTime Ingreso { get; set; }    

        public DateTime Salida { get; set; }

        public decimal Tarifa { get; set; }

        public int AutoId { get; set; }

    }
}
