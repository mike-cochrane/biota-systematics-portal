using System;
using System.Net.Mail;

namespace SystematicsPortal.Web.Helpers
{
    public class Utility
    {
        public const int PUBLIC_ACCESS_LEVEL = 40;

        public const string UNKNOWN_FIELD_NAME_ERROR_MESSAGE = "Unknown field name";

        public const string DEFAULT_WEBSITE_ADDRESS = null;

        /*private static ISearchRepository _searchRepository;
        private static ISectionContentsRepository _sectionContentsRepository;*/

        /* private static ISearchRepository SearchRepository
         {
             get
             {
                 if (_searchRepository == null)
                 {
                     var solrConnectionString = ConfigurationManager.AppSettings["SolrServer"];
                     var solrUserName = ConfigurationManager.AppSettings["SolrUserName"];
                     var solrPassword = ConfigurationManager.AppSettings["SolrPassword"];

                     _searchRepository = new Data.Solr.Repositories.SearchRepository(solrConnectionString, solrUserName, solrPassword);
                 }
                 return _searchRepository;
             }
         }*/

        /*private static ISectionContentsRepository SectionContentsRepository
        {
            get
            {
                if (_sectionContentsRepository == null)
                {
                    _sectionContentsRepository = new Data.Sql.Repositories.SectionContentsRepository();
                }
                return _sectionContentsRepository;
            }
        }*/

        public static string CleanInput(string text)
        {
            if (text == null)
            {
                return null;
            }

            if (!text.Equals(string.Empty))
            {
                int index = 0;

                while (text.ToLower().Contains("update"))
                {
                    index = text.ToLower().IndexOf("update");
                    text = text.Remove(index, 6);
                }

                while (text.ToLower().Contains("select"))
                {
                    index = text.ToLower().IndexOf("select");
                    text = text.Remove(index, 6);
                }

                while (text.ToLower().Contains("insert"))
                {
                    index = text.ToLower().IndexOf("insert");
                    text = text.Remove(index, 6);
                }

                while (text.ToLower().Contains("drop"))
                {
                    index = text.ToLower().IndexOf("drop");
                    text = text.Remove(index, 4);
                }

                while (text.ToLower().Contains("delete"))
                {
                    index = text.ToLower().IndexOf("delete");
                    text = text.Remove(index, 6);
                }

                while (text.ToLower().Contains("xp_"))
                {
                    index = text.ToLower().IndexOf("xp_");
                    text = text.Remove(index, 3);
                }

                text = text.Replace("--", "");
            }
            return text.Trim();
        }

        public static string ReplaceEscapedCharacters(string text)
        {
            text = text.Replace("&quot;", "\"");
            text = text.Replace("%5c-", "-");
            text = text.Replace("&#215;", "×");

            return text;
        }

        /*public static SetViewModel Map(Set set, bool includeSpecimenSummaries, Dictionary<string, int> userAccessLevels)
        {
            SetViewModel setModel = new SetViewModel()
            {
                SetId = set.SetId,
                OwnerId = set.OwnerId,
                DisplayName = set.DisplayName,
                Description = set.Description,
                CreatedDate = set.CreatedDate,
                UpdatedDate = set.UpdatedDate,
                IsNew = false
            };

            if (includeSpecimenSummaries)
            {
                if (set.Specimens.Count > 0)
                {
                    List<Guid> specimenIds = new List<Guid>();
                    foreach (SetSpecimen specimen in set.Specimens)
                    {
                        specimenIds.Add(specimen.SpecimenGuid);
                    }

                    List<SpecimenSummary> summaries = SearchRepository.FindSpecimens(specimenIds, userAccessLevels);
                    foreach (SetSpecimen s in set.Specimens)
                    {
                        bool found = false;
                        foreach (SpecimenSummary summary in summaries)
                        {
                            if (summary.SpecimenId == s.SpecimenGuid)
                            {
                                s.SpecimenSummary = summary;
                                found = true;
                                break;
                            }
                        }
                        if (found)
                        {
                            setModel.Specimens.Add(s);
                        }
                    }
                }
            }

            return setModel;
        }*/

        public static bool SendEmail(string toAddress, string subject, string content, string fromAddress = DEFAULT_WEBSITE_ADDRESS)
        {
            try
            {
                if (fromAddress == null)
                {
                    // TODO: Get configuration using DI
                    //fromAddress = ConfigurationManager.AppSettings["SenderAddress"].ToString();
                }

                // TODO: Get configuration using DI
                //string SMTPServer = ConfigurationManager.AppSettings["SMTPServer"].ToString();
                //var SMTPServer = string.Empty;
                var SMTPServer = "smtp.landcareresearch.co.nz"; // TODO testing this if it works...
                SmtpClient client = new SmtpClient(SMTPServer);

                MailAddress sender = new MailAddress(fromAddress);
                MailAddress recipient = new MailAddress(toAddress);

                MailMessage message = new MailMessage(sender, recipient)
                {
                    Subject = subject,
                    Body = content,
                    IsBodyHtml = true
                };
                client.Send(message);

                return true;
            }
            catch (Exception e)
            {
                //TODO - log this error somewhere
                throw e;
            }
        }

        /*public static string GetImportantNotice()
        {
            string notice = string.Empty;
            try
            {
                SectionContent content = SectionContentsRepository.GetCurrent("Home", "GeneralAlert");
                notice = content.Content;
            }
            catch (Exception)
            {
            }
            return notice;
        }*/
    }
}
