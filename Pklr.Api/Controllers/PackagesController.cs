using Microsoft.AspNetCore.Mvc;
using Pklr.Api.Integrations.FileStore;

namespace Pklr.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PackagesController
{
    private readonly IFileStore _fileStore;
    
    public PackagesController(IFileStore fileStore)
    {
        _fileStore = fileStore;
    }
    
    [HttpGet]
    public async Task<ScopesListResponse> ListPackages()
    {
        throw new NotImplementedException();
    }
    
    [HttpGet("{scopeId}")]
    public async Task<GetScopeResponse> GetPackage(string scopeId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<> SavePackage()
    {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{scopeId}")]
    public async Task<> DeletePackage()
    {
        throw new NotImplementedException();
    }
    
    [HttpPost]
    public async Task<IActionResult> UploadPackageVersion(CancellationToken cancellationToken = default)
    {
        var uploadUrl = await _fileStore.GeneratePreSignedUploadUrlForPkgZip(scope, packageName, version);
    }
}