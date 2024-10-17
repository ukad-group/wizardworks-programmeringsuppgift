using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Wizardworks.Demo.Core.Config;
using Wizardworks.Demo.Core.Feature.Squares.Model;

namespace Wizardworks.Demo.Core.Feature.Squares.Client;

internal class BaseStorageClient
{
    protected readonly BlobContainerClient _blobContainerClient;

    public BaseStorageClient(BlobServiceClient blobServiceClient, string containerName)
    {
        var container = blobServiceClient.GetBlobContainerClient(containerName);

        container.CreateIfNotExists();

        _blobContainerClient = container;
    }

    public async Task<T?> GetFromBlobAsync<T>(string name) where T: class, new()
    {
        var blob = _blobContainerClient.GetBlobClient(name);
        
        // check existence 
        var blobExists = await blob.ExistsAsync();
        if (blobExists.Value is false)
        {
            return default(T?);
        }

        // get content
        var content = await blob.DownloadContentAsync();
        var data = content.Value.Content;
        var blobContents = Encoding.UTF8.GetString(data);

        var result = JsonSerializer.Deserialize<T>(blobContents);
        
        return result;
    }

    public async Task UploadToBlobAsync<T>(string name, T content) where T: class, new()
    {
        var model = JsonSerializer.SerializeToUtf8Bytes(content);
        
        var memoryRequest = new MemoryStream(model);

        var blob = _blobContainerClient.GetBlobClient(name);

        // check existence 
        var blobExists = await blob.ExistsAsync();
        if (blobExists.Value is true)
        {
            await blob.DeleteAsync();
        }

        _ = await _blobContainerClient.UploadBlobAsync(name, memoryRequest);
    }
}
