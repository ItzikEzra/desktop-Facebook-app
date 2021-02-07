using System;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook

{
    public class MatcherByGroups : IStrategyMatcher
    {
        public User m_BestMatch { get; set; }

        public void FindMatch(User i_LoggedInUser)
        {
            int MutualGroups, maxMutualGroups = 0;

            foreach (User friend in i_LoggedInUser.Friends)
            {
                MutualGroups = 0;
                foreach (Group group in i_LoggedInUser.Groups)
                {
                    foreach (Group friendgroup in friend.Groups)
                    {
                        if (friendgroup.Id == group.Id)
                        {
                            MutualGroups++;
                        }
                    }
                }

                if (MutualGroups >= maxMutualGroups)
                {
                    maxMutualGroups = MutualGroups;
                    this.m_BestMatch = friend;
                }
            }
        }
    }
}
