namespace Functional
{
    public class Program
    {
        delegate TOut Getter<TOut>();
        delegate void Setter<TIn>(TIn value);
        delegate bool Predicate();

        static (
            Getter<string> GetName,
            Setter<string> SetName,
            Getter<DateTime> GetBirthday,
            Setter<DateTime> SetBirthday,
            Getter<string> Talk,
            Getter<string> String
        ) Person(string name, DateTime birthday)
        {
            string _name = name;
            DateTime _birthday = birthday;

            return (
                () => _name,
                (string value) => _name = value,
                () => _birthday,
                (DateTime value) => _birthday = value,
                () => "blablabla",
                () => $"Name: {_name}\nBirthday: {_birthday}"
            );
        }

        static (
            Getter<string> GetName,
            Setter<string> SetName,
            Getter<DateTime> GetBirthday,
            Setter<DateTime> SetBirthday,
            Getter<string> Talk,
            Getter<string> String,
            Getter<byte> GetGrade,
            Setter<byte> SetGrade,
            Predicate IsApproved
        ) Student(string name, DateTime birthday, byte grade)
        {
            var (getName, setName, getBirthday, setBirthday, Talk, String) = Person(name, birthday);
            byte _grade = grade;

            return (
                getName,
                setName,
                getBirthday,
                setBirthday,
                () => "BLA!! BLA!!",
                () => $"{String()}\nGrade: {_grade}",
                () => _grade,
                (byte value) => _grade = value,
                () => _grade >= 6
            );
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Person:");
            var person = Person("John", DateTime.Now);
            Console.WriteLine(person.String());
            Console.WriteLine(person.Talk());

            Console.WriteLine("\nStudent:");
            var student = Student("Alice", DateTime.Now.AddYears(-20), 10);
            Console.WriteLine(student.String());
            Console.WriteLine(student.IsApproved());
            Console.WriteLine(student.Talk());
        }
    }
}
