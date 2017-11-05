 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HarborMasterFromEmployeeMgmtCA.Models
{
    public class MembershipRepo
    {
        private static List<Membership> _memberships;

        static MembershipRepo()
        {
            _memberships = new List<Membership>()
            {
                new Membership {MembershipType="Premium Club Member", MembershipID=1},
                new Membership {MembershipType="Club Member", MembershipID=2 },
                new Membership {MembershipType="Transient", MembershipID=3 },

            };
        }

        public static List<Membership> GetAll()
        {
            return _memberships;
        }

    }
}