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
/*//enums
//Enums are value types
//the better to use enums in situation that you will not change the values of it
//can we change the enums --> no

*enums we can call are in fact a numeric type --> that we can cast it as an integer
 * but we can not cast enum as string
 

//so here we can cast the inum as integer
using System.Runtime.Serialization;

int monday = (int)DaysOfWeek.monday;

//but we can not cast it as string
//string monday = (string)DaysOfWeek.monday; //can not convert daysofweek to string

//and this the confucing part that when we wrte enums to the console
//they look like stings!
Console.WriteLine($"enum value directly: {DaysOfWeek.monday}");
Console.WriteLine($"enum value casted to int: {(int)DaysOfWeek.monday}");

//but we can go from an << enum to a string >>
//so we need to use the ToString() Method to do that
string mondaystring = DaysOfWeek.monday.ToString();
Console.WriteLine($"this the string representation of it -->  {mondaystring} --type--> {mondaystring.GetType()}");

//and to go from << string to enum >> we need parsing
//we need to use Enum.Parse and this need the enum type and sting value
//also we have another variabion in mondayenum2 with genierics with <>
Console.WriteLine(DaysOfWeek.Friday.GetType());

DaysOfWeek Fridayenum = (DaysOfWeek)Enum.Parse(typeof(DaysOfWeek), "Friday");
//another version of parsing
DaysOfWeek fridayenum2 = Enum.Parse<DaysOfWeek>("Friday");

Console.WriteLine($"fridayenum = {Fridayenum} type {Fridayenum.GetType()} and this fridayenum2 = {fridayenum2} type {fridayenum2.GetType()}");

//there is also TryParse validation as well:
DaysOfWeek mondayenum3;
bool parssuccesed = Enum.TryParse("monday", out mondayenum3);
Console.WriteLine($"Enum {(parssuccesed ? "was parsed" : "was not parsed")}: {mondayenum3}");

//so why here still see sunday printed even the  enum was not sucesseful
// and this becasue the default numeric value of the enum is 0
// and sunday is also assigned to the numeric value 0
bool parssuccesed2 = Enum.TryParse("kiro", out mondayenum3);
Console.WriteLine($"Enum {(parssuccesed2 ? "was parsed" : "was not parsed")}: {mondayenum3}");

//and if we changed to dayofweek2 and here we jsut set the numeric values form 1 -7
//still will get not parsed and numeric value 0
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
//wierd behavior where we can techincally cast an int to an enum
//even if the int desn;t correspont to a valid enum value!
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

enums also be used as "flags"
using bitwise opertors
why we assign the numbers like this  0 1 2 4 this numbering called the power of 2
and we do this to the number to dont get confused when we use opertors
like if assing 0 1 2 3 instead of  0 1 2  4
in the first one if we jsut made 1 + 2 (read + write) this will give us 3 but 3 assigend before to "excute"
so the computer will get confused which one to make the two choises read + write or do excute
thats why we do it power of 2
also we have all the freedom to do what we want and assign  what we want

[Flags]
enum permissions
{
    None = 0,
    read = 1,
    write = 2,
    Excute = 4
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

/*using DeepDive_In_C_;

Enums.run_enums();*/


//=============================================================

//begin in struct
//it is a value type
/*
 * look like calss, 
 * also have a construcotor
 * 🏗️ Constructor Difference:
 * When you define a constructor with parameters in a class, 
 *  the default parameterless constructor disappears ❌.

 * But in a struct, even if you define a constructor with parameters, 
 *  the default parameterless constructor still exists ✅.
 *  
 *  
 *  also the struct is stored in the stack and this also a big diffrence
 *  as the stack is faster than the heap as it dont need garbage collector 
 *  so this will beuseful if you have things small and need faster pefromance than clases
 */

//example of a struct
/*
 */




// so when you just pass the class so you give them the refrence which can be controlled by sth else
//but when you pass the struct it makes copy of the struct 

//here is an exmaple of astruct being copied when passed to a method
/*void DoSomethingWithPoint(Point p)
{
    p.X = 111;
    p.Y = 123;
}

var ourpoint = new Point()
{
    X = 124,
    Y = 145
};

Console.WriteLine(ourpoint.GetType()); // so the type of it is point

Console.WriteLine($"ourpoint before Dosomethingwithpoint: " + 
    $"{ourpoint.X}, {ourpoint.Y}");

DoSomethingWithPoint(ourpoint);

Console.WriteLine($"ourpoint after Dosomethingwithpoint: " +
    $"{ourpoint.X}, {ourpoint.Y}");*/

/*
 * 👆👆 and we got here the same values and this because the
 * struct value type bass copy of it not the original one 
*/

