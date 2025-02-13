﻿using PlacementsDriveManagementApp.Models;

namespace PlacementsDriveManagementApp.Interfaces
{
    public interface ICompanyRepo
    {
        ICollection<Company> GetCompanies();
        Company GetCompanyById(string companyId);
        ICollection<Opening> GetCompanyOpenings(string companyId);
        bool CompanyExists(string companyId);
    }
}
