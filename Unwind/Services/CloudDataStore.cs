using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Plugin.Connectivity;
using Refit;
using Unwind.Services;

namespace Unwind
{
    public class CloudDataStore : IDataStore<ConversationItem>
    {
        HttpClient client;

        public CloudDataStore()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri($"{App.BackendUrl}/");
        }

        public async Task<string> AddItemAsync(ConversationItem item)
        {
            if (item == null || !CrossConnectivity.Current.IsConnected)
                return "Sorry we are having troubble connecting to the internet, please try again";

            var api = RestService.For<IApi>(App.BackendUrl);

            var response = await api.SendMessage(item);

            return response;
        }
    }
}
