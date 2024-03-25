using Amazon.S3;
using Amazon.S3.Model;

namespace Customers.WebAPI.Repositories;

public class CustomerService(IAmazonS3 s3)
{
    private readonly string bucketName = "tsfilesystem";
    public async Task<PutObjectResponse> UploadImageAsync(Guid id, IFormFile file)
    {
        var putObjectRequest = new PutObjectRequest
        {
            BucketName = bucketName,
            Key = $"images/{id}",
            ContentType = file.ContentType,
            InputStream = file.OpenReadStream(),
            Metadata =
            {
                ["x-amz-mete-originalname"] = file.FileName,
                ["x-amz-mete-extension"] = Path.GetExtension(file.FileName)
            }
        };

        return await s3.PutObjectAsync(putObjectRequest);
    }

    public async Task<GetObjectResponse> GetImageAsync(Guid id)
    {
        var getObjectRequest = new GetObjectRequest
        {
            BucketName = bucketName,
            Key = $"images/{id}"
        };

        return await s3.GetObjectAsync(getObjectRequest);
    }

    public async Task<DeleteObjectResponse> DeleteImageAsync(Guid id)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = bucketName,
            Key = $"images/{id}"
        };

        return await s3.DeleteObjectAsync(deleteObjectRequest);
    }
}
