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
using ClassicDungeonGenerator.Models;

namespace DungeonGeneratorDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private DungeonLevelViewModel ViewModel;
        public MainWindow()
        {
            InitializeComponent();
            btnGenerate.Click += btnGenerate_Click;
            btnZoomIn.Click += btnZoomIn_Click;
            btnZoomOut.Click += btnZoomOut_Click;
            btnSave.Click += btnSave_Click;
            //ViewModel = new DungeonLevelViewModel();
            //DataContext = ViewModel;
        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        void btnZoomOut_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.zoomFactor--;
            ((DungeonLevelViewModel)DataContext).zoomFactor--;
        }

        void btnZoomIn_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.zoomFactor++;
            ((DungeonLevelViewModel)DataContext).zoomFactor++;
        }

        void btnGenerate_Click(object sender, RoutedEventArgs e)
        {
            //ViewModel.GenerateLevel();
            ((DungeonLevelViewModel)DataContext).GenerateLevel();
        }
    }
}
