using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    public class MatcherByPhotos : IStrategyMatcher
    {
        public User m_BestMatch { get; set; }

        public void FindMatch(User i_LoggedInUser)
        {
            FacebookObjectCollection<User> friendsOfUser = i_LoggedInUser.Friends;
            Dictionary<User, int> likesOfFriendsList = new Dictionary<User, int>();
            foreach (Album album in i_LoggedInUser.Albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    foreach (User user in photo.LikedBy)
                    {
                        if (likesOfFriendsList.ContainsKey(user))
                        {
                            likesOfFriendsList[user]++;
                        }
                        else
                        {
                            likesOfFriendsList.Add(user, 1);
                        }
                    }
                }
            }

            KeyValuePair<User, int> theMostLikerFriend = new KeyValuePair<User, int>(null, 0);
            foreach (KeyValuePair<User, int> likesOfFriend in likesOfFriendsList)
            {
                if (likesOfFriend.Value >= theMostLikerFriend.Value)
                {
                    theMostLikerFriend = likesOfFriend;
                }
            }

            this.m_BestMatch = theMostLikerFriend.Key;
        }
    }
}
