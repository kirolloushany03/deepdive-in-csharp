using System.Text;

namespace DeepDive_In_C_.workingWithBinary_and_StringData;

internal class EncodingStringsAndBytes
{
    public static void RunExamples()
    {
        string HelloWorld = "hello world ";
        byte[] bytesForHelloWoldAscii = Encoding.ASCII.GetBytes(HelloWorld);

        string hellowWorldConvertedback = Encoding.ASCII.GetString(bytesForHelloWoldAscii);

        Console.WriteLine($"converting {HelloWorld} to bytes and back with ascii");
        Console.WriteLine($"original : {HelloWorld}");
        Console.WriteLine($"converted {hellowWorldConvertedback}");

        Console.WriteLine($"{hellowWorldConvertedback == HelloWorld}");

        string unsupportedAsciiString = "😂 i'm in danger";
        byte[] unsuppoortedAsciiBytes = Encoding.ASCII.GetBytes(unsupportedAsciiString);
        string convertedbackfromunsupportedAscii = Encoding.ASCII.GetString(unsuppoortedAsciiBytes);

        Console.WriteLine($"converting to ascii and back with unsupported cahracter");
        Console.WriteLine($"orginal {unsupportedAsciiString}");
        Console.WriteLine($"coverted {convertedbackfromunsupportedAscii}");
        Console.WriteLine($"orignnial string length {unsupportedAsciiString.Length}");
        Console.WriteLine($"coverted string length {convertedbackfromunsupportedAscii.Length}");
        Console.WriteLine($"    ascii bytes length {unsuppoortedAsciiBytes.Length}");

        Console.WriteLine($"string equal: {unsupportedAsciiString == convertedbackfromunsupportedAscii}");
        Console.WriteLine($"firstchar equal: {unsupportedAsciiString[0] == convertedbackfromunsupportedAscii[0]}");

        //so to solve that both is length is false euqal so we can solve it with converting to utf8 lets see
        byte[] unsupporedstringasUtf8bytes = Encoding.UTF8.GetBytes(unsupportedAsciiString);
        string UnsupportedStringAsUtf8 = Encoding.UTF8.GetString(unsupporedstringasUtf8bytes);

        Console.WriteLine($"converting to utf-8 and back with original cahracter\n");
        Console.WriteLine($"orginal {unsupportedAsciiString}");
        Console.WriteLine($"coverted {unsupporedstringasUtf8bytes}");
        Console.WriteLine($"original length {unsupportedAsciiString.Length}");
        Console.WriteLine($"coverted length {UnsupportedStringAsUtf8.Length}");
        Console.WriteLine($"ascii bytes length {unsuppoortedAsciiBytes.Length}");
        Console.WriteLine($"Utf-8 bytes length {unsupporedstringasUtf8bytes.Length}");

        Console.WriteLine($"string equal: {unsupportedAsciiString == UnsupportedStringAsUtf8}");
        Console.WriteLine($"firstchar equal: {unsupportedAsciiString[0] == UnsupportedStringAsUtf8[0]}");
    }
}
