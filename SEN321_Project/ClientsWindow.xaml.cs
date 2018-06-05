using SmartHomeSystemsClassLibrary;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ClientsWindow.xaml
    /// </summary>
    public partial class ClientsWindow : Window
    {
        List<Client> allClients = new List<Client>();
        //List<string> allClients = new List<string>();

        public ClientsWindow()
        {
            InitializeComponent();

            //Guid a = Guid.NewGuid();
            //Guid cd = Guid.NewGuid();
            //Guid c = Guid.NewGuid();
            //Guid p = Guid.NewGuid();
            //Address newAddress = new Address("South Africa", "Pretoria", "1234", "Montana Park, Hadeda str 139", "N/A", a);
            //ContactDetails newContactDetails = new ContactDetails("maatvanysterenplaat@gmail.com", "0716763742", "N/A", cd);
            //Client newClient = new Client("Renier", "le Roux", "9709265017084", newAddress, newContactDetails, p, "A09876543", c);
            //allClients.Add(newClient);

            //a = Guid.NewGuid();
            //cd = Guid.NewGuid();
            //c = Guid.NewGuid();
            //p = Guid.NewGuid();
            //newAddress = new Address("South Africa", "Pietersburg", "4567", "Sinovelle, Villa", "Rooibok str 26", a);
            //newContactDetails = new ContactDetails("piet123@gmail.com", "0824110293", "0125539080", cd);
            //newClient = new Client("Pieter", "Potgieter", "8711056017084", newAddress, newContactDetails, p, "B00064831", c);
            //allClients.Add(newClient);

            Client client = new Client();
            allClients = client.getAllClients();

            lstClients.ItemsSource = allClients;
        }

        private void ListViewItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if ((lstClients.SelectedIndex>=0) && (lstClients.SelectedIndex<=(allClients.Count-1)))
            {
                txtName.Text = allClients[lstClients.SelectedIndex].name;
                txtSurname.Text = allClients[lstClients.SelectedIndex].surname;
                txtID.Text = allClients[lstClients.SelectedIndex].ID;
                txtCell.Text = allClients[lstClients.SelectedIndex].contactDetails.cellNumber;
                txtTell.Text = allClients[lstClients.SelectedIndex].contactDetails.tellNumber;
                txtEmail.Text = allClients[lstClients.SelectedIndex].contactDetails.email;
                txtCountry.Text = allClients[lstClients.SelectedIndex].address.country;
                txtCity.Text = allClients[lstClients.SelectedIndex].address.city;
                txtPostalCode.Text = allClients[lstClients.SelectedIndex].address.postalCode;
                txtLine1.Text = allClients[lstClients.SelectedIndex].address.street;
                txtLine2.Text = allClients[lstClients.SelectedIndex].address.street2;
            }
            
        }

        private void InsertNew(object sender, RoutedEventArgs e)
        {
            Guid a = Guid.NewGuid();
            Guid cd = Guid.NewGuid();
            Guid c = Guid.NewGuid();
            Guid p = Guid.NewGuid();
            Address newAddress = new Address(txtCountry.Text, txtCity.Text, txtPostalCode.Text, txtLine1.Text, txtLine2.Text, a);
            ContactDetails newContactDetails = new ContactDetails(txtEmail.Text, txtCell.Text, txtTell.Text, cd);
            Client newClient = new Client(txtName.Text, txtSurname.Text, txtID.Text, newAddress, newContactDetails, p, identifierGenerator(), c);
            
            insertNewClient(newClient);

            allClients.Add(newClient);
            lstClients.Items.Refresh();
        }

        private void insertNewClient(Client newClient)
        {
            object locker = new object();

            Task.Run(() => {

                lock (locker)
                {
                    newClient.newClient();
                }

            });
        }

        private string identifierGenerator()
        {
            Random rnd = new Random();
            int random = rnd.Next(1, 5);
            string identifier = "";
            switch (random)
            {
                case 1: identifier = "A"; break;
                case 2: identifier = "B"; break;
                case 3: identifier = "C"; break;
                case 4: identifier = "D"; break;
                case 5: identifier = "E"; break;
                default:
                    break;
            }
            for (int i = 0; i < 8; i++)
            {
                identifier = identifier + rnd.Next(0, 9).ToString();
            }
            return identifier;
        }

        private void StartCall(object sender, RoutedEventArgs e)
        {
            var newCallCentre = new CallCentre(); //create new form.
            newCallCentre.Show(); //show the new form.
        }
    }
}
