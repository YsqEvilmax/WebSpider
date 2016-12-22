using System.IO;
using System.Xml.Serialization;

namespace TechHome.Services.Pages
{
    public class XmlSerializer<T>
        where T: class, new()
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof(T));
        public void Serialize(T obj, string fileName)
        {
            using(FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                using(StreamWriter sw = new StreamWriter(fs))
                {
                    _serializer.Serialize(sw, obj);
                }
            }
        }

        public T Deserialize(string fileName)
        {
            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                using (StreamReader sw = new StreamReader(fs))
                {
                    return _serializer.Deserialize(sw) as T;
                }
            }
        }
    }
}
