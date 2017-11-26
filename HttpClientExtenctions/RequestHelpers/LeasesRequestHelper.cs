using System;
using FJB.Domain.Entities.Leases;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class LeasesRequestHelper
    {
        private static string LeasesUrl = "/api/lease/";

        public static bool CreateLease(Lease lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(LeasesUrl, "CreateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CompleateLease(LeaseViewModel lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(LeasesUrl, "CompleateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static LeaseModel GetLeaseDetails(int leaseId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<LeaseModel>(string.Concat(LeasesUrl, $"GetLeaseDetails?leaseId={leaseId}"));
                return lease;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static CollectionResult<LeaseModel> GetLeaseOfClient(int clientId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<CollectionResult<LeaseModel>>(string.Concat(LeasesUrl, $"GetLeaseOfClient?clientId={clientId}"));
                return lease;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
