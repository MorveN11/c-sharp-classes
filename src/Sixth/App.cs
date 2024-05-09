public class App
{
    static void Main(string[] args)
    {
        // Array Rotation
        Console.WriteLine("--- Array Rotation ---");

        var array = new int[] { 1, 2, 3, 4, 5 };
        var rotationCount = 4;
        var direction = RotationDirection.Left;

        var arrayRotation = new ArrayRotation<int>(array, rotationCount, direction);
        var rotatedArray = arrayRotation.GetArray();

        Console.WriteLine("Original Array: ");
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine(
            $"Rotated Array {rotationCount} times to the {(direction == RotationDirection.Left ? "left" : "right")}: "
        );
        Console.WriteLine(string.Join(", ", rotatedArray));

        rotationCount = 3;
        direction = RotationDirection.Right;
        arrayRotation = new ArrayRotation<int>(array, rotationCount, direction);
        rotatedArray = arrayRotation.GetArray();

        Console.WriteLine("\nOriginal Array: ");
        Console.WriteLine(string.Join(", ", array));
        Console.WriteLine(
            $"Rotated Array {rotationCount} times to the {(direction == RotationDirection.Left ? "left" : "right")}: "
        );
        Console.WriteLine(string.Join(", ", rotatedArray));

        // Coordinates
        Console.WriteLine("\n--- Coordinates ---");

        var coordinate1 = new Coordinate(1, 1);
        var coordinate2 = new Coordinate(4, 5);

        var distance = coordinate1.DistanceTo(coordinate2);
        var angle = coordinate1.AngleTo(coordinate2);

        Console.WriteLine($"Coordinate 1: {coordinate1}");
        Console.WriteLine($"Coordinate 2: {coordinate2}");
        Console.WriteLine($"Distance: {distance}");
        Console.WriteLine($"Angle: {angle}");

        // Complex Numbers
        Console.WriteLine("\n--- Complex Numbers ---");

        var complexNumber1 = new ComplexNumber(1, 2);
        var complexNumber2 = new ComplexNumber(3, 4);

        var sum = complexNumber1 + complexNumber2;
        var difference = complexNumber1 - complexNumber2;
        var isEqual = complexNumber1 == complexNumber2;
        var isDifferent = complexNumber1 != complexNumber2;

        Console.WriteLine($"Complex Number 1: {complexNumber1}");
        Console.WriteLine($"Complex Number 2: {complexNumber2}");
        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Difference: {difference}");
        Console.WriteLine($"Are the complex numbers equal? {isEqual}");
        Console.WriteLine($"Are the complex numbers different? {isDifferent}");

        // Dictionary
        Console.WriteLine("\n--- Dictionary ---");

        var account1 = new Dictionary<string, object>
        {
            { "id", 1 },
            { "amount", 1000.00 },
            { "status", "active" },
            { "currency", "USD" }
        };

        var account2 = new Dictionary<string, object>
        {
            { "id", 2 },
            { "amount", 500.00 },
            { "status", "inactive" },
            { "currency", "USD" }
        };

        var account3 = new Dictionary<string, object>
        {
            { "id", 3 },
            { "amount", 750.00 },
            { "status", "active" },
            { "currency", "EUR" }
        };

        var account4 = new Dictionary<string, object>
        {
            { "id", 4 },
            { "amount", 250.00 },
            { "status", "inactive" },
            { "currency", "EUR" }
        };

        var user1 = new Dictionary<string, object>
        {
            { "id", 1 },
            { "name", "John" },
            { "lastName", "Doe" },
            { "birthDate", new DateTime(1990, 1, 1) },
            { "address", "123 Main St." },
            {
                "accounts",
                new List<Dictionary<string, object>> { account1, account2 }
            }
        };

        var user2 = new Dictionary<string, object>
        {
            { "id", 3 },
            { "name", "Jane" },
            { "lastName", "Doe" },
            { "birthDate", new DateTime(1995, 1, 1) },
            { "address", "123 Main St." },
            {
                "accounts",
                new List<Dictionary<string, object>> { account3, account4 }
            }
        };

        Console.WriteLine("User 1:");
        Console.WriteLine($"ID: {user1["id"]}");
        Console.WriteLine($"Name: {user1["name"]}");
        Console.WriteLine($"Last Name: {user1["lastName"]}");
        Console.WriteLine($"Birth Date: {user1["birthDate"]}");
        Console.WriteLine($"Address: {user1["address"]}");
        Console.WriteLine("Accounts:");

        foreach (var account in (List<Dictionary<string, object>>)user1["accounts"])
        {
            Console.WriteLine($"ID: {account["id"]}");
            Console.WriteLine($"Amount: {account["amount"]}");
            Console.WriteLine($"Status: {account["status"]}");
            Console.WriteLine($"Currency: {account["currency"]}");
        }

        Console.WriteLine("\nUser 2:");
        Console.WriteLine($"ID: {user2["id"]}");
        Console.WriteLine($"Name: {user2["name"]}");
        Console.WriteLine($"Last Name: {user2["lastName"]}");
        Console.WriteLine($"Birth Date: {user2["birthDate"]}");
        Console.WriteLine($"Address: {user2["address"]}");
        Console.WriteLine("Accounts:");

        foreach (var account in (List<Dictionary<string, object>>)user2["accounts"])
        {
            Console.WriteLine($"ID: {account["id"]}");
            Console.WriteLine($"Amount: {account["amount"]}");
            Console.WriteLine($"Status: {account["status"]}");
            Console.WriteLine($"Currency: {account["currency"]}");
        }
    }
}
