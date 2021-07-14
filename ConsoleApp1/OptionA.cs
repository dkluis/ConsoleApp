
namespace ConsoleApp
{
    class OptionA
    {
        public void Main2()
        {
            Display disp = new Display();
            disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, "Option A Execution from OptionA.cs");
            disp.GetInput(0, 1, "Hit Any Key: ");
        }
    }
}
