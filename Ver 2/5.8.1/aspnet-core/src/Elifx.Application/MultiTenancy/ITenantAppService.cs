using Abp.Application.Services;
using Elifx.MultiTenancy.Dto;

namespace Elifx.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

