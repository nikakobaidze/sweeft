# sweeft
1. დაწერეთ ფუნქცია, რომელსაც გადაეცემა ტექსტი და აბრუნებს
პალინდრომია თუ არა. (პალინდრომი არის ტექსტი რომელიც ერთნაირად
იკითხება ორივე მხრიდან).
bool sPalindrome(string text);


```c#
public static bool sPalindrome(string text)
 {
            text = new string(text.Where(c => char.IsLetterOrDigit(c)).ToArray()).ToLower();
            return text == new string(text.Reverse().ToArray());

   }
   ```

2. გვაქვს 1,5,10,20 და 50 თეთრიანი მონეტები. დაწერეთ ფუნქცია, რომელსაც
გადაეცემა თანხა (თეთრებში) და აბრუნებს მონეტების მინიმალურ
რაოდენობას, რომლითაც შეგვიძლია ეს თანხა დავახურდაოთ.

```c#
 public static int MinSplit(int amount)
        {
            int min_coin;
            min_coin = amount / 50 + (amount % 50) / 20 + ((amount % 50) % 20) / 10 + (((amount % 50) % 20) % 10) / 5 + (((amount % 50) % 20) % 10) % 5;

            return min_coin;
        }
```
        
        
3. მოცემულია მასივი, რომელიც შედგება მთელი რიცხვებისგან. დაწერეთ
ფუნქცია რომელსაც გადაეცემა ეს მასივი და აბრუნებს მინიმალურ მთელ
რიცხვს, რომელიც 0-ზე მეტია და ამ მასივში არ შედის.

int NotContains(int[] array); 
```c#
 public static int NotContains(int[] array)
        {
           

            int minNumber = 1;
            while (array.Contains(minNumber))
            {
                minNumber++;
            }
            return minNumber;
        }
 ```

4. მოცემულია String რომელიც შედგება „(„ და „)“ ელემენტებისგან. დაწერეთ
ფუნქცია რომელიც აბრუნებს ფრჩხილები არის თუ არა მათემატიკურად
სწორად დასმული.

bool IsProperly(string sequence);

მაგ: (()()) სწორი მიმდევრობაა, ())() არასწორია
```c#

public static bool IsProperly(string sequence)
        {
            Stack<char> stack = new Stack<char>();
            foreach (char c in sequence)
            {
                if (c == '(')
                {
                    stack.Push(c);
                }
                else if (c == ')')
                {
                    if (stack.Count == 0 || stack.Peek() != '(')
                    {
                        return false;
                    }
                    stack.Pop();
                }
            }
            return stack.Count == 0;
        }
```
        
5. გვაქვს n სართულიანი კიბე, ერთ მოქმედებაში შეგვიძლია ავიდეთ 1 ან 2
საფეხურით. დაწერეთ ფუნქცია რომელიც დაითვლის n სართულზე ასვლის
ვარიანტების რაოდენობას.

int CountVariants(int stairCount);
```c#

 public static int CountVariants(int stairCount)
        {
            int[] dp = new int[stairCount + 1];
            dp[0] = 1;
            dp[1] = 1;
            for (int i = 2; i <= stairCount; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[stairCount];
        }
```
        
 6. გვაქვს Teacher ცხრილი, რომელსაც აქვს შემდეგი მახასიათებლები: სახელი,
გვარი, სქესი, საგანი. გვაქვს Pupil ცხრილი, რომელსაც აქვს შემდეგი
მახასიათებლები: სახელი, გვარი, სქესი, კლასი. ააგეთ ნებისმიერ რელაციურ
ბაზაში ისეთი დამოკიდებულება, რომელიც საშუალებას მოგვცემს, რომ
მასწავლებელმა ასწავლოს რამოდენიმე მოსწავლეს და ამავდროულად
მოსწავლეს ჰყავდეს რამდენიმე მასწავლებელი (როგორც რეალურ
ცხოვრებაში).

     1. დაწერეთ sql რომელიც ააგებს შესაბამის table-ებს.
     2. დაწერეთ sql რომელიც დააბრუნებს ყველა მასწავლებელს, რომელიც
ასწავლის მოსწავლეს, რომელის სახელია: „გიორგი“.

