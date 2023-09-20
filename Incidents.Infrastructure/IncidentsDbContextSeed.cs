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
        public static readonly Ambit Software = new Ambit { Id = 1, Name = "Software"};
        public static readonly Ambit Functionality = new Ambit { Id = 2, Name = "Functionality" };
        public static readonly Ambit Phase = new Ambit { Id = 3, Name = "Phase" };
        public static readonly Ambit Release = new Ambit { Id = 4, Name = "Release" };
        public static readonly Ambit Service = new Ambit { Id = 5, Name = "Service" };
        public static readonly Ambit TransmissionChannels = new Ambit { Id = 6, Name = "Transmission Channels" };
        public static readonly Ambit CICS = new Ambit { Id = 7, Name = "CICS" };
        public static readonly Ambit Database = new Ambit { Id = 8, Name = "Database" };
        public static readonly Ambit HardwareHost = new Ambit { Id = 9, Name = "Hardware Host" };
        public static readonly Ambit HardwareOpen = new Ambit { Id = 10, Name = "Hardware Open" };
        public static readonly Ambit Middleware = new Ambit { Id = 11, Name = "Middleware" };
        public static readonly Ambit Networks = new Ambit { Id = 12, Name = "Networks" };
        public static readonly Ambit Security = new Ambit { Id = 13, Name = "Security" };
        public static readonly Ambit BasicHostSoftware = new Ambit { Id = 14, Name = "Basic Host Software" };
        public static readonly Ambit OpenBasicSoftware = new Ambit { Id = 15, Name = "Open Basic Software" };
        public static readonly Ambit ServiceSoftware = new Ambit { Id = 16, Name = "Service Software" };
        public static readonly Ambit Storage = new Ambit { Id = 17, Name = "Storage" };
        #endregion

        #region IncidentType
        public static readonly IncidentType Configuration = new IncidentType { Id = 1, Name = "Configuration" };
        public static readonly IncidentType SoftwareMalfunction = new IncidentType { Id = 2, Name = "Software Malfunction" };
        public static readonly IncidentType ThirdParts = new IncidentType { Id = 3, Name = "Third Parts" };
        public static readonly IncidentType IncorrectChange = new IncidentType { Id = 4, Name = "Incorrect Change" };
        public static readonly IncidentType Code = new IncidentType { Id = 5, Name = "Code" };
        public static readonly IncidentType ResourceSaturation = new IncidentType { Id = 6, Name = "Resource Saturation" };
        public static readonly IncidentType InsufficientResources = new IncidentType { Id = 7, Name = "Insufficient Resources" };
        public static readonly IncidentType HardwareMalfunction = new IncidentType { Id = 8, Name = "Hardware Malfunction" };
        public static readonly IncidentType Degradation = new IncidentType { Id = 9, Name = "Degradation" };
        public static readonly IncidentType Block = new IncidentType { Id = 10, Name = "Block" };
        public static readonly IncidentType Accesses = new IncidentType { Id = 11, Name = "Accesses" };
        public static readonly IncidentType CyberAttacks = new IncidentType { Id = 12, Name = "Cyber Attacks" };
        public static readonly IncidentType Certificates = new IncidentType { Id = 13, Name = "Certificates" };
        public static readonly IncidentType Firewall = new IncidentType { Id = 14, Name = "Firewall" };
        public static readonly IncidentType IDM = new IncidentType { Id = 15, Name = "IDM" };
        public static readonly IncidentType Patching = new IncidentType { Id = 16, Name = "Patching" };
        #endregion

        #region OriginsToAmbit
        public static readonly OriginsToAmbit OriginsToAmbit1 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Phase.Id };
        public static readonly OriginsToAmbit OriginsToAmbit2 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Functionality.Id };
        public static readonly OriginsToAmbit OriginsToAmbit3 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Release.Id };
        public static readonly OriginsToAmbit OriginsToAmbit4 = new OriginsToAmbit { OriginId = Aplication.Id, AmbitId = Software.Id };

        public static readonly OriginsToAmbit OriginsToAmbit5 = new OriginsToAmbit { OriginId = External.Id, AmbitId = Functionality.Id };
        public static readonly OriginsToAmbit OriginsToAmbit6 = new OriginsToAmbit { OriginId = External.Id, AmbitId = Service.Id };
        public static readonly OriginsToAmbit OriginsToAmbit7 = new OriginsToAmbit { OriginId = External.Id, AmbitId = Software.Id };

        public static readonly OriginsToAmbit OriginsToAmbit8 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = TransmissionChannels.Id };
        public static readonly OriginsToAmbit OriginsToAmbit9 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = CICS.Id };
        public static readonly OriginsToAmbit OriginsToAmbit10 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Database.Id };
        public static readonly OriginsToAmbit OriginsToAmbit11 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Phase.Id };
        public static readonly OriginsToAmbit OriginsToAmbit12 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = HardwareHost.Id };
        public static readonly OriginsToAmbit OriginsToAmbit13 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = HardwareOpen.Id };
        public static readonly OriginsToAmbit OriginsToAmbit14 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Middleware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit15 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Networks.Id };
        public static readonly OriginsToAmbit OriginsToAmbit16 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Security.Id };
        public static readonly OriginsToAmbit OriginsToAmbit17 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Software.Id };
        public static readonly OriginsToAmbit OriginsToAmbit18 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = BasicHostSoftware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit19 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = OpenBasicSoftware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit20 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = ServiceSoftware.Id };
        public static readonly OriginsToAmbit OriginsToAmbit21 = new OriginsToAmbit { OriginId = Infrastructure.Id, AmbitId = Storage.Id };
        #endregion

        #region AmbitsToTypes
        public static readonly AmbitsToTypes AmbitsToTypes1 = new AmbitsToTypes { AmbitId = Phase.Id, TypeId = Configuration.Id };
        public static readonly AmbitsToTypes AmbitsToTypes2 = new AmbitsToTypes { AmbitId = Phase.Id, TypeId = SoftwareMalfunction.Id };

        public static readonly AmbitsToTypes AmbitsToTypes3 = new AmbitsToTypes { AmbitId = Functionality.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes4 = new AmbitsToTypes { AmbitId = Functionality.Id, TypeId = ThirdParts.Id };

        public static readonly AmbitsToTypes AmbitsToTypes5 = new AmbitsToTypes { AmbitId = Release.Id, TypeId = IncorrectChange.Id };

        public static readonly AmbitsToTypes AmbitsToTypes6 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = IncorrectChange.Id };
        public static readonly AmbitsToTypes AmbitsToTypes7 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = Code.Id };
        public static readonly AmbitsToTypes AmbitsToTypes8 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = Configuration.Id };
        public static readonly AmbitsToTypes AmbitsToTypes9 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = ResourceSaturation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes10 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = ThirdParts.Id };
        public static readonly AmbitsToTypes AmbitsToTypes11 = new AmbitsToTypes { AmbitId = Software.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes12 = new AmbitsToTypes { AmbitId = Service.Id, TypeId = ThirdParts.Id };

        public static readonly AmbitsToTypes AmbitsToTypes13 = new AmbitsToTypes { AmbitId = TransmissionChannels.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes14 = new AmbitsToTypes { AmbitId = TransmissionChannels.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes15 = new AmbitsToTypes { AmbitId = TransmissionChannels.Id, TypeId = Configuration.Id };

        public static readonly AmbitsToTypes AmbitsToTypes16 = new AmbitsToTypes { AmbitId = CICS.Id, TypeId = HardwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes17 = new AmbitsToTypes { AmbitId = CICS.Id, TypeId = Configuration.Id };

        public static readonly AmbitsToTypes AmbitsToTypes18 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = Degradation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes19 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = HardwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes20 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes21 = new AmbitsToTypes { AmbitId = Database.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes22 = new AmbitsToTypes { AmbitId = HardwareHost.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes23 = new AmbitsToTypes { AmbitId = HardwareHost.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes24 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = IncorrectChange.Id };
        public static readonly AmbitsToTypes AmbitsToTypes25 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = Block.Id };
        public static readonly AmbitsToTypes AmbitsToTypes26 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = Degradation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes27 = new AmbitsToTypes { AmbitId = HardwareOpen.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes28 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = IncorrectChange.Id };
        public static readonly AmbitsToTypes AmbitsToTypes29 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = SoftwareMalfunction.Id };
        public static readonly AmbitsToTypes AmbitsToTypes30 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes31 = new AmbitsToTypes { AmbitId = Middleware.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes32 = new AmbitsToTypes { AmbitId = Networks.Id, TypeId = IncorrectChange.Id };

        public static readonly AmbitsToTypes AmbitsToTypes33 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Accesses.Id };
        public static readonly AmbitsToTypes AmbitsToTypes34 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = CyberAttacks.Id };
        public static readonly AmbitsToTypes AmbitsToTypes35 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Certificates.Id };
        public static readonly AmbitsToTypes AmbitsToTypes36 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Configuration.Id };
        public static readonly AmbitsToTypes AmbitsToTypes37 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Firewall.Id };
        public static readonly AmbitsToTypes AmbitsToTypes38 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = IDM.Id };
        public static readonly AmbitsToTypes AmbitsToTypes39 = new AmbitsToTypes { AmbitId = Security.Id, TypeId = Patching.Id };

        public static readonly AmbitsToTypes AmbitsToTypes40 = new AmbitsToTypes { AmbitId = BasicHostSoftware.Id, TypeId = InsufficientResources.Id };

        public static readonly AmbitsToTypes AmbitsToTypes41 = new AmbitsToTypes { AmbitId = OpenBasicSoftware.Id, TypeId = InsufficientResources.Id };
        public static readonly AmbitsToTypes AmbitsToTypes42 = new AmbitsToTypes { AmbitId = OpenBasicSoftware.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes43 = new AmbitsToTypes { AmbitId = ServiceSoftware.Id, TypeId = Block.Id };
        public static readonly AmbitsToTypes AmbitsToTypes44 = new AmbitsToTypes { AmbitId = ServiceSoftware.Id, TypeId = Degradation.Id };
        public static readonly AmbitsToTypes AmbitsToTypes45 = new AmbitsToTypes { AmbitId = ServiceSoftware.Id, TypeId = ResourceSaturation.Id };

        public static readonly AmbitsToTypes AmbitsToTypes46 = new AmbitsToTypes { AmbitId = Storage.Id, TypeId = ResourceSaturation.Id };
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

        //#region Incident
        //public static readonly Incident Incident = new Incident {
        //    //Id = 1,
        //    RequestNr = "host0000007415837",
        //    Subsystem = "cr",
        //    Type = "Request Intervention",
        //    ApplicationType = "Application Type",
        //    Urgency = "Hight",
        //    SubCause = "definition change",
        //    ProblemSummery = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
        //    ProblemDescription = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
        //    Solution = "Lorem Ipsum is simply dummy text of the printing and typesetting industry.",
        //    IncidentTypeId = 1,
        //    AmbitId = 3,
        //    OriginId = 1,
        //    ThirdParty = "AAA1",
        //    ScenaryId = 1,
        //    ThreatId = 1
        //};
        //#endregion
    }
}
