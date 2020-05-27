using System;

namespace IReckonu.DataImportingTool.Messaging.Messages
{
    public class FileUploaded : IMessage
    {
        public string FilePath { get; set; }
    }
}
