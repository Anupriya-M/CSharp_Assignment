using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApplicationn
{
    class BeneficiaryDetails
    {
        private static int autoIncrementRegNo = 1000;

        public int RegNumber { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string City { get; set; }

        public List<VaccineDetails> VaccDetails
        {
            get; set;
        }


        public BeneficiaryDetails(string name, int age, Gender gender, long phNumber, string city)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = Gender;
            this.PhoneNumber = phNumber;
            this.City = city;
            this.RegNumber = autoIncrementRegNo++;

        }



    }
    public enum Gender
    {
        Male = 1,
        Female,
        Others
    }
}

