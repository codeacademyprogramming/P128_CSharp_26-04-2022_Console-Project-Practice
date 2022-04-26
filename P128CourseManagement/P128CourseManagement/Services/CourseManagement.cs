using System;
using System.Collections.Generic;
using System.Text;
using P128CourseManagement.Enums;
using P128CourseManagement.Models;
using P128CourseManagement.Interfaces;

namespace P128CourseManagement.Services
{
    class CourseManagement : ICourseManagement
    {
        private Group[] _groups;

        public Group[] Groups { get => _groups; }

        public CourseManagement()
        {
            _groups = new Group[0];
        }

        public void AddGroup(GroupType groupType, byte limit)
        {
            Group group = new Group(groupType, limit);
            Array.Resize(ref _groups, _groups.Length + 1);
            _groups[_groups.Length - 1] = group;
        }

        public void AddStudent(string name, string surname, byte age, StudentType studentType, string groupNo)
        {
            #region Old Version
            //for (int i = 0; i < _groups.Length; i++)
            //{
            //    Group group = _groups[i];
            //    if (group.No == groupNo.ToUpper())
            //    {

            //    }
            //}
            #endregion

            foreach (Group group in _groups)
            {
                if (group.No == groupNo.ToUpper())
                {
                    if (group.Limit > group.Students.Length)
                    {
                        Student student = new Student(name, surname, age, studentType, groupNo);
                        Array.Resize(ref group.Students, group.Students.Length + 1);
                        group.Students[group.Students.Length - 1] = student;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Qrupda Yer Yoxdur");
                        return;
                    }
                }
            }
            Console.WriteLine($"Daxil Edilen Qrup Nomreso {groupNo} Yanlisdir");
        }

        public void EditGroup(string groupNo, byte limit)
        {
            Group group = FindGroupByNo(groupNo);

            if (group != null)
            {
                if (limit >= group.Students.Length)
                {
                    group.Limit = limit;
                    return;
                }
                else
                {
                    Console.WriteLine($"Daxil Etdiyniz Say: {limit} Telebe Siyahi Sayini Asir");
                    return;
                }
            }
            Console.WriteLine($"Daxil Edilen Qrup Nomreso {groupNo} Yanlisdir");

            //foreach (Group group in _groups)
            //{
            //    if (group.No == groupNo.ToUpper())
            //    {
            //        if (limit >= group.Students.Length)
            //        {
            //            group.Limit = limit;
            //            return;
            //        }
            //        else
            //        {
            //            Console.WriteLine($"Daxil Etdiyniz Say: {limit} Telebe Siyahi Sayini Asir");
            //            return;
            //        }
            //    }
            //}
            //Console.WriteLine($"Daxil Edilen Qrup Nomreso {groupNo} Yanlisdir");
        }

        public void EditStudnet(string groupNo, int studentId, string name, string surname, byte age)
        {
            foreach (Group group in _groups)
            {
                if (group.No == groupNo.ToUpper())
                {
                    foreach (Student student in group.Students)
                    {
                        if (student.Id == studentId)
                        {
                            student.Name = name;
                            student.SurNama = surname;
                            student.Age = age;
                            return;
                        }
                    }
                    Console.WriteLine($"Daxil Telebe Id-si {studentId} Yanlisdir");
                    return;
                }
            }
            Console.WriteLine($"Daxil Edilen Qrup Nomreso {groupNo} Yanlisdir");
        }

        public Group[] GetGroups()
        {
            return _groups;
        }

        public Student[] GetStudents()
        {
            Student[] allStudents = new Student[0];

            foreach (Group group in _groups)
            {
                foreach (Student student in group.Students)
                {
                    Array.Resize(ref allStudents, allStudents.Length + 1);
                    allStudents[allStudents.Length - 1] = student;
                }
            }

            return allStudents;
        }

        public Student[] GetStudentsByGroupNo(string groupNo)
        {
            Student[] students = new Student[0];

            foreach (Group group in _groups)
            {
                if (group.No == groupNo.ToUpper())
                {
                    students = group.Students;
                }
            }

            return students;
        }

        public Group FindGroupByNo(string groupNo)
        {
            foreach (Group group in _groups)
            {
                if (group.No == groupNo.ToUpper())
                {
                    return group;
                }
            }

            return null;
        }

        public void RemoveStudnet(string groupNo, int studentId)
        {
            Group group = FindGroupByNo(groupNo);

            if (group != null)
            {
                for (int i = 0; i < group.Students.Length; i++)
                {
                    if (group.Students[i].Id == studentId)
                    {
                        group.Students[i] = group.Students[group.Students.Length - 1];
                        Array.Resize(ref group.Students, group.Students.Length - 1);
                        return;
                    }
                }
                Console.WriteLine($"Daxil Edilen Id-li {studentId} Sistemde Tapilmadi");
                return;
            }
            Console.WriteLine($"Daxil Edilen Qrup Nomresi {groupNo} Sistemde Tapilmadi");
        }
    }
}
