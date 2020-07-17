using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace Common
{
    public class _Common
    {
        // 메세지박스 공통
        public void MsgboxShow(String msg)
        {
            MessageBox.Show(msg, "인사관리프로그램 - ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #region 암호화
        public string EncryptSHA512(string Data)
        {
            SHA512 sha = new SHA512Managed();
            byte[] hash = sha.ComputeHash(Encoding.ASCII.GetBytes(Data));
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte b in hash)
            {
                stringBuilder.AppendFormat("{0:x2}", b);
            }
            return stringBuilder.ToString();
        }
        #endregion
        #region 프로젝트 폼 목록 읽어 오기 (Load Failed)
        public static Form GetAssemblyForm(string strFormName)
        {
            Form f = null;
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.Name == strFormName)                     //프로젝트 내 폼 중에서 찾을 이름과 같으면...
                {
                    object o = Activator.CreateInstance(t);    //인스턴스 개체 생성 
                    f = o as Form;                                  //인스턴스 개체 폼 형식으로 캐스팅
                }
            }
            return f;
        }

        public static List<Form> GetAssemblyFormList()
        {
            List<Form> ltForm = new List<Form>();
            foreach (Type t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes())
            {
                if (t.BaseType.FullName.ToString() == "System.Windows.Forms.Form")  // 타입이 윈도우즈 폼이면...
                {
                    object o = Activator.CreateInstance(t);                                      //개체 생성
                    Form f = o as Form;                                                            //폼 형식으로 캐스팅
                    ltForm.Add(f);                                                                    //리스트에 담기

                }
            }
            return ltForm;
        }
        #endregion
        #region string을 date format정해서 값 변환
        public DateTime ParseString(string data_string, string format)
        {
            DateTime result_time;
            if (data_string.Length > 8) result_time = DateTime.ParseExact(data_string, "yyyy-MM-dd", CultureInfo.InvariantCulture);
            else result_time = DateTime.ParseExact(data_string, format, CultureInfo.InvariantCulture);
            return result_time;
        }
        #endregion
    }
}
