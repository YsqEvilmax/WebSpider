using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace TechHome.Cores
{
    public class XmlSerializer<T>
        where T: class, new()
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));

        public string Serialize(T obj)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (StreamWriter sw = new StreamWriter(ms))
                {
                    _serializer.Serialize(sw, obj);
                    return sw.ToString();
                }
            }
        }

        public T Deserialize(string content)
        {
            using (StringReader sr = new StringReader(content))
            {
                return _serializer.Deserialize(sr) as T;
            }
        }
    }
}
