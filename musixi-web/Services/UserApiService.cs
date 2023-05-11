﻿using musixi_core.DTOs;

namespace musixi_web.Services
{
    public class UserApiService
    {
        private readonly HttpClient _httpClient;

        public UserApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<UserWithRoleDto>> GetUsersWithRoleAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<List<UserWithRoleDto>>>("users/GetUsersWithRole");
            return response.Data;
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var response = await _httpClient.GetFromJsonAsync<CustomResponseDto<UserDto>>($"users/{id}");
            return response.Data;
        }

        public async Task<UserDto> SaveAsync(UserDto newUser)
        {
            var response = await _httpClient.PostAsJsonAsync("users", newUser);
            if (!response.IsSuccessStatusCode) return null;
            var responseBody = await response.Content.ReadFromJsonAsync<CustomResponseDto<UserDto>>();
            return responseBody.Data;
        }

        public async Task<bool> UpdateAsync(UserDto newUser)
        {
            var response = await _httpClient.PutAsJsonAsync("users", newUser);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"users/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
