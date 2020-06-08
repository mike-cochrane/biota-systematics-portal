using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security;
using System.Text;
using System.Web;
using System.Xml;
using Systematics.Portal.Web.Models;
using Systematics.Portal.Web.Services;

namespace Systematics.Portal.Web.Controllers
{
    public class SearchController : Controller
    {
        public ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: Search
        public ActionResult Index()
        {
            return View();
        }

        // GET: Search/Details/5
        public ActionResult Detail(int id)
        {
            Document document;
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Document));

            using (StreamReader xml = new StreamReader("single-document.xml"))
            {
                document = (Document)ser.Deserialize(xml);
            }

            //XmlDocument xmlString = new XmlDocument();
            //xmlString.Load("single-document.xml");
            //string xmlString = new StreamReader("single-document.xml").ReadToEnd();// This encoding helped me for special chars like ("é")
            //string encodedXml = HttpUtility.HtmlEncode(xmlString);
            //encodedXml = SecurityElement.Escape(encodedXml); // handled the & issue
            //xmlString = xmlString.Replace("<", "<").Replace(">", ">").Replace(""", "\"");
            //string encodedXml = xmlString.ToString().Replace("'", "&apos;").Replace("\"", "&quot;").Replace(">", "&gt;").Replace("<", "&lt;").Replace("&", "&amp;");

            // convert string to stream
            //byte[] byteArray = Encoding.UTF8.GetBytes(xmlString.ToString());
            //byte[] byteArray = Encoding.ASCII.GetBytes(contents);
            //MemoryStream xmlStream = new MemoryStream(byteArray);

            //document = (Document)ser.Deserialize(xmlStream);

            return View(document);
        }


        // GET: Search/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Search/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Search/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Search/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Search/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
