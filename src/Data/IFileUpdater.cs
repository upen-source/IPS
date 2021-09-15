using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Data
{
    public record UpdateContent<TEntity>(string FileName, IEnumerable<TEntity> Entities);

    public interface IFileUpdater
    {
        public Task UpdateFileWith<TEntity>(UpdateContent<TEntity> updateContent,
            Action<List<TEntity>> updateMethod,
            CancellationToken cancellation);
    }
}