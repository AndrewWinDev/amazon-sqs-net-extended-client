Amazon SQS Extended Client Library for .NET
===========================================

[![Stand With Ukraine](https://raw.githubusercontent.com/vshymanskyy/StandWithUkraine/main/banner2-direct.svg)](https://vshymanskyy.github.io/StandWithUkraine)

[![Build status](https://github.com/raol/amazon-sqs-net-extended-client-lib/actions/workflows/dotnet-core-desktop.yml/badge.svg)](https://github.com/raol/amazon-sqs-net-extended-client-lib/actions)

This is port to .NET of existing [Amazon Extended Client Library for Java](https://github.com/awslabs/amazon-sqs-java-extended-client-lib)
It enables you to store message payloads in S3 and hence overcomes message size limitation of the SQS.
With this library you can:

* Specify whether message payloads should be always stored in S3 or when message size exceeds configurable threshold.

* Send message and store its payload in S3 bucket.

* Receive stored message from S3 bucket transparently

* Delete stored payload from the S3 bucket.

## Installation

[![Nuget](https://img.shields.io/nuget/v/Amazon.SQS.ExtendedClient.svg?style=flat)](https://www.nuget.org/packages/AWSSQS.Extended.Client/)

To install via nuget, run following command in the Package Manager Console
```PowerShell
Install-Package AWSSQS.Extended.Client
```

## Usage

```csharp
var s3Client = new AmazonS3Client(new BasicAWSCredentials("<key>", "<secret>"), "<region>")
var sqsClient = new AmazonSQSClient(new BasicAWSCredentials("<key>", "<secret>"), "<region>");
var extendedClient = new AmazonSQSExtendedClient(
    sqsClient, 
    new ExtendedClientConfiguration().WithLargePayloadSupportEnabled(s3Client, "<s3bucketname>"));
extendedClient.SendMessage(queueUrl, "MessageBody")
```

## Fork Changes
Added support for Java Extended Client SQS message format:
```Json
[
  "software.amazon.payloadoffloading.PayloadS3Pointer",
  {
    "s3BucketName": "extended-client-bucket",
    "s3Key": "xxxx-xxxxx-xxxxx-xxxxxx"
  }
]
```

### To Enable it, just use an additional parameter in the **WithLargePayloadSupportEnabled** method:
```csharp
public ExtendedClientConfiguration WithLargePayloadSupportEnabled(IAmazonS3 s3, string s3BucketName, bool useJavaClientMessageFormat = false);
```
```csharp
var extendedConfig = new ExtendedClientConfiguration()
        .WithLargePayloadSupportEnabled(s3Client, bucketName, true);
```


### Error handling on receiving messages
If client receive more than one message and processing of the first message cause exception (for instance - original message contend was not found on S3),
it will break overal process and throw the exception higher.
Now, you can swallow exception, embed information about error to message body and continue processing the rest.
Client will get the message with the error description.
To enable this behavior:
```csharp
var extendedConfig = new ExtendedClientConfiguration()
        .WithLargePayloadSupportEnabled(s3Client, bucketName, true)
        .SwallowErrorOnReceiveMessage();
```