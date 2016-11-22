using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WxOpenIdCore.Common;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WxOpenIdCore.Controllers
{
    public class WxCodeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();

            string openIdProcessUrl = "http://" + CommonHelper.BaseUri + "/WxCode/OpenId";
            string reurl = Request.Query["myPageUrl"].ToString();

            string url = "https://open.weixin.qq.com/connect/oauth2/authorize?appid="
                + CommonHelper.AppId + "&redirect_uri=" + openIdProcessUrl + "?reurl="
                + reurl + "&response_type=code&scope=snsapi_userinfo&state=1#wechat_redirect";
            Response.Redirect(url);

            return View();
        }

        public async Task OpenId()
        {
            string reurl = Request.Query["reurl"].ToString();
            string code = Request.Query["code"].ToString();

            string openId =await GetOpenId(code);
            string redirectUrl = string.Format("{0}?openId={1}", reurl, openId);
            Response.Redirect(redirectUrl);
        }

        private async Task<string> GetOpenId(string code)
        {
            string url = "https://api.weixin.qq.com/sns/oauth2/access_token?appid=" + CommonHelper.AppId 
                + "&secret=" + CommonHelper.AppSecret +
                "&code=" + code + "&grant_type=authorization_code";
            string responseText = await CommonHelper.PostJsonAsync(url,"");
            JObject jObject = JObject.Parse(responseText);
            return jObject.Property("openId").Value.ToString();
          
        }
    }
}
