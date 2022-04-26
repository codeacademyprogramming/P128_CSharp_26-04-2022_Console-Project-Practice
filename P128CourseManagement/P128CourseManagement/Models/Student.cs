using System;
using System.Collections.Generic;
using System.Text;
using P128CourseManagement.Enums;

namespace P128CourseManagement.Models
{
    class Student
    {
        private static int _count;
        public readonly int Id;
        public StudentType StudentType { get; set; }
        public string Name { get; set; }
        public string SurNama { get; set; }
        public byte Age { get; set; }
        public string GroupNo { get; set; }

        static Student()
        {
            _count = 0;
        }

        public Student(string name, string surname, byte age, StudentType studentType, string groupNo)
        {
            StudentType = studentType;
            Name = name;
            SurNama = surname;
            Age = age;
            GroupNo = groupNo;
            _count++;
            Id = _count;
        }

        public override string ToString()
        {
            string varantyType = (int)StudentType == 1 ? "Zemanetli" : "Zemanetsiz";
            return $"Id: {Id} Ad: {Name} SoyAd: {SurNama} Yas: {Age} Zemanet Novu: {varantyType}";
        }
    }
}
