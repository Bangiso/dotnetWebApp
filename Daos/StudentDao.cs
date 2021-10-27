using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using  dotnetWebApp.Models;
using  dotnetWebApp.Services;

namespace dotnetWebApp.Daos
{
    public class StudentDao: StudentService
    {

        private readonly ILogger<StudentDao> _logger;
        private static string connStr = "server=localhost;user=user;password=user;database=StudentDB";

        public StudentDao(){
        }
        public StudentDao(ILogger<StudentDao> logger) =>
                _logger = logger;

        public List<StudentViewModel> getStudents() {
            MySqlConnection conn = new MySqlConnection(connStr);
            List<StudentViewModel> students = new List<StudentViewModel>();
            try
            {
                conn.Open();

                string sql = "SELECT id, name, gpa From students";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    students.Add(new StudentViewModel((int) rdr[0], (string) rdr[1], (double) rdr[2]));
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return students;
        }

        public StudentViewModel getStudentById( int id) {
             MySqlConnection conn = new MySqlConnection(connStr);
            var student = new StudentViewModel();
            try
            {
                conn.Open();
                string sql = $"SELECT id, name, gpa From students  where id = {id}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                   student.Id = (int) rdr[0];
                   student.Name = (string) rdr[1];
                   student.Gpa = (double) rdr[2];
                }
                rdr.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            conn.Close();
            return student;
        }

        public string addStudent( StudentViewModel student) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = $"INSERT INTO students (id, name, gpa) VALUES ({student.Id}, '{student.Name}', {student.Gpa})";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return $"Student with id {student.Id} added";
            }
            catch (MySqlException ex)
            {
                string msg = $"Student, with id {student.Id} already exists.";
                Console.WriteLine($"Post action failed, student with id {student.Id}  already exists.");
                conn.Close();
                return msg;
            }

        }

        public string updateStudent( StudentViewModel student) {
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                conn.Open();
                string sql = $"UPDATE students  set name = '{student.Name}', gpa = {student.Gpa} where id = {student.Id}";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                conn.Close();
                return $"Student with id {student.Id} updated";
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Student not found.");
                conn.Close();
                 return $"Student with id {student.Id}, not found.";
            }
        }

         public string removeStudent(int id) {
            MySqlConnection conn = new MySqlConnection(connStr);
             try
             {
                 conn.Open();
                 string sql = $"DELETE FROM students WHERE id  = {id}";
                 MySqlCommand cmd = new MySqlCommand(sql, conn);
                 cmd.ExecuteNonQuery();
                 conn.Close();
                 return $"Student with id {id} deleted";
             }
             catch (MySqlException ex)
             {
                 Console.WriteLine("Student with id {id}, not found.");
                 conn.Close();
                 return $"Student with id {id}, not found.";
             }

         }
    }
}