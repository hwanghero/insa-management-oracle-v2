using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Database
{
    public class _Login : OracleDBManager
    {
        #region 로그인
        public Boolean Login(String id, String pw)
        {
            if (GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = Connection;
                    cmd.CommandText = "select * from admin_hwy where id='"+id+"' and pwd='"+pw+"'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        #endregion
    }
}
