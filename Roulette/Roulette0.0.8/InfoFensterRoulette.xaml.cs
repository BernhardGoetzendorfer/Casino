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
using System.Windows.Shapes;

namespace Roulette0._0._8
{
    /// <summary>
    /// Interaktionslogik für InfoFensterRoulette.xaml
    /// </summary>
    public partial class InfoFensterRoulette : Window
    {
        public InfoFensterRoulette()
        {
            InitializeComponent();
        }

        
        private void lblPic1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
