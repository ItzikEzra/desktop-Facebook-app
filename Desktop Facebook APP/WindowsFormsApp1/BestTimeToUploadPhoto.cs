using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{

    public class BestTimeToUploadPhoto : FindBest
    {
        public int FindBestTimeToUploadAPicture(List<string> io_Pictures)
        {
            List<Album> albums = FetcherFacade.sr_Fetcher.FetchUserAlbums();
            float maxLikePerPhoto = 0, likesPerPost = 0;
            int bestHourToPost = 0, hour = 0;

            List<PublishAndReactions> listOfPhotosLikeByTime = createTimeList();

            foreach (Album album in albums)
            {
                foreach (Photo photo in album.Photos)
                {
                    listOfPhotosLikeByTime[photo.CreatedTime.Value.Hour].m_NumOfPublishes += 1;
                    listOfPhotosLikeByTime[photo.CreatedTime.Value.Hour].m_TotalReactions += photo.LikedBy.Count;
                    listOfPhotosLikeByTime[photo.CreatedTime.Value.Hour].m_PictureOrTextHandeler.Add(photo.PictureNormalURL);
                }
            }
            bestHourToPost = FindWhen(io_Pictures, maxLikePerPhoto, likesPerPost, bestHourToPost, hour, listOfPhotosLikeByTime);
            return bestHourToPost;
        }

    }

}

