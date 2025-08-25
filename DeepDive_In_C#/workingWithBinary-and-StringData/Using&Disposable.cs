namespace DeepDive_In_C_.workingWithBinary_and_StringData;
internal class Using_Disposable
{
    public void Runexmaples()
    {
        //using & Disposal
        // What is IDisposable ??
        //      is interface we're provided with that allow us to indicate that we have
        //      recources that need to be released
        //when we have to use Disposal ? because c# should be handdel all of this with the gc(garabage collector)
        //      - streams , files , network, memory
        //      -if we are dealing with some recources don't work with the garbage collector of the c# or not in the c# lang
        //          thing like a third party like sql connection

        //part 1
        Stream readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
        //we need to do work
        //the problem here that we don't gurntee that dispose method is going to get called while our applications's running
        //because also could and exception get thrown 
        readmeStream.Dispose();

        //part 2
        //another wayt o fixit 
        // to use try and catch 
        //      so it works but...
        //prblems with that 
        //      that ugly look 
        //      we need to implment try and catch 

        readmeStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read);
        try
        {
            //to sth
        }
        catch
        {
            //to sth
        }
        finally
        {
            readmeStream.Dispose();
        }

        //part 3
        //the best practice for this situation is by using Using
        //if we put anthing inside the using that is not dispoable will not combile

        using (Stream myUsingStream = File.Open("readme.txt", FileMode.Open, FileAccess.Read))
        {
            myUsingStream.Dispose();
        }

        //the best and last form part 4
        //so it works we have variable defined just for the scobe and if it get out of the scope will get disposed
        //so need for sth simple this one need more implemnation the previous one
        //so this one when the variable is getting out the scope 
        using Stream myUsingStream2 = File.Open
            (
            "readme.txt",
            FileMode.Open,
            FileAccess.Read
            );
    }

    public class MyDisoposable : IDisposable
    {
        public void Dispose()
        {
            //you will do here all what you want to dispose
        }
    }
}
