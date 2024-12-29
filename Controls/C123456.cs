using Services;
using Models;

namespace Controls;

public class C123456 : ComplianceControl
{
    public C123456(IJiraServce jiraService, IAssetService assetService)
    {
        AddChild(new C123456_01(assetService));
        AddChild(new C123456_02(jiraService));
        AddChild(new C123456_03(jiraService, assetService));
    }

    internal class C123456_03(IJiraServce jiraService, IAssetService assetService) : ComplianceCheck
    {
        public override CommandResult Execute()
        {
            var jira = jiraService.GetTicket("123456");
            var sn = assetService.GetTicket("123456");
            if (jira == null || sn == null)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "C123456_01: Failed to get ticket 123456"
                };
            }
            return new CommandResult
            {
                Success = true,
                Message = "Success"
            };

        }
    }

    internal class C123456_02(IJiraServce jiraService) : ComplianceCheck
    {
        public override CommandResult Execute()
        {
            var value = jiraService.GetTicket("123456");
            if (value == null)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "C123456_02: Failed to get ticket 123456"
                };
            }
            return new CommandResult
            {
                Success = true,
                Message = "Success"
            };
        }
    }

    internal class C123456_01(IAssetService assetService) : ComplianceCheck
    {
        public override CommandResult Execute()
        {
            var result = assetService.GetTicket("123456");
            if (result == null)
            {
                return new CommandResult
                {
                    Success = false,
                    Message = "C123456_03: Failed to get ticket 123456"
                };
            }
            return new CommandResult
            {
                Success = true,
                Message = "Success"
            };
        }
    }
}
