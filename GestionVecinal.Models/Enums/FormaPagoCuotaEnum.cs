using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionVecinal.Models.Enums
{
    public enum FormaPagoCuotaEnum
    {
        [Description("Efectivo")]
        Efectivo = 1,
        [Description("Transferencia")]
        Transferencia = 2,
        [Description("Domiciliación")]
        Domiciliacion = 3,
        [Description("Cheque")]
        Cheque = 4,
        [Description("Otro")]
        Otro = 5
    }
}
