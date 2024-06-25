using RegexMaster.TestCases;
using RegexMaster.Websocket.WebSocketMessageHandlers;
using RegexMaster.TestCases;
namespace RegexMaster.Websocket.Routes;

public class StartTestRoute : IRoute
{
    
    public void HandleMessage(WebSocketMessageHandler webSocketMessageHandler, JsonMessage jsonMessage)
    {
        if (!(webSocketMessageHandler is ITestFunc))
        {
            throw new InvalidCastException("Expected to implement ITestFunc");
        }
        
        var itestFunc = webSocketMessageHandler as ITestFunc;
        var wasSuc = true;
        itestFunc.OnTestRes(new TestResult(true));
    }
}