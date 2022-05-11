using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleEF
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] commands = { "Show devices", "Create a device" };

            Console.WriteLine("Valid Commands");

            for(int i = 0; i < commands.Length; i++)
            {
                Console.WriteLine($" {i+1}.{commands[i]}");
            }

            Console.WriteLine("Please enter a command number");
            string commandNum = Console.ReadLine();

            switch (commandNum)
            {
                case "1":
                    using (var salesDb = new SalesDBContext())
                    {
                        var devices = salesDb.Devices.SqlQuery("SELECT * FROM Devices").ToList();
                        foreach (var device in devices)
                        {
                            Console.WriteLine(device.DeviceName);
                        }
                    }
                    break;
                case "2":
                    using(var salesDb = new SalesDBContext())
                    {
                        Console.Write("Device Name: ");
                        string deviceName = Console.ReadLine();
                        string insertDevice = $"INSERT INTO dbo.Devices VALUES ('{deviceName}');";

                        salesDb.Database.ExecuteSqlCommand(insertDevice);
                    }
                    break;
            }

            Console.ReadKey();
        }
    }
}
