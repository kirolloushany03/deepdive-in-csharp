using System.Diagnostics;

namespace DeepDive_In_C_.workingWithBinary_and_StringData;

internal class cmdExcutionUsing_ToDiospose
{
    public void RunCmdExcutionExample()
    {
        /*
            so this exmple of how we can use Using to be able to dispose cmd excution to say hellow
         */

        using (Process process = new())
        {
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.Arguments = "/c echo Hellow form cmd using c#";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.Start();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Console.WriteLine($"this what we got ffrom the cmd -->>>> {output}");
        }

        //or we can also use it like this 
        using Process process2 = new Process();
        process2.StartInfo.FileName = "cmd.exe";
        process2.StartInfo.Arguments = "/c echo Hellow form cmd using c# using the .net8 syntax";
        //process2.StartInfo.Arguments = "/c dir";
        process2.StartInfo.UseShellExecute = false;
        process2.StartInfo.CreateNoWindow = true;
        process2.StartInfo.RedirectStandardOutput = true;

        process2.Start();
        string output2 = process2.StandardOutput.ReadToEnd();
        process2.WaitForExit();

        Console.WriteLine($"this what we got ffrom the cmd2 -->>>> {output2}");
    }
}
