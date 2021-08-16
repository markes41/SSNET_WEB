using MercadoPago.Client.Common;
using MercadoPago.Client.Payment;
using MercadoPago.Client.PaymentMethod;
using MercadoPago.Resource;
using MercadoPago.Resource.Payment;
using MercadoPago.Resource.PaymentMethod;
using Microsoft.AspNetCore.Mvc;
using SSNET_WEB_CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SSNET_WEB_CORE.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Pagar()
        {
            return View();
        }

        [HttpPost]
        public JsonResult ProcesarPago(PaymentViewModel payment_receive)
        {
            var Banco_Id = new PaymentMethodClient().List().Where(m => m.Name == payment_receive.Banco_Emisor).Select(m => m.Id).FirstOrDefault();
            var test = new PaymentMethodClient().List();
            var paymentRequest = new PaymentCreateRequest
            {
                TransactionAmount = payment_receive.TransactionAmount,
                Token = payment_receive.Token,
                Description = payment_receive.Description,
                Installments = payment_receive.Installments,
                PaymentMethodId = Banco_Id,
                Payer = new PaymentPayerRequest
                {
                    Email = payment_receive.Email,
                    Identification = new IdentificationRequest
                    {
                        Type = payment_receive.Tipo_Doc,
                        Number = payment_receive.Nro_Doc,
                    },
                },
            };
            var Payment = new PaymentClient().Create(paymentRequest);
            return Json(Payment);
        }
    }
}
