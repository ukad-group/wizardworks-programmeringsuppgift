using Azure;
using Azure.Storage.Blobs;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Wizardworks.Demo.Core.Config;
using Wizardworks.Demo.Core.Feature.Squares.Client;
using Wizardworks.Demo.Core.Feature.Squares.Model;

namespace Wizardworks.Demo.Core.Feature.Squares.Repository;
internal class SquaresRepository(
    BlobServiceClient blobServiceClient,
    IOptions<AppSetting> options)
    : BaseStorageClient(blobServiceClient, options.Value.Storage.ContainerName), ISquaresRepository
{
    public async Task<SquaresModel> GetByIdAsync(string clientId)
    {
        var result = await GetFromBlobAsync<SquaresModel>(clientId);

        result ??= new SquaresModel();

        return result;
    }
    public async Task<SquaresModel> AddAsync(string clientId, SquareItemModel square)
    {
        var state = await GetFromBlobAsync<SquaresModel>(clientId);
        
        state ??= new SquaresModel();

        // ensure duplicates not created 
        var colorAlreadyExists = state.Squares.Any(x => x.Color.Equals(square.Color, StringComparison.OrdinalIgnoreCase));
        if (colorAlreadyExists)
        {
            throw new Exception("Colors should not have duplicates!");
        }

        state.Squares.Add(square);

        await UploadToBlobAsync(clientId, state);

        return state;
    }
}
