namespace Big.Nutresa.Imagix.UI.Common.Helpers
{
    using Big.Nutresa.Imagix.UI.Common.Response;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Reflection;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Linq;

    public class Utility
    {
        public static object InvokeMethod(string typeName, string methodName, object[] objectParam)
        {
            // Get the Type for the class
            var objInstance = Activator.CreateInstance(Type.GetType(typeName));
            Type calledType = objInstance.GetType();

            // Invoke the method itself. 
            MethodInfo method = calledType.GetMethod(methodName);
            return method.Invoke(objInstance, objectParam);
        }
    }

    public class CastObjects
    {
        public static List<T> ConvertItemValueList<T>(itemValueItem[] itemValueItems)
        {
            List<T> objList = Activator.CreateInstance<List<T>>();

            foreach (itemValueItem item in itemValueItems)
            {
                T obj = Activator.CreateInstance<T>();
                obj = ConvertItemValueItemItem<T>(item.value);
                objList.Add(obj);
            }

            return objList;
        }

        public static T ConvertItemValueItemItem<T>(itemValueItemItem[] itemValueItemItems)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (PropertyInfo pro in temp.GetProperties())
            {
                itemValueItemItem item = itemValueItemItems.FirstOrDefault(x => x.key == pro.Name);
                if (item == null)
                {
                    continue;
                }

                try
                {
                    // Convert the value to match the property type
                    object value = Convert.ChangeType(item.value, pro.PropertyType);
                    // Set the value of the property
                    pro.SetValue(obj, value, null);
                }
                catch (Exception ex)
                {
                    if (ex is FormatException || ex is InvalidCastException)
                        pro.SetValue(obj, null, null);
                }

            }

            return obj;
        }
    }

    public class SerializerXML
    {
        public static T Deserialize<T>(string input) where T : class
        {
            System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(T));

            using (StringReader sr = new StringReader(input))
            {
                return (T)ser.Deserialize(sr);
            }
        }

        public static string Serialize<T>(T ObjectToSerialize)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());

            using (StringWriter textWriter = new StringWriter())
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = false;
                settings.OmitXmlDeclaration = true;

                using (XmlWriter writer = XmlWriter.Create(textWriter, settings))
                {
                    xmlSerializer.Serialize(writer, ObjectToSerialize);
                    return textWriter.ToString();

                }
            }

            //using (StringWriter textWriter = new StringWriter())
            //{
            //    xmlSerializer.Serialize(textWriter, ObjectToSerialize);
            //    return textWriter.ToString();
            //}
        }

        public static XmlDocument GetXMLFile(string path)
        {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(path);
            return xmlDocument;
        }

    }
}
