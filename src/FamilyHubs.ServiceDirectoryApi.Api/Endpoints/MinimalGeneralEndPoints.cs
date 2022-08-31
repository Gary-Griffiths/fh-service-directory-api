﻿using System.Diagnostics;

namespace fh_service_directory_api.api.Endpoints;

public class MinimalGeneralEndPoints
{
    public void RegisterMinimalGeneralEndPoints(WebApplication app)
    {
        app.MapGet("api/info", () =>
        {
            try
            {
                var assembly = typeof(WebMarker).Assembly;

                var creationDate = File.GetCreationTime(assembly.Location);
                var version = FileVersionInfo.GetVersionInfo(assembly.Location).ProductVersion;

                return Results.Ok($"Version: {version}, Last Updated: {creationDate}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }
        });
    }
}
