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
    public partial class FRegister : Form
    {
        public User userModel;
        public FRegister()
        {
            InitializeComponent();
        }

        private void FRegister_Load(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (IsValid())
            {
                Register();
            }

        }
        public bool IsValid()
        {
            char[] turkishChars = { 'Ç', 'ç', 'ğ', 'Ğ', 'ü', 'Ü', 'İ', 'ı', 'ş', 'Ş', 'ö', 'Ö' };
            char[] specialChars = { ',', '!', '?', '/', ':', '>', '£' };

            if (txtName.Text.Length < 2)
            {
                MessageBox.Show("Ad geçersiz.");
                txtName.Focus();
                return false;
            }
            if (txtSurname.Text.Length < 3)
            {
                MessageBox.Show("Soyad geçersiz.");
                txtSurname.Focus();
                return false;
            }
            if (txtEmail.Text.Length < 10)
            {

                MessageBox.Show("Email geçersiz.");
                txtEmail.Focus();
                return false;
            }

            foreach (char item in turkishChars)
            {
                if (txtEmail.Text.IndexOf(item) != -1)
                {
                    MessageBox.Show("E-Mailde Türkçe karakter kullanılamaz.");
                    txtEmail.Focus();
                    return false;
                }
            }
            foreach (char item in specialChars)
            {
                if (txtEmail.Text.IndexOf(item) != -1)
                {
                    MessageBox.Show("E-Mailde '" + item.ToString() + "' karakteri kullanılamaz.");
                    txtEmail.Focus();
                    return false;
                }
            }

            int charCount = 0;
            foreach (var item in txtEmail.Text)
            {
                if (item == '@')
                {
                    charCount++;
                }
            }

            if (charCount != 1)
            {
                MessageBox.Show("Email geçersiz.");
                txtEmail.Focus();
                return false;
            }

            if (txtEmail.Text.LastIndexOf('@') < 5 || txtEmail.Text.IndexOf('@') < 3)
            {
                MessageBox.Show("Email geçersiz.");
                txtEmail.Focus();
                return false;
            }
            if (mtxtNumber.TextLength < 1)
            {
                MessageBox.Show("Telefon numarası boş bırakılamaz");
                mtxtNumber.Focus();
                return false;
            }
            if (mtxtNumber.TextLength < 11)
            {
                MessageBox.Show("Telefon numaranızı tam yazınız.");
                mtxtNumber.Focus();
                return false;
            }
            if (mtxtTckn.TextLength < 1)
            {
                MessageBox.Show("TCKN boş bırakılamaz");
                mtxtTckn.Focus();
                return false;
            }
            if (mtxtTckn.TextLength < 11)
            {
                MessageBox.Show("TC Kimlik Numaranızı tam yazınız.");
                mtxtTckn.Focus();
                return false;
            }
            foreach (char item in turkishChars)
            {
                if (txtUserName.Text.IndexOf(item) != -1)
                {
                    MessageBox.Show("Kullanıcı adında Türkçe karakter kullanılamaz.");
                    txtUserName.Focus();
                    return false;
                }
            }
            foreach (char item in specialChars)
            {
                if (txtUserName.Text.IndexOf(item) != -1)
                {
                    MessageBox.Show("Kullanıcı adında '" + item.ToString() + "' karakteri kullanılamaz.");

                    txtUserName.Focus();
                    return false;
                }
            }
            if (txtUserName.Text.Length < 4)
            {
                MessageBox.Show("Kullanıcı adı 4 harften küçük olamaz.");
                txtUserName.Focus();
                return false;
            }
            if (dtBirthDate.Value.Year > 2010)
            {
                MessageBox.Show("Doğum tarihiniz 2010'dan küçük olmalı.");
                dtBirthDate.Focus();
                return false;
            }
            if (txtPassword.Text != txtPasswordConfirmed.Text)
            {
                MessageBox.Show("Şifreler farklı olamaz.");
                txtPasswordConfirmed.Focus();
                return false;
            }
            if (txtPassword.Text.Length < 4)
            {
                MessageBox.Show("Şifre en az 4 haneli olmalı.");
                txtPassword.Focus();
                return false;
            }

            if (!rbMr.Checked && !rbMrs.Checked)
            {
                MessageBox.Show("Cinsiyet boş bırakılamaz");
                //rbMr.Focus();
                return false;
            }
            if (txtAdress.Text.Length < 10)
            {
                MessageBox.Show("Adresinizi tam giriniz.");
                txtAdress.Focus();
                return false;
            }
            if (txtSecurityQuestion.Text == "")
            {
                MessageBox.Show("Sıfırlama sorusu boş bırakılamaz.");
                txtSecurityQuestion.Focus();
                return false;
            }
            if (txtSecurityAnswer.Text == "")
            {
                MessageBox.Show("Sıfırlama cevabı boş bırakılamaz.");
                txtSecurityAnswer.Focus();
                return false;
            }


            return true;
        }
        public void Register()
        {

            int cinsiyet = 0;
            Guid id = Guid.NewGuid();
            if (rbMr.Checked)
            {
                cinsiyet = 1;
            }
            else
            {
                cinsiyet = 2;
            }

            userModel = new User
            {
                Id = id,
                Name = txtName.Text,
                Surname = txtSurname.Text,
                Email = txtEmail.Text,
                IdentityNumber = mtxtTckn.Text,
                Address = txtAdress.Text,
                Password = txtPassword.Text,
                PasswordConfirmed = txtPasswordConfirmed.Text,
                PhoneNumber = mtxtNumber.Text,
                BirthDate = dtBirthDate.Value,
                UserName = txtUserName.Text,
                Gender = cinsiyet,
                SecurityQuestion = txtSecurityQuestion.Text,
                SecurityAnswer = txtSecurityAnswer.Text,
            };

            MessageBox.Show("Kayıt Başarılı.");
            this.Close();
        }
    }
}
