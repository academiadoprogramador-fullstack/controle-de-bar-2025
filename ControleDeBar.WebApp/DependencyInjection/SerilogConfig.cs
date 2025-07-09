﻿using Serilog;
using Serilog.Events;

namespace ControleDeBar.WebApp.DependencyInjection;

public static class SerilogConfig
{
    public static void AddSerilogConfig(this IServiceCollection services, ILoggingBuilder logging)
    {
        var caminhoAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

        var caminhoArquivoLogs = Path.Combine(caminhoAppData, "ControleDeBar", "erro.log");

        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .WriteTo.File(caminhoArquivoLogs, LogEventLevel.Error)
            .CreateLogger();

        logging.ClearProviders();

        services.AddSerilog();
    }
}