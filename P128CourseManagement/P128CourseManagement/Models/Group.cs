using System;
using System.Collections.Generic;
using System.Text;
using P128CourseManagement.Enums;

namespace P128CourseManagement.Models
{
    class Group
    {
        private static int _count;
        public GroupType GroupType { get; set; }
        public byte Limit { get; set; }
        public readonly string No;

        public Student[] Students;

        static Group()
        {
            _count = 100;
        }

        public Group(GroupType groupType, byte limit)
        {
            Students = new Student[0];
            GroupType = groupType;
            Limit = limit;
            _count++;
            No = $"{groupType.ToString()[0]}{_count}";
        }

        public override string ToString()
        {
            return $"Qrup Nomresi: {No} Qrupun Novu: {GroupType} Qrupun Limiti {Limit}";
        }
    }
}
