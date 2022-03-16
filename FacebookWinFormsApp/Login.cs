using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{
    public partial class Login : Form
    {

        private User m_LoggedInUser;
        private LoginResult m_LoginResult;
        private Form1 m_ReloadFormMain;

        public Login()
        {

            InitializeComponent();
            FacebookService.s_CollectionLimit = 200;
            

        }

        private void LoginToForm1()
        {
            try
            {
                m_LoginResult = FacebookService.Login("322227853207762",
                            "public_profile",
                            "email",
                            "publish_to_groups",
                            "user_birthday",
                            "user_age_range",
                            "user_gender",
                            "user_link",
                            "user_videos",
                            "publish_to_groups",
                            "groups_access_member_info",
                            "user_friends",
                            "user_events",
                            "user_likes",
                            "user_location",
                            "user_photos",
                            "user_posts",
                            "user_hometown");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);

            }
            if (!string.IsNullOrEmpty(m_LoginResult.AccessToken))
            {

                m_LoggedInUser = m_LoginResult.LoggedInUser;

            }
            else
            {

                MessageBox.Show(m_LoginResult.ErrorMessage);

            }

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            LoginToForm1();
            this.Hide();
            m_ReloadFormMain = new Form1(m_LoggedInUser, m_LoginResult);
            m_ReloadFormMain.ShowDialog();
            this.Visible = false;


        }

        protected override void OnShown(EventArgs e)
        {

            base.OnShown(e);
            Form1.s_AppSettings = AppSettings.LoadFromFile();

            if (Form1.s_AppSettings.RememberUser && !string.IsNullOrEmpty(Form1.s_AppSettings.RecentAccessToken))
            {

                m_LoginResult = FacebookService.Connect(Form1.s_AppSettings.RecentAccessToken);
                this.Hide();
                m_LoggedInUser = m_LoginResult.LoggedInUser;
                m_ReloadFormMain = new Form1(m_LoggedInUser, m_LoginResult);
                m_ReloadFormMain.ShowDialog();

            }

        }

        private void cbRememberMe_CheckedChanged(object sender, EventArgs e)
        {

            bool buttonRememberMe = false;

            if (cbRememberMe.Checked)
            {

                Form1.s_AppSettings.RememberUser = !buttonRememberMe;

            }

        }

    }

}
