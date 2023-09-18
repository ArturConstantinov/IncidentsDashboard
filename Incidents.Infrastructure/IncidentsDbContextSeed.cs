using Incidents.Domain.Entities;
using System.Threading;

namespace Incidents.Infrastructure
{
    public static class IncidentsDbContextSeed
    {
        #region Roles
        public static readonly Role AdminRole = new Role { Id = 1, Name = "Administrator", Description = "User that can add, modify and disable other users, change data manually." };
        public static readonly Role OperatorRole = new Role { Id = 2, Name = "Operator", Description = "User that can import data from a CSV file." };
        public static readonly Role UserRole = new Role { Id = 3, Name = "User", Description = "User that can can view information about incidents." };
        #endregion

        #region User
        public static readonly User Admin = new User
        {
            Id = 1,
            UserName = "cr00001",
            Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
            FullName = "Admin",
            Email = "admin@mail.com",
            IsEnabled = true,
        };
        #endregion

        #region UserRole
        public static readonly UserRole RoleAdmin = new UserRole { UserId = Admin.Id, RoleId = AdminRole.Id };
        //public static readonly UserRole RoleAdmin3 = new UserRole { UserId = Admin.Id, RoleId = UserRole.Id };
        #endregion

        #region Origin
        public static readonly Origin Aplication = new Origin { Id = 1, Name = "Application" };
        public static readonly Origin External = new Origin { Id = 2, Name = "External" };
        public static readonly Origin Infrastructure = new Origin { Id = 3, Name = "Infrastructure" };
        #endregion

        #region Ambit
        public static readonly Ambit SoftwareA = new Ambit { Id = 1, Name = "Software", OriginId = 1 };
        public static readonly Ambit FunctionalityA = new Ambit { Id = 2, Name = "Functionality", OriginId = 1 };
        public static readonly Ambit PhaseA = new Ambit { Id = 3, Name = "Phase", OriginId = 1 };
        public static readonly Ambit Release = new Ambit { Id = 4, Name = "Release", OriginId = 1 };

        public static readonly Ambit Service = new Ambit { Id = 5, Name = "Service", OriginId = 2 };
        public static readonly Ambit FunctionalityE = new Ambit { Id = 6, Name = "Functionality", OriginId = 2 };
        public static readonly Ambit SoftwareE = new Ambit { Id = 7, Name = "Software", OriginId = 2 };

        public static readonly Ambit TransmissionChannels = new Ambit { Id = 8, Name = "Transmission Channels", OriginId = 3 };
        public static readonly Ambit CICS = new Ambit { Id = 9, Name = "CICS", OriginId = 3 };
        public static readonly Ambit Database = new Ambit { Id = 10, Name = "Database", OriginId = 3 };
        public static readonly Ambit PhaseI = new Ambit { Id = 11, Name = "Phase", OriginId = 3 };
        public static readonly Ambit HardwareHost = new Ambit { Id = 12, Name = "Hardware Host", OriginId = 3 };
        public static readonly Ambit HardwareOpen = new Ambit { Id = 13, Name = "Hardware Open", OriginId = 3 };
        public static readonly Ambit Middleware = new Ambit { Id = 14, Name = "Middleware", OriginId = 3 };
        public static readonly Ambit Networks = new Ambit { Id = 15, Name = "Networks", OriginId = 3 };
        public static readonly Ambit Security = new Ambit { Id = 16, Name = "Security", OriginId = 3 };
        public static readonly Ambit SoftwareI = new Ambit { Id = 17, Name = "Software", OriginId = 3 };
        public static readonly Ambit BasicHostSoftware = new Ambit { Id = 18, Name = "Basic Host Software", OriginId = 3 };
        public static readonly Ambit OpenBasicSoftware = new Ambit { Id = 19, Name = "Open Basic Software", OriginId = 3 };
        public static readonly Ambit ServiceSoftware = new Ambit { Id = 20, Name = "Service Software", OriginId = 3 };
        public static readonly Ambit Storage = new Ambit { Id = 21, Name = "Storage", OriginId = 3 };
        #endregion

