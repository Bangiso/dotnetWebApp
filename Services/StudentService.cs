using System;
using  dotnetWebApp.Models;

namespace dotnetWebApp.Services
{
    public interface StudentService
    {
        public List<StudentViewModel> getStudents();

        public StudentViewModel getStudentById( int id);

        public string addStudent( StudentViewModel student) ;

        public string updateStudent( StudentViewModel student);

        public string removeStudent(int id);
    }
}