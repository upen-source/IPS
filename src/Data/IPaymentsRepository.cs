using System.Threading.Tasks;
using Entities;

namespace Data
{
    public interface IPaymentsRepository : IRepository<string, ModeratorFeePayment>
    {
        public Task UpdateServicePrice(string id, double newServicePrice);
    }
}
