using Amazon.CDK;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cdkproj
{
    sealed class Program
    {
        public static void Main(string[] args)
        {
            var app = new App();
            new CdkprojStack(app, "CdkprojStack", new StackProps
            {
                Env = new Amazon.CDK.Environment
                      {
                          Account = "220659591193",
                          Region = "eu-west-1"
                      }

                // For more information, see https://docs.aws.amazon.com/cdk/latest/guide/environments.html
            });
            app.Synth();
        }
    }
}