1
```sql
  CREATE TABLE Teacher (
  TeacherID INT PRIMARY KEY,
  Name VARCHAR(50),
  Surname VARCHAR(50),
  Gender VARCHAR(10),
  Subject VARCHAR(50)
);

CREATE TABLE Pupil (
  PupilID INT PRIMARY KEY,
  FirstName VARCHAR(50),
  LastName VARCHAR(50),
  Gender VARCHAR(10),
  Class VARCHAR(50)
);

CREATE TABLE TeacherPupil (
  TeacherID INT,
  PupilID INT,
  PRIMARY KEY (TeacherID, PupilID),
  FOREIGN KEY (TeacherID) REFERENCES Teacher(TeacherID),
  FOREIGN KEY (PupilID) REFERENCES Pupil(PupilID)
);
```
2
```sql
SELECT t.Name, t.Surname
FROM Teacher t
INNER JOIN TeacherPupil tp ON t.TeacherID = tp.TeacherID
INNER JOIN Pupil p ON p.PupilID = tp.PupilID
WHERE p.FirstName = 'Giorgi';
```

7. დაწერეთ აპლიკაცია EntityFramework-ის (Code-First) გამოყენებით დავალება
6-ის მოცემულობით. დაწერეთ ფუნქცია რომელიც დააბრუნებს ყველა
მასწავლებელს, რომელიც ასწავლის მოსწავლეს, რომლის სახელია: „გიორგი“.
Teacher[] GetAllTeachersByStudent(string studentName);
```c#
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace sweeft_7
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string Subject { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Class { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; }
    }
    public class SchoolContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany<Student>(t => t.Students)
                .WithMany(s => s.Teachers)
                .Map(ts =>
                {
                    ts.MapLeftKey("TeacherId");
                    ts.MapRightKey("StudentId");
                    ts.ToTable("TeacherStudent");
                });
        }
    }

    internal class Program
    {
        public Teacher[] GetAllTeachersByStudent(string studentName)
        {
            using (var context = new SchoolContext())
            {
                return context.Teachers
                    .Where(t => t.Students.Any(s => s.FirstName == studentName))
                    .ToArray();
            }
        }
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var student1 = new Student { FirstName = "George", LastName = "Smith", Gender = "Male", Class = "10A" };
                var student2 = new Student { FirstName = "Emily", LastName = "Jones", Gender = "Female", Class = "10A" };

                var teacher1 = new Teacher { Name = "John", Surname = "Doe", Gender = "Male", Subject = "Math", Students = new List<Student> { student1, student2 } };
                var teacher2 = new Teacher { Name = "Mary", Surname = "Smith", Gender = "Female", Subject = "English", Students = new List<Student> { student1 } };

                context.Students.Add(student1);
                context.Students.Add(student2);
                context.Teachers.Add(teacher1);
                context.Teachers.Add(teacher2);

                context.SaveChanges();

                var teachers = GetAllTeachersByStudent("George");
                foreach (var teacher in teachers)
                {
                    Console.WriteLine("{0} {1} teaches {2}", teacher.Name, teacher.Surname, teacher.Subject);
                }
            }
        }
    }
}
```

8. მოცემულია Countries REST API ის მისამართი:
https://restcountries.com/v3.1/all, რომელიც აბრუნებს ინფორმაციას ქვეყნების
შესახებ. დაწერეთ ფუნქცია, რომელიც ყოველი ქვეყნისთვის შექმნის ტექსტურ
დოკუმენტს (.txt) სახელად {ქვეყნის_სახელი.txt}. თითოეულ დოკუმენტში
უნდა იყოს შევსებული ქვეყნის “region”, “subregion”, “latlng”, “area” და
“population” ველები.
void GenerateCountryDataFiles();
```c#

public void GenerateCountryDataFiles()
        {
            // Make a request to the REST API to get information about all countries
            using (var client = new HttpClient())
            {
                var response = client.GetAsync("https://restcountries.com/v3.1/all").Result;
                var content = response.Content.ReadAsStringAsync().Result;

                // Parse the response JSON into a JArray
                var countries = JArray.Parse(content);

                // Iterate through each country in the array
                foreach (var country in countries)
                {
                    // Get the country name
                    var name = (string)country["name"]["common"];

                    // Create a text file with the country name
                    var filename = $"{name}.txt";
                    using (var writer = new StreamWriter(filename))
                    {
                        // Write the country information to the file
                        writer.WriteLine($"Country: {name}");
                        writer.WriteLine($"Region: {country["region"]}");
                        writer.WriteLine($"Subregion: {country["subregion"]}");
                        writer.WriteLine($"Latlng: {string.Join(", ", country["latlng"])}");
                        writer.WriteLine($"Area: {country["area"]}");
                        writer.WriteLine($"Population: {country["population"]}");
                    }
                }
            }
        }
        ```
        
