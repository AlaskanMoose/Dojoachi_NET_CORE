using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace dojoachi.Controllers{
    public class dojoachi : Controller{
        [HttpGet]
        [Route("")]
        public IActionResult index(){
            Dojoachi lebron = HttpContext.Session.GetObjectFromJson<Dojoachi>("dojoachi");
            if(lebron == null){
                Dojoachi lebron2 = new Dojoachi();
                HttpContext.Session.SetObjectAsJson("dojoachi", lebron2);
                ViewBag.Lebron =  lebron2;
            }else{
                HttpContext.Session.SetObjectAsJson("dojoachi", lebron);
                ViewBag.Lebron =  lebron;
            }
            return View();
        }
        [HttpGet]
        [Route("feed")]
        public JsonResult feed(){
            Dojoachi lebron = HttpContext.Session.GetObjectFromJson<Dojoachi>("dojoachi");
            lebron.feed();
            HttpContext.Session.SetObjectAsJson("dojoachi", lebron);
            return Json(lebron);
        }
        [HttpGet]
        [Route("play")]
        public JsonResult play(){
            Dojoachi lebron = HttpContext.Session.GetObjectFromJson<Dojoachi>("dojoachi");
            lebron.play();
            HttpContext.Session.SetObjectAsJson("dojoachi", lebron);
            return Json(lebron);
        }
        [HttpGet]
        [Route("work")]
        public JsonResult work(){
            Dojoachi lebron = HttpContext.Session.GetObjectFromJson<Dojoachi>("dojoachi");
            lebron.work();
            HttpContext.Session.SetObjectAsJson("dojoachi", lebron);
            return Json(lebron);
        }
        [HttpGet]
        [Route("sleep")]
        public JsonResult sleep(){
            Dojoachi lebron = HttpContext.Session.GetObjectFromJson<Dojoachi>("dojoachi");
            lebron.sleep();
            HttpContext.Session.SetObjectAsJson("dojoachi", lebron);
            return Json(lebron);
        }
        [HttpPost]
        [Route("restart")]
        public IActionResult restart(){
            HttpContext.Session.Clear();
            return RedirectToAction("index");
        }
    }
}