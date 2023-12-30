using CompanyApp.Controllers;
using CompanyApp.Helper;
using static CompanyApp.Helper.Helpers;
DepartmentController departmentController = new();
EmployeeController employeeController = new();
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
while (true)
{
startMenu: ChangeTextColor(ConsoleColor.Yellow, "1.DepartmentMenu 2.EmployeeMenu 0.ExitMenu\n");
    Thread.Sleep(100);
    ChangeTextColor(ConsoleColor.DarkYellow, "Enter A Number For Menu:\n");
    var menuBar = int.TryParse(Console.ReadLine(), out var menuSelection);
    if (menuBar && menuSelection > 0 && menuSelection < 3)
    {
        switch (menuSelection)
        {
            case (int)Menus.DepartmentMenu:
                MenuDepartment: ChangeTextColor(ConsoleColor.Cyan,
                "[1] Create Department\n" +
                "[2] Get All Departments\n" +
                "[3] Get All Departments By Capacity\n" +
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
                            departmentController.CreateDepartment();
                            break;
                        case (int)DepartmentMenu.GetAllDepartments:
                            departmentController.GetAllDepartments();
                            break;
                        case (int)DepartmentMenu.GetAllDepartmentsByCapacity:
                            departmentController.GetAllDepartmentsByCapacity();
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
                goto MenuDepartment;
                break;
            case (int)Menus.EmployeeMenu:
                ChangeTextColor(ConsoleColor.Cyan,
               "[1] Create Employee\n" +
               "[2] Get All Employees\n" +
               "[3] Get All Employees By Name Or Surname\n" +
               "[4] Get Employee By ID\n" +
               "[5] Get Employees By Age\n" +
               "[6] Get Employees By Department Name\n" +
               "[7] Get Employees By Department ID\n" +
               "[8] Get All Employees Count\n" +
               "[9] Update Employee\n" +
               "[10] Delete Employee\n" +
               "[0] Exit EmployeeMenu\n");
                var getMenuNumber = int.TryParse(Console.ReadLine(), out var getEmployeeMenu);
                if (getEmployeeMenu > 0 && getEmployeeMenu < 11)
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
        ChangeTextColor(ConsoleColor.Red, "Please Enter Correct number\n");

    }

}

