using CsvHelper;
using Application.Contracts.Infrastructure;
using System.Collections.Generic;
using System.IO;
using Application.Features.Events.Queries.GetEventsExport.DTO;

namespace Infrastructure.FileExport
{
    public class CsvExporter : ICsvExporter
    {
        public byte[] ExportEventsToCsv(List<EventExportDto> eventExportDtos)
        {
            using var memoryStream = new MemoryStream();
            using (var streamWriter = new StreamWriter(memoryStream))
            {
                using var csvWriter = new CsvWriter(streamWriter, new System.Globalization.CultureInfo(1));
                csvWriter.WriteRecords(eventExportDtos);
            }

            return memoryStream.ToArray();
        }
    }
}
