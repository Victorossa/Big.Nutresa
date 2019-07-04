namespace Big.Nutresa.Imagix.Business.Providers
{
    using Big.Nutresa.Imagix.DataAccess.DAL;
    using Big.Nutresa.Imagix.UI.Common.Models;
    using Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;
    using System.Xml.Serialization;

    public class DefaultContentProvider : IContent
    {
        private XmlDocument contentSettings;

        private int ProgramId;
        public DefaultContentProvider()
        {

        }
        
        private void LoadSettings()
        {
            this.contentSettings = ContentDAL.GetContentConfiguration(ProgramId);
        }

        
        public ContentProviderSettingModel GetContent(string Idiom,string node,int ProgramId)
        {
            this.ProgramId = ProgramId;
            LoadSettings();
            XmlElement root = contentSettings.DocumentElement;

            var initialNode = root.SelectSingleNode(Idiom).SelectSingleNode(node);

            

            string classView = initialNode.Attributes["ClassView"].Value;
            string className = initialNode.Attributes["ClassName"].Value;

            var nodesView = initialNode.SelectSingleNode("View").ChildNodes;            
            var nodes = initialNode.SelectSingleNode("Content").ChildNodes;

            List<dynamic> result = new List<dynamic>();

            ContentProviderSettingModel contentProviderSettingModel = new ContentProviderSettingModel();
            contentProviderSettingModel.Content = new List<dynamic>();

            foreach (XmlNode item in nodesView)
            {

                Type type = Type.GetType(classView);

               
                XmlSerializer xmlSerializable = new XmlSerializer(type);

                using (var reader =  new XmlNodeReader(item))
                {
                    var deserializedNode = xmlSerializable.Deserialize(reader);
                    contentProviderSettingModel.StandarContent= ((StandarContent)deserializedNode);
                }

            }
            foreach (XmlNode item in nodes)
            {
                Type type = Type.GetType(className);
                XmlSerializer serializer = new XmlSerializer(type);


                using (var reader = new XmlNodeReader(item))
                {
                    var deserializedNode = serializer.Deserialize(reader);

                    contentProviderSettingModel.Content.Add(deserializedNode);
                }

            }

            return contentProviderSettingModel;
        }

      
    }


}
