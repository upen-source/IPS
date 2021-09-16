using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Data
{
    public class JsonFileUpdater : IFileUpdater
    {
        public async Task UpdateFileWith<TEntity>(UpdateContent<TEntity> updatedContent,
            Action<List<TEntity>, TEntity> updateMethod,
            CancellationToken cancellation)
        {
            (string fileName, IEnumerable<TEntity> entities, TEntity entity) =
                updatedContent;

            List<TEntity> convertedEntities = entities.ToList();
            updateMethod(convertedEntities, entity);
            var settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Culture          = CultureInfo.InvariantCulture,
                Formatting       = Formatting.Indented
            };
            string serializedObject = JsonConvert.SerializeObject(convertedEntities, settings);
            await File.WriteAllTextAsync(fileName, serializedObject, cancellation);
        }
    }
}
