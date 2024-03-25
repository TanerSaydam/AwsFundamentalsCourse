using Amazon.S3;
using Amazon.S3.Model;
using System.Text;

var s3Client = new AmazonS3Client();
#region Upload
//using var inputStream = new FileStream("C:/Test/AwsFundamentalsCourse/4.S3/S3Playground/1-02.jpg", FileMode.Open, FileAccess.Read);

//var putObjectRequest = new PutObjectRequest
//{
//    BucketName = "tsfilesystem",
//    Key = "images/logo.jpg",
//    ContentType = "image/jpeg", //mime type
//    InputStream = inputStream
//};

//await s3Client.PutObjectAsync(putObjectRequest);
#endregion

#region Download
var getObjectRequest = new GetObjectRequest
{
    BucketName = "tsfilesystem",
    Key = "images/logo.jpg"
};
var response = await s3Client.GetObjectAsync(getObjectRequest);

using var memoryStream = new MemoryStream();
response.ResponseStream.CopyTo(memoryStream);

var text = Encoding.Default.GetString(memoryStream.ToArray());

Console.WriteLine(text);
#endregion
