using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using System.Data.Common;

namespace Flunt.Data.Tests
{
    [TestFixture]
    public class WhenExecutingQueriesOnDatabase
    {
        [Test]
        public void ItShouldBeAbleToCreateQueryExecutionExpression()
        {
            // Arrange
            DatabaseCommandExpression expression;

            var dataProviderMock = new Mock<DbProviderFactory>();
            var dataCommandMock = new Mock<DbCommand>();
            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(i => i.CreateCommand())
                            .Returns(dataCommandMock.Object);

            // Act
            expression = databaseContext.Execute("SELECT * FROM dbo.Table");

            // Assert
            Assert.That(expression, Is.Not.Null);
        }

        [Test]
        public void ItShouldThrowExceptionIfQueryTextIsNullOrEmpty()
        {
            // Arrange
            TestDelegate nullQueryExpressionInitializer;
            TestDelegate emptyQueryExpressionInitializer;

            var dataProviderMock = new Mock<DbProviderFactory>();
            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            // Act
            nullQueryExpressionInitializer = new TestDelegate(() => databaseContext.Execute(null));
            emptyQueryExpressionInitializer = new TestDelegate(() => databaseContext.Execute(String.Empty));

            // Assert
            Assert.That(nullQueryExpressionInitializer, Throws.Exception);
            Assert.That(emptyQueryExpressionInitializer, Throws.Exception);
        }
    }
}
