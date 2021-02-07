using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
   public  class InactiveFriends
    {
        public static readonly InactiveFriends sr_InactiveFriends = new InactiveFriends();

        public InactiveFriends()
        {
                
        }

        public List<User> FindInactiveFriendsFeature()
        {
            List<User> friendsOfUser = FetcherFacade.sr_Fetcher.FetchUserFriend();
            List<User> activeFriends = new List<User>();
            List<User> inactiveFriends = new List<User>();

            this.activeFriends(ref activeFriends);
            InactiveFriends.inactiveFriends(ref friendsOfUser, ref activeFriends, ref inactiveFriends);

            return inactiveFriends;
        }

        private static void inactiveFriends(ref List<User> friendsOfUser,ref  List<User> activeFriends, ref List<User> inactiveFriends)
        {
            foreach (User friend in friendsOfUser)
            {
                if (!activeFriends.Contains(friend))
                {
                    inactiveFriends.Add(friend);
                }
            }
        }

        private void activeFriends(ref List<User> activeFriends)
        {
            List<Album> albums = FetcherFacade.sr_Fetcher.FetchUserAlbums();
            foreach (Album album in albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    foreach (User user in photo.LikedBy)
                    {
                        if (!activeFriends.Contains(user))
                        {
                            activeFriends.Add(user);
                        }
                    }
                }
            }
        }
    
    }
}
