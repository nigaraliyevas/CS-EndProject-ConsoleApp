namespace CompanyApp.Helper
{
    public class Helpers
    {
        #region loading-bar
        const char _block = '■';
        const string _back = "\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b\b";
        public static void WriteProgressBar(int percent, bool update = false)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;

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
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            int screenWidth = Console.WindowWidth;
            int leftPadding = (screenWidth - text.Length) / 2;
            Console.WriteLine(text.PadLeft(leftPadding + text.Length));
            Console.ResetColor();
        }
        public static void ChangeTextColor(ConsoleColor color, string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = color;
            Console.WriteLine(text);

        }
        public static void ChangeTextColorForLoading(ConsoleColor color, string text)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = color;
            Console.Write(text);
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
            GetAllDepartmentsByCapacity,
            GetAllDepartmentsWithSortedCapacity,
            GetDepartmentById,
            GetDepartmentByName,
            UpdateDepartment,
            OldDatasOfUpdatedDepartments,
            DeleteDepartment

        }
        public enum EmployeeMenu
        {
            CreateEmployee = 1,
            GetAllEmployees,
            GetAllEmployeesWithSortedAge,
            GetAllEmployeesWithSortedSalary,
            GetAllEmployeesByNameOrSurname,
            GetEmployeeById,
            GetEmployeeByAge,
            GetEmployeesByDepartmentName,
            GetEmployeesByDepartmentId,
            GetAllEmployeesCount,
            UpdateEmployee,
            OldDatasOfUpdatedEmployees,
            DeleteEmployee,
            DeleteAllEmployeesByDeparmentName,
        }
    }

}