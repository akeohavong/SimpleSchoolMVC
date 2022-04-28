using Microsoft.AspNetCore.Mvc;
using SimpleSchool.Core.Entities;
using SimpleSchool.Core.Interfaces;
using System;

namespace SimpleSchool.Mvc.Controllers
{
    public class RoomController : Controller
    {
        private IBuildingRepository _buildingRepository;
        private IRoomRepository _roomRepository;

        public RoomController(IBuildingRepository buildingRepository, IRoomRepository roomRepository)
        {
            _buildingRepository = buildingRepository;
            _roomRepository = roomRepository;
        }

 

        [Route("rooms/{id}")]
        [HttpGet]
        public IActionResult Get(int id)
        {

            var result = _roomRepository.Get(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
        }

        [Route("rooms/add")]
        [HttpGet]
        public IActionResult Add()
        {
            var model = new Room();
            return View(model);
        }

        [Route("rooms/add")]
        [HttpPost]
        public IActionResult Add(Room model)
        {
            
            var result = _roomRepository.Add(model);
           
            if (result.Success)
            {
                return RedirectToAction("GetRooms", "Building", new {id = model.BuildingID});
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
        }

        [Route("rooms/edit/{id}")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var result = _roomRepository.Get(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
        }

        [Route("rooms/edit/{id}")]
        [HttpPost]
        public IActionResult Edit(Room model)
        {
            var result = _roomRepository.Edit(model);
            if (result.Success)
            {
                return RedirectToAction("GetRooms", "Building", new { id = model.BuildingID });
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
            
        }

        [Route("rooms/remove/{id}")]
        [HttpGet]
        public IActionResult Remove(int id)
        {
            var result = _roomRepository.Get(id);
            if (result.Success)
            {
                return View(result.Data);
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
        }

        [Route("rooms/remove/{id}")]
        [HttpPost]
        public IActionResult Remove(Room model)
        {
            var result = _roomRepository.Delete(model.RoomID);
            if (result.Success)
            {
                return RedirectToAction("GetRooms", "Building", new { id = model.BuildingID });
            }
            else
            {
                throw new Exception(result.Messages[0]);
            }
        }

        
    }
}
