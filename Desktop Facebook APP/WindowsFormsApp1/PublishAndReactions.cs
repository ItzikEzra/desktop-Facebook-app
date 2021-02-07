using System.Collections;
using System.Collections.Generic;

namespace Desktop_Facebook
{
    //Iterator
    public class PublishAndReactions : IEnumerable
    {
        public PublishAndReactions(int i_NumOfPublishes, int i_TotalReactions)
        {
            this.m_NumOfPublishes = i_NumOfPublishes;
            this.m_TotalReactions = i_TotalReactions;
            this.m_PictureOrTextHandeler = new List<string>();
        }

        public int m_TotalReactions { get; set; }

        public int m_NumOfPublishes { get; set; }

        public List<string> m_PictureOrTextHandeler;

        
        public IEnumerator GetEnumerator()
        {
            return this.m_PictureOrTextHandeler.GetEnumerator();
        }
    }
}
