using CompanyApp.Helper;

namespace CompanyApp.Controllers
{
    public class AuthorLoginController
    {
        //user admin 
        public void LoginIn()
        {
            Helpers.ChangeTextColor(ConsoleColor.Yellow, "Please enter username:\n");
            string username=Console.ReadLine();
            Helpers.ChangeTextColor(ConsoleColor.Yellow, "Please enter password\n");
            string password=Console.ReadLine();
            string authorUser = "User";
            string authorAdmin = "Admin";
            string passwordUser = "User123";
            string passwordAdmin = "Admin123";
            if (username == authorUser && password == passwordUser)
            {
                Console.WriteLine("Successfully entered as ~User~ ");
            }
            else if (username == authorAdmin && password == passwordAdmin)
            {
                Console.WriteLine("Successfully entered as ~Admin~ ");
            }
            else
            {
                Console.WriteLine("username or password is incorrect");
            }
        }

    }
}