/*void DoSomethingWithPointWithProperties(PointWithProperties p)
{
    p.X = 111;
    p.Y = 123;
}

var ourpointWithProb = new PointWithProperties()
{
    X = 124,
    Y = 145
};

Console.WriteLine(ourpointWithProb.GetType()); // so the type of it is point

Console.WriteLine($"ourpointWithProb before DoSomethingWithPointWithProperties: " +
    $"{ourpointWithProb.X}, {ourpointWithProb.Y}");

DoSomethingWithPointWithProperties(ourpointWithProb);

Console.WriteLine($"ourpointWithProb after DoSomethingWithPointWithProperties: " +
    $"{ourpointWithProb.X} ,  {ourpointWithProb.Y}");

//-------------------tying that the two constructor will work // so here what 
var PointWithTwoConstructor = new PointWithConstructor(3,4);

Console.WriteLine($"this x from struct PointWithConstructor {PointWithTwoConstructor.X}" +
    $" and this the Y from struct PointWithConstructor {PointWithTwoConstructor.Y}");*/
/*
    because structs can look like classes, it can be
    confusing when to use a struct and when to use a class
    here are some guidelines:
    -use a struct when you have a small, simple object
    that you want to pass by value
    - use a struct when you want to avoid the overhead
    of heap allocation, garbage collecting, etc ...
    I try to think about very primative things like a
    Point, or a Color, or a Rectangle, or other geometric things
*/

/*public struct Point
{
    public int X;
    public int Y;
}
//same struct but with properties
public struct PointWithProperties
{
    public int X { get; set; }
    public int Y { get; set; }
}

//struct with constructor
public struct PointWithConstructor
{
    public PointWithConstructor()
    {
        Console.WriteLine("hellow from the default");
    }
    public PointWithConstructor(int x, int y)
    {
        X = x;
        Y = y;
    }

    public int X { get; set; }
    public int Y { get; set; }
}

public struct PointWithMethod
{
    public int X;
    public int Y;

    public void Move(int x, int y)
    {
        X += x;
        Y += y;
    }
}*/


/*using DeepDive_In_C_;

Structs.RunStructs_Exersices();*/

//==============================================
//the problem with equality
/*
 * so we can say here 
 * what is the problem here ?
 *      so the probelm here when you work with both in same project staruct(value type) and classes(refrecne type)
 * the probelm that you can get confused by the two behaviours between the value and refrence type
 * so the solution here is to override the behaviour of the equality to make the refrence type (class)
 * to behave likethe value type and this by override three things
 *      1. the Equals method so we can check the content instead of the refrences(memory addresses)
 *                  But that’s only half the story
 *      2. also we will change the the GetHashCode() method for the 
 *              objects go into hash-based collections like Dictionary or HashSet
 *      3. last thing is the operaotr == != to make it to use our Equals method instead of the default one
        \

so this what the people try to do jsut for clarifiying to use we dont have to do that
next one will be the solution
 */

//lets look at class equality
/*var myclass1 = new Myclass { NumericValue = 123, StringValue = "ABC" };
var myclass2 = new Myclass { NumericValue = 123, StringValue = "ABC" };
Console.WriteLine("is myclasss1 is equal to myclass2");
Console.WriteLine(myclass1 == myclass2);
Console.WriteLine(myclass1.Equals(myclass2));
Console.WriteLine(object.Equals(myclass1, myclass2));


var mystruct1 = new Mystruct {NumericValue = 123, StringValue = "soso" };
var mystruct2 = new Mystruct {NumericValue = 123, StringValue = "soso" };
Console.WriteLine("is mystrcut1 is equal to mystruct2");
//Console.WriteLine( mystruct1 == mystruct2); //you need to sepcify the specific propbety
Console.WriteLine(mystruct1.Equals(mystruct2));
Console.WriteLine(object.Equals(mystruct1, mystruct2));


//after modifiying the behaviour of Equals to make the behaviour of the refrence type liekthe value type
var myClassWithEquality1 = new MyclassWithEquality { NumericValue = 123, StringValue = "koko" };
var myClassWithEquality2 = new MyclassWithEquality { NumericValue = 123, StringValue = "koko" };

Console.WriteLine("myClassWithEquality1 is equal to myClassWithEquality2");
Console.WriteLine(myClassWithEquality1 == myClassWithEquality2);
Console.WriteLine(myClassWithEquality1.Equals(myClassWithEquality2));
Console.WriteLine(object.Equals(myClassWithEquality1, myClassWithEquality2));

// so we can modify the behavior of the classes so it can compare the values insteead of the refence only
var myClassWithEqualityAntOperator1 = new MyclassWithEqualityAndOperator { NumericValue= 123 , StringValue = "fofo"};
var myClassWithEqualityAntOperator2 = new MyclassWithEqualityAndOperator { NumericValue= 123 , StringValue = "fofo"};
Console.WriteLine("is myClassWithEqualityAntOperator1 is queal to myClassWithEqualityAntOperator2");
Console.WriteLine(myClassWithEqualityAntOperator1 == myClassWithEqualityAntOperator2);
Console.WriteLine(myClassWithEqualityAntOperator1.Equals(myClassWithEqualityAntOperator2));
Console.WriteLine(object.Equals(myClassWithEqualityAntOperator1, myClassWithEqualityAntOperator2));


public class MyclassWithEqualityAndOperator
{ 
    public int NumericValue { get; set; }
    public string StringValue { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
            return false;

        var other = (MyclassWithEqualityAndOperator)obj;
        return NumericValue == other.NumericValue && StringValue == other.StringValue;
    }

    public override int GetHashCode()
    {
        return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
    }

    public static bool operator ==(MyclassWithEqualityAndOperator left, MyclassWithEqualityAndOperator right)
    { 
        return left.Equals(right);
    }
    public static bool operator !=(MyclassWithEqualityAndOperator left, MyclassWithEqualityAndOperator right)
    { 
        return !left.Equals(right);
    }
}


public class MyclassWithEquality
{
    public string StringValue { get; set; }
    public int NumericValue { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType()) 
            return false;

        var other = (MyclassWithEquality)obj; //🎩 This turns the object into a real MycalssWithEquality type

        return NumericValue == other.NumericValue && StringValue == other.StringValue;
    }

    public override int GetHashCode()
    {
        return NumericValue.GetHashCode() ^ StringValue.GetHashCode();
    }
}

public class Myclass
{ 
    public int NumericValue { get; set; }
    public string StringValue { get; set; }
}

public struct Mystruct
{
    public int NumericValue { get; set; }
    public string StringValue { get; set; }
}
*/
/*using DeepDive_In_C_;

ProblemWithEquality.Run();*/


