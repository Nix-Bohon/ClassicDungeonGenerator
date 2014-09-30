using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ClassicDungeonGenerator.Models
{
    [Serializable()]
    [System.Xml.Serialization.XmlInclude(typeof(Doorway))]
    [System.Xml.Serialization.XmlInclude(typeof(Room))]
    public class DungeonLevel
    {
        public ObservableCollection<DungeonComponent> Components = new ObservableCollection<DungeonComponent>();
        public bool Collision(DungeonComponent component)
        {
            if (Components.Count > 40)
                return true;
            foreach (DungeonComponent d in Components)
            {
                if (d.Collision(component)) { return true; }
            }
            return false;
        }

        public bool Add(IEnumerable<DungeonComponent> components)
        {
            foreach (DungeonComponent c in components )
            {
                if (Collision(c)) 
                { 
                    return false; 
                }
            }
            Components.Concat(components);
            return true;
        }

        public bool Add(DungeonComponent component)
        {
            if (Collision(component))
            {
                return false;
            }
            else
            {
                Components.Add(component);
                return true;
            }
        }

        internal void Remove(DungeonComponent component)
        {
            Components.Remove(component);
        }

        public List<Doorway> GetUnexpandedDoors()
        {
            return (from c in Components
                    where c is Doorway && !((Doorway)c).connected
                    select (Doorway)c).ToList<Doorway>();
        }
    }
}
