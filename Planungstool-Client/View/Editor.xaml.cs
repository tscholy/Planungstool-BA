﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Planungstool_Client.View
{
    /// <summary>
    /// Interaktionslogik für Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        public Editor(User currentUser)
        {
            InitializeComponent();
            Library library = new Library(currentUser);
            libTabItem.Content = library;
        }
    }
}