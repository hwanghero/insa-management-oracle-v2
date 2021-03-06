﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common
{
    public class Form_Control
    {
        // 폼의 컨트롤을 담을 리스트
        public List<Control> get_control_list = new List<Control>();

        #region 컨트롤 Null값 체크 (true일 경우 Null)
        public Boolean control_nullcheck()
        {
            foreach (Control b in get_control_list)
            {
                if (b.Enabled == true)
                {
                    if (string.IsNullOrEmpty(b.Text))
                    {
                        _Common common = new _Common();
                        common.MsgboxShow("빈값을 넣을 수 없습니다.");
                        b.Focus();
                        if (b.GetType() == typeof(ComboBox))
                        {
                            (b as ComboBox).Select();
                            (b as ComboBox).DroppedDown = true;
                        }
                        return true;

                    }

                }
            }
            return false;
        }

        #endregion
        #region 컨트롤 내용 리셋
        public void control_reset()
        {
            foreach (Control b in get_control_list)
            {
                b.ResetText();
                if (b.GetType() == typeof(ComboBox)) (b as ComboBox).SelectedItem = null;
                if (b.GetType() == typeof(RichTextBox)) (b as RichTextBox).Clear();
            }
        }
        #endregion
        #region 컨트롤 활성화/비활성화
        public void control_enabled(Boolean check, Boolean insaSelect_use)
        {
            foreach (Control b in get_control_list)
            {
                b.Enabled = check;
                if (!insaSelect_use)
                {
                    if (b.GetType() == typeof(DateTimePicker))
                    {

                        if (b.Enabled == false)
                        {
                            (b as DateTimePicker).CustomFormat = " ";
                            (b as DateTimePicker).Format = DateTimePickerFormat.Custom;
                        }
                        else
                        {
                            (b as DateTimePicker).CustomFormat = "yyyy-MM-dd";
                            (b as DateTimePicker).Format = DateTimePickerFormat.Custom;
                        }
                    }
                }
                else
                {
                    if (b.GetType() == typeof(Button))
                    {
                        (b as Button).Visible = check;
                    }
                }
            }
        }
        #endregion
        #region 컨트롤 가져오기
        // Form form: 가져올 폼
        // Boolean allcheck: 모든 컨트롤을 가져오는지 false(TextBox RichTextBox ComboBox MaskedTextBox)는 가져옴
        public void get_control(Form form, Boolean allcheck)
        {
            get_control_list.Clear();

            if (form != null)
            {
                foreach (Control a in form.Controls)
                {
                    if (a.GetType() != typeof(TabControl))
                    {
                        get_control_list.Add(a);
                    }
                    foreach (Control b in a.Controls)
                    {
                        if (allcheck)
                        {
                            get_control_list.Add(b);
                        }
                        else
                        {
                            if (b.GetType() == typeof(TextBox) || b.GetType() == typeof(RichTextBox) || b.GetType() == typeof(ComboBox) || b.GetType() == typeof(MaskedTextBox) || b.GetType() == typeof(DateTimePicker))
                            {
                                get_control_list.Add(b);
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region 코드 변환을 위한 콤보 박스만 가져오기
        public void get_Combobox(Form form)
        {
            get_control_list.Clear();

            if (form != null)
            {
                foreach (Control a in form.Controls)
                {
                    foreach (Control b in a.Controls)
                    {
                        if (b.GetType() == typeof(ComboBox))
                        {
                            get_control_list.Add(b);
                        }

                    }
                }
            }
        }
        #endregion
    }
}
