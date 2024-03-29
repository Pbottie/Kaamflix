﻿using System.Net.Http.Json;

namespace Kaamiflix.Common.Services;

public class AdminService : IAdminService
{
    MembershipHttpClient _http;
    public AdminService(MembershipHttpClient client)
    {
        _http = client;
    }
    public async Task<List<TDto>> GetAsync<TDto>(string uri)
    {
        try
        {
            using HttpResponseMessage response = await _http.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<List<TDto>>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (result == null)
                return new List<TDto>();
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }
    public async Task<TDto?> SingleAsync<TDto>(string uri)
    {
        try
        {
            using HttpResponseMessage response = await _http.Client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            var result = JsonSerializer.Deserialize<TDto>(await response.Content.ReadAsStreamAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            if (result == null)
                return default;
            return result;
        }
        catch (Exception)
        {

            throw;
        }
    }


    public async Task CreateAsync<TDto>(string uri, TDto dto)
    {
        try
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await _http.Client.PostAsync(uri, jsonContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {

            throw;
        }

    }
    
    
    public async Task EditAsync<TDto>(string uri, TDto dto)
    {
        try
        {
            using StringContent jsonContent = new(
                JsonSerializer.Serialize(dto),
                Encoding.UTF8,
                "application/json");

            using HttpResponseMessage response = await _http.Client.PutAsync(uri, jsonContent);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {

            throw;
        }
    }  
    public async Task DeleteAsync<TDto>(string uri)
    {
        try
        {            
            using HttpResponseMessage response = await _http.Client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {
            
            throw;
        }
    }


    public async Task SendAsync(HttpRequestMessage request)
    {
        try
        {
            using HttpResponseMessage response = await _http.Client.SendAsync(request);
            response.EnsureSuccessStatusCode();
        }
        catch (Exception)
        {

            throw;
        }
    }


}
