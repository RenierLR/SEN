using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class Appointment
    {
        #region Fields
        private Guid appointmentGuid;

        private Guid appointmentClient;

        private DateTime appointmentDate;

        private DateTime requestDate;

        private string appointmentOperation;

        private Guid appointmentTechnician;

        private string appointmentContractIdentifier;
        #endregion

        #region Properties
        public string contractIdentifier
        {
            get { return appointmentContractIdentifier; }
            set { appointmentContractIdentifier = value; }
        }

        public Guid technician
        {
            get { return appointmentTechnician; }
            //set { appointmentTechnician = value; }
        }

        public string operation
        {
            get { return appointmentOperation; }
            set { appointmentOperation = value; }
        }

        public DateTime rDate
        {
            get { return requestDate; }
            set { requestDate = value; }
        }

        public DateTime aDate
        {
            get { return appointmentDate; }
            set { appointmentDate = value; }
        }

        public Guid client
        {
            get { return appointmentClient; }
            //set { appointmentClient = value; }
        }

        public Guid guid
        {
            get { return appointmentGuid; }
            //set { appointmentGuid = value; }
        }
        #endregion

        #region Constructors
        public Appointment()
        {

        }

        public Appointment(Guid AppointmentGuidParam, Guid Client, DateTime AppointmentDate, DateTime RequestDate, string Operation, Guid Technician, string ContractIdentifier)
        {
            this.appointmentGuid = AppointmentGuidParam;
            this.appointmentClient = Client;
            this.aDate = AppointmentDate;
            this.rDate = RequestDate;
            this.operation = Operation;
            this.appointmentTechnician = Technician;
            this.contractIdentifier = ContractIdentifier;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            Appointment newObj = obj as Appointment;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.appointmentGuid == newObj.appointmentGuid);
        }

        public override int GetHashCode()
        {
            return appointmentGuid.GetHashCode() ^ appointmentClient.GetHashCode() ^ appointmentTechnician.GetHashCode() ^ contractIdentifier.GetHashCode() ^ operation.GetHashCode() ^ rDate.GetHashCode() ^ aDate.GetHashCode();
        }

        public override string ToString()
        {
            return "contract identifier: "+contractIdentifier+", operation: "+operation+", request date: "+rDate+", appointment date: "+aDate;
        }
        #endregion

        #region Method to get all the appointments from the database

        public List<Appointment> getAllAppointments() {
            DataHandler.DataHandler dataAccess = new DataHandler.DataHandler();

            List<Appointment> appointments = new List<Appointment>();

            DataTable results = dataAccess.returnQuery("getAllAppointments", new Dictionary<string, string>());

            foreach (DataRow appointmentRow in results.Rows)
            {

                Appointment newAppointment = new Appointment((Guid)appointmentRow["AglobalUniqueID"],
                                                             (Guid)appointmentRow["client_guid"],
                                                             (DateTime)appointmentRow["appointmentDate"],
                                                             (DateTime)appointmentRow["requestDate"],
                                                             (string)appointmentRow["taskType"],
                                                             (Guid)appointmentRow["technician_guid"],
                                                             (string)appointmentRow["contractIdentifier"]);
                appointments.Add(newAppointment);
            }

            return appointments;
        }

        #endregion

        #region Method to insert new appointment

        public void newAppointment() {
            DataHandler.DataHandler dataAccess = new DataHandler.DataHandler();

            string spName = "insertAppointment";
            Dictionary<string, string> paramaters = new Dictionary<string, string>();

            paramaters.Add("@AppointmentGlobalUniqueID", this.guid.ToString());
            paramaters.Add("@ClientGlobalUniqueID", this.client.ToString());
            paramaters.Add("@RequestDate", this.rDate.ToString());
            paramaters.Add("@TaskType", this.operation);

            dataAccess.nonQuery(spName, paramaters);
        }

        #endregion

        public void deleteAppointment() { }

        public void updateAppointment() { }
    }
}
