using System;

namespace Buoi1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            List<Member> memberList = new List<Member>();
            memberList.Add(new Member("Chu", "Luan", "Male", new DateTime(2001, 11, 22), "0981716630", "Ha Noi", true));
            memberList.Add(new Member("le", "tuan", "Male", new DateTime(2001, 11, 22), "0981716630", "Ha Noi", true));
            memberList.Add(new Member("nguyen", "linh", "FeMale", new DateTime(1999, 11, 22), "0981716630", "Hanoi", true));
            memberList.Add(new Member("pham", "tuan", "Male", new DateTime(2000, 11, 22), "0981716630", "viet nam", true));
            memberList.Add(new Member("le", "tu", "Male", new DateTime(2000, 11, 22), "0981716630", "viet nam", true));
            memberList.Add(new Member("meo", "tuan", "Male", new DateTime(2000, 11, 22), "0981716630", "thai binh", true));

            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau1:List member gender = Male");

            foreach (Member member in memberList)
            {
                if (member.Gender == "Male")
                {
                    member.DisplayInfo();
                }
            }

            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau2:List member who is oldest one");

            uint max = memberList[0].Age;

            for (int i = 0; i < memberList.Count; i++)
            {
                if (max < memberList[i].Age)
                {
                    max = memberList[i].Age;
                }
            }
            foreach (Member member in memberList)
            {
                if (member.Age == max)
                {
                    member.DisplayInfo();
                    break;
                }
            }

            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau3:List member that contains Full Name only");

            foreach (Member member in memberList)
            {
                member.ShowFullName();
            }

            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau5:List member who has born in Ha Noi");

            int index = 0;

            while (index < memberList.Count)
            {
                var member = memberList[index];
                if (member.BirthPlace == "Ha Noi")
                {
                    member.DisplayInfo();
                    break;
                }
                ++index;
            }


            System.Console.WriteLine("----------------");
            System.Console.WriteLine("cau4:List member who has birth year ?");

            int option = 0;

            do
            {
                option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        {
                            System.Console.WriteLine("List member who has birth year is 2000");

                            foreach (Member member in memberList)
                            {
                                if (member.DOB.Year == 2000)
                                {
                                    member.DisplayInfo();
                                }
                            }
                            break;
                        };
                    case 2:
                        {
                            System.Console.WriteLine("List member who has birth year > 2000");

                            foreach (Member member in memberList)
                            {
                                if (member.DOB.Year > 2000)
                                {
                                    member.DisplayInfo();
                                }
                            }
                            break;
                        };
                    case 3:
                        {
                            System.Console.WriteLine("List member who has birth year < 2000");

                            foreach (Member member in memberList)
                            {
                                if (member.DOB.Year < 2000)
                                {
                                    member.DisplayInfo();
                                }
                            }
                            break;
                        };
                }
            } while (option >= 1 && option <= 3);




        }
    }
}