using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using SystematicsPortal.Model.Models.Documents;

namespace SystematicsPortal.Data.Uploader
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=DEV-SQL-02;MultipleActiveResultSets=true;Initial Catalog=Names_Web;Integrated Security=True;MultipleActiveResultSets=True";
            XmlSerializer serializer = new XmlSerializer(typeof(Documents));

            Documents dezerializedList;

            using (FileStream stream = File.OpenRead("D:\\development\\biota-systematics-portal\\SystematicsPortal.Data\\ExemplarData\\20200619-Document-Names-NZAC.xml"))
            {
                dezerializedList = (Documents)serializer.Deserialize(stream);
            }

            DocumentsRepository repository = new DocumentsRepository(new NamesWebContext(connectionString));

            repository.WriteDocuments(dezerializedList.Document);

            Console.ReadLine();
        }
    }
}
