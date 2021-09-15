using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Data;
using Entities;

namespace Logic
{
    public class ModeratorPaymentService
    {
        private readonly IPaymentsRepository _repository;

        public ModeratorPaymentService(IPaymentsRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ModeratorFeePayment>> GetAll(CancellationToken cancellation)
        {
            return await _repository.GetAll(cancellation);
        }

        public async Task Save(ModeratorFeePayment entity, CancellationToken cancellation)
        {
            await _repository.Save(entity, cancellation);
        }
    }
}
