using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Web.Model.APP;
using Newtonsoft.Json; 

namespace Web.Repository.APP
{
    public class BaseRepository
    {
        private string _url = string.Empty;
        HttpClient _client = new HttpClient();

        public BaseRepository(string url)
        {
            _url = url;
            _client.BaseAddress = new Uri(url);
        }

        public async Task<ApiResponseObj> Get(string uri)
        {
            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ApiResponseObj>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return new ApiResponseObj()
                {
                    message = "Failed Get Data", 
                    status = false, 
                };
            }
        }

        public async Task<ApiResponseObj> Post(string uri, object formdata)
        {

			var json = JsonConvert.SerializeObject(formdata);
			var bodyEncoding = new System.Net.Http.StringContent(json.ToString(), Encoding.UTF8, "application/json");
			var response = await _client.PostAsync(uri, bodyEncoding);
            if (response.IsSuccessStatusCode)
            {
                return  JsonConvert.DeserializeObject<ApiResponseObj>(response.Content.ReadAsStringAsync().Result);
            }
            else
            {
                return new ApiResponseObj()
                {
                    message = "Failed Get Data",
                    status = false,
                };
            }
        }


    }
}
