using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace VinaERP.Utilities
{
    public class ApiClientHelper
    {
        public static Func<string> GetAuth { get; private set; }
        public static string Login(String username, String password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return "Username or password is empty";
            }
            var user = new
            {
                userName = username,
                password = password
            };
            var client = new RestClient(ConfigurationManager.AppSettings["ApiBaseUrl"]);
            var request = new RestRequest("/user/loginerp", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(user);
            var response = client.Execute(request);
            if (response.ErrorException == null && response.StatusCode == HttpStatusCode.OK)
            {
                var content = (JObject)JsonConvert.DeserializeObject(response.Content);
                var result = (JObject)JsonConvert.DeserializeObject(content["result"].ToString());
                GetAuth = () => (result["tokenType"] + " " + result["accessToken"]);
                return null;
            }
            return "Login error";
        }

        public static List<GECurrenciesInfo> GetExchangeRate()
        {
            List<GECurrenciesInfo> currencyList = new List<GECurrenciesInfo>();
            GECurrenciesController objCurrenciesController = new GECurrenciesController();
            GECurrenciesInfo objCurrenciesInfo = new GECurrenciesInfo();
            objCurrenciesInfo = (GECurrenciesInfo)objCurrenciesController.GetObjectByNo("VND");
            if (objCurrenciesInfo != null) {
                objCurrenciesInfo.GECurrencySellRate = 1;
                objCurrenciesInfo.GECurrencyTransferRate = 1;
                objCurrenciesInfo.GECurrencyBuyRate = 1;
                currencyList.Add(objCurrenciesInfo);
            }

            XmlDocument xml = new XmlDocument();
            xml.Load("http://www.vietcombank.com.vn/ExchangeRates/ExrateXML.aspx");
            XmlNodeList noXml;
            noXml = xml.SelectNodes("/ExrateList/Exrate");
            int i = 0;
            for (i = 0; i <= noXml.Count - 1; i++)
            {
                objCurrenciesInfo = new GECurrenciesInfo();
                objCurrenciesInfo = (GECurrenciesInfo)objCurrenciesController.GetObjectByNo(noXml.Item(i).Attributes["CurrencyCode"].InnerText);
                if (objCurrenciesInfo == null)
                    continue;

                objCurrenciesInfo.GECurrencySellRate = Convert.ToDecimal(noXml.Item(i).Attributes["Sell"].InnerText);
                objCurrenciesInfo.GECurrencyBuyRate = Convert.ToDecimal(noXml.Item(i).Attributes["Buy"].InnerText);
                objCurrenciesInfo.GECurrencyTransferRate = Convert.ToDecimal(noXml.Item(i).Attributes["Transfer"].InnerText);
                currencyList.Add(objCurrenciesInfo);
            }
            return currencyList;
        }
    }
}
