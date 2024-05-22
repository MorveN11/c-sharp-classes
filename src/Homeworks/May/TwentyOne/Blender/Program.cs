static class Program
{
    static void Main()
    {
        PrepareJuice(new string[] { "Strawberry", "Banana", "Pineapple", "Apple", "Mango" });
    }

    private static void PrepareJuice(string[] fruits)
    {
        WashFruits(fruits);
        CutFruits(fruits);
        PutFruitsInBlender(fruits);
        BlendFruits();
    }

    private static void WashFruits(string[] fruits)
    {
        Console.WriteLine("Lavando las frutas...");
        foreach (var fruit in fruits)
        {
            Console.WriteLine("Lavada: " + fruit);
        }
    }

    private static void CutFruits(string[] fruits)
    {
        Console.WriteLine("Cortando las frutas...");
        foreach (var fruit in fruits)
        {
            Console.WriteLine("Cortada: " + fruit);
        }
    }

    private static void PutFruitsInBlender(string[] fruits)
    {
        Console.WriteLine("Poniendo las frutas en la licuadora...");
        foreach (var fruit in fruits)
        {
            Console.WriteLine("En la licuadora: " + fruit);
        }
    }

    private static void BlendFruits()
    {
        Console.WriteLine("Licuando las frutas...");
        Console.WriteLine("Las frutas han sido licuadas.");
    }
}
