using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IReckonu.DataImportingTool.Application.Abstractions;
using IReckonu.DataImportingTool.BackgroundJobs.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions;
using IReckonu.DataImportingTool.Data.Abstractions.File;
using IReckonu.DataImportingTool.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace IReckonu.DataImportingTool.API
{
    [Route("api/[controller]")]
    public class DataImportController : Controller
    {
        private readonly IDataImportApplicationService _dataImportApplicationService;

        public DataImportController(IDataImportApplicationService dataImportApplicationService)
        {
            _dataImportApplicationService = dataImportApplicationService;
        }
       
         [HttpPost("ImportDataFromFile")]
         [ProducesResponseType((int)HttpStatusCode.OK)]
         [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> ImportDataFromFile(IFormFile file)
        {
            if (file != null)
            {
                // Validation On the file
                _dataImportApplicationService.ImportData(file.OpenReadStream());
                return Ok();
            }
            else 
            {
                return BadRequest();
            }
        }

    }
}
