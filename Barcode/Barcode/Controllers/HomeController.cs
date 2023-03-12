using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ZXing;
using ZXing.Common;

namespace Barcode.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult GenerateBarcode(string url)
        {
            // Generate the barcode image
            var writer = new BarcodeWriter
            {
                Format = BarcodeFormat.QR_CODE,
                Options = new EncodingOptions
                {
                    Width = 250,
                    Height = 250,
                    Margin = 0
                }
            };
            var bitmap = writer.Write(url);
            var stream = new MemoryStream();
            bitmap.Save(stream, ImageFormat.Png);
            stream.Seek(0, SeekOrigin.Begin);

            // Store the URL in the MongoDB collection
            //        var client = new MongoClient();
            //        var database = client.GetDatabase("mydb");
            //        var collection = database.GetCollection<BsonDocument>("webpages");
            //        var document = new BsonDocument
            //{
            //    { "url", url }
            //};
            //        collection.InsertOne(document);

            // Return the barcode image as a FileResult
            return File(stream, "image/png");
        }
        public void Generate(string text)
        {
            text = "Hello, world!"; // the text to encode
            BarcodeWriter writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE; // the barcode format

            // set the encoding options
            EncodingOptions options = new EncodingOptions();
            options.Height = 100; // the height of the barcode image
            options.Width = 300; // the width of the barcode image
            options.Margin = 10; // the margin around the barcode

            writer.Options = options;

            // generate the barcode image
            Bitmap barcodeImage = writer.Write(text);
            // save the barcode image to a file
            string fileName = "barcode.jpg"; // or "barcode.jpg"
            //barcodeImage.Save(Server.MapPath(fileName), System.Drawing.Imaging.ImageFormat.Jpeg); // or ImageFormat.Jpeg
            barcodeImage.Save(@"C:\Users\ShereenAkoum\Documents\Projects\IRQ_SDL-LP\IRQ_SDL-LP\BE\stitchedImage.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

        }
    }
}
