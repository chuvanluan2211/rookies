namespace Buoi6_MVC_2.Models
{
    public class PersonModel
    {
        public string?  FirstName { get; set; }

        public string?  LastName { get; set; }

        public string?  Gender { get; set; }

        public DateTime?  DOB { get; set; }

        public string?  PhoneNumber { get; set; }

        public string?  BirthDay { get; set; }

        public bool?  IsGraduated { get; set; }

        public int Age
        {
            get
            {
                return DateTime.Now.Year - (DOB?.Year ?? 0);
            }
        }

        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }



    }
}