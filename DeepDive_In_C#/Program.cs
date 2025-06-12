/*//classes types (refrence types) vs
//value types (prmitive data types) --> (integers, doubles and boleans)more

//what we will do just we will just call these things in functions and will see what will happen

//refernce types --> talking about shared refrence that's in memery and work with it 
//value types --> copied around
Console.WriteLine("==============add to list by passing the ref of it==============");


List<string> ourlist = new()
{ 
    "hello",
    "kiro"
};

void DoSthWithRefrence(List<string> list)
{
    list.Add("from");
    list.Add("kiro3");
}
Console.WriteLine("this before refrenceing:\n");
Console.WriteLine(string.Join("\n", ourlist));

Console.WriteLine("\nthis after refrenceing:\n");

DoSthWithRefrence(ourlist);

foreach (var list in ourlist)
{
    Console.WriteLine(list);
}


//above so what happned here
//1- we we wrote new() adn add "hello" and "kiro"
//now the object list created that has "hello and kiro" in the heap and
//sent to the variable that named ourlist the refrence of the place of that  object in the memorey
//so now ourlist is just pointing to the object in the heap memomry 
// when we just add ourlist to the function called "DosthwithRefernce"
// and in this function there is a prameter that now pointint to the same list(object) that variable  ourlist points 2 
//so now we have two varaibalbes points to the same object means have the reference or the place that the object in the heap memorey
//so when we just added some strings in the function and print the function again we found that the list has the new strings taht added from teh function
//and this because variable that in the parm of the function points to the same object

Console.WriteLine("==============try to change the value by passing the value==============");

//now with valuse

string ourstring = "hello, kiro";

void Dosthwithvalue(string value)
{
    value = "Kiro the best";
}

Console.WriteLine("\nvalue before:\n");
Console.WriteLine(ourstring);

Console.WriteLine("\nvalue after:\n");
Dosthwithvalue(ourstring);
Console.WriteLine(ourstring);


//so here the value did not changed and this because this becaseu teh function modified the value insside only the vfunction not outside 

//but we can modifi the value by passing the refrence of the value like we did in the object
//and this by using the word ref


Console.WriteLine("==============change the value by passing the ref==============");
void DoSthWithValueByRef(ref string value)
{
    value = "kiro the best";
}

Console.WriteLine("\nvalue before:\n");
Console.WriteLine(ourstring);

Console.WriteLine("\nvalue after:\n");
DoSthWithValueByRef(ref ourstring);
Console.WriteLine(ourstring);

//what the ref keyword do the ref keyword is just tellig eh compiler that this value is 
// passing by refrence not by value 
//✅ That means the method receives a reference to the original variable, not a copy.
//When you use ref, the function receives a reference to the memory address of the variable,
  //not just its value.
//This enables:

//✅ Modifying the original variable

//✅ Skipping unnecessary value copies (especially for structs!)

//✅ Returning references from methods*/

//uncomment to run the exmples 

/*using DeepDive_In_C_;

PrimerOnClasses_refence_AndValueTypes.RuncExamples();*/

//=============================================================

/*//Enums are value types
//the better to use enums in situation that you will not change the values of it
//can we change the enums --> no*/
/*
 * enums we can call are in fact a numeric type --> that we can cast it as an integer
 * but we can not cast enum as string
 */

/*//so here we can cast the inum as integer
using System.Runtime.Serialization;

int monday = (int)DaysOfWeek.monday;

*//*//but we can not cast it as string
//string monday = (string)DaysOfWeek.monday; //can not convert daysofweek to string*/

