namespace RW1.module;

public class Student {
    private readonly string firstName, lastName;
    private readonly int studentNumber;

    private readonly List<Grade> grades = new List<Grade>();

    public string FirstName => firstName;

    public string LastName => lastName;

    private string FullName => firstName + " " + lastName;

    public int StudentNumber => studentNumber;

    public Student(string firstName, string lastName, int studentNumber) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.studentNumber = studentNumber;
    }

    public Grade SetGrade(int examCode, double value) {
        for (var i = 0; i < this.grades.Count; i++) {
            var grade = this.grades[i];
            
            if (grade.ExamCode != examCode) continue;
            if (grade.Frozen) return this.grades[i] = new Grade(value, examCode, "N/A");
            
            grade.Value = value;
            return grade;
        }

        var newGrade = new Grade(value, examCode, "N/A");
        this.grades.Add(newGrade);

        return newGrade;
    }

    public void AddGrade(Grade grade) {
        this.grades.Add(grade);
    }

    public List<Grade> GradesFor(int examCode) {
        return this.grades.FindAll(grade => grade.ExamCode == examCode);
    }

    public void PrintGrades() {
        var sortedGrades = this.grades.OrderBy(grade => grade.Date).ToList();

        Console.WriteLine($"Grades of {this}");
        foreach (var sortedGrade in sortedGrades) {
            Console.WriteLine(sortedGrade);
        }
    }

    public void PrintGrades(DateTime from, DateTime to) {
        var sortedGrades = this.grades.OrderBy(grade => grade.Date).ToList();

        Console.WriteLine($"Grades of {this}");
        foreach (var sortedGrade in sortedGrades.Where(
                     sortedGrade => sortedGrade.Date >= from && sortedGrade.Date <= to)) {
            Console.WriteLine(sortedGrade);
        }
    }

    public double GradePointAverage() {
        return this.grades.Average(grade => grade.Value);
    }

    public override string ToString() {
        return $"Student: {FullName} (#{studentNumber})";
    }
}