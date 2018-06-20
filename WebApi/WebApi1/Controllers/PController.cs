using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Handlers;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    public class PController : Controller
    {
        // GET: P
        public ActionResult Index()
        {

            //客户端对象的创建与初始化
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

            //执行Get操作
            HttpResponseMessage responseMessage = client.GetAsync("http://localhost:1869/api/Products").Result;
            var list = responseMessage.Content.ReadAsAsync<List<Product>>().Result; //?直接就将json转换成实体类了？NB

            ViewData.Model = list;//@model List<WebApi1.Models.Product> 绑定页面Model

            return View();
        }
    }
}