using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace RedDog.Search.Tests
{
    [TestClass]
    public class ListExtensionsTest
    {
        [TestMethod]
        public void ChunkTest()
        {
            List<int> list = CreateList(999);
            List<List<int>> chunked = list.Chunk(1000);
            Assert.IsNotNull(chunked);
            Assert.IsTrue(chunked.Count == 1);
            Assert.IsTrue(chunked[0].Count == 999);


            list = CreateList(1000);
            chunked = list.Chunk(1000);
            Assert.IsNotNull(chunked);
            Assert.IsTrue(chunked.Count == 1);
            Assert.IsTrue(chunked[0].Count == 1000);

            list = CreateList(1001);
            chunked = list.Chunk(1000);
            Assert.IsNotNull(chunked);
            Assert.IsTrue(chunked.Count == 2);
            Assert.IsTrue(chunked[0].Count == 1000);
            Assert.IsTrue(chunked[1].Count == 1);
        }

        private List<int> CreateList(int elementCount)
        {
            if (elementCount <= 0) { return new List<int>(); }
            List<int> result = new List<int>();
            for (int i = 0; i < elementCount; i++)
            {
                result.Add(i);
            }
            return result;
        }
    }
}
