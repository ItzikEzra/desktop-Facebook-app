using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    public class BestTimeToUploadPost : FindBest
    {
        public int FindBestTimeToUploadAPost(List<string> io_Posts)
        {
            List<Post> posts = FetcherFacade.sr_Fetcher.FetchPosts();
            float maxLikePerPost = 0, likesPerPost = 0;
            int bestHour = 0, hour = 0;

            List<PublishAndReactions> listOfPostsLikeByTime = createTimeList();

            foreach (Post post in posts)
            {
                listOfPostsLikeByTime[post.CreatedTime.Value.Hour].m_NumOfPublishes += 1;
                listOfPostsLikeByTime[post.CreatedTime.Value.Hour].m_TotalReactions += post.Comments.Count;
                listOfPostsLikeByTime[post.CreatedTime.Value.Hour].m_PictureOrTextHandeler.Add(post.Caption);
            }
            bestHour = FindWhen(io_Posts, maxLikePerPost, likesPerPost, bestHour, hour, listOfPostsLikeByTime);

            return bestHour;
        }
    }
     
}
