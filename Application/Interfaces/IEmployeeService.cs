﻿using Application.Contracts.Request;
using Application.Contracts.Response;

namespace Application.Interfaces
{
    public interface IEmployeeService
    {
        public Task<List<EmployeeListResponse>?> GetAllAsync();
        public Task<EmployeeResponse?> GetByIdAsync(Guid id);
        public Task<List<EmployeeListResponse>?> GetByTermAsync(string term);
        public Task<List<EmployeeResponse>?> GetAllVeterinarianAsync();
        public Task<List<EmployeeResponse>?> GetVeterinariansByDutyDateAsync(DateTime dutyDate, byte hour);
        public Task<List<EmployeeReportResponse>> ReportAsync();
        public Task<EmployeeResponse> CreateAsync(CreateEmployeeRequest request);
        public Task<EmployeeResponse> UpdateAsync(UpdateEmployeeRequest request);
        public Task DeleteAsync(Guid id);
    }
}
