namespace RW0.student;

public class Person {
    private readonly string name;
    private readonly DateOnly birthday;

    private int age;

    public Person(string name, DateOnly birthday) {
        this.name = name;
        this.birthday = birthday;

        // Set the age the person
        this.age = DateTime.Now.Year - birthday.Year;
    }

    public string Name => name;

    public DateOnly Birthday => birthday;

    public int Age {
        get => age;
        set => age = value;
    }

    public override string ToString() {
        return $"{name}, {age} years old ({birthday})";
    }
}