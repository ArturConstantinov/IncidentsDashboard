using Incidents.Domain.Entities;

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
            IsDeleted = false
        };

        public static readonly User User = new User
        {
            Id = 2,
            UserName = "cr00002",
            Password = "04f8996da763b7a969b1028ee3007569eaf3a635486ddab211d512c85b9df8fb",
            FullName = "User",
            Email = "user@mail.com",
            IsEnabled = true,
            IsDeleted = false
        };
        #endregion

        #region UserRole
        public static readonly UserRole RoleAdmin = new UserRole { UserId = Admin.Id, RoleId = AdminRole.Id };
        public static readonly UserRole RoleUser = new UserRole { UserId = User.Id, RoleId = UserRole.Id };
        //public static readonly UserRole RoleAdmin3 = new UserRole { UserId = Admin.Id, RoleId = UserRole.Id };
        #endregion

        //#region Origin
        //public static readonly Origin Aplication = new Origin { Id = 1, Name = "Application" };
        //public static readonly Origin External = new Origin { Id = 2, Name = "External" };
        //public static readonly Origin Infrastructure = new Origin { Id = 3, Name = "Infrastructure" };
        //#endregion

        //#region Ambit
        //public static readonly Ambit Software = new Ambit { Id = 1, Name = "Software", OriginId = 1 };
        //public static readonly Ambit Functionality = new Ambit { Id = 2, Name = "Functionality", OriginId = 2 };
        //public static readonly Ambit Service = new Ambit { Id = 3, Name = "Service", OriginId = 2 };
        //public static readonly Ambit HostHardware = new Ambit { Id = 4, Name = "Host hardware", OriginId = 3 };
        //public static readonly Ambit Middleware = new Ambit { Id = 5, Name = "Middleware", OriginId = 3 };
        //#endregion

        //#region IncidentType
        //public static readonly IncidentType Type1 = new IncidentType { Id = 1, Name = "Third parts", AmbitId = 1 };
        //public static readonly IncidentType Type2 = new IncidentType { Id = 2, Name = "Resource saturation", AmbitId = 4 };
        //public static readonly IncidentType Type3 = new IncidentType { Id = 3, Name = "Not enough resources", AmbitId = 5 };
        //#endregion

        //#region Scenary
        //public static readonly Scenary Scenary = new Scenary { Id = 1, Name = "Scenary Name" };
        //#endregion

        //#region Threat
        //public static readonly Threat Threat = new Threat { Id = 1, Name = "Threat Name" };
        //#endregion

        #region Incident
        public static readonly Incident Incident = new Incident { 
            Id = 1,
            RequestNr = "host00007415837",
            Subsystem = "cr",
            Type = "Request Intervention",
            ApplicationType = "Application Type",
            Urgency = "Hight",
            SubCause = "definition change",
            ProblemSummery = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
            ProblemDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
            Solution = "Lorem Ipsum is simply dummy text of the printing and typesetting industry."

        };
        #endregion
    }
}
