using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DLLGakuen.Properties;
using WebGrease.Css.ImageAssemblyAnalysis;

namespace GakuenMVC.Controllers
{
    public class SchemaController : Controller
    {

        public ActionResult GetImage()
        {
            var bitmap = Resources.skema;
            var bitmapBytes = BitmapToBytes(bitmap);
            return File( bitmapBytes, "Image/jpeg");

        }

        //This method is for converting bitmap into a byte array
        private static byte[] BitmapToBytes(Bitmap img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }


        // GET: Schema
        public ActionResult SchemaExampleView()
        {
           
            return View();
        }
    }
}