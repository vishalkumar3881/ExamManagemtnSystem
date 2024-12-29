
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ExamManagementSystem.Models
{
    public class DataLayer
    {
        private readonly string? connectionString;

        public DataLayer(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DBCS");
        }
        public DataLayer(string connectionString)
        {
            this.connectionString = connectionString;
        }
        internal DataTable CheckUserExist(User user)
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "select * from Logins where Username = '" + user.Username + "' and PasswordHash = '" + user.Password + "' and RoleID=" + user.Roles + " and IsActive=1";
                dt = ExecuteSelectQuery(sql);
            }
            catch (Exception ex)
            {
                dt = null;
            }
            return dt;
        }

        private DataTable ExecuteSelectQuery(string query)
        {
            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(query, connection);
                    using (SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd))
                    {
                        dataAdapter.Fill(dt);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
            return dt;
        }
    }
}
