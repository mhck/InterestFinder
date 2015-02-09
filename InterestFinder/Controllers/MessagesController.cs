using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using InterestFinder.Models;
using System.Collections.Specialized;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace InterestFinder.Controllers
{
    public class MessagesController : Controller
    {
        protected ApplicationDbContext db;
        protected ApplicationUserManager userManager;

        public MessagesController()
        {
            db = new ApplicationDbContext();
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
        }

        // GET: Messages
        public ActionResult Index()
        {
            string CurrentUserName = userManager.FindById(User.Identity.GetUserId()).UserName;
            IList<Message> CurrentUserInbox = new List<Message>();
            foreach (Message msg in db.Messages.Where(x => x.ReceiverName == CurrentUserName)) {
                    CurrentUserInbox.Add(msg);
            }
            return View(CurrentUserInbox);
        }

        // GET: Sent Messages
        public ActionResult SentMessages() { 
        string CurrentUserName = userManager.FindById(User.Identity.GetUserId()).UserName;
            IList<Message> CurrentUserSentMessages = new List<Message>();
            foreach (Message msg in db.Messages.Where(x => x.SenderName == CurrentUserName)) {
                    CurrentUserSentMessages.Add(msg);
            }
            return View(CurrentUserSentMessages);
        }

        // GET: Messages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // GET: Messages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Messages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MessageId,Content")] Message message)
        {
            NameValueCollection form = Request.Form;
            message.ReceiverName = form["ReceiverName"];
            ApplicationUser Receiver = userManager.FindByName(message.ReceiverName);
            if (Receiver != null)
                message.Receiver = Receiver;
            message.SenderName = userManager.FindById(User.Identity.GetUserId()).Nickname;
            message.TimeSent = DateTime.Now;
            message.Tags = new List<string>();

            if (ModelState.IsValid && Receiver != null)
            {
                System.Diagnostics.Debug.WriteLine("RECEIVER: " + Receiver.ToString());
                db.Messages.Add(message);
                Receiver.Inbox.Add(message);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(message);
        }

        // GET: Messages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MessageId,Content,TimeSent")] Message message)
        {
            if (ModelState.IsValid)
            {
                db.Entry(message).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(message);
        }

        // GET: Messages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Message message = db.Messages.Find(id);
            if (message == null)
            {
                return HttpNotFound();
            }
            return View(message);
        }

        // POST: Messages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Message message = db.Messages.Find(id);
            db.Messages.Remove(message);
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
