using System.Text.Json;
using Fleck;
using RegexMaster.TestCases;
using RegexMaster.Websocket.Routes;

namespace RegexMaster.Websocket.WebSocketMessageHandlers;

public class TestMessageHandler : WebSocketMessageHandler, ITestFunc
{
    public TestMessageHandler(IWebSocketConnection connection) : base(connection)
    {
    }

    protected override void OnMessage(string message)
    {
        base.OnMessage(message);
        Console.WriteLine("ONMessage testmessagehandler"); 
    }

    protected override void setMiddleWares()
    {
        
    }


    protected override void setRoutes()
    {
        routes.Add(RoutesName.StartTest,new StartTestRoute().HandleMessage);
    }

    public void OnTestRes(TestResult testResult)
    {
        _connection.Send("test was successful");
    }
}