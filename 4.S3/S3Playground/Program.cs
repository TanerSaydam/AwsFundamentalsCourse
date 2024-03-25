using Amazon.S3;
using Amazon.S3.Model;

var s3Client = new AmazonS3Client();

using var inputStream = new FileStream("C:/Test/AwsFundamentalsCourse/4.S3/S3Playground/1-02.jpg", FileMode.Open, FileAccess.Read);

var putObjectRequest = new PutObjectRequest
{
    BucketName = "tsfilesystem",
    Key = "images/logo.jpg",
    ContentType = "image/jpeg", //mime type
    InputStream = inputStream
};

await s3Client.PutObjectAsync(putObjectRequest);