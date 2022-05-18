namespace RW1.module;

public class Administration {
    private readonly List<Student> registeredStudents = new List<Student>();

    private Administration() {
    }

    /**
     * Name: Elmar Blume
     * Student: 516099
     *
     * Saxion University
     */
    public static void Main(string[] args) {
        var administration = new Administration();
        administration.DisplayMenu();

        bool stopping = false;
        while (!stopping) {
            var line = Console.ReadLine();
            if (line == null) administration.DisplayMenu();
            else
                switch (line) {
                    case "1": {
                        if (administration.registeredStudents.Count == 0)
                            Console.WriteLine("\nThere are no registered students yet!");
                        else {
                            Console.WriteLine("\nRegistered Students:");
                            administration.registeredStudents.ForEach(student => Console.WriteLine("\t" + student));
                        }

                        administration.PromptOption();
                        break;
                    }
                    case "2": {
                        var firstName = administration.PromptValue("Enter the first name: ");
                        var lastName = administration.PromptValue("Enter the last name: ");

                        var student = new Student(firstName, lastName, administration.registeredStudents.Count + 1);
                        administration.registeredStudents.Add(student);

                        Console.WriteLine("\nAdded: " + student);
                        administration.PromptOption();
                        break;
                    }
                    case "3": {
                        if (administration.EnsureRegisteredStudentsCount()) break;

                        var student = administration.PromptStudent();
                        administration.registeredStudents.Remove(student);

                        Console.WriteLine("\nRemoved: " + student);
                        administration.PromptOption();
                        break;
                    }
                    case "4": {
                        if (administration.EnsureRegisteredStudentsCount()) break;

                        var student = administration.PromptStudent();
                        student.PrintGrades();

                        administration.PromptOption();
                        break;
                    }
                    case "5": {
                        if (administration.EnsureRegisteredStudentsCount()) break;

                        var student = administration.PromptStudent();
                        var examCode = int.Parse(administration.PromptValue("Enter a exam-code: "));
                        var gradeValue = double.Parse(administration.PromptValue("Enter a grade value: "));

                        var grade = student.SetGrade(examCode, gradeValue);
                        Console.WriteLine("Gave " + student + " a " + grade);
                        break;
                    }
                    case "6": {
                        stopping = true;
                        break;
                    }
                    default: {
                        administration.DisplayMenu();
                        break;
                    }
                }
        }

        Console.WriteLine("Goodbye!");
    }

    private void DisplayMenu() {
        Console.WriteLine("\n");
        Console.WriteLine("------------------------");
        Console.WriteLine("Options");
        Console.WriteLine("\t1: List Students");
        Console.WriteLine("\t2: Add Student");
        Console.WriteLine("\t3: Remove Student");
        Console.WriteLine("\t4: Show Grades");
        Console.WriteLine("\t5: Set Grade");
        Console.WriteLine("\t6: Exit");
        Console.WriteLine("------------------------");
        Console.Write("Enter an option: ");
    }

    private void PromptOption() {
        Console.WriteLine("\n");
        Console.WriteLine("Enter another option (type '7' for the menu): ");
    }

    private bool EnsureRegisteredStudentsCount() {
        if (this.registeredStudents.Count != 0) return false;

        Console.WriteLine("\nThere are no registered students to remove!");
        this.PromptOption();
        return true;
    }

    private Student PromptStudent() {
        Student? student = null;
        while (student == null) {
            var studentNumber = int.Parse(this.PromptValue("Enter a student number: "));
            student = this.registeredStudents.Find(item => item.StudentNumber == studentNumber);
        }

        return student;
    }

    private string PromptValue(string question) {
        string? result = null;
        while (string.IsNullOrEmpty(result)) {
            Console.WriteLine(question);
            result = Console.ReadLine();
        }

        return result;
    }
}