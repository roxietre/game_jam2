/*
    .___                         .__        __   
  __| _/_______  ________   ____ |__| _____/  |_ 
 / __ |/ __ \  \/ /\____ \ /  _ \|  |/    \   __\
/ /_/ \  ___/\   / |  |_> >  <_> )  |   |  \  |  
\____ |\___  >\_/  |   __/ \____/|__|___|  /__|  
     \/    \/      |__|                  \/     
developed by: robin auxietre
all function for grab the data from the database
*/

using System;
using System.Collections.Generic;
using Microsoft.Xrm.Tooling.Connector;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Metadata.Query;
using Microsoft.Xrm.Sdk.Query;

namespace dataverse_lib
{
    public class Program
    {
        private readonly IOrganizationService ServiceObject;
        Dictionary<string, string> all_type = new Dictionary<string, string>();  
        public Program(IOrganizationService MyService)
        {
            try
            {
                this.ServiceObject = MyService;
                //new CrmServiceClient(new Uri(this.StrMyUrl), this.StrMyClientID, this.StrMyClientSecret, this.IsMySingleInstance, this.StrMyTokenCachePath);
               
                }
            catch(Exception ex)
            {
                    throw new Exception(ex.Message);
            }
        }

        public void all_format()
        {
            try {
                this.all_type.Add("multi_pick_lsit", "MultiSelectPicklistAttributeMetadata");
                this.all_type.Add("memo", "MemoAttributeMetadata");
                this.all_type.Add("string", "StringAttributeMetadata");
                this.all_type.Add("bool", "BooleanAttributeMetadata");
                this.all_type.Add("date", "DateTimeAttributeMetadata");
                this.all_type.Add("float", "DecimalAttributeMetadata");
                this.all_type.Add("double", "DoubleAttributeMetadata");
                this.all_type.Add("int", "IntegerAttributeMetadata");
                this.all_type.Add("bigint", "BigIntAttributeMetadata");
                this.all_type.Add("money", "MoneyAttributeMetadata");
                this.all_type.Add("png", "ImageAttributeMetadata");
                this.all_type.Add("lookup", "LookupAttributeMetadata");
                this.all_type.Add("status", "StatusAttributeMetadata");
                this.all_type.Add("picklist", "PicklistAttributeMetadata");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Associates one Entity to another Entity
        /// <param name="RelationShipName"> name of the new Relationship</param>
        /// <param name="tabelMany"></param>
        /// </summary>
        public void QueryRelate(string RelationShipName, string tableMany, List<Guid> listToRelate, string tableOne,Guid oneToBeRelated)
        {


            EntityReferenceCollection relatedEntities = new EntityReferenceCollection();
            foreach (Guid OneGuid in listToRelate)
            {
                relatedEntities.Add(new EntityReference(tableMany, OneGuid));
            }
            // Create an object that defines the relationship between the contact and account.
            Relationship relationship = new Relationship(RelationShipName);
            //Associate the contact with the 3 accounts
        
            this.ServiceObject.Associate(tableOne, oneToBeRelated, relationship, relatedEntities);
        }

        /// <summary>
        /// laod the table from the database
        /// <param name="service"> the service where your are connected and you want all tab</param>
        /// </summary>
        public static EntityMetadataCollection LoadEntities(IOrganizationService service)
        {
            var entityQueryExpression = new EntityQueryExpression
            {
                Properties = new MetadataPropertiesExpression("LogicalName", "DisplayName", "Attributes", "IsAuditEnabled", "ObjectTypeCode"),
                AttributeQuery = new AttributeQueryExpression
                {
                    Criteria = new MetadataFilterExpression
                    {
                        Conditions =
                        {
                            new MetadataConditionExpression("LogicalName", MetadataConditionOperator.NotIn, new[]{"traversedpath","versionnumber"})
                        }
                    },
                    Properties = new MetadataPropertiesExpression("DisplayName", "LogicalName", "AttributeType", "IsAuditEnabled", "AttributeOf", "EntityLogicalName"),
                }
            };
            var retrieveMetadataChangesRequest = new RetrieveMetadataChangesRequest
            {
                Query = entityQueryExpression,
                ClientVersionStamp = null
            };

            return ((RetrieveMetadataChangesResponse)service.Execute(retrieveMetadataChangesRequest)).EntityMetadata;
        }

        /// <summary>
        /// load the entity from the database with the tab_name
        /// <param name="tab_name"> the name of the tab you want the entity</param>
        /// </summary>
        public EntityCollection my_query(string tab_name)
        {
            try {
                var query = new QueryExpression(tab_name);
                query.ColumnSet = new ColumnSet(true);
                var result = this.ServiceObject.RetrieveMultiple(query);
                return result;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        ///load tha collum from a tab
        /// <param name="tab_name"> the name of the tab you want the collum</param>
        /// </summary>
        public List<string> my_query_collum(string tab_name)
        {
            try {
                var query = new QueryExpression(tab_name);
                query.ColumnSet = new ColumnSet(true);
                var result = this.ServiceObject.RetrieveMultiple(query);
                var list = new List<string>();
                foreach (var item in result.Entities[0].Attributes)
                {
                    list.Add(item.ToString());
                }
                return list;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        /// <summary>
        /// create a entity in the tabe_name
        /// </summary>

        public void create_a_entity(string tab_name)
        {
            try {
                var entity = new Entity(tab_name);
                this.ServiceObject.Create(entity);
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// create a tabe in the database
        /// <param name="tab">the name of the new tabe (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='tab_description'>the description of the new tabe (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name='tab_name_display'>the display name of the new tabe (the given string will not be change and add directly as name and max char 1033)</param>
        /// <param name="prima_collum">the name of Primary collum to create (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="prima_collum_description">the description of the Primary collum to create (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="prima_collum_Length">the length of the Primary collum to create (max size int)</param>
        /// </summary>

        public void Create_tab(string tab, string tab_name_display ,string tab_description, string prima_collum, string prima_collum_description, int prima_collum_Length)
        {
            try {
                CreateEntityRequest createrequest = new CreateEntityRequest
                {
                    Entity = new EntityMetadata
                    {
                        SchemaName = tab,
                        DisplayName = new Label(tab_name_display, 1033),
                        DisplayCollectionName = new Label(tab_name_display, 1033),
                        Description = new Label(tab_description, 1033),
                        OwnershipType = OwnershipTypes.UserOwned,
                        IsActivity = false,

                },
                    PrimaryAttribute = new StringAttributeMetadata
                    {
                        SchemaName = prima_collum,
                        RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                        MaxLength = prima_collum_Length,
                        FormatName = StringFormatName.Text,
                        DisplayName = new Label(prima_collum.Replace('_', ' '), 1033),
                        Description = new Label(prima_collum_description, 1033)
                    }
                };
                    this.ServiceObject.Execute(createrequest);
                }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
        
        /// <summary>
        /// create a collum in the tabe_name
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_format">the format of the new collum (int/string/date/etc go check Dictionary<string, string> this.all_type for wat type is possibel)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>

        public void Create_collum(string tab_name, string collum_name, string collum_format, string collum_description, int collum_Length)
        {
            all_format();
            this.GetType().GetMethod(this.all_type[collum_format]).Invoke(this, new object[] { tab_name, collum_name, collum_description, collum_Length });
        }

        /// <summary>
        /// get all the relation of a tabe
        /// </summary>
        
        public void Get_all_relation(string tab_name)
        {
            try {
                var query = new QueryExpression(tab_name);
                query.ColumnSet = new ColumnSet(true);
                var result = this.ServiceObject.RetrieveMultiple(query);

                foreach (var item in result.Entities)
                {
                    if (item.Attributes.Contains("OneToManyRelationshipMetadata") == true)
                    {
                        var OneToManyRelationshipMetadata = item.Attributes["OneToManyRelationshipMetadata"] as OneToManyRelationshipMetadata;
                        Console.WriteLine(OneToManyRelationshipMetadata.ReferencedEntity);
                    } if (item.Attributes.Contains("ManyToManyRelationshipMetadata") == true)
                    {
                        var ManyToManyRelationshipMetadata = item.Attributes["ManyToManyRelationshipMetadata"] as ManyToManyRelationshipMetadata;
                        Console.WriteLine(ManyToManyRelationshipMetadata.Entity1LogicalName);
                    }
                    else
                    {
                        Console.WriteLine("no relation");
                    }
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
        }
    }
}


// to do list:
// get collum from a tab
//Create_a_entity()  data from entity dynamic
//create_table_in_database() to implement all type of collum (multi choice/ look up) and check if they all work.
//grab_relation() to grab the relation between two table and check wat you need to return.