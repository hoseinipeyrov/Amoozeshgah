using System.Web.Configuration;

namespace Amoozeshgah.WebReferences
{
    public class ConfigHelper
    {
        public static string LoginAccount
        {
            get
            {
                return WebConfigurationManager.AppSettings["LoginAccount"];
            }
        }

        public static string ParsianPGWBillServiceUrl
        {
            get
            {
                return WebConfigurationManager.AppSettings["ParsianPGWBillServiceUrl"];
            }
        }

        public static string ParsianPGWSaleServiceUrl
        {
            get
            {
                return WebConfigurationManager.AppSettings["ParsianPGWSaleServiceUrl"];
            }
        }

        public static string ParsianIPGPageUrl
        {
            get
            {
                return WebConfigurationManager.AppSettings["ParsianIPGPageUrl"];
            }
        }

        public static string BillPaymentCallback
        {
            get
            {
                return WebConfigurationManager.AppSettings["BillPaymentCallback"];
            }
        }

        public static string SalePaymentCallback
        {
            get
            {
                return WebConfigurationManager.AppSettings["SalePaymentCallback"];
            }
        }

        public static int LazyLoadingMinRows
        {
            get
            {
                return 300;
            }
        }
    }
}