        #region IncidentType
        // phase
        public static readonly IncidentType ConfigurationPhA = new IncidentType { Id = 1, Name = "Configuration", AmbitId = 3 };
        public static readonly IncidentType SoftwareMalfunctionPhA = new IncidentType { Id = 2, Name = "Software Malfunction", AmbitId = 3 };
        public static readonly IncidentType ConfigurationPhI = new IncidentType { Id = 3, Name = "Configuration", AmbitId = 11 };
        public static readonly IncidentType SoftwareMalfunctionPhI = new IncidentType { Id = 4, Name = "Software Malfunction", AmbitId = 11 };

        // functionality
        public static readonly IncidentType SoftwareMalfunctionFunA = new IncidentType { Id = 5, Name = "Software Malfunction", AmbitId = 2 };
        public static readonly IncidentType ThirdPartsFunE = new IncidentType { Id = 6, Name = "Third Parts", AmbitId = 6 };

        //release
        public static readonly IncidentType IncorrectChangeRelA = new IncidentType { Id = 7, Name = "Incorrect Change", AmbitId = 4 };

        //soft 
        public static readonly IncidentType IncorrectChangeSoftA = new IncidentType { Id = 8, Name = "Incorrect Change", AmbitId = 1 };
        public static readonly IncidentType Code = new IncidentType { Id = 9, Name = "Code", AmbitId = 1 };
        public static readonly IncidentType ConfigurationSoftA = new IncidentType { Id = 10, Name = "Configuration", AmbitId = 1 };
        public static readonly IncidentType ResourceSaturationSoftA = new IncidentType { Id = 11, Name = "Resource Saturation", AmbitId = 1 };
        public static readonly IncidentType ThirdPartsSoftE = new IncidentType { Id = 12, Name = "Third Parts", AmbitId = 7 };
        public static readonly IncidentType InsufficientResourcesSoftI = new IncidentType { Id = 13, Name = "Insufficient Resources", AmbitId = 17 };

        //service
        public static readonly IncidentType ThirdPartsServ = new IncidentType { Id = 14, Name = "Third Parts", AmbitId = 5 };

        //trans chanel 
        public static readonly IncidentType SoftwareMalfunctionTransCh = new IncidentType { Id = 15, Name = "Software Malfunction", AmbitId = 8 };
        public static readonly IncidentType InsufficientResourcesTransCh = new IncidentType { Id = 16, Name = "Insufficient Resources", AmbitId = 8 };
        public static readonly IncidentType ConfigurationTransCh = new IncidentType { Id = 17, Name = "Configuration", AmbitId = 8 };

        // CICS
        public static readonly IncidentType HardwareMalfunctionCICS = new IncidentType { Id = 18, Name = "Hardware Malfunction", AmbitId = 9 };
        public static readonly IncidentType ConfigurationCICS = new IncidentType { Id = 19, Name = "Configuration", AmbitId = 9 };

        // database
        public static readonly IncidentType DegradationDB = new IncidentType { Id = 20, Name = "Degradation", AmbitId = 10 };
        public static readonly IncidentType HardwareMalfunctionDB = new IncidentType { Id = 21, Name = "Hardware Malfunction", AmbitId = 10 };
        public static readonly IncidentType SoftwareMalfunctionDB = new IncidentType { Id = 22, Name = "Software Malfunction", AmbitId = 10 };
        public static readonly IncidentType InsufficientResourcesDB = new IncidentType { Id = 23, Name = "Insufficient Resources", AmbitId = 10 };

        // hardware host
        public static readonly IncidentType InsufficientResourcesHardHost = new IncidentType { Id = 24, Name = "Insufficient Resources", AmbitId = 12 };
        public static readonly IncidentType ResourceSaturationHardHost = new IncidentType { Id = 25, Name = "Resource Saturation", AmbitId = 12 };

        // hardware open
        public static readonly IncidentType IncorrectChangeHardOpen = new IncidentType { Id = 26, Name = "Incorrect Change", AmbitId = 13 };
        public static readonly IncidentType BlockHardOpen = new IncidentType { Id = 27, Name = "Block", AmbitId = 13 };
        public static readonly IncidentType DegradationHardOpen = new IncidentType { Id = 28, Name = "Degradation", AmbitId = 13 };
        public static readonly IncidentType InsufficientResourcesHardOpen = new IncidentType { Id = 29, Name = "Insufficient Resources", AmbitId = 13 };

