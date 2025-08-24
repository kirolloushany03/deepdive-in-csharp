using System.Text;

namespace DeepDive_In_C_.workingWithBinary_and_StringData;

public class Streams
{
    public static void RunStreamsExamples()
    {
        //here we go again 
        //streams
        // allow us to navicate through a set of bytes
        //streams privide us a common api for working with binary data
        //without have to know exactly how that data is represented

        //so for streams all the streams have base calss called streams
        //Stream stream = new Stream();// so it will not compile as it is abstract one but the rest types
        //is inherting from this base class () so sth like that come from the base class things like
        // * length
        // * current postions
        // * whether we can read from or write to 
        // * note that all the streams get theses properties / methods because they inhert from the base class
        // *  but not all fo them support all the the functionality
        //--------------
        // MemoryStream |
        //--------------
        MemoryStream mymemorystream = new MemoryStream();

        Console.WriteLine("writting to stream");
        Console.WriteLine($"stream postion before  {mymemorystream.Position}");
        Console.WriteLine($"stream length before   {mymemorystream.Length}");
        Console.WriteLine($"stream capacity before {mymemorystream.Capacity}");

        byte[] data = Encoding.UTF8.GetBytes("hello world from kiro");
        mymemorystream.Write(data, offset: 0, count: data.Length);

        Console.WriteLine("\nwritting to stream\n");
        Console.WriteLine($"stream postion after  {mymemorystream.Position}");
        Console.WriteLine($"stream length after   {mymemorystream.Length}");
        Console.WriteLine($"stream capacity after {mymemorystream.Capacity}");

        Console.WriteLine("\nrepostioning memory strem....");
        mymemorystream.Seek(0, SeekOrigin.Begin);
        //or
        mymemorystream.Position = 0; //or manually
        Console.WriteLine($"strem postion after: {mymemorystream.Position}");

        //now we can read our data but 
        // how much data do we need to read?
        // where are we putting it?
        byte[] readbuffer = new byte[mymemorystream.Length];

        Console.WriteLine("\nReading from Memory Stream...");
        int NumberOfBytesRead = mymemorystream.Read(readbuffer, 0, readbuffer.Length);
        Console.WriteLine($"Number of bytes read: {NumberOfBytesRead}");

        string ReadString = Encoding.UTF8.GetString(readbuffer);
        Console.WriteLine($"Read string: {ReadString}");


        //shorcut way to getting the bytes in memory stream
        Console.WriteLine("\nReading data from memory sttream using ToArry()...");
        byte[] memorybytesnew = mymemorystream.ToArray();

        ReadString = Encoding.UTF8.GetString(memorybytesnew);
        Console.WriteLine($"read string: {ReadString}");
    }
}
