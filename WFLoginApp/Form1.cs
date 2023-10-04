using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFLoginApp
{
    public partial class Form1 : Form
    {
        public List<User> userList = new List<User>();
        FForgotPassword frm = new FForgotPassword();
        public Form1()
        {
            InitializeComponent();
        }
        public string conString = "Data Source=ALGAPC012\\SQLEXPRESS;Initial Catalog=UserAppDB;Integrated Security=True";
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
            frm.ShowDialog();
            if (frm.userModel != null)
            {

                SqlConnection connection = new SqlConnection(conString);
                    connection.Open();
                    if (connection.State == System.Data.ConnectionState.Open)
                    {
                        string query = "Update Member set MemberPassword='" + frm.userModel.Password + "'where (MemberUsername='"+frm.userModel.UserName+"'and MemberPhoneNumber='"+frm.userModel.PhoneNumber+ "'and MemberIdentıtyNumber='" + frm.userModel.IdentityNumber+"'and MemberSecurityQuestion='"+frm.userModel.SecurityQuestion+ "'and MemberSecurityAnswer='"+frm.userModel.SecurityAnswer+"')";
                    SqlCommand command = new SqlCommand(query, connection);
                        command.ExecuteNonQuery();

                    }
                    
                    
                



                //var user = userList.Where(w => w.UserName == frm.userModel.UserName
                //                            && w.PhoneNumber == frm.userModel.PhoneNumber
                //                            && w.IdentityNumber == frm.userModel.IdentityNumber
                //                            && w.SecurityQuestion == frm.userModel.SecurityQuestion
                //                            && w.SecurityAnswer == frm.userModel.SecurityAnswer).FirstOrDefault();

                //if (user != null)
                //{
                //    userList.Remove(user);
                //    userList.Add(new User
                //    {
                //        UserName = user.UserName,
                //        Address = user.Address,
                //        BirthDate = user.BirthDate,
                //        Email = user.Email,
                //        Gender = user.Gender,
                //        Id = user.Id,
                //        IdentityNumber = user.IdentityNumber,
                //        SecurityQuestion = user.SecurityQuestion,
                //        Name = user.Name,
                //        PhoneNumber = user.PhoneNumber,
                //        SecurityAnswer = user.SecurityAnswer,
                //        Surname = user.Surname,
                //        Password = frm.userModel.Password,
                //        PasswordConfirmed = frm.userModel.PasswordConfirmed
                //    });
                //}
                //if (user!=null)
                //{

                //    MessageBox.Show(user.UserName + " nickli kullanıcının şifresi:" + " " + user.Password + " idi. Yeni şifresi: " + frm.userModel.Password);

                //}
                //else
                //{
                //    MessageBox.Show("Girdiğiniz bilgiler hatalı veya böye bir kayıt bulunamadı.");
                //}
            }

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FRegister frm = new FRegister();
            frm.ShowDialog();
            if (frm.userModel != null)
            {
                
                userList.Add(frm.userModel);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userList = new List<User>
            {
                new User
                {
                    Id = Guid.NewGuid(),
                    Name="Ali Atakan",
                    Surname="Bozoğlu",
                    Email="atknbzglu@gmail.com",
                    PhoneNumber="05309490658",
                    IdentityNumber="18230297428",
                    UserName="atknbzglu",
                    BirthDate = new DateTime(2006,7,5),
                    Password="1907",
                    PasswordConfirmed="1907",
                    Gender=1,
                    Address="Blablablablablablablabla",
                    SecurityQuestion="Hangi takımlısın",
                    SecurityAnswer="Fenerbahçe",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name="Yiğit Ali",
                    Surname="Bozoğlu",
                    Email="yigitali@gmail.com",
                    PhoneNumber="05300000000",
                    IdentityNumber="12332112312",
                    UserName="ygtali",
                    BirthDate = new DateTime(1985,10,17),
                    Password="2022",
                    PasswordConfirmed="2022",
                    Gender=1,
                    Address="Blablablablablablablabla",
                    SecurityQuestion="Nerelisin",
                    SecurityAnswer="Sivas",
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name="Mahmut",
                    Surname="Rızagil",
                    Email="mhmtrizagil@gmail.com",
                    PhoneNumber="05334243312",
                    IdentityNumber="12354922312",
                    UserName="rizagilmahmut",
                    BirthDate = new DateTime(1977,3,6),
                    Password="1999",
                    PasswordConfirmed="1999",
                    Gender=1,
                    Address="Blablablablablablablabla",
                    SecurityQuestion="İlk köpeğinin adı neydi",
                    SecurityAnswer="Karamel",
                },
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            var user = userList.Where(w => w.UserName == txtUsername.Text && w.Password == txtPassword.Text).FirstOrDefault();
            if (user != null)
            {
                MessageBox.Show(user.Name + " " + user.Surname + " Hoşgeldin..");
            }
            else
            {
                MessageBox.Show("Başarısız");
            }
        }
    }
}
