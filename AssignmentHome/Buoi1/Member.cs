using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi1
{
    public class Member
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DOB { get; set; }
        public string Phone { get; set; }
        public string BirthPlace { get; set; }

        public uint Age
        {
            get
            {
                return ((uint)(DateTime.Now.Year - DOB.Year));
            }
        }
        public bool IsGraduated { get; set; }

        public Member(string firstName, string lastName, string gender, DateTime dob, string phone,
        string birthPlace, bool isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DOB = dob;
            Phone = phone;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }
        public void ShowFullName()
        {
            System.Console.WriteLine($"Full name of member: {FirstName} {LastName}");
        }

        public void DisplayInfo()
        {
            string graduated = (IsGraduated) ? "Yes" : "No";

            System.Console.WriteLine($"FirstName: {FirstName} , LastName: {LastName} , Gender: {Gender} ," +
            $" DOB: {DOB.ToString("dd/MM/yyyy")} , Phone: {Phone} , BP: {BirthPlace} , Age: {Age} , IsGraduated: {graduated}");
        }

    }
}