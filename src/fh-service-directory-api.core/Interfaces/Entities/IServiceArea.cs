﻿namespace fh_service_directory_api.core.Interfaces.Entities
{
    public interface IServiceArea
    {
        string? Extent { get; init; }
        string? LinkId { get; init; }
        string Service_area { get; init; }
        string? Uri { get; init; }
    }
}