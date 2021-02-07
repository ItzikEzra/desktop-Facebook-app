using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    public class MatchFinderFeature
    {
        public MatchFinderFeature(IStrategyMatcher i_StrategyMatcher)
        {
            IStrategyMatcher = i_StrategyMatcher;
        }

        public IStrategyMatcher IStrategyMatcher { get; set; }

        public void FindMatch(User i_LoggedInUser)
        {
            IStrategyMatcher.FindMatch(i_LoggedInUser);
        }

    }
}
