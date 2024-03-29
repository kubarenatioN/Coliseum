﻿using System;
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

namespace Kursach.Controls
{
    /// <summary>
    /// Логика взаимодействия для TeamItemControl.xaml
    /// </summary>
    public partial class TeamItemControl : UserControl
    {
        public TeamItemControl(Team team)
        {
            InitializeComponent();

            DataContext = new TeamItemViewModel(team);
        }
    }
}
