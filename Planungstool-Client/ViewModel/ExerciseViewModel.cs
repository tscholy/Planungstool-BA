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
        private List<Trainingsunit> currentTrainUnits;
        private List<Trainingsobject> currentFields;

        private Bitmap currentField;
        private TrainingRestClient trainingRestClient;
        private User currentUser;

        public ExerciseViewModel(User user)
        {
            currentUser = user;
            trainingRestClient = new TrainingRestClient(user.Id);
            CurrentField = new Bitmap(Properties.Resources.soccer);
            Refresh();
        }

        public List<Trainingsobject> CurrentTrainObjects
        {
            get
            {
                return currentTrainObjects;
            }
            set
            {
                if(value != null)
                {
                    SetProperty(ref currentTrainObjects, value);
                }
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

        public List<Trainingsunit> CurrentTrainUnits
        {
            get
            {
                return currentTrainUnits;
            }
            set
            {
                SetProperty(ref currentTrainUnits, value);
            }
        }

        public List<Trainingsobject> CurrentFields
        {
            get
            {
                return currentFields;
            }
            set
            {
                SetProperty(ref currentFields, value);
            }
        }

        internal void Refresh()
        {
            List<Trainingsobject> objects = trainingRestClient.GetAllTrainingsobjectsForUser(currentUser.Id);
            CurrentTrainUnits = trainingRestClient.GetAllTrainingsUnitForOwner(currentUser.Id);
            CurrentFields = objects.Where(x => x.Type == Enums.UploadType.Field).ToList();
            CurrentTrainObjects = objects.Where(x => x.Type == Enums.UploadType.Object).ToList();
        }
    }
}
