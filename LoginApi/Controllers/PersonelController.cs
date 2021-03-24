using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LoginApi.Controllers
{

    public class PersonelController : ApiController
    {
        serkanISGEntities db = new serkanISGEntities();
        public HttpResponseMessage Get()
        {

            return Request.CreateResponse(HttpStatusCode.OK, db.PERSONEL.ToList());


        }

        public HttpResponseMessage Post(Giris gr)
        {
            PERSONEL person = new PERSONEL();

            person = db.PERSONEL.FirstOrDefault(i => i.KULLANICI_ADI == gr.nickname);

            if (person != null && person.SIFRE ==gr.password)
            {
             
                return Request.CreateResponse(HttpStatusCode.OK, person);






                /// burayı dolduracaktın personel nesnesinde ajaxı yazarken dikkat li ol büyük ihtimaşşe orda patladı geçen
                /// 
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Kullanıcı bulunamadı");
            }










        }



    }


    public class Giris
    {



        public string nickname { get; set; }
        public string password { get; set; }


    }



}
