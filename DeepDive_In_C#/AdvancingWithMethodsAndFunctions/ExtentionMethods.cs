namespace DeepDive_In_C_.AdvancingWithMethodsAndFunctions;


internal class ExtentionMethods
{
    public static void RunExmples()
    {
        //extions methods
        //extions are special tyep of static mehtod on a static class


        //var reversed = Extentions.Reverse("Hellwo world");\
        string reversed = "kiro";

        var forwardagain = reversed.Reverse();
        Console.WriteLine(forwardagain);


        //also if you llook at linq it also uses extnion methods
        IEnumerable<int> numbers = new List<int> { 1,2,3,45};
        var evenNumbers = numbers.Where(n => n % 2 == 0);
        //so where if we press on where will will see it that it is extention method sin eh linq
    }
}
// ✅ Extension class must be top-level static

public static class Extentions
{
    public static string Reverse(this string str)
    {
        var reversedChars = str.Reverse<char>()
                               .ToArray();
        var reversed = new string(reversedChars);
        return reversed;
    }
}