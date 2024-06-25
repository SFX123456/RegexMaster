namespace RegexMaster.Websocket;

public class JsonMessage
{
    public string MessageType { get; set; }
    public Dictionary<string,string> Data { get; set; }
}