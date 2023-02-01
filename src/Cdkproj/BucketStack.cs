using Amazon.CDK;
using Constructs;
using Amazon.CDK.AWS.S3;

namespace Cdkproj
{
    public class BucketStack : Stack
    {
        internal BucketStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            new Bucket(this, "MyTestBucket", new BucketProps
            {
                Versioned = true,
                RemovalPolicy = RemovalPolicy.DESTROY,
                BucketName = "my-test-bucket"
            });
        }
    }
}