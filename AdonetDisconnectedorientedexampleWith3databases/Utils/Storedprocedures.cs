namespace AdonetDisconnectedorientedexampleWith3databases.Utils
{
    public static  class Storedprocedures
    {
        #region Department stored procedures
        public static  string AddDepartment = "Usp_AddDepartment_WithoutReturn";
        public static  string UpdateDepartment = "Usp_UpdateDepartment";
        public static  string DeleteDepartment = "Usp_DeleteDepartment";
        public static  string GetDepartment = "Usp_GetDepartment";
        public static  string GetDepartmentByDeptId = "Usp_GetDepartmentById";
        #endregion
    }
}
