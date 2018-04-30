using Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebService.Models;

namespace WebService.Controllers
{
    public class TrainingController : ApiController
    {
        private TrainingService trainingService;

        public TrainingController()
        {
            trainingService = new TrainingService();
        }

        [HttpGet]
        [ActionName("alltrainingsobjects")]
        public IHttpActionResult GetAllTrainingsobjects(int userid)
        {
            return Ok(trainingService.GetAllTrainingsObjects(userid));
        }

        
        [HttpPost]
        [ActionName("insertobject")]
        public IHttpActionResult InsertObject([FromBody]Trainingsobject trainingsobject)
        {
            
            return Ok(trainingService.InsertObject(trainingsobject, trainingsobject.Owner));
        }

        [HttpGet]
        [ActionName("allpublictrainingsobjects")]
        public IHttpActionResult GetAllPublicTrainingsobjects()
        {
            return Ok(trainingService.GetAllPublicTrainingsObjects());
        }

    }
}