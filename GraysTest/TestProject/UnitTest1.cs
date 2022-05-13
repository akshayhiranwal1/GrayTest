using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace TestProject
{
    public class UnitTest1 : IClassFixture<TestFixture>
    {
        private readonly TestFixture fixture;

        public UnitTest1(TestFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void Test_PowersOf2()
        {
            int[] powers = { 2, 4, 8, 16, 32, 64, 128, 256, 512, 1024 };

            int iteration = 0;
            foreach (int power in fixture.Implementation.YieldPowersOf(2))
            {
                // Check current power is correct
                Assert.Equal(power, powers[iteration]);
                iteration++;

                if (iteration == powers.Length)
                {
                    break;
                }
            }

            // Check that the method didn't just prepopulate a list
            Assert.Equal(powers.Length, iteration);
        }

        [Fact]
        public void Test_PowersOf5()
        {
            int[] powers = { 5, 25, 125, 625, 3125 };

            int iteration = 0;
            foreach (int power in fixture.Implementation.YieldPowersOf(5))
            {
                // Check current power is correct
                Assert.Equal(powers[iteration], power);
                iteration++;

                if (iteration == powers.Length)
                {
                    break;
                }
            }

            // Check that the method didn't just prepopulate a list
            Assert.Equal(powers.Length, iteration);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveItemFromCollection(int index)
        {
            List<TestModel> data = GetTestModelsAsList();
            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            fixture.Implementation.RemoveItemsFromCollection(data, new TestModel("A"));
            Assert.Equal(expected, data);

            // Should remove item
            fixture.Implementation.RemoveItemsFromCollection(data, data[index]);
            expected.RemoveAt(index);
            Assert.Equal(expected, data);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveItemFromCollection_WithTestCollection(int index)
        {
            TestCollection<TestModel> data = GetTestModelsAsTestCollection();
            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            fixture.Implementation.RemoveItemsFromCollection(data, new TestModel("A"));
            Assert.Equal(expected, data);

            // Should remove item
            fixture.Implementation.RemoveItemsFromCollection(data, data[index]);
            expected.RemoveAt(index);
            Assert.Equal(expected, data);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveMultipleItemsFromCollection(int index)
        {
            List<TestModel> data = GetTestModelsAsList();
            TestModel copy = data[index];
            data.Insert(index, copy);
            data.Add(copy);

            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            fixture.Implementation.RemoveItemsFromCollection(data, new TestModel("A"));
            Assert.Equal(expected, data);

            // Should remove items
            fixture.Implementation.RemoveItemsFromCollection(data, data[index]);
            expected.RemoveAll(e => e == copy);
            Assert.Equal(expected, data);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveMultipleItemsFromCollection_WithTestCollection(int index)
        {
            TestCollection<TestModel> data = GetTestModelsAsTestCollection();
            TestModel copy = data[index];
            data.Insert(index, copy);
            data.Add(copy);

            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            fixture.Implementation.RemoveItemsFromCollection(data, new TestModel("A"));
            Assert.Equal(expected, data);

            // Should remove items
            fixture.Implementation.RemoveItemsFromCollection(data, data[index]);
            expected.RemoveAll(e => e == copy);
            Assert.Equal(expected, data);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveItemInNewCollection(int index)
        {
            List<TestModel> data = GetTestModelsAsList();
            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            IEnumerable<TestModel> output = fixture.Implementation.RemoveItemsInNewCollection(data, new TestModel("A"));

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Checks output wasn't changed
            Assert.Equal(expected, output);

            // Should remove item
            output = fixture.Implementation.RemoveItemsInNewCollection(data, data[index]);

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Check if the correct item was removed
            expected.RemoveAt(index);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveItemInNewCollection_WithTestCollection(int index)
        {
            TestCollection<TestModel> data = GetTestModelsAsTestCollection();
            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            IEnumerable<TestModel> output = fixture.Implementation.RemoveItemsInNewCollection(data, new TestModel("A"));

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Checks output wasn't changed
            Assert.Equal(expected, output);

            // Should remove item
            output = fixture.Implementation.RemoveItemsInNewCollection(data, data[index]);

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Check if the correct item was removed
            expected.RemoveAt(index);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveItemInNewCollection_WithArray(int index)
        {
            TestModel[] data = GetTestModelsAsArray();
            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            IEnumerable<TestModel> output = fixture.Implementation.RemoveItemsInNewCollection(data, new TestModel("A"));

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Checks output wasn't changed
            Assert.Equal(expected, output);

            // Should remove item
            output = fixture.Implementation.RemoveItemsInNewCollection(data, data[index]);

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Check if the correct item was removed
            expected.RemoveAt(index);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveMultipleItemsInNewCollection(int index)
        {
            List<TestModel> data = GetTestModelsAsList();
            TestModel copy = data[index];
            data.Insert(index, copy);
            data.Add(copy);

            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            IEnumerable<TestModel> output = fixture.Implementation.RemoveItemsInNewCollection(data, new TestModel("A"));

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Checks output wasn't changed
            Assert.Equal(expected, output);

            // Should remove item
            output = fixture.Implementation.RemoveItemsInNewCollection(data, data[index]);

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Check if the correct items were removed
            expected.RemoveAll(e => e == copy);
            Assert.Equal(expected, output);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        public void Test_RemoveMultipleItemsInNewCollection_WithTestCollection(int index)
        {
            TestCollection<TestModel> data = GetTestModelsAsTestCollection();
            TestModel copy = data[index];
            data.Insert(index, copy);
            data.Add(copy);

            List<TestModel> expected = new List<TestModel>(data);

            // Shouldn't remove anything
            IEnumerable<TestModel> output = fixture.Implementation.RemoveItemsInNewCollection(data, new TestModel("A"));

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Checks output wasn't changed
            Assert.Equal(expected, output);

            // Should remove item
            output = fixture.Implementation.RemoveItemsInNewCollection(data, data[index]);

            // Checks input wasn't changed
            Assert.Equal(expected, data);

            // Check if the correct items were removed
            expected.RemoveAll(e => e == copy);
            Assert.Equal(expected, output);
        }

        [Fact]
        public void Test_ReverseCollectionOrder()
        {
            List<TestModel> data = GetTestModelsAsList();
            IList<TestModel> expected = new List<TestModel>(data);

            IEnumerable<TestModel> output = fixture.Implementation.ReverseCollectionOrder(data);

            // Check if the input wasn't changed
            Assert.Equal(expected, data);

            // Check output is reversed
            Assert.Equal(expected.Reverse(), output);
        }

        [Fact]
        public void Test_ReverseCollectionOrder_WithTestCollection()
        {
            TestCollection<TestModel> data = GetTestModelsAsTestCollection();
            IList<TestModel> expected = new List<TestModel>(data);

            IEnumerable<TestModel> output = fixture.Implementation.ReverseCollectionOrder(data);

            // Check if the input wasn't changed
            Assert.Equal(expected, data);

            // Check output is reversed
            Assert.Equal(expected.Reverse(), output);
        }

        [Fact]
        public async Task Test_DownloadFileAsync()
        {
            string url = "https://www.grays-int.com";
            string html = await fixture.Implementation.DownloadFileAsync(url).ConfigureAwait(false);

            // Checks if a value was returned
            Assert.True(html != null);
            Assert.True(html != string.Empty);
        }

        [Theory]
        [InlineData("test!", "test", Skip = null)]
        [InlineData("1234", "1234", Skip = null)]
        [InlineData("12[34Aa!#", "1234Aa", Skip = null)]
        [InlineData("12[34-Aa!#", "1234-Aa", Skip = null)]
        public void Test_RemoveNonAlphanumeric(string input, string expected)
        {
            string actual = fixture.Implementation.RemoveNonAlphanumeric(input);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData(4.6, "test", "1", "3.6", "a", "two", Skip = null)]
        [InlineData(9.1, "hylp", "3", "6.1", "k", "10 a", Skip = null)]
        public void Test_AddStringIfNumber(decimal expected, params string[] input)
        {
            decimal actual = fixture.Implementation.AddStringIfNumber(input);
            Assert.Equal(expected, actual);
        }

        private List<TestModel> GetTestModelsAsList()
        {
            return new List<TestModel>
            {
                new TestModel("A"),
                new TestModel("B"),
                new TestModel("C"),
                new TestModel("D"),
            };
        }

        private TestCollection<TestModel> GetTestModelsAsTestCollection()
        {
            return new TestCollection<TestModel>
            {
                new TestModel("A"),
                new TestModel("B"),
                new TestModel("C"),
                new TestModel("D"),
            };
        }

        private TestModel[] GetTestModelsAsArray()
        {
            return new[]
            {
                new TestModel("A"),
                new TestModel("B"),
                new TestModel("C"),
                new TestModel("D"),
            };
        }
    }
}
