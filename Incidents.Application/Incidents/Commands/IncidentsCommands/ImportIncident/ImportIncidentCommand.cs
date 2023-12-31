﻿using CsvHelper;
using Incidents.Application.Common.Interfaces;
using Incidents.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Incidents.Application.Incidents.Commands.IncidentsCommands.ImportIncident
{
    public class ImportIncidentCommand : IRequest<int>
    {
        public string FilePath { get; set; }
    }

    public class ImportIncidentCommandHandler : IRequestHandler<ImportIncidentCommand, int>
    {
        private readonly IIncidentsDbContext _context;
        private readonly ICurrentUserService _currentUserService;

        public ImportIncidentCommandHandler(IIncidentsDbContext context, ICurrentUserService currentUserService)
        {
            _context = context;
            _currentUserService = currentUserService;
        }

        public async Task<int> Handle(ImportIncidentCommand request, CancellationToken cancellationToken)
        {
            var errors = new List<string>();
            using(var reader = new StreamReader(request.FilePath))
            using(var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<ImportIncidentVm>();
                
                foreach(var record in records)
                {
                    var validator = new ImportIncidentVmValidator();
                    var validationResult = validator.Validate(record);

                    if (!validationResult.IsValid)
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            errors.Add(error.ErrorMessage);
                        }
                    }
                    else
                    {
                        var existingRecord = await _context.Incidents.AnyAsync(x => x.RequestNr == record.RequestNr);

                        if (existingRecord == true)
                        {
                            errors.Add(record.RequestNr + " alredy exist");
                        }
                        else
                        {
                            var incident = new Incident
                            {

                                CreatedBy = _currentUserService.UserId,
                                Created = DateTime.Now,

                                RequestNr = record.RequestNr,
                                Subsystem = record.Subsystem,
                                OpenDate = record.OpenDate,
                                Type = record.Type,
                                ApplicationType = record.ApplicationType,
                                Urgency = record.Urgency,
                                SubCause = record.SubCause,
                                ProblemSummery = record.ProblemSummery,
                                ProblemDescription = record.ProblemDescription,
                                Solution = record.Solution,
                                IncidentTypeId = _context.IncidentTypes.Where(x => x.Name == record.IncidentType).Select(x => x.Id).FirstOrDefault(),
                                AmbitId = _context.Ambits.Where(x => x.Name == record.Ambit).Select(x => x.Id).FirstOrDefault(),
                                OriginId = _context.Origins.Where(x => x.Name == record.Origin).Select(x => x.Id).FirstOrDefault(),
                                ThirdParty = record.ThirdParty,
                                ScenaryId = _context.Scenarios.Where(x => x.Name == record.Scenary).Select(x => x.Id).FirstOrDefault(),
                                ThreatId = _context.Threats.Where(x => x.Name == record.Threat).Select(x => x.Id).FirstOrDefault(),
                            };

                            await _context.Incidents.AddAsync(incident);
                        }
                    }
                }

                if (errors.Count == 0)
                {
                    return await _context.SaveChangesAsync(cancellationToken);
                }

            }

            return 0;
        }
    }
}
