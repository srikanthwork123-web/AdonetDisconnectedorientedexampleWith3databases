namespace AdonetDisconnectedorientedexampleWith3databases.Utils
{
//utlis folder is used to store the static classes which contains the constant values of the stored procedures and the parameters of the stored procedures.
//in project level if you want to create any common files we can create inside utils folder and we can use those files in the entire project.
    public static  class Storedprocedures
    {
        #region Department stored procedures
        public static  string AddDepartment = "Usp_AddDepartment_WithoutReturn";
        public static  string UpdateDepartment = "Usp_UpdateDepartment";
        public static  string DeleteDepartment = "Usp_DeleteDepartment";
        public static  string GetDepartment = "Usp_GetDepartment";
        public static  string GetDepartmentByDeptId = "Usp_GetDepartmentById";
        #endregion

        #region order stored procedures
        public static string AddOrder = "Usp_AddOrder_Without_Return";
        public static  string UpdateOrder = "Usp_UpdateOrder";
        public static  string DeleteOrder = "Usp_DeleteOrder";
        public static  string GetOrder = "Usp_GetOrder";
        public static  string GetOrderByOrderId = "Usp_GetOrderById";
        #endregion

        #region Employee storedprocedures
        public static  string AddEmployee = "Usp_AddEmployeeReturn";
        public static  string UpdateEmployee = "Usp_UpdateEmployee";
        public static  string DeleteEmployee = "Usp_DeleteEmployee";
        public static  string GetEmployee = "Usp_GetEmployee";
        public static  string GetEmployeeByEmpid = "Usp_GetEmployeeId";
        #endregion
    }
}
