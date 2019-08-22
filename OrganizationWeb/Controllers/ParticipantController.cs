using DataAccessLayer;
using DataAccessLayer.Repositories;
using Newtonsoft.Json;
using OrganizationWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrganizationWeb.Controllers
{
    public class ParticipantController :
        Controller
    {

        ParticipantRepository partRep;
        OrganizationDbEntities db;
        public ParticipantController()
        {
            db = new OrganizationDbEntities();
            partRep = new ParticipantRepository(db);
        }

        // GET: Participant
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddParticipant()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddParticipant(Participant entity)
        {
            //partRep.Add(entity);
            //return View();

            AjaxResult result = new AjaxResult();
            if (!ModelState.IsValid)
            {
                string errorMessages = "";

                foreach(var item in ModelState.Values)
                {
                    foreach (var er in item.Errors)
                        errorMessages += er.ErrorMessage + "\r\n";
                }

                result.Result = 0;
                result.Message = errorMessages;

                return Json(result);
                
            }
            var ctx = new OrganizationDbEntities();

            Participant participant = JsonConvert.DeserializeObject<Participant>(JsonConvert.SerializeObject(entity));

            partRep.Add(participant);

            result.Result = 1;
            result.Message = "işlem başarılı";

            var partList = ctx.Participant.OrderByDescending(c => c.Id).ToList();//paticipant listesini büyükten küçüğe sıralıyoruz.

            return Json(result);
        }

        public ActionResult ListParticipant()
        {
            List<Participant> model = partRep.List();
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            partRep.Delete(id);
            return RedirectToAction("ListParticipant");
        }

        public ActionResult PartListPartial()
        {
            var model = partRep.List();
            return PartialView(model);
        }

        public ActionResult Update(int id)
        {
            var _ctx = new OrganizationDbEntities();

            var entity = _ctx.Participant.Where(c => c.Id ==id).FirstOrDefault();

            return View(entity);
        }

        [HttpPost]
        public ActionResult Update(Participant part)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
              

            partRep.Update(part);
            return RedirectToAction("ListParticipant");

           
        }

    }
}