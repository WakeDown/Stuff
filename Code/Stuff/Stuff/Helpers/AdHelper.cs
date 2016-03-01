using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using Stuff.Models;
using Stuff.Objects;

namespace Stuff.Helpers
{
    public class AdHelper
    {
        public static NetworkCredential GetAdUserCredentials()
        {
            //string accUserName = @"UN1T\adUnit_prog";
            string accUserPass = "1qazXSW@";

            string domain = "UN1T";//accUserName.Substring(0, accUserName.IndexOf("\\"));
            string name = "adUnit_prog";//accUserName.Substring(accUserName.IndexOf("\\") + 1);

            NetworkCredential nc = new NetworkCredential(name, accUserPass, domain);

            return nc;
        }

        private static NetworkCredential nc = GetAdUserCredentials();

        public static IEnumerable<KeyValuePair<string, string>> GetSpecialistList(AdGroup grp)
        {
            var list = new Dictionary<string, string>();

            using (WindowsImpersonationContextFacade impersonationContext
                = new WindowsImpersonationContextFacade(
                    nc))
            {
                var domain = new PrincipalContext(ContextType.Domain);
                var group = GroupPrincipal.FindByIdentity(domain, IdentityType.Sid, AdUserGroup.GetSidByAdGroup(grp));
                if (group != null)
                {
                    var members = group.GetMembers(true);
                    foreach (var principal in members)
                    {
                        var userPrincipal = UserPrincipal.FindByIdentity(domain, principal.SamAccountName);
                        if (userPrincipal != null)
                        {
                            var name = MainHelper.ShortName(userPrincipal.DisplayName);
                            var sid = userPrincipal.Sid.Value;
                            list.Add(sid, name);
                        }
                    }
                }

                return list.OrderBy(x => x.Value);
            }
        }

        public static void SetUserAdGroups(IIdentity identity, ref AdUser user)
        {


            //using (WindowsImpersonationContextFacade impersonationContext
            //    = new WindowsImpersonationContextFacade(
            //        nc))
            //{
            var wi = (WindowsIdentity)identity;
            var context = new PrincipalContext(ContextType.Domain);


            if (identity != null && wi.User != null && user != null)
            {

                user.AdGroups = new List<AdGroup>();

                var wp = new WindowsPrincipal(wi);
                var gr = wi.Groups;

                foreach (AdUserGroup grp in AdUserGroup.GetList())
                {
                    var grpSid = new SecurityIdentifier(grp.Sid);
                    if (wp.IsInRole(grpSid))
                    {
                        user.AdGroups.Add(grp.Group);
                    }
                }
            }
            //}

        }

        public static AdUser GetUserBySid(string sid)
        {
            var result = new AdUser();

            using (WindowsImpersonationContextFacade impersonationContext
                = new WindowsImpersonationContextFacade(
                    nc))
            {
                var context = new PrincipalContext(ContextType.Domain);
                var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.Sid, sid);

                if (userPrincipal != null)
                {
                    result.Sid = sid;
                    result.FullName = userPrincipal.DisplayName;
                    result.Email = userPrincipal.EmailAddress;
                }
            }

            return result;
        }

        public static bool UserInGroup(string sid, params AdGroup[] groups)
        {
            using (WindowsImpersonationContextFacade impersonationContext
                = new WindowsImpersonationContextFacade(
                    nc))
            {
                var context = new PrincipalContext(ContextType.Domain);
                var userPrincipal = UserPrincipal.FindByIdentity(context, IdentityType.Sid, sid);

                if (userPrincipal == null) return false;
                ////if (userPrincipal.IsMemberOf(context, IdentityType.Sid, AdUserGroup.GetSidByAdGroup(AdGroup.SuperAdmin))) { return true; }//Если юзер Суперадмин

                foreach (var grp in groups)
                {
                    if (userPrincipal.IsMemberOf(context, IdentityType.Sid, AdUserGroup.GetSidByAdGroup(grp)))
                    {
                        return true;
                    }
                }


                return false;
            }
        }

        public static IEnumerable<KeyValuePair<string, string>> GetUserListByAdGroup(params AdGroup[] grps)
        {
            var list = new Dictionary<string, string>();

            using (WindowsImpersonationContextFacade impersonationContext
                = new WindowsImpersonationContextFacade(
                    nc))
            {
                var domain = new PrincipalContext(ContextType.Domain);
                foreach (AdGroup grp in grps)
                {
                var group = GroupPrincipal.FindByIdentity(domain, IdentityType.Sid, AdUserGroup.GetSidByAdGroup(grp));
                if (group != null)
                {
                    var members = group.GetMembers(true);
                    foreach (var principal in members)
                    {
                        var userPrincipal = UserPrincipal.FindByIdentity(domain, principal.SamAccountName);
                        if (userPrincipal != null)
                        {
                            var name = Employee.ShortName(userPrincipal.DisplayName);
                            var sid = userPrincipal.Sid.Value;
                                if (!list.ContainsKey(sid))list.Add(sid, name);
                        }
                    }
                }
                }
            }

            return list.OrderBy(x => x.Value);
        }
    }
}