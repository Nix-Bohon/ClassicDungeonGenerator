using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassicDungeonGenerator;
using ClassicDungeonGenerator.Models;
using ClassicDungeonGenerator.Factories;

namespace DungeonGeneratorDesktop
{
    class DungeonLevelViewModel : ObservableObject
    {
        private DungeonLevel Model;
        private ObservableCollection<DungeonComponentViewModel> _DrawableObjects = new ObservableCollection<DungeonComponentViewModel>();
        public ObservableCollection<DungeonComponentViewModel> DrawableObjects { get { return _DrawableObjects; } }

        public DungeonLevelViewModel()
        {
            Model = DungeonBuilder.GenerateLevel();
        }

        private int _zoomFactor = 10;
        public int zoomFactor
        {
            get
            {
                return _zoomFactor;
            }
            set
            {
                _zoomFactor = Math.Max(1,value);
                RaisePropertyChangedEvent("zoomFactor");
            }
        }

        public void GenerateLevel()
        {
            //Doorway entrance = new Doorway(0, 0, 0, 1);
            //entrance.SideIn = Side.North;
            //Model = DungeonBuilder.GenerateLevel();
            //DungeonBuilder.AddRoom(Model, entrance);
            DungeonLevelCreator c = new DungeonLevelCreator();
            Model = c.GenerateLevel();
            LoadLevel(Model);
        }
        public void LoadLevel(DungeonLevel level)
        {
            DrawableObjects.Clear();
            int xMin, xMax, yMin, yMax;
            xMin = xMax = yMin = yMax = 0;
            foreach (DungeonComponent c in Model.Components)
            {
                xMin = Math.Min(xMin, c.x);
                xMax = Math.Max(xMax, c.getXEdge());
                yMin = Math.Min(yMin, c.y);
                yMax = Math.Max(yMax, c.getYEdge());
            }
            //dungeonWidth = xMax - xMin;
            //dungeonWidth *= 10;
            //dungeonHeight = yMax - yMin;
            //dungeonHeight *= 10;
            foreach (DungeonComponent c in Model.Components)
            {
                DrawableObjects.Add(new DungeonComponentViewModel(c, xMin, yMax));
            }
        }
    }
    class DungeonComponentViewModel : ObservableObject
    {
        private DungeonComponent Model;
        private int minX;
        private int maxY;
        public DungeonComponentViewModel(DungeonComponent Model, int minX, int maxY){
            this.Model = Model;
            this.minX = minX;
            this.maxY = maxY;
        }
        public String ComponentType
        {
            get { return Model.GetType().Name; }
        }
        public int x {
            get {return (Model.x - minX);} 
            set {Model.x = value + minX; RaisePropertyChangedEvent("x");}
        }
        public int y {
            get { return maxY - Model.y - Model.Height; }
            set { Model.y = value - maxY - Model.Height; RaisePropertyChangedEvent("y"); }
        }
        public int Height {
            get {return Model.Height;} 
            set {Model.Height = value; RaisePropertyChangedEvent("Height");}
        }
        public int Width {
            get {return Model.Width;} 
            set {Model.Width = value; RaisePropertyChangedEvent("Width");}
        }
    }
}


