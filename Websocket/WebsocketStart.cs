using Fleck;

namespace RegexMaster.Websocket;

public class WebsocketStart
{
    private IWebSocketConnection _webSocketConnection;

    public static List<WebSocketConnectionHandler> WebsocketStarts = new List<WebSocketConnectionHandler>();

    public static void Start(IWebSocketConnection connection)
    {
        WebsocketStarts.Add(new WebSocketConnectionHandler(connection));
    }

   
}