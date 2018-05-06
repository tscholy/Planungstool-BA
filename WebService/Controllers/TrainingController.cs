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

        [HttpPost]
        [ActionName("insertexercise")]
        public IHttpActionResult InsertExercise([FromBody]Trainingsexercise trainingsexercise)
        {

            return Ok(trainingService.InsertExercise(trainingsexercise, trainingsexercise.Owner));
        }

        [HttpGet]
        [ActionName("allpublictrainingsobjects")]
        public IHttpActionResult GetAllPublicTrainingsobjects()
        {
            return Ok(trainingService.GetAllPublicTrainingsObjects());
        }

        [HttpGet]
        [ActionName("allpublictrainingsexercises")]
        public IHttpActionResult GetAllPublicTrainingsExercises()
        {
            return Ok(trainingService.GetAllPublicTrainingExercises());
        }

        [HttpGet]
        [ActionName("allownertrainingsobjects")]
        public IHttpActionResult GetAllTrainingsobjectsForOwner(int userid)
        {
            return Ok(trainingService.GetAllTrainingsObjectsForOwner(userid));
        }

        [HttpGet]
        [ActionName("allownertrainingsexercises")]
        public IHttpActionResult GetAllTrainingeExercisesForOwner(int userid)
        {
            return Ok(trainingService.GetAllTrainingsExercisesForOwner(userid));
        }

    }
}