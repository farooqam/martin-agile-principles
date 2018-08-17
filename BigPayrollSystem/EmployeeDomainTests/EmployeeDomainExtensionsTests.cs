using System;
using BigCorp.EmployeeDomain;
using BigCorp.Utility;
using FluentAssertions;
using Xunit;

namespace BigCorp.EmployeeDomainTests
{
    public class EmployeeDomainExtensionsTests
    {
        [Fact]
        public void EnsureNotNull_ThrowException()
        {
            // Arrange
            FakeDomainObject domainObject = null;
            Action action = () => domainObject.EnsureNotNull("foo");
            
            // Act & Assert
            action.Should().Throw<EmployeeDomainException>().WithMessage("foo");
        }

        [Fact]
        public void EnsureNotNull_DoesNotThrowException()
        {
            // Arrange
            FakeDomainObject domainObject = new FakeDomainObject();
            Action action = () => domainObject.EnsureNotNull("foo");
            
            // Act & Assert
            action.Should().NotThrow<ArgumentException>();
        }
    }

    public class FakeDomainObject : DomainObject<FakeDomainObject>
    {
        protected override bool CheckEquality(FakeDomainObject other)
        {
            throw new System.NotImplementedException();
        }

        protected override bool CheckEqualityUsingOperator(DomainObject<FakeDomainObject> other)
        {
            throw new System.NotImplementedException();
        }

        protected override HashCodeBuilder CalculateHashCode()
        {
            throw new System.NotImplementedException();
        }
    }
}