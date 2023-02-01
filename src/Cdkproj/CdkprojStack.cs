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
                    Input = CodePipelineSource.Connection("paul-olofsson/MyTestRepo", "master", new ConnectionSourceOptions
                    {
                        ConnectionArn = "arn:aws:codestar-connections:eu-west-1:220659591193:connection/188e1149-5dd5-4854-b70c-313f9cd8dd35",
                        TriggerOnPush = true
                    }),
                    Commands = new string[] { "npm install -g aws-cdk", "cdk synth" }
                })
            });

            var testStage = pipeline.AddStage(new MyPipelineAppStage(this, "Test", new StageProps
            {
                Env = props.Env
            }));

            testStage.AddPost(
                new ManualApprovalStep("ManualApprovalStep", new ManualApprovalStepProps
                {
                    Comment = "Approve to deploy in production"
                }));

            pipeline.AddStage(new MyPipelineAppStage(this, "Prod", new StageProps
            {
                Env = props.Env
            }));
        }
    }

    class MyPipelineAppStage : Stage
    {
        public MyPipelineAppStage(Construct scope, string id, StageProps props) : base(scope, id, props)
        {
            new BucketStack(this, "MyBucketStack", new StackProps
            {
                Env = props.Env
            });
        }
    }
}
