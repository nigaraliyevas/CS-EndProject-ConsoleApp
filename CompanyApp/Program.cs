using CompanyApp.Helper;

Console.WriteLine("gh");
/*int res = 0;
for (int i = 0; i <= 100; i++)
{
    System.Threading.Thread.Sleep(100);
    Console.WriteLine($"Loading:{i+1}");
}*/
ConsoleSpinner spinner = new ConsoleSpinner();
spinner.Delay = 300;
while (true)
{
    spinner.Turn(displayMsg: "Working ", sequenceCode: 5);
}

