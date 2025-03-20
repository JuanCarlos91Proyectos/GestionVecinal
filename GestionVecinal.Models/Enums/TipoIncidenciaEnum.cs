using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.Enums
{
    public enum TipoIncidenciaEnum
    {
        [Description("Agua")]
        Agua = 1,
        [Description("Luz")]
        Luz = 2,
        [Description("Gas")]
        Gas = 3,
        [Description("Otro")]
        Otro = 4
    }
}
