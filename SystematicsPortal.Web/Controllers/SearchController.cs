using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Services;
using System.Threading.Tasks;
using System;
using SystematicsPortal.Models.Entities.DTOs;
using System.Linq;
using SystematicsPortal.Models.Entities.Documents.Name;
using System.Xml.Serialization;
using System.Xml;
using SystematicsPortal.Web.ViewModels;
using System.Collections.Generic;
using SystematicsPortal.Models.Entities.Documents.SubDocuments;

namespace SystematicsPortal.Web.Controllers
{
    public class SearchController : Controller
    {
        const int NUMBER_OF_RESULTS_PER_PAGE = 10;
        public ISearchService _searchService;
        public IContentService _contentService;


        public SearchController(ISearchService searchService, IContentService contentService)
        {
            _searchService = searchService;
            _contentService = contentService;
        }

        // GET: Search
        [HttpPost]
        public async Task<ActionResult> Index(string query, string appliedFacets, string appliedRanges, string currentDisplayTab, string pageNumber, string sortField, string back, string errorMessage)
        {
            try
            {
                //await CallContentServiceAsync();

                bool success = false;
                var viewData = new SearchViewModel(null, null);

                string uncorrectedQuery = String.Empty;
                if (query != null)
                {
                    uncorrectedQuery = query;
                    //query = AutoCorrectQueryString(query);
                    if (uncorrectedQuery.Equals(query))
                    {
                        uncorrectedQuery = String.Empty;
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
                    viewData.Query = String.Empty;
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
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Document";
            xRoot.IsNullable = true;

            /*NameDocument document;
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(NameDocument), xRoot);

            // TODO: need to get document detail page from API
            using (StreamReader xml = new StreamReader("single-document.xml"))
            {
                document = (NameDocument)ser.Deserialize(xml);
            }*/

            /*string xmlConfig;
            using (StreamReader reader = new StreamReader("config-fields.xml"))
            {
                xmlConfig = reader.ReadToEnd();
            }*/

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("single-document.xml");

            XmlNode xmlNode = xmlDoc.SelectSingleNode("//Document/NameFull");
            XmlNodeList xmlNodeList = xmlDoc.SelectNodes("//Document/CollectionObjects/CollectionObject");
            List<XmlNode> xmlNodesList = new List<XmlNode>();

            if (xmlNodeList.Count > 0)
            {
                List<XmlNode> foundNodes = new List<XmlNode>();
                xmlNodesList = ReadAllNodes(xmlNodeList.Item(0), xmlNodesList);
            }

            List<FieldViewModel> list = new List<FieldViewModel>();

            /* XmlReader rdr = XmlReader.Create(new System.IO.StringReader(xmlConfig));
            while (rdr.Read())
            {
                if (rdr.NodeType == XmlNodeType.Element)
                {
                    Console.WriteLine(rdr.LocalName);
                    // maybe do xpath to right document so can traverse from there.
                    if(rdr.GetAttribute("documentClass") != null && rdr.GetAttribute("documentClass") == "name")
                    {
                        //string documentClass = rdr.GetAttribute("documentClass");
                    }

                    if(rdr.LocalName == "Field")
                    {
                        //FieldViewModel fieldViewModel = new FieldViewModel();
                        string type = document.GetType().GetProperty(rdr.GetAttribute("type")).GetValue(document, null).GetType().Name;

                        if (type.Equals("TextType"))
                        {
                            fieldViewModel.FieldTextType = (TextType) document.GetType().GetProperty(rdr.GetAttribute("type")).GetValue(document, null);
                        }
                        else if (type.Equals("ReferenceType"))
                        {
                            fieldViewModel.FieldReferenceType = (ReferenceType) document.GetType().GetProperty(rdr.GetAttribute("type")).GetValue(document, null);
                        }
                        else if (type.Equals("LinkedNameType"))
                        {
                            fieldViewModel.FieldLinkedNameType = (LinkedNameType) document.GetType().GetProperty(rdr.GetAttribute("type")).GetValue(document, null);
                        }
                        else
                        {
                            fieldViewModel.Field = document.GetType().GetProperty(rdr.GetAttribute("type")).GetValue(document, null);
                        }

                        fieldViewModel.EnglishLabel = rdr.GetAttribute("english-label");
                        fieldViewModel.FieldName = rdr.GetAttribute("type");
                        fieldViewModel.Order = Int32.Parse(rdr.GetAttribute("order"));
                        //fieldViewModel.FieldType = type;
                        list.Add(fieldViewModel);
                    }
                }
            }*/

            FieldViewModel fieldViewModel = new FieldViewModel();
            fieldViewModel.Label = xmlNode.Name;
            fieldViewModel.Order = 1;
            fieldViewModel.xmlNode = xmlNode;

            list.Add(fieldViewModel);

            FieldViewModel fieldViewModel2 = new FieldViewModel();
            fieldViewModel2.Label = "Collector";
            fieldViewModel2.Order = 2;
            fieldViewModel2.xmlNodeList = xmlNodeList;

            list.Add(fieldViewModel2);

            list.Sort((x, y) => x.Order.CompareTo(y.Order));

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

            FieldsViewModel fields = new FieldsViewModel();
            fields.Fields = list;
            //fields.NameDocument = document;
            return View(fields);
            //return View();
        }



        public List<XmlNode> ReadAllNodes(XmlNode node, List<XmlNode> xmlNodesList)
        {
            if (node.ChildNodes.Count > 0)
            {
                foreach (XmlNode subNode in node.ChildNodes)
                {
                    ReadAllNodes(subNode, xmlNodesList);
                }
            }
            else
            {
                xmlNodesList.Add(node);
            }
            return xmlNodesList;
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

        private async Task CallContentServiceAsync()
        {
            var resources = await _contentService.GetResources();

            var testResource = resources.ResourceList.FirstOrDefault(x => x.Value == "Test Data");

            var itemTypes = await _contentService.GetItemTypes(testResource.ResourceId);

            var itemType = itemTypes.Types.FirstOrDefault(x=>x.DisplayTitleSingular == "eFlora-Taxon");

            var itemIds = await _contentService.GetItemIds(itemType.ItemTypeId);

            var itemIdsList = itemIds.ItemsList.Select(x => x.ItemId).ToList();
                
            var items = await _contentService.GetItemsByIds(itemIdsList);

            var test = 1;
        }
    }
}
