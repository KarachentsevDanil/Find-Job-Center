using System;
using System.Collections.Generic;
using FJB.Domain.Entities.Leases;
using HttpClientExtenctions.Helpers;
using RJB.BLL.Models;

namespace HttpClientExtenctions.RequestHelpers
{
    public static class HttpLeaseService
    {
        public static bool CreateLease(Lease lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(Constants.LeasesUrl, "CreateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static bool CompleateLease(Lease lease)
        {
            try
            {
                HttpClientHelper.PostData(lease, string.Concat(Constants.LeasesUrl, "CompleateLease"));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public static LeaseModel GetLeaseDetails(int leaseId)
        {
            var lease = HttpClientHelper.GetResult<LeaseModel>(string.Concat(Constants.LeasesUrl, $"GetLeaseDetails?leaseId={leaseId}"));
            return lease;
        }

        public static List<Lease> GetLeaseOfClient(int clientId)
        {
            var lease = HttpClientHelper.GetResult<List<Lease>>(string.Concat(Constants.LeasesUrl, $"GetLeaseOfClient?clientId={clientId}"));
            return lease;
        }
    }
}
