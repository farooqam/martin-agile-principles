using System;

namespace BigCorp.Utility
{
    public sealed class HashCodeBuilder
    {
        private const int InitialValue = 385229220;
        public int Value { get; }

        private HashCodeBuilder(int value)
        {
            Value = value;
        }

        public static HashCodeBuilder CreateNew()
        {
            return new HashCodeBuilder(InitialValue);
        }

        internal static HashCodeBuilder CreateWithValue(int value)
        {
            return new HashCodeBuilder(value);
        }
    }

    public static class HashCodeBuilderFluentApi
    {
        public static HashCodeBuilder WithCaseInsensitiveString(this HashCodeBuilder builder, string value)
        {
            var hashCode = builder.Value * -1521134295 + StringComparer.OrdinalIgnoreCase.GetHashCode(value);
            return HashCodeBuilder.CreateWithValue(hashCode);
        }

        public static HashCodeBuilder Build(this HashCodeBuilder builder)
        {
            return builder;
        }
    }
}
