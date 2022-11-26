using ConsoleApp;
using Japan;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class japaneseTest
    {
        [TestCase("columns:4;1,1;1;1;1,2;rows:4;1;1,1;1,1;2;", ".####;#....;#...#;#...#;##...")]
        [TestCase("columns:1;2,1;4;2,1;1;rows:1;3;5;1;1,1;", "..#..;.###.;#####;..#..;.#.#.")]

        public static void JapaneseTests(string task, string expectedResult)
        {
            Assert.AreEqual(expectedResult, japanese.SolveJapanese(task));
        }
    }
}
