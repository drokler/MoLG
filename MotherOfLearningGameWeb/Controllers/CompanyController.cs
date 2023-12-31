﻿using Domain.Company;
using Dto.Company;
using Dto.CompanyCharacter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MotherOfLearningGameWeb.Controllers;

[ApiController]
[Route("[controller]")]
public class CompanyController : Controller
{
    private readonly ILogger<CompanyController> _logger;
    private readonly IGrainFactory _factory;

    public CompanyController(ILogger<CompanyController> logger, IGrainFactory factory)
    {
        _logger = logger;
        _factory = factory;
    }

    [Authorize(Policy = "User")]
    [HttpGet]
    public async Task<List<CompanyDto>> Get()
    {
        return await _factory.GetGrain<ICompanyAggregateGrain>(0).GetCompanies();
    }

    [Authorize(Policy = "Administrator")]
    [HttpPut]
    public async Task<CompanyDto> CreateCompany()
    {
        return await _factory.GetGrain<ICompanyAggregateGrain>(0).NewCompany();
    }

    [Authorize(Policy = "Administrator")]
    [HttpPost("companyUpdate")]
    public async Task<CompanyDto> UpdateCompany([FromBody] CompanyUpdateDto dto)
    {
        return await _factory.GetGrain<ICompanyAggregateGrain>(0).Update(dto);
    }


    [Authorize(Policy = "Administrator")]
    [HttpPost("companyCharacterAdd")]
    public async Task<IActionResult> AddCharacter([FromBody] CompanyCharacterAddDto dto)
    {
        await _factory.GetGrain<ICompanyAggregateGrain>(0).AddCharacter(dto);
        return Ok();
    }
}