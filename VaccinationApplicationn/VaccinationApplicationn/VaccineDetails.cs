using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApplicationn
{
    class VaccineDetails
    {
        public VacType VaccineType { get; set; }
        public string Dosage { get; set; }
        public DateTime VaccinatedDate { get; set; }
        public int Vacc_Count;

        public VaccineDetails(VacType vaccineType, DateTime vaccinatedDate,int vacc_Count)
        {
            this.VaccineType = VaccineType;
            this.VaccinatedDate = vaccinatedDate;
            this.Vacc_Count = vacc_Count;
            Vacc_Count++;
        }

    }
    public enum VacType
    {
        Co_vaccine = 1,
        Covishield,
        Sputnic
    }
}
   
