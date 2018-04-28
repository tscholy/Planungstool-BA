using Models;
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

        private UserControl newUploadObjectControl;

        public LibraryViewModel()
        {
            
        }

        public List<Trainingsobject> CurrentTrainingsobjects
        {
            get => currentTrainingsobjects;
            set
            {
                SetProperty(ref currentTrainingsobjects, value);
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
    }


}
