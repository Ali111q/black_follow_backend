namespace GaragesStructure.Entities;

public abstract class Person:BaseEntity<Guid>
{
    public String Name { get; set; }
}

public class Doctor : Person
{
    public string Speciality { get; set; }
}

public class Patient : Person
{
    public string Disease { get; set; }
}