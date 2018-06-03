using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SEN321_Project
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>
    public partial class SignInWindow : Window
    {
        public SignInWindow()
        {
            InitializeComponent();

            //Button btnSignIn = new Button();
            //btnSignIn.Name = "btnSignIn";
            //btnSignIn.Click += Authenticate;

        }

        [System.Runtime.InteropServices.DllImport("advapi32.dll")]
        public static extern bool LogonUser(string userName, string domainName, string password, int LogonType, int LogonProvider, ref IntPtr phToken);

        private void btnLogin_Click(object sender, EventArgs e)
        {
            bool issuccess = false;
            string username = GetloggedinUserName();

            if (username.ToLowerInvariant().Contains(txtUsername.Text.Trim().ToLowerInvariant()) && username.ToLowerInvariant().Contains(txtDomain.Text.Trim().ToLowerInvariant()))
            {
                issuccess = IsValidateCredentials(txtUsername.Text.Trim(), txtPassword.Password.Trim(), txtDomain.Text.Trim());
            }

            if (issuccess)
                MessageBox.Show("Successfuly Login !!!");
            else
                MessageBox.Show("User Name / Password / Domain is invalid !!!");
        }

        private string GetloggedinUserName()
        {
            System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
            return currentUser.Name;
        }

        private bool IsValidateCredentials(string userName, string password, string domain)
        {
            IntPtr tokenHandler = IntPtr.Zero;
            bool isValid = LogonUser(userName, domain, password, 2, 0, ref tokenHandler);
            return isValid;
        }



        private void Authenticate(object sender, RoutedEventArgs e)
        {
            PrincipalContext pcon = new PrincipalContext(ContextType.Domain);
            if (pcon.ValidateCredentials(txtUsername.Text,
                                       txtPassword.Password,
                                       ContextOptions.Negotiate))
            {
                NavigateFromSignIn();
            }
        }

        private void NavigateFromSignIn()
        {
            var newClientsWindow = new ClientsWindow(); //create new form.
            newClientsWindow.Show(); //show the new form.
            this.Close(); //close the current form.
        }
    }
}
