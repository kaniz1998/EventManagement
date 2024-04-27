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
    public class DrawerInfoRepo : IDrawerInfoRepo
    {
        private readonly IGenericRepo<DrawerInfo> _drawerInforepo;
        public DrawerInfoRepo(IGenericRepo<DrawerInfo> drawerInforepo)
        {
            this._drawerInforepo = drawerInforepo;
        }
        public IEnumerable<DrawerInfo> GetDrawerInfo()
        {
            try
            {
                return _drawerInforepo.FindAll();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public DrawerInfo GetDrawerInfoById(int id)
        {
            try
            {
                return _drawerInforepo.FindByCondition(x => x.DrawerInfoID == id).FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SaveDrawerInfo(DrawerInfo drawerInfo)
        {
            try
            {
                if (drawerInfo.DrawerInfoID > 0)
                {
                    DrawerInfo existingDrawerInfo = _drawerInforepo.FindByCondition(x => x.DrawerInfoID == drawerInfo.DrawerInfoID).FirstOrDefault();

                    if (existingDrawerInfo != null)
                    {
                        existingDrawerInfo.ReceivedDate = drawerInfo.ReceivedDate;
                        existingDrawerInfo.ReleaseDate = drawerInfo.ReleaseDate;
                  
                        _drawerInforepo.Update(existingDrawerInfo);
                    }
                }
                else
                {
                    _drawerInforepo.Create(drawerInfo);
                }
                _drawerInforepo.Commit();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDrawerInfo(int id)
        {
            _drawerInforepo.Delete(id);
            _drawerInforepo.Commit();
        }
    }
}