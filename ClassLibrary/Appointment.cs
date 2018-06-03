using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Appointment
    {
        private Client appointmentClient;

        private DateTime appointmentDate;

        private string appointmentOperation;

        private TechnicalPersonnel appointmentTechnician;

        public TechnicalPersonnel technician
        {
            get { return appointmentTechnician; }
            set { appointmentTechnician = value; }
        }

        public string operation
        {
            get { return appointmentOperation; }
            set { appointmentOperation = value; }
        }

        public DateTime date
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }

        public Client client
        {
            get { return appointmentClient; }
            set { appointmentClient = value; }
        }

        public Appointment()
        {

        }

        public Appointment(Client Client, DateTime Date, string Operation, TechnicalPersonnel Technician)
        {
            this.client = Client;
            this.date = Date;
            this.operation = Operation;
            this.technician = Technician;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public void createAppointment() { }

        public void deleteAppointment() { }

        public void updateAppointment() { }
    }
}
