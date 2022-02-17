﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;
        public Classroom(int capacity)
        {
            Capacity = capacity;
            students = new List<Student>();
        }
        public int Capacity { get; set; }
        public int Count { get {return students.Count; }  }

        public string RegisterStudent(Student student)
        {
            if (Count<Capacity)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            return "No seats in the classroom";
        }
        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(x=> (x.FirstName == firstName)&& (x.LastName == lastName)))
            {
                students.Remove(students.Where(x=>(x.FirstName == firstName) && (x.LastName == lastName)).First());
                return $"Dismissed student {firstName} {lastName}";
            }
            return "Student not found";
        }
        public string GetSubjectInfo(string subject)
        {
            if (!students.Any(x=>x.Subject == subject))
            {
                return "No students enrolled for the subject";
            }
            var sb = new StringBuilder();
            sb.AppendLine($"Subject: {subject}");
            sb.AppendLine("Students:");
            foreach (var student in students.Where(x=>x.Subject == subject))
            {
                sb.AppendLine($"{student.FirstName} {student.LastName}");
            }
            return sb.ToString().Trim();
        }
        public int GetStudentCount() => students.Count;
        public Student GetStudent(string firstName, string lastName)
        {
            return students.Where(x=>(x.FirstName == firstName) && (x.LastName == lastName)).FirstOrDefault();
        }
    }
}
