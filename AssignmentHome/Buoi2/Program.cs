using System;

namespace Buoi2; // Note: actual namespace depends on the project name.

internal class Program
{
    public static void Main(string[] args)
    {
        List<Member> memberList = new List<Member>();
        memberList.Add(new Member("Chu", "Luan", "Male", new DateTime(2001, 11, 22), "0981716630", "Ha Noi", true));
        memberList.Add(new Member("le", "tuan", "Male", new DateTime(2001, 11, 22), "0981716630", "Ha Noi", true));
        memberList.Add(new Member("nguyen", "linh", "FeMale", new DateTime(1999, 11, 22), "0981716630", "ha noi", true));
        memberList.Add(new Member("pham", "tuan", "Male", new DateTime(2000, 11, 22), "0981716630", "viet nam", true));
        memberList.Add(new Member("le", "tu", "Male", new DateTime(2000, 11, 22), "0981716630", "viet nam", true));
        memberList.Add(new Member("meo", "tuan", "Male", new DateTime(2000, 11, 22), "0981716630", "thai binh", true));

        System.Console.WriteLine("----------------");
        System.Console.WriteLine("cau1:List member gender = Male");

        var maleList = from s in memberList where s.Gender == "Male" select s;

        foreach (Member member in maleList)
        {
            member.Display();
        }

        System.Console.WriteLine("----------------");
        System.Console.WriteLine("cau2:List member who is oldest one");

        var oldList = memberList.OrderByDescending(x => x.Age).ToList();

        foreach (Member member in oldList)
        {
            member.Display();
            break;
        }

        System.Console.WriteLine("----------------");
        System.Console.WriteLine("cau3:List member that contains Full Name only");

        var fullNameList = from c in memberList
                           select c;

        foreach (Member member in fullNameList)
        {
            member.FullName();
        }

        System.Console.WriteLine("----------------");
        System.Console.WriteLine("cau5:List member who has born in Ha Noi");

        string str = "Ha Noi";
        var haNoiList = from c in memberList where c.BirthPlace.ToLower() == str.ToLower() select c;

        foreach (Member member in haNoiList)
        {
            member.Display();
            break;
        }


        System.Console.WriteLine("----------------");
        System.Console.WriteLine("cau4:List member who has birth year ?");
        System.Console.WriteLine("1.List member who has birth year is 2000");
        System.Console.WriteLine("2.List member who has birth year > 2000");
        System.Console.WriteLine("3.List member who has birth year < 2000");

        int option = 0;

        do
        {
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    {
                        System.Console.WriteLine("List member who has birth year is 2000");

                        var bornList = from c in memberList where c.DOB.Year == 2000 select c;

                        foreach (Member member in bornList)
                        {
                            member.Display();
                        }
                        break;
                    };
                case 2:
                    {
                        System.Console.WriteLine("List member who has birth year > 2000");

                        var bornList = from c in memberList where c.DOB.Year > 2000 select c;

                        foreach (Member member in bornList)
                        {
                            member.Display();
                        }
                        break;
                    };
                case 3:
                    {
                        System.Console.WriteLine("List member who has birth year < 2000");

                        var bornList = from c in memberList where c.DOB.Year < 2000 select c;

                        foreach (Member member in bornList)
                        {
                            member.Display();
                        }
                        break;
                    };
            }
        } while (option >= 1 && option <= 3);




    }
}