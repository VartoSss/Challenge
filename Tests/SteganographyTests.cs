using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class SteganographyTests
{
    [TestCase("V\r\nhello world\r\nno one's here\r\noh hell", "one")]
    [TestCase("IX\r\nand one more test for this peace of\r\ni don't even know what to right\r\noh i'll shape one word\r\ni think siiuuuuu won't be said by anyone because\r\nits messiiiuuuuuuu", "messi")]
    [TestCase("VIII\r\nlol lolly\r\nand again\r\nokay i pull up\r\nuuuuuiis\r\nsiiiiiiiiiuuuuuuuu\r\nwhat is it going to be\r\nahahahahahah\r\nhahahahahaha", "lipsi ha")]
    [TestCase("XIV\r\nprivet no ti prohodish mimo\r\nya spryatala ulibku\r\nmne vazhno chtobi ti uznal\r\nsecret lovimii kazhdiy ritm\r\nti mne ne beznazlichen", "putin")]
    [TestCase("XXII\r\noverheard parvati patil malfoy had been trying find how could\r\nunbroken earsplitting note ron hermione had been trying find how\r\nfinch fletchley justin hufflepuff said harry had been trying find\r\nnosebleed harry had been trying find how could see you\r\nteaching harry had been trying find how could see you\r\nsmarten yourselves i don't know who was going be able\r\nexciting about it was going be able get past fluffy\r\nring trapdoor it's not going be able get past fluffy\r\nheeled buckled boots his head boy who was going be\r\nwilling let me said harry had been trying find how\r\ncanary yellow circus tent still there was going be able", "i need that")]
    [TestCase("[H] [He] [B] [C] [N]\r\nhekhllo", "hello")]
    [TestCase("[He] [Li] [O] [F] [Ne]\r\nktilfdamon", "timon")]
    [TestCase("(21,20) (20,107) (83,21) (107,60) (60,97) (97,16) (49,0) (8,49) (16,15) (15,8)\r\nthe school must already be here but professor mcgonagall showed the first years into a small empty chamber off the", "got to eat")]
    [TestCase("(65,32) (36,99) (21,56) (99,63) (11,30) (30,28) (32,21) (63,65) (56,11) (28,0)\r\nscreamed for he had seen not only himself in the mirror but a whole crowd of people standing right behind him but the", "too slow i")]
    [TestCase("XV\r\nprune said harry had been trying find how could see\r\nsleeping bag bertie bott's every flavor beans drooble's best he\r\nfabulous jewels very good bye norbert had been trying find\r\nshuddered don't know who was going be able get past\r\nmodern magical herbs fungi by his head boy who was\r\nelastic band no said harry had been trying find how\r\nasleep almost forgotten all right said harry had been trying\r\nboarded cracks around his head boy who was going be\r\npages muttering herself before he was going be able get\r\ncauldrons all right said harry had been trying find how\r\nkitchens dudley's gang had been trying find how could see\r\nexchange mystified looks like this is it was going be\r\n'n my dear professor mcgonagall was going be able get\r\nfletchley justin hufflepuff said harry had been trying find how\r\nscurrying around his head boy who was going be able\r\nserpent covered blood his head boy who was going be\r\nshutting door open door open door open door open door\r\ncomforting harry had been trying find how could see you", "rest of gryffindor")]
    public static void SteganographyTest(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, Steganography.SolveSteganography(task));
    }
}