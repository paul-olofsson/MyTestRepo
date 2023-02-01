using Amazon.CDK;
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
                    Input = CodePipelineSource.Connection("MyTestRepo", "master", new ConnectionSourceOptions
                    {
                        ConnectionArn = "arn:aws:codestar-connections:eu-west-1:220659591193:connection/45669400-261f-46e2-8316-e7d38470deb2",
                        TriggerOnPush = true
                    }),
                    //Input = CodePipelineSource.GitHub("paul-olofsson/MyTestRepo", "master"),
                    Commands = new string[] { "npm install -g aws-cdk", "cdk synth" }
                })
            });

        }
    }
    //
    // class MyPipelineAppStage : Stage
    // {
    //     public MyPipelineAppStage(Construct scope, string id, StageProps props=null) : base(scope, id, props)
    //     {
    //         new BucketStack(this, "MyBucketStack", new StackProps
    //         {
    //             Env = props.Env
    //         });
    //     }
    // }
}
