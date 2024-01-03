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
int count = 0;
while (true)
{
startMenu: ChangeTextColor(ConsoleColor.DarkYellow, "1.DepartmentMenu 2.EmployeeMenu 0.ExitMenu\n");
    Thread.Sleep(100);
    ChangeTextColor(ConsoleColor.Yellow, "Enter A Number For Menu:\n");
    var menuBar = int.TryParse(Console.ReadLine(), out var menuSelection);
    if (menuBar && menuSelection > 0 && menuSelection < 3)
    {
        switch (menuSelection)
        {
            case (int)Menus.DepartmentMenu:
                MenuDepartment: ChangeTextColor(ConsoleColor.Cyan,
                $"[{count += 1}] Create Department\n" +
                $"[{count += 1}] Get All Departments\n" +
                $"[{count += 1}] Get All Departments By Capacity\n" +
                $"[{count += 1}] Get Department By ID\n" +
                $"[{count += 1}] Get Department By Name\n" +
                $"[{count += 1}] Update Department\n" +
                $"[{count += 1}] Delete Department\n" +
                $"[{count=0}] Exit Deparment Menu\n");
                var getMenuNum = int.TryParse(Console.ReadLine(), out var getDepartmentMenu);
                if (getDepartmentMenu > 0 && getDepartmentMenu < 8)
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
                            departmentController.GetDepartmentById();
                            break;
                        case (int)DepartmentMenu.GetDepartmentByName:
                            departmentController.GetDepartmentByName();
                            break;
                        case (int)DepartmentMenu.UpdateDepartment:
                            departmentController.UpdateDepartment();
                            break;
                        case (int)DepartmentMenu.DeleteDepartment:
                            departmentController.DeleteDepartment();
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
                MenuEmployee: ChangeTextColor(ConsoleColor.Cyan,
               $"[{count += 1}] Create Employee\n" +
               $"[{count += 1}] Get All Employees\n" +
               $"[{count += 1}] Get All Employees By Name Or Surname\n" +
               $"[{count += 1}] Get Employee By ID\n" +
               $"[{count += 1}] Get Employees By Age\n" +
               $"[{count += 1}] Get Employees By Department Name\n" +
               $"[{count += 1}] Get Employees By Department ID\n" +
               $"[{count += 1}] Get All Employees Count\n" +
               $"[{count += 1}] Update Employee\n" +
               $"[{count += 1}] Delete Employee\n" +
               $"[{count += 1}] Delete All Employees By Deparment Name\n" +
               $"[{count=0}] Exit EmployeeMenu\n");
                var getMenuNumber = int.TryParse(Console.ReadLine(), out var getEmployeeMenu);
                if (getEmployeeMenu > 0 && getEmployeeMenu < 12)
                {
                    switch (getEmployeeMenu)
                    {
                        case (int)EmployeeMenu.CreateEmployee:
                            employeeController.CreateEmployee();
                            break;
                        case (int)EmployeeMenu.GetAllEmployees:
                            employeeController.GetAllEmployees();
                            break;
                        case (int)EmployeeMenu.GetAllEmployeesByNameOrSurname:
                            employeeController.GetAllEmployeesByNameOrSurname();
                            break;
                        case (int)EmployeeMenu.GetEmployeeById:
                            employeeController.GetEmployeeById();
                            break;
                        case (int)EmployeeMenu.GetEmployeeByAge:
                            employeeController.GetEmployeesByAge();
                            break;
                        case (int)EmployeeMenu.GetEmployeesByDepartmentName:
                            employeeController.DeleteAllEmployeesByDeparmentName();
                            break;
                        case (int)EmployeeMenu.GetEmployeesByDepartmentId:
                            employeeController.GetEmployeesByDepartmentId();
                            break;
                        case (int)EmployeeMenu.GetAllEmployeesCount:
                            employeeController.GetAllEmployeesCount();
                            break;
                        case (int)EmployeeMenu.UpdateEmployee:
                            employeeController.UpdateEmployee();
                            break;
                        case (int)EmployeeMenu.DeleteEmployee:
                            employeeController.DeleteEmployee();
                            break;
                        case (int)EmployeeMenu.DeleteAllEmployeesByDeparmentName:
                            employeeController.DeleteAllEmployeesByDeparmentName();
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
                goto MenuEmployee;
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

