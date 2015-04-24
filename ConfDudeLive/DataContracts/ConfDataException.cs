using System;
using System.Runtime.Serialization;

namespace DataContracts
{
    [Serializable]
    public class ConfDataException : Exception
    {
        //
        // For guidelines regarding the creation of new exception types, see
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/cpgenref/html/cpconerrorraisinghandlingguidelines.asp
        // and
        //    http://msdn.microsoft.com/library/default.asp?url=/library/en-us/dncscol/html/csharp07192001.asp
        //

        public ConfDataException()
        {
        }

        public ConfDataException(string message) : base(message)
        {
        }

        public ConfDataException(string message, Exception inner) : base(message, inner)
        {
        }

        protected ConfDataException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
