// Copyright © 2022-2026 Gabor Csizmadia
// This code is licensed under MIT license (see LICENSE for details)

using System;
using System.Collections.Generic;
#if NETFRAMEWORK
using System.Diagnostics.CodeAnalysis;
#endif

using EgonsoftHU.Extensions.Bcl.UnitTests.Stubs;

using FluentAssertions;

using Xunit;

namespace EgonsoftHU.Extensions.Bcl.UnitTests
{
#if NETFRAMEWORK
    [ExcludeFromCodeCoverage]
#endif
    public class IEnumerableExtensionsTests : UnitTest<IEnumerableExtensionsTests>
    {
        public IEnumerableExtensionsTests(ITestOutputHelper output, LoggingFixture<IEnumerableExtensionsTests> fixture)
            : base(output, fixture)
        {
        }

        [Fact]
        public void DetectChanges_BothNull()
        {
            // Arrange
            IEnumerable<int>? existingItems = null;
            IEnumerable<int>? incomingItems = null;

            // Act
            ItemsChangeResult<int> result = existingItems.DetectChanges(incomingItems, item => item);

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges_BothEmpty()
        {
            // Arrange
            IEnumerable<int> existingItems = Array.Empty<int>();
            IEnumerable<int> incomingItems = Array.Empty<int>();

            // Act
            ItemsChangeResult<int> result = existingItems.DetectChanges(incomingItems, item => item);

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges_OnlyToAdd()
        {
            // Arrange
            IEnumerable<int> existingItems = Array.Empty<int>();
            IEnumerable<int> incomingItems = new int[] { 1, 2 };

            // Act
            ItemsChangeResult<int> result = existingItems.DetectChanges(incomingItems, item => item);

            // Assert
            result.ItemsToAdd.Should().BeEquivalentTo(incomingItems);
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges_OnlyToUpdate()
        {
            // Arrange
            IEnumerable<int> existingItems = new int[] { 1, 2 };
            IEnumerable<int> incomingItems = new int[] { 1, 2 };

            // Act
            ItemsChangeResult<int> result = existingItems.DetectChanges(incomingItems, item => item);

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEquivalentTo(incomingItems);
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges_OnlyToRemove()
        {
            // Arrange
            IEnumerable<int> existingItems = new int[] { 1, 2 };
            IEnumerable<int> incomingItems = Array.Empty<int>();

            // Act
            ItemsChangeResult<int> result = existingItems.DetectChanges(incomingItems, item => item);

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEquivalentTo(existingItems);
        }

        [Fact]
        public void DetectChanges_All()
        {
            // Arrange
            IEnumerable<int> existingItems = new int[] { 1, 2 };
            IEnumerable<int> incomingItems = new int[] { 2, 3 };

            // Act
            ItemsChangeResult<int> result = existingItems.DetectChanges(incomingItems, item => item);

            // Assert
#if NET8_0_OR_GREATER
            result.ItemsToAdd.Should().BeEquivalentTo([3]);
            result.ItemsToUpdate.Should().BeEquivalentTo([2]);
            result.ItemsToRemove.Should().BeEquivalentTo([1]);
#else
            result.ItemsToAdd.Should().BeEquivalentTo(3.AsSingleElementSequence());
            result.ItemsToUpdate.Should().BeEquivalentTo(2.AsSingleElementSequence());
            result.ItemsToRemove.Should().BeEquivalentTo(1.AsSingleElementSequence());
#endif
        }

        [Fact]
        public void DetectChanges2_BothNull()
        {
            // Arrange
            IEnumerable<Entity>? existingItems = null;
            IEnumerable<DataTransferObject>? incomingItems = null;

            // Act
            ItemsChangeResult<DataTransferObject, Entity> result =
                existingItems.DetectChanges(
                    incomingItems,
                    existingItem => existingItem.Id,
                    incomingItem => incomingItem.Id
                );

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges2_BothEmpty()
        {
            // Arrange
            IEnumerable<Entity> existingItems = Array.Empty<Entity>();
            IEnumerable<DataTransferObject> incomingItems = Array.Empty<DataTransferObject>();

            // Act
            ItemsChangeResult<DataTransferObject, Entity> result =
                existingItems.DetectChanges(
                    incomingItems,
                    existingItem => existingItem.Id,
                    incomingItem => incomingItem.Id
                );

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges2_OnlyToAdd()
        {
            // Arrange
            IEnumerable<Entity> existingItems = Array.Empty<Entity>();

            IEnumerable<DataTransferObject> incomingItems =
                new DataTransferObject[]
                {
                    StubDataTransferObjects.First,
                    StubDataTransferObjects.Second
                };

            // Act
            ItemsChangeResult<DataTransferObject, Entity> result =
                existingItems.DetectChanges(
                    incomingItems,
                    existingItem => existingItem.Id,
                    incomingItem => incomingItem.Id
                );

            // Assert
            result.ItemsToAdd.Should().Equal(incomingItems);
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges2_OnlyToUpdate()
        {
            // Arrange
            IEnumerable<Entity> existingItems =
                new Entity[]
                {
                    StubEntities.First,
                    StubEntities.Second
                };

            IEnumerable<DataTransferObject> incomingItems =
                new DataTransferObject[]
                {
                    StubDataTransferObjects.FirstUpdated,
                    StubDataTransferObjects.SecondUpdated
                };

            // Act
            ItemsChangeResult<DataTransferObject, Entity> result =
                existingItems.DetectChanges(
                    incomingItems,
                    existingItem => existingItem.Id,
                    incomingItem => incomingItem.Id
                );

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().Equal(incomingItems);
            result.ItemsToRemove.Should().BeEmpty();
        }

        [Fact]
        public void DetectChanges2_OnlyToRemove()
        {
            // Arrange
            IEnumerable<Entity> existingItems =
                new Entity[]
                {
                    StubEntities.First,
                    StubEntities.Second
                };

            IEnumerable<DataTransferObject> incomingItems = Array.Empty<DataTransferObject>();

            // Act
            ItemsChangeResult<DataTransferObject, Entity> result =
                existingItems.DetectChanges(
                    incomingItems,
                    existingItem => existingItem.Id,
                    incomingItem => incomingItem.Id
                );

            // Assert
            result.ItemsToAdd.Should().BeEmpty();
            result.ItemsToUpdate.Should().BeEmpty();
            result.ItemsToRemove.Should().Equal(existingItems);
        }

        [Fact]
        public void DetectChanges2_All()
        {
            // Arrange
            IEnumerable<Entity> existingItems =
                new Entity[]
                {
                    StubEntities.First,
                    StubEntities.Second
                };

            IEnumerable<DataTransferObject> incomingItems =
                new DataTransferObject[]
                {
                    StubDataTransferObjects.SecondUpdated,
                    StubDataTransferObjects.Third
                };

            // Act
            ItemsChangeResult<DataTransferObject, Entity> result =
                existingItems.DetectChanges(
                    incomingItems,
                    existingItem => existingItem.Id,
                    incomingItem => incomingItem.Id
                );

            // Assert
            result.ItemsToAdd.Should().ContainSingle().Which.Should().BeSameAs(StubDataTransferObjects.Third);
            result.ItemsToUpdate.Should().ContainSingle().Which.Should().BeSameAs(StubDataTransferObjects.SecondUpdated);
            result.ItemsToRemove.Should().ContainSingle().Which.Should().BeSameAs(StubEntities.First);
        }
    }
}
