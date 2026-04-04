using AdonetDisconnectedorientedexampleWith3databases.Interfaces;
using AdonetDisconnectedorientedexampleWith3databases.Models;
using AdonetDisconnectedorientedexampleWith3databases.Utils;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AdonetDisconnectedorientedexampleWith3databases.Repositorys
{
    public class OrderRepository : IOrderRepository
    {
        //WE NEED TO INJECT THE CONNECTION FACTORY INTERFACE IN THE CONSTRUCTOR OF THE ORDER REPOSITORY CLASS AND ASSIGN IT TO THE PRIVATE READONLY FIELD OF THE ICONNECTIONFACTORY INTERFACE TYPE.
        private readonly IConnectionFactory _connectionFactory;
        public OrderRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }
        public async Task<bool> AddOrder(Order Objord)
        {//addorder is used add the data to database by using the stored procedure and the parameters of the stored procedure are passed as the parameters of the command object and the command type is set to stored procedure and then the data adapter is used to fill the dataset with the data from the database and then the dataset is returned to the caller.
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.AddOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderName, Objord.OrderName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderLocation, Objord.OrderLocation);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                Da.Fill(dataSet, "Order");//dataset is filled with the data from the database and the name of the datatable is Order
                //you can give any name for dataset but it is better to give the name of the table as the name of the datatable in the dataset for better understanding and readability of the code.
            }
            return true;
        }

        public async Task<bool> DeleteOrder(int OrderId)
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.DeleteOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderId, OrderId);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                da.Fill(dataSet);

            }
            return true;
        }

        public async Task<List<Order>> GetallOrders()
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                List<Order> orderslist = new List<Order>();
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Orders");
                foreach (DataRow row in ds.Tables["Orders"].Rows)
                {
                    Order ord = new Order();
                    ord.OrderId = Convert.ToInt16(row["OrderId"]);//HERE CONVERTTHE DATA TO INT FORMAT 
                    ord.OrderName = Convert.ToString(row["OrderName"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    ord.OrderLocation = Convert.ToString(row["OrderLocation"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    orderslist.Add(ord);
                }
                return orderslist;
            }
        }

        public async Task<Order> GetOrderById(int Id)
        {

            Order or = new Order();
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.GetOrderByOrderId, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderId, Id);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds, "Order");
                foreach (DataRow row in ds.Tables["Order"].Rows)
                {
                  
                    or.OrderId = Convert.ToInt16(row["OrderId"]);//HERE CONVERTTHE DATA TO INT FORMAT 
                    or.OrderName = Convert.ToString(row["OrderName"]);//HERE CONVERT THE DATA TO STRING FORMAT
                    or.OrderLocation = Convert.ToString(row["OrderLocation"]);//HERE CONVERT THE DATA TO STRING FORMAT
                }
                return or;
            }
        }

        public async Task<bool> UpdateOrder(Order Objord)
        {
            using (SqlConnection con = _connectionFactory.MidLandSqlConnectionString())
            {
                SqlCommand cmd = new SqlCommand(Storedprocedures.UpdateOrder, con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderId, Objord.OrderId);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderName, Objord.OrderName);
                cmd.Parameters.AddWithValue(StoredprocedureParameters.OrderLocation, Objord.OrderLocation);
                SqlDataAdapter Da = new SqlDataAdapter(cmd);
                DataSet dataSet = new DataSet();
                Da.Fill(dataSet, "Order");
            }
            return true;
        }
    }
}
