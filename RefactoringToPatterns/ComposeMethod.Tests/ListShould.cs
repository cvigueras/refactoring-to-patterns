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
            
            object[] expectedElements = { };
            Assert.Equal(expectedElements, list.Elements());
        }
        
        [Fact]
        public void AddElement()
        {
            var list = new List(false);
            
            list.Add(1);
            
            object[] expectedElements = { 1, null, null, null, null, null, null, null, null, null };
            Assert.Equal(expectedElements, list.Elements());
        }
        
        [Fact]
        public void GrowListIfElementsExceedSize()
        {
            var list = new List(false);

            foreach (var value in Enumerable.Range(1, 11))
            {
                list.Add(value);
            }

            object[] expectedElements = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, null, null, null, null, null, null, null, null, null };
            Assert.Equal(expectedElements, list.Elements());
        }
    }
}