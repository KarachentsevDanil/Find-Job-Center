using System;
using System.Configuration;
using System.Linq;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;
using RJF.IoT.Service;

namespace RJF.IoT
{
    class Program
    {
        static void Main(string[] args)
        {
            var user = new CurrentUserViewModel
            {
                Name = ConfigurationManager.AppSettings["CompanyName"],
                Password = ConfigurationManager.AppSettings["Password"]
            };

            HttpClientHelper.User = user;

            while (true)
            {
                try
                {
                    var robots = RobotService.GetRobots();
                    var currentDate = DateTime.Now;
                    var isWorkHour = currentDate.Hour > 8 && currentDate.Hour < 22;

                    foreach (var robot in robots)
                    {
                        var isOnWork = isWorkHour && robot.RobotLeases.Any(x =>
                                           x.Lease.StartDate <= currentDate && x.Lease.EndDate >= currentDate);

                        var message = isOnWork ? "now is on work" : "now haven't work";

                        robot.IsOnWork = isOnWork;

                        Console.WriteLine($" #{robot.RobotId} - {robot.RobotModel.Name} of company {robot.Company.Name} - {message}");
                    }

                    RobotService.UpdateRobots(robots);
                }
                catch (Exception exp)
                {
                    Console.WriteLine($"Error occure: {exp.Message}");
                }
            }
        }
    }
}
