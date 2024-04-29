using System;

public class FirstClass
{

    public event Action<string> MyEvent;

    public FirstClass(string name)
    {
        Name = name;
    }

    public string Name { get; }
    public void GenerateEvent()
    {
        MyEvent?.Invoke(Name);
    }
}


public class SecondClass
{
    public void HandleEvent(string name)
    {
        Console.WriteLine($"Событие сгенерировано объектом: {name}");
    }
}


class Program
{
    static void Main(string[] args)
    {

        FirstClass obj1 = new("Объект 1");
        FirstClass obj2 = new("Объект 2");

        SecondClass objHandler = new SecondClass();

        obj1.MyEvent += objHandler.HandleEvent;
        obj2.MyEvent += objHandler.HandleEvent;

        obj1.GenerateEvent();
        obj2.GenerateEvent();
    }
}
