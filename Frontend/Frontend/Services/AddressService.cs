using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Frontend.Models;
using Newtonsoft.Json;

namespace Frontend.Services
{
    static class AddressService
    {
        static List<UserAddress> userAddresses;
        static AddressService()
        {
            userAddresses = new List<UserAddress>();
            userAddresses.Add(new UserAddress { AddressId = 1, Address = "123", City = "Gia Nghĩa", Country = "Việt Nam", District = "Hoàng Thế Thiện", Province = "Đăk Nông", UserId = 1 ,Mobile="0123456789"});
            userAddresses.Add(new UserAddress { AddressId = 2, Address = "456", City = "Thủ Đức", Country = "Việt Nam", District = "Mai Chí Thọ", Province = "Hồ Chí Minh", UserId = 1, Mobile = "0123456789" });
        }
        static async public Task<List<UserAddress>> GetAddressesByUserId(int UserId)
        {
            try
            {
                //var addresses = await Base.client.GetStringAsync("api/GetAddressesByUserId/" + UserId);
                //List<UserAddress> addressesConverted = JsonConvert.DeserializeObject<List<UserAddress>>(addresses);
                //return addressesConverted;
                return userAddresses.FindAll((e) => e.UserId == UserId);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        static async public Task UpdateAddress(UserAddress address)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(address);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //HttpResponseMessage response = await Base.client.PostAsync("api/updateAddress/" + address.AddressId, stringContent);
                //Console.WriteLine(response);
                //return response;
                userAddresses[address.AddressId - 1] = address;
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        static async public Task AddAddress(UserAddress address)
        {
            try
            {
                //var json = JsonConvert.SerializeObject(address);
                //var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); // use MediaTypeNames.Application.Json in Core 3.0+ and Standard 2.1+
                //var response = await Base.client.PostAsync("api/addAddress/"+ address.AddressId, stringContent);
                //Console.WriteLine(response);
                userAddresses.Add(address);

            }
            catch(Exception e)
            {
                throw e;
            }
        }
        static async public Task RemoveAddress(UserAddress address)
        {
            try
            {
                userAddresses.Remove(address);
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
