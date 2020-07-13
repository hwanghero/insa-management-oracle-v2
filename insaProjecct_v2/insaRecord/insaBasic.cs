using insaRecord;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using _Database;
using Common;
using Oracle.ManagedDataAccess.Client;

namespace insaProjecct_v2
{
    public partial class insaBasic : Form, Iinsa_Interface
    {
        // 콤보박스 DB 저장용
        static List<Control> CODE_STORE = new List<Control>();
        // 코드 DB 저장용
        static List<string[,]> CODE_ = new List<string[,]>();

        // DB 접속
        OracleDBManager _DB = new OracleDBManager();
        public insaBasic()
        {
            InitializeComponent();
        }
        #region 인사기본사항 정보 입력
        /*
         *  인사기본사항
         */
        public int thrm_bas_add(String empno, String resno, String name, String cname, String ename, String fix, String zip, String addr, String residence, String hdpno, String telno, String email, String mil_sta, String mil_mil, String mil_rnk, String mar,
            String acc_bank1, String acc_name1, String acc_no1, String acc_bank2, String acc_name2, String acc_no2, String cont, String intern, int intern_no, String emp_sdate, String emp_edate, String entdate,
            String resdate, String levdate, String reidate, String wsta, String sts, String pos, String dut, String dept, String rmk, String pos_dt, String dut_dt, String dept_dt, String intern_dt, String datasys1, String datasys2, String datasys3)
        {
            int check = 1;
            try
            {
                if (_DB.GetConnection() == true)
                {
                    OracleCommand comm = new OracleCommand();
                    comm.Connection = _DB.Connection;
                    comm.CommandText = @"INSERT INTO THRM_BAS_HWY values(:empno, :resno, :name, :cname, :ename, :fix, :zip, :addr, :residence, :hdpno, :telno, :email, :mil_sta, :mil_mil, :mil_rnk, :mar, " + // 15
                        ":acc_bank1, :acc_name1, :acc_no1, :acc_bank2, :acc_name2, :acc_no2, :cont, :intern, :intern_no, :emp_sdate, :emp_edate, :entdate, " + // 12
                        ":resdate, :levdate, :reidate, :wsta, :sts, :pos, :dut, :dept, :rmk, :pos_dt, :dut_dt, :dept_dt, :intern_dt, :datasys1, :datasys2, :datasys3)"; // 16

                    comm.Parameters.Add("empno", empno);
                    comm.Parameters.Add("resno", resno);
                    comm.Parameters.Add("name", name);
                    comm.Parameters.Add("cname", cname);
                    comm.Parameters.Add("ename", ename);
                    comm.Parameters.Add("fix", fix);
                    comm.Parameters.Add("zip", zip);
                    comm.Parameters.Add("addr", addr);
                    comm.Parameters.Add("residence", residence);
                    comm.Parameters.Add("hdpno", hdpno);
                    comm.Parameters.Add("telno", telno);
                    comm.Parameters.Add("email", email);
                    comm.Parameters.Add("mil_sta", mil_sta);
                    comm.Parameters.Add("mil_mil", mil_mil);
                    comm.Parameters.Add("mil_rnk", mil_rnk);
                    comm.Parameters.Add("mar", mar);
                    comm.Parameters.Add("acc_bank1", acc_bank1);
                    comm.Parameters.Add("acc_name1", acc_name1);
                    comm.Parameters.Add("acc_no1", acc_no1);
                    comm.Parameters.Add("acc_bank2", acc_bank2);
                    comm.Parameters.Add("acc_name2", acc_name2);
                    comm.Parameters.Add("acc_no2", acc_no2);
                    comm.Parameters.Add("cont", cont);
                    comm.Parameters.Add("intern", intern);
                    comm.Parameters.Add("intern_no", intern_no);
                    comm.Parameters.Add("emp_sdate", emp_sdate);
                    comm.Parameters.Add("emp_edate", emp_edate);
                    comm.Parameters.Add("entdate", entdate);
                    comm.Parameters.Add("resdate", resdate);
                    comm.Parameters.Add("levdate", levdate);
                    comm.Parameters.Add("reidate", reidate);
                    comm.Parameters.Add("wsta", wsta);
                    comm.Parameters.Add("sts", sts);
                    comm.Parameters.Add("pos", pos);
                    comm.Parameters.Add("dut", dut);
                    comm.Parameters.Add("dept", dept);
                    comm.Parameters.Add("rmk", rmk);
                    comm.Parameters.Add("pos_dt", pos_dt);
                    comm.Parameters.Add("dut_dt", dut_dt);
                    comm.Parameters.Add("dept_dt", dept_dt);
                    comm.Parameters.Add("intern_dt", intern_dt);
                    comm.Parameters.Add("datasys1", datasys1);
                    comm.Parameters.Add("datasys2", datasys2);
                    comm.Parameters.Add("datasys3", datasys3);
                    comm.Prepare();
                    comm.ExecuteNonQuery();
                    comm.Cancel();
                    comm.Dispose();
                    check = 0;
                }
            }
            catch (Exception ex)
            {
                check = 1;
                Console.WriteLine(ex);
            }
            return check;
        }
        #endregion
        public void DB_Insert()
        {
            try
            {
                //int nmbox = Convert.ToInt32(newbie_month_box.Text);
                //if (thrm_bas_add(e_no_box.Text, rrn_box.Text, kor_name_box.Text, chn_name_box.Text, eng_name_box.Text,
                //    sexxbox.Text, zip_box.Text, address_box.Text, residence_box.Text, phone_box.Text, home_box.Text, email1_box.Text,
                //    mil_ok_box.Text, save_keys[3], mil_rank_box.Text, marry_box.Text, save_keys[4], bank_master_box.Text,
                //    bank_number_box.Text, save_keys[5], bank_master_box2.Text, bank_number_box2.Text, contract_box.Text,
                //    newbie_check_box.Text, nmbox, slave_start.Value.ToString("yyyyMMdd"), slave_end.Value.ToString("yyyyMMdd"),
                //    join_box.Value.ToString("yyyyMMdd"), goodbye_box.Value.ToString("yyyyMMdd"), "", "", state_box.Text, save_keys[1], save_keys[0], save_keys[2],
                //    dept_keys, note_box.Text, now_rank_box.Value.ToString("yyyyMMdd"), now_spot_box.Value.ToString("yyyyMMdd"), now_department_box.Value.ToString("yyyyMMdd"),
                //    now_newbie_box.Value.ToString("yyyyMMdd"), nowtime, "A", "userid") == 0)
                //{
                //    MessageBox.Show("입력이 완료되었습니다.");
                //    from_control.get_control(this, false);
                //    from_control.control_reset();
                //}
            }
            catch (Exception a)
            {
                MessageBox.Show("입력에 실패하였습니다.\n\n" + a);
            }
            MessageBox.Show("basic insert");
        }


