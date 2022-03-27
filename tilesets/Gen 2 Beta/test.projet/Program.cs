/*
    .___                         .__        __   
  __| _/_______  ________   ____ |__| _____/  |_ 
 / __ |/ __ \  \/ /\____ \ /  _ \|  |/    \   __\
/ /_/ \  ___/\   / |  |_> >  <_> )  |   |  \  |  
\____ |\___  >\_/  |   __/ \____/|__|___|  /__|  
     \/    \/      |__|                  \/     
developed by: robin auxietre
main program
*/

using Microsoft.PowerPlatform.Formulas.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Net;
using System.Transactions;
using System.IO;
using Microsoft.Xrm.Tooling.Connector;
using System.Configuration;
using Microsoft.Xrm.Sdk.Metadata;


namespace testprojet
{
    public struct DataverseClient
    {
        public string _dataverseUrl;
        public string _dataverseUser;
        public string _dataversePassword;

        public DataverseClient(string dataverseUrl, string dataverseUser, string dataversePassword)
        {
            _dataverseUrl = dataverseUrl;
            _dataverseUser = dataverseUser;
            _dataversePassword = dataversePassword;
        }
    }
    public class Program
    {
        private List<EntityMetadata> emds;

        public static void Main(string[] args)
        {
            DataverseClient dataverse = new DataverseClient(ConfigurationManager.AppSettings["EnvUrl"], ConfigurationManager.AppSettings["ClientId"], ConfigurationManager.AppSettings["ClientSecret"]);
            var service = new CrmServiceClient(new Uri(dataverse._dataverseUrl), dataverse._dataverseUser, dataverse._dataversePassword, true, String.Empty);
            Console.WriteLine("him connect");
            
            //get all datasets from dataverse
            string[] datasets = new string[0];

            //get all data + name of tab     
            var tab = queery_help.Program.LoadEntities(service);
       
            //test creat a tab
            var Name = Console.ReadLine();
            queery_help.Program.Create_entity_in_tab(service, Name);
            //queery_help.Program.Create_my_collum(service, Name, "rob_test18", "int");
            
            //test creat a relation between tab
            //queery_help.Program.Create_my_relation(service,"team", "account");

            //get all collum of tab
            var t2 = queery_help.Program.LoadEntities(service);
            var test = queery_help.Program.my_query(service, Name);

            if (test != null)
            {
                Console.WriteLine(test.EntityName);
                Console.WriteLine(test.Entities.Count);
            }
            return;
        }
    }   
}