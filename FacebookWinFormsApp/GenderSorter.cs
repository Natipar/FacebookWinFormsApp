using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{

    public class GenderSorter
    {

        private User m_LoggedInUser;

        public GenderSorter(User i_UserSortByGender)
        {

            m_LoggedInUser = i_UserSortByGender;

        }

        public List<User> MaleSorter()
        {

            List<User> maleList = new List<User>();
            bool isNotMale = false;

            try
            {

                foreach (User friend in m_LoggedInUser.Friends)
                {

                    if ((friend.Gender.HasValue != isNotMale) && (friend.Gender.Value.Equals(User.eGender.male)))
                    {

                        maleList.Add(friend);

                    }

                }

                return maleList;

            }
            catch
            {

                return maleList;

            }

        }

        public List<User> FemaleSorter()
        {

            bool isNotFemale = false;
            List<User> femaleList = new List<User>();

            try
            {

                foreach (User friend in m_LoggedInUser.Friends)
                {

                    if ((friend.Gender.HasValue != isNotFemale) && (friend.Gender.Value.Equals(User.eGender.female)))
                    {

                        femaleList.Add(friend);

                    }

                }

                return femaleList;
            }

            catch
            {

                return femaleList;

            }

        }

    }

}
