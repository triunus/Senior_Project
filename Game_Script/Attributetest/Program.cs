using System;

[System.AttributeUsage(System.AttributeTargets.Class | System.AttributeTargets.Struct) ]
public class AuthorAttribute : System.Attribute
{
    private string name;
    public double version;

    public AuthorAttribute(string name)
    {
        this.name = name;
        version = 1.0;
    }
    public string Name() { return name; }
}

[Author("P. Ackerman", version = 1.1)]
class Program
{
    static void Main(string[] args)
    {
        AuthorAttribute author = (AuthorAttribute)Attribute.GetCustomAttribute(typeof(Program), typeof(AuthorAttribute));

        Console.WriteLine(author.Name());
        Console.WriteLine(author.version);
        Console.ReadLine();
    }
}

