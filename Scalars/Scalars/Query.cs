using System;
using HotChocolate;
using HotChocolate.Language;
using HotChocolate.Types;

namespace Scalars
{
    public class Query
    {
        public string GetInUppercase(string value) => value;

        [GraphQLType(typeof(StringType))] // <- Applies to return type
        public string GetWithNormalStringType([GraphQLType(typeof(StringType))] string value) =>
            value; // <- Applies to return type

        public int GetInt(int value) => value;
        public float GetFloat(float value) => value;
        public bool GetBoolean(bool value) => value;

        [GraphQLType(typeof(IdType))]
        public int GetIntID([GraphQLType(typeof(IdType))] int value) => value;

        [GraphQLType(typeof(IdType))]
        public Guid GetGuidID([GraphQLType(typeof(IdType))] Guid value) => value;


        [GraphQLType(typeof(IdType))]
        public string GetStringID([GraphQLType(typeof(IdType))] string value) => value;

        public Byte GetByte(Byte value) => value;
        public short GetShort(short value) => value;
        public long GetLong(long value) => value;
        public Decimal GetDecimal(Decimal value) => value;
        public Uri GetUri(Uri value) => value;
        public DateTime GetDateTime(DateTime value) => value;

        [GraphQLType(typeof(DateType))]
        public DateTime GetDate([GraphQLType(typeof(DateType))] DateTime value) => value;

        public Guid GetGuid(Guid value) => value;
        public TimeSpan GetTimespan(TimeSpan value) => value;
        public object GetAny(object value) => value;
    }

    public class UppercaseStringType : ScalarType<string>
    {
        public UppercaseStringType() : base("Uppercase", BindingBehavior.Explicit)
        {
        }

        public override bool IsInstanceOfType(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            return literal is StringValueNode
                   || literal is NullValueNode;
        }

        public override object? ParseLiteral(IValueNode literal)
        {
            if (literal == null)
            {
                throw new ArgumentNullException(nameof(literal));
            }

            if (literal is StringValueNode stringLiteral)
            {
                return stringLiteral.Value.ToUpper();
            }

            if (literal is NullValueNode)
            {
                return null;
            }

            throw new ArgumentException(
                "The string type can only parse string literals.",
                nameof(literal));
        }

        public override IValueNode ParseValue(object? value)
        {
            if (value == null)
            {
                return new NullValueNode(null);
            }

            if (value is string s)
            {
                return new StringValueNode(null, s.ToUpper(), false);
            }

            if (value is char c)
            {
                return new StringValueNode(null, c.ToString().ToUpper(), false);
            }

            throw new ArgumentException(
                "The specified value has to be a string or char in order " +
                "to be parsed by the string type.");
        }
    }
}