using System.Text.Json;
using System.Xml;

namespace DeepDive_In_C_.workingWithBinary_and_StringData;

internal class Xml_Json
{
    public void RunExamples()
    {
        string rawxml =
            """
            <people>
                <person>
                    <name>kiro here</name>
                    <age>211</age>
                </person>
            </people>
            """;

        File.WriteAllText("people.xml", rawxml);


        XmlDocument xmlDocument = new();
        xmlDocument.Load("people.xml");

        XmlNodeList? people = xmlDocument.SelectNodes("/people/person");
        if (people != null)
        {
            foreach (XmlNode person in people)
            {
                Console.WriteLine(person["name"].InnerText);
                Console.WriteLine(person["age"].InnerText);
                //so to change both of them in the right format you have to split them and spcifiy them
                person["name"].InnerText = person["name"].InnerText.ToUpper();
                person["age"].InnerText = person["age"].InnerText.ToUpper();
            }
        }
        else
        {
            Console.WriteLine("no poeple found");
        }

        xmlDocument.Save("people2.xml");
        Console.WriteLine("\ncontent of people2\n");
        Console.WriteLine(File.ReadAllText("people2.xml"));
        //-------------------------------------------------------
        //-----------------------------json-----------------------
        //json => it's lighter weigh but accomplishes a similar goal 
        //so this willnot make json and write like the xml will make objects to json (serilisation) and viceversa(deserliztion

        /* flow
         * serilizing -> deserlizing
         * string representation -> bytes representation and vicerversa
         */

        PeopleCollection peopleCollection = new(new[]
        {
    new Person("soso", 23),
    new Person("koko", 21)
});

        Console.WriteLine("serlizing people to json");
        string rawjson = JsonSerializer.Serialize(peopleCollection);
        Console.WriteLine(rawjson);

        File.WriteAllText("people.json", rawjson);

        //Console.WriteLine(File.ReadAllText("people.json"));
        //File.ReadAllText("people.json");

        //now deserlising from json to object
        //we have two way using stream and using string

        Console.WriteLine("\nDesrilizing people from json using stream .....");
        using var peopleJsonStream = File.OpenRead("people.json");

        PeopleCollection deserilizedPeopleFromStream = JsonSerializer.Deserialize<PeopleCollection>(peopleJsonStream);

        foreach (var person in deserilizedPeopleFromStream.People)
        {
            Console.WriteLine($"{person.Name} : {person.Age}");
        }

        Console.WriteLine("Desrilizing people from json using String .....");
        var deserilizedPeopleFromString = JsonSerializer.Deserialize<PeopleCollection>(File.ReadAllText("people.json"));


        foreach (var person in deserilizedPeopleFromString.People)
        {
            Console.WriteLine($"{person.Name} : {person.Age}");
        }

        /*
        For large files / performance-critical apps → use Stream 🏎️
        For small/medium JSON or when you already have a string → use Text 📝
         */

    }
    public record Person(string Name, int Age);
    public record PeopleCollection(Person[] People);
}
