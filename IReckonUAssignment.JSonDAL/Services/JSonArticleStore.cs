using IReckonUAssignment.DAL;
using IReckonUAssignment.JSonDAL.Configuration;
using IReckonUAssignment.Models;
using Microsoft.Extensions.Options;
using Storage.Net.Blobs;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace IReckonUAssignment.JSonDAL.Services
{
    internal class JSonArticleStore : IArticleStore
    {
        private readonly IBlobStorage blobStorage;
        private readonly IOptions<JSonDALConfiguration> options;

        public JSonArticleStore(IBlobStorage blobStorage, IOptions<JSonDALConfiguration> options)
        {
            this.blobStorage = blobStorage;
            this.options = options;
        }

        public async Task StoreAsync(IEnumerable<Article> articles)
        {
            string articlesJson = JsonSerializer.Serialize(articles);
            await blobStorage.WriteTextAsync(options.Value.JsonFileName, articlesJson);
        }
    }
}