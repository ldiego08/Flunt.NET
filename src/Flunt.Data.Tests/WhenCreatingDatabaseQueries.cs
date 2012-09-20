using System;
using System.Data.Common;
using Moq;
using NUnit.Framework;

namespace Flunt.Data.Tests
{
    [TestFixture]
    public class WhenCreatingDatabaseQueries
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

        [Test]
        public void ItShouldBeAbleToSetQueryParameter()
        {
            // Arrange
            var dataProviderMock = new Mock<DbProviderFactory>();
            var dataCommandMock = new Mock<DbCommand>();
            var dataParameterMock = new Mock<DbParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);
            
            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Value);
            dataParameterMock.SetupProperty(c => c.ParameterName);
            
            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p => p.Is(1));

            // Assert
            Assert.That(dataParameterMock.Object.ParameterName, Is.EqualTo("@Id"));
            Assert.That(dataParameterMock.Object.Value, Is.EqualTo(1));
        }

        [Test]
        public void ItShouldReplaceExistingQueryParameterWhenReset()
        {
            // Arrange
            var dataProviderMock = new Mock<DbProviderFactory>();
            var dataCommandMock = new Mock<DbCommand>();
            var dataParameterMock = new Mock<DbParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Value);
            dataParameterMock.SetupProperty(c => c.ParameterName);

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p => p.Is(1))
                                                 .Where("Id", p => p.Is(3));

            // Assert
            Assert.That(dataParameterMock.Object.ParameterName, Is.EqualTo("@Id"));
            Assert.That(dataParameterMock.Object.Value, Is.EqualTo(3));
        }

        [Test]
        public void ItShouldThrowExceptionIfParameterNameIsNullOrEmpty()
        {
            // Arrange
            var dataProviderMock = new Mock<DbProviderFactory>();
            var dataCommandMock = new Mock<DbCommand>();
            var dataParameterMock = new Mock<DbParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            TestDelegate nullParameterNameInitializer;
            TestDelegate emptyParameterNameInitializer;

            // Act
            nullParameterNameInitializer = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where(null, p => p.Is(1)));
            emptyParameterNameInitializer = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where(String.Empty, p => p.Is(1)));

            // Assert
            Assert.That(nullParameterNameInitializer, Throws.Exception);
            Assert.That(emptyParameterNameInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldThrowExceptionIfParameterExpressionArgumentsAreNull()
        {
            // Arrange
            var dataProviderMock = new Mock<DbProviderFactory>();
            var dataCommandMock = new Mock<DbCommand>();
            var dataParameterMock = new Mock<DbParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            TestDelegate nullExpressionParameterSetter;

            // Act
            nullExpressionParameterSetter = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where("Id", null));
            
            // Assert
            Assert.That(nullExpressionParameterSetter, Throws.Exception);
        }
    }
}
