using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsultaSkusMarketPlace.Clases;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Http;
using System.Security.Cryptography;
using System.Net.Http.Headers;
using System.IO;

namespace ConsultaSkusMarketPlace
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        private static readonly Encoding encoding = Encoding.UTF8;

        static void Main(string[] args)
        {
            List<MarketPlace> lMarketPlaces = new List<MarketPlace>();

            using (MarketPlaceContext db = new MarketPlaceContext())
            {
                lMarketPlaces = db.marketPlaces.ToList();



                if (lMarketPlaces != null && lMarketPlaces.Count > 0)
                {

                    foreach (MarketPlace item in lMarketPlaces)
                    {


                        Console.WriteLine("########## GET PRODUCTS ########## " + item.descripcion);

                        sendStringRequestAsync(item.apiKey, item.Apis.ToList(), item.userId, item.descripcion).Wait();
                    }
                }
            }
        }


        static async Task sendStringRequestAsync(string apiKey, List<Apis> Apis, string userId, string marketplace)
        {
            string url = string.Empty;
            Apis api = Apis.Find(x => x.action == "GetProducts");


            if (marketplace == "DAFITI")
            {

                api.parametrosUrl = api.parametrosUrl.Replace("{@Action}", api.action);
                api.parametrosUrl = api.parametrosUrl.Replace("{@Timestamp}", string.Format("{0:yyyy-MM-dd}{1:THH}{2::mm}{3::ss}-05:00", DateTime.Now, DateTime.Now, DateTime.Now, DateTime.Now));
                api.parametrosUrl = api.parametrosUrl.Replace("{@UserId}", userId);

                var escapedSignature = WebUtility.UrlEncode(api.parametrosUrl);
                escapedSignature = Regex.Replace(escapedSignature, "(%[0-9a-f]{2})", c => c.Value.ToUpperInvariant());
                escapedSignature = Regex.Replace(escapedSignature, "(%3d|%3D)", c => "=");
                escapedSignature = Regex.Replace(escapedSignature, "(%26)", c => "&");

                var keyByte = Encoding.UTF8.GetBytes(apiKey);
                string generatedSignature;
                using (var hmacsha256 = new HMACSHA256(keyByte))
                {
                    var dellip = hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(escapedSignature));
                    generatedSignature = ByteToString(dellip).ToLower();
                }

                url = string.Format(string.Format("{0}{1}&Signature={2}", api.urlBase, escapedSignature, generatedSignature));

            }

            try
            {

                //ServicePointManager.Expect100Continue = false;
                HttpResponseMessage response = await client.GetAsync(url);
                using (HttpContent content = response.Content)
                {
                    dynamic result = await content.ReadAsStringAsync();
                    Console.WriteLine("\n.....Escuchando respuesta......\n");
                    if (result.Contains("ErrorResponse"))
                        Console.WriteLine("Se genero un error?\n");

                    Console.WriteLine("Response.......");
                    Console.WriteLine(result);
                    //CantOrder Ordenes = JsonConvert.DeserializeObject<CantOrder>(result);

                    Console.WriteLine("final de response....");
                }



            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadLine();
        }

        static string ByteToString(byte[] buff)
        {
            string sbinary = "";
            for (int i = 0; i < buff.Length; i++)
                sbinary += buff[i].ToString("X2"); /* hex format */
            return sbinary;
        }
    }

}
