
using System.CodeDom.Compiler;
using System.Data;
using Microsoft.AspNetCore.Http;

namespace ExamManagementSystem.Models
{
    public class BusinessLayer
    {
        private readonly string? _connectionString;
        private readonly DataLayer _datalayer;

        public BusinessLayer(IConfiguration configuration, DataLayer dataLayer)
        {
            _connectionString = configuration.GetConnectionString("DBCS");
            _datalayer = dataLayer;
        }
        internal bool CheckUserExist(User user)
        {
             DataTable dt = _datalayer.CheckUserExist(user);
            if (dt != null && dt.Rows.Count > 0)
            {              
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
