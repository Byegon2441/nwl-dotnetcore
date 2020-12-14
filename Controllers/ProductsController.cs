using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using nwl_dotnetcore.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace nwl_dotnetcore.Controllers
{
    //ถ้าประกาศด้านบนcontroller มันจะคลุมตัวcontrollerนั้นเลย
    [Route("custom/patthapong")]//เป็นการกำหนด Routeแบบcustom
    public class ProductsController : Controller
    {
        ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [Route("")] //เป็นการกำหนดใหเเป็น ไฟล์index คือไม่ต้องพิมพ์ชื่อไฟล์ในurl
        public IActionResult Index()
        {
            //  IActionResult คือ ประเภทของการรีเทิร์น(return type)

            /* ชื่อ view เหมือนกันชื่อ method
              Index คือ ชื่อview ที่อยู่ใน Floder view
             ในทีนี้คือ ไฟล์ index.cshtml ที่อยู่ใน Product
             "/Views/Products/Index.cshtml" */
            return View();
        }
        [Route("[action]")] //[action] น่าจะหมายถึง ชื่อ method 
                            //[controller] หมายถึง ชื่อ controller
        public IActionResult ViewProduct()
        {
            // Products _data = new Products();//ประกาศ model 
            // _data.Name = "Book";
            // _data.Detail = "Programming .Net Core";
            // _data.Price = 200;



            IEnumerable<Products> _data = new List<Products>{
                new Products(){
                Name = "Book",
                Detail = "Programming .Net Core",
                Price = 200
                 },
                 new Products(){
                     Name = "Pencil",
                     Detail = "IOS",
                     Price = 120
                 }
            };
            return View(_data);//return _data ไปที่ view ViewProduct

        }
        [Route("teststring")]
        public string teststring()
        {
            return "This is String.";
        }

        [Route("[action]/{id1}/{id2}/{id3}")]
        //[Route("[action]/{id}")] ถ้ากำหนดแบบนี้เวลาเข้าurl จะต้องใส่ paraหลัง /
        //exam localhost:50001/custom/patthapong/todo/21
        //result = Age = 21
        //-------------------------------------------------------------------
        //[Route("[action]")] ถ้ากำหนดแบบนี้เวลาเข้าurl จะต้องใส่ ?ตามด้วย ชื่อpara=ค่าที่ต้องการ
        //exam localhost:50001/custom/patthapong/todo?id=21
        //result = Age = 21
        /* ------ 
        ถ้ามีpara 2 ตัว-ขึ้นไป จะใช้ / คั่นระหว่างpara 
        และตอนพิมพ์ url ให้ใส่ / ด้วย
        -----------*/
        public string todo(int id1, int id2, int id3)
        {
            return $"id1 = {id1} ,id2 = {id2} , id3 = {id3}";
            //$"normal text {variable}"
            //$"ตัวหนังสือธรรมดา {ตัวแปร}"
            //sytaxการใส่ตัวแปรลงไปในsting มี $หน้า " " และตัวแปรจะถูกครอบด้วย{ }
        }

        [NonAction] // เป็นการปิดการทำงานของ action
        [Route("[action]")]
        public IActionResult download()
        {
            //File(ที่อยู่ไฟล์,datatype,ชื่อไฟล์ที่จะขึ้นเวลาdownload)
            //ประยุกต์ใชเกลับไฟล์อื่นได้
            return File("image.png", "image/png", "patthapong.png");//file อยู่ในfloder wwwroot
        }


        [ActionName("pdall")]//เปลี่ยนชื่อ action หรือ น่าจะเป็น method
        [Route("[action]")]//กำหนดให้ routeวิ่งไปที่ชื่อ action
        public IActionResult ProductAll()
        {
            return View("ProductAll");
        }

        [Route("[action]")]
        public string checkType(int id)
        {
            if (ModelState.IsValid)
            {
                return "true";
            }
            else
            {
                return "false";
            }
        }
        [Route("[action]")]
        public IActionResult notfound()
        {
            return NotFound(); //เวลาเสิร์ชข้อมูลแล้วไม่เจอ จะขึ้นว่าหาไม่เจอ
        }
        [Route("[action]")]
        public IActionResult redirect()
        {
            return Redirect("http:www.google.com");
            //วิ่งไปที่ google 
        }
        [Route("[action]")]
        public IActionResult redirectoaction()
        {
            return RedirectToAction("pdall");
            //วิ่งไปหา action pdall
        }
        [Route("[action]")]
        public IActionResult tocontroller()
        {
            return RedirectToAction("index", "home",new {id = 10});
            //RedirectToAction(actionname,controller)
        }

    }//class
}//namespace