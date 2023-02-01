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
                    Commands = new string[] { "npm install -g aws-cdk" }
                })
            });

            pipeline.AddStage(new MyPipelineAppStage(this, "FirstStage", new StageProps
            {
                Env = props.Env,
                StageName = "Nisse"
            }));

        }
    }

    class MyPipelineAppStage : Stage
    {
        public MyPipelineAppStage(Construct scope, string id, StageProps props=null) : base(scope, id, props)
        {
            new BucketStack(this, "MyBucketStack", new StackProps
            {
                Env = props.Env
            });
        }
    }
}
