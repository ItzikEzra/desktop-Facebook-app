using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    //Facade
    public class FetcherFacade
    {
        public readonly FacebookManager m_FacebookManager = FacebookManager.Instance;

        public static readonly FetcherFacade sr_Fetcher = new FetcherFacade();

        public FetcherFacade()
        {

        }
        
        public List<string> FetchUserAlbumNames()
        {
            List<Album> albums = FetchUserAlbums();
            List<string> albusmName = new List<string>();

            foreach (Album album in albums)
            {
                albusmName.Add(album.Name);
            }
            
            return albusmName;
        }

        public List<Album> FetchUserAlbums()
        {
            List<Album> albums = new List<Album>();

            foreach (Album album in m_FacebookManager.m_LoggedInUser.Albums)
            {
                albums.Add(album);
            }
            
            return albums;
        }
        
        public List<string> FetchUserCheckin()
        {
            List<string> checkIns = new List<string>();

            foreach (Checkin check in m_FacebookManager.m_LoggedInUser.Checkins)
            {
                checkIns.Add(check.Name);
            }

            return checkIns;
        }

        public List<User> FetchUserFriend()
        {
            List<User> friendsList = new List<User>();
           
            foreach (User friend in m_FacebookManager.m_LoggedInUser.Friends)
            {
                friendsList.Add(friend);
            }

            return friendsList;
        }

        public string FetchUserProfileImage()
        {
            return m_FacebookManager.m_LoggedInUser.PictureNormalURL;
        }

        public List<Post> FetchPosts()
        {
            List<Post> postList = new List<Post>();

            foreach (Post post in m_FacebookManager.m_LoggedInUser.Posts)
            {
                postList.Add(post);
            }

            return postList;
        }

        public string FetchUserName()
        {
            return m_FacebookManager.m_LoggedInUser.Name.ToString();

        }

        public string FetchUserBirthday()
        {
            return m_FacebookManager.m_LoggedInUser.Birthday.ToString();
        }

        public string FetchUseGender()
        {
            return m_FacebookManager.m_LoggedInUser.Gender.ToString();
        }
    }
}
