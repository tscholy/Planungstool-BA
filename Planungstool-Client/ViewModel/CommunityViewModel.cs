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

        private Trainingsobject selectedTrainObject;
        private Trainingsexercise selectedTrainExercise;

        private TrainingRestClient trainingRestClient;

        public CommunityViewModel(User user)
        {
            selectedTrainExercise = new Trainingsexercise();
            SelectedTrainObject = new Trainingsobject();
            trainingRestClient = new TrainingRestClient(user.Id);
            CurrentPublicTrainingsobjects = trainingRestClient.GetAllPublicTrainingsobjects();
            CurrentPublicTrainingsexercises = trainingRestClient.GetAllPublicTrainingsExercises();

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
        }
    }
}
