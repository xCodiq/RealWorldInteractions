namespace RW1.module;

public class Grade {
    private double value;
    private readonly DateTime date;
    private readonly int examCode;
    private readonly string note;

    private bool frozen = false;

    public Grade(double value, DateTime date, int examCode, string note) {
        this.value = value;
        this.date = date;
        this.examCode = examCode;
        this.note = note ?? throw new ArgumentNullException(nameof(note));
    }

    public Grade(double value, int examCode, string note) : this(value, DateTime.Now, examCode, note) {
    }

    public double Value {
        get => value;
        set => this.value = this.frozen ? this.value : value;
    }

    public DateTime Date => date;

    public int ExamCode => examCode;

    public string Note => note;

    public bool Frozen {
        get => frozen;
        set {
            frozen = value;
            frozen = true;
        }
    }

    public override string ToString() {
        return $"{this.examCode} on {date}: {value}";
    }
}