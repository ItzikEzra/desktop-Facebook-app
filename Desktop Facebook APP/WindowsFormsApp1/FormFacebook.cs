using FacebookWrapper.ObjectModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;

namespace Desktop_Facebook
{
    public partial class FormFacebook : Form
    {
        private MatchFinderFeature MatchFinder;
        private readonly FacebookManager m_FacebookManager = FacebookManager.Instance;
        private List<string> m_CheckInsList = null;
        private List<Post> m_PostsList = null;
        private List<User> m_InactiveFriends, m_FriendsList = null;
        private static int  s_InactivePicIndex = 0;

        public FormFacebook()
        {
            InitializeComponent();
        }

        private void disconnect()
        {
            m_FacebookManager.Logout();
            cleanUI();
        }
        
        private void fillInfo()
        {
        
            try
            {
                AlbumBindingSource();
               
                foreach (string checkIn in m_CheckInsList)
                {
                    checkInsListBox.Invoke(new Action(() => checkInsListBox.Items.Add(checkIn)));
                }
                foreach (User friend in m_FriendsList)
                {
                    friendsListBox.Invoke(new Action(() => friendsListBox.Items.Add(friend.Name)));
                }
                foreach (Post post in m_PostsList)
                {
                    postsListsBox.Invoke(new Action(() => postsListsBox.Items.Add(post.Description)));
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cleanUI()
        {
            profileLoginPictureBox.Image = null;
            bestTimePictureBox.Image = null;
            inactivePictureBox.Image = null;
            m_LoginLogoutBtn.Text = "Login";
            labelProfileName.Text = "ProfileName";
            labelBirthday.Text = "Birthday";
            labelGender.Text = "Gender";
            albumsListBox.Items.Clear();
            checkInsListBox.Items.Clear();
            friendsListBox.Items.Clear();
            postsListsBox.Items.Clear();
            inactiveListBox.Items.Clear();
            mostCommentPost.Text = String.Empty;

        }

        private void AlbumBindingSource()
        {
            List <Album> albums = FetcherFacade.sr_Fetcher.FetchUserAlbums();

            if (!albumsListBox.InvokeRequired)
            {
                albumBindingSource.DataSource = albums;
            }
            else
            {
                albumsListBox.Invoke(new Action(() => albumBindingSource.DataSource = albums));
            }
        }
    
        private void loginStarter()
        {
            new Thread(fillPerofileInfo).Start();
            m_CheckInsList = FetcherFacade.sr_Fetcher.FetchUserCheckin();
            m_FriendsList = FetcherFacade.sr_Fetcher.FetchUserFriend();
            m_PostsList = FetcherFacade.sr_Fetcher.FetchPosts();
            new Thread(fillInfo).Start();
        }

        private void bestTimePostHandel()
        {
            List<string> posts = new List<string>();
            BestTimeToUploadPost bestTimeToUploadPost = new BestTimeToUploadPost();
            int timeForPosts = bestTimeToUploadPost.FindBestTimeToUploadAPost(posts);

            bestTimePostLabel.Invoke(new Action(()=> bestTimePostLabel.Text += timeForPosts.ToString()));
            mostCommentPost.Invoke(new Action(() =>
            {
                if (posts.Count > 0)
                {
                    mostCommentPost.Text = posts[0];
                }
                else
                {
                    mostCommentPost.Text = @"We were unable to obtain information due to one of the reasons:
                1) You have never published a post.
                2) We did not accept approaches.
                either way,
                Have a good day,
                  You should not live by the reaction of people(:";
                }
            }
            ));

        }

        private void bestTimePhotoHandel()
        {
            List<string> pictures = new List<string>();
            BestTimeToUploadPhoto bestTimeToUploadPhoto = new BestTimeToUploadPhoto();
            int timeForPhotos = bestTimeToUploadPhoto.FindBestTimeToUploadAPicture(pictures);
            bestTimePicLabel.Invoke(new Action(() => bestTimePicLabel.Text += timeForPhotos.ToString()));
            
            if (pictures.Count > 0)
            {
                bestTimePictureBox.LoadAsync(pictures[0]);
            }
            else
            {
                bestTimePicLabel.Invoke(new Action(() => bestTimePicLabel.Text = "No photos, so see your profile picture"));
               
                bestTimePictureBox.LoadAsync(FetcherFacade.sr_Fetcher.FetchUserProfileImage());
            }
        }

        private void fillPerofileInfo()
        {
            try
            {
                profileLoginPictureBox.LoadAsync(FetcherFacade.sr_Fetcher.FetchUserProfileImage());
                labelProfileName.Invoke(new Action(() => labelProfileName.Text = FetcherFacade.sr_Fetcher.FetchUserName()));
                labelBirthday.Invoke(new Action(()=> labelBirthday.Text = FetcherFacade.sr_Fetcher.FetchUserBirthday()));
                labelGender.Invoke(new Action(()=> labelGender.Text = FetcherFacade .sr_Fetcher.FetchUseGender()));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nextInactivePic_Click(object sender, EventArgs e)
        {
            if(s_InactivePicIndex < m_InactiveFriends.Count)
            {
                inactivePictureBox.LoadAsync(m_InactiveFriends[s_InactivePicIndex++].PictureNormalURL);

            }
        }

        private void prevInactivePic_Click(object sender, EventArgs e)
        {
            if (s_InactivePicIndex > 0)
            {
                inactivePictureBox.LoadAsync(m_InactiveFriends[--s_InactivePicIndex].PictureNormalURL);

            }
        }

        private void inactiveBtn_Click(object sender, EventArgs e)
        {
            new Thread(inactiveFriendsStart).Start();
        }

        private void inactiveFriendsStart()
        {
            try
            {
                ListSorter friendListSorter = ListSorter.CreateSorter(eSortType.SortByFirstName);

                m_InactiveFriends = InactiveFriends.sr_InactiveFriends.FindInactiveFriendsFeature();
                friendListSorter.Sort(ref m_InactiveFriends);

                foreach (User friend in m_InactiveFriends)
                {
                    inactiveListBox.Invoke(new Action(() => inactiveListBox.Items.Add(friend.Name)));
                }
                inactivePictureBox.LoadAsync(m_InactiveFriends[s_InactivePicIndex].PictureNormalURL);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bestPublishBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_FacebookManager.m_LoggedInUser != null)
                {
                    new Thread(bestTimePostHandel).Start();

                    new Thread(bestTimePhotoHandel).Start();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void MatchByFriendsBtn_Click(object sender, EventArgs e)
        {
            new Thread(this.MatchByFriends).Start();
        }

        private void MatchByPhotosBtn_Click(object sender, EventArgs e)
        {
            new Thread(this.MatchByPhotos).Start();
        }

        private void MatchByGroupsBtn_Click(object sender, EventArgs e)
        {
            new Thread(this.MatchByGroups).Start();
        }

        private void MatchByFriends()
        {
            this.MatchFinder = new MatchFinderFeature(new MatcherByFriends());
            this.MatchFinder.FindMatch(this.m_FacebookManager.m_LoggedInUser);
            this.setUI();
        }

        private void MatchByGroups()
        {
            this.MatchFinder = new MatchFinderFeature(new MatcherByGroups());
            this.MatchFinder.FindMatch(this.m_FacebookManager.m_LoggedInUser);
            this.setUI();
        }

        private void MatchByPhotos()
        {
            this.MatchFinder = new MatchFinderFeature(new MatcherByPhotos());
            this.MatchFinder.FindMatch(this.m_FacebookManager.m_LoggedInUser);
            this.setUI();
        }

        private void setUI()
        {
            try
            {
                this.m_PictureProfileMatch.LoadAsync(MatchFinder.IStrategyMatcher.m_BestMatch.PictureLargeURL);
                this.m_PictureProfileFeature.LoadAsync(this.m_FacebookManager.m_LoggedInUser.PictureNormalURL);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
      
        private void loginLogoutBtn_Click(object sender, EventArgs e)
        {

            if (m_LoginLogoutBtn.Text == "Login")
            {
                m_FacebookManager.Login();
                m_LoginLogoutBtn.Text = "Logout";
                new Thread(loginStarter).Start();

            }
            else
            {
                disconnect();
            }
        }
    }
}