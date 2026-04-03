using AdonetDisconnectedorientedexampleWith3databases.Interfaces;
using AdonetDisconnectedorientedexampleWith3databases.Models;
using AdonetDisconnectedorientedexampleWith3databases.Utils;
using Microsoft.AspNetCore.Connections;
using Microsoft.Data.SqlClient;
using System.Data;
namespace AdonetDisconnectedorientedexampleWith3databases.Repositorys
{
    public class DepertmentRepository : IDepartmentRepository
    {
        string connectionString = "data source=DESKTOP-13B42NJ;integrated security=yes;Encrypt=True;TrustServerCertificate=True;initial catalog=Northwind_DB";
        public async Task<bool> AddDepartment(Department Dept)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, Dept.DepartmentName);
                //here to pass the values to storedprocedure parameters use the AddWithValue method of the Parameters collection of the SqlCommand object.
                //The first argument is the name of the parameter as defined in the stored procedure, and the second argument is the value you want to pass to that parameter.
                //In this case, we are passing the DepartmentName property of the Dept object to the @DeptName parameter in the stored procedure.
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, Dept.DepartmentLocation);
                
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                //SqlDataAdapter class usage is it will open the connection and executing the query and fill the dataset and then it will close the connection automatically
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
            }
            return true;
        }

        public async  Task<bool> DeleteDepartment(int DepartmentId)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, DepartmentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
            return true;
        }

        public async Task<List<Department>> GetAllDepartments()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                List<Department> lstdep = new List<Department>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();//To store the data at ado.net side in table format we use dataset.
                dataAdapter.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    Department dep = new Department();
                    dep.DepartmentId = Convert.ToInt16(row["deptid"]);
                    dep.DepartmentName = Convert.ToString(row["deptname"]);
                    dep.DepartmentLocation = Convert.ToString(row["deptlocation"]);
                    lstdep.Add(dep);
                }
                return lstdep;
            }
        }

        public async Task<Department> GetDepartmentById(int DepartmentId)
        {
            Department dep = new Department();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetDepartmentByDeptId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, DepartmentId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
                foreach (DataRow row in ds.Tables["Department"].Rows)
                {
                    dep.DepartmentId = Convert.ToInt16(row["deptid"]);
                    dep.DepartmentName = Convert.ToString(row["deptname"]);
                    dep.DepartmentLocation = Convert.ToString(row["deptlocation"]);
                }
            }
            return dep;
        }

        public async Task<bool> UpdateDepartment(Department Dept)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateDepartment, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptId, Dept.DepartmentId);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptName, Dept.DepartmentName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.DeptLocation, Dept.DepartmentLocation);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Department");
            }
            return true;
        }
    }
}
/*
=>SqlDataAdapter class usage is it will open the connection and executing the query and fill the dataset and then it will close the connection automatically.

=>InAdonet disconnected oriented architecture Don't use (conn.open(),conn.close(),exceutereader(),exceutesaclar(),ExceuteNonQuery() methods).

=>In connection oriented architecture(,exceutereader(),exceutesaclar(),ExceuteNonQuery() methods used).these methods are used to excuting the Queries.

=>In disconnected oriented architecture, these methods are not used. Everything handled by sqldataadapter class for exceuting the Queries.
 */