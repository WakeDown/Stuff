using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StuffDelivery.Objects
{
    public enum AdGroup
    {
        None,
        SuperAdmin,
        PersonalManager,
        SystemUser,
        VendorStateDelivery,
        VendorStateEditor,
        EngeneerStateView,
        EngeneerStateEdit,
        EngeneerStateExpiresDelivery,
        ServiceEngeneer
    }
}