        // middleware
        public static readonly IncidentType IncorrectChangeMiddl = new IncidentType { Id = 30, Name = "Incorrect Change", AmbitId = 14 };
        public static readonly IncidentType SoftwareMalfunctionMiddl = new IncidentType { Id = 31, Name = "Software Malfunction", AmbitId = 14 };
        public static readonly IncidentType InsufficientResourcesMiddl = new IncidentType { Id = 32, Name = "Insufficient Resources", AmbitId = 14 };
        public static readonly IncidentType ResourceSaturationMiddl = new IncidentType { Id = 33, Name = "Resource Saturation", AmbitId = 14 };

        // networks
        public static readonly IncidentType IncorrectChangeNet = new IncidentType { Id = 34, Name = "Incorrect Change", AmbitId = 15 };

        // security
        public static readonly IncidentType Accesses = new IncidentType { Id = 35, Name = "Accesses", AmbitId = 16 };
        public static readonly IncidentType CyberAttacks = new IncidentType { Id = 36, Name = "Cyber Attacks", AmbitId = 16 };
        public static readonly IncidentType Certificates = new IncidentType { Id = 37, Name = "Certificates", AmbitId = 16 };
        public static readonly IncidentType ConfigurationSec = new IncidentType { Id = 38, Name = "Configuration", AmbitId = 16 };
        public static readonly IncidentType Firewall = new IncidentType { Id = 39, Name = "Firewall", AmbitId = 16 };
        public static readonly IncidentType IDM = new IncidentType { Id = 40, Name = "IDM", AmbitId = 16 };
        public static readonly IncidentType Patching = new IncidentType { Id = 41, Name = "Patching", AmbitId = 16 };

        // basic host software 
        public static readonly IncidentType InsufficientResourcesBHS = new IncidentType { Id = 42, Name = "Insufficient Resources", AmbitId = 18 };

        // Open Basic Software
        public static readonly IncidentType InsufficientResourcesOBS = new IncidentType { Id = 43, Name = "Insufficient Resources", AmbitId = 19 };
        public static readonly IncidentType ResourceSaturationOBS = new IncidentType { Id = 44, Name = "Resource Saturation", AmbitId = 19 };

        // service software
        public static readonly IncidentType BlockServSoft = new IncidentType { Id = 45, Name = "Block", AmbitId = 20 };
        public static readonly IncidentType DegradationServSoft = new IncidentType { Id = 46, Name = "Degradation", AmbitId = 20 };
        public static readonly IncidentType ResourceSaturationServSoft = new IncidentType { Id = 47, Name = "Resource Saturation", AmbitId = 20 };

        //stprage
        public static readonly IncidentType ResourceSaturationStor = new IncidentType { Id = 48, Name = "Resource Saturation", AmbitId = 21 };
        #endregion

        #region Scenary
        public static readonly Scenary ScenaryA1 = new Scenary { Id = 1, Name = "A1" };
        public static readonly Scenary ScenaryA2 = new Scenary { Id = 2, Name = "A2" };
        public static readonly Scenary ScenaryA3 = new Scenary { Id = 3, Name = "A3" };
        #endregion

        #region Threat
        public static readonly Threat ThreatAA1 = new Threat { Id = 1, Name = "AA1" };
        public static readonly Threat ThreatAA2 = new Threat { Id = 2, Name = "AA2" };
        public static readonly Threat ThreatAA3 = new Threat { Id = 3, Name = "AA3" };
        #endregion

        #region Incident
        public static readonly Incident Incident = new Incident {
            Id = 1,
            RequestNr = "host0000007415837",
            Subsystem = "cr",
            Type = "Request Intervention",
            ApplicationType = "Application Type",
            Urgency = "Hight",
            SubCause = "definition change",
            ProblemSummery = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
            ProblemDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
            Solution = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
            IncidentTypeId = 1,
            AmbitId = 3,
            OriginId = 1,
            ThirdParty = "AAA1",
            ScenaryId = 1,
            ThreatId = 1
        };
        #endregion
    }
}
