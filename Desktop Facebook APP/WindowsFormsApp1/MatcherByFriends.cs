using System;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    public class MatcherByFriends : IStrategyMatcher
    {
        public User m_BestMatch { get; set; }

        public void FindMatch(User i_LoggedInUser)
        {
            int mutualFriends, maxMutualFriends = 0;

            foreach (User friend in i_LoggedInUser.Friends)
            {
                mutualFriends = 0;
                foreach (User hisFriend in friend.Friends)
                {
                    foreach (User myFriend in i_LoggedInUser.Friends)
                    {
                        if (hisFriend == myFriend)
                        {
                            mutualFriends++;
                        }
                    }
                }

                if (mutualFriends >= maxMutualFriends)
                {
                    maxMutualFriends = mutualFriends;
                    this.m_BestMatch = friend;
                }
            }
        }
    }
}