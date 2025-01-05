using Models;
using System;
using Microsoft.Extensions.DependencyInjection;
using Services.Reflection;

namespace Services;

public interface IControlLookupService
{
    ComplianceControl GetControl(string code);
}

[TransientService]

public class ControlLookupService : IControlLookupService
{
    private readonly IServiceProvider _serviceProvider;

    public ControlLookupService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public ComplianceControl GetControl(string code)
    {
        code = code.ToUpper().Replace("-", string.Empty);
        var control = _serviceProvider.GetRequiredKeyedService<ComplianceControl>(code);

        return control;
    }
}
