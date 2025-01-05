using Services;
using Models;

namespace Controls;

public class C123456 : ComplianceControl
{
    public C123456(IJiraService jiraService, IAssetService assetService) : base("C123456", "Lorem ipsum dolor sit amet, consectetur adipiscing elit")
    {
        AddChild(new C123456_01(assetService));
        AddChild(new C123456_02(jiraService));
        AddChild(new C123456_03(jiraService, assetService));
    }

    internal class C123456_03(IJiraService jiraService, IAssetService assetService) : ComplianceCheck("C123456-03", "Neque aliquam egestas ornare luctus lacus")
    {
        public override CommandResult Execute()
        {
            var jira = jiraService.GetTicket("123456");
            var sn = assetService.GetTicket("123456");
            if (jira == null || sn == null)
            {
                return new CommandResult(this)
                {
                    Success = false,
                    Message = "Failed to get ticket 123456"
                };
            }
            return new CommandResult(this)
            {
                Success = true,
                Message = "Success"
            };

        }
    }

    internal class C123456_02(IJiraService jiraService) : ComplianceCheck("C123456-02", "Massa vulputate ac metus elit lobortis egestas fermentum primis donec")
    {
        public override CommandResult Execute()
        {
            var value = jiraService.GetTicket("123456");
            if (value == null)
            {
                return new CommandResult(this)
                {
                    Success = false,
                    Message = "Failed to get ticket 123456"
                };
            }
            return new CommandResult(this)
            {
                Success = true,
                Message = "Success"
            };
        }
    }

    internal class C123456_01(IAssetService assetService) : ComplianceCheck("C123456-01", "Ultrices a nec vulputate interdum pretium interdum sit quam")
    {
        public override CommandResult Execute()
        {
            var result = assetService.GetTicket("123456");
            if (result == null)
            {
                return new CommandResult(this)
                {
                    Success = false,
                    Message = "Failed to get ticket 123456"
                };
            }
            return new CommandResult(this)
            {
                Success = true,
                Message = "Success"
            };
        }
    }
}
