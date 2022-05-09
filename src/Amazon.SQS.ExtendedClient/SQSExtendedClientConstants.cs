namespace Amazon.SQS.ExtendedClient
{
    internal static class SQSExtendedClientConstants
    {
        public const string RESERVED_ATTRIBUTE_NAME = "SQSLargePayloadSize";

        public const int MAX_ALLOWED_ATTRIBUTES = 9;

        public const int DEFAULT_MESSAGE_SIZE_THRESHOLD = 262144;

        public const string S3_BUCKET_NAME_MARKER = "-..s3BucketName..-";

        public const string S3_KEY_MARKER = "-..s3Key..-";

        /// <summary>
        /// Extended SQS Java Client message marker.
        /// </summary>
        public static readonly string AmazonPayloadOffloadingString = "software.amazon.payloadoffloading.PayloadS3Pointer";
    }
}