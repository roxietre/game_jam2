/*
    .___                         .__        __   
  __| _/_______  ________   ____ |__| _____/  |_ 
 / __ |/ __ \  \/ /\____ \ /  _ \|  |/    \   __\
/ /_/ \  ___/\   / |  |_> >  <_> )  |   |  \  |  
\____ |\___  >\_/  |   __/ \____/|__|___|  /__|  
     \/    \/      |__|                  \/     
developed by: robin auxietre
all function for create a collum in dataverse for itch tab
*/

namespace dataverse_lib
{
    public class Programe
    {

        /// <summary>
        /// create a collum in the tabe_name that is type of multi_picklist
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void  create_multi_pick_list(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of memo
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_memo(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createBankNameAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tab_name,
                Attribute = new MemoAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    MaxLength = collum_Length,
                    FormatName = StringFormatName.Text,
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of string
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_string(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createBankNameAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tab_name,
                Attribute = new StringAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    MaxLength = collum_Length,
                    FormatName = StringFormatName.Text,
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };

            _serviceProxy.Execute(createBankNameAttributeRequest);
        }
        
        /// <summary>
        /// create a collum in the tabe_name that is type of boolean
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_boolean(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createBankNameAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tab_name,
                Attribute = new BooleanAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of date
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_date(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createCheckedDateRequest = new CreateAttributeRequest
            {
                EntityName = _customEntityName,
                Attribute = new DateTimeAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    Format = DateTimeFormat.DateOnly,
                    DisplayName = new Label("Date", 1033),
                    Description = new Label(collum_description, 1033)
                }
            };

            _serviceProxy.Execute(createCheckedDateRequest);
        }
        
        /// <summary>
        /// create a collum in the tabe_name that is type of double
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_double(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createCheckedDateRequest = new CreateAttributeRequest
            {
                EntityName = _customEntityName,
                Attribute = new DoubleAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };

            _serviceProxy.Execute(createCheckedDateRequest);
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of int
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_int(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createCheckedDateRequest = new CreateAttributeRequest
            {
                EntityName = _customEntityName,
                Attribute = new IntegerAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };

            _serviceProxy.Execute(createCheckedDateRequest);
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of money
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the PrecisionSource of the new collum (max size int)</param>
        /// </summary>
        public void create_money(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createBalanceAttributeRequest = new CreateAttributeRequest
            {
                EntityName = tab_name,
                Attribute = new MoneyAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    PrecisionSource = collum_Length,
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033),

                }
            };

            _serviceProxy.Execute(createBalanceAttributeRequest);
        }
    
        /// <summary>
        /// create a collum in the tabe_name that is type of Image
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_image(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createCheckedDateRequest = new CreateAttributeRequest
            {
                EntityName = _customEntityName,
                Attribute = new ImageAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };

            _serviceProxy.Execute(createCheckedDateRequest);
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of lookup
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>        
        public void create_lookup(string tab_name, string collum_name, string collum_description, int collum_Length)
        {

        }
        
        /// <summary>
        /// create a collum in the tabe_name that is type of status
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_status(string tab_name, string collum_name, string collum_description, int collum_Length)
        {
            CreateAttributeRequest createCheckedDateRequest = new CreateAttributeRequest
            {
                EntityName = _customEntityName,
                Attribute = new StatusAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033)
                }
            };

            _serviceProxy.Execute(createCheckedDateRequest);
        }

        /// <summary>
        /// create a collum in the tabe_name that is type of picklist
        /// <param name="tab_name">the name of the tabe where you want to create your collum(need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name='collum_name'>the name of the new collum (need a string type all space need to be '_' and not more than 1033 char)</param>
        /// <param name="collum_description">the description of the new collum (the given string will not be change and add directly as description and max char 1033)</param>
        /// <param name="collum_Length">the length of the new collum (max size int)</param>
        /// </summary>
        public void create_picklist(string tab_name, string collum_name, string collum_description, int collum_Length, var choice_name)
        {
            foreach (var item in choice_name)
            {
                choice.Add(new OptionMetadata(new Label(item, 1033), 1));
            }
            CreateAttributeRequest createCheckedDateRequest = new CreateAttributeRequest
            {
                EntityName = _customEntityName,
                Attribute = new PicklistAttributeMetadata
                {
                    SchemaName = collum_name,
                    RequiredLevel = new AttributeRequiredLevelManagedProperty(AttributeRequiredLevel.None),
                    DisplayName = new Label(collum_name.Replace('_', ' '), 1033),
                    Description = new Label(collum_description, 1033),
                    OptionSet = new OptionSetMetadata
                    {
                        IsGlobal = false,
                        OptionSetType = OptionSetType.Picklist,
                        Options = choice
                    }
                }
            };
             _serviceProxy.Execute(createCheckedDateRequest);
        }
    }
}