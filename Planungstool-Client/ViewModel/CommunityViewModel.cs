using Models;
using Planungstool_Client.WebService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Planungstool_Client.ViewModel
{
    public class CommunityViewModel : BindableBase
    {
        private List<Trainingsobject> currentPublicTrainingsobjects;
        private List<Trainingsexercise> currentPublicTrainingsexercises;
        private List<Trainingsunit> currentPublicTrainingsUnits;

        private Trainingsobject selectedTrainObject;
        private Trainingsexercise selectedTrainExercise;

        private TrainingRestClient trainingRestClient;

        private User currentUser;

        public CommunityViewModel(User user)
        {
            currentUser = user;
            selectedTrainExercise = new Trainingsexercise();
            SelectedTrainObject = new Trainingsobject();
            trainingRestClient = new TrainingRestClient(user.Id);
            Refresh();

        }

        public List<Trainingsobject> CurrentPublicTrainingsobjects
        {
            get
            {
                return currentPublicTrainingsobjects;
            }
            set
            {
                SetProperty(ref currentPublicTrainingsobjects, value);
            }
        }

        public List<Trainingsunit> CurrentPublicTrainingsUnits
        {
            get
            {
                return currentPublicTrainingsUnits;
            }
            set
            {
                SetProperty(ref currentPublicTrainingsUnits, value);
            }
        }

        public List<Trainingsexercise> CurrentPublicTrainingsexercises
        {
            get
            {
                return currentPublicTrainingsexercises;
            }
            set
            {
                SetProperty(ref currentPublicTrainingsexercises, value);
            }
        }

        internal bool AddObjectToUser()
        {
            if(selectedTrainObject.Owner == currentUser.Id)
            {
                return false;
            }
            if(trainingRestClient.InsertUserTrainingsObject(selectedTrainObject.Id))
            {
                return true;
            } else
            {
                return false;
            }
        }

        public Trainingsobject SelectedTrainObject
        {
            get
            {
                return selectedTrainObject;
            }
            set
            {
                if(value != null)
                {
                    SetProperty(ref selectedTrainObject, value);
                }
            }
        }

        public Trainingsexercise SelectedTrainExercise
        {
            get
            {
                return selectedTrainExercise;
            }
            set
            {
                if(value != null)
                {
                    SetProperty(ref selectedTrainExercise, value);
                }
            }
        }

        internal void Refresh()
        {
            CurrentPublicTrainingsobjects = trainingRestClient.GetAllPublicTrainingsobjects();
            CurrentPublicTrainingsexercises = trainingRestClient.GetAllPublicTrainingsExercises();
            CurrentPublicTrainingsUnits = trainingRestClient.GetPublicTrainingsUnits();
            foreach (Trainingsunit unit in CurrentPublicTrainingsUnits)
            {
                unit.Exercises = trainingRestClient.GetExercisesForUnit(unit.Id);
            }
        }
    }
}
