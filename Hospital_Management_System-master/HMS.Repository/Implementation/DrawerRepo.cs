using HMS.DAL.Generic_Interface;
using HMS.Models;
using HMS.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Repository.Implementation
{
    public class DrawerRepo : IDrawerRepo
    {
        private readonly IGenericRepo<Drawer> _drawerRepo;

        public DrawerRepo(IGenericRepo<Drawer> drawerRepo)
        {
            this._drawerRepo = drawerRepo;
        }
        public IEnumerable<Drawer> GetDrawers()
        {
            try
            {
                return _drawerRepo.FindAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public Drawer GetDrawerById(int id)
        {
            try
            {
                return _drawerRepo.FindByCondition(x => x.DrawerID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void SaveDrawer(Drawer drawer)
        {
            try
            {
                if (drawer.DrawerID > 0)
                {
                    if (drawer == null)
                    {
                        Drawer existingDrawer = _drawerRepo.FindByCondition(x => x.DrawerID == drawer.DrawerID).FirstOrDefault();
                        drawer = existingDrawer;
                    }
                    _drawerRepo.Update(drawer);
                }
                else
                {
                    _drawerRepo.Create(drawer);
                }
                _drawerRepo.Commit();
            }
            catch (Exception)
            {

                throw;
            }
        }
        public void DeleteDrawer(int id)
        {
            _drawerRepo.Delete(id);
            _drawerRepo.Commit();
        }
    }
}
