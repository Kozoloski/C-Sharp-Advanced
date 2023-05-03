using Domain;
using Newtonsoft.Json;

string folderPath = @"..\..\..\DataBase";
string filePath = @"..\..\..\DataBase\dog.json";

if (!Directory.Exists(folderPath))
{
    Directory.CreateDirectory(folderPath);
}


if (!File.Exists(filePath))
{
    File.Create(filePath).Close();
}

ReaderWriter readerWriter = new ReaderWriter();

try
{
    List<Dog> dogsList = new List<Dog>();

    string jsonFileContent = readerWriter.Reader(filePath);

    if (!string.IsNullOrWhiteSpace(jsonFileContent))
    {
        dogsList = JsonConvert.DeserializeObject<List<Dog>>(jsonFileContent);
    }

    Console.WriteLine("Enter the dog's name:");
    string dogName = Console.ReadLine();

    Console.WriteLine("Enter the dog's age:");
    int dogAge = int.Parse(Console.ReadLine());

    Console.WriteLine("Enter the dog's color:");
    string dogColor = Console.ReadLine();
    

    Dog newDog = new Dog()
    {
        Name = dogName,
        Age = dogAge,
        Color = dogColor
    };

    dogsList.Add(newDog);

    string jsonString = JsonConvert.SerializeObject(dogsList);
    readerWriter.Writer(filePath, jsonString);

    PrintDogs(dogsList);
}
catch (Exception ex)
{
    Console.WriteLine("ERROR: " + ex.Message);
}

void PrintDogs(List<Dog> dogsList)
{
    foreach (Dog dog in dogsList)
    {
        Console.WriteLine($"Name: {dog.Name}, Age: {dog.Age}, Color: {dog.Color}");
    }
}
