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


using DeepDive_In_C_;

PrimerOnClasses_refence_AndValueTypes.RuncExamples();
