using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Utilities
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FileResultContentTypeAttribute : Attribute
    {
        public string ContentType { get; }

        public FileResultContentTypeAttribute(string contentType)
        {
            ContentType = contentType;
        }

    }
}
