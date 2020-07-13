using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _Database
{
    public class _Side : OracleDBManager
    {
        public DataTable sideUserload()
        {
            DataTable table = new DataTable
            {
                Locale = CultureInfo.InvariantCulture
            };
            if (GetConnection() == true)
            {
                OracleDataAdapter adapter = new OracleDataAdapter("select bas_empno, bas_name from thrm_bas_hwy", Connection);
                adapter.Fill(table);
            }
            return table;
        }
    }
}
