using System.Text.Json;
using Fleck;
using RegexMaster.Websocket.WebSocketMessageHandlers;

namespace RegexMaster.Websocket;

public class WebSocketConnectionHandler : WebSocketMessageHandler
{
    private WebSocketMessageHandler _messageHandler;

    public WebSocketConnectionHandler(IWebSocketConnection connection) : base(connection)
    {
    }

  

    protected override void OnMessage(string message)
    {
        //findout 
        Console.WriteLine(message);
        var identifierMessage = JsonSerializer.Deserialize<IdentifierMessage>(message);
        switch (identifierMessage.ConnectionReason)
        {
            case "Test" :
                Console.WriteLine("it was a test websocket connection");
                _messageHandler = new TestMessageHandler(_connection);
                break;
        }
    }

    public virtual void OnClose()
    {
        Console.WriteLine("connection lost " + _connection.ConnectionInfo);
    }

    protected override void OnOpen()
    {
        Console.WriteLine("someone new connected");
    }

    protected override void setMiddleWares()
    {
        
    }


    protected override void setRoutes()
    {
        
    }
}