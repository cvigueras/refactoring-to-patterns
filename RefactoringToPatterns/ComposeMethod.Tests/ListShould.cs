using System;
using System.Linq;
using Xunit;

namespace RefactoringToPatterns.ComposeMethod.Tests
{
    public class ListShould
    {
        [Fact]
        public void NotAddElementWhenIsReadOnly()
        {
            var list = new List(true);
            
            list.Add(1);
            
            Object[] expectedElements = { };
            Assert.Equal(expectedElements, list.Elements());
        }
        
        [Fact]
        public void AddElement()
        {
            var list = new List(false);
            
            list.Add(1);
            
            Object[] expectedElements = { 1, null, null, null, null, null, null, null, null, null };
            Assert.Equal(expectedElements, list.Elements());
        }
        
        [Fact]
        public void GrowListIfElementsExceedSize()
        {
            var list = new List(false);

            foreach (int value in Enumerable.Range(1, 11))
            {
                list.Add(value);
            }

            Object[] expectedElements = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, null, null, null, null, null, null, null, null, null };
            Assert.Equal(expectedElements, list.Elements());
        }
    }
}