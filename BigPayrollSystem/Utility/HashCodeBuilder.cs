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

    public static class HashCodeBuilderExtensions
    {
        private const int PrimeNumberForHashCodeCalculation = -1521134295;

        public static HashCodeBuilder WithCaseInsensitiveString(this HashCodeBuilder builder, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return builder;

            var hashCode = builder.Value * PrimeNumberForHashCodeCalculation + StringComparer.OrdinalIgnoreCase.GetHashCode(value);
            return HashCodeBuilder.CreateWithValue(hashCode);
        }

        public static HashCodeBuilder WithDecimal(this HashCodeBuilder builder, decimal value)
        {
            var hashCode = builder.Value * PrimeNumberForHashCodeCalculation + value.GetHashCode();
            return HashCodeBuilder.CreateWithValue(hashCode);
        }

        public static HashCodeBuilder Add(this HashCodeBuilder builder, HashCodeBuilder toAdd)
        {
            var hashCode = builder.Value * PrimeNumberForHashCodeCalculation + toAdd.Value;
            return HashCodeBuilder.CreateWithValue(hashCode);
        }

        public static HashCodeBuilder Build(this HashCodeBuilder builder)
        {
            return builder;
        }
    }
}
