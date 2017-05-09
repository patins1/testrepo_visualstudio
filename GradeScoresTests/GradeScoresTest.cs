using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using GradeScoresNS; 

namespace GradeScoresTests
{
    [TestClass]
    public class GradeScoresTest
    {
        [TestMethod]
        public void TestCorrectSorting()
        {
            
            List<string> input = new List<string>();
            input.Add("BUNDY, TERESSA, 88");
            input.Add("SMITH, ALLAN, 70");
            input.Add("KING, MADISON, 88");
            input.Add("SMITH, FRANCIS, 85");

            GradeScoresProgram program = new GradeScoresProgram();
            List<string> actual = program.sortRows(input);

            List<string> expected = new List<string>();
            expected.Add("BUNDY, TERESSA, 88");
            expected.Add("KING, MADISON, 88");
            expected.Add("SMITH, FRANCIS, 85");
            expected.Add("SMITH, ALLAN, 70");

            CollectionAssert.AreEqual(expected, actual, "Rows not sorted correctly");
        }
    }
}
