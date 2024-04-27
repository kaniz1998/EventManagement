using HMS.DAL.Data;
using HMS.Models;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawersController : ControllerBase
    {
        private readonly IDrawerRepo _drawerRepo;

        public DrawersController(IDrawerRepo _drawerRepo)
        {
            this._drawerRepo = _drawerRepo;
        }
        [HttpGet]
        [Route("GetDrawer")]
        public IActionResult GetDrawer()
        {
            try
            {
                var drawers = _drawerRepo.GetDrawers().ToList();
                return Ok(drawers);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetDrawerById/{id}")]
        public IActionResult GetDrawerById(int id)
        {
            try
            {
                Drawer drawer = _drawerRepo.GetDrawerById(id);
                if (drawer == null)
                {
                    return NotFound($"Drawer with ID {id} not found.");
                }
                return Ok(drawer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostDrawer([FromForm] DrawerHelper drawerHelper)
        {
            try
            {
                Drawer drawerToSave = drawerHelper.GetDrawer();
                _drawerRepo.SaveDrawer(drawerToSave);
                return Ok(drawerToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutDrawer(int id, [FromForm] DrawerHelper drawerHelper)
        {
            try
            {
                Drawer existingDrawer = _drawerRepo.GetDrawerById(id);
                if (existingDrawer == null)
                {
                    return NotFound($"Drawer with ID {id} not found.");
                }

                existingDrawer.DrawerID = drawerHelper.DrawerID;
                existingDrawer.DrawerNo = drawerHelper.DrawerNo;
                existingDrawer.DrawerCondition = drawerHelper.DrawerCondition;
                existingDrawer.IsOccupied = drawerHelper.IsOccupied;
                //existingDrawer.DeceasedName = drawerHelper.DeceasedName;
                //existingDrawer.IsPatient = drawerHelper.IsPatient;
                //existingDrawer.PatientID = drawerHelper.PatientID;
                //existingDrawer.DateOfDeath = drawerHelper.DateOfDeath;
                existingDrawer.MorgueID = drawerHelper.MorgueID;

                _drawerRepo.SaveDrawer(existingDrawer);
                return Ok(existingDrawer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteDrawer(int id)
        {
            try
            {
                Drawer existingDrawer = _drawerRepo.GetDrawerById(id);
                if (existingDrawer == null)
                {
                    return NotFound($"Drawer with ID {id} not found.");
                }

                return BadRequest("Drawer can't be deleted. Change drawer status instead.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
