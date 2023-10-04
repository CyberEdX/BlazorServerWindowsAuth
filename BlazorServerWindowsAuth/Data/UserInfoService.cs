using System.DirectoryServices;
using System.Runtime.Versioning;

namespace BlazorServerWindowsAuth.Data
{
    public class UserInfoService
    {
        private readonly string _ADpath = "LDAP://ad.companyid";

        [SupportedOSPlatform("windows")]
        public Task<UserInfoAD> GetUserInfoAsync(string userName)
        {
            UserInfoAD tmpUserInfo = new() { 
                UserName = userName[(userName.IndexOf("\\") + 1)..],
                FirstName = "",
                LastName = "",
                DisplayName = "",
                EmailAddress = ""
            };

            try
            {
                DirectoryEntry Entry = new(_ADpath);
                DirectorySearcher mySearcher = new()
                {
                    SearchRoot = Entry,
                    Filter = "sAMAccountName=" + tmpUserInfo.UserName
                };
                mySearcher.PropertiesToLoad.Add("givenName");
                mySearcher.PropertiesToLoad.Add("sn");
                mySearcher.PropertiesToLoad.Add("displayName");
                mySearcher.PropertiesToLoad.Add("mail");
                var tmpEntry = mySearcher.FindOne();
                if (tmpEntry != null)
                {
                    tmpUserInfo.FirstName = tmpEntry.Properties["givenName"][0].ToString();
                    tmpUserInfo.LastName = tmpEntry.Properties["sn"][0].ToString();
                    tmpUserInfo.DisplayName = tmpEntry.Properties["displayName"][0].ToString();
                    tmpUserInfo.EmailAddress = tmpEntry.Properties["mail"][0].ToString();
                }
            }
            catch (Exception ex)
            {
                tmpUserInfo.DisplayName = ex.Message;
            }
            return Task.FromResult(tmpUserInfo);
        }
    }
}
