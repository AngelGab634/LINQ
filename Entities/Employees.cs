namespace EmployeeManaged.Entities
{
    public class Employee
    {
        public Employee()
        {
        }

        public Guid Id {get; set;}

        public string Name {get; set;}

        public int Age {get; set;}

        public string Departament {get; set;}
    }
}