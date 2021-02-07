using System.Collections.Generic;
using System.Linq;
using FacebookWrapper.ObjectModel;

namespace Desktop_Facebook
{
    public enum eSortType
    {
        SortByFirstName = 0,
        SortByLastName = 1
    }

    public abstract class ListSorter
    {
        internal abstract bool needSwap(User i_FirstUser, User i_SecondUser);

        public static ListSorter CreateSorter(eSortType i_SortType)
        {
            ListSorter result = null;

            switch (i_SortType)
            {
                case eSortType.SortByFirstName:
                    {
                        result = new SorterByFirstName();
                    }

                    break;
                case eSortType.SortByLastName:
                    {
                        result = new SorterByLastName();
                    }

                    break;
            }

            return result;
        }

        public void Sort(ref List<User> i_UserFriendList)
        {
            User[] UserFriendListAsArr = i_UserFriendList.ToArray();
            for (int i = 0; i < UserFriendListAsArr.Length; i++)
            {
                for (int j = 0; j < UserFriendListAsArr.Length - 1; j++)
                {
                    if (this.needSwap(UserFriendListAsArr[j], UserFriendListAsArr[j + 1]))
                    {
                        this.swap(ref UserFriendListAsArr[j], ref UserFriendListAsArr[j + 1]);
                    }
                }
            }

            i_UserFriendList = UserFriendListAsArr.ToList();
        }

        private void swap(ref User o_UserOne, ref User o_UserTwo)
        {
            User tempUser = new User();
            tempUser = o_UserOne;
            o_UserOne = o_UserTwo;
            o_UserTwo = tempUser;
        }

        private class SorterByFirstName : ListSorter
        {
            internal override bool needSwap(User i_FirstUser, User i_SecondUser)
            {
                return string.Compare(i_FirstUser.FirstName, i_SecondUser.FirstName) > 0;
            }
        }

        private class SorterByLastName : ListSorter
        {
            internal override bool needSwap(User i_FirstUser, User i_SecondUser)
            {
                return string.Compare(i_FirstUser.LastName, i_SecondUser.LastName) > 0;
            }
        }

    }
}