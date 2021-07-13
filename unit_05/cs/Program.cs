using System;

namespace cs
{
    class Human
	{
		public string name = "I am Human";
	
		public void DisplayName()
		{
			Console.WriteLine("Human Display Name " + name);
		}

	}

    // class Employee:Human
    // {

    //     public int salary = 2000;
     
    //     public void DisplaySalary()
    //     {
    //         Console.WriteLine("Employee Display Salary");
    //     }
         
    // }

    // class Employee:Human
    // {

    //     public int salary = 2000;
    
    //     public void DisplaySalary()
    //     {
    //         Console.WriteLine("Employee Display Salary");
    //     }

    //     public void DisplayName()
    //     {
    //         Console.WriteLine("Employee Display Name");
    //     }
        
    // }
    
    // base.DisplayName();
    class Employee:Human
    {

        public int salary = 2000;
    
        public void DisplaySalary()
        {
            Console.WriteLine("Employee Display Salary");
        }

        public void DisplayName()
        {
            Console.WriteLine("Employee Display Name");
            base.DisplayName();
        }
        
    }

    // ClassB:
    public class ClassB
    {
        public int b = 100;
    }

    // ClassA:

    public class ClassA
    {
        public int a = 100;
    }

    public class ClassC:ClassB
    {
        public int a = 100;
    }



    class Program
    {
        static void Main(string[] args)
        {
            Human hum = new Human();
            hum.DisplayName();
            Console.ReadKey();

            Employee emp = new Employee();
            emp.DisplayName();
            // warning CS0108: "Employee.DisplayName()" скрывает наследуемый член "Human.DisplayName()". 
            // Если скрытие было намеренным, используйте ключевое слово new. [/home/janus/work/cpp-cs-fundamental/unit_05/cs/cs.csproj]

            Console.ReadKey();

            Student stu = new Student();
            stu.DisplayName();
            Console.ReadKey();
            
            // Операции с объектами
            // ClassB classB = new ClassB();
            // ClassA classA = new ClassA();
            // Здесь мы пытаемся приравнять объект от разных классов друг к другу.

            // classA = classB;
            // classB = classA;
            // вы не можете приравнять два объекта от двух независимых классов. 

            // Класс C унаследован от B, значит, имеет все его поля и методы — при назначении переменной типа B объекта типа C проблем не возникает. Однако в обратную сторону это не работает — в классе B нет полей и методов, которые могут быть в C.

            // вы можете назначить переменной родительского типа объект дочернего, но не наоборот.

            // Приведение типа здесь сработает, но только потому, что эти классы находятся в наследственных отношениях. 
            ClassB classB = new ClassB();
            ClassC classC = new ClassC();
            classB=classC;
            classC = (ClassC)classB;

            // Два обособленных непримитивных типа привести друг к другу нельзя.
            // int integerA = 10;
            // char characterB = 'A';
            // integerA = characterB;
            // characterB = integerA;
			
        }
    }
}
