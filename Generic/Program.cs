using Generic;
class Program
{
    static void Main(string[] args)
    {
        CreateStack();
    }

    static void CreateStack()
    {
        Console.WriteLine("---------STACK---------");
        while (true)
        {
            Console.Clear();
            Console.WriteLine("What is your stack type ( 1.INT   2.DOUBLE   3.BOOLEAN )");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    HandleStack<int>();
                    break;
                case "2":
                    HandleStack<double>();
                    break;
                case "3":
                    HandleStack<bool>();
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        }

    }

    static void HandleStack<T>()
    {
        GenericStack<T> stack = new GenericStack<T>(5);
        bool running = true;
        while (running)
        {
            Console.WriteLine("\nChoose Operation: ");
            Console.WriteLine("1.Push");
            Console.WriteLine("2.Pop");
            Console.WriteLine("3.Peek");
            Console.WriteLine("4.IsEmpty");
            Console.WriteLine("5.Exit");
            running = HandleStackOperations<T>(stack);
        }
    }

    static bool HandleStackOperations<T>(GenericStack<T> stack)
    {
        bool running = true;
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                Console.WriteLine($"Enter {typeof(T)}element to push");
                string element = Console.ReadLine();
                try
                {
                    if (element != "")
                        stack.Push((T)Convert.ChangeType(element, typeof(T)));
                    else
                        stack.Push();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Invalid input");
                }

                break;
            case "2":
                if (stack.IsEmpty())
                {
                    Console.WriteLine("Stack is Empty");
                }
                else
                {
                    Console.WriteLine("Popped Item : " + stack.Pop());
                }
                break;
            case "3":
                if (stack.IsEmpty())
                {
                    Console.WriteLine("Stack is Empty");
                }
                else
                {
                    Console.WriteLine("Peek: " + stack.Peek());
                }
                break;
            case "4":
                Console.WriteLine("Is stack empty ? : " + stack.IsEmpty());
                break;
            case "5":
                running = false;
                break;
            default:
                Console.WriteLine("Invalid choice");
                break;
        }
        return running;
    }
}

