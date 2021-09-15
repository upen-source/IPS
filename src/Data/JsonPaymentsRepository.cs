using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Microsoft.Extensions.Configuration;

namespace Data
{
    public class JsonPaymentsRepository : IPaymentsRepository
    {
        private readonly string       _filePath;
        private readonly IFileUpdater _fileUpdater;

        public JsonPaymentsRepository(IConfiguration configuration, IFileUpdater fileUpdater)
        {
            _fileUpdater = fileUpdater;
            _filePath    = configuration["Persistence:FilePath"];
        }

        public async Task Save(ModeratorFeePayment entity,
            CancellationToken cancellation)
        {
            IEnumerable<ModeratorFeePayment> entities = await GetAll(cancellation);
            var updatedContent = new UpdateContent<ModeratorFeePayment>(_filePath, entities);
            await _fileUpdater.UpdateFileWith(updatedContent, e => e.Add(entity),
                cancellation);
        }

        public async Task<IEnumerable<ModeratorFeePayment>> GetAll(CancellationToken cancellation)
        {
            if (!File.Exists(_filePath)) return new List<ModeratorFeePayment>();

            using StreamReader fileReader = File.OpenText(_filePath);
            string             content    = await fileReader.ReadToEndAsync();
            return (string.IsNullOrEmpty(content)
                ? new List<ModeratorFeePayment>()
                : JsonSerializer.Deserialize<List<ModeratorFeePayment>>(content))!;
        }

        public async Task<ModeratorFeePayment?> GetById(string id, CancellationToken cancellation)
        {
            return (await GetAll(cancellation)).FirstOrDefault(e => e.Id == id);
        }

        public Task RemoveById(string id, CancellationToken cancellation)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateServicePrice(string id, double newServicePrice)
        {
            throw new System.NotImplementedException();
        }
    }
}
