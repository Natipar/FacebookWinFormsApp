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
    public class NearestFriends
    {

        public struct FriendByCoordinate
        {

            public double m_Distance;
            public string m_Name;

        }

        private User m_UserLogged;

        public NearestFriends(User i_UserSearchFriendsNeares)
        {

            m_UserLogged = i_UserSearchFriendsNeares;

        }

        public List<FriendByCoordinate> NearestFriendsMeth()
        {

            FriendByCoordinate closeFriends;
            List<FriendByCoordinate> listCloseFriends = null;
            double distance = 0;
            int index = 0;

            try
            {

                if (m_UserLogged.Friends != null)
                {

                    listCloseFriends = new List<FriendByCoordinate>();

                    foreach (User friend in m_UserLogged.Friends)
                    {
                        if (m_UserLogged.Location.Location != null)
                        {
                            distance = this.distance((double)m_UserLogged.Location.Location.Latitude,
                               (double)m_UserLogged.Location.Location.Longitude,
                               (double)friend.Location.Location.Latitude,
                               (double)friend.Location.Location.Longitude);

                            closeFriends.m_Distance = distance;
                            closeFriends.m_Name = friend.Name;
                            listCloseFriends.Insert(index++, (closeFriends));

                        }
                        else
                        {
                            break;
                        }


                    }

                    listCloseFriends.Sort();


                }

                return listCloseFriends;

            }
            catch
            {

                return null;

            }

        }

        private double toRadians(double i_AngleIn10thofaDegree)
        {
            // Angle in 10th 
            // of a degree 
            return (i_AngleIn10thofaDegree * Math.PI) / 180;

        }

        private double distance(double i_FirstLatitude, double i_SecondLatitude
                               , double i_FirstLongitude, double i_SecondLongitude)
        {

            // The math module contains  
            // a function named toRadians  
            // which converts from degrees  
            // to radians. 
            double firstLatitudeAndCalculateToRadian = toRadians(i_FirstLatitude);
            double secondLatitudeAndCalculateToRadian = toRadians(i_SecondLatitude);

            double firstLongitudeAndCalculateToRadian = toRadians(i_FirstLongitude);
            double secondLongitudeAndCalculateToRadian = toRadians(i_SecondLongitude);

            // Haversine formula  
            double distanceLongitude = secondLongitudeAndCalculateToRadian - firstLongitudeAndCalculateToRadian;
            double distanceLatitude = secondLatitudeAndCalculateToRadian - firstLatitudeAndCalculateToRadian;
            double summaryOfDistance = Math.Pow(Math.Sin(distanceLatitude / 2), 2) +
                       Math.Cos(i_FirstLatitude) * Math.Cos(i_SecondLatitude) *
                       Math.Pow(Math.Sin(distanceLongitude / 2), 2);

            double Angle = 2 * Math.Asin(Math.Sqrt(summaryOfDistance));

            // Radius of earth in  
            // kilometers. Use 3956  
            // for miles 
            double radiusOfEarth = 6371;

            // calculate the result 
            return (Angle * radiusOfEarth);

        }

    }

}

