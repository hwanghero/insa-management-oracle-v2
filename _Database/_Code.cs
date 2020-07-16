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
        #region CD_GRPCD 코드 담아서 문자로 변환
        public List<string[]> getCodeList()
        {
            List<string[]> CODELIST = new List<string[]>();
            if (GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT * FROM tieas_cd_hwy";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // 0 = grd
                            // 1, 0 = codnms
                            // 1, 1 = code
                            string[] input_code = new string[3];
                            input_code[0] = reader["cd_grpcd"].ToString();
                            input_code[1] = reader["cd_codnms"].ToString();
                            input_code[2] = reader["cd_code"].ToString();
                            CODELIST.Add(input_code);
                        }
                    }

                    cmd.CommandText = "select * from thrm_dept_hwy";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string[] input_code = new string[3];
                            input_code[0] = "DEPT";
                            input_code[1] = reader["dept_name"].ToString();
                            input_code[2] = reader["dept_code"].ToString();
                            CODELIST.Add(input_code);
                        }
                    }
                }
            }
            return CODELIST;
        }
        #endregion

        #region 코드그룹 코드들 가져오기
        public List<string> GetCodeList(params string[] value)
        {
            List<string> result = new List<string>();
            List<string> mode_item = new List<string>();
            foreach(string get_item in value)
            {
                mode_item.Add(get_item);
                Console.WriteLine(get_item);
            }
            if (GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = Connection;
                    cmd.CommandText = "SELECT * FROM tieas_cdg_hwy";

                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (!mode_item.Contains(reader["cdg_grpcd"].ToString()))
                            {
                                result.Add(reader["cdg_grpcd"].ToString() + "-" + reader["CDG_GRPNM"]);
                            }
                        }
                    }
                }
            }
            return result;
        }
        #endregion
    }
}
