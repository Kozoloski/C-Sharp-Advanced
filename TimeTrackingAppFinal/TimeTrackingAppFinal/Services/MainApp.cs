using Domain.Models;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class MainApp
    {
        private User currentUser;
        private IUserManager userManager;
        public MainApp()
        {
            userManager = new UserManager();
        }
        public void RegisterNewUser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("===== Welcome to the Register Menu =====\n");
            Console.ResetColor();

            Console.Write("Enter a First Name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine();

            if (firstName.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Your first name should be at least 2 characters!!!");
                Console.ResetColor();
            }

            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine();

            if (lastName.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Your last name should be at least 2 characters!!!");
                Console.ResetColor();
            }

            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.WriteLine();

            if (age < 18 || age > 120)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Your should be at least 18 years old and not older than 120 !!!");
                Console.ResetColor();
            }

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine();

            if (username.Length < 5)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Username should be at least 5 characters!!!");
                Console.ResetColor();
            }

            Console.Write("Enter password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            if (password.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERROR: Password should be at least 6 characters!!!");
                Console.ResetColor();
            }
            User newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username,
                Password = password,
                Age = age
            };
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Registration successful!\n");
            Console.ResetColor();

            userManager.AddUser(newUser);
        }
        public void Login()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Welcome to the Login Menu =====\n");
            Console.ResetColor();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.WriteLine();

            if (username.Length < 5 || password.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid username or password.");
                Console.ResetColor();
                return;
            }

            var loginUser = userManager.GetUserByUserName(username);
            if (loginUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Username doesn't exist! Please register first!");
                Console.ResetColor();
                return;
            }
            if (loginUser.Password != password)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorect password for the username!");
                Console.ResetColor();
                return;
            }
            currentUser = loginUser;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Login successful!\n");
            Console.ResetColor();

            while (true)
            {
                
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"Welcome {currentUser.FirstName} {currentUser.LastName}! \n");
                Console.ResetColor();
                Console.WriteLine("Choose one of the options:\n");
                Console.WriteLine("1) Track Activity");
                Console.WriteLine("2) User Statistics");
                Console.WriteLine("3) Account Managment");
                Console.WriteLine("4) Log Out");

                string option = Console.ReadLine();
                Console.WriteLine();

                switch (option)
                {
                    case "1":
                        Console.Clear();
                        TrackActivity();
                        break;

                    case "2":
                        Console.Clear();
                        GetStatistics();
                        break;

                    case "3":
                        Console.Clear();
                        AccountManagement();
                        break;

                    case "4":
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine("Logged out successfully!\n");
                        Console.ResetColor();
                        return;

                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Enter one of the options listed!!!\n");
                        Console.ResetColor();
                        break;
                }
            }
        }
        public void TrackActivity()
        {
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please log in first.");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("===== Track Activity =====\n");
            Console.ResetColor();
            Console.WriteLine("Choose your activity: \n");
            Console.WriteLine("1) Reading");
            Console.WriteLine("2) Exercising");
            Console.WriteLine("3) Working");
            Console.WriteLine("4) Other Hobbies");

            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please enter a number.");
                Console.ResetColor();
            }
            Console.WriteLine();
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    TrackReadingActivity();
                    break;
                case 2:
                    Console.Clear();
                    TrackExercisingActivity();
                    break;
                case 3:
                    Console.Clear();
                    TrackWorkingActivity();
                    break;
                case 4:
                    Console.Clear();
                    TrackOtherHobbiesActivity();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.");
                    Console.ResetColor();
                    break;
            }
        }

        private void TrackReadingActivity()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Reading\n");
            Console.ResetColor();
            Console.WriteLine("Press Enter to start the timer.");
            Console.ReadLine();

            DateTime startTime = DateTime.Now;

            Console.WriteLine("Timer started. Press Enter to stop the timer.");
            Console.ReadLine();

            DateTime stopTime = DateTime.Now;
            TimeSpan timeSpent = stopTime - startTime;

            Console.Write("Enter the type of reading (Belles Lettres, Fiction, Professional Literature): ");
            string type = Console.ReadLine();

            Activity activity = new Activity
            {
                Name = "Reading",
                TimeSpent = (int)timeSpent.TotalSeconds,
                ExtraInfo = type
            };

            currentUser.Activities.Add(activity);
            userManager.UpdateUser(currentUser);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Time spent on Reading: {timeSpent.TotalSeconds} seconds\n");
            Console.ResetColor();
        }

        private void TrackExercisingActivity()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Exercising\n");
            Console.ResetColor();

            Console.WriteLine("Press Enter to start the timer.");
            Console.ReadLine();

            DateTime startTime = DateTime.Now;

            Console.WriteLine("Timer started. Press Enter to stop the timer.");
            Console.ReadLine();

            DateTime stopTime = DateTime.Now;
            TimeSpan timeSpent = stopTime - startTime;

            Console.Write("Enter the type of exercise (General, Running, Sport): ");
            string type = Console.ReadLine();

            Activity activity = new Activity
            {
                Name = "Exercising",
                TimeSpent = (int)timeSpent.TotalSeconds,
                ExtraInfo = type
            };

            currentUser.Activities.Add(activity);
            userManager.UpdateUser(currentUser);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Time spent on Exercing: {timeSpent.TotalSeconds} seconds");
            Console.ResetColor();
        }
        private void TrackWorkingActivity()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Working\n");
            Console.ResetColor();

            Console.WriteLine("Press Enter to start the timer.");
            Console.ReadLine();

            DateTime startTime = DateTime.Now;

            Console.WriteLine("Timer started. Press Enter to stop the timer.");
            Console.ReadLine();

            DateTime stopTime = DateTime.Now;
            TimeSpan timeSpent = stopTime - startTime;

            Console.Write("Enter the work location (Office or Home): ");
            string location = Console.ReadLine();

            Activity activity = new Activity
            {
                Name = "Working",
                TimeSpent = (int)timeSpent.TotalSeconds,
                ExtraInfo = location

            };

            currentUser.Activities.Add(activity);
            userManager.UpdateUser(currentUser);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Time spent on Working: {timeSpent.TotalSeconds} seconds");
            Console.ResetColor();
        }

        private void TrackOtherHobbiesActivity()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Other Hobbies\n");
            Console.ResetColor();

            Console.WriteLine("Press Enter to start the timer.");
            Console.ReadLine();

            DateTime startTime = DateTime.Now;

            Console.WriteLine("Timer started. Press Enter to stop the timer.");
            Console.ReadLine();

            DateTime stopTime = DateTime.Now;
            TimeSpan timeSpent = stopTime - startTime;

            Console.Write("Enter the name of the hobby: ");
            string hobbyName = Console.ReadLine();

            Activity activity = new Activity
            {
                Name = "Other Hobbies",
                TimeSpent = (int)timeSpent.TotalSeconds,
                ExtraInfo = hobbyName

            };

            currentUser.Activities.Add(activity);
            userManager.UpdateUser(currentUser);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Time spent on Hobbies: {timeSpent.TotalSeconds} seconds");
            Console.ResetColor();
        }

        public void GetStatistics()
        {
            if (currentUser == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please log in first.\n");
                Console.ResetColor();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("* User Statistics ***\n");
            Console.ResetColor();
            Console.WriteLine("1. Reading\n");
            Console.WriteLine("2. Exercising\n");
            Console.WriteLine("3. Working\n");
            Console.WriteLine("4. Other Hobbies\n");
            Console.WriteLine("5. Global\n");

            Console.Write("Enter your choice: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid choice. Please enter a number.\n");
                Console.ResetColor();
                Console.Write("Enter your choice: ");
                Console.WriteLine();
            }

            switch (choice)
            {
                case 1:
                    GetReadingStatistics();
                    break;
                case 2:
                    GetExercisingStatistics();
                    break;
                case 3:
                    GetWorkingStatistics();
                    break;
                case 4:
                    GetOtherHobbiesStatistics();
                    break;
                case 5:
                    GetGlobalStatistics();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice.\n");
                    Console.ResetColor();
                    break;
            }
        }

        private void GetReadingStatistics()
        {
            int totalReadingTime = 0;
            int totalReadingPages = 0;
            int totalReadingActivities = 0;

            foreach (var activity in currentUser.Activities)
            {
                if (activity.Name == "Reading")
                {
                    totalReadingTime += activity.TimeSpent;
                    totalReadingPages += activity.TimeSpent;
                    totalReadingActivities++;
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Reading Statistics\n");
            Console.ResetColor();
            Console.WriteLine($"Total time spent on reading: {totalReadingTime} seconds\n");
            Console.WriteLine($"Total number of reading activities: {totalReadingActivities}\n");
            Console.WriteLine($"Average reading time per activity: {(totalReadingActivities != 0 ? totalReadingTime / totalReadingActivities : 0)} pages\n");
        }

        private void GetExercisingStatistics()
        {
            int totalExercisingTime = 0;
            int totalExercisingActivities = 0;

            foreach (var activity in currentUser.Activities)
            {
                if (activity.Name == "Exercising")
                {
                    totalExercisingTime += activity.TimeSpent;
                    totalExercisingActivities++;
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Exercising Statistics\n");
            Console.ResetColor();
            Console.WriteLine($"Total time spent on exercising: {totalExercisingTime} seconds\n");
            Console.WriteLine($"Total number of exercising activities: {totalExercisingActivities}\n");
            Console.WriteLine($"Average exercising time per activity: {(totalExercisingActivities != 0 ? totalExercisingTime / totalExercisingActivities : 0)} seconds\n");
        }


        private void GetWorkingStatistics()
        {
            int totalWorkingTime = 0;
            int totalOfficeWorkingTime = 0;
            int totalHomeWorkingTime = 0;
            int totalWorkingActivities = 0;

            foreach (var activity in currentUser.Activities)
            {
                if (activity.Name == "Working")
                {
                    totalWorkingTime += activity.TimeSpent;
                    totalWorkingActivities++;

                    if (activity.ExtraInfo == "At the office")
                    {
                        totalOfficeWorkingTime += activity.TimeSpent;
                    }
                    else if (activity.ExtraInfo == "From home")
                    {
                        totalHomeWorkingTime += activity.TimeSpent;
                    }
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Working Statistics\n");
            Console.ResetColor();
            Console.WriteLine($"Total time spent on working: {totalWorkingTime} seconds\n");
            Console.WriteLine($"Total number of working activities: {totalWorkingActivities} \n");
            Console.WriteLine($"Average working time per activity: {(totalWorkingActivities != 0 ? totalWorkingTime / totalWorkingActivities : 0)} hours\n");
            Console.WriteLine($"Total time spent at the office: {totalOfficeWorkingTime} seconds\n");
            Console.WriteLine($"Total time spent working from home: {totalHomeWorkingTime} seconds\n");
        }

        private void GetOtherHobbiesStatistics()
        {
            int totalHobbiesTime = 0;
            int totalHobbiesActivities = 0;
            List<string> recordedHobbies = new List<string>();

            foreach (var activity in currentUser.Activities)
            {
                if (activity.Name == "Other Hobbies")
                {
                    totalHobbiesTime += activity.TimeSpent;
                    totalHobbiesActivities++;

                    if (!recordedHobbies.Contains(activity.ExtraInfo))
                    {
                        recordedHobbies.Add(activity.ExtraInfo);
                    }
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Other Hobbies Statistics\n");
            Console.ResetColor();
            Console.WriteLine($"Total time spent on other hobbies: {totalHobbiesTime} seconds\n");
            Console.WriteLine($"Total number of other hobbies activities: {totalHobbiesActivities} \n");
            Console.WriteLine($"Average time per other hobbies activity: {(totalHobbiesActivities != 0 ? totalHobbiesTime / totalHobbiesActivities : 0)} seconds\n");
            Console.WriteLine("Recorded hobbies:");

            foreach (var hobby in recordedHobbies)
            {
                Console.WriteLine($"{hobby}\n");
            }
        }

        private void GetGlobalStatistics()
        {
            int totalGlobalTime = 0;
            int totalActivities = 0;
            Dictionary<string, int> activityCounts = new Dictionary<string, int>();

            foreach (var activity in currentUser.Activities)
            {
                totalGlobalTime += activity.TimeSpent;
                totalActivities++;

                if (activityCounts.ContainsKey(activity.Name))
                {
                    activityCounts[activity.Name]++;
                }
                else
                {
                    activityCounts.Add(activity.Name, 1);
                }
            }
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Global Statistics\n");
            Console.ResetColor();
            Console.WriteLine($"Total time spent on all activities: {totalGlobalTime} seconds\n");
            Console.WriteLine($"Total number of activities: {totalActivities}  \n");
            Console.WriteLine("Activity counts:\n");

            foreach (var activityCount in activityCounts)
            {
                Console.WriteLine($"{activityCount.Key}: {activityCount.Value}\n");
            }
        }


        private void AccountManagement()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("===== Account Management =====\n");
            Console.ResetColor();
            Console.WriteLine("1) Change Password\n");
            Console.WriteLine("2) Change First Name\n");
            Console.WriteLine("3) Change Last Name\n");
            Console.WriteLine("4) Back to Main Menu\n");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    ChangePassword();
                    break;
                case "2":
                    ChangeFirstName();
                    break;
                case "3":
                    ChangeLastName();
                    break;
                case "4":
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again!");
                    break;
            }
        }

        private void ChangePassword()
        {
            Console.WriteLine();
            Console.Write("Enter your current password: ");
            string currentPassword = Console.ReadLine();
            Console.WriteLine();

            if (currentUser.Password != currentPassword)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect password.\n");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter a new password: ");
            string newPassword = Console.ReadLine();
            Console.WriteLine();

            if (newPassword.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Password should not be shorter than 6 characters!");
                Console.ResetColor();
                return;
            }
            currentUser.Password = newPassword;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Password changed successfully!");
            Console.ResetColor();

        }
        private void ChangeFirstName()
        {
            Console.WriteLine();
            Console.Write("Enter your new first name: ");
            string newFirstName = Console.ReadLine();
            Console.WriteLine();

            if (newFirstName.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("First Name should not be shorter than 2 characters!");
                Console.ResetColor();
                return;
            }
            currentUser.FirstName = newFirstName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("First Name changed successfully!");
            Console.ResetColor();

        }
        private void ChangeLastName()
        {
            Console.WriteLine();
            Console.Write("Enter your new last name: ");
            string newLastName = Console.ReadLine();
            Console.WriteLine();

            if (newLastName.Length < 2)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Last Name should not be shorter than 2 characters!");
                Console.ResetColor();
                return;
            }

            currentUser.LastName = newLastName;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Last Name changed successfully!");
            Console.ResetColor();

        }
    }
}

