using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClassicDungeonGenerator.Models 
{
    [Serializable()]
    public class DungeonComponent 
    {
        public int Height;
        public int Width;
        public int Area { get { return Height * Width; } }
        public int x;
        public int y;

        public DungeonComponent()
        {
            new DungeonComponent(0, 0, 1, 1);
        }

        public DungeonComponent(int x, int y)
        {
            new DungeonComponent(x, y, 1, 1);
        }

        public DungeonComponent(int x, int y, int Height, int Width)
        {
            this.x = x;
            this.y = y;
            this.Height = Height;
            this.Width = Width;
        }

        public bool Collision(DungeonComponent component){
            bool xCollision = (this.x > component.getXEdge() && this.getXEdge() < component.x ) || (this.x < component.getXEdge() && this.getXEdge() > component.x);
            bool yCollision = (this.y > component.getYEdge() && this.getYEdge() < component.y ) || (this.y < component.getYEdge() && this.getYEdge() > component.y);
            return xCollision && yCollision;
        }

        public int getXEdge()
        {
            return x + Width;
        }

        public int getYEdge()
        {
            return y + Height;
        }

        public void Flip()
        {
            int temp = this.Height;
            this.Height = this.Width;
            this.Width = temp;
        }

    }
}
