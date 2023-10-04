using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFLoginApp
{
    public partial class FForgotPassword : Form
    {
        public User userModel;
        public FForgotPassword()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=ALGAPC012\\SQLEXPRESS;Initial Catalog=UserAppDB;Integrated Security=True";
        private void FForgotPassword_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            
            userModel = new User 
            {
                UserName = txtUsername.Text,
                Password = txtNewPassword.Text,
                PasswordConfirmed = txtPasswordConfirm.Text,
                SecurityAnswer = txtSecurityAnswer.Text,
                SecurityQuestion = txtSecurityQuestion.Text,
                PhoneNumber = txtPhoneNumber.Text,
                IdentityNumber = txtIdentityNumber.Text
            };
            this.Close();
        }
    }
}
