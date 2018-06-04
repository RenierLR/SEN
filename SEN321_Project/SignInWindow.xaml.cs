using ClassLibrary;
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

        private void Authenticate(object sender, RoutedEventArgs e)
        {
            try
            {
                string server = "LDAP://192.168.2.222/DC=howldev,DC=local";

                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "howldev");

                // To validate if the user credentials is in the system
                bool validated = ctx.ValidateCredentials(txtUsername.Text, txtPassword.Password);

                if (validated == true)
                {
                    // To get all the information related to the user
                    UserPrincipal user = UserPrincipal.FindByIdentity(ctx, txtUsername.Text);

                    // To validate if the user is not disabled
                    if (user.Enabled == true)
                    {
                        NavigateFromSignIn();
                    } else {
                        MessageBox.Show("Sign In Failed");
                    }
                }
                else
                {
                    MessageBox.Show("Sign In Failed");
                }
            }
                catch(Exception se)
            {
                ErrorLog.getInstance().ErrorLogWrite(new List<string> { string.Format("Exception on sign in: {0} on {1}", se.Message, DateTime.UtcNow.ToLongDateString()) });
                MessageBox.Show("Sign In Failed");
            }
            

        }

        private void NavigateFromSignIn()
        {
            var newCallCentre = new CallCentre(); //create new form.
            newCallCentre.Show(); //show the new form.
            this.Close(); //close the current form.
        }
    }
}
