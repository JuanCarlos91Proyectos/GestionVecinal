using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.Enums
{
    public enum TipoPagoEnum
    {
        [Description("Derrama")]
        Derrama = 1,
        [Description("Multa")]
        Multa = 2,
        [Description("Cuota")]
        Cuota = 3
    }
}
