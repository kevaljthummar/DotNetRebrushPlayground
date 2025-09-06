using System;

namespace OOP_Concepts
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class MyInfoAttribute : Attribute
    {
        public string Developer { get; }
        public MyInfoAttribute(string developer) => Developer = developer;
    }

    [MyInfo("Keval Thummar")]
    public class DemoClass
    {
        [MyInfo("Method Developer")]
        public void ShowMessage() => Console.WriteLine("Hello from DemoClass");
    }
}
