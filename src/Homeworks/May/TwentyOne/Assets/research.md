# C Sharp

Trainer como la tarea se subio despues de la hora de clase no me dio tiempo para
realizarlo en el horario acordado y dado a mi horario no me dio mucho tiempo
para realizar la asignacion es por ello que no tuve el tiempo de poner todo en
papel y todo este en codigo, una disculpa `:(`.

1. **Miembros de Clase**:

- **Fields (Campos)**: Son variables que se declaran directamente en una clase.

  ```csharp
  public class MyClass
  {
      public int MyField;
  }
  ```

- **Constructores**: Son métodos especiales que se utilizan para inicializar una
  instancia de una clase.

  ```csharp
  public class MyClass
  {
      public MyClass() { }
  }
  ```

- **Métodos**: Son funciones que definen el comportamiento de una clase.

  ```csharp
  public class MyClass
  {
      public void MyMethod() { }
  }
  ```

- **Propiedades**: Permiten a una clase exponer un comportamiento específico de
  los campos y protegerlos de un acceso no deseado.

  ```csharp
  public class MyClass
  {
      private int myProperty;

      public int MyProperty
      {
          get { return myProperty; }
          set { myProperty = value; }
      }
  }
  ```

- **Finalizadores (Destructores)**: Son métodos que se utilizan para liberar
  recursos no administrados antes de que la instancia de una clase sea
  recolectada por el recolector de basura.

  ```csharp
  public class MyClass
  {
      ~MyClass()
      {
          // código para liberar recursos no administrados
      }
  }
  ```

- **Indizadores**: Permiten a una clase o un objeto ser indexado como un array.

  ```csharp
  public class MyClass
  {
      private int[] array = new int[10];

      public int this[int index]
      {
          get { return array[index]; }
          set { array[index] = value; }
      }
  }
  ```

- **Operadores**: Permiten a una clase definir el comportamiento de los
  operadores para las instancias de la clase.

  ```csharp
  public class MyClass
  {
      public static MyClass operator +(MyClass a, MyClass b)
      {
          // código para la operación de suma
          return new MyClass();
      }
  }
  ```

- **Constantes**: Son campos inmutables cuyo valor se conoce en tiempo de
  compilación y no cambia por el resto de la ejecución del programa.

  ```csharp
  public class MyClass
  {
      public const int MyConstant = 10;
  }
  ```

- **Tipos anidados**: Son clases, estructuras, interfaces, enumeraciones o
  delegados declarados dentro del cuerpo de otra clase o estructura.

  ```csharp
  public class MyClass
  {
      public class MyNestedClass { }
  }
  ```

2. **Namespace**: En C#, un espacio de nombres es una forma de agrupar clases,
   estructuras, enumeraciones, interfaces y delegados relacionados. Ayuda a
   organizar el código y evita conflictos de nombres. Por ejemplo, puedes tener
   una clase `File` en el espacio de nombres `System.IO` y otra clase `File` en
   un espacio de nombres diferente sin que haya un conflicto.

3. **Ensamblado**: Un ensamblado en C Sharp es una unidad de despliegue que
   contiene código que el Common Language Runtime (CLR) ejecuta. Hay dos tipos
   de ensamblados: los ensamblados de proceso (también conocidos como
   ensamblados de aplicación) y los ensamblados de biblioteca. Los ensamblados
   de proceso contienen el punto de entrada de la aplicación, mientras que los
   ensamblados de biblioteca son componentes que se utilizan por otros
   ensamblados.

4. **Relación con las clases**: Los espacios de nombres y los ensamblados están
   relacionados con las clases en el sentido de que proporcionan un contexto y
   una organización para las clases. Un espacio de nombres puede contener varias
   clases y ayuda a evitar conflictos de nombres entre ellas. Un ensamblado, por
   otro lado, es una colección de uno o más archivos compilados (dll o exe) que
   contienen clases, así como otros tipos y recursos.

5. **Interfaz**: En un contexto general, una interfaz se refiere a un contrato
   que define un conjunto de métodos y propiedades que una clase debe
   implementar. Una interfaz no contiene ninguna implementación en sí misma,
   sólo las firmas de los métodos y propiedades. Una clase puede implementar
   múltiples interfaces, lo que permite una forma de herencia múltiple en C#.
