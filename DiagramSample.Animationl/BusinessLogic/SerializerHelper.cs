using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace BusinessLogic
{
     public static class SerializerHelper
    {
        public static string SerializeObj<T>(T obj) where T : class
        {
            //GC.Collect();
            var s = new XmlSerializer(typeof(T));
            var stringWriter = new StringWriter();
            s.Serialize(stringWriter, obj);

            return stringWriter.ToString();
        }

        public static T DeserializeXml<T>(string xml) where T : class
        {
            //GC.Collect();
            if (xml == null)
                return null;
            var s = new XmlSerializer(typeof(T));
            var stringReader = new StringReader(xml);
            return (T)s.Deserialize(stringReader);
        }

        public static void SerializeObject<T>(T serializableObject, string fileName) where T : class
        {
            if (serializableObject == null) { return; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, serializableObject);
                stream.Position = 0;
                xmlDocument.Load(stream);
                xmlDocument.Save(fileName);
                stream.Close();
            }
        }

        public static XmlDocument SerializeObject<T>(T serializableObject) where T : class
        {
            if (serializableObject == null) { return null; }

            XmlDocument xmlDocument = new XmlDocument();
            XmlSerializer serializer = new XmlSerializer(serializableObject.GetType());
            using (MemoryStream stream = new MemoryStream())
            {
                serializer.Serialize(stream, serializableObject);
                stream.Position = 0;
                xmlDocument.Load(stream);
                stream.Close();
                return xmlDocument;
            }
        }

        public static T DeSerializeObject<T>(string fileName) where T : class
        {

            if (string.IsNullOrEmpty(fileName))
            {
                return default(T);
            }

            T objectOut = default(T);


            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(fileName);
            string xmlString = xmlDocument.OuterXml;

            using (StringReader read = new StringReader(xmlString))
            {
                Type outType = typeof(T);

                XmlSerializer serializer = new XmlSerializer(outType);
                using (XmlReader reader = new XmlTextReader(read))
                {
                    objectOut = (T)serializer.Deserialize(reader);
                    reader.Close();
                }

                read.Close();
            }

            return objectOut;
        }

    }
}
