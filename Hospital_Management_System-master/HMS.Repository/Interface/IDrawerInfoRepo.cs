using HMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Interface
{
    public interface IDrawerInfoRepo
    {
        IEnumerable<DrawerInfo> GetDrawerInfo();
        DrawerInfo GetDrawerInfoById(int id);
        void SaveDrawerInfo(DrawerInfo drawerInfo);
        void DeleteDrawerInfo(int id);
    }
}