/*//and this the confucing part that when we wrte enums to the console
//they look like stings!*//*
Console.WriteLine($"enum value directly: {DaysOfWeek.monday}");
Console.WriteLine($"enum value casted to int: {(int)DaysOfWeek.monday}");

*//*//but we can go from an << enum to a string >>
//so we need to use the ToString() Method to do that*//*
string mondaystring = DaysOfWeek.monday.ToString();
Console.WriteLine($"this the string representation of it -->  {mondaystring} --type--> {mondaystring.GetType()}");

*//*//and to go from << string to enum >> we need parsing
//we need to use Enum.Parse and this need the enum type and sting value
//also we have another variabion in mondayenum2 with genierics with <>*//*
Console.WriteLine(DaysOfWeek.Friday.GetType());

DaysOfWeek Fridayenum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Friday");
//another version of parsing
DaysOfWeek fridayenum2 = Enum.Parse<DaysOfWeek>("Friday");

Console.WriteLine($"fridayenum = {Fridayenum} type {Fridayenum.GetType()} and this fridayenum2 = {fridayenum2} type {fridayenum2.GetType()}");

//there is also TryParse validation as well:
DaysOfWeek mondayenum3;
bool parssuccesed = Enum.TryParse("monday", out mondayenum3);
Console.WriteLine($"Enum {(parssuccesed ? "was parsed" : "was not parsed")}: {mondayenum3}");

*//*//so why here still see sunday printed even the  enum was not sucesseful
// and this becasue the default numeric value of the enum is 0
// and sunday is also assigned to the numeric value 0*//*
bool parssuccesed2 = Enum.TryParse("kiro", out mondayenum3);
Console.WriteLine($"Enum {(parssuccesed2 ? "was parsed" : "was not parsed")}: {mondayenum3}");

*//*//and if we changed to dayofweek2 and here we jsut set the numeric values form 1 -7
//still will get not parsed and numeric value 0*//*
DaysofWeek2 mondayenum4;
bool parssuccesed4 = Enum.TryParse("kiro", out mondayenum4);
Console.WriteLine($"Enum for mondayenum4 {(parssuccesed4 ? "was parsed" : "was not parsed")}: {mondayenum4}");

//we can also use the enum.getvalues method to get all the values of an enum

Console.WriteLine("\nAll Enum Values:");
Console.WriteLine("print values with casting");

foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
{
    Console.WriteLine($"Enum value: {(int)day} and type: {day.GetType()}");
}

Console.WriteLine("\nprint values without casting");

foreach (DaysOfWeek day in Enum.GetValues(typeof(DaysOfWeek)))
{
    Console.WriteLine($"Enum value: {day} and type: {day.GetType()}");
}

Console.WriteLine("\nprint all the names of the enum string");

Console.WriteLine("\nAll Enum Names");
foreach (string day in Enum.GetNames(typeof(DaysOfWeek)))
{
    Console.WriteLine($"Enum Name: {day} and type: {day.GetType()}");
}
Console.WriteLine("\n");
*//*//wierd behavior where we can techincally cast an int to an enum
//even if the int desn;t correspont to a valid enum value!*//*
DaysOfWeek invalidday = (DaysOfWeek)8;
Console.WriteLine($"Invalid Enum Value: {invalidday} type of it {invalidday.GetType()}");

permissions readwrite = permissions.read | permissions.write;
Console.WriteLine($"RW: {readwrite}");

//we can check if a flas is set like this :
bool canRead = (readwrite & permissions.read) == permissions.read;
bool canWrite = (readwrite & permissions.write) == permissions.write;
bool canExcute = (readwrite & permissions.Excute) == permissions.Excute;

Console.WriteLine($"canRead : {canRead}");
Console.WriteLine($"canWrite : {canWrite}");
Console.WriteLine($"canExcute : {canExcute}");

*//* enums also be used as "flags"
using bitwise opertors
why we assign the numbers like this  0 1 2 4 this numbering called the power of 2
and we do this to the number to dont get confused when we use opertors
like if assing 0 1 2 3 instead of  0 1 2  4
in the first one if we jsut made 1 + 2 (read + write) this will give us 3 but 3 assigend before to "excute"
so the computer will get confused which one to make the two choises read + write or do excute
thats why we do it power of 2
also we have all the freedom to do what we want and assign  what we want
*//*
[Flags]
enum permissions
{ 
    None     = 0,
    read     = 1,
    write    = 2,
    Excute   = 4
}


enum DaysOfWeek
{ 
    sunday, 
    monday, 
    tuesday, 
    wednesday, 
    thursday, 
    Friday, 
    saturday
}  

//we can also define the enums like this in another way
enum DaysofWeek2 
{
    sunday = 1,
    monday = 2,
    tuesday = 3,
    wednesday = 4,
    thursday = 5,
    Friday = 6,
    saturday = 7
}*/

using DeepDive_In_C_;

Enums.run_enums();