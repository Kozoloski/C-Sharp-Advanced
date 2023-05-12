using Services;

MainApp timeTrackingApp = new MainApp();

while (true)
{
    Console.Clear();
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine("===== Welcome to the Time Tracking App =====\n");
    Console.ResetColor();
    Console.WriteLine("Please choose an option:\n");
    Console.WriteLine("1) Login");
    Console.WriteLine("2) Register");
    Console.WriteLine("3) Exit");

    string option = Console.ReadLine();
    Console.WriteLine();

    switch (option)
    {
        case "1":
            timeTrackingApp.Login();
            Console.WriteLine();
            break;
        case "2":
            timeTrackingApp.RegisterNewUser();
            Console.WriteLine();
            break;
        case "3":
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Good bye!\n");
            Console.ResetColor();
            break;
        default:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter one of the options listed!!!\n");
            Console.ResetColor();
            break;
    }
    if (option == "3")
    {
        break;
    }
}