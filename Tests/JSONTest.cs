﻿using ConsoleApp;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests;

[TestFixture]
public class JSONTest
{
    [TestCase("{\"noncrystallizable\":\"-8\",\"tetractinelline\":\"determinant|-89 & 23 & 2 & -34 \\\\\\\\ 61 & -43 & 8 & -1 \\\\\\\\ -84 & -55 & 47 & 87 \\\\\\\\ 21 & 45 & -50 & 58\",\"tumorigenicity\":\"math|((79+61)+(4-43+44)+(74%77*26)+(18+74+89))+((93-14+68*22)+(50+61)/90+(61/90))\",\"accommodativeness\":\"determinant|-99 & -83 & -12 \\\\\\\\ -13 & 99 & -12 \\\\\\\\ 28 & -12 & 62\",\"shapy\":{\"diuturnity\":\"-74\",\"ballottines\":\"math|109-106%88%29+79%96\",\"unhymned\":\"24\",\"preantiseptic\":\"determinant|-11 & 99 & -24 \\\\\\\\ -30 & 59 & -52 \\\\\\\\ -91 & -50 & 98\",\"extramural\":\"math|27*19\"},\"poorest\":{\"scouths\":\"61\",\"handleable\":\"determinant|-12 & 52 \\\\\\\\ -85 & 62\",\"macs\":\"math|((14+15+9+9)-(16-4))/37-((14/85*0-12)/81+(51-21)+(60+71-26+81))+((17*19/56*95)*(77/17*12)-(38/59+49*100))\",\"slewing\":\"determinant|-22 & -1 & 67 \\\\\\\\ -16 & -65 & 21 \\\\\\\\ -101 & -89 & 89\",\"ejaculum\":\"21\",\"binary\":\"-98\"},\"chicaner\":{\"jaspidean\":\"-86\",\"something\":\"math|((27*37+107+36)+(108+50)+(50*30))+((108*63%32)/64-(28%57))-((47-79+26*72)/78+(18*44+22))\",\"photophoresis\":\"-90\",\"petiolulate\":\"10\"},\"plankbuilt\":{\"underranger\":\"determinant|-81 & -18 \\\\\\\\ -11 & 37\",\"underwinding\":\"math|((106-15+15-98)-(73+5/78)+(64-72+27+2)+(42+97))+((57+40+34)+(62-91-4+85)/79/46)\",\"indigestive\":\"-48\",\"dyer\":\"math|((94*86)+(16*81*84+13)*(15-38-90)/26)-((94+4*84-60)+(79-59*79*78)-(28-90)+(90+40+8))+((36+64/92-14)/59*(44+105+103)+(62-25-3))+((0+74)*(21+50+43+104)*(8-53%66)+(76+81/26+64))\",\"versor\":\"math|((44+19)+(88-2))-((57-60*105)+(56*36+66))\"},\"refillable\":{\"cryptomerous\":\"94\",\"odiometer\":\"determinant|75 & -22 \\\\\\\\ -30 & 21\",\"thurible\":\"math|((26/19)+(95-33)/71+(83*7*1%81))%56\",\"plumy\":\"determinant|102 & 27 \\\\\\\\ 21 & 52\",\"foreconceive\":\"math|97+8+41\"}}", "32")]
    [TestCase("{\"nontraditionally\":\"math|((24+106-87)+(94*17*82*45)-(103-98+58)+(12-36+17))*((19+23)-(53-30/87%44))+((71+78+27)+(19+99))-((53*26)-(86%76%102+21)+(69+54))\",\"carbonic\":\"math|2+41*11+8-26/60\",\"hemichorea\":\"math|((1-64)+(21-90+22+94))+((83-77*109)/43+(35+83*80)*(102/49-89+46))+((33*71)+(103-99)-(103-21)%54)+((36+72+22+41)+(2+93)*(78+45+15))\",\"poloniums\":\"math|81*54-17*4+90\",\"calamitousness\":\"math|97*0-12*99\",\"doxy\":{\"epeeist\":\"math|((26+71*3+42)+(4/8+46+67)/13)/7-((22+39-107)+(33+11))%99\",\"inspoken\":\"math|((93*15+50)-(33/63+12-1))+((87-82+60-82)-(97-28)%27)\",\"districts\":\"math|((107/34)-(84%11))-((60*85)%45/9)+((60%83-19)+(72+53))\",\"sumpit\":\"math|((29+67*102)*(62%7+18/99))%35\",\"zingiberol\":\"math|11+26+40-81*57\"},\"seldseen\":{\"sharon\":\"math|((7-84-82-93)-(101/80)+(46/74-8)+(73-86-23))+((97+74+91-35)+(31%52))\",\"chirper\":\"math|36-61%19+105\",\"turken\":\"math|((73%39)-(21*55/85)*(70+104+57*45)+(49-37+11+60))+((54/17)/29)%10+((15+100)+(8-52)+(6+103/18))\",\"transposableness\":\"math|((100*78/75*88)+(104-83)+(68/19-104)-(25+22/76+32))+((18/46)+(50%44))/63\"},\"policeless\":{\"eavedrop\":\"math|((34+32%74)+(92/97+105+65))+((91+7)-(2-48*31)%103+(45+1))\",\"orthodoxically\":\"math|22/104+6+78+53+105\",\"squeaks\":\"math|10%83\",\"textuist\":\"math|((64+42+89)-(69%13+48-10))*((96-74+74-31)%39)%83\"},\"hypohyaline\":{\"decolourisation\":\"math|40/59\",\"meow\":\"math|((94*71+95*77)*(44*88))+((108+100)*(42-100-27+77)+(107+68))\",\"stope\":\"math|((43-5)*(43%21*103-93))/51+((83+31+70+74)+(74*75)*(105*96+54)*(50*59))\",\"exiling\":\"math|((107%34*77)-(58*48*3+97))%3*((7+73)*(75-89+22)-(96+71*10-47))\"},\"bacteriuria\":{\"acridinium\":\"math|98*109-11\",\"reascension\":\"math|73%36/45\",\"paleate\":\"math|94*88+39+78+45+64\",\"favelloid\":\"math|((96+20+20-106)+(23/59+22))-((32+21*26)-(43/96-93*59))+((109*21+87)/67%94%75)\",\"bulbs\":\"math|26+14-103+19*80*10\"},\"diminutal\":{\"heep\":\"math|42/40\",\"theophrastan\":\"math|34+55*90+45\",\"osteohalisteresis\":\"math|14+96/81\",\"colorableness\":\"math|29/80\",\"insignes\":\"math|((21*74)+(0-25)-(11+79+90))+((18/107/24+30)+(45*52+61)+(10+24))+((23+98-61)-(52%89*70+95))+((58+50%92+54)+(10-64-2/19)%55+(29+3+106))\"}}", "1")]
    [TestCase("{\"homeling\":\"math|((104-83+36)+(27+35+25/102)+(81*51%45))-((2*92/94/33)-(101+29-38)-(89+1))/6\",\"fatbacks\":\"math|((41-72+36)-(88*45)+(104+33/5+94)/1)/54%97\",\"extraperineal\":\"string-number|four\",\"costermonger\":\"math|((84+4)+(78-5*38))/91\",\"kartvel\":\"string-number|zero\",\"trisodium\":{\"recusation\":\"determinant|-64 & 34 & -99 & 85 \\\\\\\\ 62 & -1 & 31 & -108 \\\\\\\\ 49 & 56 & -14 & -44 \\\\\\\\ 24 & -76 & -21 & -103\",\"flimflammer\":\"math|3-59%57\",\"cloudiest\":\"determinant|99 & 29 \\\\\\\\ 103 & -52\",\"ektodynamorphic\":\"64\"},\"civilizational\":{\"unstatuesquely\":\"cypher|#Caesar's code=2#abc=ensv#esnsv#\",\"rhizomorph\":\"cypher|#Caesar's code=3#abc=ensv#nvsve#\",\"preceptorship\":\"math|((69+97)+(38+29+11))+((20+9)/26+(58%95+93-68)/26)/94*((34*106)-(103/85+67+40)/3/73)\",\"antimissionary\":\"determinant|95 & -39 \\\\\\\\ -98 & 15\",\"unhyphenated\":\"cypher|#Caesar's code=3#abc=eorz#rzoe#\"},\"overviolent\":{\"lobscouser\":\"65\",\"periphytic\":\"-70\",\"headwords\":\"string-number|three\",\"saccharolytic\":\"math|((55-55)+(32*104-107/36)*(84*80)-(43+47/40))-((72%94+48)*(4+92/74)+(64+102-77/106)-(52+2/48))%7-((22%48%28-35)+(43-40)-(0+62*32-14)+(86%66))\",\"knitster\":\"determinant|16 & 46 & 4 \\\\\\\\ 49 & 103 & 69 \\\\\\\\ 17 & 85 & -51\",\"hegemonistic\":\"13\"},\"haemostat\":{\"unchapleted\":\"determinant|-18 & 99 & -82 & -33 \\\\\\\\ -6 & -103 & 38 & -40 \\\\\\\\ 12 & -52 & -74 & 28 \\\\\\\\ 89 & 22 & -23 & -16\",\"breeching\":\"63\",\"auxochromic\":\"cypher|#Caesar's code=-3#abc=ehrt#erthh#\",\"partless\":\"math|34+18-37+78/54\",\"patriarchist\":\"math|2/69+53/86%47\"},\"paraquet\":{\"myosalpingitis\":\"46\",\"cohorn\":\"determinant|30 & 19 & -44 \\\\\\\\ 50 & 105 & -69 \\\\\\\\ 53 & -36 & -41\",\"calfhood\":\"math|59*46\",\"narco\":\"string-number|five\",\"unblinkingly\":\"math|14-83+42/90\",\"kionotomies\":\"cypher|#Caesar's code=2#abc=foru#ruof#\"},\"kitchenful\":{\"picturableness\":\"string-number|zero\",\"cartridge\":\"determinant|-19 & 68 & -102 & -32 \\\\\\\\ 47 & -48 & -79 & -77 \\\\\\\\ -58 & 7 & -3 & 95 \\\\\\\\ 54 & -30 & -8 & 93\",\"unsingableness\":\"math|62*1\",\"exult\":\"string-number|six\",\"unangularly\":\"string-number|seven\",\"monotheletism\":\"36\"}}", "184")]
    [TestCase("{\"homeling\":\"cypher|#Caesar's code=2#abc=ensv#esnsv#\"", "7")]
    [TestCase("{\"brainwashers\":\"cypher|#Vigenere's code=ufrufuu#abc=foru#uooo#\"", "4")]
    public static void JSONTests(string task, string expectedResult)
    {
        Assert.AreEqual(expectedResult, json.SolveCommonJSON(task));
    }
}
