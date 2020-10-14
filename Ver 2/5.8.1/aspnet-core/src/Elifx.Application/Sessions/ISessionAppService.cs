using System.Threading.Tasks;
using Abp.Application.Services;
using Elifx.Sessions.Dto;

namespace Elifx.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
