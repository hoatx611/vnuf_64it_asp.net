using Swashbuckle.Swagger;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.UI.WebControls;
using K64_HTTT_Web.Models;
using System.Diagnostics;

namespace K64_HTTT_Web.Controllers
{
    public class ApiUploadController : ApiController
    {
        [Route("api/Upload/UploadFile")]
        [HttpPost]
        public async Task<HttpResponseMessage> Post()
        {
            // Check if the request contains multipart/form-data.
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }

            HttpResponseMessage result = null;
            var httpRequest = HttpContext.Current.Request;

            if (httpRequest.Files.Count > 0)
            {
                var files = new List<string>();
                for (var i = 0; i < httpRequest.Files.Count; i++)
                {
                    var postedFile = httpRequest.Files[i];
                    var filePath = HttpContext.Current.Server.MapPath("~/Media/Uploads/" + postedFile.FileName);
                    postedFile.SaveAs(filePath);
                    files.Add(filePath);
                }
                result = Request.CreateResponse(HttpStatusCode.Created, files);

                //var postedFile = httpRequest.Files[0];
                //var filePath = HttpContext.Current.Server.MapPath("~/Media/Uploads/" + postedFile.FileName);
                //postedFile.SaveAs(filePath);
                //result = Request.CreateResponse(HttpStatusCode.Created, postedFile.FileName);
            }
            else
            {
                result = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
            return result;
        }
    }
}