        public void DB_Update()
        {
            MessageBox.Show("basic update");
        }

        public void DB_Delete()
        {
            MessageBox.Show("basic delete");
        }


        #region 폼 로드시에 콤보박스 값 넣기 (DB 한번 사용)
        private void insaBasic_Load(object sender, EventArgs e)
        {
            // 한번만 넣어주기
            if (CODE_.Count == 0)
            {
                _Code CD = new _Code();
                CODE_ = CD.CD_GET();
            }

            if (CODE_STORE.Count == 0)
            {
                CODE_INPUT("POS");
                CODE_INPUT("STS");
                CODE_INPUT("DUT");
                CODE_INPUT("MIL");
                CODE_INPUT("BNK");
                CODE_INPUT("DEPT");
            }

            foreach (string[,] b in CODE_)
            {
                Console.WriteLine(b[0,0] +":"+ b[1, 0]);
            }

            // 리스트에 있는거 가져오기
            Form_Control frm_ctrl = new Form_Control();
            frm_ctrl.get_Combobox(this);
            foreach (Control a in CODE_STORE)
            {
                foreach (Control thisCtrl in frm_ctrl.get_control_list)
                {
                    if (thisCtrl.Tag != null)
                    {
                        if (thisCtrl.Tag.Equals(a.Tag))
                        {
                            foreach (string b in (a as ComboBox).Items)
                            {
                                (thisCtrl as ComboBox).Items.Add(b);
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region 콤보박스에 데이터베이스 넣기

        // :: 데이터베이스에 있는 코드를 콤보박스에 넣는 함수
        // string GRPCD : 코드 그룹 이름
        private ComboBox CODE_INPUT(string GRPCD)
        {
            ComboBox combo = new ComboBox();
            OracleDBManager _db = new OracleDBManager();
            if (_db.GetConnection() == true)
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    cmd.Connection = _db.Connection;

                    // DEPT는 따로 else에서 처리
                    if (!GRPCD.Equals("DEPT"))
                    {
                        cmd.CommandText = "select * from tieas_cd_hwy where CD_GRPCD='" + GRPCD + "'";
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                combo.Items.Add(reader["CD_CODNMS"].ToString());
                            }
                        }
                    }
                    else
                    {
                        cmd.CommandText = "select * from thrm_dept_hwy";
                        using (OracleDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                combo.Items.Add(reader["dept_name"].ToString());
                            }
                        }
                    }
                }
            }
            combo.Tag = GRPCD;
            CODE_STORE.Add(combo);
            return combo;
        }
        #endregion
    }
}
