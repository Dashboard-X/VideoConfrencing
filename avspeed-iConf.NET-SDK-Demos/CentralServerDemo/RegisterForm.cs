using System;
using System.Windows.Forms;

namespace CentralServerDemo
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = (char)0x25CF;
            txtRePassword.PasswordChar = (char)0x25CF;

            //clear fields
            txtUserName.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            txtNote.Clear();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string error = ValidateFields();
            if (error != String.Empty)
            {
                MessageBox.Show("Please correct the following :\n\n" + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Used to validate registration info (just checks for missing info)
        /// </summary>
        /// <returns>error message or empty string</returns>
        private string ValidateFields()
        {
            string error = String.Empty;

            if (txtUserName.Text.Trim() == String.Empty)
                error += "User name is required\n";

            if (txtPassword.Text.Trim() == String.Empty)
                error += "Password is required\n";

            if (txtPassword.Text != txtRePassword.Text)
                error += "Passwords do not match\n";

            return error;


        }

        private void RegisterForm_Shown(object sender, EventArgs e)
        {
            //clear fields
            txtUserName.Clear();
            txtPassword.Clear();
            txtRePassword.Clear();
            txtNote.Clear();
        }
    }
}