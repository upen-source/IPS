using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Logic;
using Microsoft.Extensions.Hosting;

namespace Presentation
{
    public class ConsoleApp : IHostedService
    {
        private readonly ModeratorPaymentService _service;

        public ConsoleApp(ModeratorPaymentService service)
        {
            _service = service;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Hello world");
            var patient = new Patient("123", 100);
            ModeratorFeePayment payment = new ContributoryPayment
            {
                Id           = "123",
                ServicePrice = 10,
                Patient      = patient,
                Date         = DateTime.Now
            };
            await _service.Save(payment, cancellationToken);
            /*(await _service.GetAll(cancellationToken)).ToList()
                .ForEach(Console.WriteLine);*/
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
