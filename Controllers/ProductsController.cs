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

         public ProductsController(ILogger<ProductsController> logger){
             _logger =logger;
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
         public IActionResult ViewProduct(){
            // Products _data = new Products();//ประกาศ model 
            // _data.Name = "Book";
            // _data.Detail = "Programming .Net Core";
            // _data.Price = 200;

            

            IEnumerable<Products> _data = new List <Products>{
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
         public string teststring(){
             return "This is String.";
         }

    [Route("[action]/{id}")]
    //[Route("[action]/{id}")] ถ้ากำหนดแบบนี้เวลาเข้าurl จะต้องใส่ paraหลัง /
    //exam localhost:50001/custom/patthapong/todo/21
    //result = Age = 21
    //-------------------------------------------------------------------
    //[Route("[action]")] ถ้ากำหนดแบบนี้เวลาเข้าurl จะต้องใส่ ?ตามด้วย ชื่อpara=ค่าที่ต้องการ
    //exam localhost:50001/custom/patthapong/todo?id=21
    //result = Age = 21
    
     public string todo(int id){
         return $"Age = {id}";
         //$"normal text {variable}"
         //$"ตัวหนังสือธรรมดา {ตัวแปร}"
         //sytaxการใส่ตัวแปรลงไปในsting มี $หน้า " " และตัวแปรจะถูกครอบด้วย{ }
     }    


    }//class
}//namespace