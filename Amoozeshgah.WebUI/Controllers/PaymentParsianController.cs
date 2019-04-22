using Amoozeshgah.WebReferences;
using Amoozeshgah.WebReferences.Parsian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Web;
using System.Web.Mvc;

namespace Amoozeshgah.WebUI.Controllers
{
    public  class Pay
    {
        public int Id { get; set; }
        public int Amount { get; set; }
    }
    public class PaymentParsianController : Controller
    {
        [HttpGet]
        public ActionResult Test()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Test(Pay pay)
        {
            if (false == ModelState.IsValid)
                return View();

            long token = 0;
            short paymentStatus = short.MinValue;
            ClientSaleResponseData responseData = null;
            using (var service = new SaleService())
            {
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback((o, xc, xch, sslP) => true);
                service.Url = ConfigHelper.ParsianPGWSaleServiceUrl;
                var saleRequest = new ClientSaleRequestData();

                saleRequest.LoginAccount = ConfigHelper.LoginAccount;

                //make sure you set the CallBackUrl property. because after user has completed Payment on IPG page, it will be redirected to the callback url you provided
                //to get you back result of the user Payment on IPG.
                saleRequest.CallBackUrl = ConfigHelper.SalePaymentCallback;

                //Amount is not used. you should not assign a value to this property.
                saleRequest.Amount = pay.Amount;
                //saleRequest.AdditionalData = model.AdditionalData;

                //Order Id MUST be UNIQUE at all times. if a duplicated Order Id is received from your request, you will get Status=-112
                var a = new Random(DateTime.Now.Ticks.GetHashCode());
                saleRequest.OrderId = a.Next(1000000, 999999999);

                saleRequest.AdditionalData = "111101789012345678901";



                responseData = service.SalePaymentRequest(saleRequest);
                paymentStatus = responseData.Status;

                //check Status property of the response object to see if the operation was successful.
                if (responseData.Status == Constants.ParsianPaymentGateway.Successful)
                {
                    //if everything is OK (LoginAccount and your IP address is valid in the Parsian PGW), save the token in a data store
                    // to use it for redirectgion of your web site's user to the Parsian IPG (Internet Payment Gateway) page to complete payment.
                    token = responseData.Token;

                    //you must save the token in a data store for further support and resolving 
                    Session["Token"] = token;
                }
                else
                {
                    //logger.Error($"Parsian PGW service call status code : {responseData.Status}");
                }
            }

            if (paymentStatus == Constants.ParsianPaymentGateway.Successful && token > 0L)
            {
                //first, save token to your database to be able to track payment process with your business.
                //after successfully retrieved a token from Parsian PGW, redirect user to Parsian IPG to complete the payment operation.
                var redirectUrl = string.Format(ConfigHelper.ParsianIPGPageUrl, token);
                //return Json(new { status = 0, location = redirectUrl });
                return Redirect(redirectUrl);
            }
            else
            {
                ViewBag.Error = "Error conecting to pay service";
                //var mdl = new PaymentRequestResponseModel()
                //{
                //    Message = responseData?.Message,
                //    Status = responseData?.Status,
                //    Token = responseData?.Token
                //};
                return View();
            }
        }
        public ActionResult PaymentCallback() {
            return View();

        }
    }
}