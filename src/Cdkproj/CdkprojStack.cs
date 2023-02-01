using Amazon.CDK;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.Pipelines;
using Constructs;

namespace Cdkproj
{
    public class CdkprojStack : Stack
    {
        internal CdkprojStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {

            var pipeline = new CodePipeline(this, "pipeline", new CodePipelineProps
            {
                PipelineName = "MyPipeline",
                Synth = new ShellStep("Synth", new ShellStepProps
                {
                    Input = CodePipelineSource.GitHub("VSAUT/filebox",
                        "net6-upgrade"),
                    Commands = new string[] { "npm install -g aws-cdk", "cdk synth" }
                })
            });


        }
    }
}
