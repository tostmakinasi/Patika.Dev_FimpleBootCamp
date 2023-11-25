using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EncapsulationProperty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            student.Name = "Berk";
            student.LastName = "Turgut";
            student.StudentNo = 611;
            student.Grade = 3;

            student.GetStudentInfo();

            student.UpGrade();
            student.GetStudentInfo();

            Student studentTwo = new Student("Ali", "Deniz", 256, 1,1);
            studentTwo.GetStudentInfo();
            studentTwo.DownGrade();
            studentTwo.DownGrade();
            studentTwo.GetStudentInfo();
        }
    }
}
class Student
{
    //field declaration. 
    private string _name;
    private string _lastName;
    private int _studentNo;
    private int _grade;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    //equals to :
    // public string Name
    // {
    //     get{return name;} //get method
    //     set{name = value;} // set method
    // }

    public string LastName { get => _lastName; set => _lastName = value; }
    public int StudentNo { get => _studentNo; set => _studentNo = value; }
    public int Grade
    {
        get => _grade;
        set
        {  //We add basic negative number logic. If we add this to the method it can be hack but prop is secure enough.
            if (value < 1)
            {
                Console.WriteLine("Grade can't be 0 or negative.");
                _grade = 1;
            }
            else
                _grade = value;
        }
    }

    public Student(string name, string lastName, int studentNo = 0, int room = 0, int grade = 1)
    {
        Name = name;
        LastName = lastName;
        StudentNo = studentNo;
        Grade = grade;
    }

    public Student() { }

    public void GetStudentInfo()
    {
        Console.WriteLine("****Student Informations****");
        Console.WriteLine("Student Name   : {0}", this.Name);
        Console.WriteLine("Student LastName   : {0}", this.LastName);
        Console.WriteLine("Student No   : {0}", this.StudentNo);
        Console.WriteLine("Student Grade   : {0}", this.Grade);
    }

    public void DownGrade()
    {
        this.Grade = this.Grade - 1;
    }

    public void UpGrade()
    {
        this.Grade = this.Grade + 1;
    }





}