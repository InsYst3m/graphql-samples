using System.Runtime.Serialization;

namespace Graphql.Api.Exceptions
{
	public sealed class UnprocessableEntityException : Exception
	{
		public UnprocessableEntityException()
		{
		}

		public UnprocessableEntityException(string? message) : base(message)
		{
		}

		public UnprocessableEntityException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}

		public UnprocessableEntityException(string? message, Exception? innerException) : base(message, innerException)
		{
		}
	}
}
