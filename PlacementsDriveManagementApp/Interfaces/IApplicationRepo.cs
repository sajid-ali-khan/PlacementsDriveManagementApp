﻿using PlacementsDriveManagementApp.Models;

namespace PlacementsDriveManagementApp.Interfaces
{
    public interface IApplicationRepo
    {
        ICollection<Application> GetApplications();
        Application GetApplicationById(int applicationId);

        Opening GetApplicationOpening(int applicationId);

        Student GetStudentByApplication(int applicationId);
        Resume GetApplicationResume(int applicationId);

        bool ApplicationExists(int applicationId);
        
    }
}
