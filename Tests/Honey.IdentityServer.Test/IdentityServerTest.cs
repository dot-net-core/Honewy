using IdentityModel.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Honey.IdentityServer.Test
{
    [TestClass]
    public class IdentityServerTest
    {
        [TestMethod]
        public async Task Identity_ClientCredentials_Test_Async()
        {
            // ��Ԫ�����з��ֶ˿�
            var disco = await DiscoveryClient.GetAsync("http://localhost:5003");

            // ��������
            var tokenClient = new TokenClient(disco.TokenEndpoint, "client", "secret");
            var tokenResponse = await tokenClient.RequestClientCredentialsAsync("Honey.Api");

            if (tokenResponse.IsError)
            {
                Console.WriteLine("tokenResponse.Error -- " + tokenResponse.Error);
                return;
            }

            Console.WriteLine("tokenResponse.Json -- "+tokenResponse.Json);

            // ����api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/Identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("response.StatusCode -- " + response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(" JArray.Parse(content) -- " + JArray.Parse(content));
            }
        }


        [TestMethod]
        public async Task Identity_ResourceOwnerPassword_Test_Async()
        {
            // ��Ԫ�����з��ֶ˿�
            var disco = await DiscoveryClient.GetAsync("http://localhost:5003");

            // ��������
            var tokenClient = new TokenClient(disco.TokenEndpoint, "ro.client", "secret");
            var tokenResponse = await tokenClient.RequestResourceOwnerPasswordAsync("alice", "1", "Honey.Api");//ʹ���û�������

            if (tokenResponse.IsError)
            {
                Console.WriteLine("tokenResponse.Error -- " + tokenResponse.Error);
                return;
            }

            Console.WriteLine("tokenResponse.Json -- " + tokenResponse.Json);

            // ����api
            var client = new HttpClient();
            client.SetBearerToken(tokenResponse.AccessToken);

            var response = await client.GetAsync("http://localhost:5001/api/Identity");
            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("response.StatusCode -- " + response.StatusCode);
            }
            else
            {
                var content = await response.Content.ReadAsStringAsync();
                Console.WriteLine(" JArray.Parse(content) -- " + JArray.Parse(content));
            }
        }
    }
}
