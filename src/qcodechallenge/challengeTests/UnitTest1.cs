using System;
using challenge.Helpers;
using Xunit;

namespace challengeTests
{
    public class UnitTest1
    {
        [Fact]
        public void ShouldThrowErrorIfTheLenghtOfMAtrixIsHigerThan64()
        {
            try
            {
                var matrixGenerator = new MatrixGenerator();
                matrixGenerator.GenerateMatrix(100, 100);
            }
            catch (Exception e)
            {
                Assert.Equal("the Matrix length can not be more than 64", e.Message);
            }
        }

    }
}
