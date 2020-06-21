using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Security;
using System.Text;
using System.Web;
using System.Xml;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Services;
using System.Threading.Tasks;
using System;
using SystematicsPortal.Model.Models.Documents;

namespace SystematicsPortal.Web.Controllers
{
    public class SearchController : Controller
    {
        const int NUMBER_OF_RESULTS_PER_PAGE = 10;
        public ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        // GET: Search
        [HttpPost]
        public async Task<ActionResult> Index(string query, string appliedFacets, string appliedRanges, string currentDisplayTab, string pageNumber, string sortField, string back, string errorMessage)
        {
            try
            {
                bool success = false;
                var viewData = new SearchViewModel(null, null);

                string uncorrectedQuery = string.Empty;
                if (query != null)
                {
                    uncorrectedQuery = query;
                    //query = AutoCorrectQueryString(query);
                    if (uncorrectedQuery.Equals(query))
                    {
                        uncorrectedQuery = string.Empty;
                    }
                    //update query log
                    //q.QueryString = query;
                }

                int selectedPage = 0;
                if (pageNumber != null)
                {
                    selectedPage = Convert.ToInt32(pageNumber);
                }
                viewData.CurrentPage = selectedPage;
                sortField = "Title";

                // viewData.Result = await _searchService.Search(query, selectedPage, NUMBER_OF_RESULTS_PER_PAGE, sortField, "ascending");
                viewData.Result = await _searchService.Search(query, null,null,selectedPage, NUMBER_OF_RESULTS_PER_PAGE, sortField, "ascending");

                if (query == null)
                {
                    viewData.Query = string.Empty;
                }
                else
                {
                    viewData.Query = query;
                    viewData.SearchData.UncorrectedQuery = uncorrectedQuery;
                }

                if (viewData.Result != null)
                {
                    success = true;
                    //specimenCount = viewData.Result.TotalSpecimens;
                }

                return View(viewData);
            }
            catch (Exception e)
            {
                throw e;
            } 
            finally
            {
                // do something
            }

        }

        // GET: Search/Details/5
        public ActionResult Details(int id)
        {
            NameDocumentDto document;
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(NameDocumentDto));

            using (StreamReader xml = new StreamReader("single-Document-References-Fungi.xml"))
            {
                document = (NameDocumentDto)ser.Deserialize(xml);
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
