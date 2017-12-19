using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;
using HttpClientExtenctions.Helpers;

namespace RJF.IoT.Service
{
    public class RobotService
    {
        private static string RobotsUrl = "/api/robot/";

        public static List<Robot> GetRobots()
        {
            var robots = HttpClientHelper.GetResult<List<Robot>>(string.Concat(RobotsUrl, "GetRobots"));
            return robots;
        }

        public static bool UpdateRobots(List<Robot> robots)
        {
            try
            {
                HttpClientHelper.PostData(robots, string.Concat(RobotsUrl, "UpdateRobotsStatus"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
