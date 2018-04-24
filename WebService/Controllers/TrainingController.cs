using Models;
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

    }
}