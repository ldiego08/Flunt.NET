using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using System.Data.Common;
using System.Data;

namespace Flunt.Data.Tests
{
    public class WhenCreatingDatabaseCommandParameters
    {
        [Test]
        public void ItShouldBeAbleToChangeValueType()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.DbType);

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p => p.Is(1).OfType(DbType.Int32));

            // Assert
            Assert.That(dataParameterMock.Object.DbType, Is.EqualTo(DbType.Int32));
        }

        [Test]
        public void ItShouldBeAbleToSetValueSize()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Size);

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p => p.Is(1).WithSize(30));

            // Assert
            Assert.That(dataParameterMock.Object.Size, Is.EqualTo(30));
        }

        [Test]
        public void ItShouldThrowExceptionIfNameIsNullOrEmpty()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);


            TestDelegate nullNameInitializer;
            TestDelegate emptyNameInitializer;

            // Act
            nullNameInitializer = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where(null, p => p.Is(1)));
            emptyNameInitializer = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where(String.Empty, p => p.Is(1)));

            // Assert
            Assert.That(nullNameInitializer, Throws.Exception);
            Assert.That(emptyNameInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldNotAddAtSymbolIfParameterNameAlreadyHasIt()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Value);
            dataParameterMock.SetupProperty(c => c.ParameterName);

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("@Id", p => p.Is(1));

            // Assert
            Assert.That(dataParameterMock.Object.ParameterName, Is.EqualTo("@Id"));
            Assert.That(dataParameterMock.Object.Value, Is.EqualTo(1));
        }

        [Test]
        public void ItShouldThrowExceptionIfValueSizeIsLessThanZero()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            TestDelegate invalidParameterSizeInitializer;

            // Act
            invalidParameterSizeInitializer = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where("Id", p => p.Is(1).WithSize(-20)));

            // Assert
            Assert.That(invalidParameterSizeInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldBeAbleToSetAdditonalOptions()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Precision);
            dataParameterMock.SetupProperty(c => c.SourceColumn);
            dataParameterMock.SetupProperty(c => c.SourceVersion);

            var resultingParameter = dataParameterMock.Object;

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p => p.Is(1).WithOptions(opt =>
                                                 {
                                                     opt.Precision = 0xFF;
                                                     opt.SourceColumn = "Id";
                                                     opt.SourceVersion = DataRowVersion.Current;
                                                 }));

            // Assert
            Assert.That(resultingParameter.Precision, Is.EqualTo(0xFF));
            Assert.That(resultingParameter.SourceColumn, Is.EqualTo("Id"));
            Assert.That(resultingParameter.SourceVersion, Is.EqualTo(DataRowVersion.Current));
        }

        [Test]
        public void ItShouldThrowExceptionIfOptionsPredicateIsNull()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            TestDelegate nullOptionsPredicateInitializer;

            // Act
            nullOptionsPredicateInitializer = new TestDelegate(() => databaseContext.Execute("SELECT * FROM Table").Where("Id", p => p.Is(8).WithOptions(null)));
            
            // Assert
            Assert.That(nullOptionsPredicateInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldBeAbleToSetDirectionToOutput()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Direction);

            var resultingParameter = dataParameterMock.Object;

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p => p.Is(1).AsOutput());

            // Assert
            Assert.That(resultingParameter.Direction, Is.EqualTo(ParameterDirection.Output));
        }

        [Test]
        public void ItShouldBeAbleToCompileExpressionToNativeParameter()
        {
            // Arrange
            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataCommandMock = new Mock<IDbCommand>();
            var dataParameterMock = new Mock<IDbDataParameter>();

            var databaseContext = Database.ForProvider(dataProviderMock.Object);

            dataProviderMock.Setup(c => c.CreateCommand())
                            .Returns(dataCommandMock.Object);

            dataProviderMock.Setup(c => c.CreateParameter())
                            .Returns(dataParameterMock.Object);

            dataParameterMock.SetupProperty(c => c.Direction);

            var resultingParameter = dataParameterMock.Object;

            DatabaseCommandParameterExpression parameterExpression = null;

            // Act
            var databaseCommand = databaseContext.Execute("SELECT * FROM Table")
                                                 .Where("Id", p =>
                                                 {
                                                     parameterExpression = p;
                                                 });

            // Assert
            Assert.That(resultingParameter, Is.EqualTo(parameterExpression.Compiled()));
        }
    }
}
