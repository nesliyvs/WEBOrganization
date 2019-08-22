using DataAccessLayer;
using DataAccessLayer.IRepositories;
using DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizationWeb.Controllers
{
    public class OrganizationController : Controller
    {
        OrganizationRepository orgrep;
        ImageRepository imagerep;
        OrgImageRepository orgimagerep;
        ParticipantRepository partrep;
        OrganizationParticipantRepository orgparticipantrep;
        OrganizationCommentRepository orgcommentrep;
        CommentRepository commentrep;
        static OrganizationDbEntities db;

        public OrganizationController()
        {
            db = new OrganizationDbEntities();

            orgrep = new OrganizationRepository(db);
            imagerep = new ImageRepository(db);
            orgimagerep = new OrgImageRepository(db);
            partrep = new ParticipantRepository(db);
            orgparticipantrep = new OrganizationParticipantRepository(db);
            orgcommentrep = new OrganizationCommentRepository(db);
            commentrep = new CommentRepository(db);
        }


        // GET: Organization
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddOrganization()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddOrganization(Organization entity)
        {
            if (Request.Files.Count <= 0)
            {
                ModelState.AddModelError("ImageValidation", "Image seçilmedi");
            }
            if (Request.Files[0].ContentLength <= 0)
            {
                ModelState.AddModelError("ImageValidation", "Image seçilmedir");
            }


            if (!ModelState.IsValid)
            {
                return View(entity);
            }




            Image image = new Image();
            image.ImageUrl = Request.Files[0].FileName;
            imagerep.Add(image);

            var imagePath = ConfigurationManager.AppSettings["ImagePath"] + "/" + image.Id + "_" + image.ImageUrl;

            Request.Files[0].SaveAs(imagePath);

            entity.ImageId = image.Id;


            orgrep.Add(entity);


            return RedirectToAction("ListOrgs");


        }


        public ActionResult ListOrgs()
        {
            List<Organization> orgList = orgrep.List();

            return View(orgList);
        }

        public ActionResult AddImage(int orgId)
        {
            Image img = new Image();
            img.ImageUrl = Request.Files[0].FileName;
            imagerep.Add(img);

            string ImagePath = ConfigurationManager.AppSettings["ImagePath"] + "/" + img.Id + "_" + img.ImageUrl;

            Request.Files[0].SaveAs(ImagePath);

            OrganizationImage orgimage = new OrganizationImage();
            orgimage.ImageId = img.Id;
            orgimage.OrganizationId = orgId;
            orgimagerep.Add(orgimage);


            return RedirectToAction("Detail", new { id = orgId });
        }

        public ActionResult Detail(int id)
        {
            Organization model = orgrep.Get(id);
            List<Participant> AllParticipant = partrep.List();
            List<Participant> filteredParticipant = new List<Participant>();
            foreach (var part in AllParticipant)
            {
                if (model.OrganizationParticipant.Where(c => c.ParticipantId == part.Id).Count() <= 0)
                {
                    filteredParticipant.Add(part);
                }

            }
            ViewData["AllParticipants"] = filteredParticipant;


            return View(model);


           
        }

        public ActionResult AddParticipant(int selectedPart,int orgId)
        {
            OrganizationParticipant orgpart = new OrganizationParticipant();
            orgpart.OrganizationId = orgId;
            orgpart.ParticipantId = selectedPart;

            orgparticipantrep.Add(orgpart);


            return RedirectToAction("Detail", new { id = orgId });
        }
        public ActionResult DeleteParticipant(int id,int orgId)
        {
            orgparticipantrep.Delete(id);
            return RedirectToAction("Detail", new { id = orgId });
        }

        public ActionResult DeleteImage(int id,int orgId)
        {
            orgimagerep.Delete(id);
            return RedirectToAction("Detail", new { id = orgId });
        }

        [HttpPost]
        public string AddComment(int orgId, string Comment)
        {
            Comment com = new Comment();
            com.Comment1 = Comment;
            com.Organization = orgrep.Get(orgId);
            com.CommentDate = DateTime.Now;
            com.Participant = partrep.Get(1);
            commentrep.Add(com);

            return com.Comment1;
        }

        public ActionResult ListComment()
        {
            List<Comment> commentList = commentrep.List();

            return View(commentList);

        }

        public ActionResult CommentListPartial(int id)
        {
            var model = commentrep.List().Where(c=>c.Organization.Id== id).ToList();
            return PartialView(model);
        }



    }
}
