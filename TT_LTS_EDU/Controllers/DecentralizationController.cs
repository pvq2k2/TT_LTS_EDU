﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using QuanLyTrungTam_API.Helper;
using TT_LTS_EDU.Handle.Request.DecentralizationRequest;
using TT_LTS_EDU.Services.Interface;

namespace TT_LTS_EDU.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class DecentralizationController : ControllerBase
    {
        private readonly IDecentralizationService _iDecentralizationService;

        public DecentralizationController(IDecentralizationService iDecentralizationService)
        {
            _iDecentralizationService = iDecentralizationService;
        }

        [HttpPost("GetAllDecentralization")]
        public async Task<IActionResult> GetAllDecentralization(Pagination pagination)
        {
            return Ok(await _iDecentralizationService.GetAllDecentralization(pagination));
        }

        [HttpGet("GetDecentralizationByID")]
        public async Task<IActionResult> GetDecentralizationByID(int decentralizationID)
        {
            return Ok(await _iDecentralizationService.GetDecentralizationByID(decentralizationID));
        }

        [HttpPost("CreateDecentralization")]
        public async Task<IActionResult> CreateDecentralization(CreateDecentralizationRequest request)
        {
            return Ok(await _iDecentralizationService.CreateDecentralization(request));
        }

        [HttpPut("UpdateDecentralization")]
        public async Task<IActionResult> UpdateDecentralization(int decentralizationID, UpdateDecentralizationRequest request)
        {
            return Ok(await _iDecentralizationService.UpdateDecentralization(decentralizationID, request));
        }

        [HttpDelete("RemoveDecentralization")]
        public async Task<IActionResult> RemoveDecentralization(int decentralizationID)
        {
            return Ok(await _iDecentralizationService.RemoveDecentralization(decentralizationID));
        }
    }
}
