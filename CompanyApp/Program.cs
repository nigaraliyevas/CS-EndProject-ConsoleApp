using CompanyApp.Helper;
Helpers.ChangeTextColorAndAlignCenter(ConsoleColor.Green, "~~WELCOME TO COMPANY APP~~");
Helpers.ChangeTextColorAndAlignCenter(ConsoleColor.Yellow, "-_-_-_-_-_-_-_-_-_-_--_-_-_-_-_-_-_-_-_-_-\n");
#region loading-bar
Console.Write("                                               Loading");
Helpers.WriteProgressBar(0);
for (var i = 0; i <= 100; ++i)
{
    Helpers.WriteProgressBar(i, true);
    System.Threading.Thread.Sleep(50);
}
Console.WriteLine();
Helpers.WriteProgress(0);
Console.WriteLine("");
#endregion
Helpers.ChangeTextColorAndAlignCenter(ConsoleColor.Yellow, "-_-_-_-_-_-_-_-_-_-_--_-_-_-_-_-_-_-_-_-_-\n\n");
Thread.Sleep(2500);
Helpers.MenuBar();

