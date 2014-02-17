using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using CrypticMeaning_KO.Models;

namespace CrypticMeaning_KO.Controllers
{
    public class ForumController : ApiController
    {
        private ForumContext db = new ForumContext();

        // GET api/Forum
        public IEnumerable<Forum> GetForum()
        {
            return db.Threads.AsEnumerable();
        }

        // GET api/Forum/5
        public Forum GetForum(int id)
        {
            Forum forum = db.Threads.Find(id);
            if (forum == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return forum;
        }

        // PUT api/Forum/5
        public HttpResponseMessage PutForum(int id, Forum forum)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (id != forum.ForumId)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(forum).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Forum
        public HttpResponseMessage PostForum(Forum forum)
        {
            if (ModelState.IsValid)
            {
                db.Threads.Add(forum);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, forum);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = forum.ForumId }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Forum/5
        public HttpResponseMessage DeleteForum(int id)
        {
            Forum forum = db.Threads.Find(id);
            if (forum == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            db.Threads.Remove(forum);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, forum);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}