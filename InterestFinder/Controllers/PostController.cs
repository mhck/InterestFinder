using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterestFinder.Models;
using InterestFinder.ViewModels;
using Microsoft.AspNet.Identity.EntityFramework;

namespace InterestFinder.Controllers
{
    public class PostController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected ApplicationUserManager userManager;
        // GET: Post
        public ActionResult Index(int? interestID)
        {
            if (interestID != null)
            {
                var result = db.Interests.Join(db.Posts,
                        i => i.InterestID,
                        p => p.InterestID,
                        (i, p) => new
                        {
                            Post = p
                        });
                Console.WriteLine("Index result: {0}", result.ToList());
                return View(result.ToList());
            }
            return View();
        }

        // GET: Post/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Post/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Post/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostID,InterestID,HeaderText,ContentText,TimePosted")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(post);
        }

        // POST: Post/CreatePost
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreatePost(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.ContentText = formCollection["PostToCreate.ContentText"];
                post.HeaderText = formCollection["PostToCreate.HeaderText"];
                post.InterestID = Convert.ToInt32(formCollection["PostToCreate.InterestID"]);
                post.TimePosted = DateTime.Parse(formCollection["PostToCreate.TimePosted"]);
                Interest interest = db.Interests.Find(post.InterestID);
                db.Posts.Add(post);
                db.SaveChanges();
                return RedirectToAction("Details", "Interest", new { id = post.InterestID });
            }
            return View();
        }

        // GET: Post/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostID,InterestID,HeaderText,ContentText,TimePosted")] Post post)
        {
            if (ModelState.IsValid)
            {
                db.Entry(post).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }

        // GET: Post/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = db.Posts.Find(id);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Post post = db.Posts.Find(id);
            db.Posts.Remove(post);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
