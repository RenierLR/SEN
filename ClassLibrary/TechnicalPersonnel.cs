using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class TechnicalPersonnel : Person
    {
        #region Fields
        private List<Appointment> tecnicalSchedule;
        #endregion

        #region Properties
        public List<Appointment> schedule
        {
            get { return tecnicalSchedule; }
            set { tecnicalSchedule = value; }
        }
        #endregion

        #region Constructors
        public TechnicalPersonnel()
        {

        }

        public TechnicalPersonnel(string Name, string Surname, string ID, Address AddressObject, ContactDetails ContactDetailsObject, Guid PersonGuidParam, List<Appointment> Schedule) : base(Name, Surname, ID, AddressObject, ContactDetailsObject, PersonGuidParam)
        {
            this.schedule = Schedule;
        }
        #endregion

        #region Overrides
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            TechnicalPersonnel newObj = obj as TechnicalPersonnel;
            if ((object)newObj == null)
            {
                return false;
            }

            return (this.tecnicalSchedule == newObj.tecnicalSchedule);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode() ^ schedule.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
        #endregion

        public void createTechnician() { }

        public void deleteTechnician() { }

        public void updateTechnician() { }
    }
}
