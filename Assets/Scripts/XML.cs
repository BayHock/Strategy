using System.IO;
using System.Xml.Serialization;

[System.Serializable]
public class XML
{
    public static void Serialization(object item, string path)
    {
        XmlSerializer serializer = new(item.GetType());
        StreamWriter writer = new(path);
        serializer.Serialize(writer.BaseStream, item);
        writer.Close();
    }
    public static T Deserialize<T>(string path)
    {
        XmlSerializer serializer = new(typeof(T));
        StreamReader reader = new(path);
        T deserialized = (T)serializer.Deserialize(reader.BaseStream);
        reader.Close();
        return deserialized;
    }
}
