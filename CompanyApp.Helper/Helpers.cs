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
            GetDepartmentById,
            GetDepartmentByName,
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
            DeleteEmployee,
            DeleteAllEmployeesByDeparmentName
        }
    }

}