using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Xml;
using SystematicsData.Search.Models.Search;
using SystematicsPortal.Web.Helpers;
using SystematicsPortal.Web.Models;
using SystematicsPortal.Web.Services.Interfaces;
using SystematicsPortal.Web.ViewModels;

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
            //create query log
            //Query q = CreateQueryLog(query, collectionId, string.Empty, string.Empty);
            bool success = false;
            int specimenCount = -1;

            try
            {
                //await CallContentServiceAsync();
                var viewData = new SearchViewModel(sortField)
                {
                    ResultsPerPage = NUMBER_OF_RESULTS_PER_PAGE
                };

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

                viewData.HaveSearched = true;
                viewData.Result.SetAppliedFacets(appliedFacets);
                viewData.Result.SetAppliedRanges(appliedRanges);

                // viewData.Result = await _searchService.Search(query, selectedPage, NUMBER_OF_RESULTS_PER_PAGE, sortField, "ascending");
                viewData.Result = await _searchService.Search(query, viewData.Result.AppliedFacets, viewData.Result.AppliedRanges, selectedPage, NUMBER_OF_RESULTS_PER_PAGE, sortField, "ascending");
                //ViewComponent("SearchQuery", new { query = query }); // don't think this does anything.

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
                    specimenCount = viewData.Result.TotalSpecimens;
                }

                ModelState.Clear();
                return View(viewData);
            }
            /*catch (SystematicsPortalWebException ex)
            {
                return RedirectToAction("Index", new { query = query, errorMessage = ex.Message });
            }*/
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (back != null)
                {
                    //SubmitQueryLog(q, success, specimenCount);
                }
            }

        }

        // GET: Search/Details/5
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<ActionResult> Details(String id)
        {
            /*XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = "Document";
            xRoot.IsNullable = true;*/

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

            /*XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("single-document.xml");
            List<FieldViewModel> list = new List<FieldViewModel>();

            // TODO: need to traverse config xml as object and carry out an xpath query per field and build FieldViewModel collection.
            // similar to Ragnar.

            List<RenderConfig> renderConfigList = new List<RenderConfig>();
            RenderConfig renderConfig1 = new RenderConfig();
            renderConfig1.Order = 1;
            renderConfig1.XpathQuery = "//Document/NameFull";
            renderConfig1.XpathQueryType = "XmlNode";
            renderConfig1.IsSection = false;
            renderConfigList.Add(renderConfig1);

            RenderConfig renderConfig2 = new RenderConfig();
            renderConfig2.Order = 2;
            renderConfig2.XpathQuery = "//Document/CollectionObjects/CollectionObject";
            renderConfig2.XpathQueryType = "XmlNodeList";
            renderConfig2.IsSection = true;
            renderConfig2.SectionHeading = "Collections";
            renderConfigList.Add(renderConfig2);

            RenderConfig renderConfig3 = new RenderConfig();
            renderConfig3.Order = 3;
            renderConfig3.XpathQuery = "//Document/BiostatusValues/BiostatusValue";
            renderConfig3.XpathQueryType = "XmlNodeList";
            renderConfig3.IsSection = true;
            renderConfig3.SectionHeading = "Biota Status Values";
            renderConfigList.Add(renderConfig3);

            foreach (RenderConfig renderConfig in renderConfigList)
            {
                if(renderConfig.XpathQueryType.Equals("XmlNode"))
                {
                    XmlNode xmlNode = xmlDoc.SelectSingleNode(renderConfig.XpathQuery);
                    FieldViewModel fieldViewModel = new FieldViewModel();
                    fieldViewModel.Label = xmlNode.Name;
                    fieldViewModel.IsSection = renderConfig.IsSection;
                    fieldViewModel.Order = renderConfig.Order;
                    fieldViewModel.xmlNode = xmlNode;
                    list.Add(fieldViewModel);
                } else
                {
                    XmlNodeList xmlNodeList = xmlDoc.SelectNodes(renderConfig.XpathQuery);
                    List<XmlNode> xmlNodesList = new List<XmlNode>();
                    if (xmlNodeList.Count > 0)
                    {
                        List<XmlNode> foundNodes = new List<XmlNode>();
                        xmlNodesList = ReadAllNodes(xmlNodeList.Item(0), xmlNodesList);
                    }
                    FieldViewModel fieldViewModel2 = new FieldViewModel();
                    fieldViewModel2.SectionHeading = renderConfig.SectionHeading;
                    fieldViewModel2.IsSection = renderConfig.IsSection;
                    fieldViewModel2.Order = renderConfig.Order;
                    fieldViewModel2.xmlNodeList = xmlNodesList;
                    list.Add(fieldViewModel2);
                }
            }*/

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

            //list.Sort((x, y) => x.Order.CompareTo(y.Order));

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

            /*FieldsViewModel fields = new FieldsViewModel();
            fields.Fields = list;*/
            //return View(fields); 

            /*Document document = await _searchService.GetDocument(id);

            return View(document);*/
            return View();
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

        [HttpPost]
        public async Task<ActionResult> ResultsPartialAsync([FromBody] SearchQueryViewModel model)
        {

            model.query = Utility.ReplaceEscapedCharacters(model.query);

            model.appliedFacets = Utility.ReplaceEscapedCharacters(model.appliedFacets);
            string allFacets = model.appliedFacets;
            model.appliedRanges = Utility.ReplaceEscapedCharacters(model.appliedRanges);
            string allRanges = model.appliedRanges;

            /*if (model.selectedFacetType.ToLower().Equals("text"))
            {
                string current = "|" + model.selectedFacet + "|" + model.selectedValue;
                if (model.toggleOn)
                {
                    allFacets += current;
                }
                else
                {
                    allFacets.Replace(current, "");
                }
            }
            else if (model.selectedFacetType.ToLower().Equals("range"))
            {
                string current = "|" + model.selectedFacet + "|" + model.selectedValue + "|" + model.selectedUpperValue;
                if (model.toggleOn)
                {
                    allRanges += current;
                }
                else
                {
                    allRanges.Replace(current, "");
                }
            }*/

            try
            {
                var viewData = new SearchViewModel(model.sortField)
                {
                    HaveSearched = true,
                    SelectedView = model.currentDisplayTab,
                    ResultsPerPage = NUMBER_OF_RESULTS_PER_PAGE,
                    CurrentPage = model.pageNumber
                };

                viewData.Result.AppliedFacets = _searchService.SetAppliedFacets(model.appliedFacets, model.selectedFacet, model.selectedValue, model.selectedFacetType, model.toggleOn);
                viewData.Result.AppliedRanges = _searchService.SetAppliedRanges(model.appliedRanges, model.selectedFacet, model.selectedValue, model.selectedFacetType, model.selectedUpperValue.ToString(), model.toggleOn);

                if (model.selectedFacetType.ToLower().Equals("text"))
                {
                    var appliedFacet = new SelectedFacetValue()
                    {
                        FacetName = model.selectedFacet,
                        ValueName = model.selectedValue
                    };
                    if (model.toggleOn)
                    {
                        bool testBool = viewData.Result.ContainsAppliedFacet(appliedFacet);
                        if (!viewData.Result.ContainsAppliedFacet(appliedFacet))
                        {
                            viewData.Result.AppliedFacets.Add(appliedFacet);
                        }
                    }
                    else
                    {
                        if (viewData.Result.ContainsAppliedFacet(appliedFacet))
                        {
                            viewData.Result.RemoveAppliedFacet(appliedFacet);
                        }
                    }
                }
                else if (model.selectedFacetType.ToLower().Equals("range"))
                {
                    if (model.toggleOn)
                    {
                        if (model.selectedValue.Contains('.'))
                        {
                            model.selectedValue = model.selectedValue.Split('.')[0];
                        }
                        if (model.selectedUpperValue.ToString().Contains('.'))
                        {
                            model.selectedUpperValue = Convert.ToInt32(model.selectedUpperValue.ToString().Split('.')[0]);
                        }

                        var appliedRange = new SelectedRange()
                        {
                            FacetName = model.selectedFacet,
                            MinimumValue = Convert.ToInt32(model.selectedValue),
                            MaximumValue = Convert.ToInt32(model.selectedUpperValue)
                        };

                        viewData.Result.AddOrUpdateAppliedRange(appliedRange);
                    }
                    else
                    {
                        viewData.Result.RemoveAppliedRange(model.selectedFacet);
                    }
                }

                viewData.Result = await _searchService.Search(model.query, viewData.Result.AppliedFacets, viewData.Result.AppliedRanges, model.pageNumber, NUMBER_OF_RESULTS_PER_PAGE, model.sortField, "ascending");
                
                // TODO: Implement following method if it's necessary
                //viewData.OneOrMoreSelected = SetSelectedSpecimens(viewData.Result.FoundSpecimens);
                viewData.SetSortField(model.sortField);
                viewData.Query = model.query;

                if (model.selectAll)
                {
                    viewData.AllSelected = true;
                }

                ModelState.Clear();
                return PartialView(viewData);
            }
            catch (Exception error)
            {
                string test = error.Message;
                /*TODO - really need to return an error message to the user here, otherwise it just looks like their click did nothing*/
                throw;
            }
            finally
            {
                // TODO: Do logging
                //SubmitQueryLog(q, success, specimenCount);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Sort([FromBody] SearchQueryViewModel model)
        {
            model.query = Utility.ReplaceEscapedCharacters(model.query);

            var viewData = new SearchViewModel(model.sortField)
            {
                HaveSearched = true,
                SelectedView = model.currentDisplayTab,
                ResultsPerPage = NUMBER_OF_RESULTS_PER_PAGE,
                CurrentPage = model.pageNumber,
                SelectedSortOption = model.sortField
            };
            viewData.Result.SetAppliedFacets(model.appliedFacets);
            viewData.Result.SetAppliedRanges(model.appliedRanges);
            //viewData.Sets = GetSets();

            viewData.Result = await _searchService.Search(model.query, viewData.Result.AppliedFacets, viewData.Result.AppliedRanges, model.pageNumber, NUMBER_OF_RESULTS_PER_PAGE, model.sortField, "ascending");
            //viewData.OneOrMoreSelected = SetSelected(viewData.Result.FoundDocuments);
            viewData.SetSortField(model.sortField);

            if (model.selectAll)
            {
                viewData.AllSelected = true;
            }

            viewData.Query = model.query;

            ModelState.Clear();
            return PartialView("ResultsPartial", viewData);
            //TODO - whenever returning ResultsPartial, need to make sure select-all bool is added to parameters being passed backwards and forwards.
        }

        /*private bool SetSelectedDocument(Dictionary<Guid, DocumentSummary> summaries)
        {
            bool specimensSelected = false;
            if (Session["SelectedDocument"] != null)
            {
                var selectedSpecimen = (List<string>)Session["SelectedSpecimens"];

                foreach (var key in summaries.Keys)
                {
                    var summary = summaries[key];
                    if (selectedSpecimen.Contains(summary.SpecimenId.ToString().ToLower()))
                    {
                        summary.Selected = true;
                        specimensSelected = true;
                    }
                }
            }
            return specimensSelected;
        }*/
    }

   /*[HttpPost]
    public ActionResult ToggleAll(string selected, string query, string collection, string appliedFacets, string appliedRanges)
    {
        query = Utility.ReplaceEscapedCharacters(query);
        bool oneOrMoreSelected = false;

        string error = string.Empty;

        try
        {
            if (selected.ToLower().Equals("true"))
            {
                var result = new SearchResult();
                result.SetAppliedFacets(appliedFacets);
                result.SetAppliedRanges(appliedRanges);

                Dictionary<string, int> accessRights = GetUserAccessLevels();

                Session["SelectedSpecimens"] = SearchRepository.GetSpecimenIds(result.AppliedFacets, result.AppliedRanges, query, collection, accessRights);
                oneOrMoreSelected = true;
            }
            else
            {
                Session["SelectedSpecimens"] = null;
            }
        }
        catch (Exception)
        {
            error = "Unable to complete this request.";
        }

        JSONToggleSpecimenSelectionModel viewData = new JSONToggleSpecimenSelectionModel()
        {
            Error = error,
            OneOrMoreSelected = oneOrMoreSelected
        };
        return Json(viewData, JsonRequestBehavior.AllowGet);
    }

    [HttpPost]
    public ActionResult ToggleSelection(string id, string selected)
    {
        string error = string.Empty;

        List<string> specimenSelection = null;
        if (Session["SelectedSpecimens"] != null)
        {
            specimenSelection = (List<string>)Session["SelectedSpecimens"];
        }

        if (selected.ToLower().Equals("true"))
        {
            if (specimenSelection == null)
            {
                specimenSelection = new List<string>();
            }
            if (!specimenSelection.Contains(id.ToLower()))
            {
                specimenSelection.Add(id.ToLower());
            }
        }
        else
        {
            if (specimenSelection != null)
            {
                if (specimenSelection.Contains(id.ToLower()))
                {
                    specimenSelection.Remove(id.ToLower());
                }
            }
        }

        Session["SelectedSpecimens"] = specimenSelection;

        bool oneOrMoreSelected = false;
        if (specimenSelection.Any())
        {
            oneOrMoreSelected = true;
        }

        JSONToggleSpecimenSelectionModel viewData = new JSONToggleSpecimenSelectionModel()
        {
            Error = error,
            OneOrMoreSelected = oneOrMoreSelected
        };
        return Json(viewData, JsonRequestBehavior.AllowGet);
    }*/


    /*private void SubmitQueryLog(Query q, bool success, int specimenCount)
    {
        q.ReturnedTime = DateTime.Now;
        q.Success = success;
        if (success)
        {
            q.SpecimenCount = specimenCount;
        }

        System.ComponentModel.BackgroundWorker bw = new BackgroundWorker();
        bw.DoWork += new System.ComponentModel.DoWorkEventHandler(delegate (object o, DoWorkEventArgs args)
        {
            BackgroundWorker b = o as BackgroundWorker;
            QueriesRepository.Add(q);
        });
        bw.RunWorkerAsync();
    }*/
}
