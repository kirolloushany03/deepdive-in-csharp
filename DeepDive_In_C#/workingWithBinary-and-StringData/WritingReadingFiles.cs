using System.Text;

namespace DeepDive_In_C_.workingWithBinary_and_StringData;

internal class WritingReadingFiles
{
    public static void RunExamples()
    {

        File.WriteAllText("readwritec#.txt", "hello from c#");
        File.WriteAllBytes("readwritec#.txt", Encoding.UTF8.GetBytes("hello from c#"));

        byte[] someFileBytes = File.ReadAllBytes("readwritec#.txt");
        string someFilestring = File.ReadAllText("readwritec#.txt", Encoding.UTF8);

        Console.WriteLine($"this the info read from bytes {Encoding.UTF8.GetString(someFileBytes)}" +
            $"\nand this from string {someFilestring}");
        //--------------- part 2------------------

        //we can use similar methods to gain access to a stream!
        FileStream filestream = File.Open
            (
                "D:\\.net vs\\first try\\DeepDive_In_C#\\DeepDive_In_C#\\readwritec#.txt",
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.Read
            );

        byte[] buffer = Encoding.UTF8.GetBytes("here we go agin");
        filestream.Write(buffer, 0, buffer.Length);

        //we can also use the apais directly on the stream class
        Stream filestreamAsStream = filestream;
        filestream.Seek(0, SeekOrigin.Begin);
        filestreamAsStream.Write(buffer, 0, buffer.Length);

        filestream.Close();
        //---------------part 3-------------------

        //then we can use the very similar api for reading from a file
        FileStream readingStream = File.Open
            (
            "readwritec#.txt",
            FileMode.Open,
            FileAccess.Read,
            FileShare.None
            );

        byte[] bufferForereading = new byte[readingStream.Length];
        var bytesReadFromStream = readingStream.Read(bufferForereading, 0, bufferForereading.Length);
        Console.WriteLine(bytesReadFromStream);

        //----------------part 4-----------------------
        //but if the file is too large what we do and don't know what is the file size is 
        readingStream.Seek(0, SeekOrigin.Begin);
        StreamReader reader = new StreamReader(readingStream, encoding: Encoding.UTF8);

        while (!reader.EndOfStream)
        {
            string line = reader.ReadLine(); //this one variation nof the reader
            Console.WriteLine(line);
        }
        //------------------part 5-------------------------------
        //also we can make it to read it in chunks
        int chunkSize = 5; //1024
        Console.WriteLine($"\nReading chunks of size {chunkSize} of file...");
        readingStream.Seek(0, SeekOrigin.Begin);
        byte[] bufferforchunking = new byte[chunkSize];
        while (
            (
            bytesReadFromStream = readingStream.Read(bufferforchunking, 0, bufferforchunking.Length)
            )
            > 0)
        {
            Console.WriteLine($"Read {bytesReadFromStream} bytes for this chunk");
        }
    }
}
