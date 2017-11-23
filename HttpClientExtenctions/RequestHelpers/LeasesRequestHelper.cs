using System;
using System.Collections.Generic;
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

        public static Lease GetLeaseDetails(int leaseId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<Lease>(string.Concat(LeasesUrl, $"GetLeaseDetails?leaseId={leaseId}"));
                return lease;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public static List<Lease> GetLeaseOfClient(int clientId)
        {
            try
            {
                var lease = HttpClientHelper.GetResult<List<Lease>>(string.Concat(LeasesUrl, $"GetLeaseOfClient?clientId={clientId}"));
                return lease;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
