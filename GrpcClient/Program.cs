using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {


            //var input = new HelloRequest { Name = "Gev" };

            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);

            //var reply = await client.SayHelloAsync(input);


            //Console.WriteLine(reply.Message);

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Customer.CustomerClient(channel);

            var output1 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            //var output2 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            //var output3 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            //var output4 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            //var output5 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            //var output6 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            //var output7 = await client.GetCustomerInfoAsync(new CustomerLookupModel { UserId = 1});
            Console.WriteLine(output1);
            //Console.WriteLine(output2);
            //Console.WriteLine(output3);
            //Console.WriteLine(output4);
            //Console.WriteLine(output5);
            //Console.WriteLine(output6);
            //Console.WriteLine(output7);
            
            using (var call = client.GetNewCustomers(new NewCostomerRequest()))
            {
                while (await call.ResponseStream.MoveNext(new System.Threading.CancellationToken()))
                {
                    var currentCustomer = call.ResponseStream.Current;
                    Console.WriteLine(currentCustomer);
                }
            }





            Console.ReadLine();
        }
    }
}
