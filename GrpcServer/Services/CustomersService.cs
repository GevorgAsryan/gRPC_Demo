using Grpc.Core;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomersService : Customer.CustomerBase
    {
        private readonly ILogger<CustomersService> _logger;

        public CustomersService(ILogger<CustomersService> logger)
        {
            _logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = new CustomerModel();

            if (request.UserId == 1)
            {
                output.FirstName = "Gevorg";
                output.Lastname = "Asryan";
            }
            return Task.FromResult(output);
        }

        public override async Task GetNewCustomers(NewCostomerRequest request, IServerStreamWriter<CustomerModel> responseStream, ServerCallContext context)
        {
            List<CustomerModel> customers = new List<CustomerModel>
            {
                new CustomerModel
                {
                    FirstName = "Tim",
                    Lastname = "Corey",
                    EmailAdress = "tim@iamtimcorey.com",
                    Age = 41,
                    IsAlive = true
                },
                new CustomerModel
                {
                    FirstName = "Gev",
                    Lastname = "Asru",
                    EmailAdress = "gev@iamgivi.com",
                    Age = 25,
                    IsAlive = true
                },
                new CustomerModel
                {
                    FirstName = "Seto",
                    Lastname = "Gharibyan",
                    EmailAdress = "sitros@butelozik.com",
                    Age = 41,
                    IsAlive = true
                }
            };

            foreach (var cust in customers)
            {
                await Task.Delay(2000);
                await responseStream.WriteAsync(cust);
            }
        }
    }
}
