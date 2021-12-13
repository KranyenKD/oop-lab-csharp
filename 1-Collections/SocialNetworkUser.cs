using System;
using System.Collections.Generic;

namespace Collections
{
    public class SocialNetworkUser<TUser> : User, ISocialNetworkUser<TUser>
        where TUser : IUser
    {
        private Dictionary<string, HashSet<TUser>> socialnet = new Dictionary<string, HashSet<TUser>>();
        public SocialNetworkUser(string fullName, string username, uint? age) : base(fullName, username, age)
        {
            User user = new User(fullName, username, age);

        }

        public bool AddFollowedUser(string group, TUser user)
        {
            if (socialnet.ContainsKey(group))
            {
                return socialnet[group].Add(user);
            }

            var newSet = new HashSet<TUser>();
            newSet.Add(user);
            socialnet.Add(group,newSet);
            return true;
        }

        public IList<TUser> FollowedUsers
        {
            get
            {
                var newList = new List<TUser>();
                foreach (var user in this.socialnet)
                {
                    foreach (var e in user.Value)
                    {
                        newList.Add(e);
                    }
                }

                return newList;
            }
        }

        public ICollection<TUser> GetFollowedUsersInGroup(string group)
        {
            if (this.socialnet.ContainsKey(group))
            {
                return this.socialnet[group];
            }

            return new HashSet<TUser>();

        }
    }
}
