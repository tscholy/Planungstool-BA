using Models;
using Planungstool_Client.WebService;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Planungstool_Client.ViewModel
{
    public class LibraryViewModel : BindableBase
    {
        private List<Trainingsobject> currentTrainingsobjects;
        private List<Trainingsexercise> currentTrainingsexercises;
        private List<Trainingsunit> currentTrainingsUnits;

        private UserControl newUploadObjectControl;
        private User currentUser;
        private TrainingRestClient trainingRestClient;

        public LibraryViewModel(User currentUser)
        {
            trainingRestClient = new TrainingRestClient(currentUser.Id);
            this.currentUser = currentUser;
            Refresh();
        }

        public List<Trainingsobject> CurrentTrainingsobjects
        {
            get => currentTrainingsobjects;
            set
            {
                SetProperty(ref currentTrainingsobjects, value);
            }
            
        }


        public List<Trainingsexercise> CurrentTrainingsexercises
        {
            get
            {
                return currentTrainingsexercises;
            }
            set
            {
                SetProperty(ref currentTrainingsexercises, value);
            }
        }

        public List<Trainingsunit> CurrentTrainingsUnits
        {
            get
            {
                return currentTrainingsUnits;
            }
            set
            {
                SetProperty(ref currentTrainingsUnits, value);
            }
        }

        public UserControl NewUploadObjectControl
        {
            get => newUploadObjectControl;
            set
            {
                SetProperty(ref newUploadObjectControl, value);
            }

        }

        internal void Refresh()
        {
            CurrentTrainingsobjects = trainingRestClient.GetAllTrainingsobjectsForOwner(currentUser.Id);
            CurrentTrainingsexercises = trainingRestClient.GetAllTrainingsExercisesForOwner(currentUser.Id);
            CurrentTrainingsUnits = trainingRestClient.GetAllTrainingsUnitForOwner(currentUser.Id);
            foreach(Trainingsunit unit in CurrentTrainingsUnits)
            {
                unit.Exercises = trainingRestClient.GetExercisesForUnit(unit.Id);
            }
        }
    }


}
