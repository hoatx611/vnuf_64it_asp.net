using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace K64_HTTT_Web.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo
        public ActionResult Index()
        {
            ViewBag.Title = "Demo";
            return View();
        }

        public ActionResult UploadFile()
        {
            ViewBag.Title = "Tải lên tập tin";
            return View();
        }

        public ActionResult SendMail()
        {
            // Ví dụ: về việc phản ánh (góp ý) thông tin
            // B1: Vào web form: nhập thông tin và gửi thông điệp
            // #Trong form có các thông tin sau:
            // - Họ và tên
            // - Email
            // - Nội dung thông điệp
            // - Tập tin đính kèm
            // B2: Hệ thống sẽ gửi email tự động đến người gửi báo rằng đã nhận đc góp ý:
            // Chức nặng API sẽ được hoạt động
            // Chú ý: thiết lập gửi đi sau 10-30s
            ViewBag.Title = "Gửi email";
            return View();
        }
    }
}