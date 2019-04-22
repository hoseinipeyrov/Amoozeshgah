using Amoozeshgah.WebReferences.Parsian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Amoozeshgah.WebReferences.Constants;

namespace Amoozeshgah.Services.PaymentParsian
{
    public class PaymentParsianService  
    {
        SaleService _saleService;
        ClientSaleRequestData _request;
        ClientSaleResponseData _response;


        public PaymentParsianService(SaleService saleService, ClientSaleRequestData request)
        {
            _saleService = saleService;
            _request = request;
        }
        public short PayNow(int amount)
        {
            _request.Amount = amount;
            _response = _saleService.SalePaymentRequest(_request);
            return _response.Status;

        }
        public bool IsSuccessfulStatus()
        {
            return _response.Status == 0 ? true : false;

        }
    }

}
