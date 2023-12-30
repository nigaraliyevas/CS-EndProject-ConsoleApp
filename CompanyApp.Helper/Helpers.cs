namespace CompanyApp.Helper
{
    public class Helpers
    {
        #region loading-bar
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        public static void WriteProgressBar(int percent, bool update = false)
        {
            if (update)
                Console.Write(_back);
            Console.Write("[");
            var p = (int)((percent / 10f) + .5f);
            for (var i = 0; i < 10; ++i)
            {
                if (i >= p)
                    Console.Write(' ');
                else
                    Console.Write(_block);
            }
            Console.Write("] {0,3:##0}%", percent);
        }
        public static void WriteProgress(int progress, bool update = false)
        {
            if (update)
                Console.Write("\b");
        }
        #endregion
        public static void ChangeTextColorAndAlignCenter(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            int screenWidth = Console.WindowWidth;
            int leftPadding = (screenWidth - text.Length) / 2;
            Console.WriteLine(text.PadLeft(leftPadding + text.Length));
            Console.ResetColor();
        }
        public static void ChangeTextColor(ConsoleColor color, string text)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }
        public static void MenuBar()
        {
            while (true)
            {
startMenu: ChangeTextColor(ConsoleColor.Yellow, "1.DepartmentMenu 2.EmployeeMenu 0.ExitMenu\n");
                ChangeTextColor(ConsoleColor.DarkYellow, "Enter A Number For Menu:\n");
                var menuBar = int.TryParse(Console.ReadLine(), out var menuSelection);
                if (menuBar && menuSelection > 0 && menuSelection < 3)
                {
                    switch (menuSelection)
                    {
                        case (int)Menus.DepartmentMenu:
                            Console.WriteLine("" +
                            "[1] Create Department\n" +
                            "[2] Get All Departments\n" +
                            "[3] Get All Departments By Name\n" +
                            "[4] Get Department By ID\n" +
                            "[5] Update Department\n" +
                            "[6] Delete Department\n" +
                            "[0] Exit Deparment Menu\n");
                            var getMenuNum = int.TryParse(Console.ReadLine(), out var getDepartmentMenu);
                            if (getDepartmentMenu > 0 && getDepartmentMenu < 7)
                            {
                                switch (getDepartmentMenu)
                                {
                                    case (int)DepartmentMenu.CreateDepartment:
                                        //
                                        break;
                                    case (int)DepartmentMenu.GetAllDepartments:
                                        //
                                        break;
                                    case (int)DepartmentMenu.GetAllDepartmentsByName:
                                        //
                                        break;
                                    case (int)DepartmentMenu.GetDepartmentById:
                                        //
                                        break;
                                    case (int)DepartmentMenu.UpdateDepartment:
                                        //
                                        break;
                                    case (int)DepartmentMenu.DeleteDepartment:
                                        //
                                        break;
                                        break;
                                }
                            }
                            else if (getDepartmentMenu == 0)
                            {
                                goto startMenu;
                            }
                            else
                            {
                                ChangeTextColor(ConsoleColor.Red, "Please Enter Correct Number...");
                            }
                            break;
                        case (int)Menus.EmployeeMenu:
                            Console.WriteLine("" +
                           "[1] Create Employee\n" +
                           "[2] Get All Employees\n" +
                           "[3] Get All Employees By Name Or Surname\n" +
                           "[4] Get Employee By ID\n" +
                           "[5] Get Employees By Age\n" +
                           "[6] Get Employees By Department Name\n" +
                           "[7] Get Employees By Department ID\n" +
                           "[7] Get All Employees Count\n" +
                           "[5] Update Employee\n" +
                           "[6] Delete Employee\n" +
                           "[0] Exit EmployeeMenu\n");
                            var getMenuNumber = int.TryParse(Console.ReadLine(), out var getEmployeeMenu);
                            if (getEmployeeMenu > 0 && getEmployeeMenu < 7)
                            {
                                switch (getEmployeeMenu)
                                {
                                    case (int)EmployeeMenu.CreateEmployee:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetAllEmployees:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetAllEmployeesByNameOrSurname:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetEmployeeById:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetEmployeeByAge:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetEmployeesByDepartmentName:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetEmployeesByDepartmentId:
                                        //
                                        break;
                                    case (int)EmployeeMenu.GetAllEmployeesCount:
                                        //
                                        break;
                                    case (int)EmployeeMenu.UpdateEmployee:
                                        //
                                        break;
                                    case (int)EmployeeMenu.DeleteEmployee:
                                        //
                                        break;
                                        break;
                                }
                            }
                            else if (getEmployeeMenu == 0)
                            {
                                goto startMenu;
                            }
                            else
                            {
                                ChangeTextColor(ConsoleColor.Red, "Please Enter Correct Number...");
                            }
                            break;
                        default:
                            break;
                    }
                }
                else if (menuSelection == 0)
                {
                    ChangeTextColor(ConsoleColor.Green, "Bye Byee...");
                    break;
                }
                else
                {
                    ChangeTextColorAndAlignCenter(ConsoleColor.Red, "Please Enter Correct number");

                }

            }
        }
        public enum Menus
        {
            DepartmentMenu = 1,
            EmployeeMenu
        }
        public enum DepartmentMenu
        {
            CreateDepartment = 1,
            GetAllDepartments,
            GetAllDepartmentsByName,
            GetDepartmentById,
            UpdateDepartment,
            DeleteDepartment

        }
        public enum EmployeeMenu
        {
            CreateEmployee = 1,
            GetAllEmployees,
            GetAllEmployeesByNameOrSurname,
            GetEmployeeById,
            GetEmployeeByAge,
            GetEmployeesByDepartmentName,
            GetEmployeesByDepartmentId,
            GetAllEmployeesCount,
            UpdateEmployee,
            DeleteEmployee
        }
    }

}