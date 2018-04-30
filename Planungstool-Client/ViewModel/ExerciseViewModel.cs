using Models;
using Planungstool_Client.WebService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planungstool_Client.ViewModel
{
    public class ExerciseViewModel : BindableBase
    {
        private List<Trainingsobject> currentTrainObjects;
        private Bitmap currentField;
        private TrainingRestClient trainingRestClient;

        public ExerciseViewModel(User user)
        {
            trainingRestClient = new TrainingRestClient(user.Id);
            CurrentField = new Bitmap(Properties.Resources.soccer);
            CurrentTrainObjects = trainingRestClient.GetAllTrainingsobjectsForUser(user.Id);
        }

        public List<Trainingsobject> CurrentTrainObjects
        {
            get
            {
                return currentTrainObjects;
            }
            set
            {
                SetProperty(ref currentTrainObjects, value);
            }
        }

        public Bitmap CurrentField
        {
            get
            {
                return currentField;
            }
            set
            {
                SetProperty(ref currentField, value);
            }
        }
    }
}
