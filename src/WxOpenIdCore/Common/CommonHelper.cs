


using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WxOpenIdCore.Common
{
    public class CommonHelper
    {
        //xiaomiao's test wechat appid
        public static string AppId
        {
            get { return "wxfc82543f2ac38756"; }
        }
        public static string AppSecret
        {
            get { return "d4624c36b6795d1d99dcf0547af5443d"; }
        }
        public static string BaseUri
        {
            get { return "3497d78c.ngrok.io"; }
        }



        public static async Task<string> PostJsonAsync(string url, string postData)
        {
            //byte[] data = Encoding.UTF8.GetBytes(postData);
            Uri uri = new Uri(url);
            var msg = "";
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Connection.Add("keep-alive");
                HttpContent content = new StringContent(postData, Encoding.UTF8);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var res = httpClient.PostAsync(url, content).GetAwaiter().GetResult();
                if (res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    msg = await res.Content.ReadAsStringAsync();
                }
            }

            return msg;// await Task.Factory.StartNew(() => Newtonsoft.Json.JsonConvert.SerializeObject(msg));
        }




    }
}