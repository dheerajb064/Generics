using GenericQueue;

class Program
{
    static void Main(string[] args)
    {
        CreateQueue();
    }

    static void CreateQueue()
    {
        Console.WriteLine("-----------QUEUE----------");
        Console.WriteLine("ENTER THE TYPE OF QUEUE (1.STRING   2.CHATMESSAGE)");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                HandleQueue<string>();
                break;
            case "2":
                HandleQueue<ChatMessage>();
                break;
            default:
                break;
        }
    }

    static void HandleQueue<T>() where T : class
    {
        GenericQueue<T> queue = new GenericQueue<T>();
        bool running = true;
        while(running)
        {
            Console.WriteLine("\nChoose Operation: ");
            Console.WriteLine("1.Enqueue");
            Console.WriteLine("2.Dequeue");
            Console.WriteLine("3.IsEmpty");
            Console.WriteLine("4.Exit");
            running = HandleQueueOperations<T>(queue);
        }
    }

    static bool HandleQueueOperations<T>(GenericQueue<T> queue) where T : class
    {
        bool running = true;
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
                if(typeof(T) == typeof(string))
                {
                    Console.WriteLine("Enter string element to Add to Queue");
                    string element = Console.ReadLine();
                    queue.Enqueue(element as T);
                }
                else
                {
                    Console.WriteLine("Enter ChatMessage properties (MessageId, Content, TimeStamp, SourceId) separated by commas:");
                    string element = Console.ReadLine();
                    try
                    {
                        string[] properties = element.Split(',');
                        int messageId = int.Parse(properties[0]);
                        string content = properties[1];
                        DateTime dateTime = DateTime.Parse(properties[2]);
                        int sourceId = int.Parse(properties[3]);
                        ChatMessage chatMessage = new ChatMessage{ MessageId = messageId, Content = content, TimeStamp = dateTime, SourceId = sourceId };
                        queue.Enqueue(chatMessage as T);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Invalid Input");
                    }
                }
                break;
            case "2":
                if(queue.IsEmpty())
                {
                    Console.WriteLine("Queue is Empty");
                }
                else
                {
                    if (typeof(T) == typeof(string))
                    {
                        Console.WriteLine("Dequeued Item : " + queue.Dequeue());
                    }
                    else if (typeof(T) == typeof(ChatMessage))
                    {
                        ChatMessage message = queue.Dequeue() as ChatMessage;
                        Console.WriteLine("Dequeued Item : " + message.MessageId + "," + message.Content + "," + message.TimeStamp + "," + message.SourceId);
                    }
                }
                break;
            case "3":
                Console.WriteLine("Is queue empty ? : " + queue.IsEmpty());
                break;
            case "4":
                running = false;
                break;
            case "5":
                Console.WriteLine("Invalid choice");
                break;
        }
        return running;
    }

}