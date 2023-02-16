using MvcFrontend.Helper;
using MvcFrontend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MvcFrontend.Services.Interfaces
{
    public class RollOff:IRollOff
    
        
        {
            private readonly HttpClient _client;

            public RollOff(HttpClient client)
            {
                _client = client ?? throw new ArgumentNullException(nameof(client));
            }

            public async Task<IEnumerable<MyDatum>> Find()
            {
                string BasePath = "/RollOff";
                var response = await _client.GetAsync(BasePath);

                return await response.ReadContentAsync<List<MyDatum>>();
            }
        }
    }

