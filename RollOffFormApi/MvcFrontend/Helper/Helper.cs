using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Json;
using System.Net.Http;

namespace MvcFrontend.Helper
{
    public static  class Helper
    {

       
            public static async Task<T> ReadContentAsync<T>(this HttpResponseMessage response)
            {
                if (response.IsSuccessStatusCode == false)
                    throw new ApplicationException($"Something went wrong calling the API:{response.ReasonPhrase}");

                var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var result = JsonSerializer.Deserialize<T>(
                    dataAsString, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                return result;
            }
        }

    }     


