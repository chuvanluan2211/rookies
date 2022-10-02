using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        class Member
        {

            public String FirstName { get; set; }
            public String LastName { get; set; }
            public String Gender { get; set; }
            public DateTime DOB { get; set; }
            public String Phone { get; set; }
            public String BirthPlace { get; set; }
            public int Age { get; set; }
            public bool IsGraduated { get; set; }

            // public Member()
            // {

            // }

            public Member(String firstName, String lastName, String gender, DateTime dob, String phone, String birthPlace, int age, bool isGraduated)
            {
                FirstName = firstName;
                LastName = lastName;
                Gender = gender;
                DOB = dob;
                Phone = phone;
                BirthPlace = birthPlace;
                Age = age;
                IsGraduated = isGraduated;
            }

            public void Display()
            {
                System.Console.WriteLine($"FirstName: {FirstName} , LastName: {LastName} , Gender: {Gender} , DOB: {DOB} , Phone: {Phone} , BP: {BirthPlace} , Age: {Age} , IsGraduated: {IsGraduated}");
            }




        }
        static void Main(string[] args)
        {
            List<Member> MemberList = new List<Member>();
            MemberList.Add(new Member("Chu", "Luan", "Male", new DateTime(2001, 11, 22), "0981716630", "Ha Noi", 21, true));
            MemberList.Add(new Member("le", "tuan", "Male", new DateTime(2001, 11, 22), "0981716630", "Ha Noi", 19, true));
            MemberList.Add(new Member("nguyen", "linh", "FeMale", new DateTime(1999, 11, 22), "0981716630", "Hanoi", 20, true));
            MemberList.Add(new Member("pham", "tuan", "Male", new DateTime(2000, 11, 22), "0981716630", "viet nam", 22, true));
            MemberList.Add(new Member("le", "tu", "Male", new DateTime(2000, 11, 22), "0981716630", "viet nam", 23, true));
            MemberList.Add(new Member("", "tuan", "Male", new DateTime(2000, 11, 22), "0981716630", "thai binh", 12, true));






            foreach (var i in MemberList)
            {
                i.Display();
            }

            System.Console.WriteLine("----------------");


            System.Console.WriteLine("cau1:List member gender = Male");

            foreach (var i in MemberList)
            {
                if (i.Gender == "Male")
                {
                    i.Display();

                }
            }
            System.Console.WriteLine("----------------");

            System.Console.WriteLine("cau2:List member who is oldest one");
            int max = MemberList[0].Age;

            for (int i = 0; i < MemberList.Count; i++)
            {
                if (max < MemberList[i].Age)
                {
                    max = MemberList[i].Age;
                }

            }
            foreach (var i in MemberList)
            {
                if(i.Age == max){
                    i.Display();
                }
            }

            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau3:List member who is oldest one");
            foreach (var i in MemberList)
            {
                if (i.FirstName != "" && i.LastName != "")
                {
                    i.Display();
                }
            }

            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau4:List member who has birth = 2000");
            foreach (var i in MemberList)
            {
                if (i.DOB.Year == 2000)
                {
                    i.Display();
                }
            }
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau4:List member who has birth < 2000");
            foreach (var i in MemberList)
            {
                if (i.DOB.Year < 2000)
                {
                    i.Display();
                }
            }
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau4:List member who has birth > 2000");
            foreach (var i in MemberList)
            {
                if (i.DOB.Year > 2000)
                {
                    i.Display();
                }
            }
            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau5:List member who has born in Ha Noi");
            foreach (var i in MemberList)
            {
                if (i.BirthPlace.Contains("Ha Noi"))
                {
                    i.Display();
                    break;
                }
            }
        }
    }
}