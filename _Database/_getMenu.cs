using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Database
{
    public class _getMenu : OracleDBManager
    {
        public void parent_menu(TreeView treeview)
        {
            if (GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    // 부모 따로, 자식 따로 불러와서 값 넣기
                    cmd.Connection = Connection;
                    cmd.CommandText = "select * from menu_hwy where menu_parent='root'";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            treeview.Nodes.Add(reader["menu_key"] as string, reader["menu_name"] as string);
                        }
                    }
                }
            }
        }

        public void child_menu(TreeView treeview, String parent)
        {
            if (GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    // 부모 따로, 자식 따로 불러와서 값 넣기
                    cmd.Connection = Connection;
                    cmd.CommandText = "select * from menu_hwy where menu_parent='" + parent + "' order by menu_rank";
                    using (OracleDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            treeview.Nodes.Find(parent, true)[0].Nodes.Add(reader["menu_key"] as string, reader["menu_name"] as string);
                        }
                    }
                }
            }
        }
    }
}
