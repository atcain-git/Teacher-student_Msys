﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace pick
{
    public partial class 学生_个人组队管理 : Form
    {
        
        public 学生_个人组队管理()
        {
            InitializeComponent();
        }
        private string uid;
        public 学生_个人组队管理(string uid)
        {
            InitializeComponent();
            this.uid = uid;
        }

        private void 学生_个人组队管理_Load(object sender, EventArgs e)
        {
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            string str = this.uid;
            //label5.Text = str;
            if (!str.Equals(""))
            {
                if (b_group.IsExistence(str, m_group))
                {
                    label1.Text = m_group.Gid.ToString();
                    captainidbox.Text = m_group.Hid;
                    captainnamebox.Text = m_group.Hid_name;
                    memberoneid.Text = m_group.Mid1;
                    memberonename.Text = m_group.Mid1_name;
                    membertwoid.Text = m_group.Mid2;
                    membertwoname.Text = m_group.Mid2_name;
                    memberthreeid.Text = m_group.Mid3;
                    memberthreename.Text = m_group.Mid3_name;
                    topicname.Text = m_group.Pro_name;
                    topicintroduce.Text = m_group.Pro_intro;
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            BLL.Group b_group = new BLL.Group();
            Model.Group m_group = new Model.Group();
            string msg = "";
            int groupid = 0;
            if (label1.Text.ToString().Equals(""))
            {
                 groupid = 0;
            }
            else
            {
                groupid = int.Parse(label1.Text.ToString());
            }
            m_group.Gid = groupid;
            m_group.Hid = captainidbox.Text;
            m_group.Hid_name = captainnamebox.Text;
            m_group.Mid1 = memberoneid.Text;
            m_group.Mid1_name = memberonename.Text;
            m_group.Mid2 = membertwoid.Text;
            m_group.Mid2_name = membertwoname.Text;
            m_group.Mid3 = memberthreeid.Text;
            m_group.Mid3_name = memberthreename.Text;
            m_group.Pro_name = topicname.Text;
            m_group.Pro_intro = topicintroduce.Text;
            b_group.InsertOrModefiy(uid,groupid, m_group, out msg);
            MessageBox.Show(msg);
            }
            
            
        }
}
