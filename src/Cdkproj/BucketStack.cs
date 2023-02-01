using Amazon.CDK;
using Constructs;
using Amazon.CDK.AWS.S3;

namespace Cdkproj
{
    public class BucketStack : Stack
    {
        internal BucketStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            new Bucket(this, "MyTestBucket2", new BucketProps
            {
                Versioned = true,
                BucketName = "my-test-bucket-second-attempt"
            });
        }
    }
}