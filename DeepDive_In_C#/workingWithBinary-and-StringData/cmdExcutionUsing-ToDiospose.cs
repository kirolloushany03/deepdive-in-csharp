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
    }
}
