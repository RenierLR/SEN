using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartHomeSystemsClassLibrary
{
    public class TechnicalPersonnel : Person
    {
        private List<Appointment> tecnicalSchedule;

        public List<Appointment> schedule
        {
            get { return tecnicalSchedule; }
            set { tecnicalSchedule = value; }
        }

        public TechnicalPersonnel()
        {

        }

        public TechnicalPersonnel(string Name, string Surname, string ID, Address AddressObject, ContactDetails ContactDetailsObject, Guid PersonGuidParam, List<Appointment> Schedule) : base(Name, Surname, ID, AddressObject, ContactDetailsObject, PersonGuidParam)
        {
            this.schedule = Schedule;
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

        public void createTechnician() { }

        public void deleteTechnician() { }

        public void updateTechnician() { }
    }
}
