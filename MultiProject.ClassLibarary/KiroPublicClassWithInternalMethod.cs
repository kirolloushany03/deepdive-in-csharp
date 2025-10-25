namespace MultiProject.ClassLibarary;

public class KiroPublicClassWithInternalMethod
{
    public void PublicMethod()
    {
        Console.WriteLine("Hello from the public method on the PublicClassWithInternalMethod");
    }
    internal void InternalMethod()
    {
        Console.WriteLine("Hello from the internal method on the PublicClassWithInternalMethod");
    }
}
