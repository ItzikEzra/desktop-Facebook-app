using System.Collections.Generic;

namespace Desktop_Facebook
{
    public class FindBest
    {
        public int FindWhen(List<string> io_Publish, float i_MaxReactionsPerPublish, float io_ReactionPerPublish, int o_BestHourToPost, int io_Hour, List<PublishAndReactions> io_ListOfPublihesByTime)
        {
            io_ReactionPerPublish = 0;

            foreach (PublishAndReactions photosAndLikes in io_ListOfPublihesByTime)
            {
                if (photosAndLikes.m_NumOfPublishes != 0)
                {
                    io_ReactionPerPublish = photosAndLikes.m_TotalReactions / photosAndLikes.m_NumOfPublishes;
                }
                else
                {
                    io_ReactionPerPublish = 0;
                }

                if (i_MaxReactionsPerPublish < io_ReactionPerPublish)
                {
                    io_Publish = photosAndLikes.m_PictureOrTextHandeler;
                    i_MaxReactionsPerPublish = io_ReactionPerPublish;
                    o_BestHourToPost = io_Hour;
                }
                else
                {
                    o_BestHourToPost = 0;
                }

                io_Hour += 1;

            }
          
            return o_BestHourToPost;
        }

        public List<PublishAndReactions> createTimeList()
        {
            List<PublishAndReactions> listOfPhotosLikeByTime = new List<PublishAndReactions>();
            for (int i = 0; i < 24; i++)
            {
                listOfPhotosLikeByTime.Add(new PublishAndReactions(0, 0));
            }
            return listOfPhotosLikeByTime;
        }
    }
     
}
