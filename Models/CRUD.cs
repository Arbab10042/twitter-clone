using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace db_connectivity.Models
{
    public class CRUD
    {
        public static string connectionString = "data source=localhost; Initial Catalog=LTwitter;Integrated Security=true";

        public static List<Tweet> getDefaultFeedTweets(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("DefaultFeedTweets", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Tweet> list = new List<Tweet>();
                while (rdr.Read())
                {
                    Tweet tweet = new Tweet();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.userid = rdr["userid"].ToString();
                    tweet.userImage = rdr["imageURL"].ToString();
                    tweet.postid = rdr["postid"].ToString();
                    tweet.postString = rdr["postString"].ToString();
                    tweet.postImageURL = rdr["postImageURL"].ToString();
                    tweet.datePost = rdr["datePost"].ToString();
                    tweet.likes = rdr["likes"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Tweet> FindWordInTweet(string word)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("FindWordInTweet", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@word", SqlDbType.NVarChar, 15).Value = word;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Tweet> list = new List<Tweet>();
                while (rdr.Read())
                {
                    Tweet tweet = new Tweet();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.userid = rdr["userid"].ToString();
                    tweet.userImage = rdr["imageURL"].ToString();
                    tweet.postid = rdr["postid"].ToString();
                    tweet.postString = rdr["postString"].ToString();
                    tweet.datePost = rdr["datePost"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Tweet> GetCategoryTweets(string word)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("GetCategoryTweets", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@categoryName", SqlDbType.NVarChar, 100).Value = word;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Tweet> list = new List<Tweet>();
                while (rdr.Read())
                {
                    Tweet tweet = new Tweet();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.userid = rdr["userid"].ToString();
                    tweet.userImage = rdr["imageURL"].ToString();
                    tweet.postid = rdr["postid"].ToString();
                    tweet.postString = rdr["postString"].ToString();
                    tweet.datePost = rdr["datePost"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<string> ListDistinctCategories()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("ListDistinctCategories", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<string> list = new List<string>();
                while (rdr.Read())
                {
                    string catName = rdr["categoryName"].ToString();

                    list.Add(catName);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Tweet> getTweetsMadeByUsername(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("TweetsMadeByUser", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<Tweet> list = new List<Tweet>();
                while (rdr.Read())
                {
                    Tweet tweet = new Tweet();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.userImage = rdr["imageURL"].ToString();
                    tweet.postid = rdr["postid"].ToString();
                    tweet.postString = rdr["postString"].ToString();
                    tweet.postImageURL = rdr["postImageURL"].ToString();
                    tweet.datePost = rdr["datePost"].ToString();
                    tweet.likes = rdr["likes"].ToString();
                    tweet.totalComments = rdr["totalComments"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<User> WhoToFollow(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("WhoToFollow", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<User> list = new List<User>();
                while (rdr.Read())
                {
                    User tweet = new User();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.imageURL = rdr["imageURL"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<User> GetFollowersDetails(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("UserFollowers", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<User> list = new List<User>();
                while (rdr.Read())
                {
                    User tweet = new User();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.imageURL = rdr["imageURL"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<User> GetFollowingsDetails(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("UserFollowings", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();

                List<User> list = new List<User>();
                while (rdr.Read())
                {
                    User tweet = new User();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.imageURL = rdr["imageURL"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;


            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<string> UserProfileCountData(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("UserProfileCountData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string followers = rdr["FollowersCount"].ToString();
                string following = rdr["FollowingsCount"].ToString();


                List<string> list = new List<string>();
                list.Add(followers);
                list.Add(following);

                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static string getUsernameFromID(int id)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("GetUsernameFromID", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@id", SqlDbType.Int).Value = id;

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                string username = rdr["username"].ToString();

                rdr.Close();
                con.Close();

                return username;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static int getIDFromUsername(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            //this function doesnt work ignore
            try
            {
                cmd = new SqlCommand("GetIDFromUsername", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                int id = Convert.ToInt32(rdr["userid"]);

                rdr.Close();
                con.Close();

                return id;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return -1;

            }

        }

        public static Tweet viewPostTweet(int postid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("GetTweetDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@postid", SqlDbType.Int).Value = postid;

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();


                Tweet tweet = new Tweet();

                tweet.name = rdr["name"].ToString();
                tweet.userid = rdr["userid"].ToString();
                tweet.username = rdr["username"].ToString();
                tweet.userImage = rdr["imageURL"].ToString();
                tweet.postString = rdr["postString"].ToString();
                tweet.postImageURL = rdr["postImageURL"].ToString();
                tweet.datePost = rdr["datePost"].ToString();
                tweet.likes = rdr["likes"].ToString();
                tweet.totalComments = rdr["totalComments"].ToString();


                rdr.Close();
                con.Close();

                return tweet;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static List<Tweet> viewPostComment(int postid)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("GetCommentDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@postid", SqlDbType.Int).Value = postid;

                SqlDataReader rdr = cmd.ExecuteReader();


                List<Tweet> list = new List<Tweet>();
                while (rdr.Read())
                {
                    Tweet tweet = new Tweet();

                    tweet.name = rdr["name"].ToString();
                    tweet.username = rdr["username"].ToString();
                    tweet.userImage = rdr["imageURL"].ToString();
                    tweet.postString = rdr["commentString"].ToString();
                    tweet.datePost = rdr["dateComment"].ToString();

                    list.Add(tweet);
                }

                rdr.Close();
                con.Close();

                return list;
            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static User getUserData(string username)
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;

            try
            {
                cmd = new SqlCommand("getUserData", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                SqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();

                User user = new User();

                user.userid = rdr["userId"].ToString();
                user.name = rdr["name"].ToString();
                user.username = rdr["username"].ToString();
                user.password = rdr["pass"].ToString();
                user.dateJoin = rdr["dateJoin"].ToString();
                user.imageURL = rdr["imageURL"].ToString();
                user.bio = rdr["bio"].ToString();
                user.country = rdr["country"].ToString();
                user.website = rdr["website"].ToString();


                //List<User> list = new List<User>();
                //while (rdr.Read())
                // {
                // list.Add(user);
                // }

                rdr.Close();
                con.Close();

                return user;

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                return null;

            }

        }

        public static int CreateTweet(string username, string postString, string postImageURL, string postCategory)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("CreateTweet", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@postString", SqlDbType.NVarChar, 200).Value = postString;
                cmd.Parameters.Add("@postImageURL", SqlDbType.NVarChar, 200).Value = postImageURL;
                cmd.Parameters.Add("@category", SqlDbType.NVarChar, 100).Value = postCategory.ToLower();

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int CreateComment(int postid, string commentString, string username)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("CreateComment", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@postid", SqlDbType.Int).Value = postid;
                cmd.Parameters.Add("@commentString", SqlDbType.NVarChar, 200).Value = commentString;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int AddLike(string username, int postid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("AddLike", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@postid", SqlDbType.Int).Value = postid;

                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int RemoveLike(string username, int postid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("RemoveLike", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@postid", SqlDbType.Int).Value = postid;

                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int CheckIfUsernameLike(string username, int postid)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("CheckIfUsernameLike", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@postid", SqlDbType.Int).Value = postid;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int FollowAPerson(string username1, string username2)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("FollowAPerson", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@followerUsername", SqlDbType.NVarChar, 200).Value = username1;
                cmd.Parameters.Add("@followingUsername", SqlDbType.NVarChar, 100).Value = username2;

                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int UnFollowAPerson(string username1, string username2)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("UnFollowAPerson", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@followerUsername", SqlDbType.NVarChar, 200).Value = username1;
                cmd.Parameters.Add("@followingUsername", SqlDbType.NVarChar, 100).Value = username2;

                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int CheckIfUserFollows(string username1, string username2)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("CheckIfUserFollows", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@followerUsername", SqlDbType.NVarChar, 200).Value = username1;
                cmd.Parameters.Add("@followingUsername", SqlDbType.NVarChar, 100).Value = username2;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int UpdateUserDetails(string username, string name, string pass, string imageURL, string bio, string country, string website)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("UpdateUserDetails", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 250).Value = name;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 100).Value = pass;
                cmd.Parameters.Add("@imageURL", SqlDbType.NVarChar, 100).Value = imageURL;
                cmd.Parameters.Add("@bio", SqlDbType.NVarChar, 100).Value = bio;
                cmd.Parameters.Add("@country", SqlDbType.NVarChar, 80).Value = country;
                cmd.Parameters.Add("@website", SqlDbType.NVarChar, 150).Value = website;

                cmd.ExecuteNonQuery();

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }


        public static int Register(string name, string username, string password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("UserSignup", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar, 250).Value = name;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@password", SqlDbType.NVarChar, 100).Value = password;

                cmd.Parameters.Add("@output", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@output"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

        public static int Login(string username, string password)
        {

            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            SqlCommand cmd;
            int result = 0;

            try
            {
                cmd = new SqlCommand("SignIn", con);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", SqlDbType.NVarChar, 100).Value = username;
                cmd.Parameters.Add("@pass", SqlDbType.NVarChar, 100).Value = password;


                cmd.Parameters.Add("@flag", SqlDbType.Int).Direction = ParameterDirection.Output;

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(cmd.Parameters["@flag"].Value);

            }

            catch (SqlException ex)
            {
                Console.WriteLine("SQL Error" + ex.Message.ToString());
                result = -1; //-1 will be interpreted as "error while connecting with the database."
            }
            finally
            {
                con.Close();
            }
            return result;

        }

    }
}