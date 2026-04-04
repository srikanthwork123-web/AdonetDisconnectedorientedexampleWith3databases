namespace AdonetDisconnectedorientedexampleWith3databases.Utils
{
    public static class StoredprocedureParameters
    {
        #region Department Parameters
        public static string DeptId = "@deptid";
        public static string DeptName = "@deptname";
        public static string DeptLocation = "@deptlocation";
        #endregion

        #region Order Parameters
        public static string OrderId = "@orderid";  //@orderid
        public static string OrderName = "@ordername";
        public static string OrderLocation = "@orderlocation";
        #endregion
    }
}
