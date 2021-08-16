using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSNET_WEB_CORE.Models
{
    public class PaymentViewModel
    {
        public decimal? TransactionAmount { get; set; }
        public string Description { get; set; }
        public int? Installments { get; set; }
        public string PaymentMethodId { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public string Tipo_Doc { get; set; }
        public string Nro_Doc { get; set; }
        public string Banco_Emisor { get; set; }
    }
}
