using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CORE.Entidades
{
    public class Cliente : BaseEntity
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Cedula { get; set; }
        
    }
}
