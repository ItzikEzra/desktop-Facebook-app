using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    public interface IStrategyMatcher
    {
        User m_BestMatch { get; set; }

        void FindMatch(User i_LoggedInUser);
    }
}

