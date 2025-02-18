using Confluent.Kafka;

const string topic = "ote-cr.cz";

var config = new ProducerConfig
{
    // User-specific properties that you must set
    BootstrapServers = "localhost:9092",

    // Fixed properties
    Acks = Acks.All
};

using var producer = new ProducerBuilder<string, string>(config).Build();

//Get data from url https://www.ote-cr.cz/en/short-term-markets/electricity/matching-curves/@@chart-data?report_date=2025-02-14&amp;hour=1

var client = new HttpClient();

var response = await client.GetAsync("https://www.ote-cr.cz/en/short-term-markets/electricity/matching-curves/@@chart-data?report_date=2025-02-14&amp;hour=1");

var content = await response.Content.ReadAsStringAsync();

producer.Produce(topic, new Message<string, string> { Key = null, Value = content });

producer.Flush(TimeSpan.FromSeconds(10));

Console.WriteLine($"messagesddd were prssoduced to topic {topic}");
