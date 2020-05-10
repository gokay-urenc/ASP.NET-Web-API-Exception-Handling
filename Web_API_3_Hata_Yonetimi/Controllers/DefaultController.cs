using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Web_API_3_Hata_Yonetimi.App_Start;
using Web_API_3_Hata_Yonetimi.Models;

namespace Web_API_3_Hata_Yonetimi.Controllers
{
    [CustomFilter] // Controller seviyesi: İçerideki bütün methodları etkiler. Her methodun üstüne tek tek yazmaktan daha iyi.
    public class DefaultController : ApiController
    {
        NORTHWND db = new NORTHWND();

        // [CustomFilter] // Method {action} seviyesi filter attribute.
        public HttpResponseMessage GetHesapla()
        {
            int sayi_1 = 2;
            int sayi_2 = 0;
            int sonuc = sayi_1 / sayi_2;
            return Request.CreateResponse(HttpStatusCode.OK, sonuc);
        }

        public IHttpActionResult GetKategori(string id)
        {
            int kategoriID = int.Parse(id);
            Category bulunanKategori = db.Categories.FirstOrDefault(x => x.CategoryID == kategoriID);
            if (bulunanKategori != null)
            {
                return NotFound();
            }
            return Ok(bulunanKategori);
        }
    }
}