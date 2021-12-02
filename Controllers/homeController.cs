using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using db_connectivity.Models;
namespace db_connectivity.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Login()
        {
            if (Session["username"] != null) {
                return RedirectToAction("homePage");
            };
            return View();
        }

        public ActionResult SignUp()
        {
            if (Session["username"] != null)
            {
                return RedirectToAction("homePage");
            };
            return View();
        }



        public ActionResult CreateTweet(string postString, string postImageURL, string postCategory)
        {
            string username = Session["username"] as string;
            int result = CRUD.CreateTweet(username, postString, postImageURL, postCategory);

            return RedirectToAction("ProfileRedirect", new { name = username });
        }

        public ActionResult CreateComment(int postid, string commentString)
        {
            int result = CRUD.CreateComment(postid, commentString, Session["username"] as string);

            return RedirectToAction("ViewPost",new { postid = postid });
        }


        public ActionResult authenticate(String username, String password)
        {
            int result = CRUD.Login(username, password);

            if (result == -1)
            {
                String data = "Username does not exist: " + username;
                return View("Login", (object)data);
            }
            else if (result == 0)
            {

                String data = "Password is incorrect.";
                return View("Login", (object)data);
            }


            Session["username"] = username;
            return RedirectToAction("SignUp");

        }

        public ActionResult registerUser(String name, String username, String password)
        {

            int result = CRUD.Register(name, username, password);

            if (result == -1)
            {
                String data = "Name cannot be null";
                return View("SignUp", (object)("ERROR: " + data));
            }
            else if (result == -2)
            {
                String data = "Username cannot be null";
                return View("SignUp", (object)("ERROR: " + data));
            }
            else if (result == -3)
            {
                String data = "Password cannot be null";
                return View("SignUp", (object)("ERROR: " + data));
            }
            else if (result == 0)
            {

                String data = "Username is not unique";
                return View("SignUp", (object)("ERROR: " + data));
            }


            Session["username"] = username;
            return RedirectToAction("Settings");

        }

        public ActionResult ViewPost(int postid)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            Tweet tweetData = CRUD.viewPostTweet(postid);
            List<Tweet> commentsList = CRUD.viewPostComment(postid);
            List<User> WhoToFollow = CRUD.WhoToFollow(Session["username"] as string);

            ViewBag.tweetData = tweetData;
            ViewBag.commentsList = commentsList;
            ViewBag.WhoToFollow = WhoToFollow;
            ViewBag.postid = postid;
            ViewBag.likeThisTweet = CRUD.CheckIfUsernameLike(Session["username"] as string, postid).ToString();

            User userDetails = CRUD.getUserData(Session["username"] as string);

            return View(userDetails);
        }



        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Login");
        }

        public ActionResult UpdateUserSettings(string username, string name, string pass, string imageURL, string bio, string country, string website)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            int res = CRUD.UpdateUserDetails(username, name, pass, imageURL, bio, country, website);

            return RedirectToAction("Settings");
        }


        public ActionResult Settings()
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            string username = Session["username"] as string;

            List<User> WhoToFollow = CRUD.WhoToFollow(username);
            List<string> UserProfileCountData = CRUD.UserProfileCountData(username);
            User userDetails = CRUD.getUserData(username);

            int followThisPerson = 0;

            //  ViewBag.defaultHomePageTweets = defaultHomePageTweets;
            ViewBag.WhoToFollow = WhoToFollow;
            ViewBag.UserProfileCountData = UserProfileCountData;
            // ViewBag.getTweetsMadeByUsername = getTweetsMadeByUsername;
            ViewBag.followThisPerson = followThisPerson;

            return View(userDetails);
        }


        public ActionResult ProfileFollowing(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            string username = CRUD.getUsernameFromID(id);

            List<User> WhoToFollow = CRUD.WhoToFollow(Session["username"] as string);
            List<string> UserProfileCountData = CRUD.UserProfileCountData(username);
            User userDetails = CRUD.getUserData(username);
            List<User> GetFollowingsDetails = CRUD.GetFollowingsDetails(username);

            //  ViewBag.defaultHomePageTweets = defaultHomePageTweets;
            ViewBag.WhoToFollow = WhoToFollow;
            ViewBag.UserProfileCountData = UserProfileCountData;
            ViewBag.FDetails = GetFollowingsDetails;
            userDetails.userid = id.ToString();

            return View(userDetails);
        }

        public ActionResult ProfileFollowers(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            string username = CRUD.getUsernameFromID(id);

            List<User> WhoToFollow = CRUD.WhoToFollow(Session["username"] as string);
            List<string> UserProfileCountData = CRUD.UserProfileCountData(username);
            User userDetails = CRUD.getUserData(username);
            List<User> GetFollowersDetails = CRUD.GetFollowersDetails(username);

            ViewBag.WhoToFollow = WhoToFollow;
            ViewBag.UserProfileCountData = UserProfileCountData;
            ViewBag.FDetails = GetFollowersDetails;
            userDetails.userid = id.ToString();

            return View(userDetails);
        }


        public ActionResult Profile(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            string username = CRUD.getUsernameFromID(id);

            //List<Tweet> defaultHomePageTweets = CRUD.getDefaultFeedTweets(Session["username"] as string);
            List<User> WhoToFollow = CRUD.WhoToFollow(Session["username"] as string);
            List<string> UserProfileCountData = CRUD.UserProfileCountData(username);
            User userDetails = CRUD.getUserData(username);
            List<Tweet> getTweetsMadeByUsername = CRUD.getTweetsMadeByUsername(username);

            string followThisPerson = CRUD.CheckIfUserFollows(Session["username"] as string, username).ToString();

            //  ViewBag.defaultHomePageTweets = defaultHomePageTweets;
            ViewBag.WhoToFollow = WhoToFollow;
            ViewBag.UserProfileCountData = UserProfileCountData;
            ViewBag.getTweetsMadeByUsername = getTweetsMadeByUsername;
            ViewBag.followThisPerson = followThisPerson;
            userDetails.userid = id.ToString();

            return View(userDetails);
        }

        public ActionResult ProfileRedirect(string name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            int id = CRUD.getIDFromUsername(name);

            return RedirectToAction("Profile", new { id = id });
        }

        public ActionResult likeATweet(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            string username = Session["username"] as string;

            int result = CRUD.AddLike(username, id);

            return RedirectToAction("ViewPost", new { postid = id });
        }

        public ActionResult unlikeATweet(int id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            string username = Session["username"] as string;

            int result = CRUD.RemoveLike(username, id);

            return RedirectToAction("ViewPost", new { postid = id });
        }

        public ActionResult followThisPerson(string name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            int res = CRUD.FollowAPerson(Session["username"] as string, name);

            return RedirectToAction("ProfileRedirect", new { name = name });
        }

        public ActionResult unfollowThisPerson(string name)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            int res = CRUD.UnFollowAPerson(Session["username"] as string, name);

            return RedirectToAction("ProfileRedirect", new { name = name });
        }

        public ActionResult Search(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            List<Tweet> FindWordInTweet = CRUD.FindWordInTweet(id);
            User userDetails = CRUD.getUserData(Session["username"] as string);
            List<User> WhoToFollow = CRUD.WhoToFollow(Session["username"] as string);

            ViewBag.FindWordInTweet = FindWordInTweet;
            ViewBag.WhoToFollow = WhoToFollow;

            return View(userDetails);
        }

        public ActionResult Explore(string id)
        {
            if (Session["username"] == null)
            {
                return RedirectToAction("Login");
            };

            List<Tweet> GetCategoryTweets = CRUD.GetCategoryTweets(id);
            User userDetails = CRUD.getUserData(Session["username"] as string);
            List<string> ListDistinctCategories = CRUD.ListDistinctCategories();

            ViewBag.GetCategoryTweets = GetCategoryTweets;
            ViewBag.ListDistinctCategories = ListDistinctCategories;

            ViewBag.catName = id;

            return View(userDetails);
        }

        public ActionResult homePage()
        {
            if (Session["username"]==null)
              {
                 return RedirectToAction("Login");
              };

            List<Tweet> defaultHomePageTweets = CRUD.getDefaultFeedTweets(Session["username"] as string);
            List<User> WhoToFollow = CRUD.WhoToFollow(Session["username"] as string);
            User userDetails = CRUD.getUserData(Session["username"] as string);

            ViewBag.defaultHomePageTweets = defaultHomePageTweets;
            ViewBag.WhoToFollow = WhoToFollow;

            return View(userDetails);
        }

    }
}