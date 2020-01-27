using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace service0
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IHttpClientFactory _clientFactory;

        public Worker(ILogger<Worker> logger, IHttpClientFactory clientFactory)
        {
            _logger = logger;
            _clientFactory = clientFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await this.GenerateAndSendData();
                await Task.Delay(5000, stoppingToken);
            }
        }

        public async Task GenerateAndSendData()
        {

            try
            {

                var request = new HttpRequestMessage(HttpMethod.Post,
                           "http://service2/sensordata");
                request.Headers.Add("Accept", "application/json");


                var tmp = new SensorData { Location = Environment.MachineName, Value = new Random().Next(30), Timestamp = DateTime.UtcNow };
                var json = JsonSerializer.Serialize<SensorData>(tmp);
                var data = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                request.Content = data;

                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    _logger.LogInformation($"Posted from {tmp.Location} value {tmp.Value}");
                }
            }
            catch (System.Exception ex)
            {
                _logger.LogError($"Error posting from {Environment.MachineName}", ex.Message);
            }
        }
    }
}