using RegexMaster.Websocket.WebSocketMessageHandlers;

namespace RegexMaster.Websocket.Routes;

public interface IRoute
{
    void HandleMessage(WebSocketMessageHandler webSocketMessageHandler, JsonMessage jsonMessage);
}