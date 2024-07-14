using System.Xml.Serialization;

[XmlRoot("dialogue")]
public class Dialogue
{
    [XmlElement("node")]
    public Node[] nodes;
}

[System.Serializable]
public class Node
{
    [XmlAttribute("mainText")]
    public string mainText;

    [XmlArray("answers")]
    [XmlArrayItem("answer")]
    public Answer[] answers;
}

[System.Serializable]
public class Answer
{
    [XmlAttribute("text")]
    public string textAnswer;
    [XmlAttribute("money")]
    public string moneyGame;
    [XmlAttribute("food")]
    public string foodGame;
    [XmlAttribute("army")]
    public string armyGame;
    [XmlAttribute("happiness")]
    public string happinessGame;
    [XmlAttribute("religion")]
    public string religionGame;
    [XmlAttribute("order")]
    public string orderGame;
    [XmlAttribute("toNode")]
    public int nextNode;
    [XmlAttribute("dialend")]
    public bool end;
}