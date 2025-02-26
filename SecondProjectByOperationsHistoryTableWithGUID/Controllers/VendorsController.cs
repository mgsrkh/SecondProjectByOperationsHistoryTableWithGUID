﻿using Microsoft.AspNetCore.Mvc;
using SecondProjectByOperationsHistoryTableWithGUID.ApplicationServices.IServices;
using SecondProjectByOperationsHistoryTableWithGUID.DTOs.Vendors;
using System;
using System.Threading.Tasks;

namespace SecondProjectByOperationsHistoryTableWithGUID.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorsController : ControllerBase
    {
        private readonly IVendorService _vendorService;

        public VendorsController(IVendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVendorByIdAsync([FromRoute] string id)
        {
            var vendorGetByIdResponse = await _vendorService.GetVendorByIdAsync(id);
            return Ok(vendorGetByIdResponse);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVendorByIdAsync([FromRoute] string id)
        {
            var vendorDeleted = await _vendorService.DeleteVendorByIdAsync(id);
            if (vendorDeleted)
            {
                string deleteVendorResponse = $"The Vendor By The Id = {id} was Deleted Successfully !";

                return Ok(deleteVendorResponse);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVendorAsync([FromRoute] string id, VendorUpdateDTO DTO)
        {
            var vendorUpdate = await _vendorService.UpdateVendorAsync(DTO, id);
            if (vendorUpdate > 0) 
            {
                string updateVendorResponse = $"The Vendor By The Id = {id} was Updated Successfully !";

                return Ok(updateVendorResponse);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public async Task<IActionResult> InsertVendorAsync([FromBody] VendorInsertDTO dto)
        {
            var insertVendorResponse = await _vendorService.InsertVendorAsync(dto);

            return Created(new Uri($"/api/Vendors/{insertVendorResponse.Id}", UriKind.Relative), insertVendorResponse);
        }
    }
}
