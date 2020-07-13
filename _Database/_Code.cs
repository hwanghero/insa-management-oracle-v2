using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Database
{
    public class _Code : OracleDBManager
    {
        #region CD_GRPCD 코드화
        // 모든 코드값 리스트에 저장하기
        public List<String[,]> CD_GET()
        {
            List<String[,]> dict = new List<String[,]>();
            if (GetConnection() == true)
            {
                Console.WriteLine("DB CD CONN");
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT * FROM tieas_cd_hwy";

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dict.Add(new String[,] {
                                {
                                    reader["cd_grpcd"].ToString()
                                },
                                {
                                    reader["cd_code"].ToString()
                                }
                                });
                        }
                    }
                }
            }
            return dict;
        }
        #endregion
    }
}
