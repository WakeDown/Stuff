﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Stuff.Objects
{
    public class AdUserGroup
    {
        public AdGroup Group { get; set; }
        public string Sid { get; set; }
        public string Name { get; set; }

        public AdUserGroup(AdGroup grp, string sid)
        {
            Group = grp;
            Sid = sid;
        }

        public static IEnumerable<AdUserGroup> GetList()
        {
            var list = new List<AdUserGroup>();
            list.Add(new AdUserGroup(AdGroup.SuperAdmin, "S-1-5-21-1970802976-3466419101-4042325969-4031"));//Суперадмин
            list.Add(new AdUserGroup(AdGroup.SuperAdmin, "S-1-5-21-1970802976-3466419101-4042325969-6761"));//Суперадмин m.verhoturcev@unitgroup.ru
            list.Add(new AdUserGroup(AdGroup.PersonalManager, "S-1-5-21-1970802976-3466419101-4042325969-4030"));//Менеджер по персоналу
            list.Add(new AdUserGroup(AdGroup.SystemUser, "S-1-5-21-1970802976-3466419101-4042325969-4033"));//Системный
            list.Add(new AdUserGroup(AdGroup.VendorStateDelivery, "S-1-5-21-1970802976-3466419101-4042325969-4555"));
            list.Add(new AdUserGroup(AdGroup.VendorStateEditor, "S-1-5-21-1970802976-3466419101-4042325969-4556"));
            list.Add(new AdUserGroup(AdGroup.EngeneerStateView, "S-1-5-21-1970802976-3466419101-4042325969-7672"));
            list.Add(new AdUserGroup(AdGroup.EngeneerStateEdit, "S-1-5-21-1970802976-3466419101-4042325969-7673"));
            list.Add(new AdUserGroup(AdGroup.EngeneerStateExpiresDelivery, "S-1-5-21-1970802976-3466419101-4042325969-7674"));
            list.Add(new AdUserGroup(AdGroup.ServiceEngeneer, "S-1-5-21-1970802976-3466419101-4042325969-2558"));
            list.Add(new AdUserGroup(AdGroup.RecruitManager, "S-1-5-21-1970802976-3466419101-4042325969-7676"));
            list.Add(new AdUserGroup(AdGroup.RecruitControler, "S-1-5-21-1970802976-3466419101-4042325969-7677"));
            return list;//Вендоры
        }

        public static string GetSidByAdGroup(AdGroup grp)
        {
            return GetList().Single(g => g.Group == grp).Sid;
        }

        public static AdGroup GetAdGroupBySid(string sid)
        {
            if (string.IsNullOrEmpty(sid)) return AdGroup.None;
            var grp = GetList().Single(g => g.Sid == sid).Group;
            return grp;
        }
    }
}