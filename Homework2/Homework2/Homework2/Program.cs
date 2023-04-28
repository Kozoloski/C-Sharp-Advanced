string appPath = @"..\..\..\Exercise";
string filePath = appPath + @"\calculations.txt";

void CreateFolder(string path)
{
    if (!Directory.Exists(path))
    {
        Directory.CreateDirectory(path);
    }
}

void CreateFile(string path)
{
    if (!File.Exists(path))
    {
        File.Create(path).Close();
    }
}

string Calculate(int num1, int num2)
{
    int result = num1 + num2;
    return num1 + " + " + num2 + " = " + result;
}



void Calculation()
{
    try
    {
        Console.Write("Enter number one: ");
        int num1 = int.Parse(Console.ReadLine());
        Console.Write("Enter number two: ");
        int num2 = int.Parse(Console.ReadLine());

    
        string result = Calculate(num1, num2);
        Console.WriteLine(result);


        using (StreamWriter sw = File.AppendText(filePath))
        {
            sw.WriteLine(result + " " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }


}

Calculation();
CreateFolder(appPath);
CreateFile(filePath);

