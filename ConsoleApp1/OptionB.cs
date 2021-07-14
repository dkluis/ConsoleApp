
namespace ConsoleApp
{
    class OptionB
    {
        public void Main3()
        {
            Display disp = new Display();
            disp.DisplayText(disp.xleftStatusMsg, disp.yStatus, "Option B Execution from OptionB.cs");
            disp.GetInput(0, 0, "Hit Any Other Key: ");
        }
    }
}