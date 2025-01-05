using Models;
using Services.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services;

[TransientService]

public class EvaluatorService(IControlLookupService service)
{
    public IEnumerable<CommandResult> Evaluate(params string[] codes)
    {
        var conrols = codes.Select(code => service.GetControl(code));
        return conrols.Select(control => control.Execute());
    }
}
