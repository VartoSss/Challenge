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
        [TestCase("columns:2;1;1,2;1;3;rows:1;2;3,1;1,1,1;;", "..#..;...##;###.#;#.#.#;.....")]
        [TestCase("columns:1,3;1,3;2,2;1,1,1;3,2;2,2,1;1,1;1,3,1;4,1;rows:1,1,1;5,1;1,1,2;2,6;2,1,2;5,1;1,2,2;;", "#....#.#.;.#####..#;..#.#..##;##.######;##...#.##;#####.#..;....")]
        public static void JapaneseTests(string task, string expectedResult)
        {
            Assert.AreEqual(expectedResult, Japanese.SolveJapanese(task));
        }
    }
}
