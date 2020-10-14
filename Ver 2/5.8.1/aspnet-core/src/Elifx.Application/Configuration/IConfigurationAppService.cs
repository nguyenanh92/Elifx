using System.Threading.Tasks;
using Elifx.Configuration.Dto;

namespace Elifx.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
