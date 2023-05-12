using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    public interface IFileManager
    {
        public void WriteToFile(List<User> users);
        public List<User> ReadFromFile();
    }
}
