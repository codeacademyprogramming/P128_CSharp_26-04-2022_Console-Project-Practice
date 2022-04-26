using System;
using System.Collections.Generic;
using System.Text;
using P128CourseManagement.Enums;
using P128CourseManagement.Models;

namespace P128CourseManagement.Interfaces
{
    interface ICourseManagement
    {
        public Group[] Groups { get; }
        void AddGroup(GroupType groupType, byte limit);
        void AddStudent(string name, string surname, byte age, StudentType studentType, string groupNo);
        void EditGroup(string groupNo, byte limit);
        void EditStudnet(string groupNo, int studentId, string name, string surname, byte age);
        Student[] GetStudents();
        Student[] GetStudentsByGroupNo(string groupNo);
        Group[] GetGroups();
        void RemoveStudnet(string groupNo, int studentId);
    }
}