//====================================================================================
//records the solution of the previous problem
//  (problem between the refrence and value type equlaity)
//record is refrence type and dealing with the value type results

/*MyRecord myrecord1 = new(123, "ABC");

MyRecord2 myrecord2 = new()
{
    NumbericValue = 123,
    stringvalue = "ABC"
};

Console.WriteLine(myrecord2);


//not the both casese we cannot change the propetires
//becaue the they are both init only:
//myrecord2.stringvalue = "kkk"; // will not compile
//myrecord2.NumbericValue= 1456; //will not compile  and this becaue the init


//how the eqality will works with the record  ?
MyRecord recordA = new(123, "ABC");
MyRecord recordB = new(123, "ABC");
Console.WriteLine("is recordA is equal to recordB");
Console.WriteLine(recordA == recordB); //true
Console.WriteLine(recordA.Equals(recordB)); //true
Console.WriteLine(object.Equals(recordA, recordB)); //true


//we can use the "with "keyword to create new record
// with the same values as the original , but with some changes

MyRecord recordC = recordA with {NumericValue = 1258 };

Console.WriteLine(recordA);
Console.WriteLine(recordB);
Console.WriteLine(recordC);

//we can also decostruct the record in to its properties
//why we use the decostruct
*//*
 * ✅ Use Case: Deconstruction in Records
 *
 * 1. Simplified Property Access:
 *    - Easily extract values without dot notation clutter.
 *    - Example: var (name, age) = person;
 *
 * 2. LINQ Integration:
 *    - Makes projection and filtering more elegant in Select/Where.
 *    - Example: people.Select(p => { var (n, _) = p; return n; });
 *
 * 3. Pattern Matching:
 *    - Deconstruct directly in switch expressions or match patterns.
 *    - Example: person switch { ("Alice", 25) => "Matched!", _ => "Default" }
 *
 * 4. Clean API/Controller Logic:
 *    - Deconstruct DTOs in minimal APIs or MVC controllers.
 *    - Example: var (username, password) = loginRequest;
 *
 * 5. Readability & Immutability:
 *    - Enhances readability and works naturally with record immutability.
 *//*
var (recValue, recString) = recordA;
Console.WriteLine("\nthis from the deconstruct of the record A");
Console.WriteLine(recValue);
Console.WriteLine(recString);



MyRecordWithExtraProperties newone = new(123, "kkk");
Console.WriteLine($"stringvalue: {newone.StringValue} , intvalue: {newone.NumericValue}, property:{newone.Extraproperty}");

newone.Extraproperty = "kk is the best";

Console.WriteLine($"stringvalue: {newone.StringValue} , intvalue: {newone.NumericValue}, property:{newone.Extraproperty}");


*//*
 * if neded we can mix in th thinks liek additional properties 
 * that are not just form the posional ones on the constructor
 *//*
public record MyRecordWithExtraProperties(
    int NumericValue,
    string StringValue)
{
    public string Extraproperty { get; set; }
}




//in the deconstrct we have to postion the order
//  based on the order fo the probperties if not will not wrok

//(string recstring, int recvalue) = recordA; // will not compile

*//*
 * records can also be defined as a structs which means they'll 
 * will be on the stacck instead of the heap and this can be useful for 
 * things for performance 
 *//*

public record struct MyRecordStruct(
    int NumericValue,
    string StringValue);



public record MyRecord(
    int NumericValue,
    string stringvalue
    );

//so th init make the proeperties as immutable
public record MyRecord2
{ 
    public int NumbericValue { get; init; }
    public string stringvalue { get; init; }
}
*/


//========================================================================
/*using DeepDive_In_C_;

//just this without static class
*//*Records tryit = new();
tryit.RunRecords();*//*

//and this with static class
Records.RunRecords();*/