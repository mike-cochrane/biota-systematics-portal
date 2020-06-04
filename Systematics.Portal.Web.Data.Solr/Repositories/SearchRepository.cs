using Systematics.Portal.Web.Data.Interfaces;
using Systematics.Portal.Web.Data.Sql.Repositories;
using Systematics.Portal.Web.Data.Solr.Model;
using Systematics.Portal.Web.Model;
using SolrNet;
using SolrNet.Commands.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using CommonServiceLocator;
using Microsoft.Win32;
using HttpWebAdapters;
using System.Net;
using System.Text;
using HttpWebAdapters.Adapters;

namespace Systematics.Portal.Web.Data.Solr.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        // We should use DI to have just one SolrConnection, but as the SearchRepository is created with a property on the controllers,
        // we have to use a static property to assure just one solr connection
        private static ISolrOperations<Specimen> SolrConnection;
        private IAdminFacetsRepository _adminFacetsRepository;
        private List<AdminFacet> _facetConfig;

        public SearchRepository(string solrConnectionString, string userName, string password)
        {
            if (SolrConnection == null)
            {
                SolrConnection = InitializeConnection(solrConnectionString, userName, password);
            }
        }

        private ISolrOperations<Specimen> InitializeConnection(string coreUrl, string userName, string password)
        {

            var solrConnection = new SolrNet.Impl.SolrConnection(coreUrl);

            var userAndPasswordNotNull = !string.IsNullOrEmpty(userName) && !string.IsNullOrEmpty(password);

            if (userAndPasswordNotNull)
            {
                solrConnection.HttpWebRequestFactory = new SecureHttpWebRequestFactory(userName, password);
            }

            Startup.Init<Specimen>(solrConnection);

            return ServiceLocator.Current.GetInstance<ISolrOperations<Specimen>>();
        }

        private IAdminFacetsRepository AdminFacetsRepository
        {
            get
            {
                if (_adminFacetsRepository == null)
                {
                    _adminFacetsRepository = new AdminFacetsRepository();
                }
                return _adminFacetsRepository;
            }
        }

        private List<AdminFacet> FacetConfig
        {
            get
            {
                if (_facetConfig == null)
                {
                    _facetConfig = AdminFacetsRepository.GetAll();
                }
                return _facetConfig;
            }
        }

        public SearchResult Search(
            List<SelectedFacetValue> appliedFacets,
            List<SelectedRange> appliedRanges,
            string searchTerm,
            string collection,
            Dictionary<string, int> userAccessLevels,
            int pageNumber,
            int resultsPerPage,
            string sortBy,
            string sortOrder)
        {
            try
            {
                SearchResult result = new SearchResult();

                var queries = new List<ISolrQuery>();

                //filter query by access levels
                var securityFilter = new List<ISolrQuery>();
                foreach (var item in userAccessLevels)
                {
                    securityFilter.Add(new SolrQueryByField("collection", item.Key) && new SolrQueryByField("securityLevel", Convert.ToString(item.Value)));
                }
                queries.Add(new SolrMultipleCriteriaQuery(securityFilter, "OR"));

                //filter query by selected collection
                if (collection.ToLower() != "all")
                {
                    queries.Add(new SolrQueryByField("collection", collection));
                }

                //filter query by applied facets
                if (appliedFacets != null)
                {
                    foreach (SelectedFacetValue appliedFacet in appliedFacets)
                    {
                        queries.Add(new SolrQueryByField(appliedFacet.FacetName, appliedFacet.ValueName));
                    }
                }

                //filter query by applied ranges
                if (appliedRanges != null)
                {
                    foreach (SelectedRange appliedRange in appliedRanges)
                    {
                        queries.Add(new SolrQueryByRange<int>(appliedRange.FacetName, appliedRange.MinimumValue, appliedRange.MaximumValue));
                    }
                }

                //calculate where to start taking results base on page number
                int startPos = pageNumber * resultsPerPage;

                //set the sort order
                var orderBy = GetSortArray(sortBy, sortOrder);

                var solr = SolrConnection;

                DateTime start = DateTime.Now;

                var facets = new FacetParameters()
                {
                    Queries = new[] {
                          new SolrFacetFieldQuery("abundance_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("actionedBy_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("associationType_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("class_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("collectionMethod_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("collectionMonth_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("collector_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("country_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("cultureViability_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("determiner_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("division_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("duplicates_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("ecologicalDistrict_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("ecologicalRegion_ss"){MinCount=1},
                          new SolrFacetFieldQuery("exsiccata_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("family_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("flagValue_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("genus_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("identificationUncertain_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("keyword_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("kindOfSpecimen_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("landDistrict_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("loanStatus_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("nzAreaCode_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("observedSpecies_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("order_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("organisation_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("otherReferenceNoType_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("phylum_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("preferredName_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("referenceNumber_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("storageMethod_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("subcollection_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("taxonomicName_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("transactionReferenceNo_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("transactionStatus_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("typeOfCollectionEvent_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("typeOfEvent_ss"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("typeOfFlag_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("typeOfIdentification_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("typeStatus_ss" ){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("dateAdded"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("last_modified"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("collectionDate"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("collectionYear"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("altitude"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("localHeight"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("identificationDate"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("actionedDate"){ MinCount=1, Limit=-1 },
                          new SolrFacetFieldQuery("hasImages"){ MinCount=1, Limit=1 }
                        }
                };

                var queryOptions = new QueryOptions
                {
                    FilterQueries = queries,
                    OrderBy = orderBy,
                    Rows = resultsPerPage,
                    StartOrCursor = new StartOrCursor.Start(startPos),
                    Facet = facets
                };

                ISolrQuery solrQuery = new SolrQuery(searchTerm);

                var extraParameters = new List<KeyValuePair<string, string>>();
                // As the "text" field is not declared as default parameter on solr,
                // we need that solrnet uses this field as default parameter
                extraParameters.Add(new KeyValuePair<string, string>("df", "text"));
                extraParameters.Add(new KeyValuePair<string, string>("q.op", "AND"));

                queryOptions.ExtraParams = extraParameters;

                var results = solr.Query(solrQuery, queryOptions);

                //NB If you want to return a count of all the records that don't have a facet of the specified type recorded, then add Missing=true to the options passed into the SolrFacedFieldQuery.

                //result.SecondsToRetrieveData = (int)(DateTime.Now - start).Seconds;

                //get specimens
                foreach (Specimen term in results)
                {
                    SpecimenSummary summary = new SpecimenSummary()
                    {
                        SpecimenId = new Guid(term.SpecimenId),
                        Collection = term.Collection,
                        AccessionNumber = term.AccessionNumber,
                        TaxonName = term.TaxonomicName,
                        SubCollection = term.Subcollection,
                        Country = term.Country,
                        LandDistrict = term.LandDistrict,
                        EcologicalDistrict = term.EcologicalDistrict,
                        NZAreaCode = term.NZAreaCode,
                        Locality = term.Locality,
                        SpecimenType = term.KindOfSpecimen,
                        TypeStatus = term.TypeStatus,
                        HasImages = term.HasImages,
                        AccessionNumberSort = term.AccessionNumberSort,
                        TaxonNameSort = term.TaxonomicNameSort
                    };
                    result.FoundSpecimens.Add(summary.SpecimenId, summary);
                }

                result.TotalSpecimens = results.NumFound;

                //get facets
                foreach (AdminFacet config in FacetConfig)
                {
                    var current = results.FacetFields.Where(c => c.Key == config.SolrFieldName);
                    if (current.Any())
                    {
                        var f = current.First();
                        switch (config.Type)
                        {
                            case "numeric":
                            case "date":
                                if (f.Value.Any() && f.Value.Where(v => v.Value > 0).Any())
                                {
                                    Range range = new Range()
                                    {
                                        Name = f.Key,
                                        DisplayText = config.Facet,
                                        Type = config.Type,
                                        MinimumValue = Convert.ToInt32(f.Value.First().Key),
                                        MaximumValue = Convert.ToInt32(f.Value.Last().Key)
                                    };

                                    //Calculate data for sparkline
                                    if (range.Type.Equals("numeric"))
                                    {
                                        if (range.MaximumValue != range.MinimumValue)
                                        {
                                            float sparklineIncrement = ((float)range.MaximumValue - (float)range.MinimumValue) / Range.NUMBER_SPARKLINES;
                                            Dictionary<float, int> sparklineCounts = new Dictionary<float, int>();
                                            float currentKey = range.MinimumValue;
                                            sparklineCounts.Add(currentKey, 0);
                                            for (int i = 0; i < 94; i++)
                                            {
                                                currentKey += sparklineIncrement;
                                                sparklineCounts.Add(currentKey, 0);
                                            }

                                            if (f.Value.Any())
                                            {
                                                foreach (var item in f.Value)
                                                {
                                                    int number = Convert.ToInt32(item.Key);
                                                    float currentIncrement = float.NaN;
                                                    float nextIncrement = float.NaN;
                                                    bool inserted = false;
                                                    foreach (float key in sparklineCounts.Keys)
                                                    {
                                                        currentIncrement = nextIncrement;
                                                        nextIncrement = key;
                                                        if (!float.IsNaN(currentIncrement))
                                                        {
                                                            if (number >= currentIncrement && number < nextIncrement)
                                                            {
                                                                sparklineCounts[currentIncrement] += item.Value;
                                                                inserted = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    if (!inserted)
                                                    {
                                                        sparklineCounts[nextIncrement] += 1;
                                                    }
                                                }
                                            }

                                            bool first = true;
                                            foreach (int count in sparklineCounts.Values)
                                            {
                                                string value = string.Empty;
                                                if (count > 0)
                                                {
                                                    value = Convert.ToString(Math.Log10(count + 10));
                                                }
                                                else
                                                {
                                                    value = "0";
                                                }

                                                if (first)
                                                {
                                                    range.SparklineData = value;
                                                    first = false;
                                                }
                                                else
                                                {
                                                    range.SparklineData += "," + value;
                                                }
                                            }
                                        }
                                    }
                                    else if (range.Type.Equals("date"))
                                    {
                                        if (f.Value.Any())
                                        {
                                            //Calculate sparkline variables
                                            DateTime minDate = ConvertIntToDate(range.MinimumValue);
                                            DateTime maxDate = ConvertIntToDate(range.MaximumValue);
                                            if (minDate != maxDate)
                                            {
                                                double sparklineIncrement = maxDate.Subtract(minDate).TotalDays / Range.NUMBER_SPARKLINES;
                                                Dictionary<DateTime, int> sparklineCounts = new Dictionary<DateTime, int>();
                                                DateTime currentKey = minDate;
                                                sparklineCounts.Add(currentKey, 0);
                                                for (int i = 0; i < 94; i++)
                                                {
                                                    currentKey = currentKey.AddDays(sparklineIncrement);
                                                    sparklineCounts.Add(currentKey, 0);
                                                }

                                                //Calculate the counts for each interval
                                                foreach (var item in f.Value)
                                                {
                                                    DateTime currentIncrement = DateTime.MaxValue;
                                                    DateTime nextIncrement = DateTime.MaxValue;
                                                    bool inserted = false;
                                                    DateTime d = ConvertIntToDate(Convert.ToInt32(item.Key));
                                                    foreach (DateTime key in sparklineCounts.Keys)
                                                    {
                                                        currentIncrement = nextIncrement;
                                                        nextIncrement = key;
                                                        if (!currentIncrement.Equals(DateTime.MaxValue))
                                                        {
                                                            if (d.CompareTo(currentIncrement) >= 0 && d.CompareTo(nextIncrement) < 0)
                                                            {
                                                                sparklineCounts[currentIncrement] += item.Value;
                                                                inserted = true;
                                                                break;
                                                            }
                                                        }
                                                    }
                                                    if (!inserted)
                                                    {
                                                        sparklineCounts[nextIncrement] += 1;
                                                    }
                                                }

                                                //Build the sparkline string
                                                bool first = true;
                                                foreach (int count in sparklineCounts.Values)
                                                {
                                                    string value = string.Empty;
                                                    if (count > 0)
                                                    {
                                                        value = Convert.ToString(Math.Log10(count + 10));
                                                    }
                                                    else
                                                    {
                                                        value = "0";
                                                    }

                                                    if (first)
                                                    {
                                                        range.SparklineData = value;
                                                        first = false;
                                                    }
                                                    else
                                                    {
                                                        range.SparklineData += "," + value;
                                                    }
                                                }
                                            }
                                        }
                                    }

                                    result.Filters.Add(range);
                                }
                                break;

                            case "text":
                            default:
                                Facet facet = new Facet();
                                facet.Name = f.Key;
                                try
                                {
                                    facet.DisplayText = config.Facet;
                                }
                                catch (Exception)
                                {
                                }
                                foreach (var v in f.Value)
                                {
                                    if (v.Value > 0)
                                    {
                                        FacetValue value = new FacetValue()
                                        {
                                            Name = v.Key,
                                            Count = v.Value
                                        };
                                        facet.Values.Add(value);
                                    }
                                }

                                //hack to counter that fact that the count for 'true' is not returned with the boolean facet hasImages
                                if (f.Key.ToLower().Equals("hasimages"))
                                {
                                    var trueCountReturned = facet.Values.Where(v => v.Name == "true");
                                    if (!trueCountReturned.Any())
                                    {
                                        var falseCountReturned = facet.Values.Where(v => v.Name == "false");
                                        if (falseCountReturned.Any())
                                        {
                                            int falseCount = falseCountReturned.First().Count;
                                            int trueCount = result.TotalSpecimens - falseCount;
                                            facet.Values.Add(new FacetValue() { Name = "true", Count = trueCount });
                                        }
                                    }
                                }
                                if (facet.Values.Any())
                                {
                                    result.Filters.Add(facet);
                                }
                                break;
                        }
                    }
                }

                //process applied facets
                if (appliedFacets != null)
                {
                    result.AppliedFacets = appliedFacets;

                    if (result.AppliedFacets.Count > 0)
                    {
                        foreach (SelectedFacetValue facet in result.AppliedFacets)
                        {
                            facet.FacetLabel = FacetConfig.Where(c => c.SolrFieldName == facet.FacetName).First().Facet;

                            Filter filter = result.Filters.Where(f => f.Name == facet.FacetName).First();
                            if (object.ReferenceEquals(filter.GetType(), typeof(Systematics.Portal.Web.Model.Facet)))
                            {
                                Facet f = (Facet)filter;
                                FacetValue value = f.Values.Where(v => v.Name == facet.ValueName).First();
                                value.Selected = true;
                            }
                        }
                    }
                }

                //add in the applied ranges
                if (appliedRanges != null)
                {
                    result.AppliedRanges = appliedRanges;
                }

                return result;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public List<string> GetSpecimenIds(List<SelectedFacetValue> appliedFacets, List<SelectedRange> appliedRanges, string searchTerm, string collection, Dictionary<string, int> userAccessLevels)
        {
            try
            {
                var specimenIds = new List<string>();
                var queries = new List<ISolrQuery>();

                //filter query by access levels
                var securityFilter = new List<ISolrQuery>();
                foreach (var item in userAccessLevels)
                {
                    securityFilter.Add(new SolrQueryByField("collection", item.Key) && new SolrQueryByField("securityLevel", Convert.ToString(item.Value)));
                }
                queries.Add(new SolrMultipleCriteriaQuery(securityFilter, "OR"));

                //filter query by selected collection
                if (collection.ToLower() != "all")
                {
                    queries.Add(new SolrQueryByField("collection", collection));
                }

                //filter query by applied facets
                if (appliedFacets != null)
                {
                    foreach (SelectedFacetValue appliedFacet in appliedFacets)
                    {
                        queries.Add(new SolrQueryByField(appliedFacet.FacetName, appliedFacet.ValueName));
                    }
                }

                //filter query by applied ranges
                if (appliedRanges != null)
                {
                    foreach (SelectedRange appliedRange in appliedRanges)
                    {
                        queries.Add(new SolrQueryByRange<int>(appliedRange.FacetName, appliedRange.MinimumValue, appliedRange.MaximumValue));
                    }
                }

                var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Specimen>>();

                var queryOptions = new QueryOptions
                {
                    FilterQueries = queries,
                };

                ISolrQuery solrQuery = new SolrQuery(searchTerm);

                var extraParameters = new List<KeyValuePair<string, string>>();
                // As the "text" field is not declared as default parameter on solr,
                // we need that solrnet uses this field as default parameter
                extraParameters.Add(new KeyValuePair<string, string>("df", "text"));
                extraParameters.Add(new KeyValuePair<string, string>("q.op", "AND"));

                queryOptions.ExtraParams = extraParameters;

                var results = solr.Query(solrQuery, queryOptions);

                //get specimen ids
                foreach (Specimen term in results)
                {
                    specimenIds.Add(term.SpecimenId.ToLower());
                }

                return specimenIds;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<SpecimenSummary> FindSpecimens(List<Guid> specimenIds, Dictionary<string, int> userAccessLevels)
        {
            try
            {
                List<SpecimenSummary> specimens = new List<SpecimenSummary>();

                //filter query by access levels
                var securityFilter = new List<ISolrQuery>();
                foreach (var item in userAccessLevels)
                {
                    securityFilter.Add(new SolrQueryByField("collection", item.Key) && new SolrQueryByField("securityLevel", Convert.ToString(item.Value)));
                }

                //apply specimenIds as filter
                //foreach (var id in specimenIds) {
                //    specimenIdsFilter.Add(new SolrQueryByField("specimenId", id.ToString().ToUpper()));
                //}
                int index = 0;
                int total = specimenIds.Count();
                int iteration = 0;

                while ((iteration * 100) < total)
                {
                    var queries = new List<ISolrQuery>();
                    queries.Add(new SolrMultipleCriteriaQuery(securityFilter, "OR"));

                    var specimenIdsFilter = new List<ISolrQuery>();
                    for (int i = index; (i < ((iteration + 1) * 100)) && (i < total); i++)
                    {
                        specimenIdsFilter.Add(new SolrQueryByField("specimenId", specimenIds[i].ToString().ToUpper()));
                    }
                    queries.Add(new SolrMultipleCriteriaQuery(specimenIdsFilter, "OR"));

                    var solr = ServiceLocator.Current.GetInstance<ISolrOperations<Specimen>>();
                    var queryOptions = new QueryOptions
                    {
                        FilterQueries = queries,
                    };
                    ISolrQuery solrQuery = new SolrQuery("*:*");

                    var extraParameters = new List<KeyValuePair<string, string>>();
                    // As the "text" field is not declared as default parameter on solr,
                    // we need that solrnet uses this field as default parameter
                    extraParameters.Add(new KeyValuePair<string, string>("df", "text"));
                    extraParameters.Add(new KeyValuePair<string, string>("q.op", "AND"));

                    queryOptions.ExtraParams = extraParameters;

                    var results = solr.Query(solrQuery, queryOptions);

                    foreach (Specimen term in results)
                    {
                        SpecimenSummary summary = new SpecimenSummary()
                        {
                            SpecimenId = new Guid(term.SpecimenId),
                            Collection = term.Collection,
                            AccessionNumber = term.AccessionNumber,
                            TaxonName = term.TaxonomicName,
                            SubCollection = term.Subcollection,
                            Country = term.Country,
                            LandDistrict = term.LandDistrict,
                            EcologicalDistrict = term.EcologicalDistrict,
                            NZAreaCode = term.NZAreaCode,
                            Locality = term.Locality,
                            SpecimenType = term.KindOfSpecimen,
                            TypeStatus = term.TypeStatus,
                            HasImages = term.HasImages,
                            AccessionNumberSort = term.AccessionNumberSort,
                            TaxonNameSort = term.TaxonomicNameSort
                        };
                        specimens.Add(summary);
                    }

                    index += 100;
                    iteration += 1;
                }

                return specimens;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private DateTime ConvertIntToDate(int i)
        {
            try
            {
                int year = i / 10000;
                int month = Math.Min(12, (i - (year * 10000)) / 100);
                int day = i - (year * 10000) - (month * 100);
                if (month == 2)
                {
                    day = Math.Min(29, day);
                }
                else if (month == 4 || month == 6 || month == 9 || month == 11)
                {
                    day = Math.Min(30, day);
                }
                else
                {
                    day = Math.Min(31, day);
                }
                return new DateTime(year, Math.Max(1, month), Math.Max(1, day));

            }
            catch (Exception)
            {
                return DateTime.MinValue;
            }
        }

        private List<SortOrder> GetSortArray(string sortBy, string sortOrder)
        {
            var order = Order.ASC;
            if (sortOrder.Equals("descending"))
            {
                order = Order.DESC;
            }

            var orderBy = new List<SortOrder>();
            switch (sortBy)
            {
                case "accessionNumber":
                    orderBy.Add(new SortOrder("accessionNumberSort", order));
                    break;
                case "country":
                    orderBy.Add(new SortOrder("country_dr", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "collection":
                    orderBy.Add(new SortOrder("collection", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "ecologicalDistrict":
                    orderBy.Add(new SortOrder("ecologicalDistrict_dr", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "hasImages":
                    if (order == Order.ASC)
                    {
                        order = Order.DESC;
                    }
                    else
                    {
                        order = Order.ASC;
                    }
                    orderBy.Add(new SortOrder("hasImages", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "landDistrict":
                    orderBy.Add(new SortOrder("landDistrict_dr", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "locality":
                    orderBy.Add(new SortOrder("locality_dr", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "relevance":
                    orderBy.Add(new SortOrder("score", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "newZealandAreaCode":
                    orderBy.Add(new SortOrder("nzAreaCode_dr", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "taxonName":
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", order));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "typeStatus":
                    orderBy.Add(new SortOrder("typeStatus", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                case "specimenType":
                    orderBy.Add(new SortOrder("kindOfSpecimen", order));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
                default:
                    orderBy.Add(new SortOrder("score", Order.ASC));
                    orderBy.Add(new SortOrder("taxonomicNameSort_dr", Order.ASC));
                    orderBy.Add(new SortOrder("accessionNumberSort", Order.ASC));
                    break;
            }
            return orderBy;
        }

        private class SecureHttpWebRequestFactory : IHttpWebRequestFactory
        {
            private readonly string _username;
            private readonly string _password;

            public SecureHttpWebRequestFactory(string username, string password)
            {
                _username = username;
                _password = password;
            }

            public IHttpWebRequest Create(string url)
            {
                return Create(new Uri(url));
            }

            public IHttpWebRequest Create(Uri url)
            {
                var req = (HttpWebRequest)WebRequest.Create(url);
                var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(_username + ":" + _password));

                req.Headers.Add("Authorization", "Basic " + credentials);

                return new HttpWebRequestAdapter(req);
            }
        }
    }
}
