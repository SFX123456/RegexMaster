

using TestResult = RegexMaster.TestCases.TestResult;

namespace RegexMaster.Websocket;

public interface ITestFunc
{
   void OnTestRes(TestResult testResult);
}