using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Z2H_Demo_WebApiForBalanceAdjustment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BalanceController : ControllerBase
    {
        private static List<CustomerBalance> Balances = new List<CustomerBalance>
        {
            new CustomerBalance{CustomerNumber = 111, Description = "Default Data 1", Amount=10m, Date = DateTime.Now.AddDays(-1)},
            new CustomerBalance{CustomerNumber = 222, Description = "Default Data 2", Amount=20m, Date = DateTime.Now},
            new CustomerBalance{CustomerNumber = 333, Description = "Default Data 3", Amount=30m, Date = DateTime.Now.AddDays(1)},
        };

        private readonly ILogger<BalanceController> _logger;

        public BalanceController(ILogger<BalanceController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CustomerBalance> Get()
        {
            return Balances;
        }

        [HttpPost]
        public ApiResponse Post([FromBody] CustomerBalance customerBalance)
        {
            if (Balances.Exists(x => x.CustomerNumber.Equals(customerBalance.CustomerNumber)))
            {
                return new ApiResponse { IsError = true, ErrorDescription = "Already exists" };
            }
            Balances.Add(customerBalance);
            return ApiResponse.Success;
        }

        [HttpDelete]
        public ApiResponse Delete([FromBody] CustomerBalance customerBalance)
        {
            if (Balances.Exists(x => x.CustomerNumber.Equals(customerBalance.CustomerNumber)))
            {
                Balances.Remove(Balances.First(x => x.CustomerNumber.Equals(customerBalance.CustomerNumber)));
            }
            return ApiResponse.Success;
        }

        [HttpPut]
        public ApiResponse Put([FromBody] CustomerBalance customerBalance)
        {
            if (Balances.Exists(x => x.CustomerNumber.Equals(customerBalance.CustomerNumber)))
            {
                Balances.Remove(Balances.First(x => x.CustomerNumber.Equals(customerBalance.CustomerNumber)));
                Balances.Add(customerBalance);
            }
            return ApiResponse.Success;
        }
    }
}
