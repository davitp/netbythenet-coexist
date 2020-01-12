using System;
using System.Collections.Generic;
using Consumer.Clients;
using Consumer.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ConsumeController : ControllerBase
{
    private SupplierClient supplierClient;
    
    public ConsumeController(SupplierClient supplierClient)
    {
        this.supplierClient = supplierClient;
    }
    
    // GET: api/Consume/count
    [Authorize(Roles = "ADMIN")]
    [HttpGet("{count}", Name = "Consume")]
    public IEnumerable<People> Consume(int count)
    {
        var token = Request.Headers["Authorization"][0].Replace("Bearer", "").Trim();
        var all = new List<People>();
        for(var i = 0; i < Math.Max(0, count); ++i)
        {
            var result = this.supplierClient.GetAll(token);

            if(result != null)
            {
                all.AddRange(result);
            }
        }

        return all;
    }
}