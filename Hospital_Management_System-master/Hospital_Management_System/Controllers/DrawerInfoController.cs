using HMS.Models;
using HMS.Repository.Interface;
using Hospital_Management_System.Helpers;
//using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrawerInfoController : ControllerBase
    {
        private readonly IDrawerInfoRepo _drawerInfoRepo;

        public DrawerInfoController(IDrawerInfoRepo drawerInfoRepo)
        {
            _drawerInfoRepo = drawerInfoRepo;
        }
        [HttpGet]
        [Route("GetDrawerInfo")]
        public IActionResult GetDrawerInfo()
        {
            try
            {
                var drawerInfo = _drawerInfoRepo.GetDrawerInfo().ToList();
                return Ok(drawerInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("GetDrawerInfoById/{id}")]
        public IActionResult GetDrawerInfoById(int id)
        {
            try
            {
                DrawerInfo drawerInfo = _drawerInfoRepo.GetDrawerInfoById(id);
                if (drawerInfo == null)
                {
                    return NotFound($"DrawerInfo with ID {id} not found.");
                }
                return Ok(drawerInfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("Insert")]
        public async Task<IActionResult> PostDrawerInfo([FromForm]DrawerInfoHelper drawerInfoHelper)
        {
            try
            {
                DrawerInfo drawerInfoToSave = drawerInfoHelper.GetDrawerInfo();
                _drawerInfoRepo.SaveDrawerInfo(drawerInfoToSave);
                return Ok(drawerInfoToSave);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("Update/{id}")]
        public async Task<IActionResult> PutDrawerInfo(int id, [FromForm] DrawerInfoHelper drawerInfoHelper)
        {
            try
            {
                DrawerInfo existingDrawerIfo = _drawerInfoRepo.GetDrawerInfoById(id);
                if (existingDrawerIfo == null)
                {
                    return NotFound($"DrawerInfo with ID {id} not found.");
                }

                existingDrawerIfo.DrawerInfoID = drawerInfoHelper.DrawerInfoID;
                existingDrawerIfo.ReceivedDate = drawerInfoHelper.ReceivedDate;
                existingDrawerIfo.ReleaseDate = drawerInfoHelper.ReleaseDate;
                existingDrawerIfo.IsPatient = drawerInfoHelper.IsPatient;
                existingDrawerIfo.DrawerID = drawerInfoHelper.DrawerID;
                existingDrawerIfo.PatientID = drawerInfoHelper.PatientID;
                existingDrawerIfo.UnidentifiedDeadBodyID = drawerInfoHelper?.UnidentifiedDeadBodyID;

                _drawerInfoRepo.SaveDrawerInfo(existingDrawerIfo);
                return Ok(existingDrawerIfo);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult DeleteDrawerInfo(int id)
        {
            try
            {
                DrawerInfo existingDrawerIfo = _drawerInfoRepo.GetDrawerInfoById(id);
                if (existingDrawerIfo == null)
                {
                    return NotFound($"DrawerInfo with ID {id} not found.");
                }

                return BadRequest("DrawerInfo can't be deleted. Change drawerInfo status instead.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
