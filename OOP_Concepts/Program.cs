using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OOP_Concepts
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Step 1: OOP Concepts in ConsoleApp
            Console.WriteLine("=== OOP Demo ===");

            Shape circle = new Circle(5, "Red");
            circle.DisplayInfo();

            Shape rectangle = new Rectangle(4, 6, "Blue");
            rectangle.DisplayInfo();

            // Step 2: Collections & Generics
            Console.WriteLine("\n=== Collections & Generics Demo ===");

            // List<T>
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            numbers.Add(6);
            Console.WriteLine("Numbers: " + string.Join(", ", numbers));

            // Dictionary<TKey, TValue>
            var employees = new Dictionary<int, string>
            {
                {1, "Alice"},
                {2, "Bob"},
                {3, "Charlie"}
            };
            Console.WriteLine("Employee 2: " + employees[2]);

            // Generic Repository
            var repo = new Repository<string>();
            repo.Add("First item");
            repo.Add("Second item");
            Console.WriteLine("Repo items: " + string.Join(", ", repo.GetAll()));

            // Step 3: Delegates & Events
            Console.WriteLine("\n=== Delegates & Events Demo ===");

            // Delegate example
            Func<int, int, int> add = (a, b) => a + b;
            Console.WriteLine("Add 5 + 3 = " + add(5, 3));

            // Event example
            var publisher = new Publisher();
            publisher.OnNotify += msg => Console.WriteLine("Subscriber received: " + msg);
            publisher.Raise("Hello Events!");

            // Step 4: LINQ
            Console.WriteLine("\n=== LINQ Demo ===");

            var numbersList = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Query syntax
            var evensQuery = from n in numbersList
                             where n % 2 == 0
                             select n;

            // Method syntax
            var evensMethod = numbersList.Where(n => n % 2 == 0).ToList();

            Console.WriteLine("Evens (Query): " + string.Join(", ", evensQuery));
            Console.WriteLine("Evens (Method): " + string.Join(", ", evensMethod));

            // Step 5: Async / Await
            Console.WriteLine("\n=== Async/Await Demo ===");
            await FetchDataAsync();

            // Step 6: Reflection & Attributes
            Console.WriteLine("\n=== Reflection Demo ===");

            var type = typeof(DemoClass);
            var classAttr = type.GetCustomAttribute<MyInfoAttribute>();
            Console.WriteLine($"Class Developer: {classAttr.Developer}");

            var method = type.GetMethod("ShowMessage");
            var methodAttr = method.GetCustomAttribute<MyInfoAttribute>();
            Console.WriteLine($"Method Developer: {methodAttr.Developer}");

            var instance = Activator.CreateInstance(type);
            method.Invoke(instance, null);
        }

        private static async Task FetchDataAsync()
        {
            Console.WriteLine("Fetching data...");
            await Task.Delay(2000); // Simulate API call
            Console.WriteLine("Data fetched.");
        }
    }

    // Generic repository class
    public class Repository<T>
    {
        private readonly List<T> _items = new List<T>();
        public void Add(T item) => _items.Add(item);
        public IEnumerable<T> GetAll() => _items;
    }

    public class Publisher
    {
        public event Action<string> OnNotify;
        public void Raise(string msg) => OnNotify?.Invoke(msg);
    }
}
