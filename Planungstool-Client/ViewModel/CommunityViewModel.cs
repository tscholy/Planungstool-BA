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
        private Trainingsobject selectedTrainObject;
        private TrainingRestClient trainingRestClient;

        public CommunityViewModel(User user)
        {
            trainingRestClient = new TrainingRestClient(user.Id);
            CurrentPublicTrainingsobjects = trainingRestClient.GetAllPublicTrainingsobjects();

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

        public Trainingsobject SelectedTrainObject
        {
            get
            {
                return selectedTrainObject;
            }
            set
            {
                SetProperty(ref selectedTrainObject, value);
            }
        }
    }
}
