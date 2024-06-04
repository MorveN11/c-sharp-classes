# Class June 3th, 2024 - Manuel Morales

## Sum, Max, Min y Average con Aggregate en C Sharp

```csharp
namespace LinQ
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> integers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            int sum = integers.Aggregate((a, b) => a + b);
            int maxValue = integers.Aggregate((a, b) => a > b ? a : b);
            int minValue = integers.Aggregate((a, b) => a < b ? a : b);
            int average = integers.Aggregate(0, (a, b) => a + b, value => value / integers.Count);

            Console.WriteLine($"Sum: {sum}"); // 55
            Console.WriteLine($"Max: {maxValue}"); // 10
            Console.WriteLine($"Min: {minValue}"); // 1
            Console.WriteLine($"Average: {average}"); // 5
        }
    }
}
```

## Se puede sobreescribir el valor default de una clase en C Sharp

En C Sharp la palabra clave `default` se utiliza para obtener el valor por
defecto de un tipo de dato, por ejemplo, el valor por defecto de un `int` es
`0`, el valor por defecto de un `string` es `null`, el valor por defecto de un
`bool` es `false`, etc.

Este metodo no puede ser sobrecargado o personalizada para tipos de referencia
como las clases. Cuando usas default(MyClass), siempre obtendrás null, porque
null es el valor predeterminado para todos los tipos de referencia en C#.

## Como funciona yield break en la funcion Any en C Sharp

Yield break en C# se usa para terminar una iteración antes de tiempo, sin
devolver un valor. Es útil cuando ya no hay más datos para producir.

La función Any() de LINQ verifica si algún elemento en una colección cumple una
condición (si se proporciona), o simplemente si la colección tiene algún
elemento. Lo hace iterando sobre la colección hasta encontrar un elemento que
cumpla la condición, o hasta que haya revisado todos los elementos.

Cuando usas Any() en una `List<int>` por ejemplo, internamente usa un iterador
para recorrer la lista. Si encuentra un elemento que cumple la condición (o
cualquier elemento, si no se proporciona una condición), inmediatamente deja de
iterar y devuelve true. Esto es efectivamente como un yield break, porque
detiene la iteración antes de tiempo.

## CLI Diagram

![Cli Diagram](https://i.ibb.co/gtvNR1d/Screenshot-from-2024-06-03-17-10-25.png)
