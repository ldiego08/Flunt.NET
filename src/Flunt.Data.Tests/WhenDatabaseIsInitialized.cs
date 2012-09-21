using System.Data.Common;
using Moq;
using NUnit.Framework;
using System;

namespace Flunt.Data.Tests
{
    [TestFixture]
    public class WhenDatabaseIsInitialized
    {
        [Test]
        public void ItShouldBeAbleToCreateDatabaseForConnectionString() 
        {
            // Arrange
            Database databaseContext;

            // Act
            databaseContext = Database.ForConnectionString("TestConnection");

            // Assert
            Assert.That(databaseContext, Is.Not.Null);
        }

        [Test]
        public void ItShouldBeAbleToCreateDatabaseForDataProvider()
        { 
            // Arrange
            Database databaseContext;

            var dataProviderMock = new Mock<IDataObjectsFactory>();
            var dataProvider = dataProviderMock.Object;

            // Act
            databaseContext = Database.ForProvider(dataProvider);

            // Assert 
            Assert.That(databaseContext, Is.Not.Null);
        }

        [Test]
        public void ItShouldBeAbleToCreateDatabaseForDataProviderByName()
        {
            // Arrange
            Database databaseContext;

            // Act
            databaseContext = Database.ForProvider("System.Data.SqlClient");

            // Assert
            Assert.That(databaseContext, Is.Not.Null);
        }

        [Test]
        public void ItShouldThrowExceptionIfConnectionStringIsNullWhenCreatingDatabase() 
        {
            // Arrange 
            Database databaseContext;
            TestDelegate databaseContextInitializer;

            // Act
            databaseContextInitializer = new TestDelegate(() => databaseContext = Database.ForConnectionString(null));

            // Assert
            Assert.That(databaseContextInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldThrowExceptionIfConnectionStringDoesNotExistWhenCreatingDatabase()
        {
            // Arrange
            Database databaseContext;
            TestDelegate databaseContextInitializer;

            // Act
            databaseContextInitializer = new TestDelegate(() => databaseContext = Database.ForConnectionString("NonExistentConnection"));
            
            // Assert
            Assert.That(databaseContextInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldBeAbleToChangeConnectionStringAfterInitialization()
        {
            // Arrange
            Database databaseContext = Database.ForProvider("System.Data.SqlClient");

            // Act
            databaseContext.UsingConnection("TestConnection");

            // Assert
            Assert.That(databaseContext.ConnectionStringOrName, Is.EqualTo("TestConnection"));
        }

        [Test]
        public void ItShouldThrowExceptionIfSpecifiedConnectionStringIsNullOrEmpty()
        {
            // Arrange
            TestDelegate nullConnectionStringDatabaseContextInitializer;
            TestDelegate emptyConnectionStringDatabaseContextInitializer;
            Database databaseContext = Database.ForProvider("System.Data.SqlClient");
            
            // Act
            nullConnectionStringDatabaseContextInitializer = new TestDelegate(() => databaseContext.UsingConnection(null));
            emptyConnectionStringDatabaseContextInitializer = new TestDelegate(() => databaseContext.UsingConnection(String.Empty));

            // Assert
            Assert.That(nullConnectionStringDatabaseContextInitializer, Throws.Exception);
            Assert.That(emptyConnectionStringDatabaseContextInitializer, Throws.Exception);
        }

        [Test]
        public void ItShouldBeAbleToGetDataProviderAfterInitialization()
        {
            // Arrange
            Database databaseContext;

            // Act
            databaseContext = Database.ForProvider("System.Data.SqlClient");

            // Assert
            Assert.That(databaseContext.Factory, Is.Not.Null);
        }

        [Test]
        public void ItShouldThrowExceptionWhenDataProviderIsNotFound()
        {
            // Arrange
            Database databaseContext;
            TestDelegate databaseContextInitializer;

            // Act
            databaseContextInitializer = new TestDelegate(() => databaseContext = Database.ForProvider("System.Data.FakeProvider"));

            // Assert
            Assert.That(databaseContextInitializer, Throws.Exception);
        }
    }
}
