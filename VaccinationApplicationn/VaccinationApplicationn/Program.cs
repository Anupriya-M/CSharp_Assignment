using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VaccinationApplicationn
{
    class Program
    {
        private static List<BeneficiaryDetails> ben_Details = new List<BeneficiaryDetails>();
        static void Main(string[] args)
        {

            Program user = new Program();

            string choice;

            //Beneficiary Registration Process
            Console.WriteLine("                                             WELCOME TO THE VACCINATION DRIVE                            ");
            do
            {
                Console.WriteLine("------------------------MAIN MENU-----------------------");
                Console.WriteLine("\n 1.Beneficiary Registration \n 2.Vaccination \n 3.Exit \n");
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        user.BenificiaryRegistration();
                        break;
                    case 2:
                        user.Vaccination();
                        break;
                    case 3:
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.Write("Enter Valid Option...!");
                        break;

                }
                
                Console.WriteLine("Do you want to continue to main menu (YES/NO)? ");
                choice = Console.ReadLine().ToUpper();
            } while (choice == "YES");
            Console.ReadKey();

        }

        //  Getting Beneficiary details
        public void BenificiaryRegistration()
        {

            Console.Write("Enter Name:");
            string BeneficiaryName = Console.ReadLine();
            Console.Write("Enter Age:");
            int Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Choose Your Gender:1.Male 2.Female 3.Others");
            Gender Gender = (Gender)int.Parse(Console.ReadLine());
            Console.Write("Enter PhoneNumber:");
            long PhoneNumber = long.Parse(Console.ReadLine());
            Console.Write("Enter City:");
            string city = Console.ReadLine();


            var add = new BeneficiaryDetails(BeneficiaryName, Age, (Gender)Gender, PhoneNumber, city);
            ben_Details.Add(add);
            Console.WriteLine(" Registration Number: "+add.RegNumber);

        }


        // Vaccination Menu Process
        public void Vaccination()
        {

            string option;
           
            Console.WriteLine("----------------------Vaccine Details-------------------------");
            Console.Write("Enter Your Registration Number:");
            int RegNo = int.Parse(Console.ReadLine());
            foreach (BeneficiaryDetails details in ben_Details)
            {
                if (details.RegNumber == RegNo)
                {
      

                    do
                    {
                        Console.WriteLine("-------------------------VACCINE MENU ---------------------------");
                        Console.WriteLine("\n 1.Take Vaccination \n 2.Vaccination History\n 3.Next Due Date \n 4.Exit \n");
                        int choice = int.Parse(Console.ReadLine());

                        switch (choice)
                        {
                            case 1:
                                Console.WriteLine("Vaccine you prefer?");
                                Console.WriteLine("1.CoVaccine \n2.Covishield \n3.Sputniic\n");
                                
                                
                                int vacc_Count = 1; 
                                VacType VaccineType = (VacType)int.Parse(Console.ReadLine());
                                if (details.RegNumber == RegNo)
                                {
                                    if (vacc_Count == 1)
                                    {
                                        VaccineDetails user = new VaccineDetails(VaccineType, DateTime.Now, vacc_Count);

                                        if (details.VaccDetails == null)
                                        {

                                            details.VaccDetails = new List<VaccineDetails>();
                                        }
                                        details.VaccDetails.Add(user);
                                        vacc_Count++;
                                    }

                                    Console.WriteLine("You have been Successfully vaccinated");
                                }
                                else if(vacc_Count == 2)
                                {
                                    VaccineDetails user = new VaccineDetails(VaccineType, DateTime.Now, vacc_Count);

                                    if (details.VaccDetails == null)
                                    {

                                        details.VaccDetails = new List<VaccineDetails>();
                                    }
                                    details.VaccDetails.Add(user);
                                    Console.WriteLine("You have been Completed your vaccination course......");
                                    Console.WriteLine("Thank you for your participation");
                                    vacc_Count++;
                                }
                                else
                                {
                                    Console.WriteLine("You have completed both the doses.");
                                }

                                break;

                            case 2:
                                VaccHistory(RegNo);
                                break;
                            case 3:
                                NextDueDate(RegNo);
                                break;
                            case 4:
                                Environment.Exit(-1);
                                break;
                            default:
                                Console.WriteLine("Enter Valid Option:");
                                break;
                        }
                        Console.WriteLine("Do you want to continue to vaccine menu-(Yes/NO)??");
                        option = Console.ReadLine().ToUpper();

                    } while (option == "YES");
                }

            }
        }

        public void VaccHistory(int registerNumber)
        {
            foreach (BeneficiaryDetails i in ben_Details)
            {
                if (i.RegNumber == registerNumber)
                {
                    if (i.VaccDetails != null)
                    {

                        Console.WriteLine($"Registratuion Number:{ i.RegNumber} \n BeneficiaryName:{i.Name}\n Vaccinated Dose: {i.VaccDetails.Count}");
                    }

                }

            }
        }

        // Next due date  
        public void NextDueDate(int regNo)
        {
            foreach (BeneficiaryDetails i in ben_Details)
            {
                if (i.RegNumber == regNo)
                {
                    if (i.VaccDetails != null)
                    {
                        if (i.VaccDetails.Count == 1)
                        {

                            Console.WriteLine("You are vaccinated by " + i.VaccDetails.Count);
                            Console.WriteLine("Your next Due Date is: " + i.VaccDetails[0].VaccinatedDate.AddDays(30));

                        }
                        else if (i.VaccDetails.Count == 2)
                        {
                            Console.WriteLine("You have successfully completed the vaccination course....Thanks for your participation in the vaccination drive.");
                        }

                    }
                }

            }

        }
    }
}
