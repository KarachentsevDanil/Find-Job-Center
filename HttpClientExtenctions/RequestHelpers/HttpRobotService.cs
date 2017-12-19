using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Robots;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class HttpRobotService
    {
        public static bool AddRobot(RobotViewModel robot)
        {
            try
            {
                HttpClientHelper.PostData(robot, string.Concat(Constants.RobotsUrl, "AddRobot"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool AddRobotModel(RobotModel robotModel)
        {
            try
            {
                HttpClientHelper.PostData(robotModel, string.Concat(Constants.RobotsUrl, "AddRobotModel"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static List<RobotModel> GetRobotsModel()
        {
            var robots = HttpClientHelper.GetResult<List<RobotModel>>(string.Concat(Constants.RobotsUrl, "GetRobotsModel"));
            return robots;
        }

        public static List<Robot> GetRobotsOnSpecificDateRange(SearchRobotModel searchRobotModel)
        {
            var robots = HttpClientHelper.PostDataAndGetResult<SearchRobotModel, List<Robot>>(searchRobotModel, string.Concat(Constants.LeasesUrl, "GetRobotsOnSpecificDateRange"));
            return robots;

        }

        public static RobotViewModel GetRobotById(int robotId)
        {
            var robot = HttpClientHelper.GetResult<RobotViewModel>(string.Concat(Constants.RobotsUrl, $"GetRobotById?robotId={robotId}"));
            return robot;
        }

        public static List<Robot> GetRobotsByOfCompany(int companyId)
        {
            var robots = HttpClientHelper.GetResult<List<Robot>>(string.Concat(Constants.RobotsUrl, $"GetRobotsByOfCompany?companyId={companyId}"));
            return robots;
        }
    }
}
