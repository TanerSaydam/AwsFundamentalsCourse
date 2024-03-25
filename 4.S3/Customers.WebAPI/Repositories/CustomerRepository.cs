using Amazon.S3.Model;

namespace Customers.WebAPI.Repositories;

public class CustomerRepository
{
    public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file)
    {

    }

    public async Task<GetObjectResponse> GetImageAsync(Guid id)
    {

    }

    public async Task<DeleteObjectResponse> DeleteImageAsync(Guid id)
    {

    }
}
