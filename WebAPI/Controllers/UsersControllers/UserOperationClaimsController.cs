﻿using Business.Abstract.UserService;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers.UsersControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserOperationClaimsController : ControllerBase
    {
        IUserOperationClaimService _userOperationClaimService;
        public UserOperationClaimsController(IUserOperationClaimService userOperationClaimService)
        {
            _userOperationClaimService = userOperationClaimService;
        }

        [HttpPost("add")]
        public IActionResult Add(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Add(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("delete")]
        public IActionResult Delete(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Delete(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("update")]
        public IActionResult Update(UserOperationClaim userOperationClaim)
        {
            var result = _userOperationClaimService.Update(userOperationClaim);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userOperationClaimService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyuseroperationclaim")]
        public IActionResult GetByUserOperationClaim(int userOperationClaimId)
        {
            var result = _userOperationClaimService.GetByUserOperationClaim(userOperationClaimId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyoperationclaim")]
        public IActionResult GetByOperationClaim(int operationClaimId)
        {
            var result = _userOperationClaimService.GetByUserOperationClaim(operationClaimId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
