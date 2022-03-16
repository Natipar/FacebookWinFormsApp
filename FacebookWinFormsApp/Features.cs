using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace BasicFacebookFeatures
{

    public class Features
    {

        private NearestFriends m_CloseFriends;
        private GenderSorter m_GenderSorter;
        private User m_UserInLogged;

        public Features(User i_UserLogged)
        {

            m_UserInLogged = i_UserLogged;

        }

        public List<NearestFriends.FriendByCoordinate> InitiateCloseFriends()
        {

            m_CloseFriends = new NearestFriends(m_UserInLogged);
            return m_CloseFriends.NearestFriendsMeth();

        }

        public List<User> InitiateGenderSorter(User.eGender i_Gender)
        {
            m_GenderSorter = new GenderSorter(m_UserInLogged);

            if (i_Gender == User.eGender.male)
            {

                return m_GenderSorter.MaleSorter();

            }
            else
            {
                return m_GenderSorter.FemaleSorter();
            }

        }

    }

}
