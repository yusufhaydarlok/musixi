using musixi_core.DTOs;

namespace musixi_web.Services
{
    public class RoleApiService
    {
        private readonly HttpClient _httpClient;

        public RoleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<RoleDto>> GetAllAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<RoleDto>>>("roles");
            return response.Data;
        }
    }
}