using System;
using System.Collections.Generic;

public abstract class OrganizationComponent
{
    protected string _name;
    protected string _position;

    public OrganizationComponent(string name, string position)
    {
        _name = name;
        _position = position;
    }

    public abstract void Display(int depth);
    public abstract decimal CalculateBudget();
    public abstract int CalculateStaffCount();

    public virtual void Add(OrganizationComponent component)
    {
        throw new NotImplementedException();
    }

    public virtual void Remove(OrganizationComponent component)
    {
        throw new NotImplementedException();
    }
}

public class Employee : OrganizationComponent
{
    private decimal _salary;

    public Employee(string name, string position, decimal salary)
        : base(name, position)
    {
        _salary = salary;
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Employee: " + _name + ", Position: " + _position + ", Salary: " + _salary);
    }

    public override decimal CalculateBudget()
    {
        return _salary;
    }

    public override int CalculateStaffCount()
    {
        return 1;
    }
}

public class Department : OrganizationComponent
{
    private List<OrganizationComponent> _components = new List<OrganizationComponent>();

    public Department(string name)
        : base(name, "Department")
    { }

    public override void Add(OrganizationComponent component)
    {
        _components.Add(component);
    }

    public override void Remove(OrganizationComponent component)
    {
        _components.Remove(component);
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Department: " + _name);
        foreach (var component in _components)
        {
            component.Display(depth + 2);
        }
    }

    public override decimal CalculateBudget()
    {
        decimal totalBudget = 0;
        foreach (var component in _components)
        {
            totalBudget += component.CalculateBudget();
        }
        return totalBudget;
    }

    public override int CalculateStaffCount()
    {
        int totalStaff = 0;
        foreach (var component in _components)
        {
            totalStaff += component.CalculateStaffCount();
        }
        return totalStaff;
    }
}

public class Contractor : OrganizationComponent
{
    private decimal _fixedPayment;

    public Contractor(string name, string position, decimal fixedPayment)
        : base(name, position)
    {
        _fixedPayment = fixedPayment;
    }

    public override void Display(int depth)
    {
        Console.WriteLine(new string('-', depth) + " Contractor: " + _name + ", Position: " + _position);
    }

    public override decimal CalculateBudget()
    {
        return 0;
    }

    public override int CalculateStaffCount()
    {
        return 1;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Employee emp1 = new Employee("John Doe", "Developer", 5000);
        Employee emp2 = new Employee("Jane Smith", "Designer", 4500);
        Employee emp3 = new Employee("Mike Johnson", "Manager", 7000);
        Contractor contractor1 = new Contractor("Sam Brown", "Temporary Developer", 3000);

        Department itDepartment = new Department("IT Department");
        Department marketingDepartment = new Department("Marketing Department");

        itDepartment.Add(emp1);
        itDepartment.Add(emp2);
        marketingDepartment.Add(emp3);
        itDepartment.Add(contractor1);

        Department headOffice = new Department("Head Office");
        headOffice.Add(itDepartment);
        headOffice.Add(marketingDepartment);

        headOffice.Display(1);

        Console.WriteLine("\nTotal Budget of Head Office: " + headOffice.CalculateBudget());
        Console.WriteLine("Total Staff Count of Head Office: " + headOffice.CalculateStaffCount());
    }
}
