using RegexMaster.Websocket.WebSocketMessageHandlers;

namespace RegexMaster.Websocket;

public abstract class Router
{
    public delegate void Route(WebSocketMessageHandler webSocketMessageHandler, JsonMessage message);

    protected Dictionary<RoutesName, Route> routes;
    protected Router()
    {
        routes = new Dictionary<RoutesName, Route>();
    }

    protected abstract void setRoutes();
}