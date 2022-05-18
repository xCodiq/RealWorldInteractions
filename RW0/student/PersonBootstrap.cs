namespace RW0.student;

public class PersonBootstrap {
    static void Main(string[] args) {
        Dictionary<string, DateOnly> personDictionary = new Dictionary<string, DateOnly>();
        personDictionary.Add("Sjaak", new DateOnly(2000, 1, 1));
        personDictionary.Add("Henk", new DateOnly(1999, 6, 4));
        personDictionary.Add("Bob", new DateOnly(1987, 3, 29));
        personDictionary.Add("Alice", new DateOnly(1956, 9, 6));

        var persons = new List<Person>();
        foreach (var (name, birthday) in personDictionary) {
            persons.Add(new Person(name, birthday));
        }

        foreach (var person in persons) {
            Console.WriteLine(person);
        }
    }
}