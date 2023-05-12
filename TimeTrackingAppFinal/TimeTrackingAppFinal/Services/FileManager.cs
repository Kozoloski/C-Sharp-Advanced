using Domain.Models;
using Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FileManager : IFileManager
    {
        private readonly string folderPath = @"..\..\..\DataBase";
        private readonly string filePath = @"..\..\..\DataBase\jsonFile.json";

        public List<User> ReadFromFile()
        {
            if (!File.Exists(filePath))
            {
                return new List<User>();
            }

            try
            {
                string fileText = File.ReadAllText(filePath);

                if (string.IsNullOrWhiteSpace(fileText))
                {
                    return new List<User>();
                }

                var allUsers = JsonConvert.DeserializeObject<List<User>>(fileText);
                return allUsers ?? new List<User>();
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error deserializing JSON: {ex.Message}");
                return new List<User>();
            }
        }

        public void WriteToFile(List<User> users)
        {
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            try
            {
                string jsonString = JsonConvert.SerializeObject(users);
                File.WriteAllText(filePath, jsonString);
            }
            catch (JsonException ex)
            {
                Console.WriteLine($"Error serializing JSON: {ex.Message}");
            }
        }
    }
}
