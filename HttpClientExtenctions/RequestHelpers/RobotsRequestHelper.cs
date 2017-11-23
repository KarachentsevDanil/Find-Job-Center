using System;
using System.Collections.Generic;
using System.Linq;
using FJB.Domain.Entities.Robots;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class RobotsRequestHelper
    {
        private static string RobotsUrl = "/api/robot/";

        public static bool AddRobot(RobotViewModel robot)
        {
            try
            {
                HttpClientHelper.PostData(robot, string.Concat(RobotsUrl, "AddRobot"));
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
                HttpClientHelper.PostData(robotModel, string.Concat(RobotsUrl, "AddRobotModel"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static IEnumerable<RobotModel> GetRobotsModel()
        {
            try
            {
                var robots = HttpClientHelper.GetResult<List<RobotModel>>(string.Concat(RobotsUrl, "GetRobotModel"));
                return robots;
            }
            catch (Exception ex)
            {
                return Enumerable.Empty<RobotModel>();
            }
        }

        public static IEnumerable<Robot> GetRobotsOnSpecificDateRange(SearchRobotModel searchRobotModel)
        {
            try
            {
                var robots = HttpClientHelper.PostDataAndGetResult<SearchRobotModel, List<Robot>>(searchRobotModel, string.Concat(RobotsUrl, "GetRobotsOnSpecificDateRange"));
                return robots;
            }
            catch (Exception)
            {
                return Enumerable.Empty<Robot>();
            }
        }

        public static IEnumerable<RobotModel> GetRobotsBySpecialization(string name)
        {
            try
            {
                var robots = HttpClientHelper.GetResult<List<RobotModel>>(string.Concat(RobotsUrl, $"GetRobotsBySpecialization?name={name}"));
                return robots;
            }
            catch (Exception)
            {
                return Enumerable.Empty<RobotModel>();
            }
        }

        public static IEnumerable<RobotModel> GetRobotsByOfCompany(int companyId)
        {
            try
            {
                var robots = HttpClientHelper.GetResult<List<RobotModel>>(string.Concat(RobotsUrl, $"GetRobotsByOfCompany?companyId={companyId}"));
                return robots;
            }
            catch (Exception)
            {
                return Enumerable.Empty<RobotModel>();
            }
        }
    }
}
