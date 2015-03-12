using InterestFinder.Controllers;
using InterestFinder.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace IFBackendTest
{
    [TestFixture]
    public class Class1
    {
        private ApplicationDbContext db;

        [SetUpFixture]
        public void SetUp()
        {
            db = new ApplicationDbContext();
        }

        [Test]
        public void TestMailSystem()
        {
            string testContentText = "hej test";
            PostController postController = new PostController();
            FormCollection fCollection = new FormCollection();
            fCollection["PostToCreate.ContentText"] = testContentText;
            fCollection["PostToCreate.HeaderText"] = "test title";
            fCollection["PostToCreate.TimePosted"] = DateTime.Now.ToShortDateString();
            fCollection["PostToCreate.InterestID"] = "61";
            postController.CreatePost(fCollection);

            Post post = db.Posts.Find("61");
            Assert.AreEqual(testContentText, post.ContentText);
        }
    }
}
