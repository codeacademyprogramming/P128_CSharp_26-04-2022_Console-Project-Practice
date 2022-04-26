using P128CourseManagement.Enums;
using P128CourseManagement.Models;
using P128CourseManagement.Services;
using System;

namespace P128CourseManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            CourseManagement courseManagement = new CourseManagement();
            do
            {
                Console.Clear();
                Console.WriteLine("=====Welcome Couse Management======\n");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Reqemini Daxil Et\n");
                Console.WriteLine("1. Qrup Elave Et:");
                Console.WriteLine("2. Telebe Elave Et:");
                Console.WriteLine("3. Qrup Uzerinde Deyisiklik Et:");
                Console.WriteLine("4. Telebe Uzerinde Deyisiklik Et:");
                Console.WriteLine("5. Qruplarin Siyahisi:");
                Console.WriteLine("6. Umumi Telebelerin Siyahisi:");
                Console.WriteLine("7. Qrupa Gore Telebelerin Siyahisi:");
                Console.WriteLine("8. Sistemden Cix:");
                string choose = Console.ReadLine();
                int chooseNum;
                while (!int.TryParse(choose, out chooseNum) || chooseNum < 1 || chooseNum > 8)
                {
                    Console.WriteLine("Duzgun Secim Edin:");
                    choose = Console.ReadLine();
                }

                switch (chooseNum)
                {
                    case 1:
                        AddGroup(ref courseManagement);
                        break;
                    case 2:
                        AddStudent(ref courseManagement);
                        break;
                    case 3:
                        EditGroup(ref courseManagement);
                        break;
                    case 4:
                        EditStudnet(ref courseManagement);
                        break;
                    case 5:
                        ShowAllGroups(ref courseManagement);
                        break;
                    case 6:
                        ShowAllStudents(ref courseManagement);
                        break;
                    case 7:
                        ShowAllStudentByGroupNo(ref courseManagement);
                        break;
                    case 8:
                        return;
                }
            } while (true);

        }

        static void AddGroup(ref CourseManagement courseManagement)
        {
            Console.Clear();
            Console.WriteLine("Qrupun Novunu Sec:");
            foreach (var item in Enum.GetValues(typeof(GroupType)))
            {
                Console.WriteLine($"{(int)item} {item}");
            }
            string chooseGroupType = Console.ReadLine();
            int chooseGroupTypeNum;
            while (!int.TryParse(chooseGroupType, out chooseGroupTypeNum) || chooseGroupTypeNum < 1 || chooseGroupTypeNum > 5)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Duzgun Secim Edin:");
                chooseGroupType = Console.ReadLine();
            }
            Console.WriteLine("Qrupun Limiti Yeni Telebe Sayini Daxil Et");
            string chooseLimit = Console.ReadLine();
            byte chooseLimitNum;
            while (!byte.TryParse(chooseLimit, out chooseLimitNum) || chooseLimitNum < 12 || chooseLimitNum > 20)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                chooseLimit = Console.ReadLine();
            }
            courseManagement.AddGroup((GroupType)chooseGroupTypeNum, chooseLimitNum);
        }

        static void AddStudent(ref CourseManagement courseManagement)
        {
            Console.WriteLine("Telebenin Zemanet Novunu Sec:");
            foreach (var item in Enum.GetValues(typeof(StudentType)))
            {
                //string varantyType = "";

                //if ((int)item == 1)
                //{
                //    varantyType = "Zemanetli";
                //}
                //else
                //{
                //    varantyType = "Zemanetsiz";
                //}

                string varantyType = (int)item == 1 ? "Zemanetli" : "Zemanetsiz";

                Console.WriteLine($"{(int)item} {varantyType}");
            }
            string chooseStudentType = Console.ReadLine();
            int chooseStudentNum;
            while (!int.TryParse(chooseStudentType,out chooseStudentNum) || chooseStudentNum < 1 || chooseStudentNum > 2)
            {
                Console.WriteLine("Duzgun Daxil Et:");
                chooseStudentType = Console.ReadLine();
            }
            Console.WriteLine("Telebenin Adini Daxil Et");
            string name = Console.ReadLine();
            Console.WriteLine("Telebenin SoyAdini daxil et");
            string surname = Console.ReadLine();
            Console.WriteLine("Telebenin Yasini daxil Et");
            string agestr = Console.ReadLine();
            byte age;
            while (!byte.TryParse(agestr,out age) || age < 15 || age > 55)
            {
                Console.WriteLine("Duzgun Daxil Et");
                agestr = Console.ReadLine();
            }

            Console.WriteLine("Qruplarin Siyahisinda Telebeni Elave Etmek Isdediyniz Qrupu Nomresini Daxil Et:");
            foreach (Group group in courseManagement.GetGroups())
            {
                Console.WriteLine(group);
            }
            string groupNo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(groupNo) || groupNo.Length != 4)
            {
                Console.WriteLine("Duzgun Daxil Et:");
                groupNo = Console.ReadLine();
            }

            courseManagement.AddStudent(name, surname, age, (StudentType)chooseStudentNum, groupNo);
        }

        static void EditGroup(ref CourseManagement courseManagement)
        {
            Console.WriteLine("Qruplarin Siyahisinda Deyisiklik Etmek Isdediyniz Qrupu Nomresini Daxil Et:");
            foreach (Group group in courseManagement.GetGroups())
            {
                Console.WriteLine(group);
            }
            string groupNo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(groupNo) || groupNo.Length != 4)
            {
                Console.WriteLine("Duzgun Daxil Et:");
                groupNo = Console.ReadLine();
            }

            Console.WriteLine("Qrupun Yeni Limiti Yeni Telebe Sayini Daxil Et");
            string chooseLimit = Console.ReadLine();
            byte chooseLimitNum;
            while (!byte.TryParse(chooseLimit, out chooseLimitNum) || chooseLimitNum < 12 || chooseLimitNum > 20)
            {
                Console.WriteLine("Duzgun Secim Edin:");
                chooseLimit = Console.ReadLine();
            }
            courseManagement.EditGroup(groupNo, chooseLimitNum);
        }

        static void EditStudnet(ref CourseManagement courseManagement)
        {
            Console.WriteLine("Qruplarin Siyahisinda Deyisiklik Etmek Isdediyniz Qrupu Nomresini Daxil Et:");
            foreach (Group group in courseManagement.GetGroups())
            {
                Console.WriteLine(group);
            }
            string groupNo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(groupNo) || groupNo.Length != 4)
            {
                Console.WriteLine("Duzgun Daxil Et:");
                groupNo = Console.ReadLine();
            }

            if (courseManagement.FindGroupByNo(groupNo) == null)
            {
                Console.WriteLine("Daxil Etdiyniz Qrup Nomresi Yanlisdi");
                return;
            }

            Console.WriteLine("Telebelerin Siyahisindan Deyisiklik Etmek Isdediyniz Telebeni Secin:");
            foreach (Student student in courseManagement.GetStudentsByGroupNo(groupNo))
            {
                Console.WriteLine(student);
            }
            string chooseIdStr = Console.ReadLine();
            int chooseIdNum;
            while (!int.TryParse(chooseIdStr, out chooseIdNum) ||chooseIdNum < 1)
            {
                Console.WriteLine("Duzgun Daxil Et:");
                chooseIdStr = Console.ReadLine();
            }
            Console.WriteLine("Telebenin Yeni Adini Daxil Et");
            string name = Console.ReadLine();
            Console.WriteLine("Telebenin Yeni SoyAdini daxil et");
            string surname = Console.ReadLine();
            Console.WriteLine("Telebenin Yeni Yasini daxil Et");
            string agestr = Console.ReadLine();
            byte age;
            while (!byte.TryParse(agestr, out age) || age < 15 || age > 55)
            {
                Console.WriteLine("Duzgun Daxil Et");
                agestr = Console.ReadLine();
            }

            courseManagement.EditStudnet(groupNo, chooseIdNum, name, surname, age);
        }

        static void ShowAllGroups(ref CourseManagement courseManagement)
        {
            foreach (Group group in courseManagement.GetGroups())
            {
                Console.WriteLine(group);
            }
        }

        static void ShowAllStudents(ref CourseManagement courseManagement)
        {
            foreach (Student student in courseManagement.GetStudents())
            {
                Console.WriteLine(student);
            }
        }

        static void ShowAllStudentByGroupNo(ref CourseManagement courseManagement)
        {
            Console.WriteLine("Qruplarin Siyahisinda Qrupun Nomresini Daxil Et:");
            foreach (Group group in courseManagement.GetGroups())
            {
                Console.WriteLine(group);
            }
            string groupNo = Console.ReadLine();
            while (string.IsNullOrWhiteSpace(groupNo) || groupNo.Length != 4)
            {
                Console.WriteLine("Duzgun Daxil Et:");
                groupNo = Console.ReadLine();
            }

            if (courseManagement.FindGroupByNo(groupNo) == null)
            {
                Console.WriteLine("Daxil Etdiyniz Qrup Nomresi Yanlisdi");
                return;
            }

            Console.WriteLine("Telebelerin Siyahisi :");
            foreach (Student student in courseManagement.GetStudentsByGroupNo(groupNo))
            {
                Console.WriteLine(student);
            }
        }
    }
}