using System.Text.Json;
using Fleck;
using RegexMaster.TestCases;

namespace RegexMaster.Websocket.WebSocketMessageHandlers;

public abstract class WebSocketMessageHandler : Router
{
    protected IWebSocketConnection _connection;
    protected RoutesName routesName;
    protected JsonMessage jsonMessage;
    protected List<IMiddleware> _middlewares;

    public WebSocketMessageHandler(IWebSocketConnection connection) : base()
    {
        _middlewares = new List<IMiddleware>();
        setMiddleWares();
        setRoutes();
        this._connection = connection;
        connection.OnMessage = null;
        connection.OnMessage = OnMessage;
        connection.OnClose = OnClose;
        connection.OnOpen = OnOpen;
    }

    protected virtual void OnMessage(string message)
    {
        
        jsonMessage = JsonSerializer.Deserialize<JsonMessage>(message);
        var isRegisteredMessageType = Enum.TryParse(jsonMessage.MessageType, out routesName);
        if (!isRegisteredMessageType)
        {
            Console.WriteLine("unable to parse enum string");
            return;
        }

        var res = routes.TryGetValue(routesName, out var fn);
        if (res)
        {
            fn(this, jsonMessage);
        }
        else
        {
            Console.WriteLine("Could not find matching route for " + message);
        }
    }

    protected virtual void OnClose()
    {
        Console.WriteLine("User disconnected " + _connection.ConnectionInfo);
    }

    protected virtual void OnOpen()
    {
    }

    protected abstract void setMiddleWares();
}