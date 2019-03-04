using System;
using System.DirectoryServices;
using System.DirectoryServices.AccountManagement;
using System.Collections.Generic;

namespace ModuleNetwork1
{
    class LdapHelper
    {
        const string pathNameDomain = "LDAP://MiljoeMaerkningDanmark.dk";

        /// <summary>
        /// Function to remote connection with user
        /// </summary>
        /// <returns></returns>
        public DirectoryEntry remoteConnection()
        {
            DirectoryEntry ldapCon = new DirectoryEntry("LDAP://192.168.1.3", "MA01", "!Admin123", AuthenticationTypes.Secure);

            return ldapCon;
        }

        /// <summary>
        /// Get User information
        /// </summary>
        /// <param name="userInformation"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool GetUserInfo(out List<string> userInformation, string username)
        {
            userInformation = new List<string>();
            bool valueReturn = false;

            try
            {
                DirectoryEntry dirEntry = remoteConnection();

                DirectorySearcher dSearch = new DirectorySearcher(dirEntry)
                {
                    Filter = "(&(objectclass=user)(sAMAccountName=" + username + "))"
                };

                SearchResultCollection res = dSearch.FindAll();

                valueReturn = (res.Count > 0) ? true : false;

                foreach (SearchResult s in res)
                {
                    foreach (var valueCollection in s.Properties.PropertyNames)
                    {
                        userInformation.Add(valueCollection.ToString() + " = " + s.Properties[valueCollection.ToString()][0].ToString());
                    }
                }

                dirEntry.Dispose();
                dSearch.Dispose();
                res.Dispose();
            }
            catch (InvalidOperationException iOe)
            {
            }
            catch (NotSupportedException nSe)
            {
            }
            finally
            {
            }

            return valueReturn;
        }

        /// <summary>
        /// Get all the groups in the ad ds
        /// </summary>
        /// <param name="lGroups"></param>
        /// <returns></returns>
        public bool GetGroups(out List<string> lGroups)
        {
            lGroups = new List<string>();
            bool returnVal = false;

            try
            {
                DirectoryEntry _de = remoteConnection();

                DirectorySearcher dSearch = new DirectorySearcher(_de)
                {
                    Filter = "(&(objectCategory=group))",
                    SearchScope = SearchScope.Subtree,
                    PageSize = 1000
                };

                SearchResultCollection res = dSearch.FindAll();

                returnVal = (res.Count > 0) ? true : false;

                foreach (SearchResult s in res)
                {
                    lGroups.Add(s.Properties["cn"][0].ToString());
                }

                _de.Dispose();
                dSearch.Dispose();
                res.Dispose();

            }
            catch (InvalidOperationException iOe)
            {
            }
            catch (NotSupportedException nSe)
            {
            }
            finally
            {

            }

            return returnVal;
        }

        /// <summary>
        /// Get all the users
        /// </summary>
        /// <param name="lUsers"></param>
        /// <returns></returns>
        public bool GetUsers(out List<string> lUsers)
        {
            lUsers = new List<string>();
            bool returnVal = false;

            try
            {
                DirectoryEntry _de = remoteConnection();

                DirectorySearcher dSearch = new DirectorySearcher(_de)
                {
                    Filter = "(&(objectclass=user))"
                };

                SearchResultCollection res = dSearch.FindAll();

                returnVal = (res.Count > 0) ? true : false;

                foreach (SearchResult s in res)
                {
                    lUsers.Add(s.Properties["name"][0].ToString());
                }

                _de.Dispose();
                dSearch.Dispose();

            }
            catch (InvalidOperationException iOe)
            {
            }
            catch (NotSupportedException nSe)
            {
            }
            finally
            {

            }

            return returnVal;
        }

        /// <summary>
        /// Create user
        /// </summary>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool CreateUser(string fName, string lName, string username, string password)
        {
            using (var pc = new PrincipalContext(ContextType.Domain, "MiljoeMaerkningDanmark", "", "MA01", "!Admin123"))
            {
                using (var up = new UserPrincipal(pc))
                {
                    up.Name = fName;
                    up.Surname = lName;
                    up.SamAccountName = username;
                    up.SetPassword(password);
                    up.Enabled = true;
                    up.Save();
                }
            }

            return true;
        }
    }
}
