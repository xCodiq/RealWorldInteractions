namespace RW0;

public class Program {
    static void Main2(string[] args) {
        int[] frequencies = new int[26];

        // open file
        var reader = new StreamReader("test.txt");

        // Read the first line
        var line = reader.ReadLine();

        while (line != null) {
            // Do something with line variable
            foreach (var c in line) {
                // Check if the char is a letter
                if (char.IsLetter(c)) {
                    frequencies[char.ToLower(c) - 'a']++;
                }
            }

            // Read the next line
            line = reader.ReadLine();
        }
        
        for (var i = 0; i < frequencies.Length; i++) {
            Console.WriteLine($"{(char) ('a' + i)}: {frequencies[i]}x");
        }
    }
}