namespace Amazon.SQS.ExtendedClient
{
    internal class MessageS3Pointer
    {
        public MessageS3Pointer()
        {
        }

        public MessageS3Pointer(string s3BucketName, string s3Key)
        {
            S3BucketName = s3BucketName;
            S3Key = s3Key;
        }

        public string S3Key { get; set; }

        public string S3BucketName { get; set; }
    }

    /// <summary>
    /// Looks like in a Java client library there is a case sensitive serialization used. 
    /// So, it fails trying to deserialize properties starting from the UpperCase letter.
    /// This class is to address the issue.
    /// </summary>
    internal class JavaMessageS3Pointer 
    {
        public JavaMessageS3Pointer(string s3BucketName, string s3Key)
        {
            this.s3BucketName = s3BucketName;
            this.s3Key = s3Key;
        }

        public JavaMessageS3Pointer(MessageS3Pointer original)
        {
            this.s3BucketName = original.S3BucketName;
            this.s3Key = original.S3Key;
        }


        public string s3Key { get; set; }
        public string s3BucketName { get; set; }
    }
}
