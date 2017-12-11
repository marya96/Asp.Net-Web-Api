using ApiAnnouncements.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace ApiAnnouncements.Controllers.api
{
    public class AnnouncementsController : ApiController
    {
        private ApiAnnouncementsDbContext db = new ApiAnnouncementsDbContext();

        // GET: api/Announcements
        public IQueryable<Announcement> GetAnnouncements()
        {
            return db.Announcements;
        }

        // GET: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult GetAnnouncement(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return NotFound();
            }

            return Ok(announcement);
        }

        // PUT: api/Announcements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnnouncement(int id, Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != announcement.Id)
            {
                return BadRequest();
            }

            db.Entry(announcement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnnouncementExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Announcements
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult PostAnnouncement(Announcement announcement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Announcements.Add(announcement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = announcement.Id }, announcement);
        }

        // DELETE: api/Announcements/5
        [ResponseType(typeof(Announcement))]
        public IHttpActionResult DeleteAnnouncement(int id)
        {
            Announcement announcement = db.Announcements.Find(id);
            if (announcement == null)
            {
                return NotFound();
            }

            db.Announcements.Remove(announcement);
            db.SaveChanges();

            return Ok(announcement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnnouncementExists(int id)
        {
            return db.Announcements.Count(e => e.Id == id) > 0;
        }
    }
}