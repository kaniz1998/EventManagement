using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IDrawerRepo
    {
        IEnumerable<Drawer> GetDrawers();
        Drawer GetDrawerById(int id);
        void SaveDrawer(Drawer drawer);
        void DeleteDrawer(int id);
    }
}
