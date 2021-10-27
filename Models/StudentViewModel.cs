namespace dotnetWebApp.Models;

public class StudentViewModel
{
    public int Id { get; set; }

    public string Name  { get; set; }

    public double Gpa  { get; set; }

    public StudentViewModel(){}

    public StudentViewModel(int id,  string name, double gpa){
         Id =id;
         Name = name;
         Gpa = gpa;
    }
}