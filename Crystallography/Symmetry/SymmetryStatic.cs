﻿using System;
using System.Collections.Generic;
using System.Linq;
using SO = Crystallography.SymmetryOperation;

namespace Crystallography;

/// <summary>
/// SymmetryStaticクラス 空間群に関する静的な情報を提供する
/// </summary>
public static class SymmetryStatic
{
    #region const 定数
    private const double d12 = 1.0 / 2.0, d13 = 1.0 / 3.0, d14 = 1.0 / 4.0, d34 = 3.0 / 4.0, d23 = 2.0 / 3.0, d16 = 1.0 / 6.0, d56 = 5.0 / 6.0;
    private const double d18 = 1.0 / 8.0, d38 = 3.0 / 8.0, d58 = 5.0 / 8.0, d78 = 7.0 / 8.0;
    private const double d1_12 = 1.0 / 12.0, d5_12 = 5.0 / 12.0, d7_12 = 7.0 / 12.0, d11_12 = 11.0 / 12.0;
    private const string m = "monoclinic", t = "triclinic", o = "orthorhombic", te = "tetragonal", tr = "trigonal", c = "cubic", h = "hexagonal";
    /// <summary>
    /// 原子の等価位置を判定する閾値 (単位は単位格子の分率)
    /// </summary>
    public const double Th = 0.0001;
    #endregion

    #region　static fields
    public static readonly ushort[][][] PositionsDictionary = new ushort[][][]
        {
				#region positions
//0 unk
new ushort[][]{ new ushort[]{ 915}},
//1 P 1
new ushort[][]{ new ushort[]{ 915}},
//2 P -1
new ushort[][]{
 new ushort[]{ 915, 922 },
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//3 P 1 2 1
new ushort[][]{
 new ushort[]{ 915, 920 },
 new ushort[]{ 236},
 new ushort[]{ 234},
 new ushort[]{ 104},
 new ushort[]{ 102}},
//4 P 1 1 2
new ushort[][]{
 new ushort[]{ 915, 921 },
 new ushort[]{ 175},
 new ushort[]{ 30 },
 new ushort[]{ 153},
 new ushort[]{ 10 }},
//5 P 2 1 1
new ushort[][]{
 new ushort[]{ 915, 918 },
 new ushort[]{ 692},
 new ushort[]{ 672},
 new ushort[]{ 690},
 new ushort[]{ 670}},
//6 P 1 2sub1 1
new ushort[][]{
 new ushort[]{ 915, 942 }},
//7 P 1 1 2sub1
new ushort[][]{
 new ushort[]{ 915, 928 }},
//8 P 2sub1 1 1
new ushort[][]{
 new ushort[]{ 915, 1142 }},
//9 C 1 2 1
new ushort[][]{
 new ushort[]{ 915, 920 },
 new ushort[]{ 104},
 new ushort[]{ 102}},
//10 A 1 2 1
new ushort[][]{ new ushort[]{ 915, 920 },
 new ushort[]{ 234},
 new ushort[]{ 102}},
//11 I 1 2 1
new ushort[][]{ new ushort[]{ 915, 920 },
 new ushort[]{ 234},
 new ushort[]{ 102}},
//12 A 1 1 2
new ushort[][]{ new ushort[]{ 915, 921 },
 new ushort[]{ 153},
 new ushort[]{ 10 }},
//13 B 1 1 2
new ushort[][]{ new ushort[]{ 915, 921 },
 new ushort[]{ 30 },
 new ushort[]{ 10 }},
//14 I 1 1 2
new ushort[][]{ new ushort[]{ 915, 921 },
 new ushort[]{ 30 },
 new ushort[]{ 10 }},
//15 B 2 1 1
new ushort[][]{ new ushort[]{ 915, 918 },
 new ushort[]{ 690},
 new ushort[]{ 670}},
//16 C 2 1 1
new ushort[][]{ new ushort[]{ 915, 918 },
 new ushort[]{ 672},
 new ushort[]{ 670}},
//17 I 2 1 1
new ushort[][]{ new ushort[]{ 915, 918 },
 new ushort[]{ 672},
 new ushort[]{ 670}},
//18 P 1 m 1
new ushort[][]{ new ushort[]{ 915, 917 },
 new ushort[]{ 700},
 new ushort[]{ 684}},
//19 P 1 1 m
new ushort[][]{ new ushort[]{ 915, 916 },
 new ushort[]{ 903},
 new ushort[]{ 899}},
//20 P m 1 1
new ushort[][]{ new ushort[]{ 915, 919 },
 new ushort[]{ 248},
 new ushort[]{ 116}},
//21 P 1 c 1
new ushort[][]{ new ushort[]{ 915, 924 }},
//22 P 1 n 1
new ushort[][]{ new ushort[]{ 915, 1147 }},
//23 P 1 a 1
new ushort[][]{ new ushort[]{ 915, 1141 }},
//24 P 1 1 a
new ushort[][]{ new ushort[]{ 915, 1140 }},
//25 P 1 1 n
new ushort[][]{ new ushort[]{ 915, 1165 }},
//26 P 1 1 b
new ushort[][]{ new ushort[]{ 915, 926 }},
//27 P b 1 1
new ushort[][]{ new ushort[]{ 915, 941 }},
//28 P n 1 1
new ushort[][]{ new ushort[]{ 915, 947 }},
//29 P c 1 1
new ushort[][]{ new ushort[]{ 915, 926 }},
//30 C 1 m 1
new ushort[][]{ new ushort[]{ 915, 917 },
 new ushort[]{ 684}},
//31 A 1 m 1
new ushort[][]{ new ushort[]{ 915, 917 },
 new ushort[]{ 684}},
//32 I 1 m 1
new ushort[][]{
 new ushort[]{ 915, 917 },
 new ushort[]{ 684}},
//33 A 1 1 m
new ushort[][]{
 new ushort[]{ 915, 916 },
 new ushort[]{ 899}},
//34 B 1 1 m
new ushort[][]{
 new ushort[]{ 915, 916 },
 new ushort[]{ 899}},
//35 I 1 1 m
new ushort[][]{
 new ushort[]{ 915, 916 },
 new ushort[]{ 899}},
//36 B m 1 1
new ushort[][]{
 new ushort[]{ 915, 919 },
 new ushort[]{ 116}},
//37 C m 1 1
new ushort[][]{
 new ushort[]{ 915, 919 },
 new ushort[]{ 116}},
//38 I m 1 1
new ushort[][]{
 new ushort[]{ 915, 919 },
 new ushort[]{ 116}},
//39 C 1 c 1
new ushort[][]{ new ushort[]{ 915, 924 }},
//40 A 1 n 1
new ushort[][]{ new ushort[]{ 915, 1147 }},
//41 I 1 a 1
new ushort[][]{ new ushort[]{ 915, 1141 }},
//42 A 1 a 1
new ushort[][]{ new ushort[]{ 915, 1141 }},
//43 C 1 n 1
new ushort[][]{ new ushort[]{ 915, 1147 }},
//44 I 1 c 1
new ushort[][]{ new ushort[]{ 915, 924 }},
//45 A 1 1 a
new ushort[][]{ new ushort[]{ 915, 1140 }},
//46 B 1 1 n
new ushort[][]{ new ushort[]{ 915, 1165 }},
//47 I 1 1 b
new ushort[][]{ new ushort[]{ 915, 938 }},
//48 B 1 1 b
new ushort[][]{ new ushort[]{ 915, 938 }},
//49 A 1 1 n
new ushort[][]{ new ushort[]{ 915, 1165 }},
//50 I 1 1 a
new ushort[][]{ new ushort[]{ 915, 1140 }},
//51 B b 1 1
new ushort[][]{ new ushort[]{ 915, 941 }},
//52 C n 1 1
new ushort[][]{ new ushort[]{ 915, 947 }},
//53 I c 1 1
new ushort[][]{ new ushort[]{ 915, 926 }},
//54 C c 1 1
new ushort[][]{ new ushort[]{ 915, 926 }},
//55 B n 1 1
new ushort[][]{ new ushort[]{ 915, 947 }},
//56 I b 1 1
new ushort[][]{ new ushort[]{ 915, 941 }},
//57 P 1 2/m 1
new ushort[][]{
 new ushort[]{ 915, 920, 922, 917 },
 new ushort[]{ 700, 703 },
 new ushort[]{ 684, 687 },
 new ushort[]{ 236, 237 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 164},
 new ushort[]{ 146},
 new ushort[]{ 19 },
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 1 },
 new ushort[]{ 18 },
 new ushort[]{ 0 }},
//58 P 1 1 2/m
new ushort[][]{
 new ushort[]{ 915, 921, 922, 916 },
 new ushort[]{ 903, 906 },
 new ushort[]{ 899, 902 },
 new ushort[]{ 175, 176 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 164},
 new ushort[]{ 163},
 new ushort[]{ 146},
 new ushort[]{ 19 },
 new ushort[]{ 18 },
 new ushort[]{ 145},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//59 P 2/m 1 1
new ushort[][]{
 new ushort[]{ 915, 918, 922, 919 },
 new ushort[]{ 248, 251 },
 new ushort[]{ 116, 119 },
 new ushort[]{ 692, 693 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 163},
 new ushort[]{ 146},
 new ushort[]{ 1 },
 new ushort[]{ 18 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//60 P 1 2sub1/m 1
new ushort[][]{
 new ushort[]{ 915, 942, 922, 939 },
 new ushort[]{ 717, 754 },
 new ushort[]{ 146, 164 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 }},
//61 P 1 1 2sub1/m
new ushort[][]{
 new ushort[]{ 915, 928, 922, 923 },
 new ushort[]{ 907, 914 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 }},
//62 P 2sub1/m 1 1
new ushort[][]{
 new ushort[]{ 915, 1142, 922, 1143 },
 new ushort[]{ 384, 567 },
 new ushort[]{ 19, 164 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 }},
//63 C 1 2/m 1
new ushort[][]{
 new ushort[]{ 915, 920, 922, 917 },
 new ushort[]{ 684, 687 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 313, 496 },
 new ushort[]{ 312, 495 },
 new ushort[]{ 19 },
 new ushort[]{ 1 },
 new ushort[]{ 18 },
 new ushort[]{ 0 }},
//64 A 1 2/m 1
new ushort[][]{
 new ushort[]{ 915, 920, 922, 917 },
 new ushort[]{ 684, 687 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 185, 187 },
 new ushort[]{ 43, 45 },
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 0 }},
//65 I 1 2/m 1
new ushort[][]{
 new ushort[]{ 915, 920, 922, 917 },
 new ushort[]{ 684, 687 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 315, 497 },
 new ushort[]{ 314, 498 },
 new ushort[]{ 19 },
 new ushort[]{ 1 },
 new ushort[]{ 18 },
 new ushort[]{ 0 }},
//66 A 1 1 2/m
new ushort[][]{
 new ushort[]{ 915, 921, 922, 916 },
 new ushort[]{ 899, 902 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 185, 200 },
 new ushort[]{ 43, 60 },
 new ushort[]{ 146},
 new ushort[]{ 145},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//67 B 1 1 2/m
new ushort[][]{
 new ushort[]{ 915, 921, 922, 916 },
 new ushort[]{ 899, 902 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 306, 487 },
 new ushort[]{ 298, 477 },
 new ushort[]{ 19 },
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//68 I 1 1 2/m
new ushort[][]{
 new ushort[]{ 915, 921, 922, 916 },
 new ushort[]{ 899, 902 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 497, 331 },
 new ushort[]{ 314, 511 },
 new ushort[]{ 146},
 new ushort[]{ 145},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//69 B 2/m 1 1
new ushort[][]{
 new ushort[]{ 915, 918, 922, 919 },
 new ushort[]{ 116, 119 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 306, 307 },
 new ushort[]{ 298, 299 },
 new ushort[]{ 163},
 new ushort[]{ 18 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//70 C 2/m 1 1
new ushort[][]{
 new ushort[]{ 915, 918, 922, 919 },
 new ushort[]{ 116, 119 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 313, 330 },
 new ushort[]{ 312, 329 },
 new ushort[]{ 146},
 new ushort[]{ 1 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//71 I 2/m 1 1
new ushort[][]{
 new ushort[]{ 915, 918, 922, 919 },
 new ushort[]{ 116, 119 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 331, 315 },
 new ushort[]{ 314, 332 },
 new ushort[]{ 163},
 new ushort[]{ 18 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//72 P 1 2/c 1
new ushort[][]{
 new ushort[]{ 915, 927, 922, 924 },
 new ushort[]{ 238, 241 },
 new ushort[]{ 106, 109 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 }},
//73 P 1 2/n 1
new ushort[][]{
 new ushort[]{ 915, 1150, 922, 1147 },
 new ushort[]{ 551, 375 },
 new ushort[]{ 371, 554 },
 new ushort[]{ 145, 1 },
 new ushort[]{ 18, 164 },
 new ushort[]{ 163, 19 },
 new ushort[]{ 0, 146 }},
//74 P 1 2/a 1
new ushort[][]{
 new ushort[]{ 915, 1144, 922, 1141 },
 new ushort[]{ 549, 370 },
 new ushort[]{ 547, 368 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 19, 164 },
 new ushort[]{ 0, 145 }},
//75 P 1 1 2/a
new ushort[][]{
 new ushort[]{ 915, 1145, 922, 1140 },
 new ushort[]{ 308, 492 },
 new ushort[]{ 300, 482 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 19, 164 },
 new ushort[]{ 0, 145 }},
//76 P 1 1 2/n
new ushort[][]{
 new ushort[]{ 915, 1170, 922, 1165 },
 new ushort[]{ 338, 505 },
 new ushort[]{ 322, 517 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 19, 146 },
 new ushort[]{ 0, 163 }},
//77 P 1 1 2/b
new ushort[][]{
 new ushort[]{ 915, 943, 922, 938 },
 new ushort[]{ 204, 194 },
 new ushort[]{ 69, 54 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 146, 164 },
 new ushort[]{ 0, 18 }},
//78 P 2/b 1 1
new ushort[][]{
 new ushort[]{ 915, 940, 922, 941 },
 new ushort[]{ 709, 745 },
 new ushort[]{ 707, 743 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 146, 164 },
 new ushort[]{ 0, 18 }},
//79 P 2/n 1 1
new ushort[][]{
 new ushort[]{ 915, 946, 922, 947 },
 new ushort[]{ 715, 747 },
 new ushort[]{ 711, 750 },
 new ushort[]{ 1, 18 },
 new ushort[]{ 145, 164 },
 new ushort[]{ 146, 163 },
 new ushort[]{ 0, 19 }},
//80 P 2/c 1 1
new ushort[][]{
 new ushort[]{ 915, 925, 922, 926 },
 new ushort[]{ 696, 695 },
 new ushort[]{ 679, 676 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 }},
//81 P 1 2sub1/c 1
new ushort[][]{
 new ushort[]{ 915, 948, 922, 945 },
 new ushort[]{ 146, 163 },
 new ushort[]{ 1, 18 },
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//82 P 1 2sub1/n 1
new ushort[][]{
 new ushort[]{ 915, 1176, 922, 1173 },
 new ushort[]{ 1, 163 },
 new ushort[]{ 146, 18 },
 new ushort[]{ 145, 19 },
 new ushort[]{ 0, 164 }},
//83 P 1 2sub1/a 1
new ushort[][]{
 new ushort[]{ 915, 1169, 922, 1166 },
 new ushort[]{ 146, 19 },
 new ushort[]{ 145, 18 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//84 P 1 1 2sub1/a
new ushort[][]{
 new ushort[]{ 915, 1151, 922, 1146 },
 new ushort[]{ 163, 19 },
 new ushort[]{ 145, 1 },
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//85 P 1 1 2sub1/n
new ushort[][]{
 new ushort[]{ 915, 1177, 922, 1172 },
 new ushort[]{ 145, 19 },
 new ushort[]{ 163, 1 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 0, 164 }},
//86 P 1 1 2sub1/b
new ushort[][]{
 new ushort[]{ 915, 949, 922, 944 },
 new ushort[]{ 163, 146 },
 new ushort[]{ 18, 1 },
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//87 P 2sub1/b 1 1
new ushort[][]{
 new ushort[]{ 915, 1167, 922, 1168 },
 new ushort[]{ 19, 146 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//88 P 2sub1/n 1 1
new ushort[][]{
 new ushort[]{ 915, 1174, 922, 1175 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 19, 145 },
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//89 P 2sub1/c 1 1
new ushort[][]{
 new ushort[]{ 915, 1148, 922, 1149 },
 new ushort[]{ 19, 163 },
 new ushort[]{ 1, 145 },
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//90 C 1 2/c 1
new ushort[][]{
 new ushort[]{ 915, 927, 922, 924 },
 new ushort[]{ 106, 109 },
 new ushort[]{ 313, 495 },
 new ushort[]{ 312, 496 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 }},
//91 A 1 2/n 1
new ushort[][]{
 new ushort[]{ 915, 1150, 922, 1147 },
 new ushort[]{ 371, 554 },
 new ushort[]{ 201, 62 },
 new ushort[]{ 60, 200 },
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//92 I 1 2/a 1
new ushort[][]{
 new ushort[]{ 915, 1144, 922, 1141 },
 new ushort[]{ 367, 548 },
 new ushort[]{ 511, 512 },
 new ushort[]{ 331, 332 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 0, 145 }},
//93 A 1 2/a 1
new ushort[][]{
 new ushort[]{ 915, 1144, 922, 1141 },
 new ushort[]{ 547, 368 },
 new ushort[]{ 185, 45 },
 new ushort[]{ 43, 187 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 0, 145 }},
//94 C 1 2/n 1
new ushort[][]{
 new ushort[]{ 915, 1150, 922, 1147 },
 new ushort[]{ 371, 554 },
 new ushort[]{ 496, 495 },
 new ushort[]{ 312, 313 },
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//95 I 1 2/c 1
new ushort[][]{
 new ushort[]{ 915, 927, 922, 924 },
 new ushort[]{ 106, 109 },
 new ushort[]{ 315, 498 },
 new ushort[]{ 314, 497 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 }},
//96 A 1 1 2/a
new ushort[][]{
 new ushort[]{ 915, 1145, 922, 1140 },
 new ushort[]{ 300, 482 },
 new ushort[]{ 185, 60 },
 new ushort[]{ 43, 200 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 }},
//97 B 1 1 2/n
new ushort[][]{
 new ushort[]{ 915, 1170, 922, 1165 },
 new ushort[]{ 322, 517 },
 new ushort[]{ 488, 478 },
 new ushort[]{ 299, 307 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//98 I 1 1 2/b
new ushort[][]{
 new ushort[]{ 915, 943, 922, 938 },
 new ushort[]{ 53, 70 },
 new ushort[]{ 332, 512 },
 new ushort[]{ 315, 498 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 0, 18 }},
//99 B 1 1 2/b
new ushort[][]{
 new ushort[]{ 915, 943, 922, 938 },
 new ushort[]{ 69, 54 },
 new ushort[]{ 306, 477 },
 new ushort[]{ 298, 487 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 0, 18 }},
//100 A 1 1 2/n
new ushort[][]{
 new ushort[]{ 915, 1170, 922, 1165 },
 new ushort[]{ 322, 517 },
 new ushort[]{ 200, 60 },
 new ushort[]{ 43, 185 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//101 I 1 1 2/a
new ushort[][]{
 new ushort[]{ 915, 1145, 922, 1140 },
 new ushort[]{ 300, 482 },
 new ushort[]{ 497, 511 },
 new ushort[]{ 314, 331 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 }},
//102 B 2/b 1 1
new ushort[][]{
 new ushort[]{ 915, 940, 922, 941 },
 new ushort[]{ 707, 743 },
 new ushort[]{ 306, 299 },
 new ushort[]{ 298, 307 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 }},
//103 C 2/n 1 1
new ushort[][]{
 new ushort[]{ 915, 946, 922, 947 },
 new ushort[]{ 711, 750 },
 new ushort[]{ 510, 509 },
 new ushort[]{ 495, 496 },
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//104 I 2/c 1 1
new ushort[][]{
 new ushort[]{ 915, 925, 922, 926 },
 new ushort[]{ 675, 680 },
 new ushort[]{ 498, 512 },
 new ushort[]{ 497, 511 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 0, 1 }},
//105 C 2/c 1 1
new ushort[][]{
 new ushort[]{ 915, 925, 922, 926 },
 new ushort[]{ 679, 676 },
 new ushort[]{ 313, 329 },
 new ushort[]{ 312, 330 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 0, 1 }},
//106 B 2/n 1 1
new ushort[][]{
 new ushort[]{ 915, 946, 922, 947 },
 new ushort[]{ 711, 750 },
 new ushort[]{ 307, 299 },
 new ushort[]{ 298, 306 },
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//107 I 2/b 1 1
new ushort[][]{
 new ushort[]{ 915, 940, 922, 941 },
 new ushort[]{ 707, 743 },
 new ushort[]{ 331, 332 },
 new ushort[]{ 314, 315 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 }},
//108 P 2 2 2
new ushort[][]{
 new ushort[]{ 915, 921, 920, 918 },
 new ushort[]{ 175, 176 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 236, 237 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 692, 693 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 18 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//109 P 2 2 2sub1
new ushort[][]{
 new ushort[]{ 915, 928, 927, 918 },
 new ushort[]{ 238, 241 },
 new ushort[]{ 106, 109 },
 new ushort[]{ 690, 693 },
 new ushort[]{ 670, 673 }},
//110 P 2sub1 2 2
new ushort[][]{
 new ushort[]{ 915, 1142, 1145, 920 },
 new ushort[]{ 308, 492 },
 new ushort[]{ 300, 482 },
 new ushort[]{ 104, 237 },
 new ushort[]{ 102, 235 }},
//111 P 2 2sub1 2
new ushort[][]{
 new ushort[]{ 915, 942, 940, 921 },
 new ushort[]{ 709, 745 },
 new ushort[]{ 707, 743 },
 new ushort[]{ 153, 176 },
 new ushort[]{ 10, 31 }},
//112 P 2sub1 2sub1 2
new ushort[][]{
 new ushort[]{ 915, 921, 1169, 1167 },
 new ushort[]{ 30, 154 },
 new ushort[]{ 10, 176 }},
//113 P 2 2sub1 2sub1
new ushort[][]{
 new ushort[]{ 915, 918, 949, 948 },
 new ushort[]{ 672, 691 },
 new ushort[]{ 670, 693 }},
//114 P 2sub1 2 2sub1
new ushort[][]{
 new ushort[]{ 915, 920, 1148, 1151},
 new ushort[]{ 234, 105 },
 new ushort[]{ 102, 237 }},
//115 P 2sub1 2sub1 2sub1
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167}},
//116 C 2 2 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 927, 918},
 new ushort[]{ 106, 109 },
 new ushort[]{ 670, 673 }},
//117 A 2sub1 2 2
new ushort[][]{ new ushort[]{ 915, 1142, 1145, 920},
 new ushort[]{ 300, 482 },
 new ushort[]{ 102, 235 }},
//118 B 2 2sub1 2
new ushort[][]{ new ushort[]{ 915, 942, 940, 921},
 new ushort[]{ 707, 743 },
 new ushort[]{ 10, 31 }},
//119 C 2 2 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918},
 new ushort[]{ 322, 505 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 1 },
 new ushort[]{ 146},
 new ushort[]{ 18 },
 new ushort[]{ 0 }},
//120 A 2 2 2
new ushort[][]{ new ushort[]{ 915, 918, 921, 920},
 new ushort[]{ 711, 747 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 145},
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//121 B 2 2 2
new ushort[][]{ new ushort[]{ 915, 920, 918, 921},
 new ushort[]{ 371, 375 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 18 },
 new ushort[]{ 19 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//122 F 2 2 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918},
 new ushort[]{ 711, 747 },
 new ushort[]{ 371, 552 },
 new ushort[]{ 322, 505 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 315},
 new ushort[]{ 314},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//123 I 2 2 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918},
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//124 I 2sub1 2sub1 2sub1
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167},
 new ushort[]{ 53, 72 },
 new ushort[]{ 367, 370 },
 new ushort[]{ 675, 995 }},
//125 P m m 2
new ushort[][]{ new ushort[]{ 915, 921, 917, 919},
 new ushort[]{ 248, 250 },
 new ushort[]{ 116, 118 },
 new ushort[]{ 700, 702 },
 new ushort[]{ 684, 686 },
 new ushort[]{ 175},
 new ushort[]{ 153},
 new ushort[]{ 30 },
 new ushort[]{ 10 }},
//126 P 2 m m
new ushort[][]{ new ushort[]{ 915, 918, 916, 917},
 new ushort[]{ 700, 701 },
 new ushort[]{ 684, 685 },
 new ushort[]{ 903, 904 },
 new ushort[]{ 899, 900 },
 new ushort[]{ 692},
 new ushort[]{ 690},
 new ushort[]{ 672},
 new ushort[]{ 670}},
//127 P m 2 m
new ushort[][]{ new ushort[]{ 915, 920, 919, 916},
 new ushort[]{ 903, 905 },
 new ushort[]{ 899, 901 },
 new ushort[]{ 248, 249 },
 new ushort[]{ 116, 117 },
 new ushort[]{ 236},
 new ushort[]{ 104},
 new ushort[]{ 234},
 new ushort[]{ 102}},
//128 P m c 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 924, 919},
 new ushort[]{ 248, 253 },
 new ushort[]{ 116, 121 }},
//129 P c m 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 926, 917},
 new ushort[]{ 700, 705 },
 new ushort[]{ 684, 689 }},
//130 P 2sub1 m a
new ushort[][]{ new ushort[]{ 915, 1142, 1140, 917},
 new ushort[]{ 700, 1008 },
 new ushort[]{ 684, 996 }},
//131 P 2sub1 a m
new ushort[][]{ new ushort[]{ 915, 1142, 1141, 916},
 new ushort[]{ 903, 1135 },
 new ushort[]{ 899, 1133 }},
//132 P b 2sub1 m
new ushort[][]{ new ushort[]{ 915, 942, 941, 916},
 new ushort[]{ 903, 932 },
 new ushort[]{ 899, 930 }},
//133 P m 2sub1 b
new ushort[][]{ new ushort[]{ 915, 942, 938, 919},
 new ushort[]{ 248, 272 },
 new ushort[]{ 116, 134 }},
//134 P c c 2
new ushort[][]{ new ushort[]{ 915, 921, 924, 926},
 new ushort[]{ 175, 177 },
 new ushort[]{ 153, 155 },
 new ushort[]{ 30, 32 },
 new ushort[]{ 10, 12 }},
//135 P 2 a a
new ushort[][]{ new ushort[]{ 915, 918, 1140, 1141},
 new ushort[]{ 692, 1002 },
 new ushort[]{ 690, 1000 },
 new ushort[]{ 672, 990 },
 new ushort[]{ 670, 988 }},
//136 P b 2 b
new ushort[][]{ new ushort[]{ 915, 920, 941, 938},
 new ushort[]{ 236, 258 },
 new ushort[]{ 104, 124 },
 new ushort[]{ 234, 256 },
 new ushort[]{ 102, 122 }},
//137 P m a 2
new ushort[][]{ new ushort[]{ 915, 921, 1141, 1143},
 new ushort[]{ 384, 566 },
 new ushort[]{ 30, 175 },
 new ushort[]{ 10, 153 }},
//138 P b m 2
new ushort[][]{ new ushort[]{ 915, 921, 941, 939},
 new ushort[]{ 717, 753 },
 new ushort[]{ 153, 175 },
 new ushort[]{ 10, 30 }},
//139 P 2 m b
new ushort[][]{ new ushort[]{ 915, 918, 938, 939},
 new ushort[]{ 717, 752 },
 new ushort[]{ 672, 692 },
 new ushort[]{ 670, 690 }},
//140 P 2 c m
new ushort[][]{ new ushort[]{ 915, 918, 924, 923},
 new ushort[]{ 907, 912 },
 new ushort[]{ 690, 692 },
 new ushort[]{ 670, 672 }},
//141 P c 2 m
new ushort[][]{ new ushort[]{ 915, 920, 926, 923},
 new ushort[]{ 907, 913 },
 new ushort[]{ 234, 236 },
 new ushort[]{ 102, 104 }},
//142 P m 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1140, 1143},
 new ushort[]{ 384, 565 },
 new ushort[]{ 104, 236 },
 new ushort[]{ 102, 234 }},
//143 P c a 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 1141, 1149}},
//144 P b c 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 941, 945}},
//145 P 2sub1 a b
new ushort[][]{ new ushort[]{ 915, 1142, 938, 1166}},
//146 P 2sub1 c a
new ushort[][]{ new ushort[]{ 915, 1142, 924, 1146}},
//147 P c 2sub1 b
new ushort[][]{ new ushort[]{ 915, 942, 926, 944}},
//148 P b 2sub1 a
new ushort[][]{ new ushort[]{ 915, 942, 1140, 1168}},
//149 P n c 2
new ushort[][]{ new ushort[]{ 915, 921, 945, 947},
 new ushort[]{ 153, 177 },
 new ushort[]{ 10, 32 }},
//150 P c n 2
new ushort[][]{ new ushort[]{ 915, 921, 1149, 1147},
 new ushort[]{ 30, 177 },
 new ushort[]{ 10, 155 }},
//151 P 2 n a
new ushort[][]{ new ushort[]{ 915, 918, 1146, 1147},
 new ushort[]{ 690, 1002 },
 new ushort[]{ 670, 990 }},
//152 P 2 a n
new ushort[][]{ new ushort[]{ 915, 918, 1166, 1165},
 new ushort[]{ 672, 1002 },
 new ushort[]{ 670, 1000 }},
//153 P b 2 n
new ushort[][]{ new ushort[]{ 915, 920, 1168, 1165},
 new ushort[]{ 104, 258 },
 new ushort[]{ 102, 256 }},
//154 P n 2 b
new ushort[][]{ new ushort[]{ 915, 920, 944, 947},
 new ushort[]{ 234, 258 },
 new ushort[]{ 102, 124 }},
//155 P m n 2sub1
new ushort[][]{ new ushort[]{ 915, 1151, 1147, 919},
 new ushort[]{ 116, 253 }},
//156 P n m 2sub1
new ushort[][]{ new ushort[]{ 915, 949, 947, 917},
 new ushort[]{ 684, 705 }},
//157 P 2sub1 m n
new ushort[][]{ new ushort[]{ 915, 1167, 1165, 917},
 new ushort[]{ 684, 1008 }},
//158 P 2sub1 n m
new ushort[][]{ new ushort[]{ 915, 1148, 1147, 916},
 new ushort[]{ 899, 1135 }},
//159 P n 2sub1 m
new ushort[][]{ new ushort[]{ 915, 948, 947, 916},
 new ushort[]{ 899, 932 }},
//160 P m 2sub1 n
new ushort[][]{ new ushort[]{ 915, 1169, 1165, 919},
 new ushort[]{ 116, 272 }},
//161 P b a 2
new ushort[][]{ new ushort[]{ 915, 921, 1166, 1168},
 new ushort[]{ 30, 153 },
 new ushort[]{ 10, 175 }},
//162 P 2 c b
new ushort[][]{ new ushort[]{ 915, 918, 944, 945},
 new ushort[]{ 672, 690 },
 new ushort[]{ 670, 692 }},
//163 P c 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1149, 1146},
 new ushort[]{ 234, 104 },
 new ushort[]{ 102, 236 }},
//164 P n a 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 1166, 1175}},
//165 P b n 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 1168, 1173}},
//166 P 2sub1 n b
new ushort[][]{ new ushort[]{ 915, 1142, 944, 1173}},
//167 P 2sub1 c n
new ushort[][]{ new ushort[]{ 915, 1142, 945, 1172}},
//168 P c 2sub1 n
new ushort[][]{ new ushort[]{ 915, 942, 1149, 1172}},
//169 P n 2sub1 a
new ushort[][]{ new ushort[]{ 915, 942, 1146, 1175}},
//170 P n n 2
new ushort[][]{ new ushort[]{ 915, 921, 1173, 1175},
 new ushort[]{ 30, 155 },
 new ushort[]{ 10, 177 }},
//171 P 2 n n
new ushort[][]{ new ushort[]{ 915, 918, 1172, 1173},
 new ushort[]{ 672, 1000 },
 new ushort[]{ 670, 1002 }},
//172 P n 2 n
new ushort[][]{ new ushort[]{ 915, 920, 1175, 1172},
 new ushort[]{ 234, 124 },
 new ushort[]{ 102, 258 }},
//173 C m m 2
new ushort[][]{ new ushort[]{ 915, 921, 917, 919},
 new ushort[]{ 116, 118 },
 new ushort[]{ 684, 686 },
 new ushort[]{ 322, 338 },
 new ushort[]{ 30 },
 new ushort[]{ 10 }},
//174 A 2 m m
new ushort[][]{ new ushort[]{ 915, 918, 916, 917},
 new ushort[]{ 684, 685 },
 new ushort[]{ 899, 900 },
 new ushort[]{ 711, 715 },
 new ushort[]{ 672},
 new ushort[]{ 670}},
//175 B m 2 m
new ushort[][]{ new ushort[]{ 915, 920, 919, 916},
 new ushort[]{ 899, 901 },
 new ushort[]{ 116, 117 },
 new ushort[]{ 371, 551 },
 new ushort[]{ 234},
 new ushort[]{ 102}},
//176 C m c 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 924, 919},
 new ushort[]{ 116, 121 }},
//177 C c m 2sub1
new ushort[][]{ new ushort[]{ 915, 928, 926, 917},
 new ushort[]{ 684, 689 }},
//178 A 2sub1 m a
new ushort[][]{ new ushort[]{ 915, 1142, 1140, 917},
 new ushort[]{ 684, 996 }},
//179 A 2sub1 a m
new ushort[][]{ new ushort[]{ 915, 1142, 1141, 916},
 new ushort[]{ 899, 1133 }},
//180 B b 2sub1 m
new ushort[][]{ new ushort[]{ 915, 942, 941, 916},
 new ushort[]{ 899, 930 }},
//181 B m 2sub1 b
new ushort[][]{ new ushort[]{ 915, 942, 938, 919},
 new ushort[]{ 116, 134 }},
//182 C c c 2
new ushort[][]{ new ushort[]{ 915, 921, 924, 926},
 new ushort[]{ 322, 340 },
 new ushort[]{ 30, 32 },
 new ushort[]{ 10, 12 }},
//183 A 2 a a
new ushort[][]{ new ushort[]{ 915, 918, 1140, 1141},
 new ushort[]{ 711, 1019 },
 new ushort[]{ 672, 990 },
 new ushort[]{ 670, 988 }},
//184 B b 2 b
new ushort[][]{ new ushort[]{ 915, 920, 941, 938},
 new ushort[]{ 371, 574 },
 new ushort[]{ 234, 256 },
 new ushort[]{ 102, 122 }},
//185 A m m 2
new ushort[][]{ new ushort[]{ 915, 921, 917, 919},
 new ushort[]{ 248, 250 },
 new ushort[]{ 116, 118 },
 new ushort[]{ 684, 686 },
 new ushort[]{ 153},
 new ushort[]{ 10 }},
//186 B m m 2
new ushort[][]{ new ushort[]{ 915, 921, 919, 917},
 new ushort[]{ 700, 702 },
 new ushort[]{ 684, 686 },
 new ushort[]{ 116, 118 },
 new ushort[]{ 30 },
 new ushort[]{ 10 }},
//187 B 2 m m
new ushort[][]{ new ushort[]{ 915, 918, 916, 917},
 new ushort[]{ 700, 701 },
 new ushort[]{ 684, 685 },
 new ushort[]{ 899, 900 },
 new ushort[]{ 690},
 new ushort[]{ 670}},
//188 C 2 m m
new ushort[][]{ new ushort[]{ 915, 918, 917, 916},
 new ushort[]{ 903, 904 },
 new ushort[]{ 899, 900 },
 new ushort[]{ 684, 685 },
 new ushort[]{ 672},
 new ushort[]{ 670}},
//189 C m 2 m
new ushort[][]{ new ushort[]{ 915, 920, 919, 916},
 new ushort[]{ 903, 905 },
 new ushort[]{ 899, 901 },
 new ushort[]{ 116, 117 },
 new ushort[]{ 104},
 new ushort[]{ 102}},
//190 A m 2 m
new ushort[][]{ new ushort[]{ 915, 920, 916, 919},
 new ushort[]{ 248, 249 },
 new ushort[]{ 116, 117 },
 new ushort[]{ 899, 901 },
 new ushort[]{ 234},
 new ushort[]{ 102}},
//191 A b m 2
new ushort[][]{ new ushort[]{ 915, 921, 939, 941},
 new ushort[]{ 717, 753 },
 new ushort[]{ 153, 175 },
 new ushort[]{ 10, 30 }},
//192 B m a 2
new ushort[][]{ new ushort[]{ 915, 921, 1143, 1141},
 new ushort[]{ 384, 566 },
 new ushort[]{ 30, 175 },
 new ushort[]{ 10, 153 }},
//193 B 2 c m
new ushort[][]{ new ushort[]{ 915, 918, 923, 924},
 new ushort[]{ 907, 912 },
 new ushort[]{ 690, 692 },
 new ushort[]{ 670, 672 }},
//194 C 2 m b
new ushort[][]{ new ushort[]{ 915, 918, 939, 938},
 new ushort[]{ 717, 752 },
 new ushort[]{ 672, 692 },
 new ushort[]{ 670, 690 }},
//195 C m 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1143, 1140},
 new ushort[]{ 384, 565 },
 new ushort[]{ 104, 236 },
 new ushort[]{ 102, 234 }},
//196 A c 2 m
new ushort[][]{ new ushort[]{ 915, 920, 923, 926},
 new ushort[]{ 907, 913 },
 new ushort[]{ 234, 236 },
 new ushort[]{ 102, 104 }},
//197 A m a 2
new ushort[][]{ new ushort[]{ 915, 921, 1141, 1143},
 new ushort[]{ 384, 566 },
 new ushort[]{ 10, 153 }},
//198 B b m 2
new ushort[][]{ new ushort[]{ 915, 921, 941, 939},
 new ushort[]{ 717, 753 },
 new ushort[]{ 10, 30 }},
//199 B 2 m b
new ushort[][]{ new ushort[]{ 915, 918, 938, 939},
 new ushort[]{ 717, 752 },
 new ushort[]{ 670, 690 }},
//200 C 2 c m
new ushort[][]{ new ushort[]{ 915, 918, 924, 923},
 new ushort[]{ 907, 912 },
 new ushort[]{ 670, 672 }},
//201 C c 2 m
new ushort[][]{ new ushort[]{ 915, 920, 926, 923},
 new ushort[]{ 907, 913 },
 new ushort[]{ 102, 104 }},
//202 A m 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1140, 1143},
 new ushort[]{ 384, 565 },
 new ushort[]{ 102, 234 }},
//203 A b a 2
new ushort[][]{ new ushort[]{ 915, 921, 1166, 1168},
 new ushort[]{ 10, 175 }},
//204 B b a 2
new ushort[][]{ new ushort[]{ 915, 921, 1168, 1166},
 new ushort[]{ 10, 175 }},
//205 B 2 c b
new ushort[][]{ new ushort[]{ 915, 918, 944, 945},
 new ushort[]{ 670, 692 }},
//206 C 2 c b
new ushort[][]{ new ushort[]{ 915, 918, 945, 944},
 new ushort[]{ 670, 692 }},
//207 C c 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1149, 1146},
 new ushort[]{ 102, 236 }},
//208 A c 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1146, 1149},
 new ushort[]{ 102, 236 }},
//209 F m m 2
new ushort[][]{ new ushort[]{ 915, 921, 917, 919},
 new ushort[]{ 684, 686 },
 new ushort[]{ 116, 118 },
 new ushort[]{ 322, 338 },
 new ushort[]{ 10 }},
//210 F 2 m m
new ushort[][]{ new ushort[]{ 915, 918, 916, 917},
 new ushort[]{ 899, 900 },
 new ushort[]{ 684, 685 },
 new ushort[]{ 711, 715 },
 new ushort[]{ 670}},
//211 F m 2 m
new ushort[][]{ new ushort[]{ 915, 920, 919, 916},
 new ushort[]{ 116, 117 },
 new ushort[]{ 899, 901 },
 new ushort[]{ 371, 551 },
 new ushort[]{ 102}},
//212 F d d 2
new ushort[][]{ new ushort[]{ 915, 921, 1255, 1256},
 new ushort[]{ 10, 326 }},
//213 F 2 d d
new ushort[][]{ new ushort[]{ 915, 918, 1254, 1255},
 new ushort[]{ 670, 1221 }},
//214 F d 2 d
new ushort[][]{ new ushort[]{ 915, 920, 1256, 1254},
 new ushort[]{ 102, 408 }},
//215 I m m 2
new ushort[][]{ new ushort[]{ 915, 921, 917, 919},
 new ushort[]{ 116, 118 },
 new ushort[]{ 684, 686 },
 new ushort[]{ 30 },
 new ushort[]{ 10 }},
//216 I 2 m m
new ushort[][]{ new ushort[]{ 915, 918, 916, 917},
 new ushort[]{ 684, 685 },
 new ushort[]{ 899, 900 },
 new ushort[]{ 672},
 new ushort[]{ 670}},
//217 I m 2 m
new ushort[][]{ new ushort[]{ 915, 920, 919, 916},
 new ushort[]{ 899, 901 },
 new ushort[]{ 116, 117 },
 new ushort[]{ 234},
 new ushort[]{ 102}},
//218 I b a 2
new ushort[][]{ new ushort[]{ 915, 921, 1166, 1168},
 new ushort[]{ 30, 153 },
 new ushort[]{ 10, 175 }},
//219 I 2 c b
new ushort[][]{ new ushort[]{ 915, 918, 944, 945},
 new ushort[]{ 672, 690 },
 new ushort[]{ 670, 692 }},
//220 I c 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1149, 1146},
 new ushort[]{ 234, 104 },
 new ushort[]{ 102, 236 }},
//221 I m a 2
new ushort[][]{ new ushort[]{ 915, 921, 1141, 1143},
 new ushort[]{ 384, 566 },
 new ushort[]{ 10, 153 }},
//222 I b m 2
new ushort[][]{ new ushort[]{ 915, 921, 941, 939},
 new ushort[]{ 717, 753 },
 new ushort[]{ 10, 30 }},
//223 I 2 m b
new ushort[][]{ new ushort[]{ 915, 918, 938, 939},
 new ushort[]{ 717, 752 },
 new ushort[]{ 670, 690 }},
//224 I 2 c m
new ushort[][]{ new ushort[]{ 915, 918, 924, 923},
 new ushort[]{ 907, 912 },
 new ushort[]{ 670, 672 }},
//225 I c 2 m
new ushort[][]{ new ushort[]{ 915, 920, 926, 923},
 new ushort[]{ 907, 913 },
 new ushort[]{ 102, 104 }},
//226 I m 2 a
new ushort[][]{ new ushort[]{ 915, 920, 1140, 1143},
 new ushort[]{ 384, 565 },
 new ushort[]{ 102, 234 }},
//227 P 2/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 922, 916, 917, 919},
 new ushort[]{ 903, 906, 905, 904},
 new ushort[]{ 899, 902, 901, 900},
 new ushort[]{ 700, 702, 703, 701},
 new ushort[]{ 684, 686, 687, 685},
 new ushort[]{ 248, 250, 249, 251},
 new ushort[]{ 116, 118, 117, 119},
 new ushort[]{ 175, 176 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 236, 237 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 692, 693 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 163},
 new ushort[]{ 18 },
 new ushort[]{ 146},
 new ushort[]{ 1 },
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//228 P 2/n 2/n 2/n
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1178, 1172, 1173, 1175},
 new ushort[]{ 30, 31, 156, 155},
 new ushort[]{ 10, 11, 178, 177},
 new ushort[]{ 234, 235, 125, 124},
 new ushort[]{ 102, 103, 259, 258},
 new ushort[]{ 672, 673, 1001, 1000},
 new ushort[]{ 670, 671, 1003, 1002},
 new ushort[]{ 512, 315, 331, 497},
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 18, 146 },
 new ushort[]{ 1, 163 },
 new ushort[]{ 145, 19 },
 new ushort[]{ 0, 164 }},
//229 P 2/n 2/n 2/n
new ushort[][]{ new ushort[]{ 915, 1170, 1150, 946, 922, 1165, 1147, 947},
 new ushort[]{ 338, 341, 505, 506},
 new ushort[]{ 322, 325, 517, 518},
 new ushort[]{ 551, 575, 375, 396},
 new ushort[]{ 371, 395, 554, 577},
 new ushort[]{ 715, 1020, 747, 1032},
 new ushort[]{ 711, 1018, 750, 1034},
 new ushort[]{ 0, 163, 146, 19},
 new ushort[]{ 164, 1, 18, 145},
 new ushort[]{ 331, 498 },
 new ushort[]{ 315, 511 },
 new ushort[]{ 497, 332 },
 new ushort[]{ 314, 512 }},
//230 P 2/c 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 921, 927, 925, 922, 916, 924, 926},
 new ushort[]{ 899, 902, 905, 904},
 new ushort[]{ 153, 156, 154, 155},
 new ushort[]{ 30, 33, 31, 32},
 new ushort[]{ 175, 178, 176, 177},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 238, 239, 241, 240},
 new ushort[]{ 106, 107, 109, 108},
 new ushort[]{ 694, 695, 697, 696},
 new ushort[]{ 675, 676, 680, 679},
 new ushort[]{ 166, 169 },
 new ushort[]{ 21, 24 },
 new ushort[]{ 147, 148 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 }},
//231 P 2/m 2/a 2/a
new ushort[][]{ new ushort[]{ 915, 918, 1145, 1144, 922, 919, 1140, 1141},
 new ushort[]{ 116, 119, 250, 249},
 new ushort[]{ 690, 1001, 691, 1000},
 new ushort[]{ 672, 991, 673, 990},
 new ushort[]{ 692, 1003, 693, 1002},
 new ushort[]{ 670, 989, 671, 988},
 new ushort[]{ 308, 309, 492, 491},
 new ushort[]{ 300, 301, 482, 481},
 new ushort[]{ 369, 370, 550, 549},
 new ushort[]{ 367, 368, 548, 547},
 new ushort[]{ 305, 486 },
 new ushort[]{ 297, 476 },
 new ushort[]{ 304, 485 },
 new ushort[]{ 296, 475 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 19, 164 },
 new ushort[]{ 0, 145 }},
//232 P 2/b 2/m 2/b
new ushort[][]{ new ushort[]{ 915, 920, 940, 943, 922, 917, 941, 938},
 new ushort[]{ 684, 687, 701, 702},
 new ushort[]{ 104, 125, 105, 124},
 new ushort[]{ 234, 257, 235, 256},
 new ushort[]{ 236, 259, 237, 258},
 new ushort[]{ 102, 123, 103, 122},
 new ushort[]{ 709, 710, 745, 744},
 new ushort[]{ 707, 708, 743, 742},
 new ushort[]{ 193, 194, 205, 204},
 new ushort[]{ 53, 54, 70, 69},
 new ushort[]{ 184, 199 },
 new ushort[]{ 183, 198 },
 new ushort[]{ 42, 59 },
 new ushort[]{ 41, 58 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 146, 164 },
 new ushort[]{ 0, 18 }},
//233 P 2/b 2/a 2/n
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1171, 1165, 1166, 1168},
 new ushort[]{ 30, 31, 154, 153},
 new ushort[]{ 10, 11, 176, 175},
 new ushort[]{ 104, 105, 259, 258},
 new ushort[]{ 102, 103, 257, 256},
 new ushort[]{ 672, 673, 1003, 1002},
 new ushort[]{ 670, 671, 1001, 1000},
 new ushort[]{ 313, 510, 496, 330},
 new ushort[]{ 312, 509, 495, 329},
 new ushort[]{ 1, 164 },
 new ushort[]{ 146, 19 },
 new ushort[]{ 145, 18 },
 new ushort[]{ 0, 163 }},
//234 P 2/b 2/a 2/n
new ushort[][]{ new ushort[]{ 915, 1170, 1144, 940, 922, 1165, 1141, 941},
 new ushort[]{ 338, 339, 505, 504},
 new ushort[]{ 322, 323, 517, 516},
 new ushort[]{ 369, 393, 550, 572},
 new ushort[]{ 367, 391, 548, 570},
 new ushort[]{ 709, 1016, 745, 1030},
 new ushort[]{ 707, 1014, 743, 1028},
 new ushort[]{ 1, 164, 146, 19},
 new ushort[]{ 0, 163, 145, 18},
 new ushort[]{ 313, 510 },
 new ushort[]{ 496, 330 },
 new ushort[]{ 495, 329 },
 new ushort[]{ 312, 509 }},
//235 P 2/n 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 918, 921, 920, 950, 947, 944, 945},
 new ushort[]{ 672, 673, 691, 690},
 new ushort[]{ 670, 671, 693, 692},
 new ushort[]{ 153, 154, 178, 177},
 new ushort[]{ 10, 11, 33, 32},
 new ushort[]{ 234, 235, 259, 258},
 new ushort[]{ 102, 103, 125, 124},
 new ushort[]{ 185, 201, 200, 187},
 new ushort[]{ 43, 62, 60, 45},
 new ushort[]{ 145, 164 },
 new ushort[]{ 163, 146 },
 new ushort[]{ 18, 1 },
 new ushort[]{ 0, 19 }},
//236 P 2/n 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 946, 943, 927, 922, 947, 938, 924},
 new ushort[]{ 715, 716, 747, 746},
 new ushort[]{ 711, 712, 750, 749},
 new ushort[]{ 193, 196, 205, 206},
 new ushort[]{ 53, 56, 70, 71},
 new ushort[]{ 238, 261, 241, 262},
 new ushort[]{ 106, 127, 109, 128},
 new ushort[]{ 145, 164, 163, 146},
 new ushort[]{ 0, 19, 18, 1},
 new ushort[]{ 185, 201 },
 new ushort[]{ 200, 187 },
 new ushort[]{ 60, 45 },
 new ushort[]{ 43, 62 }},
//237 P 2/c 2/n 2/a
new ushort[][]{ new ushort[]{ 915, 920, 918, 921, 1152, 1147, 1149, 1146},
 new ushort[]{ 234, 235, 105, 104},
 new ushort[]{ 102, 103, 237, 236},
 new ushort[]{ 690, 691, 1003, 1002},
 new ushort[]{ 670, 671, 991, 990},
 new ushort[]{ 30, 31, 178, 177},
 new ushort[]{ 10, 11, 156, 155},
 new ushort[]{ 306, 488, 307, 487},
 new ushort[]{ 298, 478, 299, 477},
 new ushort[]{ 18, 164 },
 new ushort[]{ 19, 163 },
 new ushort[]{ 1, 145 },
 new ushort[]{ 0, 146 }},
//238 P 2/c 2/n 2/a
new ushort[][]{ new ushort[]{ 915, 1150, 925, 1145, 922, 1147, 926, 1140},
 new ushort[]{ 551, 552, 375, 374},
 new ushort[]{ 371, 372, 554, 553},
 new ushort[]{ 694, 1005, 697, 1006},
 new ushort[]{ 675, 993, 680, 994},
 new ushort[]{ 308, 311, 492, 493},
 new ushort[]{ 300, 303, 482, 483},
 new ushort[]{ 18, 164, 19, 163},
 new ushort[]{ 0, 146, 1, 145},
 new ushort[]{ 306, 488 },
 new ushort[]{ 307, 487 },
 new ushort[]{ 299, 477 },
 new ushort[]{ 298, 478 } },
//239 P 2sub1/m 2/m 2/a
new ushort[][]{ new ushort[]{ 915, 1145, 920, 1142, 922, 1140, 917, 1143},
 new ushort[]{ 384, 386, 565, 567},
 new ushort[]{ 700, 1009, 703, 1008},
 new ushort[]{ 684, 997, 687, 996},
 new ushort[]{ 104, 237, 105, 236},
 new ushort[]{ 102, 235, 103, 234},
 new ushort[]{ 308, 492 },
 new ushort[]{ 300, 482 },
 new ushort[]{ 19, 164 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 0, 145 }},
//240 P 2/m 2sub1/m 2/b
new ushort[][]{ new ushort[]{ 915, 943, 918, 942, 922, 938, 919, 939},
 new ushort[]{ 717, 719, 752, 754},
 new ushort[]{ 248, 273, 251, 272},
 new ushort[]{ 116, 135, 119, 134},
 new ushort[]{ 672, 693, 673, 692},
 new ushort[]{ 670, 691, 671, 690},
 new ushort[]{ 193, 205 },
 new ushort[]{ 53, 70 },
 new ushort[]{ 146, 164 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 }},
//241 P 2/b 2sub1/m 2/m
new ushort[][]{ new ushort[]{ 915, 940, 921, 942, 922, 941, 916, 939},
 new ushort[]{ 717, 718, 753, 754},
 new ushort[]{ 903, 931, 906, 932},
 new ushort[]{ 899, 929, 902, 930},
 new ushort[]{ 153, 176, 154, 175},
 new ushort[]{ 10, 31, 11, 30},
 new ushort[]{ 709, 745 },
 new ushort[]{ 707, 743 },
 new ushort[]{ 146, 164 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 0, 18 }},
//242 P 2/c 2/m 2sub1/m
new ushort[][]{ new ushort[]{ 915, 925, 920, 928, 922, 926, 917, 923},
 new ushort[]{ 907, 908, 913, 914},
 new ushort[]{ 700, 704, 703, 705},
 new ushort[]{ 684, 688, 687, 689},
 new ushort[]{ 234, 237, 235, 236},
 new ushort[]{ 102, 105, 103, 104},
 new ushort[]{ 694, 697 },
 new ushort[]{ 675, 680 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 }},
//243 P 2/m 2/c 2sub1/m
new ushort[][]{ new ushort[]{ 915, 927, 918, 928, 922, 924, 919, 923},
 new ushort[]{ 907, 909, 912, 914},
 new ushort[]{ 248, 252, 251, 253},
 new ushort[]{ 116, 120, 119, 121},
 new ushort[]{ 690, 693, 691, 692},
 new ushort[]{ 670, 673, 671, 672},
 new ushort[]{ 238, 241 },
 new ushort[]{ 106, 109 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 0, 1 }},
//244 P 2sub1/m 2/a 2/m
new ushort[][]{ new ushort[]{ 915, 1144, 921, 1142, 922, 1141, 916, 1143},
 new ushort[]{ 384, 385, 566, 567},
 new ushort[]{ 903, 1136, 906, 1135},
 new ushort[]{ 899, 1134, 902, 1133},
 new ushort[]{ 30, 176, 31, 175},
 new ushort[]{ 10, 154, 11, 153},
 new ushort[]{ 369, 550 },
 new ushort[]{ 367, 548 },
 new ushort[]{ 19, 164 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 }},
//245 P 2/n 2sub1/n 2/a
new ushort[][]{ new ushort[]{ 915, 1145, 1176, 946, 922, 1140, 1173, 947},
 new ushort[]{ 711, 1033, 750, 1019},
 new ushort[]{ 300, 311, 482, 493},
 new ushort[]{ 1, 146, 163, 18},
 new ushort[]{ 0, 145, 164, 19}},
//246 P 2sub1/n 2/n 2/b
new ushort[][]{ new ushort[]{ 915, 943, 1174, 1150, 922, 938, 1175, 1147},
 new ushort[]{ 374, 578, 552, 394},
 new ushort[]{ 53, 196, 70, 206},
 new ushort[]{ 1, 19, 163, 145},
 new ushort[]{ 0, 18, 164, 146}},
//247 P 2/b 2/n 2sub1/n
new ushort[][]{ new ushort[]{ 915, 940, 1177, 1150, 922, 941, 1172, 1147},
 new ushort[]{ 371, 397, 554, 574},
 new ushort[]{ 707, 1016, 743, 1030},
 new ushort[]{ 145, 163, 19, 1},
 new ushort[]{ 0, 18, 164, 146}},
//248 P 2/c 2sub1/n 2/n
new ushort[][]{ new ushort[]{ 915, 925, 1176, 1170, 922, 926, 1173, 1165},
 new ushort[]{ 504, 519, 339, 324},
 new ushort[]{ 675, 1005, 680, 1006},
 new ushort[]{ 145, 146, 19, 18},
 new ushort[]{ 0, 1, 164, 163}},
//249 P 2sub1/n 2/c 2/n
new ushort[][]{ new ushort[]{ 915, 927, 1174, 1170, 922, 924, 1175, 1165},
 new ushort[]{ 322, 507, 517, 340},
 new ushort[]{ 106, 261, 109, 262},
 new ushort[]{ 18, 19, 146, 145},
 new ushort[]{ 0, 1, 164, 163}},
//250 P 2/n 2/a 2sub1/n
new ushort[][]{ new ushort[]{ 915, 1144, 1177, 946, 922, 1141, 1172, 947},
 new ushort[]{ 746, 1035, 716, 1017},
 new ushort[]{ 367, 393, 548, 572},
 new ushort[]{ 18, 163, 146, 1},
 new ushort[]{ 0, 145, 164, 19}},
//251 P 2/m 2/n 2sub1/a
new ushort[][]{ new ushort[]{ 915, 1151, 1150, 918, 922, 1146, 1147, 919},
 new ushort[]{ 116, 253, 252, 119},
 new ushort[]{ 371, 375, 554, 551},
 new ushort[]{ 690, 1003, 691, 1002},
 new ushort[]{ 670, 991, 671, 990},
 new ushort[]{ 18, 164 },
 new ushort[]{ 163, 19 },
 new ushort[]{ 145, 1 },
 new ushort[]{ 0, 146 }},
//252 P 2/n 2/m 2sub1/b
new ushort[][]{ new ushort[]{ 915, 949, 946, 920, 922, 944, 947, 917},
 new ushort[]{ 684, 705, 704, 687},
 new ushort[]{ 715, 712, 747, 749},
 new ushort[]{ 234, 259, 235, 258},
 new ushort[]{ 102, 125, 103, 124},
 new ushort[]{ 145, 164 },
 new ushort[]{ 163, 146 },
 new ushort[]{ 18, 1 },
 new ushort[]{ 0, 19 }},
//253 P 2sub1/b 2/m 2/n
new ushort[][]{ new ushort[]{ 915, 1167, 1170, 920, 922, 1168, 1165, 917},
 new ushort[]{ 684, 1008, 1009, 687},
 new ushort[]{ 322, 505, 517, 338},
 new ushort[]{ 104, 259, 105, 258},
 new ushort[]{ 102, 257, 103, 256},
 new ushort[]{ 1, 164 },
 new ushort[]{ 19, 146 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 0, 163 }},
//254 P 2sub1/c 2/n 2/m
new ushort[][]{ new ushort[]{ 915, 1148, 1150, 921, 922, 1149, 1147, 916},
 new ushort[]{ 899, 1135, 1136, 902},
 new ushort[]{ 551, 372, 375, 553},
 new ushort[]{ 30, 178, 31, 177},
 new ushort[]{ 10, 156, 11, 155},
 new ushort[]{ 18, 164 },
 new ushort[]{ 19, 163 },
 new ushort[]{ 1, 145 },
 new ushort[]{ 0, 146 }},
//255 P 2/n 2sub1/c 2/m
new ushort[][]{ new ushort[]{ 915, 948, 946, 921, 922, 945, 947, 916},
 new ushort[]{ 899, 932, 931, 902},
 new ushort[]{ 711, 747, 750, 715},
 new ushort[]{ 153, 178, 154, 177},
 new ushort[]{ 10, 33, 11, 32},
 new ushort[]{ 145, 164 },
 new ushort[]{ 146, 163 },
 new ushort[]{ 1, 18 },
 new ushort[]{ 0, 19 }},
//256 P 2/m 2sub1/a 2/n
new ushort[][]{ new ushort[]{ 915, 1169, 1170, 918, 922, 1166, 1165, 919},
 new ushort[]{ 116, 272, 273, 119},
 new ushort[]{ 338, 323, 505, 516},
 new ushort[]{ 672, 1003, 673, 1002},
 new ushort[]{ 670, 1001, 671, 1000},
 new ushort[]{ 1, 164 },
 new ushort[]{ 146, 19 },
 new ushort[]{ 145, 18 },
 new ushort[]{ 0, 163 }},
//257 P 2sub1/c 2/c 2/a
new ushort[][]{ new ushort[]{ 915, 1145, 927, 1148, 922, 1140, 924, 1149},
 new ushort[]{ 308, 494, 492, 310},
 new ushort[]{ 300, 484, 482, 302},
 new ushort[]{ 106, 239, 109, 240},
 new ushort[]{ 18, 163, 19, 164},
 new ushort[]{ 0, 145, 1, 146}},
//258 P 2/c 2sub1/c 2/b
new ushort[][]{ new ushort[]{ 915, 943, 925, 948, 922, 938, 926, 945},
 new ushort[]{ 193, 207, 205, 195},
 new ushort[]{ 53, 72, 70, 55},
 new ushort[]{ 679, 697, 676, 694},
 new ushort[]{ 145, 163, 146, 164},
 new ushort[]{ 0, 18, 1, 19}},
//259 P 2/b 2sub1/a 2/a
new ushort[][]{ new ushort[]{ 915, 940, 1145, 1169, 922, 941, 1140, 1166},
 new ushort[]{ 709, 1031, 745, 1015},
 new ushort[]{ 707, 1029, 743, 1013},
 new ushort[]{ 300, 309, 482, 491},
 new ushort[]{ 1, 19, 146, 164},
 new ushort[]{ 0, 18, 145, 163}},
//260 P 2/c 2/a 2sub1/a
new ushort[][]{ new ushort[]{ 915, 925, 1144, 1151, 922, 926, 1141, 1146},
 new ushort[]{ 694, 1007, 697, 1004},
 new ushort[]{ 675, 995, 680, 992},
 new ushort[]{ 547, 550, 368, 369},
 new ushort[]{ 18, 19, 163, 164},
 new ushort[]{ 0, 1, 145, 146}},
//261 P 2/b 2/c 2sub1/b
new ushort[][]{ new ushort[]{ 915, 927, 940, 949, 922, 924, 941, 944},
 new ushort[]{ 238, 263, 241, 260},
 new ushort[]{ 106, 129, 109, 126},
 new ushort[]{ 707, 710, 743, 744},
 new ushort[]{ 145, 146, 163, 164},
 new ushort[]{ 0, 1, 18, 19}},
//262 P 2sub1/b 2/a 2/b
new ushort[][]{ new ushort[]{ 915, 1144, 943, 1167, 922, 1141, 938, 1168},
 new ushort[]{ 369, 573, 550, 392},
 new ushort[]{ 367, 571, 548, 390},
 new ushort[]{ 69, 205, 54, 193},
 new ushort[]{ 1, 146, 19, 164},
 new ushort[]{ 0, 145, 18, 163}},
//263 P 2sub1/b 2sub1/a 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1169, 1167, 922, 916, 1166, 1168},
 new ushort[]{ 903, 906, 1160, 1159},
 new ushort[]{ 899, 902, 1158, 1157},
 new ushort[]{ 30, 154, 31, 153},
 new ushort[]{ 10, 176, 11, 175},
 new ushort[]{ 19, 146 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//264 P 2/m 2sub1/c 2sub1/b
new ushort[][]{ new ushort[]{ 915, 918, 949, 948, 922, 919, 944, 945},
 new ushort[]{ 248, 251, 276, 275},
 new ushort[]{ 116, 119, 137, 136},
 new ushort[]{ 672, 691, 673, 690},
 new ushort[]{ 670, 693, 671, 692},
 new ushort[]{ 146, 163 },
 new ushort[]{ 1, 18 },
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//265 P 2sub1/c 2/m 2sub1/a
new ushort[][]{ new ushort[]{ 915, 920, 1148, 1151, 922, 917, 1149, 1146},
 new ushort[]{ 700, 703, 1011, 1012},
 new ushort[]{ 684, 687, 998, 999},
 new ushort[]{ 234, 105, 235, 104},
 new ushort[]{ 102, 237, 103, 236},
 new ushort[]{ 163, 19 },
 new ushort[]{ 145, 1 },
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//266 P 2sub1/c 2sub1/c 2/n
new ushort[][]{ new ushort[]{ 915, 1170, 948, 1148, 922, 1165, 945, 1149},
 new ushort[]{ 338, 507, 505, 340},
 new ushort[]{ 322, 519, 517, 324},
 new ushort[]{ 1, 164, 18, 145},
 new ushort[]{ 0, 163, 19, 146}},
//267 P 2/n 2sub1/a 2sub1/a
new ushort[][]{ new ushort[]{ 915, 946, 1151, 1169, 922, 947, 1146, 1166},
 new ushort[]{ 715, 1033, 747, 1019},
 new ushort[]{ 711, 1035, 750, 1017},
 new ushort[]{ 145, 164, 1, 18},
 new ushort[]{ 0, 19, 146, 163}},
//268 P 2sub1/b 2/n 2sub1/b
new ushort[][]{ new ushort[]{ 915, 1150, 1167, 949, 922, 1147, 1168, 944},
 new ushort[]{ 551, 397, 375, 574},
 new ushort[]{ 371, 578, 554, 394},
 new ushort[]{ 18, 164, 145, 1},
 new ushort[]{ 0, 146, 163, 19}},
//269 P 2/b 2sub1/c 2sub1/m
new ushort[][]{ new ushort[]{ 915, 928, 948, 940, 922, 923, 945, 941},
 new ushort[]{ 907, 914, 935, 936},
 new ushort[]{ 707, 745, 743, 709},
 new ushort[]{ 145, 146, 164, 163},
 new ushort[]{ 0, 1, 19, 18}},
//270 P 2sub1/c 2/a 2sub1/m
new ushort[][]{ new ushort[]{ 915, 928, 1148, 1144, 922, 923, 1149, 1141},
 new ushort[]{ 911, 910, 1139, 1138},
 new ushort[]{ 367, 550, 548, 369},
 new ushort[]{ 18, 19, 164, 163},
 new ushort[]{ 0, 1, 146, 145}},
//271 P 2sub1/m 2/c 2sub1/a
new ushort[][]{ new ushort[]{ 915, 1142, 1151, 927, 922, 1143, 1146, 924},
 new ushort[]{ 384, 567, 389, 568},
 new ushort[]{ 106, 241, 109, 238},
 new ushort[]{ 18, 163, 164, 19},
 new ushort[]{ 0, 145, 146, 1}},
//272 P 2sub1/m 2sub1/a 2/b
new ushort[][]{ new ushort[]{ 915, 1142, 1169, 943, 922, 1143, 1166, 938},
 new ushort[]{ 564, 387, 585, 405},
 new ushort[]{ 53, 205, 70, 193},
 new ushort[]{ 1, 146, 164, 19},
 new ushort[]{ 0, 145, 163, 18}},
//273 P 2sub1/b 2sub1/m 2/a
new ushort[][]{ new ushort[]{ 915, 942, 1167, 1145, 922, 939, 1168, 1140},
 new ushort[]{ 717, 754, 1024, 1038},
 new ushort[]{ 300, 492, 482, 308},
 new ushort[]{ 1, 19, 164, 146},
 new ushort[]{ 0, 18, 163, 145}},
//274 P 2/c 2sub1/m 2sub1/b
new ushort[][]{ new ushort[]{ 915, 942, 949, 925, 922, 939, 944, 926},
 new ushort[]{ 751, 720, 755, 721},
 new ushort[]{ 675, 697, 680, 694},
 new ushort[]{ 145, 163, 164, 146},
 new ushort[]{ 0, 18, 19, 1}},
//275 P 2sub1/n 2sub1/n 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1176, 1174, 922, 916, 1173, 1175},
 new ushort[]{ 899, 902, 1160, 1159},
 new ushort[]{ 30, 156, 31, 155},
 new ushort[]{ 10, 178, 11, 177},
 new ushort[]{ 19, 145 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//276 P 2/m 2sub1/n 2sub1/n
new ushort[][]{ new ushort[]{ 915, 918, 1177, 1176, 922, 919, 1172, 1173},
 new ushort[]{ 116, 119, 276, 275},
 new ushort[]{ 672, 1001, 673, 1000},
 new ushort[]{ 670, 1003, 671, 1002},
 new ushort[]{ 146, 18 },
 new ushort[]{ 1, 163 },
 new ushort[]{ 145, 19 },
 new ushort[]{ 0, 164 }},
//277 P 2sub1/n 2/m 2sub1/n
new ushort[][]{ new ushort[]{ 915, 920, 1174, 1177, 922, 917, 1175, 1172},
 new ushort[]{ 684, 687, 1011, 1012},
 new ushort[]{ 234, 125, 235, 124},
 new ushort[]{ 102, 259, 103, 258},
 new ushort[]{ 163, 1 },
 new ushort[]{ 145, 19 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 0, 164 }},
//278 P 2sub1/m 2sub1/m 2/n
new ushort[][]{ new ushort[]{ 915, 921, 1169, 1167, 1171, 1165, 917, 919},
 new ushort[]{ 684, 686, 1010, 1008},
 new ushort[]{ 116, 118, 272, 274},
 new ushort[]{ 313, 510, 330, 496},
 new ushort[]{ 312, 509, 329, 495},
 new ushort[]{ 30, 154 },
 new ushort[]{ 10, 176 }},
//279 P 2sub1/m 2sub1/m 2/n
new ushort[][]{ new ushort[]{ 915, 1170, 942, 1142, 922, 1165, 939, 1143},
 new ushort[]{ 717, 1025, 754, 1037},
 new ushort[]{ 384, 405, 585, 567},
 new ushort[]{ 1, 164, 19, 146},
 new ushort[]{ 0, 163, 18, 145},
 new ushort[]{ 338, 505 },
 new ushort[]{ 322, 517 }},
//280 P 2/n 2sub1/m 2sub1/m
new ushort[][]{ new ushort[]{ 915, 918, 949, 948, 950, 947, 916, 917},
 new ushort[]{ 899, 900, 933, 932},
 new ushort[]{ 684, 685, 705, 706},
 new ushort[]{ 185, 201, 187, 200},
 new ushort[]{ 43, 62, 45, 60},
 new ushort[]{ 672, 691 },
 new ushort[]{ 670, 693 }},
//281 P 2/n 2sub1/m 2sub1/m
new ushort[][]{ new ushort[]{ 915, 946, 928, 942, 922, 947, 923, 939},
 new ushort[]{ 907, 934, 914, 937},
 new ushort[]{ 717, 721, 755, 754},
 new ushort[]{ 145, 164, 146, 163},
 new ushort[]{ 0, 19, 1, 18},
 new ushort[]{ 715, 747 },
 new ushort[]{ 711, 750 }},
//282 P 2sub1/m 2/n 2sub1/m
new ushort[][]{ new ushort[]{ 915, 920, 1148, 1151, 1152, 1147, 919, 916},
 new ushort[]{ 116, 117, 254, 253},
 new ushort[]{ 899, 901, 1135, 1137},
 new ushort[]{ 306, 488, 487, 307},
 new ushort[]{ 298, 478, 477, 299},
 new ushort[]{ 234, 105 },
 new ushort[]{ 102, 237 }},
//283 P 2sub1/m 2/n 2sub1/m
new ushort[][]{ new ushort[]{ 915, 1150, 1142, 928, 922, 1147, 1143, 923},
 new ushort[]{ 384, 388, 567, 569},
 new ushort[]{ 907, 1138, 1139, 914},
 new ushort[]{ 18, 164, 163, 19},
 new ushort[]{ 0, 146, 145, 1},
 new ushort[]{ 551, 375 },
 new ushort[]{ 371, 554 }},
//284 P 2sub1/b 2/c 2sub1/n
new ushort[][]{ new ushort[]{ 915, 1177, 927, 1167, 922, 1172, 924, 1168},
 new ushort[]{ 106, 263, 109, 260},
 new ushort[]{ 18, 146, 19, 145},
 new ushort[]{ 0, 164, 1, 163}},
//285 P 2/c 2sub1/a 2sub1/n
new ushort[][]{ new ushort[]{ 915, 1177, 925, 1169, 922, 1172, 926, 1166},
 new ushort[]{ 679, 1005, 676, 1006},
 new ushort[]{ 145, 19, 146, 18},
 new ushort[]{ 0, 164, 1, 163}},
//286 P 2sub1/n 2sub1/c 2/a
new ushort[][]{ new ushort[]{ 915, 1174, 1145, 948, 922, 1175, 1140, 945},
 new ushort[]{ 300, 494, 482, 310},
 new ushort[]{ 1, 163, 146, 18},
 new ushort[]{ 0, 164, 145, 19}},
//287 P 2sub1/n 2/a 2sub1/b
new ushort[][]{ new ushort[]{ 915, 1174, 1144, 949, 922, 1175, 1141, 944},
 new ushort[]{ 547, 393, 368, 572},
 new ushort[]{ 18, 146, 163, 1},
 new ushort[]{ 0, 164, 145, 19}},
//288 P 2/b 2sub1/n 2sub1/a
new ushort[][]{ new ushort[]{ 915, 1176, 940, 1151, 922, 1173, 941, 1146},
 new ushort[]{ 707, 1031, 743, 1015},
 new ushort[]{ 145, 19, 163, 1},
 new ushort[]{ 0, 164, 18, 146}},
//289 P 2sub1/c 2sub1/n 2/b
new ushort[][]{ new ushort[]{ 915, 1176, 943, 1148, 922, 1173, 938, 1149},
 new ushort[]{ 69, 196, 54, 206},
 new ushort[]{ 1, 163, 19, 145},
 new ushort[]{ 0, 164, 18, 146}},
//290 P 2sub1/b 2sub1/c 2sub1/a
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 922, 1146, 945, 1168},
 new ushort[]{ 1, 145, 18, 164},
 new ushort[]{ 0, 146, 19, 163}},
//291 P 2sub1/c 2sub1/a 2sub1/b
new ushort[][]{ new ushort[]{ 915, 949, 1148, 1169, 922, 944, 1149, 1166},
 new ushort[]{ 1, 18, 145, 164},
 new ushort[]{ 0, 19, 146, 163}},
//292 P 2sub1/n 2sub1/m 2sub1/a
new ushort[][]{ new ushort[]{ 915, 1151, 942, 1174, 922, 1146, 939, 1175},
 new ushort[]{ 717, 1040, 754, 1026},
 new ushort[]{ 1, 145, 19, 163},
 new ushort[]{ 0, 146, 18, 164}},
//293 P 2sub1/m 2sub1/n 2sub1/b
new ushort[][]{ new ushort[]{ 915, 949, 1142, 1176, 922, 944, 1143, 1173},
 new ushort[]{ 384, 587, 567, 406},
 new ushort[]{ 1, 18, 146, 163},
 new ushort[]{ 0, 19, 145, 164}},
//294 P 2sub1/b 2sub1/n 2sub1/m
new ushort[][]{ new ushort[]{ 915, 1167, 928, 1176, 922, 1168, 923, 1173},
 new ushort[]{ 907, 1163, 914, 1162},
 new ushort[]{ 145, 18, 146, 19},
 new ushort[]{ 0, 163, 1, 164}},
//295 P 2sub1/c 2sub1/m 2sub1/n
new ushort[][]{ new ushort[]{ 915, 1148, 942, 1177, 922, 1149, 939, 1172},
 new ushort[]{ 717, 1039, 754, 1027},
 new ushort[]{ 145, 1, 163, 19},
 new ushort[]{ 0, 146, 18, 164}},
//296 P 2sub1/m 2sub1/c 2sub1/n
new ushort[][]{ new ushort[]{ 915, 948, 1142, 1177, 922, 945, 1143, 1172},
 new ushort[]{ 384, 586, 567, 407},
 new ushort[]{ 18, 1, 163, 146},
 new ushort[]{ 0, 19, 145, 164}},
//297 P 2sub1/n 2sub1/a 2sub1/m
new ushort[][]{ new ushort[]{ 915, 1169, 928, 1174, 922, 1166, 923, 1175},
 new ushort[]{ 907, 1164, 914, 1161},
 new ushort[]{ 18, 145, 19, 146},
 new ushort[]{ 0, 163, 1, 164}},
//298 C 2/m 2/c 2sub1/m
new ushort[][]{ new ushort[]{ 915, 928, 927, 918, 922, 923, 924, 919},
 new ushort[]{ 907, 914, 909, 912},
 new ushort[]{ 116, 121, 120, 119},
 new ushort[]{ 670, 673, 671, 672},
 new ushort[]{ 312, 510, 496, 329},
 new ushort[]{ 106, 109 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 }},
//299 C 2/c 2/m 2sub1/m
new ushort[][]{ new ushort[]{ 915, 928, 925, 920, 922, 923, 926, 917},
 new ushort[]{ 911, 910, 912, 909},
 new ushort[]{ 684, 689, 688, 687},
 new ushort[]{ 102, 105, 103, 104},
 new ushort[]{ 312, 510, 330, 495},
 new ushort[]{ 679, 676 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 0, 1 }},
//300 A 2sub1/m 2/m 2/a
new ushort[][]{ new ushort[]{ 915, 1142, 1145, 920, 922, 1143, 1140, 917},
 new ushort[]{ 384, 567, 386, 565},
 new ushort[]{ 684, 996, 997, 687},
 new ushort[]{ 102, 235, 103, 234},
 new ushort[]{ 43, 201, 200, 45},
 new ushort[]{ 300, 482 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 }},
//301 A 2sub1/m 2/a 2/m
new ushort[][]{ new ushort[]{ 915, 1142, 1144, 921, 922, 1143, 1141, 916},
 new ushort[]{ 564, 387, 565, 386},
 new ushort[]{ 899, 1133, 1134, 902},
 new ushort[]{ 10, 154, 11, 153},
 new ushort[]{ 43, 201, 187, 60},
 new ushort[]{ 547, 368 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 0, 145 }},
//302 B 2/b 2sub1/m 2/m
new ushort[][]{ new ushort[]{ 915, 942, 940, 921, 922, 939, 941, 916},
 new ushort[]{ 717, 754, 718, 753},
 new ushort[]{ 899, 930, 929, 902},
 new ushort[]{ 10, 31, 11, 30},
 new ushort[]{ 298, 488, 307, 477},
 new ushort[]{ 707, 743 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 }},
//303 B 2/m 2sub1/m 2/b
new ushort[][]{ new ushort[]{ 915, 942, 943, 918, 922, 939, 938, 919},
 new ushort[]{ 751, 720, 753, 718},
 new ushort[]{ 116, 134, 135, 119},
 new ushort[]{ 670, 691, 671, 690},
 new ushort[]{ 298, 488, 487, 299},
 new ushort[]{ 69, 54 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 0, 18 }},
//304 C 2/m 2/c 2sub1/a
new ushort[][]{ new ushort[]{ 915, 949, 948, 918, 922, 944, 945, 919},
 new ushort[]{ 116, 137, 136, 119},
 new ushort[]{ 371, 578, 554, 394},
 new ushort[]{ 670, 693, 671, 692},
 new ushort[]{ 312, 496, 510, 329},
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//305 C 2/c 2/m 2sub1/b
new ushort[][]{ new ushort[]{ 915, 1151, 1148, 920, 922, 1146, 1149, 917},
 new ushort[]{ 684, 999, 998, 687},
 new ushort[]{ 715, 1033, 747, 1019},
 new ushort[]{ 102, 237, 103, 236},
 new ushort[]{ 312, 330, 510, 495},
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//306 A 2sub1/b 2/m a
new ushort[][]{ new ushort[]{ 915, 1148, 1151, 920, 922, 1149, 1146, 917},
 new ushort[]{ 684, 998, 999, 687},
 new ushort[]{ 322, 519, 517, 324},
 new ushort[]{ 102, 237, 103, 236},
 new ushort[]{ 43, 200, 201, 45},
 new ushort[]{ 18, 164 },
 new ushort[]{ 0, 146 }},
//307 A 2sub1/c 2/a 2/m
new ushort[][]{ new ushort[]{ 915, 1167, 1169, 921, 922, 1168, 1166, 916},
 new ushort[]{ 899, 1157, 1158, 902},
 new ushort[]{ 551, 397, 375, 574},
 new ushort[]{ 10, 176, 11, 175},
 new ushort[]{ 43, 187, 201, 60},
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//308 B 2/b 2sub1/c 2/m
new ushort[][]{ new ushort[]{ 915, 1169, 1167, 921, 922, 1166, 1168, 916},
 new ushort[]{ 899, 1158, 1157, 902},
 new ushort[]{ 711, 1035, 750, 1017},
 new ushort[]{ 10, 176, 11, 175},
 new ushort[]{ 298, 307, 488, 477},
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//309 B 2/m 2sub1/a 2/b
new ushort[][]{ new ushort[]{ 915, 948, 949, 918, 922, 945, 944, 919},
 new ushort[]{ 116, 136, 137, 119},
 new ushort[]{ 338, 507, 505, 340},
 new ushort[]{ 670, 693, 671, 692},
 new ushort[]{ 298, 487, 488, 299},
 new ushort[]{ 145, 164 },
 new ushort[]{ 0, 19 }},
//310 C 2/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 922, 916, 917, 919},
 new ushort[]{ 903, 906, 905, 904},
 new ushort[]{ 899, 902, 901, 900},
 new ushort[]{ 684, 686, 687, 685},
 new ushort[]{ 116, 118, 117, 119},
 new ushort[]{ 322, 505, 517, 338},
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 313, 496 },
 new ushort[]{ 312, 495 },
 new ushort[]{ 1 },
 new ushort[]{ 146},
 new ushort[]{ 145},
 new ushort[]{ 0 }},
//311 A 2/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 918, 921, 920, 922, 919, 916, 917},
 new ushort[]{ 248, 251, 250, 249},
 new ushort[]{ 116, 119, 118, 117},
 new ushort[]{ 899, 900, 902, 901},
 new ushort[]{ 684, 685, 686, 687},
 new ushort[]{ 711, 747, 750, 715},
 new ushort[]{ 672, 673 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 153, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 185, 200 },
 new ushort[]{ 43, 60 },
 new ushort[]{ 145},
 new ushort[]{ 163},
 new ushort[]{ 18 },
 new ushort[]{ 0 }},
//312 B 2/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 920, 918, 921, 922, 917, 919, 916},
 new ushort[]{ 700, 703, 701, 702},
 new ushort[]{ 684, 687, 685, 686},
 new ushort[]{ 116, 117, 119, 118},
 new ushort[]{ 899, 901, 900, 902},
 new ushort[]{ 371, 375, 554, 551},
 new ushort[]{ 234, 235 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 30, 31 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 306, 307 },
 new ushort[]{ 298, 299 },
 new ushort[]{ 18 },
 new ushort[]{ 19 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//313 C 2/c 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 921, 927, 925, 922, 916, 924, 926},
 new ushort[]{ 899, 902, 905, 904},
 new ushort[]{ 322, 507, 517, 340},
 new ushort[]{ 30, 33, 31, 32},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 106, 107, 109, 108},
 new ushort[]{ 675, 676, 680, 679},
 new ushort[]{ 329, 510 },
 new ushort[]{ 312, 496 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 21, 24 },
 new ushort[]{ 3, 6 }},
//314 A 2/m 2/a 2/a
new ushort[][]{ new ushort[]{ 915, 918, 1145, 1144, 922, 919, 1140, 1141},
 new ushort[]{ 116, 119, 250, 249},
 new ushort[]{ 711, 1033, 750, 1019},
 new ushort[]{ 672, 991, 673, 990},
 new ushort[]{ 670, 989, 671, 988},
 new ushort[]{ 300, 301, 482, 481},
 new ushort[]{ 367, 368, 548, 547},
 new ushort[]{ 45, 201 },
 new ushort[]{ 43, 200 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 },
 new ushort[]{ 297, 476 },
 new ushort[]{ 296, 475 }},
//315 B 2/b 2/m 2/b
new ushort[][]{ new ushort[]{ 915, 920, 940, 943, 922, 917, 941, 938},
 new ushort[]{ 684, 687, 701, 702},
 new ushort[]{ 371, 397, 554, 574},
 new ushort[]{ 234, 257, 235, 256},
 new ushort[]{ 102, 123, 103, 122},
 new ushort[]{ 707, 708, 743, 742},
 new ushort[]{ 53, 54, 70, 69},
 new ushort[]{ 477, 488 },
 new ushort[]{ 298, 307 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 },
 new ushort[]{ 183, 198 },
 new ushort[]{ 41, 58 }},
//316 C 2/m 2/m 2/a
new ushort[][]{ new ushort[]{ 915, 943, 942, 918, 922, 938, 939, 919},
 new ushort[]{ 717, 719, 754, 752},
 new ushort[]{ 116, 135, 134, 119},
 new ushort[]{ 300, 492, 482, 308},
 new ushort[]{ 369, 573, 550, 392},
 new ushort[]{ 367, 571, 548, 390},
 new ushort[]{ 672, 693, 673, 692},
 new ushort[]{ 670, 691, 671, 690},
 new ushort[]{ 53, 70 },
 new ushort[]{ 313, 496 },
 new ushort[]{ 312, 495 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 0, 18 },
 new ushort[]{ 297, 476 },
 new ushort[]{ 296, 475 }},
//317 C 2/m 2/m 2/b
new ushort[][]{ new ushort[]{ 915, 1145, 1142, 920, 922, 1140, 1143, 917},
 new ushort[]{ 384, 386, 567, 565},
 new ushort[]{ 684, 997, 996, 687},
 new ushort[]{ 53, 205, 70, 193},
 new ushort[]{ 709, 1031, 745, 1015},
 new ushort[]{ 707, 1029, 743, 1013},
 new ushort[]{ 104, 237, 105, 236},
 new ushort[]{ 102, 235, 103, 234},
 new ushort[]{ 300, 482 },
 new ushort[]{ 313, 330 },
 new ushort[]{ 312, 329 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 },
 new ushort[]{ 42, 59 },
 new ushort[]{ 41, 58 }},
//318 A 2/b 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 925, 928, 920, 922, 926, 923, 917},
 new ushort[]{ 907, 908, 914, 913},
 new ushort[]{ 684, 688, 689, 687},
 new ushort[]{ 707, 745, 743, 709},
 new ushort[]{ 193, 207, 205, 195},
 new ushort[]{ 53, 72, 70, 55},
 new ushort[]{ 234, 237, 235, 236},
 new ushort[]{ 102, 105, 103, 104},
 new ushort[]{ 675, 680 },
 new ushort[]{ 185, 200 },
 new ushort[]{ 43, 60 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 183, 198 },
 new ushort[]{ 41, 58 }},
//319 A 2/c 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 940, 942, 921, 922, 941, 939, 916},
 new ushort[]{ 717, 718, 754, 753},
 new ushort[]{ 899, 929, 930, 902},
 new ushort[]{ 675, 697, 680, 694},
 new ushort[]{ 238, 263, 241, 260},
 new ushort[]{ 106, 129, 109, 126},
 new ushort[]{ 153, 176, 154, 175},
 new ushort[]{ 10, 31, 11, 30},
 new ushort[]{ 707, 743 },
 new ushort[]{ 185, 187 },
 new ushort[]{ 43, 45 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 },
 new ushort[]{ 147, 148 },
 new ushort[]{ 3, 6 }},
//320 B 2/m 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 1144, 1142, 921, 922, 1141, 1143, 916},
 new ushort[]{ 384, 385, 567, 566},
 new ushort[]{ 899, 1134, 1133, 902},
 new ushort[]{ 106, 241, 109, 238},
 new ushort[]{ 694, 1007, 697, 1004},
 new ushort[]{ 675, 995, 680, 992},
 new ushort[]{ 30, 176, 31, 175},
 new ushort[]{ 10, 154, 11, 153},
 new ushort[]{ 367, 548 },
 new ushort[]{ 306, 307 },
 new ushort[]{ 298, 299 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 0, 145 },
 new ushort[]{ 21, 24 },
 new ushort[]{ 3, 6 }},
//321 B 2/m 2/a 2/m
new ushort[][]{ new ushort[]{ 915, 927, 928, 918, 922, 924, 923, 919},
 new ushort[]{ 907, 909, 914, 912},
 new ushort[]{ 116, 120, 121, 119},
 new ushort[]{ 367, 550, 548, 369},
 new ushort[]{ 308, 494, 492, 310},
 new ushort[]{ 300, 484, 482, 302},
 new ushort[]{ 690, 693, 691, 692},
 new ushort[]{ 670, 673, 671, 672},
 new ushort[]{ 106, 109 },
 new ushort[]{ 306, 487 },
 new ushort[]{ 298, 477 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 304, 485 },
 new ushort[]{ 296, 475 }},
//322 C 2/c 2/c 2/a
new ushort[][]{ new ushort[]{ 915, 1170, 920, 1167, 950, 1146, 945, 1149},
 new ushort[]{ 322, 505, 507, 324},
 new ushort[]{ 10, 11, 33, 32},
 new ushort[]{ 102, 257, 125, 236},
 new ushort[]{ 670, 1001, 693, 990},
 new ushort[]{ 43, 185, 45, 187},
 new ushort[]{ 298, 306, 478, 488},
 new ushort[]{ 1, 18 },
 new ushort[]{ 0, 19 }},
//323 C 2/c 2/c 2/a
new ushort[][]{ new ushort[]{ 915, 1145, 927, 1148, 922, 1140, 924, 1149},
 new ushort[]{ 300, 484, 482, 302},
 new ushort[]{ 53, 56, 70, 71},
 new ushort[]{ 106, 239, 109, 240},
 new ushort[]{ 711, 1033, 750, 1019},
 new ushort[]{ 0, 145, 1, 146},
 new ushort[]{ 329, 312, 510, 496},
 new ushort[]{ 45, 60 },
 new ushort[]{ 43, 62 }},
//324 C 2/c 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 1170, 918, 1169, 1152, 944, 1149, 945},
 new ushort[]{ 322, 339, 341, 324},
 new ushort[]{ 10, 11, 156, 155},
 new ushort[]{ 670, 1001, 991, 692},
 new ushort[]{ 102, 257, 237, 124},
 new ushort[]{ 299, 307, 298, 306},
 new ushort[]{ 45, 187, 60, 200},
 new ushort[]{ 1, 145 },
 new ushort[]{ 0, 146 }},
//325 C 2/c 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 943, 925, 948, 922, 938, 926, 945},
 new ushort[]{ 53, 72, 70, 55},
 new ushort[]{ 300, 303, 482, 483},
 new ushort[]{ 679, 697, 676, 694},
 new ushort[]{ 374, 578, 552, 394},
 new ushort[]{ 0, 18, 1, 19},
 new ushort[]{ 495, 312, 510, 330},
 new ushort[]{ 298, 478 },
 new ushort[]{ 299, 477 }},
//326 A 2/b 2/a 2/a
new ushort[][]{ new ushort[]{ 915, 946, 921, 948, 1152, 1168, 1146, 1166},
 new ushort[]{ 711, 747, 1033, 1017},
 new ushort[]{ 670, 671, 991, 990},
 new ushort[]{ 10, 33, 156, 175},
 new ushort[]{ 102, 125, 237, 256},
 new ushort[]{ 298, 306, 477, 487},
 new ushort[]{ 312, 313, 509, 510},
 new ushort[]{ 145, 1 },
 new ushort[]{ 0, 146 }},
//327 A 2/b 2/a 2/a
new ushort[][]{ new ushort[]{ 915, 940, 1145, 1169, 922, 941, 1140, 1166},
 new ushort[]{ 707, 1029, 743, 1013},
 new ushort[]{ 675, 993, 680, 994},
 new ushort[]{ 300, 309, 482, 491},
 new ushort[]{ 371, 397, 554, 574},
 new ushort[]{ 0, 18, 145, 163},
 new ushort[]{ 45, 43, 201, 200},
 new ushort[]{ 477, 299 },
 new ushort[]{ 298, 478 }},
//328 A 2/c 2/a 2/a
new ushort[][]{ new ushort[]{ 915, 946, 920, 949, 1171, 1149, 1166, 1146},
 new ushort[]{ 711, 716, 1020, 1017},
 new ushort[]{ 670, 671, 1001, 1000},
 new ushort[]{ 102, 125, 257, 236},
 new ushort[]{ 10, 33, 176, 155},
 new ushort[]{ 495, 496, 312, 313},
 new ushort[]{ 477, 487, 299, 307},
 new ushort[]{ 145, 18 },
 new ushort[]{ 0, 163 }},
//329 A 2/c 2/a 2/a
new ushort[][]{ new ushort[]{ 915, 925, 1144, 1151, 922, 926, 1141, 1146},
 new ushort[]{ 675, 995, 680, 992},
 new ushort[]{ 707, 1014, 743, 1028},
 new ushort[]{ 547, 550, 368, 369},
 new ushort[]{ 504, 519, 339, 324},
 new ushort[]{ 0, 1, 145, 146},
 new ushort[]{ 60, 43, 201, 187},
 new ushort[]{ 312, 509 },
 new ushort[]{ 495, 329 }},
//330 B 2/b 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 1150, 918, 1151, 1171, 945, 1168, 944},
 new ushort[]{ 371, 375, 397, 394},
 new ushort[]{ 102, 103, 257, 256},
 new ushort[]{ 670, 991, 1001, 692},
 new ushort[]{ 10, 156, 176, 32},
 new ushort[]{ 312, 313, 329, 330},
 new ushort[]{ 43, 185, 62, 201},
 new ushort[]{ 18, 145 },
 new ushort[]{ 0, 163 }},
//331 B 2/b 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 927, 940, 949, 922, 924, 941, 944},
 new ushort[]{ 106, 129, 109, 126},
 new ushort[]{ 367, 391, 548, 570},
 new ushort[]{ 707, 710, 743, 744},
 new ushort[]{ 322, 507, 517, 340},
 new ushort[]{ 0, 1, 18, 19},
 new ushort[]{ 477, 298, 488, 307},
 new ushort[]{ 329, 495 },
 new ushort[]{ 312, 509 }},
//332 B 2/b 2/a 2/b
new ushort[][]{ new ushort[]{ 915, 1150, 921, 1148, 950, 1166, 944, 1168},
 new ushort[]{ 371, 552, 575, 394},
 new ushort[]{ 102, 103, 125, 124},
 new ushort[]{ 10, 156, 33, 175},
 new ushort[]{ 670, 991, 693, 1000},
 new ushort[]{ 60, 200, 43, 185},
 new ushort[]{ 329, 330, 495, 496},
 new ushort[]{ 18, 1 },
 new ushort[]{ 0, 19 }},
//333 B 2/b 2/a 2/b
new ushort[][]{ new ushort[]{ 915, 1144, 943, 1167, 922, 1141, 938, 1168},
 new ushort[]{ 367, 571, 548, 390},
 new ushort[]{ 106, 127, 109, 128},
 new ushort[]{ 69, 205, 54, 193},
 new ushort[]{ 746, 1035, 716, 1017},
 new ushort[]{ 0, 145, 18, 163},
 new ushort[]{ 299, 298, 488, 487},
 new ushort[]{ 43, 62 },
 new ushort[]{ 60, 45 }},
//334 F 2/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 922, 916, 917, 919},
 new ushort[]{ 899, 902, 901, 900},
 new ushort[]{ 684, 686, 687, 685},
 new ushort[]{ 116, 118, 117, 119},
 new ushort[]{ 711, 747, 750, 715},
 new ushort[]{ 371, 552, 554, 374},
 new ushort[]{ 322, 505, 517, 338},
 new ushort[]{ 10, 11 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 314, 512 },
 new ushort[]{ 312, 495 },
 new ushort[]{ 298, 477 },
 new ushort[]{ 43, 60 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//335 F 2/d 2/d 2/d
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1257, 1254, 1255, 1256},
 new ushort[]{ 10, 11, 327, 326},
 new ushort[]{ 102, 103, 409, 408},
 new ushort[]{ 670, 671, 1222, 1221},
 new ushort[]{ 625, 595, 598, 621},
 new ushort[]{ 415, 653, 644, 431},
 new ushort[]{ 1, 315 },
 new ushort[]{ 0, 314 }},
//336 F 2/d 2/d 2/d
new ushort[][]{ new ushort[]{ 915, 1318, 1310, 956, 922, 1252, 1248, 955},
 new ushort[]{ 420, 619, 658, 604},
 new ushort[]{ 435, 637, 663, 611},
 new ushort[]{ 722, 1288, 757, 1224},
 new ushort[]{ 164, 313, 306, 185},
 new ushort[]{ 0, 509, 478, 62},
 new ushort[]{ 416, 654 },
 new ushort[]{ 415, 655 }},
//337 I 2/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 922, 916, 917, 919},
 new ushort[]{ 899, 902, 901, 900},
 new ushort[]{ 684, 686, 687, 685},
 new ushort[]{ 116, 118, 117, 119},
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 153, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 104, 105 },
 new ushort[]{ 102, 103 },
 new ushort[]{ 690, 691 },
 new ushort[]{ 670, 671 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 19 },
 new ushort[]{ 0 }},
//338 I 2/b 2/a 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1169, 1167, 922, 916, 1166, 1168},
 new ushort[]{ 899, 902, 1158, 1157},
 new ushort[]{ 30, 154, 31, 153},
 new ushort[]{ 10, 176, 11, 175},
 new ushort[]{ 106, 107, 109, 108},
 new ushort[]{ 675, 676, 680, 679},
 new ushort[]{ 314, 511, 332, 498},
 new ushort[]{ 145, 18 },
 new ushort[]{ 0, 163 },
 new ushort[]{ 147, 148 },
 new ushort[]{ 3, 6 }},
//339 I 2/m 2/c 2/b
new ushort[][]{ new ushort[]{ 915, 918, 949, 948, 922, 919, 944, 945},
 new ushort[]{ 116, 119, 137, 136},
 new ushort[]{ 672, 691, 673, 690},
 new ushort[]{ 670, 693, 671, 692},
 new ushort[]{ 300, 301, 482, 481},
 new ushort[]{ 367, 368, 548, 547},
 new ushort[]{ 314, 332, 498, 511},
 new ushort[]{ 18, 1 },
 new ushort[]{ 0, 19 },
 new ushort[]{ 304, 485 },
 new ushort[]{ 296, 475 }},
//340 I 2/c 2/m 2/a
new ushort[][]{ new ushort[]{ 915, 920, 1148, 1151, 922, 917, 1149, 1146},
 new ushort[]{ 684, 687, 998, 999},
 new ushort[]{ 234, 105, 235, 104},
 new ushort[]{ 102, 237, 103, 236},
 new ushort[]{ 707, 708, 743, 742},
 new ushort[]{ 53, 54, 70, 69},
 new ushort[]{ 314, 498, 511, 332},
 new ushort[]{ 1, 145 },
 new ushort[]{ 0, 146 },
 new ushort[]{ 42, 59 },
 new ushort[]{ 41, 58 }},
//341 I 2/b 2/c 2/a
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 922, 1146, 945, 1168},
 new ushort[]{ 53, 72, 70, 55},
 new ushort[]{ 367, 370, 548, 549},
 new ushort[]{ 675, 995, 680, 992},
 new ushort[]{ 314, 332, 511, 498},
 new ushort[]{ 0, 146, 19, 163}},
//342 I 2/c 2/a 2/b
new ushort[][]{ new ushort[]{ 915, 949, 1148, 1169, 922, 944, 1149, 1166},
 new ushort[]{ 300, 484, 482, 302},
 new ushort[]{ 707, 710, 743, 744},
 new ushort[]{ 108, 127, 107, 128},
 new ushort[]{ 315, 497, 512, 331},
 new ushort[]{ 0, 19, 146, 163}},
//343 I 2/m 2/m 2/a
new ushort[][]{ new ushort[]{ 915, 943, 942, 918, 922, 938, 939, 919},
 new ushort[]{ 717, 719, 754, 752},
 new ushort[]{ 116, 135, 134, 119},
 new ushort[]{ 371, 575, 554, 396},
 new ushort[]{ 670, 691, 671, 690},
 new ushort[]{ 53, 70 },
 new ushort[]{ 315, 498 },
 new ushort[]{ 314, 497 },
 new ushort[]{ 1, 19 },
 new ushort[]{ 0, 18 }},
//344 I 2/m 2/m 2/b
new ushort[][]{ new ushort[]{ 915, 1145, 1142, 920, 922, 1140, 1143, 917},
 new ushort[]{ 384, 386, 567, 565},
 new ushort[]{ 684, 997, 996, 687},
 new ushort[]{ 715, 1035, 747, 1017},
 new ushort[]{ 102, 235, 103, 234},
 new ushort[]{ 300, 482 },
 new ushort[]{ 314, 331 },
 new ushort[]{ 315, 332 },
 new ushort[]{ 1, 146 },
 new ushort[]{ 0, 145 }},
//345 I 2/b 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 925, 928, 920, 922, 926, 923, 917},
 new ushort[]{ 907, 908, 914, 913},
 new ushort[]{ 684, 688, 689, 687},
 new ushort[]{ 322, 341, 517, 506},
 new ushort[]{ 102, 105, 103, 104},
 new ushort[]{ 675, 680 },
 new ushort[]{ 497, 511 },
 new ushort[]{ 314, 331 },
 new ushort[]{ 145, 146 },
 new ushort[]{ 0, 1 }},
//346 I 2/c 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 940, 942, 921, 922, 941, 939, 916},
 new ushort[]{ 717, 718, 754, 753},
 new ushort[]{ 899, 929, 930, 902},
 new ushort[]{ 551, 578, 375, 394},
 new ushort[]{ 10, 31, 11, 30},
 new ushort[]{ 707, 743 },
 new ushort[]{ 314, 315 },
 new ushort[]{ 497, 498 },
 new ushort[]{ 145, 163 },
 new ushort[]{ 0, 18 }},
//347 I 2/m 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 1144, 1142, 921, 922, 1141, 1143, 916},
 new ushort[]{ 384, 385, 567, 566},
 new ushort[]{ 899, 1134, 1133, 902},
 new ushort[]{ 711, 1020, 750, 1032},
 new ushort[]{ 10, 154, 11, 153},
 new ushort[]{ 367, 548 },
 new ushort[]{ 331, 332 },
 new ushort[]{ 314, 315 },
 new ushort[]{ 18, 163 },
 new ushort[]{ 0, 145 }},
//348 I 2/m 2/a 2/m
new ushort[][]{ new ushort[]{ 915, 927, 928, 918, 922, 924, 923, 919},
 new ushort[]{ 907, 909, 914, 912},
 new ushort[]{ 116, 120, 121, 119},
 new ushort[]{ 338, 519, 505, 324},
 new ushort[]{ 670, 673, 671, 672},
 new ushort[]{ 106, 109 },
 new ushort[]{ 314, 497 },
 new ushort[]{ 331, 511 },
 new ushort[]{ 18, 19 },
 new ushort[]{ 0, 1 }},
//349 P 4
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452},
 new ushort[]{ 30, 153 },
 new ushort[]{ 175},
 new ushort[]{ 10 }},
//350 P 4sub1
new ushort[][]{ new ushort[]{ 915, 928, 1470, 1476}},
//351 P 4sub2
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460},
 new ushort[]{ 30, 155 },
 new ushort[]{ 175, 177 },
 new ushort[]{ 10, 12 }},
//352 P 4sub3
new ushort[][]{ new ushort[]{ 915, 928, 1477, 1469}},
//353 I 4
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452},
 new ushort[]{ 30, 153 },
 new ushort[]{ 10 }},
//354 I 4sub1
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622},
 new ushort[]{ 10, 36 }},
//355 P -4
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455},
 new ushort[]{ 30, 154 },
 new ushort[]{ 175, 176 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 164},
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//356 I -4
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455},
 new ushort[]{ 30, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 24 },
 new ushort[]{ 21 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//357 P 4/m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 922, 916, 1453, 1455},
 new ushort[]{ 903, 906, 1444, 1443},
 new ushort[]{ 899, 902, 1440, 1439},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 175, 176 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 19, 146 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 164},
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//358 P 4sub2/m
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 922, 916, 1461, 1463},
 new ushort[]{ 899, 902, 1444, 1443},
 new ushort[]{ 30, 155, 31, 156},
 new ushort[]{ 175, 177, 176, 178},
 new ushort[]{ 10, 12, 11, 13},
 new ushort[]{ 166, 169 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 19, 145 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 }},
//359 P 4/n
new ushort[][]{ new ushort[]{ 915, 921, 1634, 1632, 1171, 1165, 1453, 1455},
 new ushort[]{ 10, 175, 176, 11},
 new ushort[]{ 313, 510, 330, 496},
 new ushort[]{ 312, 509, 329, 495},
 new ushort[]{ 30, 154 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//360 P 4/n
new ushort[][]{ new ushort[]{ 915, 1170, 1612, 1480, 922, 1165, 1611, 1481},
 new ushort[]{ 338, 504, 505, 339},
 new ushort[]{ 1, 164, 146, 19},
 new ushort[]{ 0, 163, 145, 18},
 new ushort[]{ 322, 517 },
 new ushort[]{ 330, 496 },
 new ushort[]{ 329, 495 }},
//361 P 4sub2/n
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 1178, 1172, 1453, 1455},
 new ushort[]{ 10, 177, 178, 11},
 new ushort[]{ 30, 32, 156, 154},
 new ushort[]{ 315, 512, 331, 497},
 new ushort[]{ 314, 511, 332, 498},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//362 P 4sub2/n
new ushort[][]{ new ushort[]{ 915, 1170, 1485, 1614, 922, 1165, 1484, 1617},
 new ushort[]{ 322, 518, 517, 325},
 new ushort[]{ 504, 506, 339, 341},
 new ushort[]{ 1, 164, 18, 145},
 new ushort[]{ 0, 163, 19, 146},
 new ushort[]{ 315, 511 },
 new ushort[]{ 314, 512 }},
//363 I 4/m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 922, 916, 1453, 1455},
 new ushort[]{ 899, 902, 1440, 1439},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 314, 511, 497, 331},
 new ushort[]{ 10, 11 },
 new ushort[]{ 21, 147 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//364 I 4sub1/a
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622, 952, 1154, 1453, 1643},
 new ushort[]{ 10, 36, 37, 11},
 new ushort[]{ 47, 186, 490, 479},
 new ushort[]{ 44, 189, 489, 480},
 new ushort[]{ 1, 24 },
 new ushort[]{ 0, 21 }},
//365 I 4sub1/a
new ushort[][]{ new ushort[]{ 915, 1151, 1770, 1781, 922, 1146, 1730, 1720},
 new ushort[]{ 53, 197, 70, 209},
 new ushort[]{ 1, 145, 498, 511},
 new ushort[]{ 0, 146, 497, 512},
 new ushort[]{ 47, 190 },
 new ushort[]{ 44, 188 }},
//366 P 4 2 2
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 920, 918, 1451, 1457},
 new ushort[]{ 690, 691, 210, 211},
 new ushort[]{ 672, 673, 76, 77},
 new ushort[]{ 692, 693, 212, 213},
 new ushort[]{ 670, 671, 74, 75},
 new ushort[]{ 763, 766, 765, 764},
 new ushort[]{ 758, 761, 760, 759},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 175, 176 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 146, 19 },
 new ushort[]{ 145, 18 },
 new ushort[]{ 164},
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//367 P 4 2sub1 2
new ushort[][]{ new ushort[]{ 915, 921, 1634, 1632, 1169, 1167, 1451, 1457},
 new ushort[]{ 763, 766, 1086, 1085},
 new ushort[]{ 758, 761, 1082, 1081},
 new ushort[]{ 10, 175, 176, 11},
 new ushort[]{ 30, 154 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//368 P 4sub1 2 2
new ushort[][]{ new ushort[]{ 915, 928, 1470, 1476, 920, 925, 1475, 1471},
 new ushort[]{ 790, 801, 798, 779},
 new ushort[]{ 234, 237, 1394, 1395},
 new ushort[]{ 102, 105, 1376, 1377}},
//369 P 4sub1 2sub1 2
new ushort[][]{ new ushort[]{ 915, 928, 1647, 1648, 1180, 1181, 1451, 1465},
 new ushort[]{ 758, 766, 1090, 1093}},
//370 P 4sub2 2 2
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 920, 918, 1459, 1465},
 new ushort[]{ 786, 789, 773, 772},
 new ushort[]{ 771, 774, 788, 787},
 new ushort[]{ 690, 691, 212, 213},
 new ushort[]{ 672, 673, 74, 75},
 new ushort[]{ 692, 693, 210, 211},
 new ushort[]{ 670, 671, 76, 77},
 new ushort[]{ 30, 155, 31, 156},
 new ushort[]{ 175, 177, 176, 178},
 new ushort[]{ 10, 12, 11, 13},
 new ushort[]{ 166, 169 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 19, 145 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 }},
//371 P 4sub2 2sub1 2
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 1176, 1174, 1451, 1457},
 new ushort[]{ 763, 766, 1082, 1081},
 new ushort[]{ 758, 761, 1086, 1085},
 new ushort[]{ 30, 32, 156, 154},
 new ushort[]{ 10, 177, 178, 11},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//372 P 4sub3 2 2
new ushort[][]{ new ushort[]{ 915, 928, 1477, 1469, 920, 925, 1468, 1478},
 new ushort[]{ 797, 780, 791, 800},
 new ushort[]{ 234, 237, 1396, 1393},
 new ushort[]{ 102, 105, 1378, 1375}},
//373 P 4sub3 2sub1 2
new ushort[][]{ new ushort[]{ 915, 928, 1649, 1646, 1182, 1179, 1451, 1465},
 new ushort[]{ 758, 766, 1094, 1089}},
//374 I 4 2 2
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 920, 918, 1451, 1457},
 new ushort[]{ 835, 838, 1052, 1051},
 new ushort[]{ 672, 673, 76, 77},
 new ushort[]{ 670, 671, 74, 75},
 new ushort[]{ 758, 761, 760, 759},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 10, 11 },
 new ushort[]{ 21, 147 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//375 I 4sub1 2 2
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622, 1156, 951, 1639, 1457},
 new ushort[]{ 713, 1022, 538, 530},
 new ushort[]{ 759, 1086, 835, 1057},
 new ushort[]{ 758, 1087, 837, 1055},
 new ushort[]{ 10, 36, 162, 178},
 new ushort[]{ 1, 24 },
 new ushort[]{ 0, 21 }},
//376 P 4 m m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 917, 919, 1456, 1450},
 new ushort[]{ 700, 702, 220, 222},
 new ushort[]{ 684, 686, 92, 94},
 new ushort[]{ 813, 819, 817, 815},
 new ushort[]{ 153, 30 },
 new ushort[]{ 175},
 new ushort[]{ 10 }},
//377 P 4 b m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 1166, 1168, 1636, 1630},
 new ushort[]{ 851, 857, 1070, 1068},
 new ushort[]{ 153, 30 },
 new ushort[]{ 10, 175 }},
//378 P 4sub2 c m
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 924, 926, 1456, 1450},
 new ushort[]{ 813, 819, 824, 822},
 new ushort[]{ 30, 155, 32, 153},
 new ushort[]{ 175, 177 },
 new ushort[]{ 10, 12 }},
//379 P 4sub2 n m
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 1173, 1175, 1456, 1450},
 new ushort[]{ 813, 819, 1117, 1115},
 new ushort[]{ 30, 32, 155, 153},
 new ushort[]{ 10, 177 }},
//380 P 4 c c
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 924, 926, 1464, 1458},
 new ushort[]{ 30, 153, 32, 155},
 new ushort[]{ 175, 177 },
 new ushort[]{ 10, 12 }},
//381 P 4 n c
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 1173, 1175, 1644, 1638},
 new ushort[]{ 30, 153, 155, 32},
 new ushort[]{ 10, 177 }},
//382 P 4sub2 m c
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 917, 919, 1464, 1458},
 new ushort[]{ 700, 702, 224, 225},
 new ushort[]{ 684, 686, 96, 98},
 new ushort[]{ 30, 155 },
 new ushort[]{ 175, 177 },
 new ushort[]{ 10, 12 }},
//383 P 4sub2 b c
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 1166, 1168, 1644, 1638},
 new ushort[]{ 30, 155, 153, 32},
 new ushort[]{ 10, 12, 175, 177}},
//384 I 4 m m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 917, 919, 1456, 1450},
 new ushort[]{ 684, 686, 92, 94},
 new ushort[]{ 813, 819, 817, 815},
 new ushort[]{ 30, 153 },
 new ushort[]{ 10 }},
//385 I 4 c m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 924, 926, 1464, 1458},
 new ushort[]{ 851, 857, 1070, 1068},
 new ushort[]{ 153, 30 },
 new ushort[]{ 10, 12 }},
//386 I 4sub1 m d
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622, 917, 1175, 1489, 1621},
 new ushort[]{ 116, 276, 1411, 1576},
 new ushort[]{ 10, 36 }},
//387 I 4sub1 c d
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622, 924, 1168, 1491, 1619},
 new ushort[]{ 10, 36, 12, 40}},
//388 P -4 2 m
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 920, 918, 1456, 1450},
 new ushort[]{ 813, 819, 816, 818},
 new ushort[]{ 30, 154, 31, 153},
 new ushort[]{ 690, 691, 211, 210},
 new ushort[]{ 672, 673, 77, 76},
 new ushort[]{ 692, 693, 213, 212},
 new ushort[]{ 670, 671, 75, 74},
 new ushort[]{ 175, 176 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 146, 19 },
 new ushort[]{ 145, 18 },
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//389 P -4 2 c
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 927, 925, 1464, 1458},
 new ushort[]{ 30, 154, 33, 155},
 new ushort[]{ 175, 176, 178, 177},
 new ushort[]{ 10, 11, 13, 12},
 new ushort[]{ 106, 107, 1377, 1378},
 new ushort[]{ 694, 695, 217, 216},
 new ushort[]{ 238, 239, 1395, 1396},
 new ushort[]{ 675, 676, 87, 86},
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 21, 148 },
 new ushort[]{ 166, 169 },
 new ushort[]{ 147, 24 },
 new ushort[]{ 3, 6 }},
//390 P -4 2sub1 m
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 1169, 1167, 1636, 1630},
 new ushort[]{ 851, 857, 1069, 1071},
 new ushort[]{ 10, 11, 176, 175},
 new ushort[]{ 30, 154 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//391 P -4 2sub1 c
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 1176, 1174, 1644, 1638},
 new ushort[]{ 30, 154, 156, 32},
 new ushort[]{ 10, 11, 178, 177},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//392 P -4 m 2
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 917, 919, 1451, 1457},
 new ushort[]{ 700, 702, 223, 221},
 new ushort[]{ 684, 686, 95, 93},
 new ushort[]{ 763, 766, 764, 765},
 new ushort[]{ 758, 761, 759, 760},
 new ushort[]{ 30, 154 },
 new ushort[]{ 175, 176 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 164},
 new ushort[]{ 163},
 new ushort[]{ 0 }},
//393 P -4 c 2
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 924, 926, 1459, 1465},
 new ushort[]{ 30, 154, 32, 156},
 new ushort[]{ 175, 176, 177, 178},
 new ushort[]{ 10, 11, 12, 13},
 new ushort[]{ 786, 789, 772, 773},
 new ushort[]{ 771, 774, 787, 788},
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 166, 169 },
 new ushort[]{ 3, 6 }},
//394 P -4 b 2
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 1166, 1168, 1631, 1637},
 new ushort[]{ 831, 834, 1047, 1048},
 new ushort[]{ 827, 830, 1043, 1044},
 new ushort[]{ 30, 154, 153, 31},
 new ushort[]{ 10, 11, 175, 176},
 new ushort[]{ 19, 146 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//395 P -4 n 2
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 1173, 1175, 1639, 1645},
 new ushort[]{ 30, 154, 155, 33},
 new ushort[]{ 835, 838, 1055, 1056},
 new ushort[]{ 836, 837, 1057, 1054},
 new ushort[]{ 10, 11, 177, 178},
 new ushort[]{ 24, 147 },
 new ushort[]{ 21, 148 },
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//396 I -4 m 2
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 917, 919, 1451, 1457},
 new ushort[]{ 684, 686, 95, 93},
 new ushort[]{ 835, 838, 1055, 1056},
 new ushort[]{ 758, 761, 759, 760},
 new ushort[]{ 30, 154 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 24 },
 new ushort[]{ 21 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//397 I -4 c 2
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 924, 926, 1459, 1465},
 new ushort[]{ 827, 830, 1043, 1044},
 new ushort[]{ 30, 154, 32, 156},
 new ushort[]{ 10, 11, 12, 13},
 new ushort[]{ 771, 774, 787, 788},
 new ushort[]{ 18, 145 },
 new ushort[]{ 21, 24 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//398 I -4 2 m
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 920, 918, 1456, 1450},
 new ushort[]{ 813, 819, 816, 818},
 new ushort[]{ 30, 154, 31, 153},
 new ushort[]{ 672, 673, 77, 76},
 new ushort[]{ 670, 671, 75, 74},
 new ushort[]{ 10, 11 },
 new ushort[]{ 21, 24 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//399 I -4 2 d
new ushort[][]{ new ushort[]{ 915, 921, 1453, 1455, 1156, 1155, 1623, 1621},
 new ushort[]{ 713, 748, 350, 529},
 new ushort[]{ 10, 11, 162, 161},
 new ushort[]{ 1, 147 },
 new ushort[]{ 0, 148 }},
//400 P 4/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 920, 918, 1451, 1457, 922, 916, 1453, 1455, 917, 919, 1456, 1450},
 new ushort[]{ 700, 702, 220, 222, 703, 701, 221, 223},
 new ushort[]{ 684, 686, 92, 94, 687, 685, 93, 95},
 new ushort[]{ 813, 819, 817, 815, 818, 816, 814, 820},
 new ushort[]{ 903, 906, 1444, 1443, 905, 904, 1442, 1445},
 new ushort[]{ 899, 902, 1440, 1439, 901, 900, 1438, 1441},
 new ushort[]{ 692, 693, 212, 213},
 new ushort[]{ 690, 691, 210, 211},
 new ushort[]{ 672, 673, 76, 77},
 new ushort[]{ 670, 671, 74, 75},
 new ushort[]{ 763, 766, 765, 764},
 new ushort[]{ 758, 761, 760, 759},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 175, 176 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 19, 146 },
 new ushort[]{ 164},
 new ushort[]{ 163},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//401 P 4/m 2/c 2/c
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 927, 925, 1459, 1465, 922, 916, 1453, 1455, 924, 926, 1464, 1458},
 new ushort[]{ 899, 902, 1440, 1439, 905, 904, 1442, 1445},
 new ushort[]{ 694, 695, 214, 215, 697, 696, 217, 216},
 new ushort[]{ 675, 676, 80, 81, 680, 679, 87, 86},
 new ushort[]{ 771, 774, 773, 772, 789, 786, 787, 788},
 new ushort[]{ 30, 153, 33, 156, 31, 154, 32, 155},
 new ushort[]{ 175, 178, 176, 177},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 21, 147, 24, 148},
 new ushort[]{ 18, 145, 19, 146},
 new ushort[]{ 163, 164 },
 new ushort[]{ 166, 169 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//402 P 4/n 2/b 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 920, 918, 1451, 1457, 1171, 1165, 1633, 1635, 1166, 1168, 1636, 1630},
 new ushort[]{ 851, 857, 1070, 1068, 856, 854, 1067, 1072},
 new ushort[]{ 672, 673, 76, 77, 1003, 1002, 229, 228},
 new ushort[]{ 670, 671, 74, 75, 1001, 1000, 227, 226},
 new ushort[]{ 763, 766, 765, 764, 1087, 1084, 1085, 1086},
 new ushort[]{ 758, 761, 760, 759, 1083, 1080, 1081, 1082},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 10, 11, 176, 175},
 new ushort[]{ 313, 510, 496, 330},
 new ushort[]{ 312, 509, 495, 329},
 new ushort[]{ 19, 146 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//403 P 4/n 2/b 2/m
new ushort[][]{ new ushort[]{ 915, 1170, 1612, 1480, 1144, 940, 1451, 1637, 922, 1165, 1611, 1481, 1141, 941, 1456, 1630},
 new ushort[]{ 815, 1111, 1066, 857, 1072, 852, 818, 1110},
 new ushort[]{ 709, 1016, 346, 354, 745, 1030, 525, 534},
 new ushort[]{ 707, 1014, 345, 353, 743, 1028, 524, 532},
 new ushort[]{ 763, 1087, 1048, 832, 766, 1084, 1047, 833},
 new ushort[]{ 758, 1083, 1044, 828, 761, 1080, 1043, 829},
 new ushort[]{ 504, 338, 505, 339},
 new ushort[]{ 322, 323, 517, 516},
 new ushort[]{ 1, 164, 146, 19},
 new ushort[]{ 0, 163, 145, 18},
 new ushort[]{ 496, 330 },
 new ushort[]{ 495, 329 },
 new ushort[]{ 313, 510 },
 new ushort[]{ 312, 509 }},
//404 P 4/n 2/n 2/c
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 920, 918, 1451, 1457, 1178, 1172, 1641, 1643, 1173, 1175, 1644, 1638},
 new ushort[]{ 672, 673, 76, 77, 1001, 1000, 227, 226},
 new ushort[]{ 670, 671, 74, 75, 1003, 1002, 229, 228},
 new ushort[]{ 758, 761, 760, 759, 1087, 1084, 1085, 1086},
 new ushort[]{ 153, 30, 154, 31, 33, 156, 32, 155},
 new ushort[]{ 314, 511, 497, 331, 498, 332, 315, 512},
 new ushort[]{ 10, 11, 178, 177},
 new ushort[]{ 147, 21, 148, 24},
 new ushort[]{ 145, 18, 19, 146},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//405 P 4/n 2/n 2/c
new ushort[][]{ new ushort[]{ 915, 1170, 1612, 1480, 1150, 946, 1459, 1645, 922, 1165, 1611, 1481, 1147, 947, 1464, 1638},
 new ushort[]{ 746, 1033, 526, 536, 716, 1019, 349, 356},
 new ushort[]{ 711, 1018, 347, 355, 750, 1034, 528, 537},
 new ushort[]{ 771, 1091, 1052, 836, 789, 1092, 1055, 841},
 new ushort[]{ 338, 504, 341, 507, 505, 339, 506, 340},
 new ushort[]{ 0, 163, 145, 18, 146, 19, 1, 164},
 new ushort[]{ 322, 325, 517, 518},
 new ushort[]{ 329, 495, 330, 496},
 new ushort[]{ 332, 498, 497, 331},
 new ushort[]{ 315, 511 },
 new ushort[]{ 314, 512 }},
//406 P 4/m 2sub1/b m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 1169, 1167, 1631, 1637, 922, 916, 1453, 1455, 1166, 1168, 1636, 1630},
 new ushort[]{ 851, 857, 1070, 1068, 1071, 1069, 852, 858},
 new ushort[]{ 903, 906, 1444, 1443, 1160, 1159, 1626, 1629},
 new ushort[]{ 899, 902, 1440, 1439, 1158, 1157, 1624, 1625},
 new ushort[]{ 831, 834, 1048, 1047},
 new ushort[]{ 827, 830, 1044, 1043},
 new ushort[]{ 30, 153, 154, 31},
 new ushort[]{ 10, 176, 11, 175},
 new ushort[]{ 18, 145 },
 new ushort[]{ 19, 146 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//407 P 4/m 2sub1/n c
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 1176, 1174, 1639, 1645, 922, 916, 1453, 1455, 1173, 1175, 1644, 1638},
 new ushort[]{ 899, 902, 1440, 1439, 1160, 1159, 1626, 1629},
 new ushort[]{ 835, 838, 1052, 1051, 842, 839, 1055, 1056},
 new ushort[]{ 30, 153, 156, 33, 31, 154, 155, 32},
 new ushort[]{ 10, 178, 11, 177},
 new ushort[]{ 21, 147, 24, 148},
 new ushort[]{ 18, 145, 146, 19},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//408 P 4/n 2sub1/m m
new ushort[][]{ new ushort[]{ 915, 921, 1634, 1632, 1169, 1167, 1451, 1457, 1171, 1165, 1453, 1455, 917, 919, 1636, 1630},
 new ushort[]{ 851, 857, 855, 853, 1071, 1069, 1067, 1072},
 new ushort[]{ 116, 118, 1584, 1583, 272, 274, 1386, 1388},
 new ushort[]{ 763, 766, 1086, 1085, 1087, 1084, 764, 765},
 new ushort[]{ 758, 761, 1082, 1081, 1083, 1080, 759, 760},
 new ushort[]{ 10, 175, 176, 11},
 new ushort[]{ 313, 510, 330, 496},
 new ushort[]{ 312, 509, 329, 495},
 new ushort[]{ 30, 154 },
 new ushort[]{ 1, 164 },
 new ushort[]{ 0, 163 }},
//409 P 4/n 2sub1/m m
new ushort[][]{ new ushort[]{ 915, 1170, 1612, 1480, 942, 1142, 1631, 1457, 922, 1165, 1611, 1481, 939, 1143, 1636, 1450},
 new ushort[]{ 813, 1113, 1070, 853, 856, 1069, 1109, 820},
 new ushort[]{ 384, 405, 1595, 1420, 585, 567, 1606, 1433},
 new ushort[]{ 764, 1086, 1046, 834, 765, 1085, 1049, 831},
 new ushort[]{ 759, 1082, 1042, 830, 760, 1081, 1045, 827},
 new ushort[]{ 504, 338, 339, 505},
 new ushort[]{ 1, 164, 146, 19},
 new ushort[]{ 0, 163, 145, 18},
 new ushort[]{ 322, 517 },
 new ushort[]{ 496, 330 },
 new ushort[]{ 495, 329 }},
//410 P 4/n 2sub1/c c
new ushort[][]{ new ushort[]{ 915, 921, 1634, 1632, 1176, 1174, 1459, 1465, 1171, 1165, 1453, 1455, 924, 926, 1644, 1638},
 new ushort[]{ 771, 774, 1090, 1089, 1095, 1092, 787, 788},
 new ushort[]{ 10, 175, 178, 13, 176, 11, 12, 177},
 new ushort[]{ 312, 509, 329, 495, 330, 496, 313, 510},
 new ushort[]{ 30, 156, 154, 32},
 new ushort[]{ 0, 163, 164, 1},
 new ushort[]{ 3, 166, 169, 6}},
//411 P 4/n 2sub1/c c
new ushort[][]{ new ushort[]{ 915, 1170, 1612, 1480, 948, 1148, 1639, 1465, 922, 1165, 1611, 1481, 945, 1149, 1644, 1458},
 new ushort[]{ 772, 1090, 1050, 838, 788, 1093, 1057, 839},
 new ushort[]{ 504, 338, 341, 507, 339, 505, 506, 340},
 new ushort[]{ 0, 163, 145, 18, 19, 146, 164, 1},
 new ushort[]{ 322, 519, 517, 324},
 new ushort[]{ 495, 329, 330, 496},
 new ushort[]{ 497, 331, 332, 498}},
//412 P 4sub2/m 2/m 2/c
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 920, 918, 1459, 1465, 922, 916, 1461, 1463, 917, 919, 1464, 1458},
 new ushort[]{ 899, 902, 1444, 1443, 901, 900, 1442, 1445},
 new ushort[]{ 248, 250, 1409, 1407, 249, 251, 1408, 1410},
 new ushort[]{ 116, 118, 1391, 1389, 117, 119, 1390, 1392},
 new ushort[]{ 771, 774, 788, 787, 789, 786, 772, 773},
 new ushort[]{ 690, 691, 212, 213},
 new ushort[]{ 672, 673, 74, 75},
 new ushort[]{ 692, 693, 210, 211},
 new ushort[]{ 670, 671, 76, 77},
 new ushort[]{ 30, 155, 31, 156},
 new ushort[]{ 175, 177, 176, 178},
 new ushort[]{ 10, 12, 11, 13},
 new ushort[]{ 166, 169 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 19, 145 },
 new ushort[]{ 18, 146 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 0, 1 }},
//413 P 4sub2/m 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 927, 925, 1451, 1457, 922, 916, 1461, 1463, 924, 926, 1456, 1450},
 new ushort[]{ 813, 819, 824, 822, 825, 823, 814, 820},
 new ushort[]{ 899, 902, 1444, 1443, 905, 904, 1438, 1441},
 new ushort[]{ 694, 695, 216, 217, 697, 696, 215, 214},
 new ushort[]{ 675, 676, 86, 87, 680, 679, 81, 80},
 new ushort[]{ 30, 155, 33, 154, 31, 156, 32, 153},
 new ushort[]{ 763, 766, 760, 759},
 new ushort[]{ 758, 761, 765, 764},
 new ushort[]{ 175, 177, 178, 176},
 new ushort[]{ 10, 12, 13, 11},
 new ushort[]{ 18, 146, 19, 145},
 new ushort[]{ 21, 148, 24, 147},
 new ushort[]{ 166, 169 },
 new ushort[]{ 163, 164 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 0, 1 }},
//414 P 4sub2/n 2/b 2/c
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 927, 925, 1631, 1637, 1178, 1172, 1453, 1455, 1166, 1168, 1464, 1458},
 new ushort[]{ 827, 830, 833, 832, 1049, 1046, 1043, 1044},
 new ushort[]{ 679, 680, 230, 231, 1007, 1006, 81, 80},
 new ushort[]{ 675, 676, 232, 233, 1005, 1004, 87, 86},
 new ushort[]{ 10, 177, 13, 176, 178, 11, 175, 12},
 new ushort[]{ 30, 32, 33, 31, 156, 154, 153, 155},
 new ushort[]{ 314, 511, 332, 498, 497, 331, 512, 315},
 new ushort[]{ 0, 164, 1, 163},
 new ushort[]{ 18, 19, 146, 145},
 new ushort[]{ 3, 169, 166, 6},
 new ushort[]{ 21, 24, 147, 148}},
//415 P 4sub2/n 2/b 2/c
new ushort[][]{ new ushort[]{ 915, 1170, 1616, 1483, 1144, 940, 1459, 1645, 922, 1165, 1615, 1486, 1141, 941, 1464, 1638},
 new ushort[]{ 771, 1091, 1056, 840, 789, 1092, 1051, 837},
 new ushort[]{ 709, 1016, 345, 353, 745, 1030, 524, 532},
 new ushort[]{ 707, 1014, 346, 354, 743, 1028, 525, 534},
 new ushort[]{ 504, 340, 505, 341, 339, 507, 338, 506},
 new ushort[]{ 322, 324, 323, 325, 517, 519, 516, 518},
 new ushort[]{ 0, 163, 146, 19, 145, 18, 1, 164},
 new ushort[]{ 498, 331, 497, 332},
 new ushort[]{ 314, 315, 512, 511},
 new ushort[]{ 495, 330, 329, 496},
 new ushort[]{ 312, 313, 509, 510}},
//416 P 4sub2/n 2/n 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 920, 918, 1639, 1645, 1178, 1172, 1453, 1455, 1173, 1175, 1456, 1450},
 new ushort[]{ 813, 819, 1117, 1115, 818, 816, 1114, 1119},
 new ushort[]{ 839, 842, 837, 836, 1057, 1054, 1051, 1052},
 new ushort[]{ 835, 838, 841, 840, 1053, 1050, 1055, 1056},
 new ushort[]{ 672, 673, 226, 227, 1001, 1000, 77, 76},
 new ushort[]{ 670, 671, 228, 229, 1003, 1002, 75, 74},
 new ushort[]{ 30, 32, 31, 33, 156, 154, 155, 153},
 new ushort[]{ 10, 177, 11, 178},
 new ushort[]{ 512, 315, 497, 331},
 new ushort[]{ 314, 511, 332, 498},
 new ushort[]{ 21, 24, 147, 148},
 new ushort[]{ 18, 19, 146, 145},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//417 P 4sub2/n 2/n 2/m
new ushort[][]{ new ushort[]{ 915, 1170, 1616, 1483, 1150, 946, 1451, 1637, 922, 1165, 1615, 1486, 1147, 947, 1456, 1630},
 new ushort[]{ 815, 1111, 1073, 864, 1079, 859, 818, 1110},
 new ushort[]{ 763, 1087, 1044, 828, 766, 1084, 1043, 829},
 new ushort[]{ 758, 1083, 1048, 832, 761, 1080, 1047, 833},
 new ushort[]{ 711, 1018, 348, 357, 750, 1034, 527, 535},
 new ushort[]{ 715, 1020, 347, 355, 747, 1032, 528, 537},
 new ushort[]{ 322, 324, 325, 323, 517, 519, 518, 516},
 new ushort[]{ 504, 340, 507, 339},
 new ushort[]{ 0, 163, 146, 19},
 new ushort[]{ 1, 164, 145, 18},
 new ushort[]{ 312, 313, 509, 510},
 new ushort[]{ 314, 315, 512, 511},
 new ushort[]{ 497, 332 },
 new ushort[]{ 331, 498 }},
//418 P 4sub2/m 2sub1/b 2/c
new ushort[][]{ new ushort[]{ 915, 921, 1462, 1460, 1169, 1167, 1639, 1645, 922, 916, 1461, 1463, 1166, 1168, 1644, 1638},
 new ushort[]{ 899, 902, 1444, 1443, 1158, 1157, 1626, 1629},
 new ushort[]{ 835, 838, 1056, 1055, 842, 839, 1051, 1052},
 new ushort[]{ 30, 155, 154, 33, 31, 156, 153, 32},
 new ushort[]{ 10, 12, 176, 178, 11, 13, 175, 177},
 new ushort[]{ 21, 148, 24, 147},
 new ushort[]{ 18, 146, 145, 19},
 new ushort[]{ 3, 6, 169, 166},
 new ushort[]{ 0, 1, 163, 164}},
//419 P 4sub2/m 2sub1/n 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 1176, 1174, 1451, 1457, 922, 916, 1641, 1643, 1173, 1175, 1456, 1450},
 new ushort[]{ 813, 819, 1117, 1115, 1118, 1116, 814, 820},
 new ushort[]{ 899, 902, 1628, 1627, 1160, 1159, 1438, 1441},
 new ushort[]{ 30, 32, 156, 154, 31, 33, 155, 153},
 new ushort[]{ 759, 760, 1084, 1087},
 new ushort[]{ 758, 761, 1086, 1085},
 new ushort[]{ 10, 177, 178, 11},
 new ushort[]{ 21, 24, 147, 148},
 new ushort[]{ 18, 19, 146, 145},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//420 P 4sub2/n 2sub1/m 2/c
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 1176, 1174, 1451, 1457, 1178, 1172, 1453, 1455, 917, 919, 1644, 1638},
 new ushort[]{ 116, 118, 1587, 1585, 275, 277, 1386, 1388},
 new ushort[]{ 758, 761, 1086, 1085, 1087, 1084, 759, 760},
 new ushort[]{ 314, 511, 332, 498, 331, 497, 315, 512},
 new ushort[]{ 30, 32, 156, 154},
 new ushort[]{ 10, 177, 178, 11},
 new ushort[]{ 1, 163 },
 new ushort[]{ 0, 164 }},
//421 P 4sub2/n 2sub1/m 2/c
new ushort[][]{ new ushort[]{ 915, 1170, 1616, 1483, 942, 1142, 1639, 1465, 922, 1165, 1615, 1486, 939, 1143, 1644, 1458},
 new ushort[]{ 384, 405, 1596, 1421, 585, 567, 1607, 1434},
 new ushort[]{ 772, 1090, 1054, 842, 788, 1093, 1053, 835},
 new ushort[]{ 0, 163, 146, 19, 18, 145, 164, 1},
 new ushort[]{ 322, 324, 517, 519},
 new ushort[]{ 504, 340, 339, 507},
 new ushort[]{ 497, 332 },
 new ushort[]{ 498, 331 }},
//422 P 4sub2/n 2sub1/c 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1642, 1640, 1169, 1167, 1459, 1465, 1178, 1172, 1453, 1455, 924, 926, 1636, 1630},
 new ushort[]{ 851, 857, 862, 860, 1071, 1069, 1074, 1079},
 new ushort[]{ 786, 789, 1090, 1089, 1095, 1092, 772, 773},
 new ushort[]{ 771, 774, 1094, 1093, 1091, 1088, 787, 788},
 new ushort[]{ 10, 177, 176, 13, 178, 11, 12, 175},
 new ushort[]{ 30, 32, 154, 156},
 new ushort[]{ 315, 512, 331, 497},
 new ushort[]{ 314, 511, 332, 498},
 new ushort[]{ 0, 164, 163, 1},
 new ushort[]{ 3, 169, 166, 6}},
//423 P 4sub2/n 2sub1/c 2/m
new ushort[][]{ new ushort[]{ 915, 1170, 1616, 1483, 948, 1148, 1631, 1457, 922, 1165, 1615, 1486, 945, 1149, 1636, 1450},
 new ushort[]{ 813, 1113, 1077, 860, 863, 1076, 1109, 820},
 new ushort[]{ 759, 1082, 1046, 834, 760, 1081, 1049, 831},
 new ushort[]{ 764, 1086, 1042, 830, 765, 1085, 1045, 827},
 new ushort[]{ 504, 340, 341, 505, 339, 507, 506, 338},
 new ushort[]{ 322, 324, 519, 517},
 new ushort[]{ 0, 163, 146, 19},
 new ushort[]{ 1, 164, 145, 18},
 new ushort[]{ 498, 331, 332, 497},
 new ushort[]{ 495, 330, 329, 496}},
//424 I 4/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 920, 918, 1451, 1457, 922, 916, 1453, 1455, 917, 919, 1456, 1450},
 new ushort[]{ 116, 118, 1387, 1385, 117, 119, 1386, 1388},
 new ushort[]{ 813, 819, 817, 815, 818, 816, 814, 820},
 new ushort[]{ 899, 902, 1440, 1439, 901, 900, 1438, 1441},
 new ushort[]{ 835, 838, 1052, 1051, 842, 839, 1055, 1056},
 new ushort[]{ 690, 691, 210, 211},
 new ushort[]{ 670, 671, 74, 75},
 new ushort[]{ 758, 761, 760, 759},
 new ushort[]{ 30, 153, 31, 154},
 new ushort[]{ 314, 511, 497, 331},
 new ushort[]{ 10, 11 },
 new ushort[]{ 21, 147 },
 new ushort[]{ 18, 145 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//425 I 4/m 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 921, 1454, 1452, 927, 925, 1459, 1465, 922, 916, 1453, 1455, 924, 926, 1464, 1458},
 new ushort[]{ 851, 857, 1070, 1068, 863, 861, 1074, 1079},
 new ushort[]{ 899, 902, 1440, 1439, 905, 904, 1442, 1445},
 new ushort[]{ 675, 676, 80, 81, 680, 679, 87, 86},
 new ushort[]{ 771, 774, 773, 772, 789, 786, 787, 788},
 new ushort[]{ 827, 830, 1044, 1043},
 new ushort[]{ 30, 153, 33, 156},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 314, 511, 497, 331},
 new ushort[]{ 18, 145 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 21, 147 },
 new ushort[]{ 3, 6 }},
//426 I 4sub1/a 2/m 2/d
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622, 1156, 951, 1639, 1457, 952, 1154, 1453, 1643, 1173, 919, 1623, 1487},
 new ushort[]{ 116, 276, 1411, 1576, 255, 138, 1586, 1388},
 new ushort[]{ 758, 1087, 837, 1055, 838, 1054, 759, 1086},
 new ushort[]{ 713, 1022, 538, 530, 714, 1021, 350, 358},
 new ushort[]{ 10, 36, 162, 178},
 new ushort[]{ 47, 186, 490, 479},
 new ushort[]{ 44, 189, 489, 480},
 new ushort[]{ 1, 24 },
 new ushort[]{ 0, 21 }},
//427 I 4sub1/a 2/m 2/d
new ushort[][]{ new ushort[]{ 915, 1151, 1727, 1722, 1150, 918, 1726, 1723, 922, 1146, 1773, 1779, 1147, 919, 1775, 1776},
 new ushort[]{ 116, 253, 1711, 1705, 252, 119, 1710, 1706},
 new ushort[]{ 867, 1127, 871, 1122, 872, 1121, 868, 1126},
 new ushort[]{ 670, 991, 366, 363, 671, 990, 542, 545},
 new ushort[]{ 53, 73, 196, 208},
 new ushort[]{ 1, 145, 332, 314},
 new ushort[]{ 0, 146, 331, 315},
 new ushort[]{ 46, 64 },
 new ushort[]{ 61, 202 }},
//428 I 4sub1/a 2/c 2/d
new ushort[][]{ new ushort[]{ 915, 1177, 1488, 1622, 1153, 953, 1631, 1465, 952, 1154, 1453, 1643, 1166, 926, 1620, 1490},
 new ushort[]{ 771, 1095, 833, 1043, 830, 1046, 787, 1090},
 new ushort[]{ 373, 398, 1423, 1599, 576, 555, 1424, 1598},
 new ushort[]{ 10, 36, 159, 176, 37, 11, 175, 158},
 new ushort[]{ 44, 189, 489, 480, 186, 47, 490, 479},
 new ushort[]{ 3, 19, 18, 6},
 new ushort[]{ 0, 21, 147, 163}},
//429 I 4sub1/a 2/c 2/d
new ushort[][]{ new ushort[]{ 915, 1151, 1727, 1722, 1144, 925, 1728, 1721, 922, 1146, 1773, 1779, 1141, 926, 1771, 1780},
 new ushort[]{ 865, 1128, 873, 1123, 874, 1120, 866, 1125},
 new ushort[]{ 675, 995, 365, 359, 680, 992, 540, 543},
 new ushort[]{ 53, 73, 194, 209, 70, 57, 204, 197},
 new ushort[]{ 0, 146, 331, 315, 145, 1, 332, 314},
 new ushort[]{ 44, 63, 65, 47},
 new ushort[]{ 46, 64, 189, 202}},
//430 P 3
new ushort[][]{ new ushort[]{ 915, 1507, 1340 },
 new ushort[]{ 471},
 new ushort[]{ 292},
 new ushort[]{ 10 }},
//431 P 3sub1
new ushort[][]{ new ushort[]{ 915, 1510, 1344 }},
//432 P 3sub2
new ushort[][]{ new ushort[]{ 915, 1511, 1343 }},
//433 R 3
new ushort[][]{ new ushort[]{ 915, 1507, 1340 },
 new ushort[]{ 10 }},
//434 R 3
new ushort[][]{ new ushort[]{ 915, 1817, 1555 },
 new ushort[]{ 802}},
//435 P -3
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 922, 1498, 1359 },
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 292, 472 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//436 R -3
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 922, 1498, 1359 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//437 R -3
new ushort[][]{ new ushort[]{ 915, 1817, 1555, 922, 1824, 1562 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 802, 809 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//438 P 3 1 2
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1457, 1350, 892 },
 new ushort[]{ 764, 726, 445 },
 new ushort[]{ 759, 724, 442 },
 new ushort[]{ 471, 472 },
 new ushort[]{ 292, 293 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 468},
 new ushort[]{ 467},
 new ushort[]{ 289},
 new ushort[]{ 288},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//439 P 3 2 1
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1451, 1370, 882 },
 new ushort[]{ 672, 76, 766 },
 new ushort[]{ 670, 74, 761 },
 new ushort[]{ 292, 472 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//440 P 3sub1 1 2
new ushort[][]{ new ushort[]{ 915, 1510, 1344, 1474, 1353, 892 },
 new ushort[]{ 794, 731, 445 },
 new ushort[]{ 768, 732, 442 }},
//441 P 3sub1 2 1
new ushort[][]{ new ushort[]{ 915, 1510, 1344, 1451, 1374, 885 },
 new ushort[]{ 681, 82, 766 },
 new ushort[]{ 674, 84, 761 }},
//442 P 3sub2 1 2
new ushort[][]{ new ushort[]{ 915, 1511, 1343, 1467, 1354, 892 },
 new ushort[]{ 776, 735, 445 },
 new ushort[]{ 783, 728, 442 }},
//443 P 3sub2 2 1
new ushort[][]{ new ushort[]{ 915, 1511, 1343, 1451, 1373, 886 },
 new ushort[]{ 677, 88, 766 },
 new ushort[]{ 678, 78, 761 }},
//444 R 3 2
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1451, 1370, 882 },
 new ushort[]{ 672, 76, 766 },
 new ushort[]{ 670, 74, 761 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//445 R 3 2
new ushort[][]{ new ushort[]{ 915, 1817, 1555, 1457, 973, 1850 },
 new ushort[]{ 243, 1399, 1517 },
 new ushort[]{ 111, 1381, 1513 },
 new ushort[]{ 802, 809 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//446 P 3 m 1
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1456, 1349, 891 },
 new ushort[]{ 815, 736, 463 },
 new ushort[]{ 471},
 new ushort[]{ 292},
 new ushort[]{ 10 }},
//447 P 3 1 m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1450, 1369, 881 },
 new ushort[]{ 684, 92, 819 },
 new ushort[]{ 292, 471 },
 new ushort[]{ 10 }},
//448 P 3 c 1
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1464, 1351, 893 },
 new ushort[]{ 471, 473 },
 new ushort[]{ 292, 294 },
 new ushort[]{ 10, 12 }},
//449 P 3 1 c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1458, 1371, 883 },
 new ushort[]{ 292, 473 },
 new ushort[]{ 10, 12 }},
//450 R 3 m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1456, 1349, 891 },
 new ushort[]{ 815, 736, 463 },
 new ushort[]{ 10 }},
//451 R 3 m
new ushort[][]{ new ushort[]{ 915, 1817, 1555, 1450, 966, 1843 },
 new ushort[]{ 813, 1809, 958 },
 new ushort[]{ 802}},
//452 R 3 c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1464, 1351, 893 },
 new ushort[]{ 10, 12 }},
//453 R 3 c
new ushort[][]{ new ushort[]{ 915, 1817, 1555, 1638, 1206, 1905 },
 new ushort[]{ 802, 1101 }},
//454 P -3 1 2/m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1457, 1350, 892, 922, 1498, 1359, 1450, 1369, 881},
 new ushort[]{ 684, 92, 819, 95, 687, 814 },
 new ushort[]{ 764, 726, 445, 765, 727, 444 },
 new ushort[]{ 759, 724, 442, 760, 725, 441 },
 new ushort[]{ 292, 293, 472, 471},
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 289, 468 },
 new ushort[]{ 288, 467 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//455 P -3 1 2/c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1465, 1352, 894, 922, 1498, 1359, 1458, 1371, 883},
 new ushort[]{ 772, 729, 449, 788, 734, 455 },
 new ushort[]{ 145, 18, 163, 19, 146, 164 },
 new ushort[]{ 292, 295, 472, 473},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 469, 291 },
 new ushort[]{ 290, 470 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//456 P -3 2/m 1
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1451, 1370, 882, 922, 1498, 1359, 1456, 1349, 891},
 new ushort[]{ 815, 736, 463, 818, 462, 739 },
 new ushort[]{ 672, 76, 766, 673, 77, 763 },
 new ushort[]{ 670, 74, 761, 671, 75, 758 },
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 292, 472 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//457 P -3 2/c 1
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1459, 1372, 884, 922, 1498, 1359, 1464, 1351, 893},
 new ushort[]{ 675, 80, 774, 680, 87, 786 },
 new ushort[]{ 145, 18, 163, 19, 146, 164 },
 new ushort[]{ 292, 474, 472, 294},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//458 R -3 2/m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1451, 1370, 882, 922, 1498, 1359, 1456, 1349, 891},
 new ushort[]{ 815, 736, 463, 818, 462, 739 },
 new ushort[]{ 672, 76, 766, 673, 77, 763 },
 new ushort[]{ 670, 74, 761, 671, 75, 758 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//459 R -3 2/m
new ushort[][]{ new ushort[]{ 915, 1817, 1555, 1457, 973, 1850, 922, 1824, 1562, 1450, 966, 1843},
 new ushort[]{ 813, 1809, 958, 820, 965, 1816 },
 new ushort[]{ 764, 218, 699, 765, 219, 698 },
 new ushort[]{ 759, 90, 683, 760, 91, 682 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 802, 809 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//460 R -3 2/c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 1459, 1372, 884, 922, 1498, 1359, 1464, 1351, 893},
 new ushort[]{ 675, 80, 774, 680, 87, 786 },
 new ushort[]{ 145, 18, 163, 19, 146, 164 },
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//461 R -3 2/c
new ushort[][]{ new ushort[]{ 915, 1817, 1555, 1645, 1213, 1912, 922, 1824, 1562, 1638, 1206, 1905},
 new ushort[]{ 836, 351, 1023, 841, 531, 1036 },
 new ushort[]{ 145, 18, 1, 146, 19, 163 },
 new ushort[]{ 802, 1108, 809, 1101},
 new ushort[]{ 0, 164 },
 new ushort[]{ 314, 512 }},
//462 P 6
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358 },
 new ushort[]{ 153, 30, 175 },
 new ushort[]{ 292, 471 },
 new ushort[]{ 10 }},
//463 P 6sub1
new ushort[][]{ new ushort[]{ 915, 1510, 1344, 928, 1503, 1362 }},
//464 P 6sub5
new ushort[][]{ new ushort[]{ 915, 1511, 1343, 928, 1501, 1364 }},
//465 P 6sub2
new ushort[][]{ new ushort[]{ 915, 1511, 1343, 921, 1502, 1361 },
 new ushort[]{ 175, 160, 34 },
 new ushort[]{ 10, 16, 14 }},
//466 P 6sub4
new ushort[][]{ new ushort[]{ 915, 1510, 1344, 921, 1500, 1363 },
 new ushort[]{ 175, 157, 38 },
 new ushort[]{ 10, 14, 16 }},
//467 P 6sub3
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360 },
 new ushort[]{ 292, 473 },
 new ushort[]{ 10, 12 }},
//468 P -6
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 916, 1508, 1341 },
 new ushort[]{ 903, 1505, 1338 },
 new ushort[]{ 899, 1504, 1337 },
 new ushort[]{ 471, 472 },
 new ushort[]{ 292, 293 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 468},
 new ushort[]{ 467},
 new ushort[]{ 289},
 new ushort[]{ 288},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//469 P 6/m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358, 922, 1498, 1359, 916, 1508, 1341},
 new ushort[]{ 903, 1505, 1338, 906, 1495, 1356 },
 new ushort[]{ 899, 1504, 1337, 902, 1494, 1355 },
 new ushort[]{ 153, 30, 175, 154, 31, 176 },
 new ushort[]{ 292, 471, 472, 293},
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 289, 468 },
 new ushort[]{ 288, 467 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//470 P 6sub3/m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360, 922, 1498, 1359, 923, 1509, 1342},
 new ushort[]{ 907, 1506, 1339, 914, 1496, 1357 },
 new ushort[]{ 145, 18, 163, 146, 19, 164 },
 new ushort[]{ 292, 473, 472, 295},
 new ushort[]{ 10, 12, 11, 13},
 new ushort[]{ 469, 291 },
 new ushort[]{ 290, 470 },
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//471 P 6 2 2
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358, 1451, 1370, 882, 1457, 1350, 892},
 new ushort[]{ 764, 726, 445, 765, 727, 444 },
 new ushort[]{ 759, 724, 442, 760, 725, 441 },
 new ushort[]{ 672, 76, 766, 673, 77, 763 },
 new ushort[]{ 670, 74, 761, 671, 75, 758 },
 new ushort[]{ 153, 30, 175, 31, 154, 176 },
 new ushort[]{ 292, 471, 472, 293},
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 289, 468 },
 new ushort[]{ 288, 467 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//472 P 6sub1 2 2
new ushort[][]{ new ushort[]{ 915, 1510, 1344, 928, 1503, 1362, 1466, 1370, 886, 1479, 1352, 896},
 new ushort[]{ 729, 460, 781, 734, 443, 792 },
 new ushort[]{ 670, 78, 785, 673, 89, 775 }},
//473 P 6sub5 2 2
new ushort[][]{ new ushort[]{ 915, 1511, 1343, 928, 1501, 1364, 1473, 1370, 885, 1472, 1352, 898},
 new ushort[]{ 733, 457, 762, 730, 452, 799 },
 new ushort[]{ 670, 84, 770, 673, 83, 793 }},
//474 P 6sub2 2 2
new ushort[][]{ new ushort[]{ 915, 1511, 1343, 921, 1502, 1361, 1473, 1370, 885, 1474, 1350, 895},
 new ushort[]{ 726, 451, 794, 727, 450, 795 },
 new ushort[]{ 724, 454, 768, 725, 453, 769 },
 new ushort[]{ 672, 82, 796, 673, 83, 793 },
 new ushort[]{ 670, 84, 770, 671, 85, 767 },
 new ushort[]{ 153, 38, 179, 39, 154, 180 },
 new ushort[]{ 10, 16, 14, 17, 11, 15 },
 new ushort[]{ 146, 22, 170 },
 new ushort[]{ 145, 23, 165 },
 new ushort[]{ 1, 4, 7 },
 new ushort[]{ 0, 5, 2 }},
//475 P 6sub4 2 2
new ushort[][]{ new ushort[]{ 915, 1510, 1344, 921, 1500, 1363, 1466, 1370, 886, 1467, 1350, 897},
 new ushort[]{ 726, 459, 776, 727, 458, 777 },
 new ushort[]{ 724, 447, 783, 725, 446, 784 },
 new ushort[]{ 672, 88, 778, 673, 89, 775 },
 new ushort[]{ 670, 78, 785, 671, 79, 782 },
 new ushort[]{ 153, 34, 181, 35, 154, 182 },
 new ushort[]{ 10, 14, 16, 15, 11, 17 },
 new ushort[]{ 146, 25, 167 },
 new ushort[]{ 145, 20, 168 },
 new ushort[]{ 1, 7, 4 },
 new ushort[]{ 0, 2, 5 }},
//476 P 6sub3 2 2
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360, 1451, 1370, 882, 1465, 1352, 894},
 new ushort[]{ 729, 449, 772, 734, 455, 788 },
 new ushort[]{ 670, 74, 761, 673, 77, 763 },
 new ushort[]{ 292, 473, 472, 295},
 new ushort[]{ 10, 12, 11, 13},
 new ushort[]{ 291, 469 },
 new ushort[]{ 290, 470 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 0, 1 }},
//477 P 6 m m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358, 1456, 1349, 891, 1450, 1369, 881},
 new ushort[]{ 815, 736, 463, 817, 738, 461 },
 new ushort[]{ 684, 92, 819, 686, 94, 813 },
 new ushort[]{ 153, 30, 175 },
 new ushort[]{ 292, 471 },
 new ushort[]{ 10 }},
//478 P 6 c c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358, 1464, 1351, 893, 1458, 1371, 883},
 new ushort[]{ 153, 30, 175, 32, 155, 177 },
 new ushort[]{ 292, 471, 294, 473},
 new ushort[]{ 10, 12 }},
//479 P 6sub3 c m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360, 1464, 1351, 893, 1450, 1369, 881},
 new ushort[]{ 684, 92, 819, 689, 98, 821 },
 new ushort[]{ 292, 473, 294, 471},
 new ushort[]{ 10, 12 }},
//480 P 6sub3 m c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360, 1456, 1349, 891, 1458, 1371, 883},
 new ushort[]{ 815, 736, 463, 824, 741, 465 },
 new ushort[]{ 292, 473 },
 new ushort[]{ 10, 12 }},
//481 P -6 m 2
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 916, 1508, 1341, 1456, 1349, 891, 1457, 1350, 892},
 new ushort[]{ 815, 736, 463, 816, 737, 464 },
 new ushort[]{ 903, 1505, 1338, 1445, 1346, 888 },
 new ushort[]{ 899, 1504, 1337, 1441, 1345, 887 },
 new ushort[]{ 764, 726, 445 },
 new ushort[]{ 759, 724, 442 },
 new ushort[]{ 471, 472 },
 new ushort[]{ 292, 293 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 468},
 new ushort[]{ 467},
 new ushort[]{ 289},
 new ushort[]{ 288},
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//482 P -6 c 2
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 923, 1509, 1342, 1464, 1351, 893, 1457, 1350, 892},
 new ushort[]{ 907, 1506, 1339, 1449, 1348, 890 },
 new ushort[]{ 759, 724, 442, 764, 726, 445 },
 new ushort[]{ 471, 474, 473, 472},
 new ushort[]{ 292, 295, 294, 293},
 new ushort[]{ 10, 13, 12, 11},
 new ushort[]{ 469, 470 },
 new ushort[]{ 467, 468 },
 new ushort[]{ 290, 291 },
 new ushort[]{ 288, 289 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 0, 1 }},
//483 P -6 2 m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 916, 1508, 1341, 1451, 1370, 882, 1450, 1369, 881},
 new ushort[]{ 903, 1505, 1338, 1442, 1366, 878 },
 new ushort[]{ 899, 1504, 1337, 1438, 1365, 877 },
 new ushort[]{ 684, 92, 819, 685, 93, 820 },
 new ushort[]{ 292, 293, 472, 471},
 new ushort[]{ 672, 76, 766 },
 new ushort[]{ 670, 74, 761 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 289, 468 },
 new ushort[]{ 288, 467 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//484 P -6 2 c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 923, 1509, 1342, 1451, 1370, 882, 1458, 1371, 883},
 new ushort[]{ 907, 1506, 1339, 1448, 1368, 880 },
 new ushort[]{ 670, 74, 761, 672, 76, 766 },
 new ushort[]{ 292, 295, 472, 473},
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 469, 291 },
 new ushort[]{ 290, 470 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 0, 1 }},
//485 P 6/m 2/m 2/m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358, 1451, 1370, 882, 1457, 1350, 892, 922, 1498, 1359, 916, 1508, 1341, 1456, 1349, 891, 1450, 1369, 881},
 new ushort[]{ 903, 1505, 1338, 906, 1495, 1356, 1442, 1366, 878, 1445, 1346, 888},
 new ushort[]{ 899, 1504, 1337, 902, 1494, 1355, 1438, 1365, 877, 1441, 1345, 887},
 new ushort[]{ 736, 463, 815, 738, 461, 817, 462, 739, 818, 464, 737, 816},
 new ushort[]{ 684, 92, 819, 686, 94, 813, 93, 685, 820, 95, 687, 814},
 new ushort[]{ 726, 445, 764, 727, 444, 765 },
 new ushort[]{ 724, 442, 759, 725, 441, 760 },
 new ushort[]{ 672, 76, 766, 673, 77, 763 },
 new ushort[]{ 670, 74, 761, 671, 75, 758 },
 new ushort[]{ 153, 30, 175, 31, 154, 176 },
 new ushort[]{ 292, 471, 472, 293},
 new ushort[]{ 146, 19, 164 },
 new ushort[]{ 145, 18, 163 },
 new ushort[]{ 10, 11 },
 new ushort[]{ 289, 468 },
 new ushort[]{ 288, 467 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//486 P 6/m 2/c 2/c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 921, 1497, 1358, 1459, 1372, 884, 1465, 1352, 894, 922, 1498, 1359, 916, 1508, 1341, 1464, 1351, 893, 1458, 1371, 883},
 new ushort[]{ 899, 1504, 1337, 902, 1494, 1355, 1442, 1366, 878, 1445, 1346, 888},
 new ushort[]{ 729, 449, 772, 730, 448, 773, 734, 455, 788, 733, 456, 787},
 new ushort[]{ 675, 80, 774, 676, 81, 771, 680, 87, 786, 679, 86, 789},
 new ushort[]{ 153, 30, 175, 33, 156, 178, 154, 31, 176, 32, 155, 177},
 new ushort[]{ 292, 471, 474, 295, 472, 293, 294, 473},
 new ushort[]{ 145, 18, 163, 19, 146, 164 },
 new ushort[]{ 147, 21, 166, 148, 24, 169 },
 new ushort[]{ 10, 13, 11, 12},
 new ushort[]{ 288, 467, 468, 289},
 new ushort[]{ 290, 469, 470, 291},
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//487 P 6sub3/m 2/c 2/m
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360, 1459, 1372, 884, 1457, 1350, 892, 922, 1498, 1359, 923, 1509, 1342, 1464, 1351, 893, 1450, 1369, 881},
 new ushort[]{ 684, 92, 819, 689, 98, 821, 97, 688, 826, 95, 687, 814},
 new ushort[]{ 907, 1506, 1339, 914, 1496, 1357, 1446, 1367, 879, 1449, 1348, 890},
 new ushort[]{ 724, 442, 759, 727, 444, 765, 725, 441, 760, 726, 445, 764},
 new ushort[]{ 292, 473, 474, 293, 472, 295, 294, 471},
 new ushort[]{ 675, 80, 774, 680, 87, 786 },
 new ushort[]{ 145, 18, 163, 146, 19, 164 },
 new ushort[]{ 10, 12, 13, 11},
 new ushort[]{ 288, 468, 467, 289},
 new ushort[]{ 290, 470, 469, 291},
 new ushort[]{ 0, 1 },
 new ushort[]{ 3, 6 }},
//488 P 6sub3/m 2/m 2/c
new ushort[][]{ new ushort[]{ 915, 1507, 1340, 928, 1499, 1360, 1451, 1370, 882, 1465, 1352, 894, 922, 1498, 1359, 923, 1509, 1342, 1456, 1349, 891, 1458, 1371, 883},
 new ushort[]{ 736, 463, 815, 741, 465, 824, 462, 739, 818, 466, 740, 823},
 new ushort[]{ 907, 1506, 1339, 914, 1496, 1357, 1448, 1368, 880, 1447, 1347, 889},
 new ushort[]{ 670, 74, 761, 673, 77, 763, 671, 75, 758, 672, 76, 766},
 new ushort[]{ 729, 449, 772, 734, 455, 788 },
 new ushort[]{ 145, 18, 163, 146, 19, 164 },
 new ushort[]{ 292, 473, 472, 295},
 new ushort[]{ 10, 12, 11, 13},
 new ushort[]{ 291, 469 },
 new ushort[]{ 290, 470 },
 new ushort[]{ 3, 6 },
 new ushort[]{ 0, 1 }},
//489 P 2 3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561},
 new ushort[]{ 692, 693, 212, 213, 171, 172 },
 new ushort[]{ 690, 691, 76, 77, 149, 150 },
 new ushort[]{ 672, 673, 210, 211, 26, 27 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 802, 808, 807, 805},
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//490 F 2 3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561},
 new ushort[]{ 711, 747, 347, 349, 316, 500 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 802, 808, 807, 805},
 new ushort[]{ 512},
 new ushort[]{ 314},
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//491 I 2 3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561},
 new ushort[]{ 690, 691, 76, 77, 149, 150 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 802, 808, 807, 805},
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 0 }},
//492 P 2sub1 3
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688},
 new ushort[]{ 802, 1065, 849, 1097}},
//493 I 2sub1 3
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688},
 new ushort[]{ 675, 995, 345, 533, 49, 67 },
 new ushort[]{ 802, 1065, 849, 1097}},
//494 P 2/m -3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556},
 new ushort[]{ 248, 250, 249, 251, 1805, 1806, 1807, 1808, 1551, 1553, 1552, 1554},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550},
 new ushort[]{ 802, 808, 807, 805, 809, 803, 804, 806},
 new ushort[]{ 692, 693, 212, 213, 171, 172 },
 new ushort[]{ 690, 691, 76, 77, 149, 150 },
 new ushort[]{ 672, 673, 210, 211, 26, 27 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//495 P 2/n -3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1178, 1172, 1173, 1175, 1885, 1884, 1882, 1883, 1697, 1695, 1696, 1694},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 991, 990, 227, 226, 29, 28},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 1003, 1002, 229, 228, 174, 173},
 new ushort[]{ 802, 808, 807, 805, 1108, 1102, 1103, 1105},
 new ushort[]{ 19, 146, 163, 145, 18, 1 },
 new ushort[]{ 512, 315, 331, 497},
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 0, 164 }},
//496 P 2/n -3
new ushort[][]{ new ushort[]{ 915, 1170, 1150, 946, 1817, 1829, 1881, 1868, 1555, 1687, 1564, 1693, 922, 1165, 1147, 947, 1824, 1830, 1877, 1866, 1562, 1685, 1565, 1689},
 new ushort[]{ 746, 1033, 348, 357, 499, 502, 716, 1019, 527, 535, 334, 335},
 new ushort[]{ 711, 1018, 347, 355, 316, 318, 750, 1034, 528, 537, 513, 514},
 new ushort[]{ 802, 1100, 1064, 847, 809, 1096, 1062, 848},
 new ushort[]{ 332, 498, 511, 497, 331, 315 },
 new ushort[]{ 164, 1, 18, 145},
 new ushort[]{ 0, 163, 146, 19},
 new ushort[]{ 314, 512 }},
//497 F 2/m -3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550},
 new ushort[]{ 711, 747, 347, 349, 316, 500, 750, 715, 528, 526, 513, 333},
 new ushort[]{ 802, 808, 807, 805, 809, 803, 804, 806},
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 43, 60, 298, 299, 312, 495 },
 new ushort[]{ 314, 512 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//498 F 2/d -3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1257, 1254, 1255, 1256, 1925, 1924, 1922, 1923, 1747, 1745, 1746, 1744},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 1222, 1221, 362, 361, 320, 319},
 new ushort[]{ 802, 808, 807, 805, 1238, 1235, 1236, 1237},
 new ushort[]{ 625, 595, 598, 621},
 new ushort[]{ 415, 653, 644, 431},
 new ushort[]{ 164, 512 },
 new ushort[]{ 0, 314 }},
//499 F 2/d -3
new ushort[][]{ new ushort[]{ 915, 1253, 1249, 954, 1817, 1833, 1921, 1915, 1555, 1740, 1568, 1743, 922, 1317, 1309, 957, 1824, 1834, 1954, 1943, 1562, 1791, 1569, 1798},
 new ushort[]{ 722, 1223, 432, 433, 418, 419, 757, 1289, 659, 662, 656, 657},
 new ushort[]{ 802, 1233, 1227, 869, 809, 1303, 1291, 876},
 new ushort[]{ 164, 510, 488, 201},
 new ushort[]{ 0, 312, 298, 43},
 new ushort[]{ 625, 594 },
 new ushort[]{ 415, 655 }},
//500 I 2/m -3
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550},
 new ushort[]{ 802, 808, 807, 805, 809, 803, 804, 806},
 new ushort[]{ 672, 673, 210, 211, 26, 27 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 0 }},
//501 P 2sub1/a -3
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 922, 1146, 945, 1168, 1824, 1879, 1865, 1828, 1562, 1563, 1691, 1684},
 new ushort[]{ 802, 1065, 849, 1097, 809, 1061, 846, 1098},
 new ushort[]{ 164, 18, 145, 1},
 new ushort[]{ 0, 146, 19, 163}},
//502 I 2sub1/a -3
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 922, 1146, 945, 1168, 1824, 1879, 1865, 1828, 1562, 1563, 1691, 1684},
 new ushort[]{ 675, 995, 345, 533, 49, 67, 680, 992, 524, 352, 66, 50},
 new ushort[]{ 802, 1065, 849, 1097, 809, 1061, 846, 1098},
 new ushort[]{ 314, 332, 511, 498},
 new ushort[]{ 0, 146, 19, 163}},
//503 P 4 3 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850},
 new ushort[]{ 242, 244, 243, 245, 1397, 1398, 1399, 1400, 1516, 1518, 1517, 1519},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 210, 211, 672, 673, 27, 26},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806},
 new ushort[]{ 692, 693, 212, 213, 171, 172 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//504 P 4sub2 3 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1639, 1645, 1640, 1642, 1207, 1210, 1213, 1208, 1906, 1907, 1909, 1912},
 new ushort[]{ 380, 562, 561, 383, 1589, 1601, 1602, 1592, 1532, 1538, 1537, 1535},
 new ushort[]{ 381, 563, 560, 382, 1591, 1603, 1600, 1590, 1533, 1539, 1536, 1534},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 100, 101, 1000, 1001, 152, 151},
 new ushort[]{ 672, 673, 210, 211, 26, 27, 226, 227, 990, 991, 29, 28},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 228, 229, 1002, 1003, 174, 173},
 new ushort[]{ 802, 808, 807, 805, 1102, 1108, 1103, 1105},
 new ushort[]{ 304, 485, 42, 59, 147, 148 },
 new ushort[]{ 297, 476, 183, 198, 21, 24 },
 new ushort[]{ 19, 146, 163, 18, 145, 1 },
 new ushort[]{ 512, 315, 331, 497},
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 0, 164 }},
//505 F 4 3 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850},
 new ushort[]{ 711, 747, 347, 349, 316, 500, 348, 528, 715, 712, 317, 333},
 new ushort[]{ 242, 244, 243, 245, 1397, 1398, 1399, 1400, 1516, 1518, 1517, 1519},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806},
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 43, 60, 298, 299, 312, 495 },
 new ushort[]{ 314, 315 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//506 F 4sub1 3 2
new ushort[][]{ new ushort[]{ 915, 949, 1169, 1148, 1817, 1867, 1832, 1880, 1555, 1692, 1686, 1567, 1772, 1721, 1729, 1778, 1329, 1334, 1269, 1276, 1962, 1941, 1966, 1935},
 new ushort[]{ 437, 667, 610, 633, 1708, 1764, 1760, 1714, 1541, 1683, 1680, 1543},
 new ushort[]{ 670, 693, 74, 213, 8, 172, 541, 362, 1282, 1284, 503, 337},
 new ushort[]{ 802, 850, 1099, 1063, 1297, 1238, 1245, 1305},
 new ushort[]{ 625, 601, 642, 422},
 new ushort[]{ 415, 647, 600, 628},
 new ushort[]{ 164, 331 },
 new ushort[]{ 0, 498 }},
//507 I 4 3 2
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850},
 new ushort[]{ 381, 563, 560, 382, 1591, 1603, 1600, 1590, 1533, 1539, 1536, 1534},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 210, 211, 672, 673, 27, 26},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806},
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 304, 485, 42, 59, 147, 148 },
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 0 }},
//508 P 4sub3 3 2
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 1728, 1721, 1777, 1774, 1275, 1331, 1269, 1333, 1940, 1965, 1964, 1935},
 new ushort[]{ 437, 608, 665, 634, 1708, 1759, 1715, 1761, 1541, 1545, 1675, 1681},
 new ushort[]{ 802, 1065, 849, 1097, 1244, 1238, 1304, 1299},
 new ushort[]{ 625, 645, 593, 429},
 new ushort[]{ 415, 602, 652, 623}},
//509 P 4sub1 3 2
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 1769, 1782, 1722, 1727, 1328, 1274, 1336, 1270, 1961, 1936, 1939, 1968},
 new ushort[]{ 436, 607, 666, 635, 1707, 1758, 1716, 1762, 1540, 1544, 1676, 1682},
 new ushort[]{ 802, 1065, 849, 1097, 1296, 1307, 1239, 1243},
 new ushort[]{ 655, 616, 421, 597},
 new ushort[]{ 594, 425, 627, 643}},
//510 I 4sub1 3 2
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 1769, 1782, 1722, 1727, 1328, 1274, 1336, 1270, 1961, 1936, 1939, 1968},
 new ushort[]{ 437, 608, 665, 634, 1708, 1759, 1715, 1761, 1541, 1545, 1675, 1681},
 new ushort[]{ 436, 607, 666, 635, 1707, 1758, 1716, 1762, 1540, 1544, 1676, 1682},
 new ushort[]{ 675, 995, 345, 533, 49, 67, 539, 544, 1280, 1218, 51, 192},
 new ushort[]{ 802, 1065, 849, 1097, 1296, 1307, 1239, 1243},
 new ushort[]{ 614, 640, 343, 523, 47, 65 },
 new ushort[]{ 412, 591, 328, 520, 44, 63 },
 new ushort[]{ 655, 616, 421, 597},
 new ushort[]{ 415, 602, 652, 623}},
//511 P -4 3 m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1450, 1456, 1453, 1455, 966, 971, 972, 969, 1843, 1846, 1848, 1849},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 210, 211, 672, 673, 26, 27},
 new ushort[]{ 692, 693, 212, 213, 171, 172 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 802, 808, 807, 805},
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//512 F -4 3 m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1450, 1456, 1453, 1455, 966, 971, 972, 969, 1843, 1846, 1848, 1849},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964},
 new ushort[]{ 711, 747, 347, 349, 316, 500 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 802, 808, 807, 805},
 new ushort[]{ 512},
 new ushort[]{ 314},
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//513 I -4 3 m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1450, 1456, 1453, 1455, 966, 971, 972, 969, 1843, 1846, 1848, 1849},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 210, 211, 672, 673, 26, 27},
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 304, 485, 42, 59, 147, 148 },
 new ushort[]{ 802, 808, 807, 805},
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 0 }},
//514 P -4 3 n
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1638, 1644, 1641, 1643, 1206, 1211, 1212, 1209, 1905, 1908, 1910, 1911},
 new ushort[]{ 672, 673, 210, 211, 26, 27, 226, 227, 990, 991, 28, 29},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 100, 101, 1000, 1001, 151, 152},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 228, 229, 1002, 1003, 173, 174},
 new ushort[]{ 802, 808, 807, 805, 1101, 1107, 1104, 1106},
 new ushort[]{ 297, 476, 183, 198, 21, 24 },
 new ushort[]{ 304, 485, 42, 59, 147, 148 },
 new ushort[]{ 19, 146, 163, 18, 145, 1 },
 new ushort[]{ 0, 164 }},
//515 F -4 3 c
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1638, 1644, 1641, 1643, 1206, 1211, 1212, 1209, 1905, 1908, 1910, 1911},
 new ushort[]{ 711, 747, 347, 349, 316, 500, 537, 357, 1034, 1033, 514, 502},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 228, 229, 1002, 1003, 173, 174},
 new ushort[]{ 802, 808, 807, 805, 1101, 1107, 1104, 1106},
 new ushort[]{ 296, 475, 41, 58, 3, 6 },
 new ushort[]{ 43, 60, 298, 299, 312, 495 },
 new ushort[]{ 314, 512 },
 new ushort[]{ 0, 164 }},
//516 I -4 3 d
new ushort[][]{ new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 1719, 1731, 1773, 1779, 1268, 1335, 1277, 1330, 1934, 1963, 1967, 1942},
 new ushort[]{ 675, 995, 345, 533, 49, 67, 360, 364, 1219, 1278, 191, 52},
 new ushort[]{ 802, 1065, 849, 1097, 1234, 1246, 1298, 1306},
 new ushort[]{ 639, 615, 344, 522, 48, 64 },
 new ushort[]{ 590, 413, 342, 508, 46, 61 }},
//517 P 4/m -3 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556, 1456, 1450, 1455, 1453, 972, 969, 966, 971, 1849, 1848, 1846, 1843},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964, 814, 820, 815, 817, 959, 962, 965, 960, 1810, 1811, 1813, 1816},
 new ushort[]{ 248, 250, 249, 251, 1805, 1806, 1807, 1808, 1551, 1553, 1552, 1554, 1404, 1406, 1403, 1405, 281, 280, 283, 282, 1839, 1840, 1841, 1842},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550, 1386, 1388, 1385, 1387, 142, 141, 144, 143, 1835, 1836, 1837, 1838},
 new ushort[]{ 242, 244, 243, 245, 1397, 1398, 1399, 1400, 1516, 1518, 1517, 1519},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 210, 211, 672, 673, 27, 26},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806},
 new ushort[]{ 692, 693, 212, 213, 171, 172 },
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 145, 18, 1 },
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//518 P 4/n -3 2/n
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850, 1178, 1172, 1173, 1175, 1885, 1884, 1882, 1883, 1697, 1695, 1696, 1694, 1644, 1638, 1643, 1641, 1212, 1209, 1206, 1211, 1911, 1910, 1908, 1905},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515, 269, 267, 268, 266, 1582, 1581, 1580, 1579, 1669, 1667, 1668, 1666},
 new ushort[]{ 672, 673, 210, 211, 26, 27, 76, 77, 690, 691, 150, 149, 1001, 1000, 101, 100, 152, 151, 227, 226, 991, 990, 28, 29},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806, 1108, 1102, 1103, 1105, 1107, 1101, 1106, 1104},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 1003, 1002, 229, 228, 174, 173},
 new ushort[]{ 297, 476, 183, 198, 21, 24, 42, 59, 304, 485, 148, 147},
 new ushort[]{ 314, 511, 498, 332, 315, 512, 331, 497},
 new ushort[]{ 19, 146, 163, 145, 18, 1 },
 new ushort[]{ 0, 164 }},
//519 P 4/n -3 2/n
new ushort[][]{ new ushort[]{ 915, 1170, 1150, 946, 1817, 1829, 1881, 1868, 1555, 1687, 1564, 1693, 1459, 1645, 1480, 1612, 974, 1191, 1213, 980, 1851, 1854, 1893, 1912, 922, 1165, 1147, 947, 1824, 1830, 1877, 1866, 1562, 1685, 1565, 1689, 1464, 1638, 1481, 1611, 976, 1190, 1206, 981, 1853, 1855, 1892, 1905},
 new ushort[]{ 376, 401, 381, 403, 1412, 1417, 1591, 1593, 1520, 1658, 1533, 1670, 559, 580, 562, 583, 1428, 1431, 1601, 1604, 1527, 1661, 1538, 1671},
 new ushort[]{ 746, 1033, 348, 357, 499, 502, 526, 536, 715, 1020, 336, 333, 716, 1019, 527, 535, 334, 335, 349, 356, 747, 1032, 501, 500},
 new ushort[]{ 802, 1100, 1064, 847, 810, 1108, 843, 1059, 809, 1096, 1062, 848, 812, 1101, 844, 1058},
 new ushort[]{ 711, 1018, 347, 355, 316, 318, 750, 1034, 528, 537, 513, 514},
 new ushort[]{ 60, 200, 299, 307, 495, 496, 477, 487, 45, 187, 330, 329},
 new ushort[]{ 0, 163, 146, 19, 1, 164, 18, 145},
 new ushort[]{ 497, 331, 315, 332, 498, 511 },
 new ushort[]{ 314, 512 }},
//520 P 4sub2/m -3 2/n
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1639, 1645, 1640, 1642, 1207, 1210, 1213, 1208, 1906, 1907, 1909, 1912, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556, 1644, 1638, 1643, 1641, 1212, 1209, 1206, 1211, 1911, 1910, 1908, 1905},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550, 1586, 1588, 1585, 1587, 285, 284, 287, 286, 1898, 1899, 1900, 1901},
 new ushort[]{ 380, 562, 561, 383, 1589, 1601, 1602, 1592, 1532, 1538, 1537, 1535, 563, 381, 382, 560, 1603, 1591, 1590, 1600, 1539, 1533, 1534, 1536},
 new ushort[]{ 802, 808, 807, 805, 1102, 1108, 1103, 1105, 809, 803, 804, 806, 1107, 1101, 1106, 1104},
 new ushort[]{ 690, 691, 76, 77, 149, 150, 100, 101, 1000, 1001, 152, 151},
 new ushort[]{ 672, 673, 210, 211, 26, 27, 226, 227, 990, 991, 29, 28},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 228, 229, 1002, 1003, 174, 173},
 new ushort[]{ 314, 511, 498, 332, 512, 315, 331, 497},
 new ushort[]{ 304, 485, 42, 59, 147, 148 },
 new ushort[]{ 297, 476, 183, 198, 21, 24 },
 new ushort[]{ 19, 146, 163, 18, 145, 1 },
 new ushort[]{ 0, 164 }},
//521 P 4sub2/n -3 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1639, 1645, 1640, 1642, 1207, 1210, 1213, 1208, 1906, 1907, 1909, 1912, 1178, 1172, 1173, 1175, 1885, 1884, 1882, 1883, 1697, 1695, 1696, 1694, 1456, 1450, 1455, 1453, 972, 969, 966, 971, 1849, 1848, 1846, 1843},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964, 1114, 1119, 1115, 1117, 1199, 1201, 1202, 1200, 1873, 1874, 1875, 1876},
 new ushort[]{ 380, 562, 561, 383, 1589, 1601, 1602, 1592, 1532, 1538, 1537, 1535, 402, 580, 581, 399, 1419, 1431, 1430, 1416, 1659, 1661, 1662, 1656},
 new ushort[]{ 381, 563, 560, 382, 1591, 1603, 1600, 1590, 1533, 1539, 1536, 1534, 401, 579, 582, 400, 1417, 1429, 1432, 1418, 1658, 1660, 1663, 1657},
 new ushort[]{ 672, 673, 210, 211, 26, 27, 226, 227, 990, 991, 29, 28, 1001, 1000, 101, 100, 152, 151, 77, 76, 691, 690, 149, 150},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 228, 229, 1002, 1003, 174, 173},
 new ushort[]{ 297, 476, 183, 198, 21, 24, 304, 485, 42, 59, 147, 148},
 new ushort[]{ 802, 808, 807, 805, 1102, 1108, 1103, 1105},
 new ushort[]{ 19, 146, 163, 18, 145, 1 },
 new ushort[]{ 512, 315, 331, 497},
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 0, 164 }},
//522 P 4sub2/n -3 2/m
new ushort[][]{ new ushort[]{ 915, 1170, 1150, 946, 1817, 1829, 1881, 1868, 1555, 1687, 1564, 1693, 1631, 1457, 1614, 1485, 1203, 984, 973, 1193, 1902, 1895, 1858, 1850, 922, 1165, 1147, 947, 1824, 1830, 1877, 1866, 1562, 1685, 1565, 1689, 1636, 1450, 1617, 1484, 1205, 983, 966, 1194, 1904, 1896, 1857, 1843},
 new ushort[]{ 813, 1113, 1078, 861, 1809, 1825, 1872, 1864, 958, 1189, 977, 1198, 1109, 820, 1075, 862, 1196, 978, 965, 1187, 1870, 1862, 1826, 1816},
 new ushort[]{ 243, 131, 114, 268, 1399, 1384, 1570, 1580, 1517, 1653, 1528, 1668, 244, 130, 115, 267, 1398, 1383, 1571, 1581, 1518, 1652, 1529, 1667},
 new ushort[]{ 246, 133, 111, 265, 1577, 1572, 1381, 1402, 1530, 1665, 1513, 1655, 247, 132, 112, 264, 1578, 1573, 1380, 1401, 1531, 1664, 1514, 1654},
 new ushort[]{ 715, 1020, 526, 536, 333, 336, 535, 527, 1019, 716, 334, 335, 747, 1032, 349, 356, 500, 501, 357, 348, 1033, 746, 499, 502},
 new ushort[]{ 711, 1018, 347, 355, 316, 318, 537, 528, 1034, 750, 513, 514},
 new ushort[]{ 187, 45, 487, 477, 330, 329, 200, 60, 307, 299, 496, 495},
 new ushort[]{ 802, 1100, 1064, 847, 1096, 809, 1062, 848},
 new ushort[]{ 332, 498, 511, 331, 497, 315 },
 new ushort[]{ 164, 1, 18, 145},
 new ushort[]{ 0, 163, 146, 19},
 new ushort[]{ 314, 512 }},
//523 F 4/m -3 2/m
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556, 1456, 1450, 1455, 1453, 972, 969, 966, 971, 1849, 1848, 1846, 1843},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964, 814, 820, 815, 817, 959, 962, 965, 960, 1810, 1811, 1813, 1816},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550, 1386, 1388, 1385, 1387, 142, 141, 144, 143, 1835, 1836, 1837, 1838},
 new ushort[]{ 242, 244, 243, 245, 1397, 1398, 1399, 1400, 1516, 1518, 1517, 1519},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515},
 new ushort[]{ 711, 747, 347, 349, 316, 500, 348, 528, 715, 712, 317, 333},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806},
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 43, 60, 298, 299, 312, 495 },
 new ushort[]{ 314, 315 },
 new ushort[]{ 164},
 new ushort[]{ 0 }},
//524 F 4/m -3 2/c
new ushort[][]{ new ushort[]{ 915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1639, 1645, 1640, 1642, 1207, 1210, 1213, 1208, 1906, 1907, 1909, 1912, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556, 1644, 1638, 1643, 1641, 1212, 1209, 1206, 1211, 1911, 1910, 1908, 1905},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550, 1586, 1588, 1585, 1587, 285, 284, 287, 286, 1898, 1899, 1900, 1901},
 new ushort[]{ 376, 558, 557, 379, 1412, 1426, 1427, 1415, 1520, 1526, 1525, 1523, 559, 377, 378, 556, 1428, 1414, 1413, 1425, 1527, 1521, 1522, 1524},
 new ushort[]{ 802, 808, 807, 805, 1102, 1108, 1103, 1105, 809, 803, 804, 806, 1107, 1101, 1106, 1104},
 new ushort[]{ 711, 747, 347, 349, 316, 500, 750, 715, 528, 526, 513, 333},
 new ushort[]{ 670, 671, 74, 75, 8, 9, 228, 229, 1002, 1003, 174, 173},
 new ushort[]{ 43, 60, 298, 299, 312, 495 },
 new ushort[]{ 296, 475, 41, 58, 3, 6 },
 new ushort[]{ 0, 164 },
 new ushort[]{ 314, 512 }},
//525 F 4sub1/d -3 2/m
new ushort[][]{ new ushort[]{ 915, 949, 1169, 1148, 1817, 1867, 1832, 1880, 1555, 1692, 1686, 1567, 1772, 1721, 1729, 1778, 1329, 1334, 1269, 1276, 1962, 1941, 1966, 1935, 1257, 1262, 1319, 1316, 1925, 1952, 1931, 1955, 1747, 1799, 1797, 1752, 1618, 1450, 1486, 1633, 1195, 1204, 966, 985, 1897, 1859, 1903, 1843},
 new ushort[]{ 437, 667, 610, 633, 1708, 1764, 1760, 1714, 1541, 1683, 1680, 1543, 439, 613, 669, 636, 1422, 1608, 1610, 1436, 1732, 1786, 1788, 1734},
 new ushort[]{ 813, 864, 1112, 1076, 1809, 1863, 1827, 1871, 958, 1197, 1188, 979, 1302, 1240, 1247, 1308, 1325, 1332, 1267, 1271, 1948, 1927, 1953, 1920},
 new ushort[]{ 670, 693, 74, 213, 8, 172, 541, 362, 1282, 1284, 503, 337},
 new ushort[]{ 802, 850, 1099, 1063, 1297, 1238, 1245, 1305},
 new ushort[]{ 625, 601, 642, 422},
 new ushort[]{ 415, 647, 600, 628},
 new ushort[]{ 164, 331 },
 new ushort[]{ 0, 498 }},
//526 F 4sub1/d -3 2/m
new ushort[][]{
 new ushort[]{915, 1314, 1251, 1185, 1817, 1890, 1950, 1919, 1555, 1742, 1700, 1795, 1768, 1457, 1718, 1651, 1327, 1217, 973, 1266, 1960, 1933, 1914, 1850, 922, 1259, 1311, 1184, 1824, 1887, 1928, 1944, 1562, 1792, 1699, 1749, 1725, 1450, 1766, 1650, 1273, 1214, 966, 1322, 1938, 1958, 1913, 1843},
 new ushort[]{111, 588, 404, 279, 1381, 1605, 1755, 1703, 1513, 1737, 1678, 1789, 112, 410, 584, 278, 1380, 1594, 1709, 1754, 1514, 1784, 1673, 1738},
 new ushort[]{813, 1301, 1232, 1131, 1809, 1888, 1947, 1917, 958, 1265, 1215, 1324, 1300, 820, 1231, 1132, 1323, 1216, 965, 1264, 1946, 1916, 1889, 1816},
 new ushort[]{722, 1283, 432, 631, 418, 427, 660, 659, 1286, 1041, 650, 596},
 new ushort[]{802, 1295, 1230, 1129, 1294, 809, 1229, 1130},
 new ushort[]{ 164, 329, 477, 45},
 new ushort[]{ 0, 496, 307, 200},
 new ushort[]{ 594, 423 },
 new ushort[]{ 415, 646 }},
//527 F 4sub1/d -3 2/c
new ushort[][]{
 new ushort[]{915, 949, 1169, 1148, 1817, 1867, 1832, 1880, 1555, 1692, 1686, 1567, 1772, 1721, 1729, 1778, 1329, 1334, 1269, 1276, 1962, 1941, 1966, 1935, 1320, 1315, 1258, 1261, 1956, 1930, 1951, 1926, 1800, 1748, 1751, 1796, 1482, 1638, 1613, 1461, 982, 975, 1206, 1192, 1856, 1894, 1852, 1905},
 new ushort[]{437, 667, 610, 633, 1708, 1764, 1760, 1714, 1541, 1683, 1680, 1543, 638, 668, 612, 440, 1609, 1437, 1435, 1597, 1787, 1735, 1733, 1785},
 new ushort[]{670, 693, 74, 213, 8, 172, 541, 362, 1282, 1284, 503, 337, 1285, 1281, 546, 366, 515, 321, 99, 228, 691, 672, 26, 150},
 new ushort[]{802, 850, 1099, 1063, 1297, 1238, 1245, 1305, 1307, 1296, 1239, 1243, 845, 1101, 1060, 811},
 new ushort[]{296, 486, 41, 199, 3, 169, 488, 298, 45, 200, 496, 329},
 new ushort[]{594, 617, 430, 651, 424, 655, 620, 592},
 new ushort[]{415, 647, 600, 628, 625, 645, 593, 429},
 new ushort[]{ 0, 498, 512, 18}},
//528 F 4sub1/d -3 2/c
new ushort[][]{
 new ushort[]{915, 1260, 1312, 1183, 1817, 1886, 1929, 1945, 1555, 1793, 1698, 1750, 1767, 1645, 1717, 1493, 1326, 987, 1213, 1263, 1959, 1932, 1861, 1912, 922, 1313, 1250, 1186, 1824, 1891, 1949, 1918, 1562, 1741, 1701, 1794, 1724, 1638, 1765, 1492, 1272, 986, 1206, 1321, 1937, 1957, 1860, 1905},
 new ushort[]{377, 140, 270, 589, 1414, 1575, 1702, 1757, 1521, 1783, 1672, 1739, 558, 139, 271, 411, 1426, 1574, 1753, 1704, 1526, 1736, 1677, 1790},
 new ushort[]{722, 1226, 432, 630, 418, 626, 661, 605, 1287, 756, 649, 603, 757, 1286, 659, 606, 656, 596, 434, 629, 1225, 723, 426, 618},
 new ushort[]{802, 1242, 1292, 1124, 1293, 1108, 1228, 875, 809, 1294, 1229, 1130, 1241, 1101, 1290, 870},
 new ushort[]{641, 599, 428, 622, 417, 624, 644, 598, 623, 429, 645, 602},
 new ushort[]{0, 330, 487, 187, 495, 164, 299, 60},
 new ushort[]{314, 24, 198, 476, 512, 21, 183, 297},
 new ushort[]{ 415, 648, 655, 423}},
//529 I 4/m -3 2/m
new ushort[][]{ new ushort[]{915, 921, 920, 918, 1817, 1820, 1823, 1822, 1555, 1560, 1558, 1561, 1451, 1457, 1452, 1454, 967, 970, 973, 968, 1844, 1845, 1847, 1850, 922, 916, 917, 919, 1824, 1821, 1818, 1819, 1562, 1557, 1559, 1556, 1456, 1450, 1455, 1453, 972, 969, 966, 971, 1849, 1848, 1846, 1843},
 new ushort[]{ 813, 819, 818, 816, 1809, 1812, 1815, 1814, 958, 963, 961, 964, 814, 820, 815, 817, 959, 962, 965, 960, 1810, 1811, 1813, 1816},
 new ushort[]{ 116, 118, 117, 119, 1801, 1802, 1803, 1804, 1547, 1549, 1548, 1550, 1386, 1388, 1385, 1387, 142, 141, 144, 143, 1835, 1836, 1837, 1838},
 new ushort[]{ 381, 563, 560, 382, 1591, 1603, 1600, 1590, 1533, 1539, 1536, 1534, 562, 380, 383, 561, 1601, 1589, 1592, 1602, 1538, 1532, 1535, 1537},
 new ushort[]{ 110, 112, 111, 113, 1379, 1380, 1381, 1382, 1512, 1514, 1513, 1515},
 new ushort[]{ 672, 673, 210, 211, 26, 27, 76, 77, 690, 691, 150, 149},
 new ushort[]{ 802, 808, 807, 805, 803, 809, 804, 806},
 new ushort[]{ 670, 671, 74, 75, 8, 9 },
 new ushort[]{ 297, 476, 183, 198, 21, 24 },
 new ushort[]{ 314, 511, 498, 332},
 new ushort[]{ 19, 146, 163 },
 new ushort[]{ 0 }},
//530 I 4sub1/a -3 2/d
new ushort[][]{
 new ushort[]{ 915, 1151, 948, 1167, 1817, 1878, 1869, 1831, 1555, 1566, 1690, 1688, 1769, 1782, 1722, 1727, 1328, 1274, 1336, 1270, 1961, 1936, 1939, 1968, 922, 1146, 945, 1168, 1824, 1879, 1865, 1828, 1562, 1563, 1691, 1684, 1731, 1719, 1779, 1773, 1277, 1330, 1268, 1335, 1942, 1967, 1963, 1934},
 new ushort[]{ 437, 608, 665, 634, 1708, 1759, 1715, 1761, 1541, 1545, 1675, 1681, 664, 632, 438, 609, 1763, 1713, 1756, 1712, 1546, 1542, 1679, 1674},
 new ushort[]{ 675, 995, 345, 533, 49, 67, 539, 544, 1280, 1218, 51, 192, 680, 992, 524, 352, 66, 50, 364, 360, 1220, 1279, 68, 203},
 new ushort[]{ 802, 1065, 849, 1097, 1296, 1307, 1239, 1243, 809, 1061, 846, 1098, 1246, 1234, 1306, 1298},
 new ushort[]{ 590, 413, 342, 508, 46, 61, 522, 521, 414, 639, 48, 186},
 new ushort[]{ 412, 591, 328, 520, 44, 63, 640, 614, 523, 343, 65, 47},
 new ushort[]{ 415, 602, 652, 623, 655, 616, 421, 597},
 new ushort[]{ 0, 146, 19, 163, 497, 512, 315, 331}},
//531 C -1
new ushort[][]{
 new ushort[]{ 915, 922 },
 new ushort[]{ 497},
 new ushort[]{ 495},
 new ushort[]{ 313},
 new ushort[]{ 312},
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//532 I -1
new ushort[][]{
 new ushort[]{ 915, 922 },
 new ushort[]{ 315},
 new ushort[]{ 331},
 new ushort[]{ 497},
 new ushort[]{ 314},
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//533 A -1
new ushort[][]{
 new ushort[]{ 915, 922 },
 new ushort[]{ 200},
 new ushort[]{ 60 },
 new ushort[]{ 185},
 new ushort[]{ 43 },
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//534 B -1
new ushort[][]{
 new ushort[]{ 915, 922 },
 new ushort[]{ 307},
 new ushort[]{ 299},
 new ushort[]{ 305},
 new ushort[]{ 298},
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//535 F -1
new ushort[][]{
 new ushort[]{ 915, 922 },
 new ushort[]{ 497},
 new ushort[]{ 495},
 new ushort[]{ 313},
 new ushort[]{ 312},
 new ushort[]{ 307},
 new ushort[]{ 299},
 new ushort[]{ 306},
 new ushort[]{ 298},
 new ushort[]{ 200},
 new ushort[]{ 60 },
 new ushort[]{ 185},
 new ushort[]{ 43 },
 new ushort[]{ 164},
 new ushort[]{ 19 },
 new ushort[]{ 146},
 new ushort[]{ 163},
 new ushort[]{ 145},
 new ushort[]{ 18 },
 new ushort[]{ 1 },
 new ushort[]{ 0 }},
//536 A 1
new ushort[][]{ new ushort[]{ 915}},
//537 B 1
new ushort[][]{ new ushort[]{ 915}},
//538 C 1
new ushort[][]{ new ushort[]{ 915}},
//539 F 1
new ushort[][]{ new ushort[]{ 915}}
#endregion positions
        };

    public static readonly Func<double, double, double, (double X, double Y, double Z)>[] PositionGeneratorList 
        = new Func<double, double, double, (double X, double Y, double Z)>[]
        {
			#region PositionGenerator
(_,_,_) => (0,0,0),	//0
(_,_,_) => (0,0,d12),	//1
(_,_,_) => (0,0,d13),	//2
(_,_,_) => (0,0,d14),	//3
(_,_,_) => (0,0,d16),	//4
(_,_,_) => (0,0,d23),	//5
(_,_,_) => (0,0,d34),	//6
(_,_,_) => (0,0,d56),	//7
(x,_,_) => (0,0,x),	//8
(x,_,_) => (0,0,-x),	//9
(_,_,z) => (0,0,z),	//10
(_,_,z) => (0,0,-z),	//11
(_,_,z) => (0,0,z+d12),	//12
(_,_,z) => (0,0,-z+d12),	//13
(_,_,z) => (0,0,z+d13),	//14
(_,_,z) => (0,0,-z+d13),	//15
(_,_,z) => (0,0,z+d23),	//16
(_,_,z) => (0,0,-z+d23),	//17
(_,_,_) => (0,d12,0),	//18
(_,_,_) => (0,d12,d12),	//19
(_,_,_) => (0,d12,d13),	//20
(_,_,_) => (0,d12,d14),	//21
(_,_,_) => (0,d12,d16),	//22
(_,_,_) => (0,d12,d23),	//23
(_,_,_) => (0,d12,d34),	//24
(_,_,_) => (0,d12,d56),	//25
(x,_,_) => (0,d12,x),	//26
(x,_,_) => (0,d12,-x),	//27
(x,_,_) => (0,d12,x+d12),	//28
(x,_,_) => (0,d12,-x+d12),	//29
(_,_,z) => (0,d12,z),	//30
(_,_,z) => (0,d12,-z),	//31
(_,_,z) => (0,d12,z+d12),	//32
(_,_,z) => (0,d12,-z+d12),	//33
(_,_,z) => (0,d12,z+d13),	//34
(_,_,z) => (0,d12,-z+d13),	//35
(_,_,z) => (0,d12,z+d14),	//36
(_,_,z) => (0,d12,-z+d14),	//37
(_,_,z) => (0,d12,z+d23),	//38
(_,_,z) => (0,d12,-z+d23),	//39
(_,_,z) => (0,d12,z+d34),	//40
(_,_,_) => (0,d14,0),	//41
(_,_,_) => (0,d14,d12),	//42
(_,_,_) => (0,d14,d14),	//43
(_,_,_) => (0,d14,d18),	//44
(_,_,_) => (0,d14,d34),	//45
(_,_,_) => (0,d14,d38),	//46
(_,_,_) => (0,d14,d58),	//47
(_,_,_) => (0,d14,d78),	//48
(x,_,_) => (0,d14,x),	//49
(x,_,_) => (0,d14,x+d12),	//50
(x,_,_) => (0,d14,-x+d14),	//51
(x,_,_) => (0,d14,-x+d34),	//52
(_,_,z) => (0,d14,z),	//53
(_,_,z) => (0,d14,-z),	//54
(_,_,z) => (0,d14,z+d12),	//55
(_,_,z) => (0,d14,-z+d12),	//56
(_,_,z) => (0,d14,-z+d34),	//57
(_,_,_) => (0,d34,0),	//58
(_,_,_) => (0,d34,d12),	//59
(_,_,_) => (0,d34,d14),	//60
(_,_,_) => (0,d34,d18),	//61
(_,_,_) => (0,d34,d34),	//62
(_,_,_) => (0,d34,d38),	//63
(_,_,_) => (0,d34,d58),	//64
(_,_,_) => (0,d34,d78),	//65
(x,_,_) => (0,d34,-x),	//66
(x,_,_) => (0,d34,-x+d12),	//67
(x,_,_) => (0,d34,x+d34),	//68
(_,_,z) => (0,d34,z),	//69
(_,_,z) => (0,d34,-z),	//70
(_,_,z) => (0,d34,z+d12),	//71
(_,_,z) => (0,d34,-z+d12),	//72
(_,_,z) => (0,d34,z+d14),	//73
(x,_,_) => (0,x,0),	//74
(x,_,_) => (0,-x,0),	//75
(x,_,_) => (0,x,d12),	//76
(x,_,_) => (0,-x,d12),	//77
(x,_,_) => (0,x,d13),	//78
(x,_,_) => (0,-x,d13),	//79
(x,_,_) => (0,x,d14),	//80
(x,_,_) => (0,-x,d14),	//81
(x,_,_) => (0,x,d16),	//82
(x,_,_) => (0,-x,d16),	//83
(x,_,_) => (0,x,d23),	//84
(x,_,_) => (0,-x,d23),	//85
(x,_,_) => (0,x,d34),	//86
(x,_,_) => (0,-x,d34),	//87
(x,_,_) => (0,x,d56),	//88
(x,_,_) => (0,-x,d56),	//89
(x,_,_) => (0,x,-x),	//90
(x,_,_) => (0,-x,x),	//91
(x,_,z) => (0,x,z),	//92
(x,_,z) => (0,x,-z),	//93
(x,_,z) => (0,-x,z),	//94
(x,_,z) => (0,-x,-z),	//95
(x,_,z) => (0,x,z+d12),	//96
(x,_,z) => (0,x,-z+d12),	//97
(x,_,z) => (0,-x,z+d12),	//98
(x,_,_) => (0,-x+d12,0),	//99
(x,_,_) => (0,x+d12,d12),	//100
(x,_,_) => (0,-x+d12,d12),	//101
(_,y,_) => (0,y,0),	//102
(_,y,_) => (0,-y,0),	//103
(_,y,_) => (0,y,d12),	//104
(_,y,_) => (0,-y,d12),	//105
(_,y,_) => (0,y,d14),	//106
(_,y,_) => (0,-y,d14),	//107
(_,y,_) => (0,y,d34),	//108
(_,y,_) => (0,-y,d34),	//109
(_,y,_) => (0,y,y),	//110
(_,y,_) => (0,y,-y),	//111
(_,y,_) => (0,-y,y),	//112
(_,y,_) => (0,-y,-y),	//113
(_,y,_) => (0,y,y+d12),	//114
(_,y,_) => (0,-y,-y+d12),	//115
(_,y,z) => (0,y,z),	//116
(_,y,z) => (0,y,-z),	//117
(_,y,z) => (0,-y,z),	//118
(_,y,z) => (0,-y,-z),	//119
(_,y,z) => (0,y,-z+d12),	//120
(_,y,z) => (0,-y,z+d12),	//121
(_,y,_) => (0,y+d12,0),	//122
(_,y,_) => (0,-y+d12,0),	//123
(_,y,_) => (0,y+d12,d12),	//124
(_,y,_) => (0,-y+d12,d12),	//125
(_,y,_) => (0,y+d12,d14),	//126
(_,y,_) => (0,-y+d12,d14),	//127
(_,y,_) => (0,y+d12,d34),	//128
(_,y,_) => (0,-y+d12,d34),	//129
(_,y,_) => (0,y+d12,y),	//130
(_,y,_) => (0,-y+d12,-y),	//131
(_,y,_) => (0,y+d12,-y+d12),	//132
(_,y,_) => (0,-y+d12,y+d12),	//133
(_,y,z) => (0,y+d12,-z),	//134
(_,y,z) => (0,-y+d12,z),	//135
(_,y,z) => (0,y+d12,-z+d12),	//136
(_,y,z) => (0,-y+d12,z+d12),	//137
(_,y,z) => (0,-y+d12,-z+d14),	//138
(_,y,_) => (0,y+d14,y+d12),	//139
(_,y,_) => (0,-y+d34,-y+d12),	//140
(_,y,z) => (0,z,y),	//141
(_,y,z) => (0,z,-y),	//142
(_,y,z) => (0,-z,y),	//143
(_,y,z) => (0,-z,-y),	//144
(_,_,_) => (d12,0,0),	//145
(_,_,_) => (d12,0,d12),	//146
(_,_,_) => (d12,0,d14),	//147
(_,_,_) => (d12,0,d34),	//148
(x,_,_) => (d12,0,x),	//149
(x,_,_) => (d12,0,-x),	//150
(x,_,_) => (d12,0,x+d12),	//151
(x,_,_) => (d12,0,-x+d12),	//152
(_,_,z) => (d12,0,z),	//153
(_,_,z) => (d12,0,-z),	//154
(_,_,z) => (d12,0,z+d12),	//155
(_,_,z) => (d12,0,-z+d12),	//156
(_,_,z) => (d12,0,z+d13),	//157
(_,_,z) => (d12,0,z+d14),	//158
(_,_,z) => (d12,0,-z+d14),	//159
(_,_,z) => (d12,0,z+d23),	//160
(_,_,z) => (d12,0,z+d34),	//161
(_,_,z) => (d12,0,-z+d34),	//162
(_,_,_) => (d12,d12,0),	//163
(_,_,_) => (d12,d12,d12),	//164
(_,_,_) => (d12,d12,d13),	//165
(_,_,_) => (d12,d12,d14),	//166
(_,_,_) => (d12,d12,d16),	//167
(_,_,_) => (d12,d12,d23),	//168
(_,_,_) => (d12,d12,d34),	//169
(_,_,_) => (d12,d12,d56),	//170
(x,_,_) => (d12,d12,x),	//171
(x,_,_) => (d12,d12,-x),	//172
(x,_,_) => (d12,d12,x+d12),	//173
(x,_,_) => (d12,d12,-x+d12),	//174
(_,_,z) => (d12,d12,z),	//175
(_,_,z) => (d12,d12,-z),	//176
(_,_,z) => (d12,d12,z+d12),	//177
(_,_,z) => (d12,d12,-z+d12),	//178
(_,_,z) => (d12,d12,z+d13),	//179
(_,_,z) => (d12,d12,-z+d13),	//180
(_,_,z) => (d12,d12,z+d23),	//181
(_,_,z) => (d12,d12,-z+d23),	//182
(_,_,_) => (d12,d14,0),	//183
(_,_,_) => (d12,d14,d12),	//184
(_,_,_) => (d12,d14,d14),	//185
(_,_,_) => (d12,d14,d18),	//186
(_,_,_) => (d12,d14,d34),	//187
(_,_,_) => (d12,d14,d38),	//188
(_,_,_) => (d12,d14,d58),	//189
(_,_,_) => (d12,d14,d78),	//190
(x,_,_) => (d12,d14,x+d14),	//191
(x,_,_) => (d12,d14,x+d34),	//192
(_,_,z) => (d12,d14,z),	//193
(_,_,z) => (d12,d14,-z),	//194
(_,_,z) => (d12,d14,z+d12),	//195
(_,_,z) => (d12,d14,-z+d12),	//196
(_,_,z) => (d12,d14,z+d14),	//197
(_,_,_) => (d12,d34,0),	//198
(_,_,_) => (d12,d34,d12),	//199
(_,_,_) => (d12,d34,d14),	//200
(_,_,_) => (d12,d34,d34),	//201
(_,_,_) => (d12,d34,d38),	//202
(x,_,_) => (d12,d34,-x+d14),	//203
(_,_,z) => (d12,d34,z),	//204
(_,_,z) => (d12,d34,-z),	//205
(_,_,z) => (d12,d34,z+d12),	//206
(_,_,z) => (d12,d34,-z+d12),	//207
(_,_,z) => (d12,d34,-z+d14),	//208
(_,_,z) => (d12,d34,-z+d34),	//209
(x,_,_) => (d12,x,0),	//210
(x,_,_) => (d12,-x,0),	//211
(x,_,_) => (d12,x,d12),	//212
(x,_,_) => (d12,-x,d12),	//213
(x,_,_) => (d12,x,d14),	//214
(x,_,_) => (d12,-x,d14),	//215
(x,_,_) => (d12,x,d34),	//216
(x,_,_) => (d12,-x,d34),	//217
(x,_,_) => (d12,x,-x),	//218
(x,_,_) => (d12,-x,x),	//219
(x,_,z) => (d12,x,z),	//220
(x,_,z) => (d12,x,-z),	//221
(x,_,z) => (d12,-x,z),	//222
(x,_,z) => (d12,-x,-z),	//223
(x,_,z) => (d12,x,z+d12),	//224
(x,_,z) => (d12,-x,z+d12),	//225
(x,_,_) => (d12,x+d12,0),	//226
(x,_,_) => (d12,-x+d12,0),	//227
(x,_,_) => (d12,x+d12,d12),	//228
(x,_,_) => (d12,-x+d12,d12),	//229
(x,_,_) => (d12,x+d12,d14),	//230
(x,_,_) => (d12,-x+d12,d14),	//231
(x,_,_) => (d12,x+d12,d34),	//232
(x,_,_) => (d12,-x+d12,d34),	//233
(_,y,_) => (d12,y,0),	//234
(_,y,_) => (d12,-y,0),	//235
(_,y,_) => (d12,y,d12),	//236
(_,y,_) => (d12,-y,d12),	//237
(_,y,_) => (d12,y,d14),	//238
(_,y,_) => (d12,-y,d14),	//239
(_,y,_) => (d12,y,d34),	//240
(_,y,_) => (d12,-y,d34),	//241
(_,y,_) => (d12,y,y),	//242
(_,y,_) => (d12,y,-y),	//243
(_,y,_) => (d12,-y,y),	//244
(_,y,_) => (d12,-y,-y),	//245
(_,y,_) => (d12,y,y+d12),	//246
(_,y,_) => (d12,-y,-y+d12),	//247
(_,y,z) => (d12,y,z),	//248
(_,y,z) => (d12,y,-z),	//249
(_,y,z) => (d12,-y,z),	//250
(_,y,z) => (d12,-y,-z),	//251
(_,y,z) => (d12,y,-z+d12),	//252
(_,y,z) => (d12,-y,z+d12),	//253
(_,y,z) => (d12,-y,-z+d12),	//254
(_,y,z) => (d12,y,-z+d34),	//255
(_,y,_) => (d12,y+d12,0),	//256
(_,y,_) => (d12,-y+d12,0),	//257
(_,y,_) => (d12,y+d12,d12),	//258
(_,y,_) => (d12,-y+d12,d12),	//259
(_,y,_) => (d12,y+d12,d14),	//260
(_,y,_) => (d12,-y+d12,d14),	//261
(_,y,_) => (d12,y+d12,d34),	//262
(_,y,_) => (d12,-y+d12,d34),	//263
(_,y,_) => (d12,y+d12,y),	//264
(_,y,_) => (d12,-y+d12,-y),	//265
(_,y,_) => (d12,y+d12,y+d12),	//266
(_,y,_) => (d12,y+d12,-y+d12),	//267
(_,y,_) => (d12,-y+d12,y+d12),	//268
(_,y,_) => (d12,-y+d12,-y+d12),	//269
(_,y,_) => (d12,y+d12,y+d14),	//270
(_,y,_) => (d12,-y+d12,-y+d34),	//271
(_,y,z) => (d12,y+d12,-z),	//272
(_,y,z) => (d12,-y+d12,z),	//273
(_,y,z) => (d12,-y+d12,-z),	//274
(_,y,z) => (d12,y+d12,-z+d12),	//275
(_,y,z) => (d12,-y+d12,z+d12),	//276
(_,y,z) => (d12,-y+d12,-z+d12),	//277
(_,y,_) => (d12,y+d14,-y+d34),	//278
(_,y,_) => (d12,-y+d34,y+d14),	//279
(_,y,z) => (d12,z,y),	//280
(_,y,z) => (d12,z,-y),	//281
(_,y,z) => (d12,-z,y),	//282
(_,y,z) => (d12,-z,-y),	//283
(_,y,z) => (d12,z+d12,y+d12),	//284
(_,y,z) => (d12,z+d12,-y+d12),	//285
(_,y,z) => (d12,-z+d12,y+d12),	//286
(_,y,z) => (d12,-z+d12,-y+d12),	//287
(_,_,_) => (d13,d23,0),	//288
(_,_,_) => (d13,d23,d12),	//289
(_,_,_) => (d13,d23,d14),	//290
(_,_,_) => (d13,d23,d34),	//291
(_,_,z) => (d13,d23,z),	//292
(_,_,z) => (d13,d23,-z),	//293
(_,_,z) => (d13,d23,z+d12),	//294
(_,_,z) => (d13,d23,-z+d12),	//295
(_,_,_) => (d14,0,0),	//296
(_,_,_) => (d14,0,d12),	//297
(_,_,_) => (d14,0,d14),	//298
(_,_,_) => (d14,0,d34),	//299
(_,_,z) => (d14,0,z),	//300
(_,_,z) => (d14,0,-z),	//301
(_,_,z) => (d14,0,z+d12),	//302
(_,_,z) => (d14,0,-z+d12),	//303
(_,_,_) => (d14,d12,0),	//304
(_,_,_) => (d14,d12,d12),	//305
(_,_,_) => (d14,d12,d14),	//306
(_,_,_) => (d14,d12,d34),	//307
(_,_,z) => (d14,d12,z),	//308
(_,_,z) => (d14,d12,-z),	//309
(_,_,z) => (d14,d12,z+d12),	//310
(_,_,z) => (d14,d12,-z+d12),	//311
(_,_,_) => (d14,d14,0),	//312
(_,_,_) => (d14,d14,d12),	//313
(_,_,_) => (d14,d14,d14),	//314
(_,_,_) => (d14,d14,d34),	//315
(x,_,_) => (d14,d14,x),	//316
(x,_,_) => (d14,d14,-x),	//317
(x,_,_) => (d14,d14,-x+d12),	//318
(x,_,_) => (d14,d14,x+d14),	//319
(x,_,_) => (d14,d14,-x+d14),	//320
(x,_,_) => (d14,d14,x+d34),	//321
(_,_,z) => (d14,d14,z),	//322
(_,_,z) => (d14,d14,-z),	//323
(_,_,z) => (d14,d14,z+d12),	//324
(_,_,z) => (d14,d14,-z+d12),	//325
(_,_,z) => (d14,d14,z+d14),	//326
(_,_,z) => (d14,d14,-z+d14),	//327
(_,_,_) => (d14,d18,0),	//328
(_,_,_) => (d14,d34,0),	//329
(_,_,_) => (d14,d34,d12),	//330
(_,_,_) => (d14,d34,d14),	//331
(_,_,_) => (d14,d34,d34),	//332
(x,_,_) => (d14,d34,x),	//333
(x,_,_) => (d14,d34,-x),	//334
(x,_,_) => (d14,d34,x+d12),	//335
(x,_,_) => (d14,d34,-x+d12),	//336
(x,_,_) => (d14,d34,x+d34),	//337
(_,_,z) => (d14,d34,z),	//338
(_,_,z) => (d14,d34,-z),	//339
(_,_,z) => (d14,d34,z+d12),	//340
(_,_,z) => (d14,d34,-z+d12),	//341
(_,_,_) => (d14,d38,0),	//342
(_,_,_) => (d14,d58,0),	//343
(_,_,_) => (d14,d78,0),	//344
(x,_,_) => (d14,x,0),	//345
(x,_,_) => (d14,x,d12),	//346
(x,_,_) => (d14,x,d14),	//347
(x,_,_) => (d14,x,d34),	//348
(x,_,_) => (d14,-x,d34),	//349
(x,_,_) => (d14,-x,d78),	//350
(x,_,_) => (d14,x,-x+d12),	//351
(x,_,_) => (d14,x+d12,0),	//352
(x,_,_) => (d14,-x+d12,0),	//353
(x,_,_) => (d14,-x+d12,d12),	//354
(x,_,_) => (d14,-x+d12,d14),	//355
(x,_,_) => (d14,x+d12,d34),	//356
(x,_,_) => (d14,-x+d12,d34),	//357
(x,_,_) => (d14,x+d12,d38),	//358
(x,_,_) => (d14,-x+d14,0),	//359
(x,_,_) => (d14,x+d14,d12),	//360
(x,_,_) => (d14,x+d14,d14),	//361
(x,_,_) => (d14,-x+d14,d14),	//362
(x,_,_) => (d14,-x+d14,d34),	//363
(x,_,_) => (d14,-x+d34,0),	//364
(x,_,_) => (d14,x+d34,d12),	//365
(x,_,_) => (d14,x+d34,d14),	//366
(_,y,_) => (d14,y,0),	//367
(_,y,_) => (d14,-y,0),	//368
(_,y,_) => (d14,y,d12),	//369
(_,y,_) => (d14,-y,d12),	//370
(_,y,_) => (d14,y,d14),	//371
(_,y,_) => (d14,-y,d14),	//372
(_,y,_) => (d14,y,d18),	//373
(_,y,_) => (d14,y,d34),	//374
(_,y,_) => (d14,-y,d34),	//375
(_,y,_) => (d14,y,y),	//376
(_,y,_) => (d14,y,-y),	//377
(_,y,_) => (d14,-y,y),	//378
(_,y,_) => (d14,-y,-y),	//379
(_,y,_) => (d14,y,y+d12),	//380
(_,y,_) => (d14,y,-y+d12),	//381
(_,y,_) => (d14,-y,y+d12),	//382
(_,y,_) => (d14,-y,-y+d12),	//383
(_,y,z) => (d14,y,z),	//384
(_,y,z) => (d14,y,-z),	//385
(_,y,z) => (d14,-y,z),	//386
(_,y,z) => (d14,-y,-z),	//387
(_,y,z) => (d14,y,-z+d12),	//388
(_,y,z) => (d14,-y,z+d12),	//389
(_,y,_) => (d14,y+d12,0),	//390
(_,y,_) => (d14,-y+d12,0),	//391
(_,y,_) => (d14,y+d12,d12),	//392
(_,y,_) => (d14,-y+d12,d12),	//393
(_,y,_) => (d14,y+d12,d14),	//394
(_,y,_) => (d14,-y+d12,d14),	//395
(_,y,_) => (d14,y+d12,d34),	//396
(_,y,_) => (d14,-y+d12,d34),	//397
(_,y,_) => (d14,-y+d12,d58),	//398
(_,y,_) => (d14,y+d12,y),	//399
(_,y,_) => (d14,y+d12,-y),	//400
(_,y,_) => (d14,-y+d12,y),	//401
(_,y,_) => (d14,-y+d12,-y),	//402
(_,y,_) => (d14,-y+d12,-y+d12),	//403
(_,y,_) => (d14,y+d12,y+d34),	//404
(_,y,z) => (d14,-y+d12,z),	//405
(_,y,z) => (d14,y+d12,-z+d12),	//406
(_,y,z) => (d14,-y+d12,z+d12),	//407
(_,y,_) => (d14,y+d14,d14),	//408
(_,y,_) => (d14,-y+d14,d14),	//409
(_,y,_) => (d14,y+d34,y+d12),	//410
(_,y,_) => (d14,y+d34,-y+d14),	//411
(_,_,_) => (d18,0,d14),	//412
(_,_,_) => (d18,0,d34),	//413
(_,_,_) => (d18,d12,d14),	//414
(_,_,_) => (d18,d18,d18),	//415
(_,_,_) => (d18,d18,d58),	//416
(_,_,_) => (d18,d18,d78),	//417
(x,_,_) => (d18,d18,x),	//418
(x,_,_) => (d18,d18,-x+d14),	//419
(_,_,z) => (d18,d18,z),	//420
(_,_,_) => (d18,d38,d58),	//421
(_,_,_) => (d18,d38,d78),	//422
(_,_,_) => (d18,d58,d18),	//423
(_,_,_) => (d18,d58,d38),	//424
(_,_,_) => (d18,d58,d78),	//425
(x,_,_) => (d18,d58,x),	//426
(x,_,_) => (d18,d58,-x+d34),	//427
(_,_,_) => (d18,d78,d18),	//428
(_,_,_) => (d18,d78,d38),	//429
(_,_,_) => (d18,d78,d58),	//430
(_,_,_) => (d18,d78,d78),	//431
(x,_,_) => (d18,x,d18),	//432
(x,_,_) => (d18,-x+d14,d18),	//433
(x,_,_) => (d18,-x+d34,d18),	//434
(_,y,_) => (d18,y,d18),	//435
(_,y,_) => (d18,y,y+d14),	//436
(_,y,_) => (d18,y,-y+d14),	//437
(_,y,_) => (d18,-y+d12,-y+d34),	//438
(_,y,_) => (d18,-y+d14,y),	//439
(_,y,_) => (d18,y+d34,-y+d12),	//440
(x,_,_) => (2*x,x,0),	//441
(x,_,_) => (-2*x,-x,0),	//442
(x,_,_) => (2*x,x,d1_12),	//443
(x,_,_) => (2*x,x,d12),	//444
(x,_,_) => (-2*x,-x,d12),	//445
(x,_,_) => (2*x,x,d13),	//446
(x,_,_) => (-2*x,-x,d13),	//447
(x,_,_) => (2*x,x,d14),	//448
(x,_,_) => (-2*x,-x,d14),	//449
(x,_,_) => (2*x,x,d16),	//450
(x,_,_) => (-2*x,-x,d16),	//451
(x,_,_) => (2*x,x,d11_12),	//452
(x,_,_) => (2*x,x,d23),	//453
(x,_,_) => (-2*x,-x,d23),	//454
(x,_,_) => (2*x,x,d34),	//455
(x,_,_) => (-2*x,-x,d34),	//456
(x,_,_) => (-2*x,-x,d5_12),	//457
(x,_,_) => (2*x,x,d56),	//458
(x,_,_) => (-2*x,-x,d56),	//459
(x,_,_) => (-2*x,-x,d7_12),	//460
(x,_,z) => (2*x,x,z),	//461
(x,_,z) => (2*x,x,-z),	//462
(x,_,z) => (-2*x,-x,z),	//463
(x,_,z) => (-2*x,-x,-z),	//464
(x,_,z) => (2*x,x,z+d12),	//465
(x,_,z) => (-2*x,-x,-z+d12),	//466
(_,_,_) => (d23,d13,0),	//467
(_,_,_) => (d23,d13,d12),	//468
(_,_,_) => (d23,d13,d14),	//469
(_,_,_) => (d23,d13,d34),	//470
(_,_,z) => (d23,d13,z),	//471
(_,_,z) => (d23,d13,-z),	//472
(_,_,z) => (d23,d13,z+d12),	//473
(_,_,z) => (d23,d13,-z+d12),	//474
(_,_,_) => (d34,0,0),	//475
(_,_,_) => (d34,0,d12),	//476
(_,_,_) => (d34,0,d14),	//477
(_,_,_) => (d34,0,d34),	//478
(_,_,_) => (d34,0,d38),	//479
(_,_,_) => (d34,0,d78),	//480
(_,_,z) => (d34,0,z),	//481
(_,_,z) => (d34,0,-z),	//482
(_,_,z) => (d34,0,z+d12),	//483
(_,_,z) => (d34,0,-z+d12),	//484
(_,_,_) => (d34,d12,0),	//485
(_,_,_) => (d34,d12,d12),	//486
(_,_,_) => (d34,d12,d14),	//487
(_,_,_) => (d34,d12,d34),	//488
(_,_,_) => (d34,d12,d38),	//489
(_,_,_) => (d34,d12,d78),	//490
(_,_,z) => (d34,d12,z),	//491
(_,_,z) => (d34,d12,-z),	//492
(_,_,z) => (d34,d12,z+d12),	//493
(_,_,z) => (d34,d12,-z+d12),	//494
(_,_,_) => (d34,d14,0),	//495
(_,_,_) => (d34,d14,d12),	//496
(_,_,_) => (d34,d14,d14),	//497
(_,_,_) => (d34,d14,d34),	//498
(x,_,_) => (d34,d14,x),	//499
(x,_,_) => (d34,d14,-x),	//500
(x,_,_) => (d34,d14,x+d12),	//501
(x,_,_) => (d34,d14,-x+d12),	//502
(x,_,_) => (d34,d14,-x+d34),	//503
(_,_,z) => (d34,d14,z),	//504
(_,_,z) => (d34,d14,-z),	//505
(_,_,z) => (d34,d14,z+d12),	//506
(_,_,z) => (d34,d14,-z+d12),	//507
(_,_,_) => (d34,d18,0),	//508
(_,_,_) => (d34,d34,0),	//509
(_,_,_) => (d34,d34,d12),	//510
(_,_,_) => (d34,d34,d14),	//511
(_,_,_) => (d34,d34,d34),	//512
(x,_,_) => (d34,d34,-x),	//513
(x,_,_) => (d34,d34,x+d12),	//514
(x,_,_) => (d34,d34,-x+d34),	//515
(_,_,z) => (d34,d34,z),	//516
(_,_,z) => (d34,d34,-z),	//517
(_,_,z) => (d34,d34,z+d12),	//518
(_,_,z) => (d34,d34,-z+d12),	//519
(_,_,_) => (d34,d38,0),	//520
(_,_,_) => (d34,d38,d12),	//521
(_,_,_) => (d34,d58,0),	//522
(_,_,_) => (d34,d78,0),	//523
(x,_,_) => (d34,-x,0),	//524
(x,_,_) => (d34,-x,d12),	//525
(x,_,_) => (d34,x,d14),	//526
(x,_,_) => (d34,-x,d14),	//527
(x,_,_) => (d34,-x,d34),	//528
(x,_,_) => (d34,x,d78),	//529
(x,_,_) => (d34,-x,d78),	//530
(x,_,_) => (d34,-x,x+d12),	//531
(x,_,_) => (d34,x+d12,0),	//532
(x,_,_) => (d34,-x+d12,0),	//533
(x,_,_) => (d34,x+d12,d12),	//534
(x,_,_) => (d34,x+d12,d14),	//535
(x,_,_) => (d34,-x+d12,d14),	//536
(x,_,_) => (d34,x+d12,d34),	//537
(x,_,_) => (d34,x+d12,d38),	//538
(x,_,_) => (d34,x+d14,0),	//539
(x,_,_) => (d34,-x+d14,d12),	//540
(x,_,_) => (d34,x+d14,d34),	//541
(x,_,_) => (d34,-x+d14,d34),	//542
(x,_,_) => (d34,x+d34,0),	//543
(x,_,_) => (d34,-x+d34,d12),	//544
(x,_,_) => (d34,x+d34,d14),	//545
(x,_,_) => (d34,-x+d34,d34),	//546
(_,y,_) => (d34,y,0),	//547
(_,y,_) => (d34,-y,0),	//548
(_,y,_) => (d34,y,d12),	//549
(_,y,_) => (d34,-y,d12),	//550
(_,y,_) => (d34,y,d14),	//551
(_,y,_) => (d34,-y,d14),	//552
(_,y,_) => (d34,y,d34),	//553
(_,y,_) => (d34,-y,d34),	//554
(_,y,_) => (d34,y,d58),	//555
(_,y,_) => (d34,y,y),	//556
(_,y,_) => (d34,y,-y),	//557
(_,y,_) => (d34,-y,y),	//558
(_,y,_) => (d34,-y,-y),	//559
(_,y,_) => (d34,y,y+d12),	//560
(_,y,_) => (d34,y,-y+d12),	//561
(_,y,_) => (d34,-y,y+d12),	//562
(_,y,_) => (d34,-y,-y+d12),	//563
(_,y,z) => (d34,y,z),	//564
(_,y,z) => (d34,y,-z),	//565
(_,y,z) => (d34,-y,z),	//566
(_,y,z) => (d34,-y,-z),	//567
(_,y,z) => (d34,y,-z+d12),	//568
(_,y,z) => (d34,-y,z+d12),	//569
(_,y,_) => (d34,y+d12,0),	//570
(_,y,_) => (d34,-y+d12,0),	//571
(_,y,_) => (d34,y+d12,d12),	//572
(_,y,_) => (d34,-y+d12,d12),	//573
(_,y,_) => (d34,y+d12,d14),	//574
(_,y,_) => (d34,-y+d12,d14),	//575
(_,y,_) => (d34,-y+d12,d18),	//576
(_,y,_) => (d34,y+d12,d34),	//577
(_,y,_) => (d34,-y+d12,d34),	//578
(_,y,_) => (d34,y+d12,y),	//579
(_,y,_) => (d34,y+d12,-y),	//580
(_,y,_) => (d34,-y+d12,y),	//581
(_,y,_) => (d34,-y+d12,-y),	//582
(_,y,_) => (d34,y+d12,y+d12),	//583
(_,y,_) => (d34,-y+d12,-y+d14),	//584
(_,y,z) => (d34,y+d12,-z),	//585
(_,y,z) => (d34,y+d12,-z+d12),	//586
(_,y,z) => (d34,-y+d12,z+d12),	//587
(_,y,_) => (d34,-y+d14,-y+d12),	//588
(_,y,_) => (d34,-y+d14,y+d34),	//589
(_,_,_) => (d38,0,d14),	//590
(_,_,_) => (d38,0,d34),	//591
(_,_,_) => (d38,d18,d58),	//592
(_,_,_) => (d38,d18,d78),	//593
(_,_,_) => (d38,d38,d38),	//594
(_,_,_) => (d38,d38,d58),	//595
(x,_,_) => (d38,d38,x+d34),	//596
(_,_,_) => (d38,d58,d18),	//597
(_,_,_) => (d38,d58,d38),	//598
(_,_,_) => (d38,d58,d58),	//599
(_,_,_) => (d38,d58,d78),	//600
(_,_,_) => (d38,d78,d18),	//601
(_,_,_) => (d38,d78,d58),	//602
(x,_,_) => (d38,d78,x+d34),	//603
(_,_,z) => (d38,d78,z+d14),	//604
(x,_,_) => (d38,-x+d12,d38),	//605
(x,_,_) => (d38,x+d34,d38),	//606
(_,y,_) => (d38,-y,y+d34),	//607
(_,y,_) => (d38,-y,-y+d34),	//608
(_,y,_) => (d38,y+d12,-y+d14),	//609
(_,y,_) => (d38,y+d12,y+d34),	//610
(_,y,_) => (d38,y+d14,d78),	//611
(_,y,_) => (d38,-y+d14,-y),	//612
(_,y,_) => (d38,y+d34,y+d12),	//613
(_,_,_) => (d58,0,d14),	//614
(_,_,_) => (d58,0,d34),	//615
(_,_,_) => (d58,d18,d38),	//616
(_,_,_) => (d58,d18,d78),	//617
(x,_,_) => (d58,d18,-x+d14),	//618
(_,_,z) => (d58,d18,-z+d34),	//619
(_,_,_) => (d58,d38,d18),	//620
(_,_,_) => (d58,d38,d38),	//621
(_,_,_) => (d58,d38,d58),	//622
(_,_,_) => (d58,d38,d78),	//623
(_,_,_) => (d58,d58,d38),	//624
(_,_,_) => (d58,d58,d58),	//625
(x,_,_) => (d58,d58,-x+d14),	//626
(_,_,_) => (d58,d78,d18),	//627
(_,_,_) => (d58,d78,d38),	//628
(x,_,_) => (d58,x+d12,d58),	//629
(x,_,_) => (d58,-x+d14,d58),	//630
(x,_,_) => (d58,-x+d34,d18),	//631
(_,y,_) => (d58,y,y+d14),	//632
(_,y,_) => (d58,-y,y+d14),	//633
(_,y,_) => (d58,-y+d12,y+d34),	//634
(_,y,_) => (d58,-y+d12,-y+d34),	//635
(_,y,_) => (d58,y+d14,-y),	//636
(_,y,_) => (d58,-y+d34,d18),	//637
(_,y,_) => (d58,-y+d34,y+d12),	//638
(_,_,_) => (d78,0,d14),	//639
(_,_,_) => (d78,0,d34),	//640
(_,_,_) => (d78,d18,d18),	//641
(_,_,_) => (d78,d18,d38),	//642
(_,_,_) => (d78,d18,d58),	//643
(_,_,_) => (d78,d18,d78),	//644
(_,_,_) => (d78,d38,d18),	//645
(_,_,_) => (d78,d38,d38),	//646
(_,_,_) => (d78,d38,d58),	//647
(_,_,_) => (d78,d38,d78),	//648
(x,_,_) => (d78,d38,-x),	//649
(x,_,_) => (d78,d38,-x+d12),	//650
(_,_,_) => (d78,d58,d18),	//651
(_,_,_) => (d78,d58,d38),	//652
(_,_,_) => (d78,d78,d18),	//653
(_,_,_) => (d78,d78,d38),	//654
(_,_,_) => (d78,d78,d78),	//655
(x,_,_) => (d78,d78,-x),	//656
(x,_,_) => (d78,d78,x+d34),	//657
(_,_,z) => (d78,d78,-z),	//658
(x,_,_) => (d78,-x,d78),	//659
(x,_,_) => (d78,x+d14,d38),	//660
(x,_,_) => (d78,x+d14,d78),	//661
(x,_,_) => (d78,x+d34,d78),	//662
(_,y,_) => (d78,-y,d78),	//663
(_,y,_) => (d78,-y,y+d34),	//664
(_,y,_) => (d78,y+d12,y+d14),	//665
(_,y,_) => (d78,y+d12,-y+d14),	//666
(_,y,_) => (d78,-y+d12,-y+d34),	//667
(_,y,_) => (d78,y+d14,y),	//668
(_,y,_) => (d78,-y+d34,-y+d12),	//669
(x,_,_) => (x,0,0),	//670
(x,_,_) => (-x,0,0),	//671
(x,_,_) => (x,0,d12),	//672
(x,_,_) => (-x,0,d12),	//673
(x,_,_) => (x,0,d13),	//674
(x,_,_) => (x,0,d14),	//675
(x,_,_) => (-x,0,d14),	//676
(x,_,_) => (x,0,d16),	//677
(x,_,_) => (x,0,d23),	//678
(x,_,_) => (x,0,d34),	//679
(x,_,_) => (-x,0,d34),	//680
(x,_,_) => (x,0,d56),	//681
(x,_,_) => (x,0,-x),	//682
(x,_,_) => (-x,0,x),	//683
(x,_,z) => (x,0,z),	//684
(x,_,z) => (x,0,-z),	//685
(x,_,z) => (-x,0,z),	//686
(x,_,z) => (-x,0,-z),	//687
(x,_,z) => (x,0,-z+d12),	//688
(x,_,z) => (-x,0,z+d12),	//689
(x,_,_) => (x,d12,0),	//690
(x,_,_) => (-x,d12,0),	//691
(x,_,_) => (x,d12,d12),	//692
(x,_,_) => (-x,d12,d12),	//693
(x,_,_) => (x,d12,d14),	//694
(x,_,_) => (-x,d12,d14),	//695
(x,_,_) => (x,d12,d34),	//696
(x,_,_) => (-x,d12,d34),	//697
(x,_,_) => (x,d12,-x),	//698
(x,_,_) => (-x,d12,x),	//699
(x,_,z) => (x,d12,z),	//700
(x,_,z) => (x,d12,-z),	//701
(x,_,z) => (-x,d12,z),	//702
(x,_,z) => (-x,d12,-z),	//703
(x,_,z) => (x,d12,-z+d12),	//704
(x,_,z) => (-x,d12,z+d12),	//705
(x,_,z) => (-x,d12,-z+d12),	//706
(x,_,_) => (x,d14,0),	//707
(x,_,_) => (-x,d14,0),	//708
(x,_,_) => (x,d14,d12),	//709
(x,_,_) => (-x,d14,d12),	//710
(x,_,_) => (x,d14,d14),	//711
(x,_,_) => (-x,d14,d14),	//712
(x,_,_) => (x,d14,d18),	//713
(x,_,_) => (-x,d14,d18),	//714
(x,_,_) => (x,d14,d34),	//715
(x,_,_) => (-x,d14,d34),	//716
(x,_,z) => (x,d14,z),	//717
(x,_,z) => (x,d14,-z),	//718
(x,_,z) => (-x,d14,z),	//719
(x,_,z) => (-x,d14,-z),	//720
(x,_,z) => (x,d14,-z+d12),	//721
(x,_,_) => (x,d18,d18),	//722
(x,_,_) => (x,d18,d58),	//723
(x,_,_) => (x,2*x,0),	//724
(x,_,_) => (-x,-2*x,0),	//725
(x,_,_) => (x,2*x,d12),	//726
(x,_,_) => (-x,-2*x,d12),	//727
(x,_,_) => (x,2*x,d13),	//728
(x,_,_) => (x,2*x,d14),	//729
(x,_,_) => (-x,-2*x,d14),	//730
(x,_,_) => (x,2*x,d16),	//731
(x,_,_) => (x,2*x,d23),	//732
(x,_,_) => (x,2*x,d34),	//733
(x,_,_) => (-x,-2*x,d34),	//734
(x,_,_) => (x,2*x,d56),	//735
(x,_,z) => (x,2*x,z),	//736
(x,_,z) => (x,2*x,-z),	//737
(x,_,z) => (-x,-2*x,z),	//738
(x,_,z) => (-x,-2*x,-z),	//739
(x,_,z) => (x,2*x,-z+d12),	//740
(x,_,z) => (-x,-2*x,z+d12),	//741
(x,_,_) => (x,d34,0),	//742
(x,_,_) => (-x,d34,0),	//743
(x,_,_) => (x,d34,d12),	//744
(x,_,_) => (-x,d34,d12),	//745
(x,_,_) => (x,d34,d14),	//746
(x,_,_) => (-x,d34,d14),	//747
(x,_,_) => (-x,d34,d18),	//748
(x,_,_) => (x,d34,d34),	//749
(x,_,_) => (-x,d34,d34),	//750
(x,_,z) => (x,d34,z),	//751
(x,_,z) => (x,d34,-z),	//752
(x,_,z) => (-x,d34,z),	//753
(x,_,z) => (-x,d34,-z),	//754
(x,_,z) => (-x,d34,z+d12),	//755
(x,_,_) => (-x,d78,d38),	//756
(x,_,_) => (-x,d78,d78),	//757
(x,_,_) => (x,x,0),	//758
(x,_,_) => (x,-x,0),	//759
(x,_,_) => (-x,x,0),	//760
(x,_,_) => (-x,-x,0),	//761
(x,_,_) => (x,-x,d1_12),	//762
(x,_,_) => (x,x,d12),	//763
(x,_,_) => (x,-x,d12),	//764
(x,_,_) => (-x,x,d12),	//765
(x,_,_) => (-x,-x,d12),	//766
(x,_,_) => (x,x,d13),	//767
(x,_,_) => (x,-x,d13),	//768
(x,_,_) => (-x,x,d13),	//769
(x,_,_) => (-x,-x,d13),	//770
(x,_,_) => (x,x,d14),	//771
(x,_,_) => (x,-x,d14),	//772
(x,_,_) => (-x,x,d14),	//773
(x,_,_) => (-x,-x,d14),	//774
(x,_,_) => (x,x,d16),	//775
(x,_,_) => (x,-x,d16),	//776
(x,_,_) => (-x,x,d16),	//777
(x,_,_) => (-x,-x,d16),	//778
(x,_,_) => (x,-x,d18),	//779
(x,_,_) => (-x,-x,d18),	//780
(x,_,_) => (x,-x,d11_12),	//781
(x,_,_) => (x,x,d23),	//782
(x,_,_) => (x,-x,d23),	//783
(x,_,_) => (-x,x,d23),	//784
(x,_,_) => (-x,-x,d23),	//785
(x,_,_) => (x,x,d34),	//786
(x,_,_) => (x,-x,d34),	//787
(x,_,_) => (-x,x,d34),	//788
(x,_,_) => (-x,-x,d34),	//789
(x,_,_) => (x,x,d38),	//790
(x,_,_) => (-x,x,d38),	//791
(x,_,_) => (-x,x,d5_12),	//792
(x,_,_) => (x,x,d56),	//793
(x,_,_) => (x,-x,d56),	//794
(x,_,_) => (-x,x,d56),	//795
(x,_,_) => (-x,-x,d56),	//796
(x,_,_) => (x,x,d58),	//797
(x,_,_) => (-x,x,d58),	//798
(x,_,_) => (-x,x,d7_12),	//799
(x,_,_) => (x,-x,d78),	//800
(x,_,_) => (-x,-x,d78),	//801
(x,_,_) => (x,x,x),	//802
(x,_,_) => (x,x,-x),	//803
(x,_,_) => (x,-x,x),	//804
(x,_,_) => (x,-x,-x),	//805
(x,_,_) => (-x,x,x),	//806
(x,_,_) => (-x,x,-x),	//807
(x,_,_) => (-x,-x,x),	//808
(x,_,_) => (-x,-x,-x),	//809
(x,_,_) => (x,x,-x+d12),	//810
(x,_,_) => (x,-x,-x+d12),	//811
(x,_,_) => (-x,-x,x+d12),	//812
(x,_,z) => (x,x,z),	//813
(x,_,z) => (x,x,-z),	//814
(x,_,z) => (x,-x,z),	//815
(x,_,z) => (x,-x,-z),	//816
(x,_,z) => (-x,x,z),	//817
(x,_,z) => (-x,x,-z),	//818
(x,_,z) => (-x,-x,z),	//819
(x,_,z) => (-x,-x,-z),	//820
(x,_,z) => (x,x,z+d12),	//821
(x,_,z) => (x,-x,z+d12),	//822
(x,_,z) => (x,-x,-z+d12),	//823
(x,_,z) => (-x,x,z+d12),	//824
(x,_,z) => (-x,x,-z+d12),	//825
(x,_,z) => (-x,-x,-z+d12),	//826
(x,_,_) => (x,x+d12,0),	//827
(x,_,_) => (x,-x+d12,0),	//828
(x,_,_) => (-x,x+d12,0),	//829
(x,_,_) => (-x,-x+d12,0),	//830
(x,_,_) => (x,x+d12,d12),	//831
(x,_,_) => (x,-x+d12,d12),	//832
(x,_,_) => (-x,x+d12,d12),	//833
(x,_,_) => (-x,-x+d12,d12),	//834
(x,_,_) => (x,x+d12,d14),	//835
(x,_,_) => (x,-x+d12,d14),	//836
(x,_,_) => (-x,x+d12,d14),	//837
(x,_,_) => (-x,-x+d12,d14),	//838
(x,_,_) => (x,x+d12,d34),	//839
(x,_,_) => (x,-x+d12,d34),	//840
(x,_,_) => (-x,x+d12,d34),	//841
(x,_,_) => (-x,-x+d12,d34),	//842
(x,_,_) => (x,-x+d12,x),	//843
(x,_,_) => (-x,x+d12,-x),	//844
(x,_,_) => (-x,-x+d12,x),	//845
(x,_,_) => (x,-x+d12,x+d12),	//846
(x,_,_) => (x,-x+d12,-x+d12),	//847
(x,_,_) => (-x,x+d12,x+d12),	//848
(x,_,_) => (-x,x+d12,-x+d12),	//849
(x,_,_) => (-x,-x+d12,x+d12),	//850
(x,_,z) => (x,x+d12,z),	//851
(x,_,z) => (x,x+d12,-z),	//852
(x,_,z) => (x,-x+d12,z),	//853
(x,_,z) => (x,-x+d12,-z),	//854
(x,_,z) => (-x,x+d12,z),	//855
(x,_,z) => (-x,x+d12,-z),	//856
(x,_,z) => (-x,-x+d12,z),	//857
(x,_,z) => (-x,-x+d12,-z),	//858
(x,_,z) => (x,x+d12,-z+d12),	//859
(x,_,z) => (x,-x+d12,z+d12),	//860
(x,_,z) => (x,-x+d12,-z+d12),	//861
(x,_,z) => (-x,x+d12,z+d12),	//862
(x,_,z) => (-x,x+d12,-z+d12),	//863
(x,_,z) => (-x,-x+d12,z+d12),	//864
(x,_,_) => (x,x+d14,d18),	//865
(x,_,_) => (x,-x+d14,d58),	//866
(x,_,_) => (x,x+d14,d78),	//867
(x,_,_) => (x,-x+d14,d78),	//868
(x,_,_) => (x,-x+d14,-x+d14),	//869
(x,_,_) => (x,-x+d14,-x+d34),	//870
(x,_,_) => (-x,x+d34,d18),	//871
(x,_,_) => (-x,-x+d34,d18),	//872
(x,_,_) => (-x,x+d34,d38),	//873
(x,_,_) => (-x,-x+d34,d78),	//874
(x,_,_) => (-x,x+d34,x+d14),	//875
(x,_,_) => (-x,x+d34,x+d34),	//876
(x,y,_) => (-x,-x+y,0),	//877
(x,y,_) => (-x,-x+y,d12),	//878
(x,y,_) => (-x,-x+y,d14),	//879
(x,y,_) => (-x,-x+y,d34),	//880
(x,y,z) => (-x,-x+y,z),	//881
(x,y,z) => (-x,-x+y,-z),	//882
(x,y,z) => (-x,-x+y,z+d12),	//883
(x,y,z) => (-x,-x+y,-z+d12),	//884
(x,y,z) => (-x,-x+y,-z+d13),	//885
(x,y,z) => (-x,-x+y,-z+d23),	//886
(x,y,_) => (x,x-y,0),	//887
(x,y,_) => (x,x-y,d12),	//888
(x,y,_) => (x,x-y,d14),	//889
(x,y,_) => (x,x-y,d34),	//890
(x,y,z) => (x,x-y,z),	//891
(x,y,z) => (x,x-y,-z),	//892
(x,y,z) => (x,x-y,z+d12),	//893
(x,y,z) => (x,x-y,-z+d12),	//894
(x,y,z) => (x,x-y,-z+d13),	//895
(x,y,z) => (x,x-y,-z+d16),	//896
(x,y,z) => (x,x-y,-z+d23),	//897
(x,y,z) => (x,x-y,-z+d56),	//898
(x,y,_) => (x,y,0),	//899
(x,y,_) => (x,-y,0),	//900
(x,y,_) => (-x,y,0),	//901
(x,y,_) => (-x,-y,0),	//902
(x,y,_) => (x,y,d12),	//903
(x,y,_) => (x,-y,d12),	//904
(x,y,_) => (-x,y,d12),	//905
(x,y,_) => (-x,-y,d12),	//906
(x,y,_) => (x,y,d14),	//907
(x,y,_) => (x,-y,d14),	//908
(x,y,_) => (-x,y,d14),	//909
(x,y,_) => (-x,-y,d14),	//910
(x,y,_) => (x,y,d34),	//911
(x,y,_) => (x,-y,d34),	//912
(x,y,_) => (-x,y,d34),	//913
(x,y,_) => (-x,-y,d34),	//914
(x,y,z) => (x,y,z),	//915
(x,y,z) => (x,y,-z),	//916
(x,y,z) => (x,-y,z),	//917
(x,y,z) => (x,-y,-z),	//918
(x,y,z) => (-x,y,z),	//919
(x,y,z) => (-x,y,-z),	//920
(x,y,z) => (-x,-y,z),	//921
(x,y,z) => (-x,-y,-z),	//922
(x,y,z) => (x,y,-z+d12),	//923
(x,y,z) => (x,-y,z+d12),	//924
(x,y,z) => (x,-y,-z+d12),	//925
(x,y,z) => (-x,y,z+d12),	//926
(x,y,z) => (-x,y,-z+d12),	//927
(x,y,z) => (-x,-y,z+d12),	//928
(x,y,_) => (x,-y+d12,0),	//929
(x,y,_) => (-x,y+d12,0),	//930
(x,y,_) => (x,-y+d12,d12),	//931
(x,y,_) => (-x,y+d12,d12),	//932
(x,y,_) => (-x,-y+d12,d12),	//933
(x,y,_) => (x,-y+d12,d14),	//934
(x,y,_) => (-x,y+d12,d14),	//935
(x,y,_) => (x,-y+d12,d34),	//936
(x,y,_) => (-x,y+d12,d34),	//937
(x,y,z) => (x,y+d12,-z),	//938
(x,y,z) => (x,-y+d12,z),	//939
(x,y,z) => (x,-y+d12,-z),	//940
(x,y,z) => (-x,y+d12,z),	//941
(x,y,z) => (-x,y+d12,-z),	//942
(x,y,z) => (-x,-y+d12,z),	//943
(x,y,z) => (x,y+d12,-z+d12),	//944
(x,y,z) => (x,-y+d12,z+d12),	//945
(x,y,z) => (x,-y+d12,-z+d12),	//946
(x,y,z) => (-x,y+d12,z+d12),	//947
(x,y,z) => (-x,y+d12,-z+d12),	//948
(x,y,z) => (-x,-y+d12,z+d12),	//949
(x,y,z) => (-x,-y+d12,-z+d12),	//950
(x,y,z) => (x,-y+d12,-z+d14),	//951
(x,y,z) => (-x,-y+d12,-z+d14),	//952
(x,y,z) => (x,-y+d12,-z+d34),	//953
(x,y,z) => (x,-y+d14,-z+d14),	//954
(x,y,z) => (-x,y+d14,z+d14),	//955
(x,y,z) => (x,-y+d34,-z+d34),	//956
(x,y,z) => (-x,y+d34,z+d34),	//957
(x,_,z) => (x,z,x),	//958
(x,_,z) => (x,z,-x),	//959
(x,_,z) => (x,-z,x),	//960
(x,_,z) => (x,-z,-x),	//961
(x,_,z) => (-x,z,x),	//962
(x,_,z) => (-x,z,-x),	//963
(x,_,z) => (-x,-z,x),	//964
(x,_,z) => (-x,-z,-x),	//965
(x,y,z) => (x,z,y),	//966
(x,y,z) => (x,z,-y),	//967
(x,y,z) => (x,-z,y),	//968
(x,y,z) => (x,-z,-y),	//969
(x,y,z) => (-x,z,y),	//970
(x,y,z) => (-x,z,-y),	//971
(x,y,z) => (-x,-z,y),	//972
(x,y,z) => (-x,-z,-y),	//973
(x,y,z) => (x,z,-y+d12),	//974
(x,y,z) => (x,-z,-y+d12),	//975
(x,y,z) => (-x,-z,y+d12),	//976
(x,_,z) => (x,-z+d12,-x+d12),	//977
(x,_,z) => (-x,z+d12,x+d12),	//978
(x,_,z) => (-x,-z+d12,x+d12),	//979
(x,y,z) => (x,-z+d12,y),	//980
(x,y,z) => (-x,z+d12,-y),	//981
(x,y,z) => (-x,-z+d12,y),	//982
(x,y,z) => (x,-z+d12,-y+d12),	//983
(x,y,z) => (-x,z+d12,y+d12),	//984
(x,y,z) => (-x,z+d12,-y+d12),	//985
(x,y,z) => (x,-z+d14,-y+d34),	//986
(x,y,z) => (-x,z+d34,y+d14),	//987
(x,_,_) => (x+d12,0,0),	//988
(x,_,_) => (-x+d12,0,0),	//989
(x,_,_) => (x+d12,0,d12),	//990
(x,_,_) => (-x+d12,0,d12),	//991
(x,_,_) => (x+d12,0,d14),	//992
(x,_,_) => (-x+d12,0,d14),	//993
(x,_,_) => (x+d12,0,d34),	//994
(x,_,_) => (-x+d12,0,d34),	//995
(x,_,z) => (x+d12,0,-z),	//996
(x,_,z) => (-x+d12,0,z),	//997
(x,_,z) => (x+d12,0,-z+d12),	//998
(x,_,z) => (-x+d12,0,z+d12),	//999
(x,_,_) => (x+d12,d12,0),	//1000
(x,_,_) => (-x+d12,d12,0),	//1001
(x,_,_) => (x+d12,d12,d12),	//1002
(x,_,_) => (-x+d12,d12,d12),	//1003
(x,_,_) => (x+d12,d12,d14),	//1004
(x,_,_) => (-x+d12,d12,d14),	//1005
(x,_,_) => (x+d12,d12,d34),	//1006
(x,_,_) => (-x+d12,d12,d34),	//1007
(x,_,z) => (x+d12,d12,-z),	//1008
(x,_,z) => (-x+d12,d12,z),	//1009
(x,_,z) => (-x+d12,d12,-z),	//1010
(x,_,z) => (x+d12,d12,-z+d12),	//1011
(x,_,z) => (-x+d12,d12,z+d12),	//1012
(x,_,_) => (x+d12,d14,0),	//1013
(x,_,_) => (-x+d12,d14,0),	//1014
(x,_,_) => (x+d12,d14,d12),	//1015
(x,_,_) => (-x+d12,d14,d12),	//1016
(x,_,_) => (x+d12,d14,d14),	//1017
(x,_,_) => (-x+d12,d14,d14),	//1018
(x,_,_) => (x+d12,d14,d34),	//1019
(x,_,_) => (-x+d12,d14,d34),	//1020
(x,_,_) => (x+d12,d14,d58),	//1021
(x,_,_) => (-x+d12,d14,d58),	//1022
(x,_,_) => (-x+d12,d14,x),	//1023
(x,_,z) => (x+d12,d14,-z),	//1024
(x,_,z) => (-x+d12,d14,z),	//1025
(x,_,z) => (x+d12,d14,-z+d12),	//1026
(x,_,z) => (-x+d12,d14,z+d12),	//1027
(x,_,_) => (x+d12,d34,0),	//1028
(x,_,_) => (-x+d12,d34,0),	//1029
(x,_,_) => (x+d12,d34,d12),	//1030
(x,_,_) => (-x+d12,d34,d12),	//1031
(x,_,_) => (x+d12,d34,d14),	//1032
(x,_,_) => (-x+d12,d34,d14),	//1033
(x,_,_) => (x+d12,d34,d34),	//1034
(x,_,_) => (-x+d12,d34,d34),	//1035
(x,_,_) => (x+d12,d34,-x),	//1036
(x,_,z) => (x+d12,d34,-z),	//1037
(x,_,z) => (-x+d12,d34,z),	//1038
(x,_,z) => (x+d12,d34,-z+d12),	//1039
(x,_,z) => (-x+d12,d34,z+d12),	//1040
(x,_,_) => (-x+d12,d78,d38),	//1041
(x,_,_) => (x+d12,x,0),	//1042
(x,_,_) => (x+d12,-x,0),	//1043
(x,_,_) => (-x+d12,x,0),	//1044
(x,_,_) => (-x+d12,-x,0),	//1045
(x,_,_) => (x+d12,x,d12),	//1046
(x,_,_) => (x+d12,-x,d12),	//1047
(x,_,_) => (-x+d12,x,d12),	//1048
(x,_,_) => (-x+d12,-x,d12),	//1049
(x,_,_) => (x+d12,x,d14),	//1050
(x,_,_) => (x+d12,-x,d14),	//1051
(x,_,_) => (-x+d12,x,d14),	//1052
(x,_,_) => (-x+d12,-x,d14),	//1053
(x,_,_) => (x+d12,x,d34),	//1054
(x,_,_) => (x+d12,-x,d34),	//1055
(x,_,_) => (-x+d12,x,d34),	//1056
(x,_,_) => (-x+d12,-x,d34),	//1057
(x,_,_) => (x+d12,-x,-x),	//1058
(x,_,_) => (-x+d12,x,x),	//1059
(x,_,_) => (-x+d12,x,-x),	//1060
(x,_,_) => (x+d12,x,-x+d12),	//1061
(x,_,_) => (x+d12,-x,x+d12),	//1062
(x,_,_) => (x+d12,-x,-x+d12),	//1063
(x,_,_) => (-x+d12,x,-x+d12),	//1064
(x,_,_) => (-x+d12,-x,x+d12),	//1065
(x,_,z) => (x+d12,x,z),	//1066
(x,_,z) => (x+d12,x,-z),	//1067
(x,_,z) => (x+d12,-x,z),	//1068
(x,_,z) => (x+d12,-x,-z),	//1069
(x,_,z) => (-x+d12,x,z),	//1070
(x,_,z) => (-x+d12,x,-z),	//1071
(x,_,z) => (-x+d12,-x,-z),	//1072
(x,_,z) => (x+d12,x,z+d12),	//1073
(x,_,z) => (x+d12,x,-z+d12),	//1074
(x,_,z) => (x+d12,-x,z+d12),	//1075
(x,_,z) => (x+d12,-x,-z+d12),	//1076
(x,_,z) => (-x+d12,x,z+d12),	//1077
(x,_,z) => (-x+d12,x,-z+d12),	//1078
(x,_,z) => (-x+d12,-x,-z+d12),	//1079
(x,_,_) => (x+d12,x+d12,0),	//1080
(x,_,_) => (x+d12,-x+d12,0),	//1081
(x,_,_) => (-x+d12,x+d12,0),	//1082
(x,_,_) => (-x+d12,-x+d12,0),	//1083
(x,_,_) => (x+d12,x+d12,d12),	//1084
(x,_,_) => (x+d12,-x+d12,d12),	//1085
(x,_,_) => (-x+d12,x+d12,d12),	//1086
(x,_,_) => (-x+d12,-x+d12,d12),	//1087
(x,_,_) => (x+d12,x+d12,d14),	//1088
(x,_,_) => (x+d12,-x+d12,d14),	//1089
(x,_,_) => (-x+d12,x+d12,d14),	//1090
(x,_,_) => (-x+d12,-x+d12,d14),	//1091
(x,_,_) => (x+d12,x+d12,d34),	//1092
(x,_,_) => (x+d12,-x+d12,d34),	//1093
(x,_,_) => (-x+d12,x+d12,d34),	//1094
(x,_,_) => (-x+d12,-x+d12,d34),	//1095
(x,_,_) => (x+d12,x+d12,-x),	//1096
(x,_,_) => (x+d12,-x+d12,-x),	//1097
(x,_,_) => (-x+d12,x+d12,x),	//1098
(x,_,_) => (-x+d12,x+d12,-x),	//1099
(x,_,_) => (-x+d12,-x+d12,x),	//1100
(x,_,_) => (x+d12,x+d12,x+d12),	//1101
(x,_,_) => (x+d12,x+d12,-x+d12),	//1102
(x,_,_) => (x+d12,-x+d12,x+d12),	//1103
(x,_,_) => (x+d12,-x+d12,-x+d12),	//1104
(x,_,_) => (-x+d12,x+d12,x+d12),	//1105
(x,_,_) => (-x+d12,x+d12,-x+d12),	//1106
(x,_,_) => (-x+d12,-x+d12,x+d12),	//1107
(x,_,_) => (-x+d12,-x+d12,-x+d12),	//1108
(x,_,z) => (x+d12,x+d12,-z),	//1109
(x,_,z) => (x+d12,-x+d12,-z),	//1110
(x,_,z) => (-x+d12,x+d12,z),	//1111
(x,_,z) => (-x+d12,x+d12,-z),	//1112
(x,_,z) => (-x+d12,-x+d12,z),	//1113
(x,_,z) => (x+d12,x+d12,-z+d12),	//1114
(x,_,z) => (x+d12,-x+d12,z+d12),	//1115
(x,_,z) => (x+d12,-x+d12,-z+d12),	//1116
(x,_,z) => (-x+d12,x+d12,z+d12),	//1117
(x,_,z) => (-x+d12,x+d12,-z+d12),	//1118
(x,_,z) => (-x+d12,-x+d12,-z+d12),	//1119
(x,_,_) => (x+d12,x+d14,d38),	//1120
(x,_,_) => (x+d12,x+d14,d58),	//1121
(x,_,_) => (x+d12,-x+d14,d58),	//1122
(x,_,_) => (x+d12,-x+d14,d78),	//1123
(x,_,_) => (x+d12,-x+d14,-x+d34),	//1124
(x,_,_) => (-x+d12,x+d34,d18),	//1125
(x,_,_) => (-x+d12,x+d34,d38),	//1126
(x,_,_) => (-x+d12,-x+d34,d38),	//1127
(x,_,_) => (-x+d12,-x+d34,d58),	//1128
(x,_,_) => (x+d12,-x+d34,-x+d14),	//1129
(x,_,_) => (-x+d12,x+d34,x+d14),	//1130
(x,_,z) => (x+d12,-x+d34,-z+d14),	//1131
(x,_,z) => (-x+d12,x+d34,z+d14),	//1132
(x,y,_) => (x+d12,-y,0),	//1133
(x,y,_) => (-x+d12,y,0),	//1134
(x,y,_) => (x+d12,-y,d12),	//1135
(x,y,_) => (-x+d12,y,d12),	//1136
(x,y,_) => (-x+d12,-y,d12),	//1137
(x,y,_) => (-x+d12,y,d14),	//1138
(x,y,_) => (x+d12,-y,d34),	//1139
(x,y,z) => (x+d12,y,-z),	//1140
(x,y,z) => (x+d12,-y,z),	//1141
(x,y,z) => (x+d12,-y,-z),	//1142
(x,y,z) => (-x+d12,y,z),	//1143
(x,y,z) => (-x+d12,y,-z),	//1144
(x,y,z) => (-x+d12,-y,z),	//1145
(x,y,z) => (x+d12,y,-z+d12),	//1146
(x,y,z) => (x+d12,-y,z+d12),	//1147
(x,y,z) => (x+d12,-y,-z+d12),	//1148
(x,y,z) => (-x+d12,y,z+d12),	//1149
(x,y,z) => (-x+d12,y,-z+d12),	//1150
(x,y,z) => (-x+d12,-y,z+d12),	//1151
(x,y,z) => (-x+d12,-y,-z+d12),	//1152
(x,y,z) => (-x+d12,y,-z+d14),	//1153
(x,y,z) => (x+d12,y,-z+d34),	//1154
(x,y,z) => (x+d12,-y,-z+d34),	//1155
(x,y,z) => (-x+d12,y,-z+d34),	//1156
(x,y,_) => (x+d12,-y+d12,0),	//1157
(x,y,_) => (-x+d12,y+d12,0),	//1158
(x,y,_) => (x+d12,-y+d12,d12),	//1159
(x,y,_) => (-x+d12,y+d12,d12),	//1160
(x,y,_) => (x+d12,-y+d12,d14),	//1161
(x,y,_) => (-x+d12,y+d12,d14),	//1162
(x,y,_) => (x+d12,-y+d12,d34),	//1163
(x,y,_) => (-x+d12,y+d12,d34),	//1164
(x,y,z) => (x+d12,y+d12,-z),	//1165
(x,y,z) => (x+d12,-y+d12,z),	//1166
(x,y,z) => (x+d12,-y+d12,-z),	//1167
(x,y,z) => (-x+d12,y+d12,z),	//1168
(x,y,z) => (-x+d12,y+d12,-z),	//1169
(x,y,z) => (-x+d12,-y+d12,z),	//1170
(x,y,z) => (-x+d12,-y+d12,-z),	//1171
(x,y,z) => (x+d12,y+d12,-z+d12),	//1172
(x,y,z) => (x+d12,-y+d12,z+d12),	//1173
(x,y,z) => (x+d12,-y+d12,-z+d12),	//1174
(x,y,z) => (-x+d12,y+d12,z+d12),	//1175
(x,y,z) => (-x+d12,y+d12,-z+d12),	//1176
(x,y,z) => (-x+d12,-y+d12,z+d12),	//1177
(x,y,z) => (-x+d12,-y+d12,-z+d12),	//1178
(x,y,z) => (x+d12,-y+d12,-z+d14),	//1179
(x,y,z) => (-x+d12,y+d12,-z+d14),	//1180
(x,y,z) => (x+d12,-y+d12,-z+d34),	//1181
(x,y,z) => (-x+d12,y+d12,-z+d34),	//1182
(x,y,z) => (x+d12,-y+d14,-z+d34),	//1183
(x,y,z) => (-x+d12,y+d14,z+d34),	//1184
(x,y,z) => (x+d12,-y+d34,-z+d14),	//1185
(x,y,z) => (-x+d12,y+d34,z+d14),	//1186
(x,_,z) => (x+d12,-z,x+d12),	//1187
(x,_,z) => (x+d12,-z,-x+d12),	//1188
(x,_,z) => (-x+d12,z,-x+d12),	//1189
(x,y,z) => (x+d12,-z,-y),	//1190
(x,y,z) => (-x+d12,z,y),	//1191
(x,y,z) => (-x+d12,z,-y),	//1192
(x,y,z) => (x+d12,-z,y+d12),	//1193
(x,y,z) => (-x+d12,z,-y+d12),	//1194
(x,y,z) => (-x+d12,-z,y+d12),	//1195
(x,_,z) => (x+d12,z+d12,-x),	//1196
(x,_,z) => (-x+d12,z+d12,-x),	//1197
(x,_,z) => (-x+d12,-z+d12,x),	//1198
(x,_,z) => (x+d12,z+d12,-x+d12),	//1199
(x,_,z) => (x+d12,-z+d12,x+d12),	//1200
(x,_,z) => (-x+d12,z+d12,x+d12),	//1201
(x,_,z) => (-x+d12,-z+d12,-x+d12),	//1202
(x,y,z) => (x+d12,z+d12,-y),	//1203
(x,y,z) => (x+d12,-z+d12,-y),	//1204
(x,y,z) => (-x+d12,-z+d12,y),	//1205
(x,y,z) => (x+d12,z+d12,y+d12),	//1206
(x,y,z) => (x+d12,z+d12,-y+d12),	//1207
(x,y,z) => (x+d12,-z+d12,y+d12),	//1208
(x,y,z) => (x+d12,-z+d12,-y+d12),	//1209
(x,y,z) => (-x+d12,z+d12,y+d12),	//1210
(x,y,z) => (-x+d12,z+d12,-y+d12),	//1211
(x,y,z) => (-x+d12,-z+d12,y+d12),	//1212
(x,y,z) => (-x+d12,-z+d12,-y+d12),	//1213
(x,y,z) => (x+d12,-z+d14,-y+d34),	//1214
(x,_,z) => (x+d12,-z+d34,-x+d14),	//1215
(x,_,z) => (-x+d12,z+d34,x+d14),	//1216
(x,y,z) => (-x+d12,z+d34,y+d14),	//1217
(x,_,_) => (-x+d14,0,d14),	//1218
(x,_,_) => (x+d14,d12,d14),	//1219
(x,_,_) => (-x+d14,d12,d34),	//1220
(x,_,_) => (x+d14,d14,d14),	//1221
(x,_,_) => (-x+d14,d14,d14),	//1222
(x,_,_) => (-x+d14,d18,d18),	//1223
(x,_,_) => (x+d14,d38,d78),	//1224
(x,_,_) => (-x+d14,d58,d18),	//1225
(x,_,_) => (-x+d14,d58,d58),	//1226
(x,_,_) => (-x+d14,x,-x+d14),	//1227
(x,_,_) => (x+d14,-x,x+d34),	//1228
(x,_,_) => (x+d14,-x+d12,x+d34),	//1229
(x,_,_) => (-x+d14,x+d12,-x+d34),	//1230
(x,_,z) => (x+d14,-x+d12,z+d34),	//1231
(x,_,z) => (-x+d14,x+d12,-z+d34),	//1232
(x,_,_) => (-x+d14,-x+d14,x),	//1233
(x,_,_) => (x+d14,x+d14,x+d14),	//1234
(x,_,_) => (x+d14,x+d14,-x+d14),	//1235
(x,_,_) => (x+d14,-x+d14,x+d14),	//1236
(x,_,_) => (-x+d14,x+d14,x+d14),	//1237
(x,_,_) => (-x+d14,-x+d14,-x+d14),	//1238
(x,_,_) => (x+d14,-x+d14,x+d34),	//1239
(x,_,z) => (-x+d14,-x+d14,-z+d14),	//1240
(x,_,_) => (-x+d14,-x+d34,x),	//1241
(x,_,_) => (-x+d14,-x+d34,x+d12),	//1242
(x,_,_) => (-x+d14,x+d34,x+d14),	//1243
(x,_,_) => (x+d14,x+d34,-x+d34),	//1244
(x,_,_) => (x+d14,-x+d34,x+d34),	//1245
(x,_,_) => (-x+d14,-x+d34,x+d34),	//1246
(x,_,z) => (x+d14,-x+d34,z+d34),	//1247
(x,y,z) => (x+d14,-y,z+d14),	//1248
(x,y,z) => (-x+d14,y,-z+d14),	//1249
(x,y,z) => (x+d14,-y+d12,z+d34),	//1250
(x,y,z) => (-x+d14,y+d12,-z+d34),	//1251
(x,y,z) => (x+d14,y+d14,-z),	//1252
(x,y,z) => (-x+d14,-y+d14,z),	//1253
(x,y,z) => (x+d14,y+d14,-z+d14),	//1254
(x,y,z) => (x+d14,-y+d14,z+d14),	//1255
(x,y,z) => (-x+d14,y+d14,z+d14),	//1256
(x,y,z) => (-x+d14,-y+d14,-z+d14),	//1257
(x,y,z) => (x+d14,-y+d14,z+d34),	//1258
(x,y,z) => (x+d14,y+d34,-z+d12),	//1259
(x,y,z) => (-x+d14,-y+d34,z+d12),	//1260
(x,y,z) => (-x+d14,y+d34,z+d14),	//1261
(x,y,z) => (x+d14,y+d34,-z+d34),	//1262
(x,y,z) => (x+d14,-z,y+d34),	//1263
(x,_,z) => (x+d14,-z+d12,x+d34),	//1264
(x,_,z) => (-x+d14,z+d12,-x+d34),	//1265
(x,y,z) => (x+d14,-z+d12,y+d34),	//1266
(x,_,z) => (-x+d14,-z+d14,-x+d14),	//1267
(x,y,z) => (x+d14,z+d14,y+d14),	//1268
(x,y,z) => (-x+d14,-z+d14,-y+d14),	//1269
(x,y,z) => (x+d14,-z+d14,y+d34),	//1270
(x,_,z) => (x+d14,-z+d34,x+d34),	//1271
(x,y,z) => (-x+d14,-z+d34,y),	//1272
(x,y,z) => (-x+d14,-z+d34,y+d12),	//1273
(x,y,z) => (-x+d14,z+d34,y+d14),	//1274
(x,y,z) => (x+d14,z+d34,-y+d34),	//1275
(x,y,z) => (x+d14,-z+d34,y+d34),	//1276
(x,y,z) => (-x+d14,-z+d34,y+d34),	//1277
(x,_,_) => (-x+d34,0,d14),	//1278
(x,_,_) => (x+d34,0,d34),	//1279
(x,_,_) => (x+d34,d12,d14),	//1280
(x,_,_) => (x+d34,d14,d14),	//1281
(x,_,_) => (x+d34,d14,d34),	//1282
(x,_,_) => (-x+d34,d18,d58),	//1283
(x,_,_) => (-x+d34,d34,d14),	//1284
(x,_,_) => (-x+d34,d34,d34),	//1285
(x,_,_) => (x+d34,d38,d38),	//1286
(x,_,_) => (x+d34,d38,d78),	//1287
(x,_,_) => (-x+d34,d58,d18),	//1288
(x,_,_) => (x+d34,d78,d78),	//1289
(x,_,_) => (-x+d34,x,-x+d14),	//1290
(x,_,_) => (x+d34,-x,x+d34),	//1291
(x,_,_) => (-x+d34,x+d12,-x+d14),	//1292
(x,_,_) => (x+d34,x+d14,-x),	//1293
(x,_,_) => (x+d34,x+d14,-x+d12),	//1294
(x,_,_) => (-x+d34,-x+d14,x+d12),	//1295
(x,_,_) => (x+d34,x+d14,-x+d14),	//1296
(x,_,_) => (x+d34,x+d14,-x+d34),	//1297
(x,_,_) => (x+d34,-x+d14,-x+d34),	//1298
(x,_,_) => (-x+d34,x+d14,x+d34),	//1299
(x,_,z) => (x+d34,x+d14,-z+d12),	//1300
(x,_,z) => (-x+d34,-x+d14,z+d12),	//1301
(x,_,z) => (x+d34,x+d14,-z+d34),	//1302
(x,_,_) => (x+d34,x+d34,-x),	//1303
(x,_,_) => (x+d34,-x+d34,x+d14),	//1304
(x,_,_) => (-x+d34,x+d34,x+d14),	//1305
(x,_,_) => (-x+d34,x+d34,-x+d14),	//1306
(x,_,_) => (-x+d34,-x+d34,-x+d34),	//1307
(x,_,z) => (-x+d34,x+d34,z+d14),	//1308
(x,y,z) => (x+d34,-y,z+d34),	//1309
(x,y,z) => (-x+d34,y,-z+d34),	//1310
(x,y,z) => (x+d34,-y+d12,z+d14),	//1311
(x,y,z) => (-x+d34,y+d12,-z+d14),	//1312
(x,y,z) => (x+d34,y+d14,-z+d12),	//1313
(x,y,z) => (-x+d34,-y+d14,z+d12),	//1314
(x,y,z) => (x+d34,y+d14,-z+d14),	//1315
(x,y,z) => (-x+d34,y+d14,z+d34),	//1316
(x,y,z) => (x+d34,y+d34,-z),	//1317
(x,y,z) => (-x+d34,-y+d34,z),	//1318
(x,y,z) => (x+d34,-y+d34,z+d14),	//1319
(x,y,z) => (-x+d34,-y+d34,-z+d34),	//1320
(x,y,z) => (-x+d34,z,-y+d14),	//1321
(x,y,z) => (-x+d34,z+d12,-y+d14),	//1322
(x,_,z) => (x+d34,z+d14,-x+d12),	//1323
(x,_,z) => (-x+d34,-z+d14,x+d12),	//1324
(x,_,z) => (x+d34,z+d14,-x+d34),	//1325
(x,y,z) => (x+d34,z+d14,-y),	//1326
(x,y,z) => (x+d34,z+d14,-y+d12),	//1327
(x,y,z) => (x+d34,z+d14,-y+d14),	//1328
(x,y,z) => (x+d34,z+d14,-y+d34),	//1329
(x,y,z) => (x+d34,-z+d14,-y+d34),	//1330
(x,y,z) => (-x+d34,z+d14,y+d34),	//1331
(x,_,z) => (-x+d34,z+d34,x+d14),	//1332
(x,y,z) => (x+d34,-z+d34,y+d14),	//1333
(x,y,z) => (-x+d34,z+d34,y+d14),	//1334
(x,y,z) => (-x+d34,z+d34,-y+d14),	//1335
(x,y,z) => (-x+d34,-z+d34,-y+d34),	//1336
(x,y,_) => (-x+y,-x,0),	//1337
(x,y,_) => (-x+y,-x,d12),	//1338
(x,y,_) => (-x+y,-x,d14),	//1339
(x,y,z) => (-x+y,-x,z),	//1340
(x,y,z) => (-x+y,-x,-z),	//1341
(x,y,z) => (-x+y,-x,-z+d12),	//1342
(x,y,z) => (-x+y,-x,z+d13),	//1343
(x,y,z) => (-x+y,-x,z+d23),	//1344
(x,y,_) => (-x+y,y,0),	//1345
(x,y,_) => (-x+y,y,d12),	//1346
(x,y,_) => (-x+y,y,d14),	//1347
(x,y,_) => (-x+y,y,d34),	//1348
(x,y,z) => (-x+y,y,z),	//1349
(x,y,z) => (-x+y,y,-z),	//1350
(x,y,z) => (-x+y,y,z+d12),	//1351
(x,y,z) => (-x+y,y,-z+d12),	//1352
(x,y,z) => (-x+y,y,-z+d13),	//1353
(x,y,z) => (-x+y,y,-z+d23),	//1354
(x,y,_) => (x-y,x,0),	//1355
(x,y,_) => (x-y,x,d12),	//1356
(x,y,_) => (x-y,x,d34),	//1357
(x,y,z) => (x-y,x,z),	//1358
(x,y,z) => (x-y,x,-z),	//1359
(x,y,z) => (x-y,x,z+d12),	//1360
(x,y,z) => (x-y,x,z+d13),	//1361
(x,y,z) => (x-y,x,z+d16),	//1362
(x,y,z) => (x-y,x,z+d23),	//1363
(x,y,z) => (x-y,x,z+d56),	//1364
(x,y,_) => (x-y,-y,0),	//1365
(x,y,_) => (x-y,-y,d12),	//1366
(x,y,_) => (x-y,-y,d14),	//1367
(x,y,_) => (x-y,-y,d34),	//1368
(x,y,z) => (x-y,-y,z),	//1369
(x,y,z) => (x-y,-y,-z),	//1370
(x,y,z) => (x-y,-y,z+d12),	//1371
(x,y,z) => (x-y,-y,-z+d12),	//1372
(x,y,z) => (x-y,-y,-z+d13),	//1373
(x,y,z) => (x-y,-y,-z+d23),	//1374
(_,y,_) => (y,0,d14),	//1375
(_,y,_) => (-y,0,d14),	//1376
(_,y,_) => (y,0,d34),	//1377
(_,y,_) => (-y,0,d34),	//1378
(_,y,_) => (y,0,y),	//1379
(_,y,_) => (y,0,-y),	//1380
(_,y,_) => (-y,0,y),	//1381
(_,y,_) => (-y,0,-y),	//1382
(_,y,_) => (y,0,y+d12),	//1383
(_,y,_) => (-y,0,-y+d12),	//1384
(_,y,z) => (y,0,z),	//1385
(_,y,z) => (y,0,-z),	//1386
(_,y,z) => (-y,0,z),	//1387
(_,y,z) => (-y,0,-z),	//1388
(_,y,z) => (y,0,z+d12),	//1389
(_,y,z) => (y,0,-z+d12),	//1390
(_,y,z) => (-y,0,z+d12),	//1391
(_,y,z) => (-y,0,-z+d12),	//1392
(_,y,_) => (y,d12,d14),	//1393
(_,y,_) => (-y,d12,d14),	//1394
(_,y,_) => (y,d12,d34),	//1395
(_,y,_) => (-y,d12,d34),	//1396
(_,y,_) => (y,d12,y),	//1397
(_,y,_) => (y,d12,-y),	//1398
(_,y,_) => (-y,d12,y),	//1399
(_,y,_) => (-y,d12,-y),	//1400
(_,y,_) => (y,d12,y+d12),	//1401
(_,y,_) => (-y,d12,-y+d12),	//1402
(_,y,z) => (y,d12,z),	//1403
(_,y,z) => (y,d12,-z),	//1404
(_,y,z) => (-y,d12,z),	//1405
(_,y,z) => (-y,d12,-z),	//1406
(_,y,z) => (y,d12,z+d12),	//1407
(_,y,z) => (y,d12,-z+d12),	//1408
(_,y,z) => (-y,d12,z+d12),	//1409
(_,y,z) => (-y,d12,-z+d12),	//1410
(_,y,z) => (-y,d12,z+d14),	//1411
(_,y,_) => (y,d14,y),	//1412
(_,y,_) => (y,d14,-y),	//1413
(_,y,_) => (-y,d14,y),	//1414
(_,y,_) => (-y,d14,-y),	//1415
(_,y,_) => (y,d14,y+d12),	//1416
(_,y,_) => (y,d14,-y+d12),	//1417
(_,y,_) => (-y,d14,y+d12),	//1418
(_,y,_) => (-y,d14,-y+d12),	//1419
(_,y,z) => (y,d14,z),	//1420
(_,y,z) => (y,d14,z+d12),	//1421
(_,y,_) => (y,d18,-y+d14),	//1422
(_,y,_) => (-y,d34,d38),	//1423
(_,y,_) => (y,d34,d78),	//1424
(_,y,_) => (y,d34,y),	//1425
(_,y,_) => (y,d34,-y),	//1426
(_,y,_) => (-y,d34,y),	//1427
(_,y,_) => (-y,d34,-y),	//1428
(_,y,_) => (y,d34,y+d12),	//1429
(_,y,_) => (y,d34,-y+d12),	//1430
(_,y,_) => (-y,d34,y+d12),	//1431
(_,y,_) => (-y,d34,-y+d12),	//1432
(_,y,z) => (-y,d34,-z),	//1433
(_,y,z) => (-y,d34,-z+d12),	//1434
(_,y,_) => (-y,d38,-y+d14),	//1435
(_,y,_) => (-y,d58,y+d14),	//1436
(_,y,_) => (y,d78,y+d14),	//1437
(x,y,_) => (y,x,0),	//1438
(x,y,_) => (y,-x,0),	//1439
(x,y,_) => (-y,x,0),	//1440
(x,y,_) => (-y,-x,0),	//1441
(x,y,_) => (y,x,d12),	//1442
(x,y,_) => (y,-x,d12),	//1443
(x,y,_) => (-y,x,d12),	//1444
(x,y,_) => (-y,-x,d12),	//1445
(x,y,_) => (y,x,d14),	//1446
(x,y,_) => (-y,-x,d14),	//1447
(x,y,_) => (y,x,d34),	//1448
(x,y,_) => (-y,-x,d34),	//1449
(x,y,z) => (y,x,z),	//1450
(x,y,z) => (y,x,-z),	//1451
(x,y,z) => (y,-x,z),	//1452
(x,y,z) => (y,-x,-z),	//1453
(x,y,z) => (-y,x,z),	//1454
(x,y,z) => (-y,x,-z),	//1455
(x,y,z) => (-y,-x,z),	//1456
(x,y,z) => (-y,-x,-z),	//1457
(x,y,z) => (y,x,z+d12),	//1458
(x,y,z) => (y,x,-z+d12),	//1459
(x,y,z) => (y,-x,z+d12),	//1460
(x,y,z) => (y,-x,-z+d12),	//1461
(x,y,z) => (-y,x,z+d12),	//1462
(x,y,z) => (-y,x,-z+d12),	//1463
(x,y,z) => (-y,-x,z+d12),	//1464
(x,y,z) => (-y,-x,-z+d12),	//1465
(x,y,z) => (y,x,-z+d13),	//1466
(x,y,z) => (-y,-x,-z+d13),	//1467
(x,y,z) => (y,x,-z+d14),	//1468
(x,y,z) => (y,-x,z+d14),	//1469
(x,y,z) => (-y,x,z+d14),	//1470
(x,y,z) => (-y,-x,-z+d14),	//1471
(x,y,z) => (-y,-x,-z+d16),	//1472
(x,y,z) => (y,x,-z+d23),	//1473
(x,y,z) => (-y,-x,-z+d23),	//1474
(x,y,z) => (y,x,-z+d34),	//1475
(x,y,z) => (y,-x,z+d34),	//1476
(x,y,z) => (-y,x,z+d34),	//1477
(x,y,z) => (-y,-x,-z+d34),	//1478
(x,y,z) => (-y,-x,-z+d56),	//1479
(x,y,z) => (y,-x+d12,z),	//1480
(x,y,z) => (-y,x+d12,-z),	//1481
(x,y,z) => (-y,-x+d12,z),	//1482
(x,y,z) => (y,-x+d12,z+d12),	//1483
(x,y,z) => (y,-x+d12,-z+d12),	//1484
(x,y,z) => (-y,x+d12,z+d12),	//1485
(x,y,z) => (-y,x+d12,-z+d12),	//1486
(x,y,z) => (y,x+d12,z+d14),	//1487
(x,y,z) => (-y,x+d12,z+d14),	//1488
(x,y,z) => (-y,-x+d12,z+d14),	//1489
(x,y,z) => (y,x+d12,z+d34),	//1490
(x,y,z) => (-y,-x+d12,z+d34),	//1491
(x,y,z) => (y,-x+d14,-z+d34),	//1492
(x,y,z) => (-y,x+d34,z+d14),	//1493
(x,y,_) => (y,-x+y,0),	//1494
(x,y,_) => (y,-x+y,d12),	//1495
(x,y,_) => (y,-x+y,d34),	//1496
(x,y,z) => (y,-x+y,z),	//1497
(x,y,z) => (y,-x+y,-z),	//1498
(x,y,z) => (y,-x+y,z+d12),	//1499
(x,y,z) => (y,-x+y,z+d13),	//1500
(x,y,z) => (y,-x+y,z+d16),	//1501
(x,y,z) => (y,-x+y,z+d23),	//1502
(x,y,z) => (y,-x+y,z+d56),	//1503
(x,y,_) => (-y,x-y,0),	//1504
(x,y,_) => (-y,x-y,d12),	//1505
(x,y,_) => (-y,x-y,d14),	//1506
(x,y,z) => (-y,x-y,z),	//1507
(x,y,z) => (-y,x-y,-z),	//1508
(x,y,z) => (-y,x-y,-z+d12),	//1509
(x,y,z) => (-y,x-y,z+d13),	//1510
(x,y,z) => (-y,x-y,z+d23),	//1511
(_,y,_) => (y,y,0),	//1512
(_,y,_) => (y,-y,0),	//1513
(_,y,_) => (-y,y,0),	//1514
(_,y,_) => (-y,-y,0),	//1515
(_,y,_) => (y,y,d12),	//1516
(_,y,_) => (y,-y,d12),	//1517
(_,y,_) => (-y,y,d12),	//1518
(_,y,_) => (-y,-y,d12),	//1519
(_,y,_) => (y,y,d14),	//1520
(_,y,_) => (y,-y,d14),	//1521
(_,y,_) => (-y,y,d14),	//1522
(_,y,_) => (-y,-y,d14),	//1523
(_,y,_) => (y,y,d34),	//1524
(_,y,_) => (y,-y,d34),	//1525
(_,y,_) => (-y,y,d34),	//1526
(_,y,_) => (-y,-y,d34),	//1527
(_,y,_) => (y,y+d12,0),	//1528
(_,y,_) => (-y,-y+d12,0),	//1529
(_,y,_) => (y,y+d12,d12),	//1530
(_,y,_) => (-y,-y+d12,d12),	//1531
(_,y,_) => (y,y+d12,d14),	//1532
(_,y,_) => (y,-y+d12,d14),	//1533
(_,y,_) => (-y,y+d12,d14),	//1534
(_,y,_) => (-y,-y+d12,d14),	//1535
(_,y,_) => (y,y+d12,d34),	//1536
(_,y,_) => (y,-y+d12,d34),	//1537
(_,y,_) => (-y,y+d12,d34),	//1538
(_,y,_) => (-y,-y+d12,d34),	//1539
(_,y,_) => (y,y+d14,d18),	//1540
(_,y,_) => (y,-y+d14,d18),	//1541
(_,y,_) => (y,y+d14,d58),	//1542
(_,y,_) => (-y,y+d14,d58),	//1543
(_,y,_) => (-y,y+d34,d38),	//1544
(_,y,_) => (-y,-y+d34,d38),	//1545
(_,y,_) => (-y,y+d34,d78),	//1546
(_,y,z) => (y,z,0),	//1547
(_,y,z) => (y,-z,0),	//1548
(_,y,z) => (-y,z,0),	//1549
(_,y,z) => (-y,-z,0),	//1550
(_,y,z) => (y,z,d12),	//1551
(_,y,z) => (y,-z,d12),	//1552
(_,y,z) => (-y,z,d12),	//1553
(_,y,z) => (-y,-z,d12),	//1554
(x,y,z) => (y,z,x),	//1555
(x,y,z) => (y,z,-x),	//1556
(x,y,z) => (y,-z,x),	//1557
(x,y,z) => (y,-z,-x),	//1558
(x,y,z) => (-y,z,x),	//1559
(x,y,z) => (-y,z,-x),	//1560
(x,y,z) => (-y,-z,x),	//1561
(x,y,z) => (-y,-z,-x),	//1562
(x,y,z) => (y,-z+d12,x+d12),	//1563
(x,y,z) => (y,-z+d12,-x+d12),	//1564
(x,y,z) => (-y,z+d12,x+d12),	//1565
(x,y,z) => (-y,z+d12,-x+d12),	//1566
(x,y,z) => (-y,-z+d12,x+d12),	//1567
(x,y,z) => (y,-z+d14,-x+d14),	//1568
(x,y,z) => (-y,z+d34,x+d34),	//1569
(_,y,_) => (y+d12,0,y),	//1570
(_,y,_) => (-y+d12,0,-y),	//1571
(_,y,_) => (y+d12,0,-y+d12),	//1572
(_,y,_) => (-y+d12,0,y+d12),	//1573
(_,y,_) => (y+d12,0,y+d14),	//1574
(_,y,_) => (-y+d12,0,-y+d34),	//1575
(_,y,z) => (y+d12,0,z+d34),	//1576
(_,y,_) => (y+d12,d12,y),	//1577
(_,y,_) => (-y+d12,d12,-y),	//1578
(_,y,_) => (y+d12,d12,y+d12),	//1579
(_,y,_) => (y+d12,d12,-y+d12),	//1580
(_,y,_) => (-y+d12,d12,y+d12),	//1581
(_,y,_) => (-y+d12,d12,-y+d12),	//1582
(_,y,z) => (y+d12,d12,z),	//1583
(_,y,z) => (-y+d12,d12,z),	//1584
(_,y,z) => (y+d12,d12,z+d12),	//1585
(_,y,z) => (y+d12,d12,-z+d12),	//1586
(_,y,z) => (-y+d12,d12,z+d12),	//1587
(_,y,z) => (-y+d12,d12,-z+d12),	//1588
(_,y,_) => (y+d12,d14,y),	//1589
(_,y,_) => (y+d12,d14,-y),	//1590
(_,y,_) => (-y+d12,d14,y),	//1591
(_,y,_) => (-y+d12,d14,-y),	//1592
(_,y,_) => (-y+d12,d14,-y+d12),	//1593
(_,y,_) => (y+d12,d14,y+d34),	//1594
(_,y,z) => (-y+d12,d14,z),	//1595
(_,y,z) => (-y+d12,d14,z+d12),	//1596
(_,y,_) => (-y+d12,d18,y+d34),	//1597
(_,y,_) => (-y+d12,d34,d38),	//1598
(_,y,_) => (y+d12,d34,d78),	//1599
(_,y,_) => (y+d12,d34,y),	//1600
(_,y,_) => (y+d12,d34,-y),	//1601
(_,y,_) => (-y+d12,d34,y),	//1602
(_,y,_) => (-y+d12,d34,-y),	//1603
(_,y,_) => (y+d12,d34,y+d12),	//1604
(_,y,_) => (-y+d12,d34,-y+d14),	//1605
(_,y,z) => (y+d12,d34,-z),	//1606
(_,y,z) => (y+d12,d34,-z+d12),	//1607
(_,y,_) => (y+d12,d38,y+d34),	//1608
(_,y,_) => (y+d12,d58,-y+d34),	//1609
(_,y,_) => (-y+d12,d78,-y+d34),	//1610
(x,y,z) => (y+d12,-x,-z),	//1611
(x,y,z) => (-y+d12,x,z),	//1612
(x,y,z) => (-y+d12,x,-z),	//1613
(x,y,z) => (y+d12,-x,z+d12),	//1614
(x,y,z) => (y+d12,-x,-z+d12),	//1615
(x,y,z) => (-y+d12,x,z+d12),	//1616
(x,y,z) => (-y+d12,x,-z+d12),	//1617
(x,y,z) => (-y+d12,-x,z+d12),	//1618
(x,y,z) => (y+d12,x,z+d14),	//1619
(x,y,z) => (-y+d12,-x,z+d14),	//1620
(x,y,z) => (y+d12,x,z+d34),	//1621
(x,y,z) => (y+d12,-x,z+d34),	//1622
(x,y,z) => (-y+d12,-x,z+d34),	//1623
(x,y,_) => (y+d12,x+d12,0),	//1624
(x,y,_) => (-y+d12,-x+d12,0),	//1625
(x,y,_) => (y+d12,x+d12,d12),	//1626
(x,y,_) => (y+d12,-x+d12,d12),	//1627
(x,y,_) => (-y+d12,x+d12,d12),	//1628
(x,y,_) => (-y+d12,-x+d12,d12),	//1629
(x,y,z) => (y+d12,x+d12,z),	//1630
(x,y,z) => (y+d12,x+d12,-z),	//1631
(x,y,z) => (y+d12,-x+d12,z),	//1632
(x,y,z) => (y+d12,-x+d12,-z),	//1633
(x,y,z) => (-y+d12,x+d12,z),	//1634
(x,y,z) => (-y+d12,x+d12,-z),	//1635
(x,y,z) => (-y+d12,-x+d12,z),	//1636
(x,y,z) => (-y+d12,-x+d12,-z),	//1637
(x,y,z) => (y+d12,x+d12,z+d12),	//1638
(x,y,z) => (y+d12,x+d12,-z+d12),	//1639
(x,y,z) => (y+d12,-x+d12,z+d12),	//1640
(x,y,z) => (y+d12,-x+d12,-z+d12),	//1641
(x,y,z) => (-y+d12,x+d12,z+d12),	//1642
(x,y,z) => (-y+d12,x+d12,-z+d12),	//1643
(x,y,z) => (-y+d12,-x+d12,z+d12),	//1644
(x,y,z) => (-y+d12,-x+d12,-z+d12),	//1645
(x,y,z) => (y+d12,-x+d12,z+d14),	//1646
(x,y,z) => (-y+d12,x+d12,z+d14),	//1647
(x,y,z) => (y+d12,-x+d12,z+d34),	//1648
(x,y,z) => (-y+d12,x+d12,z+d34),	//1649
(x,y,z) => (y+d12,-x+d14,-z+d34),	//1650
(x,y,z) => (-y+d12,x+d34,z+d14),	//1651
(_,y,_) => (y+d12,y,0),	//1652
(_,y,_) => (-y+d12,-y,0),	//1653
(_,y,_) => (y+d12,y,d12),	//1654
(_,y,_) => (-y+d12,-y,d12),	//1655
(_,y,_) => (y+d12,y,d14),	//1656
(_,y,_) => (y+d12,-y,d14),	//1657
(_,y,_) => (-y+d12,y,d14),	//1658
(_,y,_) => (-y+d12,-y,d14),	//1659
(_,y,_) => (y+d12,y,d34),	//1660
(_,y,_) => (y+d12,-y,d34),	//1661
(_,y,_) => (-y+d12,y,d34),	//1662
(_,y,_) => (-y+d12,-y,d34),	//1663
(_,y,_) => (y+d12,-y+d12,0),	//1664
(_,y,_) => (-y+d12,y+d12,0),	//1665
(_,y,_) => (y+d12,y+d12,d12),	//1666
(_,y,_) => (y+d12,-y+d12,d12),	//1667
(_,y,_) => (-y+d12,y+d12,d12),	//1668
(_,y,_) => (-y+d12,-y+d12,d12),	//1669
(_,y,_) => (-y+d12,-y+d12,d14),	//1670
(_,y,_) => (y+d12,y+d12,d34),	//1671
(_,y,_) => (y+d12,y+d14,d12),	//1672
(_,y,_) => (-y+d12,-y+d14,d34),	//1673
(_,y,_) => (y+d12,-y+d14,d38),	//1674
(_,y,_) => (y+d12,y+d14,d78),	//1675
(_,y,_) => (y+d12,-y+d14,d78),	//1676
(_,y,_) => (-y+d12,-y+d34,d12),	//1677
(_,y,_) => (y+d12,y+d34,d14),	//1678
(_,y,_) => (-y+d12,-y+d34,d18),	//1679
(_,y,_) => (y+d12,y+d34,d38),	//1680
(_,y,_) => (-y+d12,y+d34,d58),	//1681
(_,y,_) => (-y+d12,-y+d34,d58),	//1682
(_,y,_) => (-y+d12,-y+d34,d78),	//1683
(x,y,z) => (y+d12,z,-x+d12),	//1684
(x,y,z) => (y+d12,-z,x+d12),	//1685
(x,y,z) => (y+d12,-z,-x+d12),	//1686
(x,y,z) => (-y+d12,z,-x+d12),	//1687
(x,y,z) => (-y+d12,-z,x+d12),	//1688
(x,y,z) => (y+d12,z+d12,-x),	//1689
(x,y,z) => (y+d12,-z+d12,-x),	//1690
(x,y,z) => (-y+d12,z+d12,x),	//1691
(x,y,z) => (-y+d12,z+d12,-x),	//1692
(x,y,z) => (-y+d12,-z+d12,x),	//1693
(x,y,z) => (y+d12,z+d12,-x+d12),	//1694
(x,y,z) => (y+d12,-z+d12,x+d12),	//1695
(x,y,z) => (-y+d12,z+d12,x+d12),	//1696
(x,y,z) => (-y+d12,-z+d12,-x+d12),	//1697
(x,y,z) => (y+d12,-z+d14,-x+d34),	//1698
(x,y,z) => (-y+d12,z+d14,x+d34),	//1699
(x,y,z) => (y+d12,-z+d34,-x+d14),	//1700
(x,y,z) => (-y+d12,z+d34,x+d14),	//1701
(_,y,_) => (y+d14,d12,y+d12),	//1702
(_,y,_) => (y+d14,d12,-y+d34),	//1703
(_,y,_) => (-y+d14,d14,y+d34),	//1704
(_,y,z) => (y+d14,d14,z+d34),	//1705
(_,y,z) => (-y+d14,d14,-z+d34),	//1706
(_,y,_) => (y+d14,d18,y),	//1707
(_,y,_) => (-y+d14,d18,y),	//1708
(_,y,_) => (-y+d14,d34,-y+d12),	//1709
(_,y,z) => (y+d14,d34,-z+d14),	//1710
(_,y,z) => (-y+d14,d34,z+d14),	//1711
(_,y,_) => (-y+d14,d38,y+d12),	//1712
(_,y,_) => (y+d14,d58,y),	//1713
(_,y,_) => (y+d14,d58,-y),	//1714
(_,y,_) => (y+d14,d78,y+d12),	//1715
(_,y,_) => (-y+d14,d78,y+d12),	//1716
(x,y,z) => (y+d14,-x,z+d34),	//1717
(x,y,z) => (y+d14,-x+d12,z+d34),	//1718
(x,y,z) => (y+d14,x+d14,z+d14),	//1719
(x,y,z) => (-y+d14,x+d14,-z+d14),	//1720
(x,y,z) => (-y+d14,-x+d14,-z+d14),	//1721
(x,y,z) => (y+d14,-x+d14,z+d34),	//1722
(x,y,z) => (-y+d14,-x+d14,-z+d34),	//1723
(x,y,z) => (-y+d14,-x+d34,z),	//1724
(x,y,z) => (-y+d14,-x+d34,z+d12),	//1725
(x,y,z) => (y+d14,x+d34,-z+d14),	//1726
(x,y,z) => (-y+d14,x+d34,z+d14),	//1727
(x,y,z) => (y+d14,x+d34,-z+d34),	//1728
(x,y,z) => (y+d14,-x+d34,z+d34),	//1729
(x,y,z) => (y+d14,-x+d34,-z+d34),	//1730
(x,y,z) => (-y+d14,-x+d34,z+d34),	//1731
(_,y,_) => (-y+d14,y,d18),	//1732
(_,y,_) => (-y+d14,-y,d38),	//1733
(_,y,_) => (y+d14,-y,d58),	//1734
(_,y,_) => (y+d14,y,d78),	//1735
(_,y,_) => (y+d14,y+d12,0),	//1736
(_,y,_) => (-y+d14,-y+d12,d34),	//1737
(_,y,_) => (y+d14,-y+d34,d12),	//1738
(_,y,_) => (-y+d14,y+d34,d34),	//1739
(x,y,z) => (-y+d14,z,-x+d14),	//1740
(x,y,z) => (y+d14,-z+d12,x+d34),	//1741
(x,y,z) => (-y+d14,z+d12,-x+d34),	//1742
(x,y,z) => (-y+d14,-z+d14,x),	//1743
(x,y,z) => (y+d14,z+d14,-x+d14),	//1744
(x,y,z) => (y+d14,-z+d14,x+d14),	//1745
(x,y,z) => (-y+d14,z+d14,x+d14),	//1746
(x,y,z) => (-y+d14,-z+d14,-x+d14),	//1747
(x,y,z) => (y+d14,-z+d14,x+d34),	//1748
(x,y,z) => (y+d14,z+d34,-x+d12),	//1749
(x,y,z) => (-y+d14,-z+d34,x+d12),	//1750
(x,y,z) => (-y+d14,z+d34,x+d14),	//1751
(x,y,z) => (y+d14,z+d34,-x+d34),	//1752
(_,y,_) => (-y+d34,d12,-y+d12),	//1753
(_,y,_) => (-y+d34,d12,y+d14),	//1754
(_,y,_) => (y+d34,d14,y+d12),	//1755
(_,y,_) => (-y+d34,d18,-y+d12),	//1756
(_,y,_) => (y+d34,d34,-y+d14),	//1757
(_,y,_) => (y+d34,d38,-y),	//1758
(_,y,_) => (-y+d34,d38,-y),	//1759
(_,y,_) => (y+d34,d38,y+d12),	//1760
(_,y,_) => (y+d34,d58,-y+d12),	//1761
(_,y,_) => (-y+d34,d58,-y+d12),	//1762
(_,y,_) => (y+d34,d78,-y),	//1763
(_,y,_) => (-y+d34,d78,-y+d12),	//1764
(x,y,z) => (-y+d34,x,-z+d14),	//1765
(x,y,z) => (-y+d34,x+d12,-z+d14),	//1766
(x,y,z) => (y+d34,x+d14,-z),	//1767
(x,y,z) => (y+d34,x+d14,-z+d12),	//1768
(x,y,z) => (y+d34,x+d14,-z+d14),	//1769
(x,y,z) => (-y+d34,x+d14,z+d14),	//1770
(x,y,z) => (-y+d34,-x+d14,z+d14),	//1771
(x,y,z) => (y+d34,x+d14,-z+d34),	//1772
(x,y,z) => (y+d34,-x+d14,-z+d34),	//1773
(x,y,z) => (-y+d34,x+d14,z+d34),	//1774
(x,y,z) => (-y+d34,-x+d14,z+d34),	//1775
(x,y,z) => (y+d34,x+d34,z+d14),	//1776
(x,y,z) => (y+d34,-x+d34,z+d14),	//1777
(x,y,z) => (-y+d34,x+d34,z+d14),	//1778
(x,y,z) => (-y+d34,x+d34,-z+d14),	//1779
(x,y,z) => (y+d34,x+d34,z+d34),	//1780
(x,y,z) => (y+d34,-x+d34,z+d34),	//1781
(x,y,z) => (-y+d34,-x+d34,-z+d34),	//1782
(_,y,_) => (-y+d34,-y+d12,0),	//1783
(_,y,_) => (y+d34,y+d12,d14),	//1784
(_,y,_) => (y+d34,-y+d12,d18),	//1785
(_,y,_) => (y+d34,y+d12,d38),	//1786
(_,y,_) => (-y+d34,y+d12,d58),	//1787
(_,y,_) => (-y+d34,-y+d12,d78),	//1788
(_,y,_) => (-y+d34,y+d14,d12),	//1789
(_,y,_) => (y+d34,-y+d14,d14),	//1790
(x,y,z) => (y+d34,-z,x+d34),	//1791
(x,y,z) => (y+d34,-z+d12,x+d14),	//1792
(x,y,z) => (-y+d34,z+d12,-x+d14),	//1793
(x,y,z) => (y+d34,z+d14,-x+d12),	//1794
(x,y,z) => (-y+d34,-z+d14,x+d12),	//1795
(x,y,z) => (y+d34,z+d14,-x+d14),	//1796
(x,y,z) => (-y+d34,z+d14,x+d34),	//1797
(x,y,z) => (y+d34,z+d34,-x),	//1798
(x,y,z) => (y+d34,-z+d34,x+d14),	//1799
(x,y,z) => (-y+d34,-z+d34,-x+d34),	//1800
(_,y,z) => (z,0,y),	//1801
(_,y,z) => (z,0,-y),	//1802
(_,y,z) => (-z,0,y),	//1803
(_,y,z) => (-z,0,-y),	//1804
(_,y,z) => (z,d12,y),	//1805
(_,y,z) => (z,d12,-y),	//1806
(_,y,z) => (-z,d12,y),	//1807
(_,y,z) => (-z,d12,-y),	//1808
(x,_,z) => (z,x,x),	//1809
(x,_,z) => (z,x,-x),	//1810
(x,_,z) => (z,-x,x),	//1811
(x,_,z) => (z,-x,-x),	//1812
(x,_,z) => (-z,x,x),	//1813
(x,_,z) => (-z,x,-x),	//1814
(x,_,z) => (-z,-x,x),	//1815
(x,_,z) => (-z,-x,-x),	//1816
(x,y,z) => (z,x,y),	//1817
(x,y,z) => (z,x,-y),	//1818
(x,y,z) => (z,-x,y),	//1819
(x,y,z) => (z,-x,-y),	//1820
(x,y,z) => (-z,x,y),	//1821
(x,y,z) => (-z,x,-y),	//1822
(x,y,z) => (-z,-x,y),	//1823
(x,y,z) => (-z,-x,-y),	//1824
(x,_,z) => (z,-x+d12,-x+d12),	//1825
(x,_,z) => (-z,x+d12,x+d12),	//1826
(x,_,z) => (-z,-x+d12,x+d12),	//1827
(x,y,z) => (z,-x+d12,y+d12),	//1828
(x,y,z) => (z,-x+d12,-y+d12),	//1829
(x,y,z) => (-z,x+d12,y+d12),	//1830
(x,y,z) => (-z,x+d12,-y+d12),	//1831
(x,y,z) => (-z,-x+d12,y+d12),	//1832
(x,y,z) => (z,-x+d14,-y+d14),	//1833
(x,y,z) => (-z,x+d34,y+d34),	//1834
(_,y,z) => (z,y,0),	//1835
(_,y,z) => (z,-y,0),	//1836
(_,y,z) => (-z,y,0),	//1837
(_,y,z) => (-z,-y,0),	//1838
(_,y,z) => (z,y,d12),	//1839
(_,y,z) => (z,-y,d12),	//1840
(_,y,z) => (-z,y,d12),	//1841
(_,y,z) => (-z,-y,d12),	//1842
(x,y,z) => (z,y,x),	//1843
(x,y,z) => (z,y,-x),	//1844
(x,y,z) => (z,-y,x),	//1845
(x,y,z) => (z,-y,-x),	//1846
(x,y,z) => (-z,y,x),	//1847
(x,y,z) => (-z,y,-x),	//1848
(x,y,z) => (-z,-y,x),	//1849
(x,y,z) => (-z,-y,-x),	//1850
(x,y,z) => (z,y,-x+d12),	//1851
(x,y,z) => (z,-y,-x+d12),	//1852
(x,y,z) => (-z,-y,x+d12),	//1853
(x,y,z) => (z,-y+d12,x),	//1854
(x,y,z) => (-z,y+d12,-x),	//1855
(x,y,z) => (-z,-y+d12,x),	//1856
(x,y,z) => (z,-y+d12,-x+d12),	//1857
(x,y,z) => (-z,y+d12,x+d12),	//1858
(x,y,z) => (-z,y+d12,-x+d12),	//1859
(x,y,z) => (z,-y+d14,-x+d34),	//1860
(x,y,z) => (-z,y+d34,x+d14),	//1861
(x,_,z) => (z+d12,-x,x+d12),	//1862
(x,_,z) => (z+d12,-x,-x+d12),	//1863
(x,_,z) => (-z+d12,x,-x+d12),	//1864
(x,y,z) => (z+d12,x,-y+d12),	//1865
(x,y,z) => (z+d12,-x,y+d12),	//1866
(x,y,z) => (z+d12,-x,-y+d12),	//1867
(x,y,z) => (-z+d12,x,-y+d12),	//1868
(x,y,z) => (-z+d12,-x,y+d12),	//1869
(x,_,z) => (z+d12,x+d12,-x),	//1870
(x,_,z) => (-z+d12,x+d12,-x),	//1871
(x,_,z) => (-z+d12,-x+d12,x),	//1872
(x,_,z) => (z+d12,x+d12,-x+d12),	//1873
(x,_,z) => (z+d12,-x+d12,x+d12),	//1874
(x,_,z) => (-z+d12,x+d12,x+d12),	//1875
(x,_,z) => (-z+d12,-x+d12,-x+d12),	//1876
(x,y,z) => (z+d12,x+d12,-y),	//1877
(x,y,z) => (z+d12,-x+d12,-y),	//1878
(x,y,z) => (-z+d12,x+d12,y),	//1879
(x,y,z) => (-z+d12,x+d12,-y),	//1880
(x,y,z) => (-z+d12,-x+d12,y),	//1881
(x,y,z) => (z+d12,x+d12,-y+d12),	//1882
(x,y,z) => (z+d12,-x+d12,y+d12),	//1883
(x,y,z) => (-z+d12,x+d12,y+d12),	//1884
(x,y,z) => (-z+d12,-x+d12,-y+d12),	//1885
(x,y,z) => (z+d12,-x+d14,-y+d34),	//1886
(x,y,z) => (-z+d12,x+d14,y+d34),	//1887
(x,_,z) => (z+d12,-x+d34,-x+d14),	//1888
(x,_,z) => (-z+d12,x+d34,x+d14),	//1889
(x,y,z) => (z+d12,-x+d34,-y+d14),	//1890
(x,y,z) => (-z+d12,x+d34,y+d14),	//1891
(x,y,z) => (z+d12,-y,-x),	//1892
(x,y,z) => (-z+d12,y,x),	//1893
(x,y,z) => (-z+d12,y,-x),	//1894
(x,y,z) => (z+d12,-y,x+d12),	//1895
(x,y,z) => (-z+d12,y,-x+d12),	//1896
(x,y,z) => (-z+d12,-y,x+d12),	//1897
(_,y,z) => (z+d12,y+d12,d12),	//1898
(_,y,z) => (z+d12,-y+d12,d12),	//1899
(_,y,z) => (-z+d12,y+d12,d12),	//1900
(_,y,z) => (-z+d12,-y+d12,d12),	//1901
(x,y,z) => (z+d12,y+d12,-x),	//1902
(x,y,z) => (z+d12,-y+d12,-x),	//1903
(x,y,z) => (-z+d12,-y+d12,x),	//1904
(x,y,z) => (z+d12,y+d12,x+d12),	//1905
(x,y,z) => (z+d12,y+d12,-x+d12),	//1906
(x,y,z) => (z+d12,-y+d12,x+d12),	//1907
(x,y,z) => (z+d12,-y+d12,-x+d12),	//1908
(x,y,z) => (-z+d12,y+d12,x+d12),	//1909
(x,y,z) => (-z+d12,y+d12,-x+d12),	//1910
(x,y,z) => (-z+d12,-y+d12,x+d12),	//1911
(x,y,z) => (-z+d12,-y+d12,-x+d12),	//1912
(x,y,z) => (z+d12,-y+d14,-x+d34),	//1913
(x,y,z) => (-z+d12,y+d34,x+d14),	//1914
(x,y,z) => (-z+d14,x,-y+d14),	//1915
(x,_,z) => (z+d14,-x+d12,x+d34),	//1916
(x,_,z) => (-z+d14,x+d12,-x+d34),	//1917
(x,y,z) => (z+d14,-x+d12,y+d34),	//1918
(x,y,z) => (-z+d14,x+d12,-y+d34),	//1919
(x,_,z) => (-z+d14,-x+d14,-x+d14),	//1920
(x,y,z) => (-z+d14,-x+d14,y),	//1921
(x,y,z) => (z+d14,x+d14,-y+d14),	//1922
(x,y,z) => (z+d14,-x+d14,y+d14),	//1923
(x,y,z) => (-z+d14,x+d14,y+d14),	//1924
(x,y,z) => (-z+d14,-x+d14,-y+d14),	//1925
(x,y,z) => (z+d14,-x+d14,y+d34),	//1926
(x,_,z) => (z+d14,-x+d34,x+d34),	//1927
(x,y,z) => (z+d14,x+d34,-y+d12),	//1928
(x,y,z) => (-z+d14,-x+d34,y+d12),	//1929
(x,y,z) => (-z+d14,x+d34,y+d14),	//1930
(x,y,z) => (z+d14,x+d34,-y+d34),	//1931
(x,y,z) => (z+d14,-y,x+d34),	//1932
(x,y,z) => (z+d14,-y+d12,x+d34),	//1933
(x,y,z) => (z+d14,y+d14,x+d14),	//1934
(x,y,z) => (-z+d14,-y+d14,-x+d14),	//1935
(x,y,z) => (z+d14,-y+d14,x+d34),	//1936
(x,y,z) => (-z+d14,-y+d34,x),	//1937
(x,y,z) => (-z+d14,-y+d34,x+d12),	//1938
(x,y,z) => (-z+d14,y+d34,x+d14),	//1939
(x,y,z) => (z+d14,y+d34,-x+d34),	//1940
(x,y,z) => (z+d14,-y+d34,x+d34),	//1941
(x,y,z) => (-z+d14,-y+d34,x+d34),	//1942
(x,y,z) => (z+d34,-x,y+d34),	//1943
(x,y,z) => (z+d34,-x+d12,y+d14),	//1944
(x,y,z) => (-z+d34,x+d12,-y+d14),	//1945
(x,_,z) => (z+d34,x+d14,-x+d12),	//1946
(x,_,z) => (-z+d34,-x+d14,x+d12),	//1947
(x,_,z) => (z+d34,x+d14,-x+d34),	//1948
(x,y,z) => (z+d34,x+d14,-y+d12),	//1949
(x,y,z) => (-z+d34,-x+d14,y+d12),	//1950
(x,y,z) => (z+d34,x+d14,-y+d14),	//1951
(x,y,z) => (-z+d34,x+d14,y+d34),	//1952
(x,_,z) => (-z+d34,x+d34,x+d14),	//1953
(x,y,z) => (z+d34,x+d34,-y),	//1954
(x,y,z) => (z+d34,-x+d34,y+d14),	//1955
(x,y,z) => (-z+d34,-x+d34,-y+d34),	//1956
(x,y,z) => (-z+d34,y,-x+d14),	//1957
(x,y,z) => (-z+d34,y+d12,-x+d14),	//1958
(x,y,z) => (z+d34,y+d14,-x),	//1959
(x,y,z) => (z+d34,y+d14,-x+d12),	//1960
(x,y,z) => (z+d34,y+d14,-x+d14),	//1961
(x,y,z) => (z+d34,y+d14,-x+d34),	//1962
(x,y,z) => (z+d34,-y+d14,-x+d34),	//1963
(x,y,z) => (-z+d34,y+d14,x+d34),	//1964
(x,y,z) => (z+d34,-y+d34,x+d14),	//1965
(x,y,z) => (-z+d34,y+d34,x+d14),	//1966
(x,y,z) => (-z+d34,y+d34,-x+d14),	//1967
(x,y,z) => (-z+d34,-y+d34,-x+d34)	//1968
#endregion Coordinates
        };
    
    public static readonly Func<double, double, double, (double X, double Y, double Z)>[] PositionGeneratorListA, PositionGeneratorListB, PositionGeneratorListC, PositionGeneratorListI;
    public static readonly Func<double, double, double, (double X, double Y, double Z)>[] PositionGeneratorListR1, PositionGeneratorListR2;


    public static readonly string[] PositionStringList = new string[]
        {
				#region CoodStr
	"0,0,0",
"0,0,1/2",
"0,0,1/3",
"0,0,1/4",
"0,0,1/6",
"0,0,2/3",
"0,0,3/4",
"0,0,5/6",
"0,0,x",
"0,0,-x",
"0,0,z",
"0,0,-z",
"0,0,z+1/2",
"0,0,-z+1/2",
"0,0,z+1/3",
"0,0,-z+1/3",
"0,0,z+2/3",
"0,0,-z+2/3",
"0,1/2,0",
"0,1/2,1/2",
"0,1/2,1/3",
"0,1/2,1/4",
"0,1/2,1/6",
"0,1/2,2/3",
"0,1/2,3/4",
"0,1/2,5/6",
"0,1/2,x",
"0,1/2,-x",
"0,1/2,x+1/2",
"0,1/2,-x+1/2",
"0,1/2,z",
"0,1/2,-z",
"0,1/2,z+1/2",
"0,1/2,-z+1/2",
"0,1/2,z+1/3",
"0,1/2,-z+1/3",
"0,1/2,z+1/4",
"0,1/2,-z+1/4",
"0,1/2,z+2/3",
"0,1/2,-z+2/3",
"0,1/2,z+3/4",
"0,1/4,0",
"0,1/4,1/2",
"0,1/4,1/4",
"0,1/4,1/8",
"0,1/4,3/4",
"0,1/4,3/8",
"0,1/4,5/8",
"0,1/4,7/8",
"0,1/4,x",
"0,1/4,x+1/2",
"0,1/4,-x+1/4",
"0,1/4,-x+3/4",
"0,1/4,z",
"0,1/4,-z",
"0,1/4,z+1/2",
"0,1/4,-z+1/2",
"0,1/4,-z+3/4",
"0,3/4,0",
"0,3/4,1/2",
"0,3/4,1/4",
"0,3/4,1/8",
"0,3/4,3/4",
"0,3/4,3/8",
"0,3/4,5/8",
"0,3/4,7/8",
"0,3/4,-x",
"0,3/4,-x+1/2",
"0,3/4,x+3/4",
"0,3/4,z",
"0,3/4,-z",
"0,3/4,z+1/2",
"0,3/4,-z+1/2",
"0,3/4,z+1/4",
"0,x,0",
"0,-x,0",
"0,x,1/2",
"0,-x,1/2",
"0,x,1/3",
"0,-x,1/3",
"0,x,1/4",
"0,-x,1/4",
"0,x,1/6",
"0,-x,1/6",
"0,x,2/3",
"0,-x,2/3",
"0,x,3/4",
"0,-x,3/4",
"0,x,5/6",
"0,-x,5/6",
"0,x,-x",
"0,-x,x",
"0,x,z",
"0,x,-z",
"0,-x,z",
"0,-x,-z",
"0,x,z+1/2",
"0,x,-z+1/2",
"0,-x,z+1/2",
"0,-x+1/2,0",
"0,x+1/2,1/2",
"0,-x+1/2,1/2",
"0,y,0",
"0,-y,0",
"0,y,1/2",
"0,-y,1/2",
"0,y,1/4",
"0,-y,1/4",
"0,y,3/4",
"0,-y,3/4",
"0,y,y",
"0,y,-y",
"0,-y,y",
"0,-y,-y",
"0,y,y+1/2",
"0,-y,-y+1/2",
"0,y,z",
"0,y,-z",
"0,-y,z",
"0,-y,-z",
"0,y,-z+1/2",
"0,-y,z+1/2",
"0,y+1/2,0",
"0,-y+1/2,0",
"0,y+1/2,1/2",
"0,-y+1/2,1/2",
"0,y+1/2,1/4",
"0,-y+1/2,1/4",
"0,y+1/2,3/4",
"0,-y+1/2,3/4",
"0,y+1/2,y",
"0,-y+1/2,-y",
"0,y+1/2,-y+1/2",
"0,-y+1/2,y+1/2",
"0,y+1/2,-z",
"0,-y+1/2,z",
"0,y+1/2,-z+1/2",
"0,-y+1/2,z+1/2",
"0,-y+1/2,-z+1/4",
"0,y+1/4,y+1/2",
"0,-y+3/4,-y+1/2",
"0,z,y",
"0,z,-y",
"0,-z,y",
"0,-z,-y",
"1/2,0,0",
"1/2,0,1/2",
"1/2,0,1/4",
"1/2,0,3/4",
"1/2,0,x",
"1/2,0,-x",
"1/2,0,x+1/2",
"1/2,0,-x+1/2",
"1/2,0,z",
"1/2,0,-z",
"1/2,0,z+1/2",
"1/2,0,-z+1/2",
"1/2,0,z+1/3",
"1/2,0,z+1/4",
"1/2,0,-z+1/4",
"1/2,0,z+2/3",
"1/2,0,z+3/4",
"1/2,0,-z+3/4",
"1/2,1/2,0",
"1/2,1/2,1/2",
"1/2,1/2,1/3",
"1/2,1/2,1/4",
"1/2,1/2,1/6",
"1/2,1/2,2/3",
"1/2,1/2,3/4",
"1/2,1/2,5/6",
"1/2,1/2,x",
"1/2,1/2,-x",
"1/2,1/2,x+1/2",
"1/2,1/2,-x+1/2",
"1/2,1/2,z",
"1/2,1/2,-z",
"1/2,1/2,z+1/2",
"1/2,1/2,-z+1/2",
"1/2,1/2,z+1/3",
"1/2,1/2,-z+1/3",
"1/2,1/2,z+2/3",
"1/2,1/2,-z+2/3",
"1/2,1/4,0",
"1/2,1/4,1/2",
"1/2,1/4,1/4",
"1/2,1/4,1/8",
"1/2,1/4,3/4",
"1/2,1/4,3/8",
"1/2,1/4,5/8",
"1/2,1/4,7/8",
"1/2,1/4,x+1/4",
"1/2,1/4,x+3/4",
"1/2,1/4,z",
"1/2,1/4,-z",
"1/2,1/4,z+1/2",
"1/2,1/4,-z+1/2",
"1/2,1/4,z+1/4",
"1/2,3/4,0",
"1/2,3/4,1/2",
"1/2,3/4,1/4",
"1/2,3/4,3/4",
"1/2,3/4,3/8",
"1/2,3/4,-x+1/4",
"1/2,3/4,z",
"1/2,3/4,-z",
"1/2,3/4,z+1/2",
"1/2,3/4,-z+1/2",
"1/2,3/4,-z+1/4",
"1/2,3/4,-z+3/4",
"1/2,x,0",
"1/2,-x,0",
"1/2,x,1/2",
"1/2,-x,1/2",
"1/2,x,1/4",
"1/2,-x,1/4",
"1/2,x,3/4",
"1/2,-x,3/4",
"1/2,x,-x",
"1/2,-x,x",
"1/2,x,z",
"1/2,x,-z",
"1/2,-x,z",
"1/2,-x,-z",
"1/2,x,z+1/2",
"1/2,-x,z+1/2",
"1/2,x+1/2,0",
"1/2,-x+1/2,0",
"1/2,x+1/2,1/2",
"1/2,-x+1/2,1/2",
"1/2,x+1/2,1/4",
"1/2,-x+1/2,1/4",
"1/2,x+1/2,3/4",
"1/2,-x+1/2,3/4",
"1/2,y,0",
"1/2,-y,0",
"1/2,y,1/2",
"1/2,-y,1/2",
"1/2,y,1/4",
"1/2,-y,1/4",
"1/2,y,3/4",
"1/2,-y,3/4",
"1/2,y,y",
"1/2,y,-y",
"1/2,-y,y",
"1/2,-y,-y",
"1/2,y,y+1/2",
"1/2,-y,-y+1/2",
"1/2,y,z",
"1/2,y,-z",
"1/2,-y,z",
"1/2,-y,-z",
"1/2,y,-z+1/2",
"1/2,-y,z+1/2",
"1/2,-y,-z+1/2",
"1/2,y,-z+3/4",
"1/2,y+1/2,0",
"1/2,-y+1/2,0",
"1/2,y+1/2,1/2",
"1/2,-y+1/2,1/2",
"1/2,y+1/2,1/4",
"1/2,-y+1/2,1/4",
"1/2,y+1/2,3/4",
"1/2,-y+1/2,3/4",
"1/2,y+1/2,y",
"1/2,-y+1/2,-y",
"1/2,y+1/2,y+1/2",
"1/2,y+1/2,-y+1/2",
"1/2,-y+1/2,y+1/2",
"1/2,-y+1/2,-y+1/2",
"1/2,y+1/2,y+1/4",
"1/2,-y+1/2,-y+3/4",
"1/2,y+1/2,-z",
"1/2,-y+1/2,z",
"1/2,-y+1/2,-z",
"1/2,y+1/2,-z+1/2",
"1/2,-y+1/2,z+1/2",
"1/2,-y+1/2,-z+1/2",
"1/2,y+1/4,-y+3/4",
"1/2,-y+3/4,y+1/4",
"1/2,z,y",
"1/2,z,-y",
"1/2,-z,y",
"1/2,-z,-y",
"1/2,z+1/2,y+1/2",
"1/2,z+1/2,-y+1/2",
"1/2,-z+1/2,y+1/2",
"1/2,-z+1/2,-y+1/2",
"1/3,2/3,0",
"1/3,2/3,1/2",
"1/3,2/3,1/4",
"1/3,2/3,3/4",
"1/3,2/3,z",
"1/3,2/3,-z",
"1/3,2/3,z+1/2",
"1/3,2/3,-z+1/2",
"1/4,0,0",
"1/4,0,1/2",
"1/4,0,1/4",
"1/4,0,3/4",
"1/4,0,z",
"1/4,0,-z",
"1/4,0,z+1/2",
"1/4,0,-z+1/2",
"1/4,1/2,0",
"1/4,1/2,1/2",
"1/4,1/2,1/4",
"1/4,1/2,3/4",
"1/4,1/2,z",
"1/4,1/2,-z",
"1/4,1/2,z+1/2",
"1/4,1/2,-z+1/2",
"1/4,1/4,0",
"1/4,1/4,1/2",
"1/4,1/4,1/4",
"1/4,1/4,3/4",
"1/4,1/4,x",
"1/4,1/4,-x",
"1/4,1/4,-x+1/2",
"1/4,1/4,x+1/4",
"1/4,1/4,-x+1/4",
"1/4,1/4,x+3/4",
"1/4,1/4,z",
"1/4,1/4,-z",
"1/4,1/4,z+1/2",
"1/4,1/4,-z+1/2",
"1/4,1/4,z+1/4",
"1/4,1/4,-z+1/4",
"1/4,1/8,0",
"1/4,3/4,0",
"1/4,3/4,1/2",
"1/4,3/4,1/4",
"1/4,3/4,3/4",
"1/4,3/4,x",
"1/4,3/4,-x",
"1/4,3/4,x+1/2",
"1/4,3/4,-x+1/2",
"1/4,3/4,x+3/4",
"1/4,3/4,z",
"1/4,3/4,-z",
"1/4,3/4,z+1/2",
"1/4,3/4,-z+1/2",
"1/4,3/8,0",
"1/4,5/8,0",
"1/4,7/8,0",
"1/4,x,0",
"1/4,x,1/2",
"1/4,x,1/4",
"1/4,x,3/4",
"1/4,-x,3/4",
"1/4,-x,7/8",
"1/4,x,-x+1/2",
"1/4,x+1/2,0",
"1/4,-x+1/2,0",
"1/4,-x+1/2,1/2",
"1/4,-x+1/2,1/4",
"1/4,x+1/2,3/4",
"1/4,-x+1/2,3/4",
"1/4,x+1/2,3/8",
"1/4,-x+1/4,0",
"1/4,x+1/4,1/2",
"1/4,x+1/4,1/4",
"1/4,-x+1/4,1/4",
"1/4,-x+1/4,3/4",
"1/4,-x+3/4,0",
"1/4,x+3/4,1/2",
"1/4,x+3/4,1/4",
"1/4,y,0",
"1/4,-y,0",
"1/4,y,1/2",
"1/4,-y,1/2",
"1/4,y,1/4",
"1/4,-y,1/4",
"1/4,y,1/8",
"1/4,y,3/4",
"1/4,-y,3/4",
"1/4,y,y",
"1/4,y,-y",
"1/4,-y,y",
"1/4,-y,-y",
"1/4,y,y+1/2",
"1/4,y,-y+1/2",
"1/4,-y,y+1/2",
"1/4,-y,-y+1/2",
"1/4,y,z",
"1/4,y,-z",
"1/4,-y,z",
"1/4,-y,-z",
"1/4,y,-z+1/2",
"1/4,-y,z+1/2",
"1/4,y+1/2,0",
"1/4,-y+1/2,0",
"1/4,y+1/2,1/2",
"1/4,-y+1/2,1/2",
"1/4,y+1/2,1/4",
"1/4,-y+1/2,1/4",
"1/4,y+1/2,3/4",
"1/4,-y+1/2,3/4",
"1/4,-y+1/2,5/8",
"1/4,y+1/2,y",
"1/4,y+1/2,-y",
"1/4,-y+1/2,y",
"1/4,-y+1/2,-y",
"1/4,-y+1/2,-y+1/2",
"1/4,y+1/2,y+3/4",
"1/4,-y+1/2,z",
"1/4,y+1/2,-z+1/2",
"1/4,-y+1/2,z+1/2",
"1/4,y+1/4,1/4",
"1/4,-y+1/4,1/4",
"1/4,y+3/4,y+1/2",
"1/4,y+3/4,-y+1/4",
"1/8,0,1/4",
"1/8,0,3/4",
"1/8,1/2,1/4",
"1/8,1/8,1/8",
"1/8,1/8,5/8",
"1/8,1/8,7/8",
"1/8,1/8,x",
"1/8,1/8,-x+1/4",
"1/8,1/8,z",
"1/8,3/8,5/8",
"1/8,3/8,7/8",
"1/8,5/8,1/8",
"1/8,5/8,3/8",
"1/8,5/8,7/8",
"1/8,5/8,x",
"1/8,5/8,-x+3/4",
"1/8,7/8,1/8",
"1/8,7/8,3/8",
"1/8,7/8,5/8",
"1/8,7/8,7/8",
"1/8,x,1/8",
"1/8,-x+1/4,1/8",
"1/8,-x+3/4,1/8",
"1/8,y,1/8",
"1/8,y,y+1/4",
"1/8,y,-y+1/4",
"1/8,-y+1/2,-y+3/4",
"1/8,-y+1/4,y",
"1/8,y+3/4,-y+1/2",
"2x,x,0",
"-2x,-x,0",
"2x,x,1/12",
"2x,x,1/2",
"-2x,-x,1/2",
"2x,x,1/3",
"-2x,-x,1/3",
"2x,x,1/4",
"-2x,-x,1/4",
"2x,x,1/6",
"-2x,-x,1/6",
"2x,x,11/12",
"2x,x,2/3",
"-2x,-x,2/3",
"2x,x,3/4",
"-2x,-x,3/4",
"-2x,-x,5/12",
"2x,x,5/6",
"-2x,-x,5/6",
"-2x,-x,7/12",
"2x,x,z",
"2x,x,-z",
"-2x,-x,z",
"-2x,-x,-z",
"2x,x,z+1/2",
"-2x,-x,-z+1/2",
"2/3,1/3,0",
"2/3,1/3,1/2",
"2/3,1/3,1/4",
"2/3,1/3,3/4",
"2/3,1/3,z",
"2/3,1/3,-z",
"2/3,1/3,z+1/2",
"2/3,1/3,-z+1/2",
"3/4,0,0",
"3/4,0,1/2",
"3/4,0,1/4",
"3/4,0,3/4",
"3/4,0,3/8",
"3/4,0,7/8",
"3/4,0,z",
"3/4,0,-z",
"3/4,0,z+1/2",
"3/4,0,-z+1/2",
"3/4,1/2,0",
"3/4,1/2,1/2",
"3/4,1/2,1/4",
"3/4,1/2,3/4",
"3/4,1/2,3/8",
"3/4,1/2,7/8",
"3/4,1/2,z",
"3/4,1/2,-z",
"3/4,1/2,z+1/2",
"3/4,1/2,-z+1/2",
"3/4,1/4,0",
"3/4,1/4,1/2",
"3/4,1/4,1/4",
"3/4,1/4,3/4",
"3/4,1/4,x",
"3/4,1/4,-x",
"3/4,1/4,x+1/2",
"3/4,1/4,-x+1/2",
"3/4,1/4,-x+3/4",
"3/4,1/4,z",
"3/4,1/4,-z",
"3/4,1/4,z+1/2",
"3/4,1/4,-z+1/2",
"3/4,1/8,0",
"3/4,3/4,0",
"3/4,3/4,1/2",
"3/4,3/4,1/4",
"3/4,3/4,3/4",
"3/4,3/4,-x",
"3/4,3/4,x+1/2",
"3/4,3/4,-x+3/4",
"3/4,3/4,z",
"3/4,3/4,-z",
"3/4,3/4,z+1/2",
"3/4,3/4,-z+1/2",
"3/4,3/8,0",
"3/4,3/8,1/2",
"3/4,5/8,0",
"3/4,7/8,0",
"3/4,-x,0",
"3/4,-x,1/2",
"3/4,x,1/4",
"3/4,-x,1/4",
"3/4,-x,3/4",
"3/4,x,7/8",
"3/4,-x,7/8",
"3/4,-x,x+1/2",
"3/4,x+1/2,0",
"3/4,-x+1/2,0",
"3/4,x+1/2,1/2",
"3/4,x+1/2,1/4",
"3/4,-x+1/2,1/4",
"3/4,x+1/2,3/4",
"3/4,x+1/2,3/8",
"3/4,x+1/4,0",
"3/4,-x+1/4,1/2",
"3/4,x+1/4,3/4",
"3/4,-x+1/4,3/4",
"3/4,x+3/4,0",
"3/4,-x+3/4,1/2",
"3/4,x+3/4,1/4",
"3/4,-x+3/4,3/4",
"3/4,y,0",
"3/4,-y,0",
"3/4,y,1/2",
"3/4,-y,1/2",
"3/4,y,1/4",
"3/4,-y,1/4",
"3/4,y,3/4",
"3/4,-y,3/4",
"3/4,y,5/8",
"3/4,y,y",
"3/4,y,-y",
"3/4,-y,y",
"3/4,-y,-y",
"3/4,y,y+1/2",
"3/4,y,-y+1/2",
"3/4,-y,y+1/2",
"3/4,-y,-y+1/2",
"3/4,y,z",
"3/4,y,-z",
"3/4,-y,z",
"3/4,-y,-z",
"3/4,y,-z+1/2",
"3/4,-y,z+1/2",
"3/4,y+1/2,0",
"3/4,-y+1/2,0",
"3/4,y+1/2,1/2",
"3/4,-y+1/2,1/2",
"3/4,y+1/2,1/4",
"3/4,-y+1/2,1/4",
"3/4,-y+1/2,1/8",
"3/4,y+1/2,3/4",
"3/4,-y+1/2,3/4",
"3/4,y+1/2,y",
"3/4,y+1/2,-y",
"3/4,-y+1/2,y",
"3/4,-y+1/2,-y",
"3/4,y+1/2,y+1/2",
"3/4,-y+1/2,-y+1/4",
"3/4,y+1/2,-z",
"3/4,y+1/2,-z+1/2",
"3/4,-y+1/2,z+1/2",
"3/4,-y+1/4,-y+1/2",
"3/4,-y+1/4,y+3/4",
"3/8,0,1/4",
"3/8,0,3/4",
"3/8,1/8,5/8",
"3/8,1/8,7/8",
"3/8,3/8,3/8",
"3/8,3/8,5/8",
"3/8,3/8,x+3/4",
"3/8,5/8,1/8",
"3/8,5/8,3/8",
"3/8,5/8,5/8",
"3/8,5/8,7/8",
"3/8,7/8,1/8",
"3/8,7/8,5/8",
"3/8,7/8,x+3/4",
"3/8,7/8,z+1/4",
"3/8,-x+1/2,3/8",
"3/8,x+3/4,3/8",
"3/8,-y,y+3/4",
"3/8,-y,-y+3/4",
"3/8,y+1/2,-y+1/4",
"3/8,y+1/2,y+3/4",
"3/8,y+1/4,7/8",
"3/8,-y+1/4,-y",
"3/8,y+3/4,y+1/2",
"5/8,0,1/4",
"5/8,0,3/4",
"5/8,1/8,3/8",
"5/8,1/8,7/8",
"5/8,1/8,-x+1/4",
"5/8,1/8,-z+3/4",
"5/8,3/8,1/8",
"5/8,3/8,3/8",
"5/8,3/8,5/8",
"5/8,3/8,7/8",
"5/8,5/8,3/8",
"5/8,5/8,5/8",
"5/8,5/8,-x+1/4",
"5/8,7/8,1/8",
"5/8,7/8,3/8",
"5/8,x+1/2,5/8",
"5/8,-x+1/4,5/8",
"5/8,-x+3/4,1/8",
"5/8,y,y+1/4",
"5/8,-y,y+1/4",
"5/8,-y+1/2,y+3/4",
"5/8,-y+1/2,-y+3/4",
"5/8,y+1/4,-y",
"5/8,-y+3/4,1/8",
"5/8,-y+3/4,y+1/2",
"7/8,0,1/4",
"7/8,0,3/4",
"7/8,1/8,1/8",
"7/8,1/8,3/8",
"7/8,1/8,5/8",
"7/8,1/8,7/8",
"7/8,3/8,1/8",
"7/8,3/8,3/8",
"7/8,3/8,5/8",
"7/8,3/8,7/8",
"7/8,3/8,-x",
"7/8,3/8,-x+1/2",
"7/8,5/8,1/8",
"7/8,5/8,3/8",
"7/8,7/8,1/8",
"7/8,7/8,3/8",
"7/8,7/8,7/8",
"7/8,7/8,-x",
"7/8,7/8,x+3/4",
"7/8,7/8,-z",
"7/8,-x,7/8",
"7/8,x+1/4,3/8",
"7/8,x+1/4,7/8",
"7/8,x+3/4,7/8",
"7/8,-y,7/8",
"7/8,-y,y+3/4",
"7/8,y+1/2,y+1/4",
"7/8,y+1/2,-y+1/4",
"7/8,-y+1/2,-y+3/4",
"7/8,y+1/4,y",
"7/8,-y+3/4,-y+1/2",
"x,0,0",
"-x,0,0",
"x,0,1/2",
"-x,0,1/2",
"x,0,1/3",
"x,0,1/4",
"-x,0,1/4",
"x,0,1/6",
"x,0,2/3",
"x,0,3/4",
"-x,0,3/4",
"x,0,5/6",
"x,0,-x",
"-x,0,x",
"x,0,z",
"x,0,-z",
"-x,0,z",
"-x,0,-z",
"x,0,-z+1/2",
"-x,0,z+1/2",
"x,1/2,0",
"-x,1/2,0",
"x,1/2,1/2",
"-x,1/2,1/2",
"x,1/2,1/4",
"-x,1/2,1/4",
"x,1/2,3/4",
"-x,1/2,3/4",
"x,1/2,-x",
"-x,1/2,x",
"x,1/2,z",
"x,1/2,-z",
"-x,1/2,z",
"-x,1/2,-z",
"x,1/2,-z+1/2",
"-x,1/2,z+1/2",
"-x,1/2,-z+1/2",
"x,1/4,0",
"-x,1/4,0",
"x,1/4,1/2",
"-x,1/4,1/2",
"x,1/4,1/4",
"-x,1/4,1/4",
"x,1/4,1/8",
"-x,1/4,1/8",
"x,1/4,3/4",
"-x,1/4,3/4",
"x,1/4,z",
"x,1/4,-z",
"-x,1/4,z",
"-x,1/4,-z",
"x,1/4,-z+1/2",
"x,1/8,1/8",
"x,1/8,5/8",
"x,2x,0",
"-x,-2x,0",
"x,2x,1/2",
"-x,-2x,1/2",
"x,2x,1/3",
"x,2x,1/4",
"-x,-2x,1/4",
"x,2x,1/6",
"x,2x,2/3",
"x,2x,3/4",
"-x,-2x,3/4",
"x,2x,5/6",
"x,2x,z",
"x,2x,-z",
"-x,-2x,z",
"-x,-2x,-z",
"x,2x,-z+1/2",
"-x,-2x,z+1/2",
"x,3/4,0",
"-x,3/4,0",
"x,3/4,1/2",
"-x,3/4,1/2",
"x,3/4,1/4",
"-x,3/4,1/4",
"-x,3/4,1/8",
"x,3/4,3/4",
"-x,3/4,3/4",
"x,3/4,z",
"x,3/4,-z",
"-x,3/4,z",
"-x,3/4,-z",
"-x,3/4,z+1/2",
"-x,7/8,3/8",
"-x,7/8,7/8",
"x,x,0",
"x,-x,0",
"-x,x,0",
"-x,-x,0",
"x,-x,1/12",
"x,x,1/2",
"x,-x,1/2",
"-x,x,1/2",
"-x,-x,1/2",
"x,x,1/3",
"x,-x,1/3",
"-x,x,1/3",
"-x,-x,1/3",
"x,x,1/4",
"x,-x,1/4",
"-x,x,1/4",
"-x,-x,1/4",
"x,x,1/6",
"x,-x,1/6",
"-x,x,1/6",
"-x,-x,1/6",
"x,-x,1/8",
"-x,-x,1/8",
"x,-x,11/12",
"x,x,2/3",
"x,-x,2/3",
"-x,x,2/3",
"-x,-x,2/3",
"x,x,3/4",
"x,-x,3/4",
"-x,x,3/4",
"-x,-x,3/4",
"x,x,3/8",
"-x,x,3/8",
"-x,x,5/12",
"x,x,5/6",
"x,-x,5/6",
"-x,x,5/6",
"-x,-x,5/6",
"x,x,5/8",
"-x,x,5/8",
"-x,x,7/12",
"x,-x,7/8",
"-x,-x,7/8",
"x,x,x",
"x,x,-x",
"x,-x,x",
"x,-x,-x",
"-x,x,x",
"-x,x,-x",
"-x,-x,x",
"-x,-x,-x",
"x,x,-x+1/2",
"x,-x,-x+1/2",
"-x,-x,x+1/2",
"x,x,z",
"x,x,-z",
"x,-x,z",
"x,-x,-z",
"-x,x,z",
"-x,x,-z",
"-x,-x,z",
"-x,-x,-z",
"x,x,z+1/2",
"x,-x,z+1/2",
"x,-x,-z+1/2",
"-x,x,z+1/2",
"-x,x,-z+1/2",
"-x,-x,-z+1/2",
"x,x+1/2,0",
"x,-x+1/2,0",
"-x,x+1/2,0",
"-x,-x+1/2,0",
"x,x+1/2,1/2",
"x,-x+1/2,1/2",
"-x,x+1/2,1/2",
"-x,-x+1/2,1/2",
"x,x+1/2,1/4",
"x,-x+1/2,1/4",
"-x,x+1/2,1/4",
"-x,-x+1/2,1/4",
"x,x+1/2,3/4",
"x,-x+1/2,3/4",
"-x,x+1/2,3/4",
"-x,-x+1/2,3/4",
"x,-x+1/2,x",
"-x,x+1/2,-x",
"-x,-x+1/2,x",
"x,-x+1/2,x+1/2",
"x,-x+1/2,-x+1/2",
"-x,x+1/2,x+1/2",
"-x,x+1/2,-x+1/2",
"-x,-x+1/2,x+1/2",
"x,x+1/2,z",
"x,x+1/2,-z",
"x,-x+1/2,z",
"x,-x+1/2,-z",
"-x,x+1/2,z",
"-x,x+1/2,-z",
"-x,-x+1/2,z",
"-x,-x+1/2,-z",
"x,x+1/2,-z+1/2",
"x,-x+1/2,z+1/2",
"x,-x+1/2,-z+1/2",
"-x,x+1/2,z+1/2",
"-x,x+1/2,-z+1/2",
"-x,-x+1/2,z+1/2",
"x,x+1/4,1/8",
"x,-x+1/4,5/8",
"x,x+1/4,7/8",
"x,-x+1/4,7/8",
"x,-x+1/4,-x+1/4",
"x,-x+1/4,-x+3/4",
"-x,x+3/4,1/8",
"-x,-x+3/4,1/8",
"-x,x+3/4,3/8",
"-x,-x+3/4,7/8",
"-x,x+3/4,x+1/4",
"-x,x+3/4,x+3/4",
"-x,-x+y,0",
"-x,-x+y,1/2",
"-x,-x+y,1/4",
"-x,-x+y,3/4",
"-x,-x+y,z",
"-x,-x+y,-z",
"-x,-x+y,z+1/2",
"-x,-x+y,-z+1/2",
"-x,-x+y,-z+1/3",
"-x,-x+y,-z+2/3",
"x,x-y,0",
"x,x-y,1/2",
"x,x-y,1/4",
"x,x-y,3/4",
"x,x-y,z",
"x,x-y,-z",
"x,x-y,z+1/2",
"x,x-y,-z+1/2",
"x,x-y,-z+1/3",
"x,x-y,-z+1/6",
"x,x-y,-z+2/3",
"x,x-y,-z+5/6",
"x,y,0",
"x,-y,0",
"-x,y,0",
"-x,-y,0",
"x,y,1/2",
"x,-y,1/2",
"-x,y,1/2",
"-x,-y,1/2",
"x,y,1/4",
"x,-y,1/4",
"-x,y,1/4",
"-x,-y,1/4",
"x,y,3/4",
"x,-y,3/4",
"-x,y,3/4",
"-x,-y,3/4",
"x,y,z",
"x,y,-z",
"x,-y,z",
"x,-y,-z",
"-x,y,z",
"-x,y,-z",
"-x,-y,z",
"-x,-y,-z",
"x,y,-z+1/2",
"x,-y,z+1/2",
"x,-y,-z+1/2",
"-x,y,z+1/2",
"-x,y,-z+1/2",
"-x,-y,z+1/2",
"x,-y+1/2,0",
"-x,y+1/2,0",
"x,-y+1/2,1/2",
"-x,y+1/2,1/2",
"-x,-y+1/2,1/2",
"x,-y+1/2,1/4",
"-x,y+1/2,1/4",
"x,-y+1/2,3/4",
"-x,y+1/2,3/4",
"x,y+1/2,-z",
"x,-y+1/2,z",
"x,-y+1/2,-z",
"-x,y+1/2,z",
"-x,y+1/2,-z",
"-x,-y+1/2,z",
"x,y+1/2,-z+1/2",
"x,-y+1/2,z+1/2",
"x,-y+1/2,-z+1/2",
"-x,y+1/2,z+1/2",
"-x,y+1/2,-z+1/2",
"-x,-y+1/2,z+1/2",
"-x,-y+1/2,-z+1/2",
"x,-y+1/2,-z+1/4",
"-x,-y+1/2,-z+1/4",
"x,-y+1/2,-z+3/4",
"x,-y+1/4,-z+1/4",
"-x,y+1/4,z+1/4",
"x,-y+3/4,-z+3/4",
"-x,y+3/4,z+3/4",
"x,z,x",
"x,z,-x",
"x,-z,x",
"x,-z,-x",
"-x,z,x",
"-x,z,-x",
"-x,-z,x",
"-x,-z,-x",
"x,z,y",
"x,z,-y",
"x,-z,y",
"x,-z,-y",
"-x,z,y",
"-x,z,-y",
"-x,-z,y",
"-x,-z,-y",
"x,z,-y+1/2",
"x,-z,-y+1/2",
"-x,-z,y+1/2",
"x,-z+1/2,-x+1/2",
"-x,z+1/2,x+1/2",
"-x,-z+1/2,x+1/2",
"x,-z+1/2,y",
"-x,z+1/2,-y",
"-x,-z+1/2,y",
"x,-z+1/2,-y+1/2",
"-x,z+1/2,y+1/2",
"-x,z+1/2,-y+1/2",
"x,-z+1/4,-y+3/4",
"-x,z+3/4,y+1/4",
"x+1/2,0,0",
"-x+1/2,0,0",
"x+1/2,0,1/2",
"-x+1/2,0,1/2",
"x+1/2,0,1/4",
"-x+1/2,0,1/4",
"x+1/2,0,3/4",
"-x+1/2,0,3/4",
"x+1/2,0,-z",
"-x+1/2,0,z",
"x+1/2,0,-z+1/2",
"-x+1/2,0,z+1/2",
"x+1/2,1/2,0",
"-x+1/2,1/2,0",
"x+1/2,1/2,1/2",
"-x+1/2,1/2,1/2",
"x+1/2,1/2,1/4",
"-x+1/2,1/2,1/4",
"x+1/2,1/2,3/4",
"-x+1/2,1/2,3/4",
"x+1/2,1/2,-z",
"-x+1/2,1/2,z",
"-x+1/2,1/2,-z",
"x+1/2,1/2,-z+1/2",
"-x+1/2,1/2,z+1/2",
"x+1/2,1/4,0",
"-x+1/2,1/4,0",
"x+1/2,1/4,1/2",
"-x+1/2,1/4,1/2",
"x+1/2,1/4,1/4",
"-x+1/2,1/4,1/4",
"x+1/2,1/4,3/4",
"-x+1/2,1/4,3/4",
"x+1/2,1/4,5/8",
"-x+1/2,1/4,5/8",
"-x+1/2,1/4,x",
"x+1/2,1/4,-z",
"-x+1/2,1/4,z",
"x+1/2,1/4,-z+1/2",
"-x+1/2,1/4,z+1/2",
"x+1/2,3/4,0",
"-x+1/2,3/4,0",
"x+1/2,3/4,1/2",
"-x+1/2,3/4,1/2",
"x+1/2,3/4,1/4",
"-x+1/2,3/4,1/4",
"x+1/2,3/4,3/4",
"-x+1/2,3/4,3/4",
"x+1/2,3/4,-x",
"x+1/2,3/4,-z",
"-x+1/2,3/4,z",
"x+1/2,3/4,-z+1/2",
"-x+1/2,3/4,z+1/2",
"-x+1/2,7/8,3/8",
"x+1/2,x,0",
"x+1/2,-x,0",
"-x+1/2,x,0",
"-x+1/2,-x,0",
"x+1/2,x,1/2",
"x+1/2,-x,1/2",
"-x+1/2,x,1/2",
"-x+1/2,-x,1/2",
"x+1/2,x,1/4",
"x+1/2,-x,1/4",
"-x+1/2,x,1/4",
"-x+1/2,-x,1/4",
"x+1/2,x,3/4",
"x+1/2,-x,3/4",
"-x+1/2,x,3/4",
"-x+1/2,-x,3/4",
"x+1/2,-x,-x",
"-x+1/2,x,x",
"-x+1/2,x,-x",
"x+1/2,x,-x+1/2",
"x+1/2,-x,x+1/2",
"x+1/2,-x,-x+1/2",
"-x+1/2,x,-x+1/2",
"-x+1/2,-x,x+1/2",
"x+1/2,x,z",
"x+1/2,x,-z",
"x+1/2,-x,z",
"x+1/2,-x,-z",
"-x+1/2,x,z",
"-x+1/2,x,-z",
"-x+1/2,-x,-z",
"x+1/2,x,z+1/2",
"x+1/2,x,-z+1/2",
"x+1/2,-x,z+1/2",
"x+1/2,-x,-z+1/2",
"-x+1/2,x,z+1/2",
"-x+1/2,x,-z+1/2",
"-x+1/2,-x,-z+1/2",
"x+1/2,x+1/2,0",
"x+1/2,-x+1/2,0",
"-x+1/2,x+1/2,0",
"-x+1/2,-x+1/2,0",
"x+1/2,x+1/2,1/2",
"x+1/2,-x+1/2,1/2",
"-x+1/2,x+1/2,1/2",
"-x+1/2,-x+1/2,1/2",
"x+1/2,x+1/2,1/4",
"x+1/2,-x+1/2,1/4",
"-x+1/2,x+1/2,1/4",
"-x+1/2,-x+1/2,1/4",
"x+1/2,x+1/2,3/4",
"x+1/2,-x+1/2,3/4",
"-x+1/2,x+1/2,3/4",
"-x+1/2,-x+1/2,3/4",
"x+1/2,x+1/2,-x",
"x+1/2,-x+1/2,-x",
"-x+1/2,x+1/2,x",
"-x+1/2,x+1/2,-x",
"-x+1/2,-x+1/2,x",
"x+1/2,x+1/2,x+1/2",
"x+1/2,x+1/2,-x+1/2",
"x+1/2,-x+1/2,x+1/2",
"x+1/2,-x+1/2,-x+1/2",
"-x+1/2,x+1/2,x+1/2",
"-x+1/2,x+1/2,-x+1/2",
"-x+1/2,-x+1/2,x+1/2",
"-x+1/2,-x+1/2,-x+1/2",
"x+1/2,x+1/2,-z",
"x+1/2,-x+1/2,-z",
"-x+1/2,x+1/2,z",
"-x+1/2,x+1/2,-z",
"-x+1/2,-x+1/2,z",
"x+1/2,x+1/2,-z+1/2",
"x+1/2,-x+1/2,z+1/2",
"x+1/2,-x+1/2,-z+1/2",
"-x+1/2,x+1/2,z+1/2",
"-x+1/2,x+1/2,-z+1/2",
"-x+1/2,-x+1/2,-z+1/2",
"x+1/2,x+1/4,3/8",
"x+1/2,x+1/4,5/8",
"x+1/2,-x+1/4,5/8",
"x+1/2,-x+1/4,7/8",
"x+1/2,-x+1/4,-x+3/4",
"-x+1/2,x+3/4,1/8",
"-x+1/2,x+3/4,3/8",
"-x+1/2,-x+3/4,3/8",
"-x+1/2,-x+3/4,5/8",
"x+1/2,-x+3/4,-x+1/4",
"-x+1/2,x+3/4,x+1/4",
"x+1/2,-x+3/4,-z+1/4",
"-x+1/2,x+3/4,z+1/4",
"x+1/2,-y,0",
"-x+1/2,y,0",
"x+1/2,-y,1/2",
"-x+1/2,y,1/2",
"-x+1/2,-y,1/2",
"-x+1/2,y,1/4",
"x+1/2,-y,3/4",
"x+1/2,y,-z",
"x+1/2,-y,z",
"x+1/2,-y,-z",
"-x+1/2,y,z",
"-x+1/2,y,-z",
"-x+1/2,-y,z",
"x+1/2,y,-z+1/2",
"x+1/2,-y,z+1/2",
"x+1/2,-y,-z+1/2",
"-x+1/2,y,z+1/2",
"-x+1/2,y,-z+1/2",
"-x+1/2,-y,z+1/2",
"-x+1/2,-y,-z+1/2",
"-x+1/2,y,-z+1/4",
"x+1/2,y,-z+3/4",
"x+1/2,-y,-z+3/4",
"-x+1/2,y,-z+3/4",
"x+1/2,-y+1/2,0",
"-x+1/2,y+1/2,0",
"x+1/2,-y+1/2,1/2",
"-x+1/2,y+1/2,1/2",
"x+1/2,-y+1/2,1/4",
"-x+1/2,y+1/2,1/4",
"x+1/2,-y+1/2,3/4",
"-x+1/2,y+1/2,3/4",
"x+1/2,y+1/2,-z",
"x+1/2,-y+1/2,z",
"x+1/2,-y+1/2,-z",
"-x+1/2,y+1/2,z",
"-x+1/2,y+1/2,-z",
"-x+1/2,-y+1/2,z",
"-x+1/2,-y+1/2,-z",
"x+1/2,y+1/2,-z+1/2",
"x+1/2,-y+1/2,z+1/2",
"x+1/2,-y+1/2,-z+1/2",
"-x+1/2,y+1/2,z+1/2",
"-x+1/2,y+1/2,-z+1/2",
"-x+1/2,-y+1/2,z+1/2",
"-x+1/2,-y+1/2,-z+1/2",
"x+1/2,-y+1/2,-z+1/4",
"-x+1/2,y+1/2,-z+1/4",
"x+1/2,-y+1/2,-z+3/4",
"-x+1/2,y+1/2,-z+3/4",
"x+1/2,-y+1/4,-z+3/4",
"-x+1/2,y+1/4,z+3/4",
"x+1/2,-y+3/4,-z+1/4",
"-x+1/2,y+3/4,z+1/4",
"x+1/2,-z,x+1/2",
"x+1/2,-z,-x+1/2",
"-x+1/2,z,-x+1/2",
"x+1/2,-z,-y",
"-x+1/2,z,y",
"-x+1/2,z,-y",
"x+1/2,-z,y+1/2",
"-x+1/2,z,-y+1/2",
"-x+1/2,-z,y+1/2",
"x+1/2,z+1/2,-x",
"-x+1/2,z+1/2,-x",
"-x+1/2,-z+1/2,x",
"x+1/2,z+1/2,-x+1/2",
"x+1/2,-z+1/2,x+1/2",
"-x+1/2,z+1/2,x+1/2",
"-x+1/2,-z+1/2,-x+1/2",
"x+1/2,z+1/2,-y",
"x+1/2,-z+1/2,-y",
"-x+1/2,-z+1/2,y",
"x+1/2,z+1/2,y+1/2",
"x+1/2,z+1/2,-y+1/2",
"x+1/2,-z+1/2,y+1/2",
"x+1/2,-z+1/2,-y+1/2",
"-x+1/2,z+1/2,y+1/2",
"-x+1/2,z+1/2,-y+1/2",
"-x+1/2,-z+1/2,y+1/2",
"-x+1/2,-z+1/2,-y+1/2",
"x+1/2,-z+1/4,-y+3/4",
"x+1/2,-z+3/4,-x+1/4",
"-x+1/2,z+3/4,x+1/4",
"-x+1/2,z+3/4,y+1/4",
"-x+1/4,0,1/4",
"x+1/4,1/2,1/4",
"-x+1/4,1/2,3/4",
"x+1/4,1/4,1/4",
"-x+1/4,1/4,1/4",
"-x+1/4,1/8,1/8",
"x+1/4,3/8,7/8",
"-x+1/4,5/8,1/8",
"-x+1/4,5/8,5/8",
"-x+1/4,x,-x+1/4",
"x+1/4,-x,x+3/4",
"x+1/4,-x+1/2,x+3/4",
"-x+1/4,x+1/2,-x+3/4",
"x+1/4,-x+1/2,z+3/4",
"-x+1/4,x+1/2,-z+3/4",
"-x+1/4,-x+1/4,x",
"x+1/4,x+1/4,x+1/4",
"x+1/4,x+1/4,-x+1/4",
"x+1/4,-x+1/4,x+1/4",
"-x+1/4,x+1/4,x+1/4",
"-x+1/4,-x+1/4,-x+1/4",
"x+1/4,-x+1/4,x+3/4",
"-x+1/4,-x+1/4,-z+1/4",
"-x+1/4,-x+3/4,x",
"-x+1/4,-x+3/4,x+1/2",
"-x+1/4,x+3/4,x+1/4",
"x+1/4,x+3/4,-x+3/4",
"x+1/4,-x+3/4,x+3/4",
"-x+1/4,-x+3/4,x+3/4",
"x+1/4,-x+3/4,z+3/4",
"x+1/4,-y,z+1/4",
"-x+1/4,y,-z+1/4",
"x+1/4,-y+1/2,z+3/4",
"-x+1/4,y+1/2,-z+3/4",
"x+1/4,y+1/4,-z",
"-x+1/4,-y+1/4,z",
"x+1/4,y+1/4,-z+1/4",
"x+1/4,-y+1/4,z+1/4",
"-x+1/4,y+1/4,z+1/4",
"-x+1/4,-y+1/4,-z+1/4",
"x+1/4,-y+1/4,z+3/4",
"x+1/4,y+3/4,-z+1/2",
"-x+1/4,-y+3/4,z+1/2",
"-x+1/4,y+3/4,z+1/4",
"x+1/4,y+3/4,-z+3/4",
"x+1/4,-z,y+3/4",
"x+1/4,-z+1/2,x+3/4",
"-x+1/4,z+1/2,-x+3/4",
"x+1/4,-z+1/2,y+3/4",
"-x+1/4,-z+1/4,-x+1/4",
"x+1/4,z+1/4,y+1/4",
"-x+1/4,-z+1/4,-y+1/4",
"x+1/4,-z+1/4,y+3/4",
"x+1/4,-z+3/4,x+3/4",
"-x+1/4,-z+3/4,y",
"-x+1/4,-z+3/4,y+1/2",
"-x+1/4,z+3/4,y+1/4",
"x+1/4,z+3/4,-y+3/4",
"x+1/4,-z+3/4,y+3/4",
"-x+1/4,-z+3/4,y+3/4",
"-x+3/4,0,1/4",
"x+3/4,0,3/4",
"x+3/4,1/2,1/4",
"x+3/4,1/4,1/4",
"x+3/4,1/4,3/4",
"-x+3/4,1/8,5/8",
"-x+3/4,3/4,1/4",
"-x+3/4,3/4,3/4",
"x+3/4,3/8,3/8",
"x+3/4,3/8,7/8",
"-x+3/4,5/8,1/8",
"x+3/4,7/8,7/8",
"-x+3/4,x,-x+1/4",
"x+3/4,-x,x+3/4",
"-x+3/4,x+1/2,-x+1/4",
"x+3/4,x+1/4,-x",
"x+3/4,x+1/4,-x+1/2",
"-x+3/4,-x+1/4,x+1/2",
"x+3/4,x+1/4,-x+1/4",
"x+3/4,x+1/4,-x+3/4",
"x+3/4,-x+1/4,-x+3/4",
"-x+3/4,x+1/4,x+3/4",
"x+3/4,x+1/4,-z+1/2",
"-x+3/4,-x+1/4,z+1/2",
"x+3/4,x+1/4,-z+3/4",
"x+3/4,x+3/4,-x",
"x+3/4,-x+3/4,x+1/4",
"-x+3/4,x+3/4,x+1/4",
"-x+3/4,x+3/4,-x+1/4",
"-x+3/4,-x+3/4,-x+3/4",
"-x+3/4,x+3/4,z+1/4",
"x+3/4,-y,z+3/4",
"-x+3/4,y,-z+3/4",
"x+3/4,-y+1/2,z+1/4",
"-x+3/4,y+1/2,-z+1/4",
"x+3/4,y+1/4,-z+1/2",
"-x+3/4,-y+1/4,z+1/2",
"x+3/4,y+1/4,-z+1/4",
"-x+3/4,y+1/4,z+3/4",
"x+3/4,y+3/4,-z",
"-x+3/4,-y+3/4,z",
"x+3/4,-y+3/4,z+1/4",
"-x+3/4,-y+3/4,-z+3/4",
"-x+3/4,z,-y+1/4",
"-x+3/4,z+1/2,-y+1/4",
"x+3/4,z+1/4,-x+1/2",
"-x+3/4,-z+1/4,x+1/2",
"x+3/4,z+1/4,-x+3/4",
"x+3/4,z+1/4,-y",
"x+3/4,z+1/4,-y+1/2",
"x+3/4,z+1/4,-y+1/4",
"x+3/4,z+1/4,-y+3/4",
"x+3/4,-z+1/4,-y+3/4",
"-x+3/4,z+1/4,y+3/4",
"-x+3/4,z+3/4,x+1/4",
"x+3/4,-z+3/4,y+1/4",
"-x+3/4,z+3/4,y+1/4",
"-x+3/4,z+3/4,-y+1/4",
"-x+3/4,-z+3/4,-y+3/4",
"-x+y,-x,0",
"-x+y,-x,1/2",
"-x+y,-x,1/4",
"-x+y,-x,z",
"-x+y,-x,-z",
"-x+y,-x,-z+1/2",
"-x+y,-x,z+1/3",
"-x+y,-x,z+2/3",
"-x+y,y,0",
"-x+y,y,1/2",
"-x+y,y,1/4",
"-x+y,y,3/4",
"-x+y,y,z",
"-x+y,y,-z",
"-x+y,y,z+1/2",
"-x+y,y,-z+1/2",
"-x+y,y,-z+1/3",
"-x+y,y,-z+2/3",
"x-y,x,0",
"x-y,x,1/2",
"x-y,x,3/4",
"x-y,x,z",
"x-y,x,-z",
"x-y,x,z+1/2",
"x-y,x,z+1/3",
"x-y,x,z+1/6",
"x-y,x,z+2/3",
"x-y,x,z+5/6",
"x-y,-y,0",
"x-y,-y,1/2",
"x-y,-y,1/4",
"x-y,-y,3/4",
"x-y,-y,z",
"x-y,-y,-z",
"x-y,-y,z+1/2",
"x-y,-y,-z+1/2",
"x-y,-y,-z+1/3",
"x-y,-y,-z+2/3",
"y,0,1/4",
"-y,0,1/4",
"y,0,3/4",
"-y,0,3/4",
"y,0,y",
"y,0,-y",
"-y,0,y",
"-y,0,-y",
"y,0,y+1/2",
"-y,0,-y+1/2",
"y,0,z",
"y,0,-z",
"-y,0,z",
"-y,0,-z",
"y,0,z+1/2",
"y,0,-z+1/2",
"-y,0,z+1/2",
"-y,0,-z+1/2",
"y,1/2,1/4",
"-y,1/2,1/4",
"y,1/2,3/4",
"-y,1/2,3/4",
"y,1/2,y",
"y,1/2,-y",
"-y,1/2,y",
"-y,1/2,-y",
"y,1/2,y+1/2",
"-y,1/2,-y+1/2",
"y,1/2,z",
"y,1/2,-z",
"-y,1/2,z",
"-y,1/2,-z",
"y,1/2,z+1/2",
"y,1/2,-z+1/2",
"-y,1/2,z+1/2",
"-y,1/2,-z+1/2",
"-y,1/2,z+1/4",
"y,1/4,y",
"y,1/4,-y",
"-y,1/4,y",
"-y,1/4,-y",
"y,1/4,y+1/2",
"y,1/4,-y+1/2",
"-y,1/4,y+1/2",
"-y,1/4,-y+1/2",
"y,1/4,z",
"y,1/4,z+1/2",
"y,1/8,-y+1/4",
"-y,3/4,3/8",
"y,3/4,7/8",
"y,3/4,y",
"y,3/4,-y",
"-y,3/4,y",
"-y,3/4,-y",
"y,3/4,y+1/2",
"y,3/4,-y+1/2",
"-y,3/4,y+1/2",
"-y,3/4,-y+1/2",
"-y,3/4,-z",
"-y,3/4,-z+1/2",
"-y,3/8,-y+1/4",
"-y,5/8,y+1/4",
"y,7/8,y+1/4",
"y,x,0",
"y,-x,0",
"-y,x,0",
"-y,-x,0",
"y,x,1/2",
"y,-x,1/2",
"-y,x,1/2",
"-y,-x,1/2",
"y,x,1/4",
"-y,-x,1/4",
"y,x,3/4",
"-y,-x,3/4",
"y,x,z",
"y,x,-z",
"y,-x,z",
"y,-x,-z",
"-y,x,z",
"-y,x,-z",
"-y,-x,z",
"-y,-x,-z",
"y,x,z+1/2",
"y,x,-z+1/2",
"y,-x,z+1/2",
"y,-x,-z+1/2",
"-y,x,z+1/2",
"-y,x,-z+1/2",
"-y,-x,z+1/2",
"-y,-x,-z+1/2",
"y,x,-z+1/3",
"-y,-x,-z+1/3",
"y,x,-z+1/4",
"y,-x,z+1/4",
"-y,x,z+1/4",
"-y,-x,-z+1/4",
"-y,-x,-z+1/6",
"y,x,-z+2/3",
"-y,-x,-z+2/3",
"y,x,-z+3/4",
"y,-x,z+3/4",
"-y,x,z+3/4",
"-y,-x,-z+3/4",
"-y,-x,-z+5/6",
"y,-x+1/2,z",
"-y,x+1/2,-z",
"-y,-x+1/2,z",
"y,-x+1/2,z+1/2",
"y,-x+1/2,-z+1/2",
"-y,x+1/2,z+1/2",
"-y,x+1/2,-z+1/2",
"y,x+1/2,z+1/4",
"-y,x+1/2,z+1/4",
"-y,-x+1/2,z+1/4",
"y,x+1/2,z+3/4",
"-y,-x+1/2,z+3/4",
"y,-x+1/4,-z+3/4",
"-y,x+3/4,z+1/4",
"y,-x+y,0",
"y,-x+y,1/2",
"y,-x+y,3/4",
"y,-x+y,z",
"y,-x+y,-z",
"y,-x+y,z+1/2",
"y,-x+y,z+1/3",
"y,-x+y,z+1/6",
"y,-x+y,z+2/3",
"y,-x+y,z+5/6",
"-y,x-y,0",
"-y,x-y,1/2",
"-y,x-y,1/4",
"-y,x-y,z",
"-y,x-y,-z",
"-y,x-y,-z+1/2",
"-y,x-y,z+1/3",
"-y,x-y,z+2/3",
"y,y,0",
"y,-y,0",
"-y,y,0",
"-y,-y,0",
"y,y,1/2",
"y,-y,1/2",
"-y,y,1/2",
"-y,-y,1/2",
"y,y,1/4",
"y,-y,1/4",
"-y,y,1/4",
"-y,-y,1/4",
"y,y,3/4",
"y,-y,3/4",
"-y,y,3/4",
"-y,-y,3/4",
"y,y+1/2,0",
"-y,-y+1/2,0",
"y,y+1/2,1/2",
"-y,-y+1/2,1/2",
"y,y+1/2,1/4",
"y,-y+1/2,1/4",
"-y,y+1/2,1/4",
"-y,-y+1/2,1/4",
"y,y+1/2,3/4",
"y,-y+1/2,3/4",
"-y,y+1/2,3/4",
"-y,-y+1/2,3/4",
"y,y+1/4,1/8",
"y,-y+1/4,1/8",
"y,y+1/4,5/8",
"-y,y+1/4,5/8",
"-y,y+3/4,3/8",
"-y,-y+3/4,3/8",
"-y,y+3/4,7/8",
"y,z,0",
"y,-z,0",
"-y,z,0",
"-y,-z,0",
"y,z,1/2",
"y,-z,1/2",
"-y,z,1/2",
"-y,-z,1/2",
"y,z,x",
"y,z,-x",
"y,-z,x",
"y,-z,-x",
"-y,z,x",
"-y,z,-x",
"-y,-z,x",
"-y,-z,-x",
"y,-z+1/2,x+1/2",
"y,-z+1/2,-x+1/2",
"-y,z+1/2,x+1/2",
"-y,z+1/2,-x+1/2",
"-y,-z+1/2,x+1/2",
"y,-z+1/4,-x+1/4",
"-y,z+3/4,x+3/4",
"y+1/2,0,y",
"-y+1/2,0,-y",
"y+1/2,0,-y+1/2",
"-y+1/2,0,y+1/2",
"y+1/2,0,y+1/4",
"-y+1/2,0,-y+3/4",
"y+1/2,0,z+3/4",
"y+1/2,1/2,y",
"-y+1/2,1/2,-y",
"y+1/2,1/2,y+1/2",
"y+1/2,1/2,-y+1/2",
"-y+1/2,1/2,y+1/2",
"-y+1/2,1/2,-y+1/2",
"y+1/2,1/2,z",
"-y+1/2,1/2,z",
"y+1/2,1/2,z+1/2",
"y+1/2,1/2,-z+1/2",
"-y+1/2,1/2,z+1/2",
"-y+1/2,1/2,-z+1/2",
"y+1/2,1/4,y",
"y+1/2,1/4,-y",
"-y+1/2,1/4,y",
"-y+1/2,1/4,-y",
"-y+1/2,1/4,-y+1/2",
"y+1/2,1/4,y+3/4",
"-y+1/2,1/4,z",
"-y+1/2,1/4,z+1/2",
"-y+1/2,1/8,y+3/4",
"-y+1/2,3/4,3/8",
"y+1/2,3/4,7/8",
"y+1/2,3/4,y",
"y+1/2,3/4,-y",
"-y+1/2,3/4,y",
"-y+1/2,3/4,-y",
"y+1/2,3/4,y+1/2",
"-y+1/2,3/4,-y+1/4",
"y+1/2,3/4,-z",
"y+1/2,3/4,-z+1/2",
"y+1/2,3/8,y+3/4",
"y+1/2,5/8,-y+3/4",
"-y+1/2,7/8,-y+3/4",
"y+1/2,-x,-z",
"-y+1/2,x,z",
"-y+1/2,x,-z",
"y+1/2,-x,z+1/2",
"y+1/2,-x,-z+1/2",
"-y+1/2,x,z+1/2",
"-y+1/2,x,-z+1/2",
"-y+1/2,-x,z+1/2",
"y+1/2,x,z+1/4",
"-y+1/2,-x,z+1/4",
"y+1/2,x,z+3/4",
"y+1/2,-x,z+3/4",
"-y+1/2,-x,z+3/4",
"y+1/2,x+1/2,0",
"-y+1/2,-x+1/2,0",
"y+1/2,x+1/2,1/2",
"y+1/2,-x+1/2,1/2",
"-y+1/2,x+1/2,1/2",
"-y+1/2,-x+1/2,1/2",
"y+1/2,x+1/2,z",
"y+1/2,x+1/2,-z",
"y+1/2,-x+1/2,z",
"y+1/2,-x+1/2,-z",
"-y+1/2,x+1/2,z",
"-y+1/2,x+1/2,-z",
"-y+1/2,-x+1/2,z",
"-y+1/2,-x+1/2,-z",
"y+1/2,x+1/2,z+1/2",
"y+1/2,x+1/2,-z+1/2",
"y+1/2,-x+1/2,z+1/2",
"y+1/2,-x+1/2,-z+1/2",
"-y+1/2,x+1/2,z+1/2",
"-y+1/2,x+1/2,-z+1/2",
"-y+1/2,-x+1/2,z+1/2",
"-y+1/2,-x+1/2,-z+1/2",
"y+1/2,-x+1/2,z+1/4",
"-y+1/2,x+1/2,z+1/4",
"y+1/2,-x+1/2,z+3/4",
"-y+1/2,x+1/2,z+3/4",
"y+1/2,-x+1/4,-z+3/4",
"-y+1/2,x+3/4,z+1/4",
"y+1/2,y,0",
"-y+1/2,-y,0",
"y+1/2,y,1/2",
"-y+1/2,-y,1/2",
"y+1/2,y,1/4",
"y+1/2,-y,1/4",
"-y+1/2,y,1/4",
"-y+1/2,-y,1/4",
"y+1/2,y,3/4",
"y+1/2,-y,3/4",
"-y+1/2,y,3/4",
"-y+1/2,-y,3/4",
"y+1/2,-y+1/2,0",
"-y+1/2,y+1/2,0",
"y+1/2,y+1/2,1/2",
"y+1/2,-y+1/2,1/2",
"-y+1/2,y+1/2,1/2",
"-y+1/2,-y+1/2,1/2",
"-y+1/2,-y+1/2,1/4",
"y+1/2,y+1/2,3/4",
"y+1/2,y+1/4,1/2",
"-y+1/2,-y+1/4,3/4",
"y+1/2,-y+1/4,3/8",
"y+1/2,y+1/4,7/8",
"y+1/2,-y+1/4,7/8",
"-y+1/2,-y+3/4,1/2",
"y+1/2,y+3/4,1/4",
"-y+1/2,-y+3/4,1/8",
"y+1/2,y+3/4,3/8",
"-y+1/2,y+3/4,5/8",
"-y+1/2,-y+3/4,5/8",
"-y+1/2,-y+3/4,7/8",
"y+1/2,z,-x+1/2",
"y+1/2,-z,x+1/2",
"y+1/2,-z,-x+1/2",
"-y+1/2,z,-x+1/2",
"-y+1/2,-z,x+1/2",
"y+1/2,z+1/2,-x",
"y+1/2,-z+1/2,-x",
"-y+1/2,z+1/2,x",
"-y+1/2,z+1/2,-x",
"-y+1/2,-z+1/2,x",
"y+1/2,z+1/2,-x+1/2",
"y+1/2,-z+1/2,x+1/2",
"-y+1/2,z+1/2,x+1/2",
"-y+1/2,-z+1/2,-x+1/2",
"y+1/2,-z+1/4,-x+3/4",
"-y+1/2,z+1/4,x+3/4",
"y+1/2,-z+3/4,-x+1/4",
"-y+1/2,z+3/4,x+1/4",
"y+1/4,1/2,y+1/2",
"y+1/4,1/2,-y+3/4",
"-y+1/4,1/4,y+3/4",
"y+1/4,1/4,z+3/4",
"-y+1/4,1/4,-z+3/4",
"y+1/4,1/8,y",
"-y+1/4,1/8,y",
"-y+1/4,3/4,-y+1/2",
"y+1/4,3/4,-z+1/4",
"-y+1/4,3/4,z+1/4",
"-y+1/4,3/8,y+1/2",
"y+1/4,5/8,y",
"y+1/4,5/8,-y",
"y+1/4,7/8,y+1/2",
"-y+1/4,7/8,y+1/2",
"y+1/4,-x,z+3/4",
"y+1/4,-x+1/2,z+3/4",
"y+1/4,x+1/4,z+1/4",
"-y+1/4,x+1/4,-z+1/4",
"-y+1/4,-x+1/4,-z+1/4",
"y+1/4,-x+1/4,z+3/4",
"-y+1/4,-x+1/4,-z+3/4",
"-y+1/4,-x+3/4,z",
"-y+1/4,-x+3/4,z+1/2",
"y+1/4,x+3/4,-z+1/4",
"-y+1/4,x+3/4,z+1/4",
"y+1/4,x+3/4,-z+3/4",
"y+1/4,-x+3/4,z+3/4",
"y+1/4,-x+3/4,-z+3/4",
"-y+1/4,-x+3/4,z+3/4",
"-y+1/4,y,1/8",
"-y+1/4,-y,3/8",
"y+1/4,-y,5/8",
"y+1/4,y,7/8",
"y+1/4,y+1/2,0",
"-y+1/4,-y+1/2,3/4",
"y+1/4,-y+3/4,1/2",
"-y+1/4,y+3/4,3/4",
"-y+1/4,z,-x+1/4",
"y+1/4,-z+1/2,x+3/4",
"-y+1/4,z+1/2,-x+3/4",
"-y+1/4,-z+1/4,x",
"y+1/4,z+1/4,-x+1/4",
"y+1/4,-z+1/4,x+1/4",
"-y+1/4,z+1/4,x+1/4",
"-y+1/4,-z+1/4,-x+1/4",
"y+1/4,-z+1/4,x+3/4",
"y+1/4,z+3/4,-x+1/2",
"-y+1/4,-z+3/4,x+1/2",
"-y+1/4,z+3/4,x+1/4",
"y+1/4,z+3/4,-x+3/4",
"-y+3/4,1/2,-y+1/2",
"-y+3/4,1/2,y+1/4",
"y+3/4,1/4,y+1/2",
"-y+3/4,1/8,-y+1/2",
"y+3/4,3/4,-y+1/4",
"y+3/4,3/8,-y",
"-y+3/4,3/8,-y",
"y+3/4,3/8,y+1/2",
"y+3/4,5/8,-y+1/2",
"-y+3/4,5/8,-y+1/2",
"y+3/4,7/8,-y",
"-y+3/4,7/8,-y+1/2",
"-y+3/4,x,-z+1/4",
"-y+3/4,x+1/2,-z+1/4",
"y+3/4,x+1/4,-z",
"y+3/4,x+1/4,-z+1/2",
"y+3/4,x+1/4,-z+1/4",
"-y+3/4,x+1/4,z+1/4",
"-y+3/4,-x+1/4,z+1/4",
"y+3/4,x+1/4,-z+3/4",
"y+3/4,-x+1/4,-z+3/4",
"-y+3/4,x+1/4,z+3/4",
"-y+3/4,-x+1/4,z+3/4",
"y+3/4,x+3/4,z+1/4",
"y+3/4,-x+3/4,z+1/4",
"-y+3/4,x+3/4,z+1/4",
"-y+3/4,x+3/4,-z+1/4",
"y+3/4,x+3/4,z+3/4",
"y+3/4,-x+3/4,z+3/4",
"-y+3/4,-x+3/4,-z+3/4",
"-y+3/4,-y+1/2,0",
"y+3/4,y+1/2,1/4",
"y+3/4,-y+1/2,1/8",
"y+3/4,y+1/2,3/8",
"-y+3/4,y+1/2,5/8",
"-y+3/4,-y+1/2,7/8",
"-y+3/4,y+1/4,1/2",
"y+3/4,-y+1/4,1/4",
"y+3/4,-z,x+3/4",
"y+3/4,-z+1/2,x+1/4",
"-y+3/4,z+1/2,-x+1/4",
"y+3/4,z+1/4,-x+1/2",
"-y+3/4,-z+1/4,x+1/2",
"y+3/4,z+1/4,-x+1/4",
"-y+3/4,z+1/4,x+3/4",
"y+3/4,z+3/4,-x",
"y+3/4,-z+3/4,x+1/4",
"-y+3/4,-z+3/4,-x+3/4",
"z,0,y",
"z,0,-y",
"-z,0,y",
"-z,0,-y",
"z,1/2,y",
"z,1/2,-y",
"-z,1/2,y",
"-z,1/2,-y",
"z,x,x",
"z,x,-x",
"z,-x,x",
"z,-x,-x",
"-z,x,x",
"-z,x,-x",
"-z,-x,x",
"-z,-x,-x",
"z,x,y",
"z,x,-y",
"z,-x,y",
"z,-x,-y",
"-z,x,y",
"-z,x,-y",
"-z,-x,y",
"-z,-x,-y",
"z,-x+1/2,-x+1/2",
"-z,x+1/2,x+1/2",
"-z,-x+1/2,x+1/2",
"z,-x+1/2,y+1/2",
"z,-x+1/2,-y+1/2",
"-z,x+1/2,y+1/2",
"-z,x+1/2,-y+1/2",
"-z,-x+1/2,y+1/2",
"z,-x+1/4,-y+1/4",
"-z,x+3/4,y+3/4",
"z,y,0",
"z,-y,0",
"-z,y,0",
"-z,-y,0",
"z,y,1/2",
"z,-y,1/2",
"-z,y,1/2",
"-z,-y,1/2",
"z,y,x",
"z,y,-x",
"z,-y,x",
"z,-y,-x",
"-z,y,x",
"-z,y,-x",
"-z,-y,x",
"-z,-y,-x",
"z,y,-x+1/2",
"z,-y,-x+1/2",
"-z,-y,x+1/2",
"z,-y+1/2,x",
"-z,y+1/2,-x",
"-z,-y+1/2,x",
"z,-y+1/2,-x+1/2",
"-z,y+1/2,x+1/2",
"-z,y+1/2,-x+1/2",
"z,-y+1/4,-x+3/4",
"-z,y+3/4,x+1/4",
"z+1/2,-x,x+1/2",
"z+1/2,-x,-x+1/2",
"-z+1/2,x,-x+1/2",
"z+1/2,x,-y+1/2",
"z+1/2,-x,y+1/2",
"z+1/2,-x,-y+1/2",
"-z+1/2,x,-y+1/2",
"-z+1/2,-x,y+1/2",
"z+1/2,x+1/2,-x",
"-z+1/2,x+1/2,-x",
"-z+1/2,-x+1/2,x",
"z+1/2,x+1/2,-x+1/2",
"z+1/2,-x+1/2,x+1/2",
"-z+1/2,x+1/2,x+1/2",
"-z+1/2,-x+1/2,-x+1/2",
"z+1/2,x+1/2,-y",
"z+1/2,-x+1/2,-y",
"-z+1/2,x+1/2,y",
"-z+1/2,x+1/2,-y",
"-z+1/2,-x+1/2,y",
"z+1/2,x+1/2,-y+1/2",
"z+1/2,-x+1/2,y+1/2",
"-z+1/2,x+1/2,y+1/2",
"-z+1/2,-x+1/2,-y+1/2",
"z+1/2,-x+1/4,-y+3/4",
"-z+1/2,x+1/4,y+3/4",
"z+1/2,-x+3/4,-x+1/4",
"-z+1/2,x+3/4,x+1/4",
"z+1/2,-x+3/4,-y+1/4",
"-z+1/2,x+3/4,y+1/4",
"z+1/2,-y,-x",
"-z+1/2,y,x",
"-z+1/2,y,-x",
"z+1/2,-y,x+1/2",
"-z+1/2,y,-x+1/2",
"-z+1/2,-y,x+1/2",
"z+1/2,y+1/2,1/2",
"z+1/2,-y+1/2,1/2",
"-z+1/2,y+1/2,1/2",
"-z+1/2,-y+1/2,1/2",
"z+1/2,y+1/2,-x",
"z+1/2,-y+1/2,-x",
"-z+1/2,-y+1/2,x",
"z+1/2,y+1/2,x+1/2",
"z+1/2,y+1/2,-x+1/2",
"z+1/2,-y+1/2,x+1/2",
"z+1/2,-y+1/2,-x+1/2",
"-z+1/2,y+1/2,x+1/2",
"-z+1/2,y+1/2,-x+1/2",
"-z+1/2,-y+1/2,x+1/2",
"-z+1/2,-y+1/2,-x+1/2",
"z+1/2,-y+1/4,-x+3/4",
"-z+1/2,y+3/4,x+1/4",
"-z+1/4,x,-y+1/4",
"z+1/4,-x+1/2,x+3/4",
"-z+1/4,x+1/2,-x+3/4",
"z+1/4,-x+1/2,y+3/4",
"-z+1/4,x+1/2,-y+3/4",
"-z+1/4,-x+1/4,-x+1/4",
"-z+1/4,-x+1/4,y",
"z+1/4,x+1/4,-y+1/4",
"z+1/4,-x+1/4,y+1/4",
"-z+1/4,x+1/4,y+1/4",
"-z+1/4,-x+1/4,-y+1/4",
"z+1/4,-x+1/4,y+3/4",
"z+1/4,-x+3/4,x+3/4",
"z+1/4,x+3/4,-y+1/2",
"-z+1/4,-x+3/4,y+1/2",
"-z+1/4,x+3/4,y+1/4",
"z+1/4,x+3/4,-y+3/4",
"z+1/4,-y,x+3/4",
"z+1/4,-y+1/2,x+3/4",
"z+1/4,y+1/4,x+1/4",
"-z+1/4,-y+1/4,-x+1/4",
"z+1/4,-y+1/4,x+3/4",
"-z+1/4,-y+3/4,x",
"-z+1/4,-y+3/4,x+1/2",
"-z+1/4,y+3/4,x+1/4",
"z+1/4,y+3/4,-x+3/4",
"z+1/4,-y+3/4,x+3/4",
"-z+1/4,-y+3/4,x+3/4",
"z+3/4,-x,y+3/4",
"z+3/4,-x+1/2,y+1/4",
"-z+3/4,x+1/2,-y+1/4",
"z+3/4,x+1/4,-x+1/2",
"-z+3/4,-x+1/4,x+1/2",
"z+3/4,x+1/4,-x+3/4",
"z+3/4,x+1/4,-y+1/2",
"-z+3/4,-x+1/4,y+1/2",
"z+3/4,x+1/4,-y+1/4",
"-z+3/4,x+1/4,y+3/4",
"-z+3/4,x+3/4,x+1/4",
"z+3/4,x+3/4,-y",
"z+3/4,-x+3/4,y+1/4",
"-z+3/4,-x+3/4,-y+3/4",
"-z+3/4,y,-x+1/4",
"-z+3/4,y+1/2,-x+1/4",
"z+3/4,y+1/4,-x",
"z+3/4,y+1/4,-x+1/2",
"z+3/4,y+1/4,-x+1/4",
"z+3/4,y+1/4,-x+3/4",
"z+3/4,-y+1/4,-x+3/4",
"-z+3/4,y+1/4,x+3/4",
"z+3/4,-y+3/4,x+1/4",
"-z+3/4,y+3/4,x+1/4",
"-z+3/4,y+3/4,-x+1/4",
"-z+3/4,-y+3/4,-x+3/4"
            #endregion CoodStr
        };

    public static readonly ushort[][] OperationDictionary = new ushort[][]
        {
				#region OperationDictionary
 //0	Unknown
new ushort[]{0,},
//1	P1
new ushort[]{0,},
//2	P-1
	new ushort[]{0,1,},
//3	P2=P121
	new ushort[]{0,2,},
//4	P2=P112
	new ushort[]{0,3,},
//5	P2=P211
	new ushort[]{0,4,},
//6	P2sub1=P12sub11
	new ushort[]{0,5,},
//7	P2sub1=P112sub1
	new ushort[]{0,6,},
//8	P2sub1=P2sub111
	new ushort[]{0,7,},
//9	C2=C121
	new ushort[]{0,2,},
//10	C2=A121
	new ushort[]{0,2,},
//11	C2=I121
	new ushort[]{0,2,},
//12	C2=A112
	new ushort[]{0,3,},
//13	C2=B112=B2
	new ushort[]{0,3,},
//14	C2=I112
	new ushort[]{0,3,},
//15	C2=B211
	new ushort[]{0,4,},
//16	C2=C211
	new ushort[]{0,4,},
//17	C2=I211
	new ushort[]{0,4,},
//18	Pm=P1m1
	new ushort[]{0,8,},
//19	Pm=P11m
	new ushort[]{0,9,},
//20	Pm=Pm11
	new ushort[]{0,10,},
//21	Pc=P1c1
	new ushort[]{0,11,},
//22	Pc=P1n1
	new ushort[]{0,12,},
//23	Pc=P1a1
	new ushort[]{0,13,},
//24	Pc=P11a
	new ushort[]{0,14,},
//25	Pc=P11n
	new ushort[]{0,15,},
//26	Pc=P11b=Pb
	new ushort[]{0,16,},
//27	Pc=Pb11
	new ushort[]{0,17,},
//28	Pc=Pn11
	new ushort[]{0,18,},
//29	Pc=Pc11
	new ushort[]{0,19,},
//30	Cm=C1m1
	new ushort[]{0,8,},
//31	Cm=A1m1
	new ushort[]{0,8,},
//32	Cm=I1m1
	new ushort[]{0,8,},
//33	Cm=A11m
	new ushort[]{0,9,},
//34	Cm=B11m=Bm
	new ushort[]{0,9,},
//35	Cm=I11m
	new ushort[]{0,9,},
//36	Cm=Bm11
	new ushort[]{0,10,},
//37	Cm=Cm11
	new ushort[]{0,10,},
//38	Cm=Im11
	new ushort[]{0,10,},
//39	Cc=C1c1
	new ushort[]{0,11,},
//40	Cc=A1n1
	new ushort[]{0,12,},
//41	Cc=I1a1
	new ushort[]{0,13,},
//42	Cc=A1a1
	new ushort[]{0,13,},
//43	Cc=C1n1
	new ushort[]{0,12,},
//44	Cc=I1c1
	new ushort[]{0,11,},
//45	Cc=A11a
	new ushort[]{0,14,},
//46	Cc=B11n
	new ushort[]{0,15,},
//47	Cc=I11b
	new ushort[]{0,16,},
//48	Cc=B11b=Bb
	new ushort[]{0,16,},
//49	Cc=A11n
	new ushort[]{0,15,},
//50	Cc=I11a
	new ushort[]{0,14,},
//51	Cc=Bb11
	new ushort[]{0,17,},
//52	Cc=Cn11
	new ushort[]{0,18,},
//53	Cc=Ic11
	new ushort[]{0,19,},
//54	Cc=Cc11
	new ushort[]{0,19,},
//55	Cc=Bn11
	new ushort[]{0,18,},
//56	Cc=Ib11
	new ushort[]{0,17,},
//57	P2/m=P12/m1
	new ushort[]{0,2,1,8,},
//58	P2/m=P112/m
	new ushort[]{0,3,1,9,},
//59	P2/m=P2/m11
	new ushort[]{0,4,1,10,},
//60	P2sub1/m=P12sub1/m1
	new ushort[]{0,5,1,20,},
//61	P2sub1/m=P112sub1/m
	new ushort[]{0,6,1,21,},
//62	P2sub1/m=P2sub1/m11
	new ushort[]{0,7,1,22,},
//63	C2/m=C12/m1
	new ushort[]{0,2,1,8,},
//64	C2/m=A12/m1
	new ushort[]{0,2,1,8,},
//65	C2/m=I12/m1
	new ushort[]{0,2,1,8,},
//66	C2/m=A112/m
	new ushort[]{0,3,1,9,},
//67	C2/m=B112/m=B2/m
	new ushort[]{0,3,1,9,},
//68	C2/m=I112/m
	new ushort[]{0,3,1,9,},
//69	C2/m=B2/m11
	new ushort[]{0,4,1,10,},
//70	C2/m=C2/m11
	new ushort[]{0,4,1,10,},
//71	C2/m=I2/m11
	new ushort[]{0,4,1,10,},
//72	P2/c=P12/c1
	new ushort[]{0,23,1,11,},
//73	P2/c=P12/n1
	new ushort[]{0,24,1,12,},
//74	P2/c=P12/a1
	new ushort[]{0,25,1,13,},
//75	P2/c=P112/a
	new ushort[]{0,26,1,14,},
//76	P2/c=P112/n
	new ushort[]{0,27,1,15,},
//77	P2/c=P112/b=P2/b
	new ushort[]{0,28,1,16,},
//78	P2/c=P2/b11
	new ushort[]{0,29,1,17,},
//79	P2/c=P2/n11
	new ushort[]{0,30,1,18,},
//80	P2/c=P2/c11
	new ushort[]{0,31,1,19,},
//81	P2sub1/c=P12sub1/c1
	new ushort[]{0,32,1,33,},
//82	P2sub1/c=P12sub1/n1
	new ushort[]{0,34,1,35,},
//83	P2sub1/c=P12sub1/a1
	new ushort[]{0,36,1,37,},
//84	P2sub1/c=P112sub1/a
	new ushort[]{0,38,1,39,},
//85	P2sub1/c=P112sub1/n
	new ushort[]{0,40,1,41,},
//86	P2sub1/c=P112sub1/b=P2sub1/b
	new ushort[]{0,42,1,43,},
//87	P2sub1/c=P2sub1/b11
	new ushort[]{0,44,1,45,},
//88	P2sub1/c=P2sub1/n11
	new ushort[]{0,46,1,47,},
//89	P2sub1/c=P2sub1/c11
	new ushort[]{0,48,1,49,},
//90	C2/c=C12/c1
	new ushort[]{0,23,1,11,},
//91	C2/c=A12/n1
	new ushort[]{0,24,1,12,},
//92	C2/c=I12/a1
	new ushort[]{0,25,1,13,},
//93	C2/c=A12/a1
	new ushort[]{0,25,1,13,},
//94	C2/c=C12/n1
	new ushort[]{0,24,1,12,},
//95	C2/c=I12/c1
	new ushort[]{0,23,1,11,},
//96	C2/c=A112/a
	new ushort[]{0,26,1,14,},
//97	C2/c=B112/n
	new ushort[]{0,27,1,15,},
//98	C2/c=I112/b
	new ushort[]{0,28,1,16,},
//99	C2/c=B112/b=B2/b
	new ushort[]{0,28,1,16,},
//100	C2/c=A112/n
	new ushort[]{0,27,1,15,},
//101	C2/c=I112/a
	new ushort[]{0,26,1,14,},
//102	C2/c=B2/b11
	new ushort[]{0,29,1,17,},
//103	C2/c=C2/n11
	new ushort[]{0,30,1,18,},
//104	C2/c=I2/c11
	new ushort[]{0,31,1,19,},
//105	C2/c=C2/c11
	new ushort[]{0,31,1,19,},
//106	C2/c=B2/n11
	new ushort[]{0,30,1,18,},
//107	C2/c=I2/b11
	new ushort[]{0,29,1,17,},
//108	P222
	new ushort[]{0,3,2,4,},
//109	P222sub1
	new ushort[]{0,6,23,4,},
//110	P2sub122
	new ushort[]{0,7,26,2,},
//111	P22sub12
	new ushort[]{0,5,29,3,},
//112	P2sub12sub12
	new ushort[]{0,3,36,44,},
//113	P22sub12sub1
	new ushort[]{0,4,42,32,},
//114	P2sub122sub1
	new ushort[]{0,2,48,38,},
//115	P2sub12sub12sub1
	new ushort[]{0,38,32,44,},
//116	C222sub1
	new ushort[]{0,6,23,4,},
//117	A2sub122
	new ushort[]{0,7,26,2,},
//118	B22sub12
	new ushort[]{0,5,29,3,},
//119	C222
	new ushort[]{0,3,2,4,},
//120	A222
	new ushort[]{0,4,3,2,},
//121	B222
	new ushort[]{0,2,4,3,},
//122	F222
	new ushort[]{0,3,2,4,},
//123	I222
	new ushort[]{0,3,2,4,},
//124	I2sub12sub12sub1
	new ushort[]{0,38,32,44,},
//125	Pmm2
	new ushort[]{0,3,8,10,},
//126	P2mm
	new ushort[]{0,4,9,8,},
//127	Pm2m
	new ushort[]{0,2,10,9,},
//128	Pmc2sub1
	new ushort[]{0,6,11,10,},
//129	Pcm2sub1
	new ushort[]{0,6,19,8,},
//130	P2sub1ma
	new ushort[]{0,7,14,8,},
//131	P2sub1am
	new ushort[]{0,7,13,9,},
//132	Pb2sub1m
	new ushort[]{0,5,17,9,},
//133	Pm2sub1b
	new ushort[]{0,5,16,10,},
//134	Pcc2
	new ushort[]{0,3,11,19,},
//135	P2aa
	new ushort[]{0,4,14,13,},
//136	Pb2b
	new ushort[]{0,2,17,16,},
//137	Pma2
	new ushort[]{0,3,13,22,},
//138	Pbm2
	new ushort[]{0,3,17,20,},
//139	P2mb
	new ushort[]{0,4,16,20,},
//140	P2cm
	new ushort[]{0,4,11,21,},
//141	Pc2m
	new ushort[]{0,2,19,21,},
//142	Pm2a
	new ushort[]{0,2,14,22,},
//143	Pca2sub1
	new ushort[]{0,6,13,49,},
//144	Pbc2sub1
	new ushort[]{0,6,17,33,},
//145	P2sub1ab
	new ushort[]{0,7,16,37,},
//146	P2sub1ca
	new ushort[]{0,7,11,39,},
//147	Pc2sub1b
	new ushort[]{0,5,19,43,},
//148	Pb2sub1a
	new ushort[]{0,5,14,45,},
//149	Pnc2
	new ushort[]{0,3,33,18,},
//150	Pcn2
	new ushort[]{0,3,49,12,},
//151	P2na
	new ushort[]{0,4,39,12,},
//152	P2an
	new ushort[]{0,4,37,15,},
//153	Pb2n
	new ushort[]{0,2,45,15,},
//154	Pn2b
	new ushort[]{0,2,43,18,},
//155	Pmn2sub1
	new ushort[]{0,38,12,10,},
//156	Pnm2sub1
	new ushort[]{0,42,18,8,},
//157	P2sub1mn
	new ushort[]{0,44,15,8,},
//158	P2sub1nm
	new ushort[]{0,48,12,9,},
//159	Pn2sub1m
	new ushort[]{0,32,18,9,},
//160	Pm2sub1n
	new ushort[]{0,36,15,10,},
//161	Pba2
	new ushort[]{0,3,37,45,},
//162	P2cb
	new ushort[]{0,4,43,33,},
//163	Pc2a
	new ushort[]{0,2,49,39,},
//164	Pna2sub1
	new ushort[]{0,6,37,47,},
//165	Pbn2sub1
	new ushort[]{0,6,45,35,},
//166	P2sub1nb
	new ushort[]{0,7,43,35,},
//167	P2sub1cn
	new ushort[]{0,7,33,41,},
//168	Pc2sub1n
	new ushort[]{0,5,49,41,},
//169	Pn2sub1a
	new ushort[]{0,5,39,47,},
//170	Pnn2
	new ushort[]{0,3,35,47,},
//171	P2nn
	new ushort[]{0,4,41,35,},
//172	Pn2n
	new ushort[]{0,2,47,41,},
//173	Cmm2
	new ushort[]{0,3,8,10,},
//174	A2mm
	new ushort[]{0,4,9,8,},
//175	Bm2m
	new ushort[]{0,2,10,9,},
//176	Cmc2sub1
	new ushort[]{0,6,11,10,},
//177	Ccm2sub1
	new ushort[]{0,6,19,8,},
//178	A2sub1ma
	new ushort[]{0,7,14,8,},
//179	A2sub1am
	new ushort[]{0,7,13,9,},
//180	Bb2sub1m
	new ushort[]{0,5,17,9,},
//181	Bm2sub1b
	new ushort[]{0,5,16,10,},
//182	Ccc2
	new ushort[]{0,3,11,19,},
//183	A2aa
	new ushort[]{0,4,14,13,},
//184	Bb2b
	new ushort[]{0,2,17,16,},
//185	Amm2
	new ushort[]{0,3,8,10,},
//186	Bmm2
	new ushort[]{0,3,10,8,},
//187	B2mm
	new ushort[]{0,4,9,8,},
//188	C2mm
	new ushort[]{0,4,8,9,},
//189	Cm2m
	new ushort[]{0,2,10,9,},
//190	Am2m
	new ushort[]{0,2,9,10,},
//191	Aem2
	new ushort[]{0,3,20,17,},
//192	Bme2
	new ushort[]{0,3,22,13,},
//193	B2em
	new ushort[]{0,4,21,11,},
//194	C2me
	new ushort[]{0,4,20,16,},
//195	Cm2e
	new ushort[]{0,2,22,14,},
//196	Ae2m
	new ushort[]{0,2,21,19,},
//197	Ama2
	new ushort[]{0,3,13,22,},
//198	Bbm2
	new ushort[]{0,3,17,20,},
//199	B2mb
	new ushort[]{0,4,16,20,},
//200	C2cm
	new ushort[]{0,4,11,21,},
//201	Cc2m
	new ushort[]{0,2,19,21,},
//202	Am2a
	new ushort[]{0,2,14,22,},
//203	Aea2
	new ushort[]{0,3,37,45,},
//204	Bbe2
	new ushort[]{0,3,45,37,},
//205	B2eb
	new ushort[]{0,4,43,33,},
//206	C2ce
	new ushort[]{0,4,33,43,},
//207	Cc2e
	new ushort[]{0,2,49,39,},
//208	Ae2a
	new ushort[]{0,2,39,49,},
//209	Fmm2
	new ushort[]{0,3,8,10,},
//210	F2mm
	new ushort[]{0,4,9,8,},
//211	Fm2m
	new ushort[]{0,2,10,9,},
//212	Fdd2
	new ushort[]{0,3,50,51,},
//213	F2dd
	new ushort[]{0,4,52,50,},
//214	Fd2d
	new ushort[]{0,2,51,52,},
//215	Imm2
	new ushort[]{0,3,8,10,},
//216	I2mm
	new ushort[]{0,4,9,8,},
//217	Im2m
	new ushort[]{0,2,10,9,},
//218	Iba2
	new ushort[]{0,3,37,45,},
//219	I2cb
	new ushort[]{0,4,43,33,},
//220	Ic2a
	new ushort[]{0,2,49,39,},
//221	Ima2
	new ushort[]{0,3,13,22,},
//222	Ibm2
	new ushort[]{0,3,17,20,},
//223	I2mb
	new ushort[]{0,4,16,20,},
//224	I2cm
	new ushort[]{0,4,11,21,},
//225	Ic2m
	new ushort[]{0,2,19,21,},
//226	Im2a
	new ushort[]{0,2,14,22,},
//227	Pmmm
	new ushort[]{0,3,2,4,1,9,8,10,},
//228	Pnnn(1)
	new ushort[]{0,3,2,4,53,41,35,47,},
//229	Pnnn(2)
	new ushort[]{0,27,24,30,1,15,12,18,},
//230	Pccm
	new ushort[]{0,3,23,31,1,9,11,19,},
//231	Pmaa
	new ushort[]{0,4,26,25,1,10,14,13,},
//232	Pbmb
	new ushort[]{0,2,29,28,1,8,17,16,},
//233	Pban(1)
	new ushort[]{0,3,2,4,54,15,37,45,},
//234	Pban(2)
	new ushort[]{0,27,25,29,1,15,13,17,},
//235	Pncb(1)
	new ushort[]{0,4,3,2,55,18,43,33,},
//236	Pncb(2)
	new ushort[]{0,30,28,23,1,18,16,11,},
//237	Pcna(1)
	new ushort[]{0,2,4,3,56,12,49,39,},
//238	Pcna(2)
	new ushort[]{0,24,31,26,1,12,19,14,},
//239	Pmma
	new ushort[]{0,26,2,7,1,14,8,22,},
//240	Pmmb
	new ushort[]{0,28,4,5,1,16,10,20,},
//241	Pbmm
	new ushort[]{0,29,3,5,1,17,9,20,},
//242	Pcmm
	new ushort[]{0,31,2,6,1,19,8,21,},
//243	Pmcm
	new ushort[]{0,23,4,6,1,11,10,21,},
//244	Pmam
	new ushort[]{0,25,3,7,1,13,9,22,},
//245	Pnna
	new ushort[]{0,26,34,30,1,14,35,18,},
//246	Pnnb
	new ushort[]{0,28,46,24,1,16,47,12,},
//247	Pbnn
	new ushort[]{0,29,40,24,1,17,41,12,},
//248	Pcnn
	new ushort[]{0,31,34,27,1,19,35,15,},
//249	Pncn
	new ushort[]{0,23,46,27,1,11,47,15,},
//250	Pnan
	new ushort[]{0,25,40,30,1,13,41,18,},
//251	Pmna
	new ushort[]{0,38,24,4,1,39,12,10,},
//252	Pnmb
	new ushort[]{0,42,30,2,1,43,18,8,},
//253	Pbmn
	new ushort[]{0,44,27,2,1,45,15,8,},
//254	Pcnm
	new ushort[]{0,48,24,3,1,49,12,9,},
//255	Pncm
	new ushort[]{0,32,30,3,1,33,18,9,},
//256	Pman
	new ushort[]{0,36,27,4,1,37,15,10,},
//257	Pcca
	new ushort[]{0,26,23,48,1,14,11,49,},
//258	Pccb
	new ushort[]{0,28,31,32,1,16,19,33,},
//259	Pbaa
	new ushort[]{0,29,26,36,1,17,14,37,},
//260	Pcaa
	new ushort[]{0,31,25,38,1,19,13,39,},
//261	Pbcb
	new ushort[]{0,23,29,42,1,11,17,43,},
//262	Pbab
	new ushort[]{0,25,28,44,1,13,16,45,},
//263	Pbam
	new ushort[]{0,3,36,44,1,9,37,45,},
//264	Pmcb
	new ushort[]{0,4,42,32,1,10,43,33,},
//265	Pcma
	new ushort[]{0,2,48,38,1,8,49,39,},
//266	Pccn
	new ushort[]{0,27,32,48,1,15,33,49,},
//267	Pnaa
	new ushort[]{0,30,38,36,1,18,39,37,},
//268	Pbnb
	new ushort[]{0,24,44,42,1,12,45,43,},
//269	Pbcm
	new ushort[]{0,6,32,29,1,21,33,17,},
//270	Pcam
	new ushort[]{0,6,48,25,1,21,49,13,},
//271	Pmca
	new ushort[]{0,7,38,23,1,22,39,11,},
//272	Pmab
	new ushort[]{0,7,36,28,1,22,37,16,},
//273	Pbma
	new ushort[]{0,5,44,26,1,20,45,14,},
//274	Pcmb
	new ushort[]{0,5,42,31,1,20,43,19,},
//275	Pnnm
	new ushort[]{0,3,34,46,1,9,35,47,},
//276	Pmnn
	new ushort[]{0,4,40,34,1,10,41,35,},
//277	Pnmn
	new ushort[]{0,2,46,40,1,8,47,41,},
//278	Pmmn(1)
	new ushort[]{0,3,36,44,54,15,8,10,},
//279	Pmmn(2)
	new ushort[]{0,27,5,7,1,15,20,22,},
//280	Pnmm(1)
	new ushort[]{0,4,42,32,55,18,9,8,},
//281	Pnmm(2)
	new ushort[]{0,30,6,5,1,18,21,20,},
//282	Pmnm(1)
	new ushort[]{0,2,48,38,56,12,10,9,},
//283	Pmnm(2)
	new ushort[]{0,24,7,6,1,12,22,21,},
//284	Pbcn
	new ushort[]{0,40,23,44,1,41,11,45,},
//285	Pcan
	new ushort[]{0,40,31,36,1,41,19,37,},
//286	Pnca
	new ushort[]{0,46,26,32,1,47,14,33,},
//287	Pnab
	new ushort[]{0,46,25,42,1,47,13,43,},
//288	Pbna
	new ushort[]{0,34,29,38,1,35,17,39,},
//289	Pcnb
	new ushort[]{0,34,28,48,1,35,16,49,},
//290	Pbca
	new ushort[]{0,38,32,44,1,39,33,45,},
//291	Pcab
	new ushort[]{0,42,48,36,1,43,49,37,},
//292	Pnma
	new ushort[]{0,38,5,46,1,39,20,47,},
//293	Pmnb
	new ushort[]{0,42,7,34,1,43,22,35,},
//294	Pbnm
	new ushort[]{0,44,6,34,1,45,21,35,},
//295	Pcmn
	new ushort[]{0,48,5,40,1,49,20,41,},
//296	Pmcn
	new ushort[]{0,32,7,40,1,33,22,41,},
//297	Pnam
	new ushort[]{0,36,6,46,1,37,21,47,},
//298	Cmcm
	new ushort[]{0,6,23,4,1,21,11,10,},
//299	Ccmm
	new ushort[]{0,6,31,2,1,21,19,8,},
//300	Amma
	new ushort[]{0,7,26,2,1,22,14,8,},
//301	Amam
	new ushort[]{0,7,25,3,1,22,13,9,},
//302	Bbmm
	new ushort[]{0,5,29,3,1,20,17,9,},
//303	Bmmb
	new ushort[]{0,5,28,4,1,20,16,10,},
//304	Cmce
	new ushort[]{0,42,32,4,1,43,33,10,},
//305	Ccme
	new ushort[]{0,38,48,2,1,39,49,8,},
//306	Aema
	new ushort[]{0,48,38,2,1,49,39,8,},
//307	Aeam
	new ushort[]{0,44,36,3,1,45,37,9,},
//308	Bbem
	new ushort[]{0,36,44,3,1,37,45,9,},
//309	Bmeb
	new ushort[]{0,32,42,4,1,33,43,10,},
//310	Cmmm
	new ushort[]{0,3,2,4,1,9,8,10,},
//311	Ammm
	new ushort[]{0,4,3,2,1,10,9,8,},
//312	Bmmm
	new ushort[]{0,2,4,3,1,8,10,9,},
//313	Cccm
	new ushort[]{0,3,23,31,1,9,11,19,},
//314	Amaa
	new ushort[]{0,4,26,25,1,10,14,13,},
//315	Bbmb
	new ushort[]{0,2,29,28,1,8,17,16,},
//316	Cmme
	new ushort[]{0,28,5,4,1,16,20,10,},
//317	Cmme
	new ushort[]{0,28,5,4,1,16,20,10,},
//318	Aemm
	new ushort[]{0,31,6,2,1,19,21,8,},
//319	Aemm
	new ushort[]{0,31,6,2,1,19,21,8,},
//320	Bmem
	new ushort[]{0,25,7,3,1,13,22,9,},
//321	Bmem
	new ushort[]{0,25,7,3,1,13,22,9,},
//322	Ccce(1)
	new ushort[]{0,27,2,44,55,39,33,49,},
//323	Ccce(2)
	new ushort[]{0,26,23,48,1,14,11,49,},
//324	Ccce(1)
	new ushort[]{0,27,2,44,55,39,33,49,},
//325	Ccce(2)
	new ushort[]{0,26,23,48,1,14,11,49,},
//326	Aeaa(1)
	new ushort[]{0,30,3,32,56,45,39,37,},
//327	Aeaa(2)
	new ushort[]{0,29,26,36,1,17,14,37,},
//328	Aeaa(1)
	new ushort[]{0,30,3,32,56,45,39,37,},
//329	Aeaa(2)
	new ushort[]{0,29,26,36,1,17,14,37,},
//330	Bbeb(1)
	new ushort[]{0,24,4,38,54,33,45,43,},
//331	Bbeb(2)
	new ushort[]{0,23,29,42,1,11,17,43,},
//332	Bbeb(1)
	new ushort[]{0,24,4,38,54,33,45,43,},
//333	Bbeb(2)
	new ushort[]{0,23,29,42,1,11,17,43,},
//334	Fmmm
	new ushort[]{0,3,2,4,1,9,8,10,},
//335	Fddd(1)
	new ushort[]{0,3,2,4,57,52,50,51,},
//336	Fddd(2)
	new ushort[]{0,58,59,60,1,61,62,63,},
//337	Immm
	new ushort[]{0,3,2,4,1,9,8,10,},
//338	Ibam
	new ushort[]{0,3,36,44,1,9,37,45,},
//339	Imcb
	new ushort[]{0,4,42,32,1,10,43,33,},
//340	Icma
	new ushort[]{0,2,48,38,1,8,49,39,},
//341	Ibca
	new ushort[]{0,38,32,44,1,39,33,45,},
//342	Icab
	new ushort[]{0,42,48,36,1,43,49,37,},
//343	Imma
	new ushort[]{0,28,5,4,1,16,20,10,},
//344	Immb
	new ushort[]{0,26,7,2,1,14,22,8,},
//345	Ibmm
	new ushort[]{0,31,6,2,1,19,21,8,},
//346	Icmm
	new ushort[]{0,29,5,3,1,17,20,9,},
//347	Imcm
	new ushort[]{0,25,7,3,1,13,22,9,},
//348	Imam
	new ushort[]{0,23,6,4,1,11,21,10,},
//349	P4
	new ushort[]{0,3,64,65,},
//350	P4sub1
	new ushort[]{0,6,66,67,},
//351	P4sub2
	new ushort[]{0,3,68,69,},
//352	P4sub3
	new ushort[]{0,6,70,71,},
//353	I4
	new ushort[]{0,3,64,65,},
//354	I4sub1
	new ushort[]{0,40,72,73,},
//355	P-4
	new ushort[]{0,3,74,75,},
//356	I-4
	new ushort[]{0,3,74,75,},
//357	P4/m
	new ushort[]{0,3,64,65,1,9,74,75,},
//358	P4sub2/m
	new ushort[]{0,3,68,69,1,9,76,77,},
//359	P4/n(1)
	new ushort[]{0,3,78,79,54,15,74,75,},
//360	P4/n(2)
	new ushort[]{0,27,80,81,1,15,82,83,},
//361	P4sub2/n(1)
	new ushort[]{0,3,84,85,53,41,74,75,},
//362	P4sub2/n(2)
	new ushort[]{0,27,86,87,1,15,88,89,},
//363	I4/m
	new ushort[]{0,3,64,65,1,9,74,75,},
//364	I4sub1/a(1)
	new ushort[]{0,40,72,73,90,91,74,92,},
//365	I4sub1/a(2)
	new ushort[]{0,38,93,94,1,39,95,96,},
//366	P422
	new ushort[]{0,3,64,65,2,4,97,98,},
//367	P42sub12
	new ushort[]{0,3,78,79,36,44,97,98,},
//368	P4sub122
	new ushort[]{0,6,66,67,2,31,99,100,},
//369	P4sub12sub12
	new ushort[]{0,6,101,102,103,104,97,105,},
//370	P4sub222
	new ushort[]{0,3,68,69,2,4,106,105,},
//371	P4sub22sub12
	new ushort[]{0,3,84,85,34,46,97,98,},
//372	P4sub322
	new ushort[]{0,6,70,71,2,31,107,108,},
//373	P4sub32sub12
	new ushort[]{0,6,109,110,111,112,97,105,},
//374	I422
	new ushort[]{0,3,64,65,2,4,97,98,},
//375	I4sub122
	new ushort[]{0,40,72,73,113,114,115,98,},
//376	P4mm
	new ushort[]{0,3,64,65,8,10,116,117,},
//377	P4bm
	new ushort[]{0,3,64,65,37,45,118,119,},
//378	P4sub2cm
	new ushort[]{0,3,68,69,11,19,116,117,},
//379	P4sub2nm
	new ushort[]{0,3,84,85,35,47,116,117,},
//380	P4cc
	new ushort[]{0,3,64,65,11,19,120,121,},
//381	P4nc
	new ushort[]{0,3,64,65,35,47,122,123,},
//382	P4sub2mc
	new ushort[]{0,3,68,69,8,10,120,121,},
//383	P4sub2bc
	new ushort[]{0,3,68,69,37,45,122,123,},
//384	I4mm
	new ushort[]{0,3,64,65,8,10,116,117,},
//385	I4cm
	new ushort[]{0,3,64,65,11,19,120,121,},
//386	I4sub1md
	new ushort[]{0,40,72,73,8,47,124,125,},
//387	I4sub1cd
	new ushort[]{0,40,72,73,11,45,126,127,},
//388	P-42m
	new ushort[]{0,3,74,75,2,4,116,117,},
//389	P-42c
	new ushort[]{0,3,74,75,23,31,120,121,},
//390	P-42sub1m
	new ushort[]{0,3,74,75,36,44,118,119,},
//391	P-42sub1c
	new ushort[]{0,3,74,75,34,46,122,123,},
//392	P-4m2
	new ushort[]{0,3,74,75,8,10,97,98,},
//393	P-4c2
	new ushort[]{0,3,74,75,11,19,106,105,},
//394	P-4b2
	new ushort[]{0,3,74,75,37,45,128,129,},
//395	P-4n2
	new ushort[]{0,3,74,75,35,47,115,130,},
//396	I-4m2
	new ushort[]{0,3,74,75,8,10,97,98,},
//397	I-4c2
	new ushort[]{0,3,74,75,11,19,106,105,},
//398	I-42m
	new ushort[]{0,3,74,75,2,4,116,117,},
//399	I-42d
	new ushort[]{0,3,74,75,113,131,132,125,},
//400	P4/mmm
	new ushort[]{0,3,64,65,2,4,97,98,1,9,74,75,8,10,116,117,},
//401	P4/mcc
	new ushort[]{0,3,64,65,23,31,106,105,1,9,74,75,11,19,120,121,},
//402	P4/nbm(1)
	new ushort[]{0,3,64,65,2,4,97,98,54,15,133,134,37,45,118,119,},
//403	P4/nbm(2)
	new ushort[]{0,27,80,81,25,29,97,129,1,15,82,83,13,17,116,119,},
//404	P4/nnc(1)
	new ushort[]{0,3,64,65,2,4,97,98,53,41,135,92,35,47,122,123,},
//405	P4/nnc(2)
	new ushort[]{0,27,80,81,24,30,106,130,1,15,82,83,12,18,120,123,},
//406	P4/mbm
	new ushort[]{0,3,64,65,36,44,128,129,1,9,74,75,37,45,118,119,},
//407	P4/mnc
	new ushort[]{0,3,64,65,34,46,115,130,1,9,74,75,35,47,122,123,},
//408	P4/nmm(1)
	new ushort[]{0,3,78,79,36,44,97,98,54,15,74,75,8,10,118,119,},
//409	P4/nmm(2)
	new ushort[]{0,27,80,81,5,7,128,98,1,15,82,83,20,22,118,117,},
//410	P4/ncc(1)
	new ushort[]{0,3,78,79,34,46,106,105,54,15,74,75,11,19,122,123,},
//411	P4/ncc(2)
	new ushort[]{0,27,80,81,32,48,115,105,1,15,82,83,33,49,122,121,},
//412	P4sub2/mmc
	new ushort[]{0,3,68,69,2,4,106,105,1,9,76,77,8,10,120,121,},
//413	P4sub2/mcm
	new ushort[]{0,3,68,69,23,31,97,98,1,9,76,77,11,19,116,117,},
//414	P4sub2/nbc(1)
	new ushort[]{0,3,84,85,23,31,128,129,53,41,74,75,37,45,120,121,},
//415	P4sub2/nbc(2)
	new ushort[]{0,27,136,137,25,29,106,130,1,15,138,139,13,17,120,123,},
//416	P4sub2/nnm(1)
	new ushort[]{0,3,84,85,2,4,115,130,53,41,74,75,35,47,116,117,},
//417	P4sub2/nnm(2)
	new ushort[]{0,27,136,137,24,30,97,129,1,15,138,139,12,18,116,119,},
//418	P4sub2/mbc
	new ushort[]{0,3,68,69,36,44,115,130,1,9,76,77,37,45,122,123,},
//419	P4sub2/mnm
	new ushort[]{0,3,84,85,34,46,97,98,1,9,135,92,35,47,116,117,},
//420	P4sub2/nmc(1)
	new ushort[]{0,3,84,85,34,46,97,98,53,41,74,75,8,10,122,123,},
//421	P4sub2/nmc(2)
	new ushort[]{0,27,136,137,5,7,115,105,1,15,138,139,20,22,122,121,},
//422	P4sub2/ncm(1)
	new ushort[]{0,3,84,85,36,44,106,105,53,41,74,75,11,19,118,119,},
//423	P4sub2/ncm(2)
	new ushort[]{0,27,136,137,32,48,128,98,1,15,138,139,33,49,118,117,},
//424	I4/mmm
	new ushort[]{0,3,64,65,2,4,97,98,1,9,74,75,8,10,116,117,},
//425	I4/mcm
	new ushort[]{0,3,64,65,23,31,106,105,1,9,74,75,11,19,120,121,},
//426	I4sub1/amd(1)
	new ushort[]{0,40,72,73,113,114,115,98,90,91,74,92,35,10,132,140,},
//427	I4sub1/amd(2)
	new ushort[]{0,38,141,142,24,4,143,144,1,39,145,146,12,10,147,148,},
//428	I4sub1/acd(1)
	new ushort[]{0,40,72,73,149,150,128,105,90,91,74,92,37,19,151,152,},
//429	I4sub1/acd(2)
	new ushort[]{0,38,141,142,25,31,153,154,1,39,145,146,13,19,155,156,},
//430	P3
	new ushort[]{0,157,158,},
//431	P3sub1
	new ushort[]{0,159,160,},
//432	P3sub2
	new ushort[]{0,161,162,},
//433	R3Hex
	new ushort[]{0,157,158,},
//434	R3Rho
	new ushort[]{0,163,164,},
//435	P-3
	new ushort[]{0,157,158,1,165,166,},
//436	R-3Hex
	new ushort[]{0,157,158,1,165,166,},
//437	R-3Rho
	new ushort[]{0,163,164,1,167,168,},
//438	P312
	new ushort[]{0,157,158,98,169,170,},
//439	P321
	new ushort[]{0,157,158,97,4,2,},
//440	P3sub112
	new ushort[]{0,159,160,171,172,170,},
//441	P3sub121
	new ushort[]{0,159,160,97,173,174,},
//442	P3sub212
	new ushort[]{0,161,162,175,176,170,},
//443	P3sub221
	new ushort[]{0,161,162,97,177,178,},
//444	R32Hex
	new ushort[]{0,157,158,97,4,2,},
//445	R32Rho
	new ushort[]{0,163,164,179,98,180,},
//446	P3m1
	new ushort[]{0,157,158,116,10,8,},
//447	P31m
	new ushort[]{0,157,158,117,181,182,},
//448	P3c1
	new ushort[]{0,157,158,120,19,11,},
//449	P31c
	new ushort[]{0,157,158,121,183,184,},
//450	R3mHex
	new ushort[]{0,157,158,116,10,8,},
//451	R3mRho
	new ushort[]{0,163,164,185,117,186,},
//452	R3cHex
	new ushort[]{0,157,158,120,19,11,},
//453	R3cRho
	new ushort[]{0,163,164,187,123,188,},
//454	P-31m
	new ushort[]{0,157,158,98,169,170,1,165,166,117,181,182,},
//455	P-31c
	new ushort[]{0,157,158,105,189,190,1,165,166,121,183,184,},
//456	P-3m1
	new ushort[]{0,157,158,97,4,2,1,165,166,116,10,8,},
//457	P-3c1
	new ushort[]{0,157,158,106,31,23,1,165,166,120,19,11,},
//458	R-3mHex
	new ushort[]{0,157,158,97,4,2,1,165,166,116,10,8,},
//459	R-3mRho
	new ushort[]{0,163,164,179,98,180,1,167,168,185,117,186,},
//460	R-3cHex
	new ushort[]{0,157,158,106,31,23,1,165,166,120,19,11,},
//461	R-3cRho
	new ushort[]{0,163,164,191,130,192,1,167,168,187,123,188,},
//462	P6
	new ushort[]{0,157,158,3,193,194,},
//463	P6sub1
	new ushort[]{0,159,160,6,195,196,},
//464	P6sub5
	new ushort[]{0,161,162,6,197,198,},
//465	P6sub2
	new ushort[]{0,161,162,3,199,200,},
//466	P6sub4
	new ushort[]{0,159,160,3,201,202,},
//467	P6sub3
	new ushort[]{0,157,158,6,203,204,},
//468	P-6
	new ushort[]{0,157,158,9,205,206,},
//469	P6/m
	new ushort[]{0,157,158,3,193,194,1,165,166,9,205,206,},
//470	P6sub3/m
	new ushort[]{0,157,158,6,203,204,1,165,166,21,207,208,},
//471	P622
	new ushort[]{0,157,158,3,193,194,97,4,2,98,169,170,},
//472	P6sub122
	new ushort[]{0,159,160,6,195,196,209,4,178,210,189,211,},
//473	P6sub522
	new ushort[]{0,161,162,6,197,198,212,4,174,213,189,214,},
//474	P6sub222
	new ushort[]{0,161,162,3,199,200,212,4,174,171,169,215,},
//475	P6sub422
	new ushort[]{0,159,160,3,201,202,209,4,178,175,169,216,},
//476	P6sub322
	new ushort[]{0,157,158,6,203,204,97,4,2,105,189,190,},
//477	P6mm
	new ushort[]{0,157,158,3,193,194,116,10,8,117,181,182,},
//478	P6cc
	new ushort[]{0,157,158,3,193,194,120,19,11,121,183,184,},
//479	P6sub3cm
	new ushort[]{0,157,158,6,203,204,120,19,11,117,181,182,},
//480	P6sub3mc
	new ushort[]{0,157,158,6,203,204,116,10,8,121,183,184,},
//481	P-6m2
	new ushort[]{0,157,158,9,205,206,116,10,8,98,169,170,},
//482	P-6c2
	new ushort[]{0,157,158,21,207,208,120,19,11,98,169,170,},
//483	P-62m
	new ushort[]{0,157,158,9,205,206,97,4,2,117,181,182,},
//484	P-62c
	new ushort[]{0,157,158,21,207,208,97,4,2,121,183,184,},
//485	P6/mmm
	new ushort[]{0,157,158,3,193,194,97,4,2,98,169,170,1,165,166,9,205,206,116,10,8,117,181,182,},
//486	P6/mcc
	new ushort[]{0,157,158,3,193,194,106,31,23,105,189,190,1,165,166,9,205,206,120,19,11,121,183,184,},
//487	P6sub3/mcm
	new ushort[]{0,157,158,6,203,204,106,31,23,98,169,170,1,165,166,21,207,208,120,19,11,117,181,182,},
//488	P6sub3/mmc
	new ushort[]{0,157,158,6,203,204,97,4,2,105,189,190,1,165,166,21,207,208,116,10,8,121,183,184,},
//489	P23
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,},
//490	F23
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,},
//491	I23
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,},
//492	P2sub13
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,},
//493	I2sub13
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,},
//494	Pm-3
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,1,9,8,10,167,229,230,231,168,232,233,234,},
//495	Pn-3(1)
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,53,41,35,47,235,236,237,238,239,240,241,242,},
//496	Pn-3(2)
	new ushort[]{0,27,24,30,163,243,244,245,164,246,247,248,1,15,12,18,167,249,250,251,168,252,253,254,},
//497	Fm-3
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,1,9,8,10,167,229,230,231,168,232,233,234,},
//498	Fd-3(1)
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,57,52,50,51,255,256,257,258,259,260,261,262,},
//499	Fd-3(2)
	new ushort[]{0,58,59,60,163,263,264,265,164,266,267,268,1,61,62,63,167,269,270,271,168,272,273,274,},
//500	Im-3
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,1,9,8,10,167,229,230,231,168,232,233,234,},
//501	Pa-3
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,1,39,33,45,167,275,276,277,168,278,279,280,},
//502	Ia-3
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,1,39,33,45,167,275,276,277,168,278,279,280,},
//503	P432
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,},
//504	P4sub232
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,115,130,85,84,287,288,192,289,290,291,292,191,},
//505	F432
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,},
//506	F4sub132
	new ushort[]{0,42,36,48,163,293,294,295,164,296,297,298,299,154,300,301,302,303,304,305,306,307,308,309,},
//507	I432
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,},
//508	P4sub332
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,153,154,310,311,312,313,304,314,315,316,317,309,},
//509	P4sub132
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,318,319,142,141,320,321,322,323,324,325,326,327,},
//510	I4sub132
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,318,319,142,141,320,321,322,323,324,325,326,327,},
//511	P-43m
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,117,116,74,75,186,328,329,330,185,331,332,333,},
//512	F-43m
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,117,116,74,75,186,328,329,330,185,331,332,333,},
//513	I-43m
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,117,116,74,75,186,328,329,330,185,331,332,333,},
//514	P-43n
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,123,122,135,92,188,334,335,336,187,337,338,339,},
//515	F-43c
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,123,122,135,92,188,334,335,336,187,337,338,339,},
//516	I-43d
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,340,341,145,146,342,343,344,345,346,347,348,349,},
//517	Pm-3m
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,1,9,8,10,167,229,230,231,168,232,233,234,116,117,75,74,329,330,186,328,333,332,331,185,},
//518	Pn-3n(1)
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,53,41,35,47,235,236,237,238,239,240,241,242,122,123,92,135,335,336,188,334,339,338,337,187,},
//519	Pn-3n(2)
	new ushort[]{0,27,24,30,163,243,244,245,164,246,247,248,106,130,81,80,350,351,192,352,353,354,355,191,1,15,12,18,167,249,250,251,168,252,253,254,120,123,83,82,356,357,188,358,359,360,361,187,},
//520	Pm-3n
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,115,130,85,84,287,288,192,289,290,291,292,191,1,9,8,10,167,229,230,231,168,232,233,234,122,123,92,135,335,336,188,334,339,338,337,187,},
//521	Pn-3m(1)
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,115,130,85,84,287,288,192,289,290,291,292,191,53,41,35,47,235,236,237,238,239,240,241,242,116,117,75,74,329,330,186,328,333,332,331,185,},
//522	Pn-3m(2)
	new ushort[]{0,27,24,30,163,243,244,245,164,246,247,248,128,98,87,86,362,363,180,364,365,366,367,179,1,15,12,18,167,249,250,251,168,252,253,254,118,117,89,88,368,369,186,370,371,372,373,185,},
//523	Fm-3m
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,1,9,8,10,167,229,230,231,168,232,233,234,116,117,75,74,329,330,186,328,333,332,331,185,},
//524	Fm-3c
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,115,130,85,84,287,288,192,289,290,291,292,191,1,9,8,10,167,229,230,231,168,232,233,234,122,123,92,135,335,336,188,334,339,338,337,187,},
//525	Fd-3m(1)
	new ushort[]{0,42,36,48,163,293,294,295,164,296,297,298,299,154,300,301,302,303,304,305,306,307,308,309,57,374,375,376,255,377,378,379,259,380,381,382,383,117,139,133,384,385,186,386,387,388,389,185,},
//526	Fd-3m(2)
	new ushort[]{0,390,391,392,163,393,394,395,164,396,397,398,399,98,400,401,402,403,180,404,405,406,407,179,1,408,409,410,167,411,412,413,168,414,415,416,417,117,418,419,420,421,186,422,423,424,425,185,},
//527	Fd-3c(1)
	new ushort[]{0,42,36,48,163,293,294,295,164,296,297,298,299,154,300,301,302,303,304,305,306,307,308,309,426,427,428,429,430,431,432,433,434,435,436,437,438,123,439,76,440,441,188,442,443,444,445,187,},
//528	Fd-3c(2)
	new ushort[]{0,446,447,448,163,449,450,451,164,452,453,454,455,130,456,457,458,459,192,460,461,462,463,191,1,464,465,466,167,467,468,469,168,470,471,472,473,123,474,475,476,477,188,478,479,480,481,187,},
//529	Im-3m
	new ushort[]{0,3,2,4,163,217,218,219,164,220,221,222,97,98,65,64,281,282,180,283,284,285,286,179,1,9,8,10,167,229,230,231,168,232,233,234,116,117,75,74,329,330,186,328,333,332,331,185,},
//530	Ia-3d
	new ushort[]{0,38,32,44,163,223,224,225,164,226,227,228,318,319,142,141,320,321,322,323,324,325,326,327,1,39,33,45,167,275,276,277,168,278,279,280,341,340,146,145,344,345,342,343,349,348,347,346,},
//531	C-1
new ushort[]{0,1,},
//532	I-1
new ushort[]{0,1,},
//533	A-1
new ushort[]{0,1,},
//534	B-1
new ushort[]{0,1,},
//535	F-1
new ushort[]{0,1,},
//536	A1
new ushort[]{0,},
//537	B1
new ushort[]{0,},
//538	C1
new ushort[]{0,},
//539	F1
new ushort[]{0,},
            #endregion
        };
    public static readonly SO[] OperationList 
        = new SO[]
        {
				#region OperationList

new SO(1,+1,(0,0,0),(0,0,0)),//000
new SO(-1,+1,(0,0,0),(0,0,0)),//001
new SO(2,+1,(0,1,0),(0,0,0)),
new SO(2,+1,(0,0,1),(0,0,0)),
new SO(2,+1,(1,0,0),(0,0,0)),
new SO(2,+1,(0,1,0),(0,0,d12)),
new SO(2,+1,(0,0,1),(0,0,d12)),
new SO(2,+1,(1,0,0),(0,d12,d14)),
new SO(-2,+1,(0,1,0),(0,0,0)),
new SO(-2,+1,(0,0,1),(0,0,0)),
new SO(-2,+1,(1,0,0),(0,0,0)),
new SO(-2,+1,(0,1,0),(0,0,d12)),
new SO(-2,+1,(0,1,0),(0,d12,d14)),
new SO(-2,+1,(0,1,0),(0,d12,d14)),
new SO(-2,+1,(0,0,1),(0,d12,d14)),
new SO(-2,+1,(0,0,1),(d12,0,d34)),
new SO(-2,+1,(0,0,1),(0,0,d12)),
new SO(-2,+1,(1,0,0),(0,0,d12)),
new SO(-2,+1,(1,0,0),(0,d12,d12)),
new SO(-2,+1,(1,0,0),(0,0,d12)),
new SO(-2,+1,(0,1,0),(0,0,d12)),
new SO(-2,+1,(0,0,1),(0,0,d12)),
new SO(-2,+1,(1,0,0),(0,d12,d14)),
new SO(2,+1,(0,1,0),(0,0,d12)),
new SO(2,+1,(0,1,0),(0,d12,d14)),
new SO(2,+1,(0,1,0),(0,d12,d14)),
new SO(2,+1,(0,0,1),(0,d12,d14)),
new SO(2,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(0,0,1),(0,0,d12)),
new SO(2,+1,(1,0,0),(0,0,d12)),
new SO(2,+1,(1,0,0),(0,d12,d12)),
new SO(2,+1,(1,0,0),(0,0,d12)),
new SO(2,+1,(0,1,0),(0,d12,d12)),
new SO(-2,+1,(0,1,0),(0,d12,d12)),
new SO(2,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(0,0,1),(0,d12,d14)),
new SO(-2,+1,(0,0,1),(0,d12,d14)),
new SO(2,+1,(0,0,1),(d12,0,d34)),
new SO(-2,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(0,0,1),(0,d12,d12)),
new SO(-2,+1,(0,0,1),(0,d12,d12)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(-2,+1,(1,0,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(-2,+1,(1,0,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(0,d12,d14)),
new SO(-2,+1,(1,0,0),(0,d12,d14)),
new SO(-2,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,0),(d12,0,d34)),
new SO(-2,+1,(0,0,1),(d12,0,d34)),
new SO(-1,+1,(0,0,0),(d12,0,d34)),
new SO(-1,+1,(0,0,0),(d12,0,d34)),
new SO(-1,+1,(0,0,0),(0,d12,d12)),
new SO(-1,+1,(0,0,0),(0,d12,d14)),
new SO(-1,+1,(0,0,0),(d12,0,d34)),
new SO(2,+1,(0,0,1),(d34,d14,d34)),
new SO(2,+1,(0,1,0),(d14,d14,d34)),
new SO(2,+1,(1,0,0),(0,d12,d14)),
new SO(-2,+1,(0,0,1),(d12,0,d34)),
new SO(-2,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,0),(0,d14,d14)),
new SO(4,+1,(0,0,1),(0,0,0)),
new SO(4,+1,(0,0,1),(0,0,0)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(0,d12,d12)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(0,0,0)),
new SO(-4,+1,(0,0,1),(0,0,0)),
new SO(-4,+1,(0,0,1),(0,0,d12)),
new SO(-4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(0,d12,d14)),
new SO(4,+1,(0,0,1),(0,0,d12)),
new SO(-4,+1,(0,0,1),(0,d12,d14)),
new SO(-4,+1,(0,0,1),(0,0,d12)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(0,d12,d12)),
new SO(4,+1,(0,0,1),(0,d12,d14)),
new SO(-4,+1,(0,0,1),(0,d12,d12)),
new SO(-4,+1,(0,0,1),(0,d12,d14)),
new SO(-1,+1,(0,0,0),(0,d12,d12)),
new SO(-2,+1,(0,0,1),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d14,d14,d34)),
new SO(4,+1,(0,0,1),(0,d14,d34)),
new SO(-4,+1,(0,0,1),(d14,d34,d34)),
new SO(-4,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(1,1,0),(0,0,0)),
new SO(2,+1,(1,-1,0),(0,0,0)),
new SO(2,+1,(1,1,0),(0,0,d12)),
new SO(2,+1,(1,-1,0),(0,0,d12)),//100
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(2,+1,(1,-1,0),(0,0,d12)),
new SO(2,+1,(1,1,0),(0,0,d12)),
new SO(2,+1,(1,1,0),(0,0,d12)),
new SO(2,+1,(1,-1,0),(0,0,d12)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(2,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(0,d12,d12)),
new SO(2,+1,(1,1,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(0,0,0)),
new SO(-2,-1,(1,-1,0),(0,0,0)),
new SO(-2,+1,(1,1,0),(d12,0,d34)),
new SO(-2,-1,(1,-1,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(0,0,d12)),
new SO(-2,-1,(1,-1,0),(0,0,d12)),
new SO(-2,+1,(1,1,0),(d12,0,d34)),
new SO(-2,-1,(1,-1,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(0,d12,d12)),
new SO(-2,-1,(1,-1,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(0,d12,d12)),
new SO(-2,-1,(1,-1,0),(0,d12,d14)),
new SO(2,+1,(1,1,0),(d12,0,d34)),
new SO(2,+1,(1,-1,0),(d12,0,d34)),
new SO(2,+1,(1,-1,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(0,d12,d14)),
new SO(4,+1,(0,0,1),(0,d12,d12)),
new SO(-4,+1,(0,0,1),(0,d12,d14)),
new SO(-4,+1,(0,0,1),(0,d12,d12)),
new SO(-2,-1,(1,-1,0),(0,d12,d12)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(1,1,0),(d12,0,d34)),
new SO(2,+1,(1,-1,0),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d34,d14,d34)),
new SO(-4,+1,(0,0,1),(d34,d34,d14)),
new SO(-2,+1,(1,1,0),(d34,d14,d34)),
new SO(-2,-1,(1,-1,0),(d34,d34,d14)),
new SO(2,+1,(0,1,0),(0,d12,d14)),
new SO(2,+1,(1,0,0),(0,d12,d12)),
new SO(-2,+1,(1,1,0),(0,d12,d14)),
new SO(-2,-1,(1,-1,0),(0,d12,d12)),
new SO(2,+1,(1,1,0),(d14,d34,d34)),
new SO(2,+1,(1,-1,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(d14,d14,d34)),
new SO(-2,-1,(1,-1,0),(0,d14,d34)),
new SO(3,+1,(0,0,1),(0,0,0)),
new SO(3,-1,(0,0,1),(0,0,0)),
new SO(3,+1,(0,0,1),(0,0,d12)),
new SO(3,-1,(0,0,1),(0,0,d12)),
new SO(3,+1,(0,0,1),(0,0,d12)),
new SO(3,-1,(0,0,1),(0,0,d12)),
new SO(3,+1,(1,1,1),(0,0,0)),
new SO(3,-1,(1,1,1),(0,0,0)),
new SO(-3,+1,(0,0,1),(0,0,0)),
new SO(-3,-1,(0,0,1),(0,0,0)),
new SO(-3,+1,(1,1,1),(0,0,0)),
new SO(-3,-1,(1,1,1),(0,0,0)),
new SO(2,+1,(1,2,0),(0,0,0)),
new SO(2,+1,(2,1,0),(0,0,0)),
new SO(2,+1,(1,-1,0),(0,0,d12)),
new SO(2,+1,(1,2,0),(0,0,d12)),
new SO(2,+1,(1,0,0),(0,0,d12)),
new SO(2,+1,(0,1,0),(0,0,d12)),
new SO(2,+1,(1,-1,0),(0,0,d12)),
new SO(2,+1,(1,2,0),(0,0,d12)),
new SO(2,+1,(1,0,0),(0,0,d12)),
new SO(2,+1,(0,1,0),(0,0,d12)),
new SO(2,+1,(-1,0,1),(0,0,0)),
new SO(2,+1,(0,-1,1),(0,0,0)),
new SO(-2,+1,(1,2,0),(0,0,0)),
new SO(-2,+1,(2,1,0),(0,0,0)),
new SO(-2,+1,(1,2,0),(0,0,d12)),
new SO(-2,+1,(2,1,0),(0,0,d12)),
new SO(-2,-1,(-1,0,1),(0,0,0)),
new SO(-2,-1,(0,1,-1),(0,0,0)),
new SO(-2,-1,(-1,0,1),(d12,0,d34)),
new SO(-2,-1,(0,1,-1),(d12,0,d34)),
new SO(2,+1,(1,2,0),(0,0,d12)),
new SO(2,+1,(2,1,0),(0,0,d12)),
new SO(2,+1,(-1,0,1),(d12,0,d34)),
new SO(2,+1,(0,-1,1),(d12,0,d34)),
new SO(6,-1,(0,0,1),(0,0,0)),
new SO(6,-1,(0,0,1),(0,0,0)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),//200
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(6,-1,(0,0,1),(0,0,d12)),
new SO(-6,-1,(0,0,1),(0,0,0)),
new SO(-6,-1,(0,0,1),(0,0,0)),
new SO(-6,-1,(0,0,1),(0,0,d12)),
new SO(-6,-1,(0,0,1),(0,0,d12)),
new SO(2,+1,(1,1,0),(0,0,d12)),
new SO(2,+1,(1,-1,0),(0,0,d12)),
new SO(2,+1,(2,1,0),(0,0,d12)),
new SO(2,+1,(1,1,0),(0,0,d12)),
new SO(2,+1,(1,-1,0),(0,0,d12)),
new SO(2,+1,(2,1,0),(0,0,d12)),
new SO(2,+1,(2,1,0),(0,0,d12)),
new SO(2,+1,(2,1,0),(0,0,d12)),
new SO(3,+1,(-1,1,-1),(0,0,0)),
new SO(3,+1,(1,-1,-1),(0,0,0)),
new SO(3,+1,(-1,-1,1),(0,0,0)),
new SO(3,-1,(1,-1,-1),(0,0,0)),
new SO(3,-1,(-1,-1,1),(0,0,0)),
new SO(3,-1,(-1,1,-1),(0,0,0)),
new SO(3,+1,(-1,1,-1),(d12,0,d34)),
new SO(3,+1,(1,-1,-1),(0,d12,d14)),
new SO(3,+1,(-1,-1,1),(0,d12,d12)),
new SO(3,-1,(1,-1,-1),(0,d12,d12)),
new SO(3,-1,(-1,-1,1),(d12,0,d34)),
new SO(3,-1,(-1,1,-1),(0,d12,d14)),
new SO(-3,+1,(-1,1,-1),(0,0,0)),
new SO(-3,+1,(1,-1,-1),(0,0,0)),
new SO(-3,+1,(-1,-1,1),(0,0,0)),
new SO(-3,-1,(1,-1,-1),(0,0,0)),
new SO(-3,-1,(-1,-1,1),(0,0,0)),
new SO(-3,-1,(-1,1,-1),(0,0,0)),
new SO(-3,+1,(1,1,1),(d12,0,d34)),
new SO(-3,+1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,-1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(1,1,1),(d12,0,d34)),
new SO(-3,-1,(1,-1,-1),(d12,0,d34)),
new SO(-3,-1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(-1,1,-1),(d12,0,d34)),
new SO(3,+1,(-1,1,-1),(0,d12,d12)),
new SO(3,+1,(1,-1,-1),(d12,0,d34)),
new SO(3,+1,(-1,-1,1),(0,d12,d14)),
new SO(3,-1,(1,-1,-1),(0,d12,d14)),
new SO(3,-1,(-1,-1,1),(0,d12,d12)),
new SO(3,-1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,1,-1),(0,d12,d12)),
new SO(-3,+1,(1,-1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,-1,1),(0,d12,d14)),
new SO(-3,-1,(1,-1,-1),(0,d12,d14)),
new SO(-3,-1,(-1,-1,1),(0,d12,d12)),
new SO(-3,-1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,1,1),(d12,0,d34)),
new SO(-3,+1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,-1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(1,1,1),(d12,0,d34)),
new SO(-3,-1,(1,-1,-1),(d12,0,d34)),
new SO(-3,-1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(-1,1,-1),(d12,0,d34)),
new SO(3,+1,(-1,1,-1),(0,d12,d14)),
new SO(3,+1,(1,-1,-1),(d34,d14,d34)),
new SO(3,+1,(-1,-1,1),(d14,d14,d34)),
new SO(3,-1,(1,-1,-1),(d14,d14,d34)),
new SO(3,-1,(-1,-1,1),(0,d12,d14)),
new SO(3,-1,(-1,1,-1),(d34,d14,d34)),
new SO(-3,+1,(-1,1,-1),(0,d14,d14)),
new SO(-3,+1,(1,-1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(1,-1,-1),(d12,0,d34)),
new SO(-3,-1,(-1,-1,1),(0,d14,d14)),
new SO(-3,-1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,-1,-1),(0,d12,d14)),
new SO(-3,+1,(-1,-1,1),(0,d12,d12)),
new SO(-3,-1,(1,-1,-1),(0,d12,d12)),
new SO(-3,-1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(-1,1,-1),(0,d12,d14)),
new SO(4,-1,(1,0,0),(0,0,0)),
new SO(2,+1,(0,1,1),(0,0,0)),
new SO(4,+1,(1,0,0),(0,0,0)),
new SO(4,+1,(0,1,0),(0,0,0)),
new SO(2,+1,(1,0,1),(0,0,0)),
new SO(4,+1,(0,1,0),(0,0,0)),
new SO(4,-1,(1,0,0),(d12,0,d34)),
new SO(2,+1,(0,1,1),(d12,0,d34)),
new SO(4,+1,(1,0,0),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(1,0,1),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d12,0,d34)),
new SO(3,+1,(-1,1,-1),(0,d12,d14)),
new SO(3,+1,(1,-1,-1),(0,d12,d12)),
new SO(3,+1,(-1,-1,1),(d12,0,d34)),
new SO(3,-1,(1,-1,-1),(d12,0,d34)),
new SO(3,-1,(-1,-1,1),(0,d12,d14)),
new SO(3,-1,(-1,1,-1),(0,d12,d12)),
new SO(2,+1,(1,1,0),(d34,d14,d34)),
new SO(4,+1,(0,0,1),(d14,d34,d34)),//300
new SO(4,+1,(0,0,1),(d34,d34,d14)),
new SO(4,-1,(1,0,0),(d34,d14,d34)),
new SO(2,+1,(0,1,1),(d34,d34,d14)),
new SO(2,+1,(0,-1,1),(d12,0,d34)),
new SO(4,+1,(1,0,0),(d14,d34,d34)),
new SO(4,+1,(0,1,0),(d34,d14,d34)),
new SO(2,+1,(1,0,1),(d14,d34,d34)),
new SO(4,+1,(0,1,0),(d34,d34,d14)),
new SO(2,+1,(-1,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(d34,d34,d14)),
new SO(4,+1,(0,0,1),(d34,d14,d34)),
new SO(4,-1,(1,0,0),(d14,d34,d34)),
new SO(2,+1,(0,1,1),(d34,d14,d34)),
new SO(4,+1,(1,0,0),(d34,d34,d14)),
new SO(4,+1,(0,1,0),(d14,d34,d34)),
new SO(2,+1,(1,0,1),(d34,d34,d14)),
new SO(4,+1,(0,1,0),(d34,d14,d34)),
new SO(2,+1,(1,1,0),(d14,d14,d34)),
new SO(2,+1,(1,-1,0),(0,d14,d34)),
new SO(4,-1,(1,0,0),(d14,d14,d34)),
new SO(2,+1,(0,1,1),(d12,0,d34)),
new SO(2,+1,(0,-1,1),(0,d14,d34)),
new SO(4,+1,(1,0,0),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d14,d14,d34)),
new SO(2,+1,(1,0,1),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(-1,0,1),(0,d14,d34)),
new SO(-4,+1,(1,0,0),(0,0,0)),
new SO(-4,-1,(1,0,0),(0,0,0)),
new SO(-2,-1,(0,1,1),(0,0,0)),
new SO(-4,+1,(0,1,0),(0,0,0)),
new SO(-2,+1,(1,0,1),(0,0,0)),
new SO(-4,+1,(0,1,0),(0,0,0)),
new SO(-4,+1,(1,0,0),(d12,0,d34)),
new SO(-4,-1,(1,0,0),(d12,0,d34)),
new SO(-2,-1,(0,1,1),(d12,0,d34)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,1),(d12,0,d34)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(-2,-1,(1,-1,0),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(d14,d34,d34)),
new SO(-2,-1,(0,1,-1),(d12,0,d34)),
new SO(-4,+1,(1,0,0),(d34,d34,d14)),
new SO(-4,-1,(1,0,0),(d14,d34,d34)),
new SO(-2,-1,(0,1,1),(d34,d14,d34)),
new SO(-2,-1,(-1,0,1),(d12,0,d34)),
new SO(-4,+1,(0,1,0),(d34,d14,d34)),
new SO(-2,+1,(1,0,1),(d34,d34,d14)),
new SO(-4,+1,(0,1,0),(d14,d34,d34)),
new SO(4,-1,(1,0,0),(0,0,d12)),
new SO(2,+1,(0,1,1),(0,d12,d14)),
new SO(4,+1,(1,0,0),(0,0,d12)),
new SO(4,+1,(0,1,0),(0,0,d12)),
new SO(2,+1,(1,0,1),(0,0,d12)),
new SO(4,+1,(0,1,0),(0,d12,d14)),
new SO(-4,-1,(1,0,0),(0,0,d12)),
new SO(-2,-1,(0,1,1),(0,d12,d14)),
new SO(-4,+1,(1,0,0),(0,0,d12)),
new SO(-4,+1,(0,1,0),(0,0,d12)),
new SO(-2,+1,(1,0,1),(0,0,d12)),
new SO(-4,+1,(0,1,0),(0,d12,d14)),
new SO(4,-1,(1,0,0),(d12,0,d34)),
new SO(2,+1,(0,1,1),(0,d12,d12)),
new SO(4,+1,(1,0,0),(0,d12,d14)),
new SO(4,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(1,0,1),(0,d12,d14)),
new SO(4,+1,(0,1,0),(0,d12,d12)),
new SO(-4,-1,(1,0,0),(d12,0,d34)),
new SO(-2,-1,(0,1,1),(0,d12,d12)),
new SO(-4,+1,(1,0,0),(0,d12,d14)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,1),(0,d12,d14)),
new SO(-4,+1,(0,1,0),(0,d12,d12)),
new SO(-2,+1,(0,0,1),(d14,d34,d34)),
new SO(-2,+1,(0,1,0),(d34,d34,d14)),
new SO(-2,+1,(1,0,0),(d34,d14,d34)),
new SO(-3,+1,(-1,1,-1),(d34,d14,d34)),
new SO(-3,+1,(1,-1,-1),(d14,d34,d34)),
new SO(-3,+1,(-1,-1,1),(d34,d34,d14)),
new SO(-3,-1,(1,-1,-1),(d34,d34,d14)),
new SO(-3,-1,(-1,-1,1),(d34,d14,d34)),
new SO(-3,-1,(-1,1,-1),(d14,d34,d34)),
new SO(-2,+1,(1,1,0),(0,d12,d14)),
new SO(-4,-1,(1,0,0),(0,d12,d14)),
new SO(-2,-1,(0,1,1),(d12,0,d34)),
new SO(-4,+1,(1,0,0),(0,d12,d12)),
new SO(-4,+1,(0,1,0),(0,d12,d14)),
new SO(-2,+1,(1,0,1),(0,d12,d12)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(0,0,1),(d14,d14,d34)),
new SO(2,+1,(0,1,0),(d12,0,d34)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(3,+1,(-1,1,-1),(d12,0,d34)),
new SO(3,+1,(1,-1,-1),(d14,d14,d34)),
new SO(3,+1,(-1,-1,1),(d12,0,d34)),
new SO(3,-1,(1,-1,-1),(d12,0,d34)),
new SO(3,-1,(-1,-1,1),(d12,0,d34)),
new SO(3,-1,(-1,1,-1),(d14,d14,d34)),
new SO(2,+1,(1,1,0),(d14,d14,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),//400
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,-1,(1,0,0),(d14,d14,d34)),
new SO(2,+1,(0,1,1),(d12,0,d34)),
new SO(4,+1,(1,0,0),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d14,d14,d34)),
new SO(2,+1,(1,0,1),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(0,0,1),(d12,0,d34)),
new SO(-2,+1,(0,1,0),(d14,d14,d34)),
new SO(-2,+1,(1,0,0),(d12,0,d34)),
new SO(-3,+1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,-1,-1),(d12,0,d34)),
new SO(-3,+1,(-1,-1,1),(d14,d14,d34)),
new SO(-3,-1,(1,-1,-1),(d14,d14,d34)),
new SO(-3,-1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(-1,1,-1),(d12,0,d34)),
new SO(-2,+1,(1,1,0),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d14,d14,d34)),
new SO(-4,+1,(0,0,1),(d12,0,d34)),
new SO(-4,-1,(1,0,0),(d12,0,d34)),
new SO(-2,-1,(0,1,1),(d12,0,d34)),
new SO(-4,+1,(1,0,0),(d14,d14,d34)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,1),(d14,d14,d34)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(-1,+1,(0,0,0),(0,d14,d34)),
new SO(-2,+1,(0,0,1),(d14,d14,d34)),
new SO(-2,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,0),(d12,0,d34)),
new SO(-3,+1,(1,1,1),(0,d14,d34)),
new SO(-3,+1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,-1,-1),(d14,d14,d34)),
new SO(-3,+1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(1,1,1),(0,d14,d34)),
new SO(-3,-1,(1,-1,-1),(d12,0,d34)),
new SO(-3,-1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(-1,1,-1),(d14,d14,d34)),
new SO(-2,+1,(1,1,0),(0,0,d12)),
new SO(-4,+1,(0,0,1),(0,d12,d14)),
new SO(-4,-1,(1,0,0),(0,0,d12)),
new SO(-2,-1,(0,1,1),(0,0,d12)),
new SO(-4,+1,(1,0,0),(0,d12,d14)),
new SO(-4,+1,(0,1,0),(0,0,d12)),
new SO(-2,+1,(1,0,1),(0,d12,d14)),
new SO(-4,+1,(0,1,0),(0,0,d12)),
new SO(2,+1,(0,0,1),(d12,0,d34)),
new SO(2,+1,(0,1,0),(d14,d14,d34)),
new SO(2,+1,(1,0,0),(d12,0,d34)),
new SO(3,+1,(-1,1,-1),(d12,0,d34)),
new SO(3,+1,(1,-1,-1),(d12,0,d34)),
new SO(3,+1,(-1,-1,1),(d14,d14,d34)),
new SO(3,-1,(1,-1,-1),(d14,d14,d34)),
new SO(3,-1,(-1,-1,1),(d12,0,d34)),
new SO(3,-1,(-1,1,-1),(d12,0,d34)),
new SO(2,+1,(1,1,0),(d14,d14,d34)),
new SO(4,+1,(0,0,1),(d12,0,d34)),
new SO(4,+1,(0,0,1),(0,d12,d14)),
new SO(4,-1,(1,0,0),(d14,d14,d34)),
new SO(2,+1,(0,1,1),(0,d12,d14)),
new SO(4,+1,(1,0,0),(d12,0,d34)),
new SO(4,+1,(0,1,0),(d14,d14,d34)),
new SO(2,+1,(1,0,1),(d12,0,d34)),
new SO(4,+1,(0,1,0),(0,d12,d14)),
new SO(-2,+1,(0,0,1),(d14,d14,d34)),
new SO(-2,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,0),(d12,0,d34)),
new SO(-3,+1,(-1,1,-1),(d12,0,d34)),
new SO(-3,+1,(1,-1,-1),(d14,d14,d34)),
new SO(-3,+1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(1,-1,-1),(d12,0,d34)),
new SO(-3,-1,(-1,-1,1),(d12,0,d34)),
new SO(-3,-1,(-1,1,-1),(d14,d14,d34)),
new SO(-2,+1,(1,1,0),(d12,0,d34)),
new SO(-4,+1,(0,0,1),(d14,d14,d34)),
new SO(-4,+1,(0,0,1),(0,d12,d14)),
new SO(-4,-1,(1,0,0),(d12,0,d34)),
new SO(-2,-1,(0,1,1),(0,d12,d14)),
new SO(-4,+1,(1,0,0),(d14,d14,d34)),
new SO(-4,+1,(0,1,0),(d12,0,d34)),
new SO(-2,+1,(1,0,1),(d14,d14,d34)),
new SO(-4,+1,(0,1,0),(0,d12,d14)),
            #endregion
        };
    public static readonly byte[][] SiteSymmetryDictionary = new byte[][]
        {
				#region siteSymmetry
//0  unk
new byte[]{0},
//1  P 1
new byte[]{0},
//2  P -1
new byte[]{0,1,1,1,1,1,1,1,1},
//3  P 1 2 1
new byte[]{0,2,2,2,2},
//4  P 1 1 2
new byte[]{0,2,2,2,2},
//5  P 2 1 1
new byte[]{0,2,2,2,2},
//6  P 1 2sub1 1
new byte[]{0},
//7  P 1 1 2sub1
new byte[]{0},
//8  P 2sub1 1 1
new byte[]{0},
//9  C 1 2 1
new byte[]{0,2,2},
//10  A 1 2 1
new byte[]{0,2,2},
//11  I 1 2 1
new byte[]{0,2,2},
//12  A 1 1 2
new byte[]{0,2,2},
//13  B 1 1 2
new byte[]{0,2,2},
//14  I 1 1 2
new byte[]{0,2,2},
//15  B 2 1 1
new byte[]{0,2,2},
//16  C 2 1 1
new byte[]{0,2,2},
//17  I 2 1 1
new byte[]{0,2,2},
//18  P 1 m 1
new byte[]{0,3,3},
//19  P 1 1 m
new byte[]{0,3,3},
//20  P m 1 1
new byte[]{0,3,3},
//21  P 1 c 1
new byte[]{0},
//22  P 1 n 1
new byte[]{0},
//23  P 1 a 1
new byte[]{0},
//24  P 1 1 a
new byte[]{0},
//25  P 1 1 n
new byte[]{0},
//26  P 1 1 b
new byte[]{0},
//27  P b 1 1
new byte[]{0},
//28  P n 1 1
new byte[]{0},
//29  P c 1 1
new byte[]{0},
//30  C 1 m 1
new byte[]{0,3},
//31  A 1 m 1
new byte[]{0,3},
//32  I 1 m 1
new byte[]{0,3},
//33  A 1 1 m
new byte[]{0,3},
//34  B 1 1 m
new byte[]{0,3},
//35  I 1 1 m
new byte[]{0,3},
//36  B m 1 1
new byte[]{0,3},
//37  C m 1 1
new byte[]{0,3},
//38  I m 1 1
new byte[]{0,3},
//39  C 1 c 1
new byte[]{0},
//40  A 1 n 1
new byte[]{0},
//41  I 1 a 1
new byte[]{0},
//42  A 1 a 1
new byte[]{0},
//43  C 1 n 1
new byte[]{0},
//44  I 1 c 1
new byte[]{0},
//45  A 1 1 a
new byte[]{0},
//46  B 1 1 n
new byte[]{0},
//47  I 1 1 b
new byte[]{0},
//48  B 1 1 b
new byte[]{0},
//49  A 1 1 n
new byte[]{0},
//50  I 1 1 a
new byte[]{0},
//51  B b 1 1
new byte[]{0},
//52  C n 1 1
new byte[]{0},
//53  I c 1 1
new byte[]{0},
//54  C c 1 1
new byte[]{0},
//55  B n 1 1
new byte[]{0},
//56  I b 1 1
new byte[]{0},
//57  P 1 2/m 1
new byte[]{0,3,3,2,2,2,2,4,4,4,4,4,4,4,4},
//58  P 1 1 2/m
new byte[]{0,3,3,2,2,2,2,4,4,4,4,4,4,4,4},
//59  P 2/m 1 1
new byte[]{0,3,3,2,2,2,2,4,4,4,4,4,4,4,4},
//60  P 1 2sub1/m 1
new byte[]{0,3,1,1,1,1},
//61  P 1 1 2sub1/m
new byte[]{0,3,1,1,1,1},
//62  P 2sub1/m 1 1
new byte[]{0,3,1,1,1,1},
//63  C 1 2/m 1
new byte[]{0,3,2,2,1,1,4,4,4,4},
//64  A 1 2/m 1
new byte[]{0,3,2,2,1,1,4,4,4,4},
//65  I 1 2/m 1
new byte[]{0,3,2,2,1,1,4,4,4,4},
//66  A 1 1 2/m
new byte[]{0,3,2,2,1,1,4,4,4,4},
//67  B 1 1 2/m
new byte[]{0,3,2,2,1,1,4,4,4,4},
//68  I 1 1 2/m
new byte[]{0,3,2,2,1,1,4,4,4,4},
//69  B 2/m 1 1
new byte[]{0,3,2,2,1,1,4,4,4,4},
//70  C 2/m 1 1
new byte[]{0,3,2,2,1,1,4,4,4,4},
//71  I 2/m 1 1
new byte[]{0,3,2,2,1,1,4,4,4,4},
//72  P 1 2/c 1
new byte[]{0,2,2,1,1,1,1},
//73  P 1 2/n 1
new byte[]{0,2,2,1,1,1,1},
//74  P 1 2/a 1
new byte[]{0,2,2,1,1,1,1},
//75  P 1 1 2/a
new byte[]{0,2,2,1,1,1,1},
//76  P 1 1 2/n
new byte[]{0,2,2,1,1,1,1},
//77  P 1 1 2/b
new byte[]{0,2,2,1,1,1,1},
//78  P 2/b 1 1
new byte[]{0,2,2,1,1,1,1},
//79  P 2/n 1 1
new byte[]{0,2,2,1,1,1,1},
//80  P 2/c 1 1
new byte[]{0,2,2,1,1,1,1},
//81  P 1 2sub1/c 1
new byte[]{0,1,1,1,1},
//82  P 1 2sub1/n 1
new byte[]{0,1,1,1,1},
//83  P 1 2sub1/a 1
new byte[]{0,1,1,1,1},
//84  P 1 1 2sub1/a
new byte[]{0,1,1,1,1},
//85  P 1 1 2sub1/n
new byte[]{0,1,1,1,1},
//86  P 1 1 2sub1/b
new byte[]{0,1,1,1,1},
//87  P 2sub1/b 1 1
new byte[]{0,1,1,1,1},
//88  P 2sub1/n 1 1
new byte[]{0,1,1,1,1},
//89  P 2sub1/c 1 1
new byte[]{0,1,1,1,1},
//90  C 1 2/c 1
new byte[]{0,2,1,1,1,1},
//91  A 1 2/n 1
new byte[]{0,2,1,1,1,1},
//92  I 1 2/a 1
new byte[]{0,2,1,1,1,1},
//93  A 1 2/a 1
new byte[]{0,2,1,1,1,1},
//94  C 1 2/n 1
new byte[]{0,2,1,1,1,1},
//95  I 1 2/c 1
new byte[]{0,2,1,1,1,1},
//96  A 1 1 2/a
new byte[]{0,2,1,1,1,1},
//97  B 1 1 2/n
new byte[]{0,2,1,1,1,1},
//98  I 1 1 2/b
new byte[]{0,2,1,1,1,1},
//99  B 1 1 2/b
new byte[]{0,2,1,1,1,1},
//100  A 1 1 2/n
new byte[]{0,2,1,1,1,1},
//101  I 1 1 2/a
new byte[]{0,2,1,1,1,1},
//102  B 2/b 1 1
new byte[]{0,2,1,1,1,1},
//103  C 2/n 1 1
new byte[]{0,2,1,1,1,1},
//104  I 2/c 1 1
new byte[]{0,2,1,1,1,1},
//105  C 2/c 1 1
new byte[]{0,2,1,1,1,1},
//106  B 2/n 1 1
new byte[]{0,2,1,1,1,1},
//107  I 2/b 1 1
new byte[]{0,2,1,1,1,1},
//108  P 2 2 2
new byte[]{0,5,5,5,5,6,6,6,6,7,7,7,7,8,8,8,8,8,8,8,8},
//109  P 2 2 2sub1
new byte[]{0,6,6,7,7},
//110  P 2sub1 2 2
new byte[]{0,6,6,7,7},
//111  P 2 2sub1 2
new byte[]{0,6,6,7,7},
//112  P 2sub1 2sub1 2
new byte[]{0,5,5},
//113  P 2 2sub1 2sub1
new byte[]{0,5,5},
//114  P 2sub1 2 2sub1
new byte[]{0,5,5},
//115  P 2sub1 2sub1 2sub1
new byte[]{0},
//116  C 2 2 2sub1
new byte[]{0,6,7},
//117  A 2sub1 2 2
new byte[]{0,6,7},
//118  B 2 2sub1 2
new byte[]{0,6,7},
//119  C 2 2 2
new byte[]{0,5,5,5,6,6,7,7,8,8,8,8},
//120  A 2 2 2
new byte[]{0,5,5,5,6,6,7,7,8,8,8,8},
//121  B 2 2 2
new byte[]{0,5,5,5,6,6,7,7,8,8,8,8},
//122  F 2 2 2
new byte[]{0,7,6,5,5,6,7,8,8,8,8},
//123  I 2 2 2
new byte[]{0,5,5,6,6,7,7,8,8,8,8},
//124  I 2sub1 2sub1 2sub1
new byte[]{0,5,6,7},
//125  P m m 2
new byte[]{0,9,9,10,10,11,11,11,11},
//126  P 2 m m
new byte[]{0,9,9,10,10,11,11,11,11},
//127  P m 2 m
new byte[]{0,9,9,10,10,11,11,11,11},
//128  P m c 2sub1
new byte[]{0,9,9},
//129  P c m 2sub1
new byte[]{0,9,9},
//130  P 2sub1 m a
new byte[]{0,9,9},
//131  P 2sub1 a m
new byte[]{0,9,9},
//132  P b 2sub1 m
new byte[]{0,9,9},
//133  P m 2sub1 b
new byte[]{0,9,9},
//134  P c c 2
new byte[]{0,5,5,5,5},
//135  P 2 a a
new byte[]{0,5,5,5,5},
//136  P b 2 b
new byte[]{0,5,5,5,5},
//137  P m a 2
new byte[]{0,9,5,5},
//138  P b m 2
new byte[]{0,9,5,5},
//139  P 2 m b
new byte[]{0,9,5,5},
//140  P 2 c m
new byte[]{0,9,5,5},
//141  P c 2 m
new byte[]{0,9,5,5},
//142  P m 2 a
new byte[]{0,9,5,5},
//143  P c a 2sub1
new byte[]{0},
//144  P b c 2sub1
new byte[]{0},
//145  P 2sub1 a b
new byte[]{0},
//146  P 2sub1 c a
new byte[]{0},
//147  P c 2sub1 b
new byte[]{0},
//148  P b 2sub1 a
new byte[]{0},
//149  P n c 2
new byte[]{0,5,5},
//150  P c n 2
new byte[]{0,5,5},
//151  P 2 n a
new byte[]{0,5,5},
//152  P 2 a n
new byte[]{0,5,5},
//153  P b 2 n
new byte[]{0,5,5},
//154  P n 2 b
new byte[]{0,5,5},
//155  P m n 2sub1
new byte[]{0,9},
//156  P n m 2sub1
new byte[]{0,9},
//157  P 2sub1 m n
new byte[]{0,9},
//158  P 2sub1 n m
new byte[]{0,9},
//159  P n 2sub1 m
new byte[]{0,9},
//160  P m 2sub1 n
new byte[]{0,9},
//161  P b a 2
new byte[]{0,5,5},
//162  P 2 c b
new byte[]{0,5,5},
//163  P c 2 a
new byte[]{0,5,5},
//164  P n a 2sub1
new byte[]{0},
//165  P b n 2sub1
new byte[]{0},
//166  P 2sub1 n b
new byte[]{0},
//167  P 2sub1 c n
new byte[]{0},
//168  P c 2sub1 n
new byte[]{0},
//169  P n 2sub1 a
new byte[]{0},
//170  P n n 2
new byte[]{0,5,5},
//171  P 2 n n
new byte[]{0,5,5},
//172  P n 2 n
new byte[]{0,5,5},
//173  C m m 2
new byte[]{0,9,10,5,11,11},
//174  A 2 m m
new byte[]{0,9,10,5,11,11},
//175  B m 2 m
new byte[]{0,9,10,5,11,11},
//176  C m c 2sub1
new byte[]{0,9},
//177  C c m 2sub1
new byte[]{0,9},
//178  A 2sub1 m a
new byte[]{0,9},
//179  A 2sub1 a m
new byte[]{0,9},
//180  B b 2sub1 m
new byte[]{0,9},
//181  B m 2sub1 b
new byte[]{0,9},
//182  C c c 2
new byte[]{0,5,5,5},
//183  A 2 a a
new byte[]{0,5,5,5},
//184  B b 2 b
new byte[]{0,5,5,5},
//185  A m m 2
new byte[]{0,9,9,10,11,11},
//186  B m m 2
new byte[]{0,9,9,10,11,11},
//187  B 2 m m
new byte[]{0,9,9,10,11,11},
//188  C 2 m m
new byte[]{0,9,9,10,11,11},
//189  C m 2 m
new byte[]{0,9,9,10,11,11},
//190  A m 2 m
new byte[]{0,9,9,10,11,11},
//191  A b m 2
new byte[]{0,10,5,5},
//192  B m a 2
new byte[]{0,10,5,5},
//193  B 2 c m
new byte[]{0,10,5,5},
//194  C 2 m b
new byte[]{0,10,5,5},
//195  C m 2 a
new byte[]{0,10,5,5},
//196  A c 2 m
new byte[]{0,10,5,5},
//197  A m a 2
new byte[]{0,9,5},
//198  B b m 2
new byte[]{0,9,5},
//199  B 2 m b
new byte[]{0,9,5},
//200  C 2 c m
new byte[]{0,9,5},
//201  C c 2 m
new byte[]{0,9,5},
//202  A m 2 a
new byte[]{0,9,5},
//203  A b a 2
new byte[]{0,5},
//204  B b a 2
new byte[]{0,5},
//205  B 2 c b
new byte[]{0,5},
//206  C 2 c b
new byte[]{0,5},
//207  C c 2 a
new byte[]{0,5},
//208  A c 2 a
new byte[]{0,5},
//209  F m m 2
new byte[]{0,10,9,5,11},
//210  F 2 m m
new byte[]{0,10,9,5,11},
//211  F m 2 m
new byte[]{0,10,9,5,11},
//212  F d d 2
new byte[]{0,5},
//213  F 2 d d
new byte[]{0,5},
//214  F d 2 d
new byte[]{0,5},
//215  I m m 2
new byte[]{0,9,10,11,11},
//216  I 2 m m
new byte[]{0,9,10,11,11},
//217  I m 2 m
new byte[]{0,9,10,11,11},
//218  I b a 2
new byte[]{0,5,5},
//219  I 2 c b
new byte[]{0,5,5},
//220  I c 2 a
new byte[]{0,5,5},
//221  I m a 2
new byte[]{0,9,5},
//222  I b m 2
new byte[]{0,9,5},
//223  I 2 m b
new byte[]{0,9,5},
//224  I 2 c m
new byte[]{0,9,5},
//225  I c 2 m
new byte[]{0,9,5},
//226  I m 2 a
new byte[]{0,9,5},
//227  P 2/m 2/m 2/m
new byte[]{0,12,12,10,10,9,9,11,11,11,11,13,13,13,13,14,14,14,14,15,15,15,15,15,15,15,15},
//228  P 2/n 2/n 2/n
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//229  P 2/n 2/n 2/n
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//230  P 2/c 2/c 2/m
new byte[]{0,12,5,5,5,5,6,6,7,7,8,8,8,8,16,16,16,16},
//231  P 2/m 2/a 2/a
new byte[]{0,12,5,5,5,5,6,6,7,7,8,8,8,8,16,16,16,16},
//232  P 2/b 2/m 2/b
new byte[]{0,12,5,5,5,5,6,6,7,7,8,8,8,8,16,16,16,16},
//233  P 2/b 2/a 2/n
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//234  P 2/b 2/a 2/n
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//235  P 2/n 2/c 2/b
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//236  P 2/n 2/c 2/b
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//237  P 2/c 2/n 2/a
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//238  P 2/c 2/n 2/a
new byte[]{0,5,5,6,6,7,7,1,1,8,8,8,8},
//239  P 2sub1/m 2/m 2/a
new byte[]{0,9,10,10,6,6,11,11,17,17,17,17},
//240  P 2/m 2sub1/m 2/b
new byte[]{0,9,10,10,6,6,11,11,17,17,17,17},
//241  P 2/b 2sub1/m 2/m
new byte[]{0,9,10,10,6,6,11,11,17,17,17,17},
//242  P 2/c 2/m 2sub1/m
new byte[]{0,9,10,10,6,6,11,11,17,17,17,17},
//243  P 2/m 2/c 2sub1/m
new byte[]{0,9,10,10,6,6,11,11,17,17,17,17},
//244  P 2sub1/m 2/a 2/m
new byte[]{0,9,10,10,6,6,11,11,17,17,17,17},
//245  P 2/n 2sub1/n 2/a
new byte[]{0,7,5,1,1},
//246  P 2sub1/n 2/n 2/b
new byte[]{0,7,5,1,1},
//247  P 2/b 2/n 2sub1/n
new byte[]{0,7,5,1,1},
//248  P 2/c 2sub1/n 2/n
new byte[]{0,7,5,1,1},
//249  P 2sub1/n 2/c 2/n
new byte[]{0,7,5,1,1},
//250  P 2/n 2/a 2sub1/n
new byte[]{0,7,5,1,1},
//251  P 2/m 2/n 2sub1/a
new byte[]{0,9,6,7,7,18,18,18,18},
//252  P 2/n 2/m 2sub1/b
new byte[]{0,9,6,7,7,18,18,18,18},
//253  P 2sub1/b 2/m 2/n
new byte[]{0,9,6,7,7,18,18,18,18},
//254  P 2sub1/c 2/n 2/m
new byte[]{0,9,6,7,7,18,18,18,18},
//255  P 2/n 2sub1/c 2/m
new byte[]{0,9,6,7,7,18,18,18,18},
//256  P 2/m 2sub1/a 2/n
new byte[]{0,9,6,7,7,18,18,18,18},
//257  P 2sub1/c 2/c 2/a
new byte[]{0,5,5,6,1,1},
//258  P 2/c 2sub1/c 2/b
new byte[]{0,5,5,6,1,1},
//259  P 2/b 2sub1/a 2/a
new byte[]{0,5,5,6,1,1},
//260  P 2/c 2/a 2sub1/a
new byte[]{0,5,5,6,1,1},
//261  P 2/b 2/c 2sub1/b
new byte[]{0,5,5,6,1,1},
//262  P 2sub1/b 2/a 2/b
new byte[]{0,5,5,6,1,1},
//263  P 2sub1/b 2sub1/a 2/m
new byte[]{0,12,12,5,5,16,16,16,16},
//264  P 2/m 2sub1/c 2sub1/b
new byte[]{0,12,12,5,5,16,16,16,16},
//265  P 2sub1/c 2/m 2sub1/a
new byte[]{0,12,12,5,5,16,16,16,16},
//266  P 2sub1/c 2sub1/c 2/n
new byte[]{0,5,5,1,1},
//267  P 2/n 2sub1/a 2sub1/a
new byte[]{0,5,5,1,1},
//268  P 2sub1/b 2/n 2sub1/b
new byte[]{0,5,5,1,1},
//269  P 2/b 2sub1/c 2sub1/m
new byte[]{0,12,7,1,1},
//270  P 2sub1/c 2/a 2sub1/m
new byte[]{0,12,7,1,1},
//271  P 2sub1/m 2/c 2sub1/a
new byte[]{0,12,7,1,1},
//272  P 2sub1/m 2sub1/a 2/b
new byte[]{0,12,7,1,1},
//273  P 2sub1/b 2sub1/m 2/a
new byte[]{0,12,7,1,1},
//274  P 2/c 2sub1/m 2sub1/b
new byte[]{0,12,7,1,1},
//275  P 2sub1/n 2sub1/n 2/m
new byte[]{0,12,5,5,16,16,16,16},
//276  P 2/m 2sub1/n 2sub1/n
new byte[]{0,12,5,5,16,16,16,16},
//277  P 2sub1/n 2/m 2sub1/n
new byte[]{0,12,5,5,16,16,16,16},
//278  P 2sub1/m 2sub1/m 2/n
new byte[]{0,10,9,1,1,11,11},
//279  P 2sub1/m 2sub1/m 2/n
new byte[]{0,10,9,1,1,11,11},
//280  P 2/n 2sub1/m 2sub1/m
new byte[]{0,10,9,1,1,11,11},
//281  P 2/n 2sub1/m 2sub1/m
new byte[]{0,10,9,1,1,11,11},
//282  P 2sub1/m 2/n 2sub1/m
new byte[]{0,10,9,1,1,11,11},
//283  P 2sub1/m 2/n 2sub1/m
new byte[]{0,10,9,1,1,11,11},
//284  P 2sub1/b 2/c 2sub1/n
new byte[]{0,6,1,1},
//285  P 2/c 2sub1/a 2sub1/n
new byte[]{0,6,1,1},
//286  P 2sub1/n 2sub1/c 2/a
new byte[]{0,6,1,1},
//287  P 2sub1/n 2/a 2sub1/b
new byte[]{0,6,1,1},
//288  P 2/b 2sub1/n 2sub1/a
new byte[]{0,6,1,1},
//289  P 2sub1/c 2sub1/n 2/b
new byte[]{0,6,1,1},
//290  P 2sub1/b 2sub1/c 2sub1/a
new byte[]{0,1,1},
//291  P 2sub1/c 2sub1/a 2sub1/b
new byte[]{0,1,1},
//292  P 2sub1/n 2sub1/m 2sub1/a
new byte[]{0,10,1,1},
//293  P 2sub1/m 2sub1/n 2sub1/b
new byte[]{0,10,1,1},
//294  P 2sub1/b 2sub1/n 2sub1/m
new byte[]{0,10,1,1},
//295  P 2sub1/c 2sub1/m 2sub1/n
new byte[]{0,10,1,1},
//296  P 2sub1/m 2sub1/c 2sub1/n
new byte[]{0,10,1,1},
//297  P 2sub1/n 2sub1/a 2sub1/m
new byte[]{0,10,1,1},
//298  C 2/m 2/c 2sub1/m
new byte[]{0,12,9,7,1,13,18,18},
//299  C 2/c 2/m 2sub1/m
new byte[]{0,12,9,7,1,13,18,18},
//300  A 2sub1/m 2/m 2/a
new byte[]{0,12,9,7,1,13,18,18},
//301  A 2sub1/m 2/a 2/m
new byte[]{0,12,9,7,1,13,18,18},
//302  B 2/b 2sub1/m 2/m
new byte[]{0,12,9,7,1,13,18,18},
//303  B 2/m 2sub1/m 2/b
new byte[]{0,12,9,7,1,13,18,18},
//304  C 2/m 2/c 2sub1/a
new byte[]{0,9,6,7,1,18,18},
//305  C 2/c 2/m 2sub1/b
new byte[]{0,9,6,7,1,18,18},
//306  A 2sub1/b 2/m a
new byte[]{0,9,6,7,1,18,18},
//307  A 2sub1/c 2/a 2/m
new byte[]{0,9,6,7,1,18,18},
//308  B 2/b 2sub1/c 2/m
new byte[]{0,9,6,7,1,18,18},
//309  B 2/m 2sub1/a 2/b
new byte[]{0,9,6,7,1,18,18},
//310  C 2/m 2/m 2/m
new byte[]{0,12,12,10,9,5,11,11,13,13,14,14,16,16,15,15,15,15},
//311  A 2/m 2/m 2/m
new byte[]{0,12,12,10,9,5,11,11,13,13,14,14,16,16,15,15,15,15},
//312  B 2/m 2/m 2/m
new byte[]{0,12,12,10,9,5,11,11,13,13,14,14,16,16,15,15,15,15},
//313  C 2/c 2/c 2/m
new byte[]{0,12,5,5,5,6,7,16,16,16,16,8,8},
//314  A 2/m 2/a 2/a
new byte[]{0,12,5,5,5,6,7,16,16,16,16,8,8},
//315  B 2/b 2/m 2/b
new byte[]{0,12,5,5,5,6,7,16,16,16,16,8,8},
//316  C 2/m 2/m 2/a
new byte[]{0,10,9,5,6,6,7,7,11,17,17,18,18,8,8},
//317  C 2/m 2/m 2/b
new byte[]{0,10,9,5,6,6,7,7,11,17,17,18,18,8,8},
//318  A 2/b 2/m 2/m
new byte[]{0,10,9,5,6,6,7,7,11,17,17,18,18,8,8},
//319  A 2/c 2/m 2/m
new byte[]{0,10,9,5,6,6,7,7,11,17,17,18,18,8,8},
//320  B 2/m 2/c 2/m
new byte[]{0,10,9,5,6,6,7,7,11,17,17,18,18,8,8},
//321  B 2/m 2/a 2/m
new byte[]{0,10,9,5,6,6,7,7,11,17,17,18,18,8,8},
//322  C 2/c 2/c 2/a
new byte[]{0,5,5,6,7,1,1,8,8},
//323  C 2/c 2/c 2/a
new byte[]{0,5,5,6,7,1,1,8,8},
//324  C 2/c 2/c 2/b
new byte[]{0,5,5,6,7,1,1,8,8},
//325  C 2/c 2/c 2/b
new byte[]{0,5,5,6,7,1,1,8,8},
//326  A 2/b 2/a 2/a
new byte[]{0,5,5,6,7,1,1,8,8},
//327  A 2/b 2/a 2/a
new byte[]{0,5,5,6,7,1,1,8,8},
//328  A 2/c 2/a 2/a
new byte[]{0,5,5,6,7,1,1,8,8},
//329  A 2/c 2/a 2/a
new byte[]{0,5,5,6,7,1,1,8,8},
//330  B 2/b 2/c 2/b
new byte[]{0,5,5,6,7,1,1,8,8},
//331  B 2/b 2/c 2/b
new byte[]{0,5,5,6,7,1,1,8,8},
//332  B 2/b 2/a 2/b
new byte[]{0,5,5,6,7,1,1,8,8},
//333  B 2/b 2/a 2/b
new byte[]{0,5,5,6,7,1,1,8,8},
//334  F 2/m 2/m 2/m
new byte[]{0,12,10,9,7,6,5,11,13,14,8,16,17,18,15,15},
//335  F 2/d 2/d 2/d
new byte[]{0,5,6,7,1,1,8,8},
//336  F 2/d 2/d 2/d
new byte[]{0,5,6,7,1,1,8,8},
//337  I 2/m 2/m 2/m
new byte[]{0,12,10,9,1,11,11,13,13,14,14,15,15,15,15},
//338  I 2/b 2/a 2/m
new byte[]{0,12,5,5,6,7,1,16,16,8,8},
//339  I 2/m 2/c 2/b
new byte[]{0,12,5,5,6,7,1,16,16,8,8},
//340  I 2/c 2/m 2/a
new byte[]{0,12,5,5,6,7,1,16,16,8,8},
//341  I 2/b 2/c 2/a
new byte[]{0,5,6,7,1,1},
//342  I 2/c 2/a 2/b
new byte[]{0,5,6,7,1,1},
//343  I 2/m 2/m 2/a
new byte[]{0,10,9,6,7,11,17,17,18,18},
//344  I 2/m 2/m 2/b
new byte[]{0,10,9,6,7,11,17,17,18,18},
//345  I 2/b 2/m 2/m
new byte[]{0,10,9,6,7,11,17,17,18,18},
//346  I 2/c 2/m 2/m
new byte[]{0,10,9,6,7,11,17,17,18,18},
//347  I 2/m 2/c 2/m
new byte[]{0,10,9,6,7,11,17,17,18,18},
//348  I 2/m 2/a 2/m
new byte[]{0,10,9,6,7,11,17,17,18,18},
//349  P 4
new byte[]{0,7,19,19},
//350  P 4sub1
new byte[]{0},
//351  P 4sub2
new byte[]{0,7,7,7},
//352  P 4sub3
new byte[]{0},
//353  I 4
new byte[]{0,7,19},
//354  I 4sub1
new byte[]{0,7},
//355  P -4
new byte[]{0,7,7,7,20,20,20,20},
//356  I -4
new byte[]{0,7,7,20,20,20,20},
//357  P 4/m
new byte[]{0,9,9,7,19,19,18,18,21,21,21,21},
//358  P 4sub2/m
new byte[]{0,9,7,7,7,20,20,18,18,18,18},
//359  P 4/n
new byte[]{0,7,1,1,19,20,20},
//360  P 4/n
new byte[]{0,7,1,1,19,20,20},
//361  P 4sub2/n
new byte[]{0,7,7,1,1,20,20},
//362  P 4sub2/n
new byte[]{0,7,7,1,1,20,20},
//363  I 4/m
new byte[]{0,9,7,1,19,20,18,21,21},
//364  I 4sub1/a
new byte[]{0,7,1,1,20,20},
//365  I 4sub1/a
new byte[]{0,7,1,1,20,20},
//366  P 4 2 2
new byte[]{0,6,6,6,6,5,5,7,19,19,22,22,23,23,23,23},
//367  P 4 2sub1 2
new byte[]{0,5,5,7,19,24,24},
//368  P 4sub1 2 2
new byte[]{0,5,6,6},
//369  P 4sub1 2sub1 2
new byte[]{0,5},
//370  P 4sub2 2 2
new byte[]{0,5,5,6,6,6,6,7,7,7,24,24,22,22,22,22},
//371  P 4sub2 2sub1 2
new byte[]{0,5,5,7,7,24,24},
//372  P 4sub3 2 2
new byte[]{0,5,6,6},
//373  P 4sub3 2sub1 2
new byte[]{0,5},
//374  I 4 2 2
new byte[]{0,5,6,6,5,7,19,24,22,23,23},
//375  I 4sub1 2 2
new byte[]{0,6,5,5,7,24,24},
//376  P 4 m m
new byte[]{0,10,10,12,25,26,26},
//377  P 4 b m
new byte[]{0,12,27,19},
//378  P 4sub2 c m
new byte[]{0,12,7,27,27},
//379  P 4sub2 n m
new byte[]{0,12,7,27},
//380  P 4 c c
new byte[]{0,7,19,19},
//381  P 4 n c
new byte[]{0,7,19},
//382  P 4sub2 m c
new byte[]{0,10,10,25,25,25},
//383  P 4sub2 b c
new byte[]{0,7,7},
//384  I 4 m m
new byte[]{0,10,12,25,26},
//385  I 4 c m
new byte[]{0,12,27,19},
//386  I 4sub1 m d
new byte[]{0,10,25},
//387  I 4sub1 c d
new byte[]{0,7},
//388  P -4 2 m
new byte[]{0,12,7,6,6,6,6,27,27,22,22,28,28,28,28},
//389  P -4 2 c
new byte[]{0,7,7,7,6,6,6,6,20,20,22,22,22,22},
//390  P -4 2sub1 m
new byte[]{0,12,7,27,20,20},
//391  P -4 2sub1 c
new byte[]{0,7,7,20,20},
//392  P -4 m 2
new byte[]{0,10,10,5,5,25,25,25,29,29,29,29},
//393  P -4 c 2
new byte[]{0,7,7,7,5,5,20,20,24,24},
//394  P -4 b 2
new byte[]{0,5,5,7,7,24,24,20,20},
//395  P -4 n 2
new byte[]{0,7,5,5,7,24,24,20,20},
//396  I -4 m 2
new byte[]{0,10,5,5,25,25,29,29,29,29},
//397  I -4 c 2
new byte[]{0,5,7,7,5,24,20,20,24},
//398  I -4 2 m
new byte[]{0,12,7,6,6,27,20,22,28,28},
//399  I -4 2 d
new byte[]{0,6,7,20,20},
//400  P 4/m 2/m 2/m
new byte[]{0,10,10,12,9,9,30,30,30,30,31,31,25,26,26,32,32,33,33,33,33},
//401  P 4/m 2/c 2/c
new byte[]{0,9,6,6,5,7,19,19,22,18,21,23,21,23},
//402  P 4/n 2/b 2/m
new byte[]{0,12,6,6,5,5,27,19,16,16,28,28,23,23},
//403  P 4/n 2/b 2/m
new byte[]{0,12,6,6,5,5,27,19,16,16,28,28,23,23},
//404  P 4/n 2/n 2/c
new byte[]{0,6,6,5,7,1,19,20,22,23,23},
//405  P 4/n 2/n 2/c
new byte[]{0,6,6,5,7,1,19,20,22,23,23},
//406  P 4/m 2sub1/b m
new byte[]{0,12,9,9,31,31,27,19,34,34,21,21},
//407  P 4/m 2sub1/n c
new byte[]{0,9,5,7,19,24,18,21,21},
//408  P 4/n 2sub1/m m
new byte[]{0,12,10,5,5,25,16,16,26,29,29},
//409  P 4/n 2sub1/m m
new byte[]{0,12,10,5,5,25,16,16,26,29,29},
//410  P 4/n 2sub1/c c
new byte[]{0,5,7,1,19,20,24},
//411  P 4/n 2sub1/c c
new byte[]{0,5,7,1,19,20,24},
//412  P 4sub2/m 2/m 2/c
new byte[]{0,9,10,10,5,30,30,30,30,25,25,25,29,29,32,32,32,32},
//413  P 4sub2/m 2/c 2/m
new byte[]{0,12,9,6,6,7,31,31,27,27,18,22,28,34,28,34},
//414  P 4sub2/n 2/b 2/c
new byte[]{0,5,6,6,7,7,1,20,24,22,22},
//415  P 4sub2/n 2/b 2/c
new byte[]{0,5,6,6,7,7,1,20,24,22,22},
//416  P 4sub2/n 2/n 2/m
new byte[]{0,12,5,5,6,6,7,27,16,16,24,22,28,28},
//417  P 4sub2/n 2/n 2/m
new byte[]{0,12,5,5,6,6,7,27,16,16,24,22,28,28},
//418  P 4sub2/m 2sub1/b 2/c
new byte[]{0,9,5,7,7,24,18,20,18},
//419  P 4sub2/m 2sub1/n 2/m
new byte[]{0,12,9,7,31,31,27,20,18,34,34},
//420  P 4sub2/n 2sub1/m 2/c
new byte[]{0,10,5,1,25,25,29,29},
//421  P 4sub2/n 2sub1/m 2/c
new byte[]{0,10,5,1,25,25,29,29},
//422  P 4sub2/n 2sub1/c 2/m
new byte[]{0,12,5,5,7,27,16,16,20,24},
//423  P 4sub2/n 2sub1/c 2/m
new byte[]{0,12,5,5,7,27,16,16,20,24},
//424  I 4/m 2/m 2/m
new byte[]{0,10,12,9,5,30,30,31,25,16,26,29,32,33,33},
//425  I 4/m 2/c 2/m
new byte[]{0,12,9,6,5,31,27,19,16,34,21,28,23},
//426  I 4sub1/a 2/m 2/d
new byte[]{0,10,5,6,25,17,17,29,29},
//427  I 4sub1/a 2/m 2/d
new byte[]{0,10,5,6,25,17,17,29,29},
//428  I 4sub1/a 2/c 2/d
new byte[]{0,5,6,7,1,24,20},
//429  I 4sub1/a 2/c 2/d
new byte[]{0,5,6,7,1,24,20},
//430  P 3
new byte[]{0,35,35,35},
//431  P 3sub1
new byte[]{0},
//432  P 3sub2
new byte[]{0},
//433  R 3
new byte[]{0,36},
//434  R 3
new byte[]{0,36},
//435  P -3
new byte[]{0,1,1,35,35,37,37},
//436  R -3
new byte[]{0,1,1,36,38,38},
//437  R -3
new byte[]{0,1,1,36,38,38},
//438  P 3 1 2
new byte[]{0,5,5,35,35,35,39,39,39,39,39,39},
//439  P 3 2 1
new byte[]{0,6,6,35,35,40,40},
//440  P 3sub1 1 2
new byte[]{0,5,5},
//441  P 3sub1 2 1
new byte[]{0,6,6},
//442  P 3sub2 1 2
new byte[]{0,5,5},
//443  P 3sub2 2 1
new byte[]{0,6,6},
//444  R 3 2
new byte[]{0,41,41,36,42,42},
//445  R 3 2
new byte[]{0,41,41,36,42,42},
//446  P 3 m 1
new byte[]{0,10,43,43,43},
//447  P 3 1 m
new byte[]{0,12,35,44},
//448  P 3 c 1
new byte[]{0,35,35,35},
//449  P 3 1 c
new byte[]{0,35,35},
//450  R 3 m
new byte[]{0,45,46},
//451  R 3 m
new byte[]{0,45,46},
//452  R 3 c
new byte[]{0,36},
//453  R 3 c
new byte[]{0,36},
//454  P -3 1 2/m
new byte[]{0,12,5,5,35,16,16,44,39,39,47,47},
//455  P -3 1 2/c
new byte[]{0,5,1,35,35,39,39,37,39},
//456  P -3 2/m 1
new byte[]{0,10,6,6,17,17,43,43,48,48},
//457  P -3 2/c 1
new byte[]{0,6,1,35,35,37,40},
//458  R -3 2/m
new byte[]{0,45,41,41,49,49,46,50,50},
//459  R -3 2/m
new byte[]{0,45,41,41,49,49,46,50,50},
//460  R -3 2/c
new byte[]{0,41,1,36,38,42},
//461  R -3 2/c
new byte[]{0,41,1,36,38,42},
//462  P 6
new byte[]{0,7,35,51},
//463  P 6sub1
new byte[]{0,},
//464  P 6sub5
new byte[]{0,},
//465  P 6sub2
new byte[]{0,7,7},
//466  P 6sub4
new byte[]{0,7,7},
//467  P 6sub3
new byte[]{0,35,35},
//468  P -6
new byte[]{0,9,9,35,35,35,52,52,52,52,52,52},
//469  P 6/m
new byte[]{0,9,9,7,35,18,18,51,52,52,53,53},
//470  P 6sub3/m
new byte[]{0,9,1,35,35,52,52,37,52},
//471  P 6 2 2
new byte[]{0,5,5,6,6,7,35,8,8,51,39,39,54,54},
//472  P 6sub1 2 2
new byte[]{0,5,6,},
//473  P 6sub5 2 2
new byte[]{0,5,6,},
//474  P 6sub2 2 2
new byte[]{0,5,5,6,6,7,7,8,8,8,8},
//475  P 6sub4 2 2
new byte[]{0,5,5,6,6,7,7,8,8,8,8},
//476  P 6sub3 2 2
new byte[]{0,5,6,35,35,39,39,39,40},
//477  P 6 m m
new byte[]{0,10,12,14,43,55},
//478  P 6 c c
new byte[]{0,7,35,51},
//479  P 6sub3 c m
new byte[]{0,12,35,44},
//480  P 6sub3 m c
new byte[]{0,10,43,43},
//481  P -6 m 2
new byte[]{0,10,9,9,11,11,43,43,43,56,56,56,56,56,56},
//482  P -6 c 2
new byte[]{0,9,5,35,35,35,52,39,52,39,52,39},
//483  P -6 2 m
new byte[]{0,9,9,12,35,13,13,44,52,52,57,57},
//484  P -6 2 c
new byte[]{0,9,6,35,35,52,52,52,40},
//485  P 6/m 2/m 2/m
new byte[]{0,9,9,10,12,11,11,13,13,14,43,15,15,55,56,56,58,58},
//486  P 6/m 2/c 2/c
new byte[]{0,9,5,6,7,35,18,8,51,52,39,53,54},
//487  P 6sub3/m 2/c 2/m
new byte[]{0,12,9,5,35,13,16,44,39,52,47,57},
//488  P 6sub3/m 2/m 2/c
new byte[]{0,10,9,6,11,17,43,43,56,56,56,48},
//489  P 2 3
new byte[]{0,7,7,7,7,59,60,60,61,61},
//490  F 2 3
new byte[]{0,7,7,59,61,61,61,61},
//491  I 2 3
new byte[]{0,7,7,59,60,61},
//492  P 2sub1 3
new byte[]{0,59},
//493  I 2sub1 3
new byte[]{0,7,59},
//494  P 2/m -3
new byte[]{0,9,9,59,62,62,62,62,63,63,64,64},
//495  P 2/n -3
new byte[]{0,7,7,59,60,65,65,61},
//496  P 2/n -3
new byte[]{0,7,7,59,60,65,65,61},
//497  F 2/m -3
new byte[]{0,9,7,59,62,18,61,64,64},
//498  F 2/d -3
new byte[]{0,7,59,65,65,61,61},
//499  F 2/d -3
new byte[]{0,7,59,65,65,61,61},
//500  I 2/m -3
new byte[]{0,9,59,62,62,65,63,64},
//501  P 2sub1/a -3
new byte[]{0,59,65,65},
//502  I 2sub1/a -3
new byte[]{0,7,59,65,65},
//503  P 4 3 2
new byte[]{0,5,5,7,59,19,19,66,66,67,67},
//504  P 4sub2 3 2
new byte[]{0,5,5,7,7,7,59,24,24,60,68,68,61},
//505  F 4 3 2
new byte[]{0,7,5,5,59,19,24,61,67,67},
//506  F 4sub1 3 2
new byte[]{0,5,7,59,68,68,61,61},
//507  I 4 3 2
new byte[]{0,5,5,7,59,19,24,68,66,67},
//508  P 4sub3 3 2
new byte[]{0,5,59,68,68},
//509  P 4sub1 3 2
new byte[]{0,5,59,68,68},
//510  I 4sub1 3 2
new byte[]{0,5,5,7,59,24,24,68,68},
//511  P -4 3 m
new byte[]{0,12,7,27,27,69,70,70,71,71},
//512  F -4 3 m
new byte[]{0,12,27,27,69,71,71,71,71},
//513  I -4 3 m
new byte[]{0,12,7,27,20,69,70,71},
//514  P -4 3 n
new byte[]{0,7,7,7,59,20,20,60,61},
//515  F -4 3 c
new byte[]{0,7,7,59,20,20,61,61},
//516  I -4 3 d
new byte[]{0,7,59,20,20,},
//517  P 4/m -3 2/m
new byte[]{0,12,9,9,72,72,62,69,73,73,74,74,75,75},
//518  P 4/n -3 2/n
new byte[]{0,5,7,59,19,20,65,66,67},
//519  P 4/n -3 2/n
new byte[]{0,5,7,59,19,20,65,66,67},
//520  P 4sub2/m -3 2/n
new byte[]{0,9,5,59,62,62,62,68,76,76,63,64},
//521  P 4sub2/n -3 2/m
new byte[]{0,12,5,5,7,27,24,69,70,77,77,71},
//522  P 4sub2/n -3 2/m
new byte[]{0,12,5,5,7,27,24,69,70,77,77,71},
//523  F 4/m -3 2/m
new byte[]{0,12,9,72,72,27,69,73,34,71,75,75},
//524  F 4/m -3 2/c
new byte[]{0,9,5,59,19,62,21,76,64,67},
//525  F 4sub1/d -3 2/m
new byte[]{0,5,12,27,69,77,77,71,71},
//526  F 4sub1/d -3 2/m
new byte[]{0,5,12,27,69,77,77,71,71},
//527  F 4sub1/d -3 2/c
new byte[]{0,5,7,59,20,65,68,61},
//528  F 4sub1/d -3 2/c
new byte[]{0,5,7,59,20,65,68,61},
//529  I 4/m -3 2/m
new byte[]{0,12,9,5,72,62,69,73,76,77,74,75},
//530  I 4sub1/a -3 2/d
new byte[]{0,5,7,59,20,24,68,65,},
//531  C -1
new byte[]{0,1,1,1,1,1,1,1,1,1,1,1,1},
//532  I -1
new byte[]{0,1,1,1,1,1,1,1,1,1,1,1,1},
//533  A -1
new byte[]{0,1,1,1,1,1,1,1,1,1,1,1,1},
//534  B -1
new byte[]{0,1,1,1,1,1,1,1,1,1,1,1,1},
//535  F -1
new byte[]{0,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1},
//536  A 1
new byte[]{0},
//537  B 1
new byte[]{0},
//538  C 1
new byte[]{0},
//539  F 1
new byte[]{0}
#endregion
        };
    public static readonly string[] SiteSymmetryList = new string[]
        {
				#region siteSymmetryList
"1",
"-1",
"2",
"m",
"2/m",
"..2",
".2.",
"2..",
"222",
"m..",
".m.",
"mm2",
"..m",
"m2m",
"2mm",
"mmm",
"..2/m",
".2/m.",
"2/m..",
"4..",
"-4..",
"4/m..",
"222.",
"422",
"2.22",
"2mm.",
"4mm",
"2.mm",
"-42m",
"-4m2",
"m2m.",
"m.2m",
"mmm.",
"4/mmm",
"m.mm",
"3..",
"3.",
"-3..",
"-3.",
"3.2",
"32.",
".2",
"32",
"3m.",
"3.m",
".m",
"3m",
"-3.m",
"-3m.",
".2/m",
"-3m",
"6..",
"-6..",
"6/m..",
"622",
"6mm",
"-6m2",
"-62m",
"6/mmm",
".3.",
"222..",
"23.",
"mm2..",
"mmm..",
"m-3.",
".-3.",
"42.2",
"432",
".32",
".3m",
"-42.m",
"-43m",
"m.m2",
"4m.m",
"4/mm.m",
"m-3m",
"-4m.2",
".-3m"
            #endregion
        };
    public static readonly ushort[][][] BelongingNumberOfSymmetry = new ushort[][][]{
				#region BelongingNumberOfSymmetry
					new ushort[][]{//unknown
						new ushort[]{0}
                        },
					//triclinic
					new ushort[][]{
                        new ushort[]{1,536,537,538,539},
                        new ushort[]{2,533,534,531,532,535}
                        },
					//mono
					new ushort[][]{
                        new ushort[]{3,4,5,6,7,8,9,10,11,12,13,14,15,16,17},
                        new ushort[]{18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56},
                        new ushort[]{57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100,101,102,103,104,105,106,107}
                        },
					//ortho
					new ushort[][]{
                        new ushort[]{108,109,110,111,112,113,114,115,116,117,118,119,120,121,122,123,124},
                        new ushort[]{125,126,127,128,129,130,131,132,133,134,135,136,137,138,139,140,141,142,143,144,145,146,147,148,149,150,151,152,153,154,155,156,157,158,159,160,161,162,163,164,165,166,167,168,169,170,171,172,173,174,175,176,177,178,179,180,181,182,183,184,185,186,187,188,189,190,191,192,193,194,195,196,197,198,199,200,201,202,203,204,205,206,207,208,209,210,211,212,213,214,215,216,217,218,219,220,221,222,223,224,225,226},
                        new ushort[]{227,228,229,230,231,232,233,234,235,236,237,238,239,240,241,242,243,244,245,246,247,248,249,250,251,252,253,254,255,256,257,258,259,260,261,262,263,264,265,266,267,268,269,270,271,272,273,274,275,276,277,278,279,280,281,282,283,284,285,286,287,288,289,290,291,292,293,294,295,296,297,298,299,300,301,302,303,304,305,306,307,308,309,310,311,312,313,314,315,316,317,318,319,320,321,322,323,324,325,326,327,328,329,330,331,332,333,334,335,336,337,338,339,340,341,342,343,344,345,346,347,348}
                        },
					//tetra
					new ushort[][]{
                        new ushort[]{349,350,351,352,353,354},
                        new ushort[]{355,356},
                        new ushort[]{357,358,359,360,361,362,363,364,365},
                        new ushort[]{366,367,368,369,370,371,372,373,374,375},
                        new ushort[]{376,377,378,379,380,381,382,383,384,385,386,387},
                        new ushort[]{388,389,390,391,392,393,394,395,396,397,398,399},
                        new ushort[]{400,401,402,403,404,405,406,407,408,409,410,411,412,413,414,415,416,417,418,419,420,421,422,423,424,425,426,427,428,429}
                        },
					//trigonal
					new ushort[][]{
                        new ushort[]{430,431,432,433,434},
                        new ushort[]{435,436,437},
                        new ushort[]{438,439,440,441,442,443,444,445},
                        new ushort[]{446,447,448,449,450,451,452,453},
                        new ushort[]{454,455,456,457,458,459,460,461}
                        },
					//hexa
					new ushort[][]{
                        new ushort[]{462,463,464,465,466,467},
                        new ushort[]{468},
                        new ushort[]{469,470},
                        new ushort[]{471,472,473,474,475,476},
                        new ushort[]{477,478,479,480},
                        new ushort[]{481,482,483,484},
                        new ushort[]{485,486,487,488}
                        },
					//cubic
					new ushort[][]{
                        new ushort[]{489,490,491,492,493},
                        new ushort[]{494,495,496,497,498,499,500,501,502},
                        new ushort[]{503,504,505,506,507,508,509,510},
                        new ushort[]{511,512,513,514,515,516},
                        new ushort[]{517,518,519,520,521,522,523,524,525,526,527,528,529,530}
                        }
					#endregion
		};

    public static readonly Symmetry[] Symmetries;

    /// <summary>
    /// WyckoffPositions[i][j]: 通し番号がi番目の空間群のj番目のワイコフ位置
    /// </summary>
    public static readonly WyckoffPosition[][] WyckoffPositions;

    /// <summary>
    ///   0:extra表記 1:SF表記 2	Hall表記 3:HM表記	 4HM表記full 5:主軸 6	:格子タイプ
    ///   7:1軸平行操作 8:1軸垂直操作, 9:2軸平行操作, 10:2軸垂直操作, 11:3軸平行操作, 12:3軸垂直操作
    ///   13:点群名前HM, 14:点群名前SF, 15:ラウエ, 16:結晶系
    /// </summary>
    public static readonly string[][] StrArray = new string[][]
        {
				#region StrArray
new[]{"","Unknown","Unknown","Unknown","Unknown","","Unknown","Unknown","Unknown","Unknown","Unknown","Unknown","Unknown","Unknown","Unknown","Unknown","Unknown"},
new[]{"","C1^1","P1","P1","P1","","P","1","","1","","1","","1","C1","-1",t},
new[]{"","Ci^1","-P1","P-1","P-1","","P","-1","","1","","1","","-1","Ci","-1",t},
new[]{"b","C2^1","P2y","P2=P121","P121","b","P","1","","2","","1","","2","C2","2/m",m},
new[]{"c","C2^1","P2","P2=P112","P112","c","P","1","","1","","2","","2","C2","2/m",m},
new[]{"a","C2^1","P2x","P2=P211","P211","a","P","2","","1","","1","","2","C2","2/m",m},
new[]{"b","C2^2","P2yb","P2sub1=P12sub11","P12sub11","b","P","1","","2s1","","1","","2","C2","2/m",m},
new[]{"c","C2^2","P2c","P2sub1=P112sub1","P112sub1","c","P","1","","1","","2s1","","2","C2","2/m",m},
new[]{"a","C2^2","P2xa","P2sub1=P2sub111","P2sub111","a","P","2s1","","1","","1","","2","C2","2/m",m},
new[]{"b1","C2^3","C2y","C2=C121","C121","b","C","1","","2","","1","","2","C2","2/m",m},
new[]{"b2","C2^3","A2y","C2=A121","A121","b","A","1","","2","","1","","2","C2","2/m",m},
new[]{"b3","C2^3","I2y","C2=I121","I121","b","I","1","","2","","1","","2","C2","2/m",m},
new[]{"c1","C2^3","A2","C2=A112","A112","c","A","1","","1","","2","","2","C2","2/m",m},
new[]{"c2","C2^3","B2","C2=B112=B2","B112","c","B","1","","1","","2","","2","C2","2/m",m},
new[]{"c3","C2^3","I2","C2=I112","I112","c","I","1","","1","","2","","2","C2","2/m",m},
new[]{"a1","C2^3","B2x","C2=B211","B211","a","B","2","","1","","1","","2","C2","2/m",m},
new[]{"a2","C2^3","C2x","C2=C211","C211","a","C","2","","1","","1","","2","C2","2/m",m},
new[]{"a3","C2^3","I2x","C2=I211","I211","a","I","2","","1","","1","","2","C2","2/m",m},
new[]{"b","Cs^1","P-2y","Pm=P1m1","P1m1","b","P","1","","1","m","1","","m","Cs","2/m",m},
new[]{"c","Cs^1","P-2","Pm=P11m","P11m","c","P","1","","1","","1","m","m","Cs","2/m",m},
new[]{"a","Cs^1","P-2x","Pm=Pm11","Pm11","a","P","","m","1","","1","","m","Cs","2/m",m},
new[]{"b1","Cs^2","P-2yc","Pc=P1c1","P1c1","b","P","1","","","c","1","","m","Cs","2/m",m},
new[]{"b2","Cs^2","P-2yac","Pc=P1n1","P1n1","b","P","1","","","n","1","","m","Cs","2/m",m},
new[]{"b3","Cs^2","P-2ya","Pc=P1a1","P1a1","b","P","1","","","a","1","","m","Cs","2/m",m},
new[]{"c1","Cs^2","P-2a","Pc=P11a","P11a","c","P","1","","1","","","a","m","Cs","2/m",m},
new[]{"c2","Cs^2","P-2ab","Pc=P11n","P11n","c","P","1","","1","","","n","m","Cs","2/m",m},
new[]{"c3","Cs^2","P-2b","Pc=P11b=Pb","P11b","c","P","1","","1","","","b","m","Cs","2/m",m},
new[]{"a1","Cs^2","P-2xb","Pc=Pb11","Pb11","a","P","","b","1","","1","","m","Cs","2/m",m},
new[]{"a2","Cs^2","P-2xbc","Pc=Pn11","Pn11","a","P","","n","1","","1","","m","Cs","2/m",m},
new[]{"a3","Cs^2","P-2xc","Pc=Pc11","Pc11","a","P","","c","1","","1","","m","Cs","2/m",m},
new[]{"b1","Cs^3","C-2y","Cm=C1m1","C1m1","b","C","1","","","m","1","","m","Cs","2/m",m},
new[]{"b2","Cs^3","A-2y","Cm=A1m1","A1m1","b","A","1","","","m","1","","m","Cs","2/m",m},
new[]{"b3","Cs^3","I-2y","Cm=I1m1","I1m1","b","I","1","","","m","1","","m","Cs","2/m",m},
new[]{"c1","Cs^3","A-2","Cm=A11m","A11m","c","A","1","","1","","","m","m","Cs","2/m",m},
new[]{"c2","Cs^3","B-2","Cm=B11m=Bm","B11m","c","B","1","","1","","","m","m","Cs","2/m",m},
new[]{"c3","Cs^3","I-2","Cm=I11m","I11m","c","I","1","","1","","","m","m","Cs","2/m",m},
new[]{"a1","Cs^3","B-2x","Cm=Bm11","Bm11","a","B","","m","1","","1","","m","Cs","2/m",m},
new[]{"a2","Cs^3","C-2x","Cm=Cm11","Cm11","a","C","","m","1","","1","","m","Cs","2/m",m},
new[]{"a3","Cs^3","I-2x","Cm=Im11","Im11","a","I","","m","1","","1","","m","Cs","2/m",m},
new[]{"b1","Cs^4","C-2yc","Cc=C1c1","C1c1","b","C","1","","","c","1","","m","Cs","2/m",m},
new[]{"b2","Cs^4","A-2yac","Cc=A1n1","A1n1","b","A","1","","","n","1","","m","Cs","2/m",m},
new[]{"b3","Cs^4","I-2ya","Cc=I1a1","I1a1","b","I","1","","","a","1","","m","Cs","2/m",m},
new[]{"-b1","Cs^4","A-2ya","Cc=A1a1","A1a1","b","A","1","","","a","1","","m","Cs","2/m",m},
new[]{"-b2","Cs^4","C-2ybc","Cc=C1n1","C1n1","b","C","1","","","n","1","","m","Cs","2/m",m},
new[]{"-b3","Cs^4","I-2yc","Cc=I1c1","I1c1","b","I","1","","","c","1","","m","Cs","2/m",m},
new[]{"c1","Cs^4","A-2a","Cc=A11a","A11a","c","A","1","","1","","","a","m","Cs","2/m",m},
new[]{"c2","Cs^4","B-2bc","Cc=B11n","B11n","c","B","1","","1","","","n","m","Cs","2/m",m},
new[]{"c3","Cs^4","I-2b","Cc=I11b","I11b","c","I","1","","1","","","b","m","Cs","2/m",m},
new[]{"-c1","Cs^4","B-2b","Cc=B11b=Bb","B11b","c","B","1","","1","","","b","m","Cs","2/m",m},
new[]{"-c2","Cs^4","A-2ac","Cc=A11n","A11n","c","A","1","","1","","","n","m","Cs","2/m",m},
new[]{"-c3","Cs^4","I-2a","Cc=I11a","I11a","c","I","1","","1","","","a","m","Cs","2/m",m},
new[]{"a1","Cs^4","B-2xb","Cc=Bb11","Bb11","a","B","","b","1","","1","","m","Cs","2/m",m},
new[]{"a2","Cs^4","C-2xbc","Cc=Cn11","Cn11","a","C","","n","1","","1","","m","Cs","2/m",m},
new[]{"a3","Cs^4","I-2xc","Cc=Ic11","Ic11","a","I","","c","1","","1","","m","Cs","2/m",m},
new[]{"-a1","Cs^4","C-2xc","Cc=Cc11","Cc11","a","C","","c","1","","1","","m","Cs","2/m",m},
new[]{"-a2","Cs^4","B-2xbc","Cc=Bn11","Bn11","a","B","","n","1","","1","","m","Cs","2/m",m},
new[]{"-a3","Cs^4","I-2xb","Cc=Ib11","Ib11","a","I","","b","1","","1","","m","Cs","2/m",m},
new[]{"b","C2h^1","-P2y","P2/m=P12/m1","P12/m1","b","P","1","","2","m","1","","2/m","C2h","2/m",m},
new[]{"c","C2h^1","-P2","P2/m=P112/m","P112/m","c","P","1","","1","","2","m","2/m","C2h","2/m",m},
new[]{"a","C2h^1","-P2x","P2/m=P2/m11","P2/m11","a","P","2","m","1","","1","","2/m","C2h","2/m",m},
new[]{"b","C2h^2","-P2yb","P2sub1/m=P12sub1/m1","P12sub1/m1","b","P","1","","2s1","m","1","","2/m","C2h","2/m",m},
new[]{"c","C2h^2","-P2c","P2sub1/m=P112sub1/m","P112sub1/m","c","P","1","","1","","2s1","m","2/m","C2h","2/m",m},
new[]{"a","C2h^2","-P2xa","P2sub1/m=P2sub1/m11","P2sub1/m11","a","P","2s1","m","1","","1","","2/m","C2h","2/m",m},
new[]{"b1","C2h^3","-C2y","C2/m=C12/m1","C12/m1","b","C","1","","2","m","1","","2/m","C2h","2/m",m},
new[]{"b2","C2h^3","-A2y","C2/m=A12/m1","A12/m1","b","A","1","","2","m","1","","2/m","C2h","2/m",m},
new[]{"b3","C2h^3","-I2y","C2/m=I12/m1","I12/m1","b","I","1","","2","m","1","","2/m","C2h","2/m",m},
new[]{"c1","C2h^3","-A2","C2/m=A112/m","A112/m","c","A","1","","1","","2","m","2/m","C2h","2/m",m},
new[]{"c2","C2h^3","-B2","C2/m=B112/m=B2/m","B112/m","c","B","1","","1","","2","m","2/m","C2h","2/m",m},
new[]{"c3","C2h^3","-I2","C2/m=I112/m","I112/m","c","I","1","","1","","2","m","2/m","C2h","2/m",m},
new[]{"a1","C2h^3","-B2x","C2/m=B2/m11","B2/m11","a","B","2","m","1","","1","","2/m","C2h","2/m",m},
new[]{"a2","C2h^3","-C2x","C2/m=C2/m11","C2/m11","a","C","2","m","1","","1","","2/m","C2h","2/m",m},
new[]{"a3","C2h^3","-I2x","C2/m=I2/m11","I2/m11","a","I","2","m","1","","1","","2/m","C2h","2/m",m},
new[]{"b1","C2h^4","-P2yc","P2/c=P12/c1","P12/c1","b","P","1","","2","c","1","","2/m","C2h","2/m",m},
new[]{"b2","C2h^4","-P2yac","P2/c=P12/n1","P12/n1","b","P","1","","2","n","1","","2/m","C2h","2/m",m},
new[]{"b3","C2h^4","-P2ya","P2/c=P12/a1","P12/a1","b","P","1","","2","a","1","","2/m","C2h","2/m",m},
new[]{"c1","C2h^4","-P2a","P2/c=P112/a","P112/a","c","P","1","","1","","2","a","2/m","C2h","2/m",m},
new[]{"c2","C2h^4","-P2ab","P2/c=P112/n","P112/n","c","P","1","","1","","2","n","2/m","C2h","2/m",m},
new[]{"c3","C2h^4","-P2b","P2/c=P112/b=P2/b","P112/b","c","P","1","","1","","2","b","2/m","C2h","2/m",m},
new[]{"a1","C2h^4","-P2xb","P2/c=P2/b11","P2/b11","a","P","2","b","1","","1","","2/m","C2h","2/m",m},
new[]{"a2","C2h^4","-P2xbc","P2/c=P2/n11","P2/n11","a","P","2","n","1","","1","","2/m","C2h","2/m",m},
new[]{"a3","C2h^4","-P2xc","P2/c=P2/c11","P2/c11","a","P","2","c","1","","1","","2/m","C2h","2/m",m},
new[]{"b1","C2h^5","-P2ybc","P2sub1/c=P12sub1/c1","P12sub1/c1","b","P","1","","2s1","c","1","","2/m","C2h","2/m",m},
new[]{"b2","C2h^5","-P2yn","P2sub1/c=P12sub1/n1","P12sub1/n1","b","P","1","","2s1","n","1","","2/m","C2h","2/m",m},
new[]{"b3","C2h^5","-P2yab","P2sub1/c=P12sub1/a1","P12sub1/a1","b","P","1","","2s1","a","1","","2/m","C2h","2/m",m},
new[]{"c1","C2h^5","-P2ac","P2sub1/c=P112sub1/a","P112sub1/a","c","P","1","","1","","2s1","a","2/m","C2h","2/m",m},
new[]{"c2","C2h^5","-P2n","P2sub1/c=P112sub1/n","P112sub1/n","c","P","1","","1","","2s1","n","2/m","C2h","2/m",m},
new[]{"c3","C2h^5","-P2bc","P2sub1/c=P112sub1/b=P2sub1/b","P112sub1/b","c","P","1","","1","","2s1","b","2/m","C2h","2/m",m},
new[]{"a1","C2h^5","-P2xab","P2sub1/c=P2sub1/b11","P2sub1/b11","a","P","2s1","b","1","","1","","2/m","C2h","2/m",m},
new[]{"a2","C2h^5","-P2xn","P2sub1/c=P2sub1/n11","P2sub1/n11","a","P","2s1","n","1","","1","","2/m","C2h","2/m",m},
new[]{"a3","C2h^5","-P2xac","P2sub1/c=P2sub1/c11","P2sub1/c11","a","P","2s1","c","1","","1","","2/m","C2h","2/m",m},
new[]{"b1","C2h^6","-C2yc","C2/c=C12/c1","C12/c1","b","C","1","","2","c","1","","2/m","C2h","2/m",m},
new[]{"b2","C2h^6","-A2yac","C2/c=A12/n1","A12/n1","b","A","1","","2","n","1","","2/m","C2h","2/m",m},
new[]{"b3","C2h^6","-I2ya","C2/c=I12/a1","I12/a1","b","I","1","","2","a","1","","2/m","C2h","2/m",m},
new[]{"-b1","C2h^6","-A2ya","C2/c=A12/a1","A12/a1","b","A","1","","2","a","1","","2/m","C2h","2/m",m},
new[]{"-b2","C2h^6","-C2ybc","C2/c=C12/n1","C12/n1","b","C","1","","2","n","1","","2/m","C2h","2/m",m},
new[]{"-b3","C2h^6","-I2yc","C2/c=I12/c1","I12/c1","b","I","1","","2","c","1","","2/m","C2h","2/m",m},
new[]{"c1","C2h^6","-A2a","C2/c=A112/a","A112/a","c","A","1","","1","","2","a","2/m","C2h","2/m",m},
new[]{"c2","C2h^6","-B2bc","C2/c=B112/n","B112/n","c","B","1","","1","","2","n","2/m","C2h","2/m",m},
new[]{"c3","C2h^6","-I2b","C2/c=I112/b","I112/b","c","I","1","","1","","2","b","2/m","C2h","2/m",m},
new[]{"-c1","C2h^6","-B2b","C2/c=B112/b=B2/b","B112/b","c","B","1","","1","","2","b","2/m","C2h","2/m",m},
new[]{"-c2","C2h^6","-A2ac","C2/c=A112/n","A112/n","c","A","1","","1","","2","n","2/m","C2h","2/m",m},
new[]{"-c3","C2h^6","-I2a","C2/c=I112/a","I112/a","c","I","1","","1","","2","a","2/m","C2h","2/m",m},
new[]{"a1","C2h^6","-B2xb","C2/c=B2/b11","B2/b11","a","B","2","b","1","","1","","2/m","C2h","2/m",m},
new[]{"a2","C2h^6","-C2xbc","C2/c=C2/n11","C2/n11","a","C","2","n","1","","1","","2/m","C2h","2/m",m},
new[]{"a3","C2h^6","-I2xc","C2/c=I2/c11","I2/c11","a","I","2","c","1","","1","","2/m","C2h","2/m",m},
new[]{"-a1","C2h^6","-C2xc","C2/c=C2/c11","C2/c11","a","C","2","c","1","","1","","2/m","C2h","2/m",m},
new[]{"-a2","C2h^6","-B2xbc","C2/c=B2/n11","B2/n11","a","B","2","n","1","","1","","2/m","C2h","2/m",m},
new[]{"-a3","C2h^6","-I2xb","C2/c=I2/b11","I2/b11","a","I","2","b","1","","1","","2/m","C2h","2/m",m},
new[]{"","D2^1","P22","P222","P222","","P","2","","2","","2","","222","D2","mmm",o},
new[]{"","D2^2","P2c2","P222sub1","P222sub1","","P","2","","2","","2s1","","222","D2","mmm",o},
new[]{"cab","D2^2","P2a2a","P2sub122","P2sub122","","P","2s1","","2","","2","","222","D2","mmm",o},
new[]{"bca","D2^2","P22b","P22sub12","P22sub12","","P","2","","2s1","","2","","222","D2","mmm",o},
new[]{"","D2^3","P22ab","P2sub12sub12","P2sub12sub12","","P","2s1","","2s1","","2","","222","D2","mmm",o},
new[]{"cab","D2^3","P2bc2","P22sub12sub1","P22sub12sub1","","P","2","","2s1","","2s1","","222","D2","mmm",o},
new[]{"bca","D2^3","P2ac2ac","P2sub122sub1","P2sub122sub1","","P","2s1","","2","","2s1","","222","D2","mmm",o},
new[]{"","D2^4","P2ac2ab","P2sub12sub12sub1","P2sub12sub12sub1","","P","2s1","","2s1","","2s1","","222","D2","mmm",o},
new[]{"","D2^5","C2c2","C222sub1","C222sub1","","C","2","","2","","2s1","","222","D2","mmm",o},
new[]{"cab","D2^5","A2a2a","A2sub122","A2sub122","","A","2s1","","2","","2","","222","D2","mmm",o},
new[]{"bca","D2^5","B22b","B22sub12","B22sub12","","B","2","","2s1","","2","","222","D2","mmm",o},
new[]{"","D2^6","C22","C222","C222","","C","2","","2","","2","","222","D2","mmm",o},
new[]{"cab","D2^6","A22","A222","A222","","A","2","","2","","2","","222","D2","mmm",o},
new[]{"bca","D2^6","B22","B222","B222","","B","2","","2","","2","","222","D2","mmm",o},
new[]{"","D2^7","F22","F222","F222","","F","2","","2","","2","","222","D2","mmm",o},
new[]{"","D2^8","I22","I222","I222","","I","2","","2","","2","","222","D2","mmm",o},
new[]{"","D2^9","I2b2c","I2sub12sub12sub1","I2sub12sub12sub1","","I","2s1","","2s1","","2s1","","222","D2","mmm",o},
new[]{"","C2v^1","P2-2","Pmm2","Pmm2","","P","","m","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^1","P-22","P2mm","P2mm","","P","2","","","m","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^1","P-2-2","Pm2m","Pm2m","","P","","m","2","","","m","mm2","C2v","mmm",o},
new[]{"","C2v^2","P2c-2","Pmc2sub1","Pmc2sub1","","P","","m","","c","2s1","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^2","P2c-2c","Pcm2sub1","Pcm2sub1","","P","","c","","m","2s1","","mm2","C2v","mmm",o},
new[]{"cab","C2v^2","P-2a2a","P2sub1ma","P2sub1ma","","P","2s1","","","m","","a","mm2","C2v","mmm",o},
new[]{"-cba","C2v^2","P-22a","P2sub1am","P2sub1am","","P","2s1","","","a","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^2","P-2-2b","Pb2sub1m","Pb2sub1m","","P","","b","2s1","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^2","P-2b-2","Pm2sub1b","Pm2sub1b","","P","","m","2s1","","","b","mm2","C2v","mmm",o},
new[]{"","C2v^3","P2-2c","Pcc2","Pcc2","","P","","c","","c","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^3","P-2a2","P2aa","P2aa","","P","2","","","a","","a","mm2","C2v","mmm",o},
new[]{"bca","C2v^3","P-2b-2b","Pb2b","Pb2b","","P","","b","2","","","b","mm2","C2v","mmm",o},
new[]{"","C2v^4","P2-2a","Pma2","Pma2","","P","","m","","a","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^4","P2-2b","Pbm2","Pbm2","","P","","b","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^4","P-2b2","P2mb","P2mb","","P","2","","","m","","b","mm2","C2v","mmm",o},
new[]{"-cba","C2v^4","P-2c2","P2cm","P2cm","","P","2","","","c","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^4","P-2c-2c","Pc2m","Pc2m","","P","","c","2","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^4","P-2a-2a","Pm2a","Pm2a","","P","","m","2","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^5","P2c-2ac","Pca2sub1","Pca2sub1","","P","","c","","a","2s1","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^5","P2c-2b","Pbc2sub1","Pbc2sub1","","P","","b","","c","2s1","","mm2","C2v","mmm",o},
new[]{"cab","C2v^5","P-2b2a","P2sub1ab","P2sub1ab","","P","2s1","","","a","","b","mm2","C2v","mmm",o},
new[]{"-cba","C2v^5","P-2ac2a","P2sub1ca","P2sub1ca","","P","2s1","","","c","","a","mm2","C2v","mmm",o},
new[]{"bca","C2v^5","P-2bc-2c","Pc2sub1b","Pc2sub1b","","P","","c","2s1","","","b","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^5","P-2a-2ab","Pb2sub1a","Pb2sub1a","","P","","b","2s1","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^6","P2-2bc","Pnc2","Pnc2","","P","","n","","c","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^6","P2-2ac","Pcn2","Pcn2","","P","","c","","n","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^6","P-2ac2","P2na","P2na","","P","2","","","n","","a","mm2","C2v","mmm",o},
new[]{"-cba","C2v^6","P-2ab2","P2an","P2an","","P","2","","","a","","n","mm2","C2v","mmm",o},
new[]{"bca","C2v^6","P-2ab-2ab","Pb2n","Pb2n","","P","","b","2","","","n","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^6","P-2bc-2bc","Pn2b","Pn2b","","P","","n","2","","","b","mm2","C2v","mmm",o},
new[]{"","C2v^7","P2ac-2","Pmn2sub1","Pmn2sub1","","P","","m","","n","2s1","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^7","P2bc-2bc","Pnm2sub1","Pnm2sub1","","P","","n","","m","2s1","","mm2","C2v","mmm",o},
new[]{"cab","C2v^7","P-2ab2ab","P2sub1mn","P2sub1mn","","P","2s1","","","m","","n","mm2","C2v","mmm",o},
new[]{"-cba","C2v^7","P-22ac","P2sub1nm","P2sub1nm","","P","2s1","","","n","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^7","P-2-2bc","Pn2sub1m","Pn2sub1m","","P","","n","2s1","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^7","P-2ab-2","Pm2sub1n","Pm2sub1n","","P","","m","2s1","","","n","mm2","C2v","mmm",o},
new[]{"","C2v^8","P2-2ab","Pba2","Pba2","","P","","b","","a","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^8","P-2bc2","P2cb","P2cb","","P","2","","","c","","b","mm2","C2v","mmm",o},
new[]{"bca","C2v^8","P-2ac-2ac","Pc2a","Pc2a","","P","","c","2","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^9","P2c-2n","Pna2sub1","Pna2sub1","","P","","n","","a","2s1","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^9","P2c-2ab","Pbn2sub1","Pbn2sub1","","P","","b","","n","2s1","","mm2","C2v","mmm",o},
new[]{"cab","C2v^9","P-2bc2a","P2sub1nb","P2sub1nb","","P","2s1","","","n","","b","mm2","C2v","mmm",o},
new[]{"-cba","C2v^9","P-2n2a","P2sub1cn","P2sub1cn","","P","2s1","","","c","","n","mm2","C2v","mmm",o},
new[]{"bca","C2v^9","P-2n-2ac","Pc2sub1n","Pc2sub1n","","P","","c","2s1","","","n","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^9","P-2ac-2n","Pn2sub1a","Pn2sub1a","","P","","n","2s1","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^10","P2-2n","Pnn2","Pnn2","","P","","n","","n","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^10","P-2n2","P2nn","P2nn","","P","2","","","n","","n","mm2","C2v","mmm",o},
new[]{"bca","C2v^10","P-2n-2n","Pn2n","Pn2n","","P","","n","2","","","n","mm2","C2v","mmm",o},
new[]{"","C2v^11","C2-2","Cmm2","Cmm2","","C","","m","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^11","A-22","A2mm","A2mm","","A","2","","","m","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^11","B-2-2","Bm2m","Bm2m","","B","","m","2","","","m","mm2","C2v","mmm",o},
new[]{"","C2v^12","C2c-2","Cmc2sub1","Cmc2sub1","","C","","m","","c","2s1","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^12","C2c-2c","Ccm2sub1","Ccm2sub1","","C","","c","","m","2s1","","mm2","C2v","mmm",o},
new[]{"cab","C2v^12","A-2a2a","A2sub1ma","A2sub1ma","","A","2s1","","","m","","a","mm2","C2v","mmm",o},
new[]{"-cba","C2v^12","A-22a","A2sub1am","A2sub1am","","A","2s1","","","a","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^12","B-2-2b","Bb2sub1m","Bb2sub1m","","B","","b","2s1","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^12","B-2b-2","Bm2sub1b","Bm2sub1b","","B","","m","2s1","","","b","mm2","C2v","mmm",o},
new[]{"","C2v^13","C2-2c","Ccc2","Ccc2","","C","","c","","c","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^13","A-2a2","A2aa","A2aa","","A","2","","","a","","a","mm2","C2v","mmm",o},
new[]{"bca","C2v^13","B-2b-2b","Bb2b","Bb2b","","B","","b","2","","","b","mm2","C2v","mmm",o},
new[]{"","C2v^14","A2-2","Amm2","Amm2","","A","","m","","m","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^14","B2-2","Bmm2","Bmm2","","B","","m","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^14","B-22","B2mm","B2mm","","B","2","","","m","","m","mm2","C2v","mmm",o},
new[]{"-cba","C2v^14","C-22","C2mm","C2mm","","C","2","","","m","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^14","C-2-2","Cm2m","Cm2m","","C","","m","2","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^14","A-2-2","Am2m","Am2m","","A","","m","2","","","m","mm2","C2v","mmm",o},
new[]{"","C2v^15","A2-2c","Aem2","Aem2","","A","","b","","m","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^15","B2-2c","Bme2","Bme2","","B","","m","","a","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^15","B-2c2","B2em","B2em","","B","2","","","c","","m","mm2","C2v","mmm",o},
new[]{"-cba","C2v^15","C-2b2","C2me","C2me","","C","2","","","m","","b","mm2","C2v","mmm",o},
new[]{"bca","C2v^15","C-2b-2b","Cm2e","Cm2e","","C","","m","2","","","a","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^15","A-2c-2c","Ae2m","Ae2m","","A","","c","2","","","m","mm2","C2v","mmm",o},
new[]{"","C2v^16","A2-2a","Ama2","Ama2","","A","","m","","a","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^16","B2-2b","Bbm2","Bbm2","","B","","b","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^16","B-2b2","B2mb","B2mb","","B","2","","","m","","b","mm2","C2v","mmm",o},
new[]{"-cba","C2v^16","C-2c2","C2cm","C2cm","","C","2","","","c","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^16","C-2c-2c","Cc2m","Cc2m","","C","","c","2","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^16","A-2a-2a","Am2a","Am2a","","A","","m","2","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^17","A2-2ac","Aea2","Aea2","","A","","b","","a","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^17","B2-2bc","Bbe2","Bbe2","","B","","b","","a","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^17","B-2bc2","B2eb","B2eb","","B","2","","","c","","b","mm2","C2v","mmm",o},
new[]{"-cba","C2v^17","C-2bc2","C2ce","C2ce","","C","2","","","c","","b","mm2","C2v","mmm",o},
new[]{"bca","C2v^17","C-2bc-2bc","Cc2e","Cc2e","","C","","c","2","","","a","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^17","A-2ac-2ac","Ae2a","Ae2a","","A","","c","2","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^18","F2-2","Fmm2","Fmm2","","F","","m","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^18","F-22","F2mm","F2mm","","F","2","","","m","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^18","F-2-2","Fm2m","Fm2m","","F","","m","2","","","m","mm2","C2v","mmm",o},
new[]{"","C2v^19","F2-2d","Fdd2","Fdd2","","F","","d","","d","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^19","F-2d2","F2dd","F2dd","","F","2","","","d","","d","mm2","C2v","mmm",o},
new[]{"bca","C2v^19","F-2d-2d","Fd2d","Fd2d","","F","","d","2","","","d","mm2","C2v","mmm",o},
new[]{"","C2v^20","I2-2","Imm2","Imm2","","I","","m","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^20","I-22","I2mm","I2mm","","I","2","","","m","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^20","I-2-2","Im2m","Im2m","","I","","m","2","","","m","mm2","C2v","mmm",o},
new[]{"","C2v^21","I2-2c","Iba2","Iba2","","I","","b","","a","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^21","I-2a2","I2cb","I2cb","","I","2","","","c","","b","mm2","C2v","mmm",o},
new[]{"bca","C2v^21","I-2b-2b","Ic2a","Ic2a","","I","","c","2","","","a","mm2","C2v","mmm",o},
new[]{"","C2v^22","I2-2a","Ima2","Ima2","","I","","m","","a","2","","mm2","C2v","mmm",o},
new[]{"ba-c","C2v^22","I2-2b","Ibm2","Ibm2","","I","","b","","m","2","","mm2","C2v","mmm",o},
new[]{"cab","C2v^22","I-2b2","I2mb","I2mb","","I","2","","","m","","b","mm2","C2v","mmm",o},
new[]{"-cba","C2v^22","I-2c2","I2cm","I2cm","","I","2","","","c","","m","mm2","C2v","mmm",o},
new[]{"bca","C2v^22","I-2c-2c","Ic2m","Ic2m","","I","","c","2","","","m","mm2","C2v","mmm",o},
new[]{"a-cb","C2v^22","I-2a-2a","Im2a","Im2a","","I","","m","2","","","a","mm2","C2v","mmm",o},
new[]{"","D2h^1","-P22","Pmmm","P2/m2/m2/m","","P","2","m","2","m","2","m","mmm","D2h","mmm",o},
new[]{"1","D2h^2","P22-1n","Pnnn(1)","P2/n2/n2/n","","P","2","n","2","n","2","n","mmm","D2h","mmm",o},
new[]{"2","D2h^2","-P2ab2bc","Pnnn(2)","P2/n2/n2/n","","P","2","n","2","n","2","n","mmm","D2h","mmm",o},
new[]{"","D2h^3","-P22c","Pccm","P2/c2/c2/m","","P","2","c","2","c","2","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^3","-P2a2","Pmaa","P2/m2/a2/a","","P","2","m","2","a","2","a","mmm","D2h","mmm",o},
new[]{"bca","D2h^3","-P2b2b","Pbmb","P2/b2/m2/b","","P","2","b","2","m","2","b","mmm","D2h","mmm",o},
new[]{"1","D2h^4","P22-1ab","Pban(1)","P2/b2/a2/n","","P","2","b","2","a","2","n","mmm","D2h","mmm",o},
new[]{"2","D2h^4","-P2ab2b","Pban(2)","P2/b2/a2/n","","P","2","b","2","a","2","n","mmm","D2h","mmm",o},
new[]{"1cab","D2h^4","P22-1bc","Pncb(1)","P2/n2/c2/b","","P","2","n","2","c","2","b","mmm","D2h","mmm",o},
new[]{"2cab","D2h^4","-P2b2bc","Pncb(2)","P2/n2/c2/b","","P","2","n","2","c","2","b","mmm","D2h","mmm",o},
new[]{"1bca","D2h^4","P22-1ac","Pcna(1)","P2/c2/n2/a","","P","2","c","2","n","2","a","mmm","D2h","mmm",o},
new[]{"2bca","D2h^4","-P2a2c","Pcna(2)","P2/c2/n2/a","","P","2","c","2","n","2","a","mmm","D2h","mmm",o},
new[]{"","D2h^5","-P2a2a","Pmma","P2sub1/m2/m2/a","","P","2s1","m","2","m","2","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^5","-P2b2","Pmmb","P2/m2sub1/m2/b","","P","2","m","2s1","m","2","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^5","-P22b","Pbmm","P2/b2sub1/m2/m","","P","2","b","2s1","m","2","m","mmm","D2h","mmm",o},
new[]{"-cba","D2h^5","-P2c2c","Pcmm","P2/c2/m2sub1/m","","P","2","c","2","m","2s1","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^5","-P2c2","Pmcm","P2/m2/c2sub1/m","","P","2","m","2","c","2s1","m","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^5","-P22a","Pmam","P2sub1/m2/a2/m","","P","2s1","m","2","a","2","m","mmm","D2h","mmm",o},
new[]{"","D2h^6","-P2a2bc","Pnna","P2/n2sub1/n2/a","","P","2","n","2s1","n","2","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^6","-P2b2n","Pnnb","P2sub1/n2/n2/b","","P","2s1","n","2","n","2","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^6","-P2n2b","Pbnn","P2/b2/n2sub1/n","","P","2","b","2","n","2s1","n","mmm","D2h","mmm",o},
new[]{"-cba","D2h^6","-P2ab2c","Pcnn","P2/c2sub1/n2/n","","P","2","c","2s1","n","2","n","mmm","D2h","mmm",o},
new[]{"bca","D2h^6","-P2ab2n","Pncn","P2sub1/n2/c2/n","","P","2s1","n","2","c","2","n","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^6","-P2n2bc","Pnan","P2/n2/a2sub1/n","","P","2","n","2","a","2s1","n","mmm","D2h","mmm",o},
new[]{"","D2h^7","-P2ac2","Pmna","P2/m2/n2sub1/a","","P","2","m","2","n","2s1","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^7","-P2bc2bc","Pnmb","P2/n2/m2sub1/b","","P","2","n","2","m","2s1","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^7","-P2ab2ab","Pbmn","P2sub1/b2/m2/n","","P","2s1","b","2","m","2","n","mmm","D2h","mmm",o},
new[]{"-cba","D2h^7","-P22ac","Pcnm","P2sub1/c2/n2/m","","P","2s1","c","2","n","2","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^7","-P22bc","Pncm","P2/n2sub1/c2/m","","P","2","n","2s1","c","2","m","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^7","-P2ab2","Pman","P2/m2sub1/a2/n","","P","2","m","2s1","a","2","n","mmm","D2h","mmm",o},
new[]{"","D2h^8","-P2a2ac","Pcca","P2sub1/c2/c2/a","","P","2s1","c","2","c","2","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^8","-P2b2c","Pccb","P2/c2sub1/c2/b","","P","2","c","2s1","c","2","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^8","-P2a2b","Pbaa","P2/b2sub1/a2/a","","P","2","b","2s1","a","2","a","mmm","D2h","mmm",o},
new[]{"-cba","D2h^8","-P2ac2c","Pcaa","P2/c2/a2sub1/a","","P","2","c","2","a","2s1","a","mmm","D2h","mmm",o},
new[]{"bca","D2h^8","-P2bc2b","Pbcb","P2/b2/c2sub1/b","","P","2","b","2","c","2s1","b","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^8","-P2b2ab","Pbab","P2sub1/b2/a2/b","","P","2s1","b","2","a","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^9","-P22ab","Pbam","P2sub1/b2sub1/a2/m","","P","2s1","b","2s1","a","2","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^9","-P2bc2","Pmcb","P2/m2sub1/c2sub1/b","","P","2","m","2s1","c","2s1","b","mmm","D2h","mmm",o},
new[]{"bca","D2h^9","-P2ac2ac","Pcma","P2sub1/c2/m2sub1/a","","P","2s1","c","2","m","2s1","a","mmm","D2h","mmm",o},
new[]{"","D2h^10","-P2ab2ac","Pccn","P2sub1/c2sub1/c2/n","","P","2s1","c","2s1","c","2","n","mmm","D2h","mmm",o},
new[]{"cab","D2h^10","-P2ac2bc","Pnaa","P2/n2sub1/a2sub1/a","","P","2","n","2s1","a","2s1","a","mmm","D2h","mmm",o},
new[]{"bca","D2h^10","-P2bc2ab","Pbnb","P2sub1/b2/n2sub1/b","","P","2s1","b","2","n","2s1","b","mmm","D2h","mmm",o},
new[]{"","D2h^11","-P2c2b","Pbcm","P2/b2sub1/c2sub1/m","","P","2","b","2s1","c","2s1","m","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^11","-P2c2ac","Pcam","P2sub1/c2/a2sub1/m","","P","2s1","c","2","a","2s1","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^11","-P2ac2a","Pmca","P2sub1/m2/c2sub1/a","","P","2s1","m","2","c","2s1","a","mmm","D2h","mmm",o},
new[]{"-cba","D2h^11","-P2b2a","Pmab","P2sub1/m2sub1/a2/b","","P","2s1","m","2s1","a","2","b","mmm","D2h","mmm",o},
new[]{"bca","D2h^11","-P2a2ab","Pbma","P2sub1/b2sub1/m2/a","","P","2s1","b","2s1","m","2","a","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^11","-P2bc2c","Pcmb","P2/c2sub1/m2sub1/b","","P","2","c","2s1","m","2s1","b","mmm","D2h","mmm",o},
new[]{"","D2h^12","-P22n","Pnnm","P2sub1/n2sub1/n2/m","","P","2s1","n","2s1","n","2","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^12","-P2n2","Pmnn","P2/m2sub1/n2sub1/n","","P","2","m","2s1","n","2s1","n","mmm","D2h","mmm",o},
new[]{"bca","D2h^12","-P2n2n","Pnmn","P2sub1/n2/m2sub1/n","","P","2s1","n","2","m","2s1","n","mmm","D2h","mmm",o},
new[]{"1","D2h^13","P22ab-1ab","Pmmn(1)","P2sub1/m2sub1/m2/n","","P","2s1","m","2s1","m","2","n","mmm","D2h","mmm",o},
new[]{"2","D2h^13","-P2ab2a","Pmmn(2)","P2sub1/m2sub1/m2/n","","P","2s1","m","2s1","m","2","n","mmm","D2h","mmm",o},
new[]{"1cab","D2h^13","P2bc2-1bc","Pnmm(1)","P2/n2sub1/m2sub1/m","","P","2","n","2s1","m","2s1","m","mmm","D2h","mmm",o},
new[]{"2cab","D2h^13","-P2c2bc","Pnmm(2)","P2/n2sub1/m2sub1/m","","P","2","n","2s1","m","2s1","m","mmm","D2h","mmm",o},
new[]{"1bca","D2h^13","P2ac2ac-1ac","Pmnm(1)","P2sub1/m2/n2sub1/m","","P","2s1","m","2","n","2s1","m","mmm","D2h","mmm",o},
new[]{"2bca","D2h^13","-P2c2a","Pmnm(2)","P2sub1/m2/n2sub1/m","","P","2s1","m","2","n","2s1","m","mmm","D2h","mmm",o},
new[]{"","D2h^14","-P2n2ab","Pbcn","P2sub1/b2/c2sub1/n","","P","2s1","b","2","c","2s1","n","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^14","-P2n2c","Pcan","P2/c2sub1/a2sub1/n","","P","2","c","2s1","a","2s1","n","mmm","D2h","mmm",o},
new[]{"cab","D2h^14","-P2a2n","Pnca","P2sub1/n2sub1/c2/a","","P","2s1","n","2s1","c","2","a","mmm","D2h","mmm",o},
new[]{"-cba","D2h^14","-P2bc2n","Pnab","P2sub1/n2/a2sub1/b","","P","2s1","n","2","a","2s1","b","mmm","D2h","mmm",o},
new[]{"bca","D2h^14","-P2ac2b","Pbna","P2/b2sub1/n2sub1/a","","P","2","b","2s1","n","2s1","a","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^14","-P2b2ac","Pcnb","P2sub1/c2sub1/n2/b","","P","2s1","c","2s1","n","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^15","-P2ac2ab","Pbca","P2sub1/b2sub1/c2sub1/a","","P","2s1","b","2s1","c","2s1","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^15","-P2bc2ac","Pcab","P2sub1/c2sub1/a2sub1/b","","P","2s1","c","2s1","a","2s1","b","mmm","D2h","mmm",o},
new[]{"","D2h^16","-P2ac2n","Pnma","P2sub1/n2sub1/m2sub1/a","","P","2s1","n","2s1","m","2s1","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^16","-P2bc2a","Pmnb","P2sub1/m2sub1/n2sub1/b","","P","2s1","m","2s1","n","2s1","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^16","-P2c2ab","Pbnm","P2sub1/b2sub1/n2sub1/m","","P","2s1","b","2s1","n","2s1","m","mmm","D2h","mmm",o},
new[]{"-cba","D2h^16","-P2n2ac","Pcmn","P2sub1/c2sub1/m2sub1/n","","P","2s1","c","2s1","m","2s1","n","mmm","D2h","mmm",o},
new[]{"bca","D2h^16","-P2n2a","Pmcn","P2sub1/m2sub1/c2sub1/n","","P","2s1","m","2s1","c","2s1","n","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^16","-P2c2n","Pnam","P2sub1/n2sub1/a2sub1/m","","P","2s1","n","2s1","a","2s1","m","mmm","D2h","mmm",o},
new[]{"","D2h^17","-C2c2","Cmcm","C2/m2/c2sub1/m","","C","2","m","2","c","2s1","m","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^17","-C2c2c","Ccmm","C2/c2/m2sub1/m","","C","2","c","2","m","2s1","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^17","-A2a2a","Amma","A2sub1/m2/m2/a","","A","2s1","m","2","m","2","a","mmm","D2h","mmm",o},
new[]{"-cba","D2h^17","-A22a","Amam","A2sub1/m2/a2/m","","A","2s1","m","2","a","2","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^17","-B22b","Bbmm","B2/b2sub1/m2/m","","B","2","b","2s1","m","2","m","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^17","-B2b2","Bmmb","B2/m2sub1/m2/b","","B","2","m","2s1","m","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^18","-C2bc2","Cmce","C2/m2/c2sub1/e","","C","2","m","2","c","2s1","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^18","-C2bc2bc","Ccme","C2/c2/m2sub1/e","","C","2","c","2","m","2s1","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^18","-A2ac2ac","Aema","A2sub1/e2/ma","","A","2s1","b","2","m","","a","mmm","D2h","mmm",o},
new[]{"-cba","D2h^18","-A22ac","Aeam","A2sub1/e2/a2/m","","A","2s1","c","2","a","2","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^18","-B22bc","Bbem","B2/b2sub1/e2/m","","B","2","b","2s1","c","2","m","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^18","-B2bc2","Bmeb","B2/m2sub1/e2/b","","B","2","m","2s1","a","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^19","-C22","Cmmm","C2/m2/m2/m","","C","2","m","2","m","2","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^19","-A22","Ammm","A2/m2/m2/m","","A","2","m","2","m","2","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^19","-B22","Bmmm","B2/m2/m2/m","","B","2","m","2","m","2","m","mmm","D2h","mmm",o},
new[]{"","D2h^20","-C22c","Cccm","C2/c2/c2/m","","C","2","c","2","c","2","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^20","-A2a2","Amaa","A2/m2/a2/a","","A","2","m","2","a","2","a","mmm","D2h","mmm",o},
new[]{"bca","D2h^20","-B2b2b","Bbmb","B2/b2/m2/b","","B","2","b","2","m","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^21","-C2b2","Cmme","C2/m2/m2/e","","C","2","m","2","m","2","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^21","-C2b2b","Cmme","C2/m2/m2/e","","C","2","m","2","m","2","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^21","-A2c2c","Aemm","A2/e2/m2/m","","A","2","b","2","m","2","m","mmm","D2h","mmm",o},
new[]{"-cba","D2h^21","-A22c","Aemm","A2/e2/m2/m","","A","2","c","2","m","2","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^21","-B22c","Bmem","B2/m2/e2/m","","B","2","m","2","c","2","m","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^21","-B2c2","Bmem","B2/m2/e2/m","","B","2","m","2","a","2","m","mmm","D2h","mmm",o},
new[]{"1","D2h^22","C22-1bc","Ccce(1)","C2/c2/c2/e","","C","2","c","2","c","2","a","mmm","D2h","mmm",o},
new[]{"2","D2h^22","-C2b2bc","Ccce(2)","C2/c2/c2/e","","C","2","c","2","c","2","a","mmm","D2h","mmm",o},
new[]{"1ba-c","D2h^22","C22-1bc","Ccce(1)","C2/c2/c2/e","","C","2","c","2","c","2","b","mmm","D2h","mmm",o},
new[]{"2ba-c","D2h^22","-C2b2c","Ccce(2)","C2/c2/c2/e","","C","2","c","2","c","2","b","mmm","D2h","mmm",o},
new[]{"1cab","D2h^22","A22-1ac","Aeaa(1)","A2/e2/a2/a","","A","2","b","2","a","2","a","mmm","D2h","mmm",o},
new[]{"2cab","D2h^22","-A2a2c","Aeaa(2)","A2/e2/a2/a","","A","2","b","2","a","2","a","mmm","D2h","mmm",o},
new[]{"1-cba","D2h^22","A22-1ac","Aeaa(1)","A2/e2/a2/a","","A","2","c","2","a","2","a","mmm","D2h","mmm",o},
new[]{"2-cba","D2h^22","-A2ac2c","Aeaa(2)","A2/e2/a2/a","","A","2","c","2","a","2","a","mmm","D2h","mmm",o},
new[]{"1bca","D2h^22","B22-1bc","Bbeb(1)","B2/b2/e2/b","","B","2","b","2","c","2","b","mmm","D2h","mmm",o},
new[]{"2bca","D2h^22","-B2bc2b","Bbeb(2)","B2/b2/e2/b","","B","2","b","2","c","2","b","mmm","D2h","mmm",o},
new[]{"1a-cb","D2h^22","B22-1bc","Bbeb(1)","B2/b2/e2/b","","B","2","b","2","a","2","b","mmm","D2h","mmm",o},
new[]{"2a-cb","D2h^22","-B2b2bc","Bbeb(2)","B2/b2/e2/b","","B","2","b","2","a","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^23","-F22","Fmmm","F2/m2/m2/m","","F","2","m","2","m","2","m","mmm","D2h","mmm",o},
new[]{"1","D2h^24","F22-1d","Fddd(1)","F2/d2/d2/d","","F","2","d","2","d","2","d","mmm","D2h","mmm",o},
new[]{"2","D2h^24","-F2uv2vw","Fddd(2)","F2/d2/d2/d","","F","2","d","2","d","2","d","mmm","D2h","mmm",o},
new[]{"","D2h^25","-I22","Immm","I2/m2/m2/m","","I","2","m","2","m","2","m","mmm","D2h","mmm",o},
new[]{"","D2h^26","-I22c","Ibam","I2/b2/a2/m","","I","2","b","2","a","2","m","mmm","D2h","mmm",o},
new[]{"cab","D2h^26","-I2a2","Imcb","I2/m2/c2/b","","I","2","m","2","c","2","b","mmm","D2h","mmm",o},
new[]{"bca","D2h^26","-I2b2b","Icma","I2/c2/m2/a","","I","2","c","2","m","2","a","mmm","D2h","mmm",o},
new[]{"","D2h^27","-I2b2c","Ibca","I2/b2/c2/a","","I","2","b","2","c","2","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^27","-I2a2b","Icab","I2/c2/a2/b","","I","2","c","2","a","2","b","mmm","D2h","mmm",o},
new[]{"","D2h^28","-I2b2","Imma","I2/m2/m2/a","","I","2","m","2","m","2","a","mmm","D2h","mmm",o},
new[]{"ba-c","D2h^28","-I2a2a","Immb","I2/m2/m2/b","","I","2","m","2","m","2","b","mmm","D2h","mmm",o},
new[]{"cab","D2h^28","-I2c2c","Ibmm","I2/b2/m2/m","","I","2","b","2","m","2","m","mmm","D2h","mmm",o},
new[]{"-cba","D2h^28","-I22b","Icmm","I2/c2/m2/m","","I","2","c","2","m","2","m","mmm","D2h","mmm",o},
new[]{"bca","D2h^28","-I22a","Imcm","I2/m2/c2/m","","I","2","m","2","c","2","m","mmm","D2h","mmm",o},
new[]{"a-cb","D2h^28","-I2c2","Imam","I2/m2/a2/m","","I","2","m","2","a","2","m","mmm","D2h","mmm",o},
new[]{"","C4^1","P4","P4","P4","","P","4","","1","","1","","4","C4","4/m",te},
new[]{"","C4^2","P4w","P4sub1","P4sub1","","P","4s1","","1","","1","","4","C4","4/m",te},
new[]{"","C4^3","P4c","P4sub2","P4sub2","","P","4s2","","1","","1","","4","C4","4/m",te},
new[]{"","C4^4","P4cw","P4sub3","P4sub3","","P","4s3","","1","","1","","4","C4","4/m",te},
new[]{"","C4^5","I4","I4","I4","","I","4","","1","","1","","4","C4","4/m",te},
new[]{"","C4^6","I4bw","I4sub1","I4sub1","","I","4s1","","1","","1","","4","C4","4/m",te},
new[]{"","S4^1","P-4","P-4","P-4","","P","-4","","1","","1","","-4","S4","4/m",te},
new[]{"","S4^2","I-4","I-4","I-4","","I","-4","","1","","1","","-4","S4","4/m",te},
new[]{"","C4h^1","-P4","P4/m","P4/m","","P","4","m","1","","1","","4/m","C4h","4/m",te},
new[]{"","C4h^2","-P4c","P4sub2/m","P4sub2/m","","P","4s2","m","1","","1","","4/m","C4h","4/m",te},
new[]{"1","C4h^3","P4ab-1ab","P4/n(1)","P4/n","","P","4","n","1","","1","","4/m","C4h","4/m",te},
new[]{"2","C4h^3","-P4a","P4/n(2)","P4/n","","P","4","n","1","","1","","4/m","C4h","4/m",te},
new[]{"1","C4h^4","P4n-1n","P4sub2/n(1)","P4sub2/n","","P","4s2","n","1","","1","","4/m","C4h","4/m",te},
new[]{"2","C4h^4","-P4bc","P4sub2/n(2)","P4sub2/n","","P","4s2","n","1","","1","","4/m","C4h","4/m",te},
new[]{"","C4h^5","-I4","I4/m","I4/m","","I","4","m","1","","1","","4/m","C4h","4/m",te},
new[]{"1","C4h^6","I4bw-1bw","I4sub1/a(1)","I4sub1/a","","I","4s1","a","1","","1","","4/m","C4h","4/m",te},
new[]{"2","C4h^6","-I4ad","I4sub1/a(2)","I4sub1/a","","I","4s1","a","1","","1","","4/m","C4h","4/m",te},
new[]{"","D4^1","P42","P422","P422","","P","4","","2","","2","","422","D4","4/mmm",te},
new[]{"","D4^2","P4ab2ab","P42sub12","P42sub12","","P","4","","2s1","","2","","422","D4","4/mmm",te},
new[]{"","D4^3","P4w2c","P4sub122","P4sub122","","P","4s1","","2","","2","","422","D4","4/mmm",te},
new[]{"","D4^4","P4abw2nw","P4sub12sub12","P4sub12sub12","","P","4s1","","2s1","","2","","422","D4","4/mmm",te},
new[]{"","D4^5","P4c2","P4sub222","P4sub222","","P","4s2","","2","","2","","422","D4","4/mmm",te},
new[]{"","D4^6","P4n2n","P4sub22sub12","P4sub22sub12","","P","4s2","","2s1","","2","","422","D4","4/mmm",te},
new[]{"","D4^7","P4cw2c","P4sub322","P4sub322","","P","4s3","","2","","2","","422","D4","4/mmm",te},
new[]{"","D4^8","P4nw2abw","P4sub32sub12","P4sub32sub12","","P","4s3","","2s1","","2","","422","D4","4/mmm",te},
new[]{"","D4^9","I42","I422","I422","","I","4","","2","","2","","422","D4","4/mmm",te},
new[]{"","D4^10","I4bw2bw","I4sub122","I4sub122","","I","4s1","","2","","2","","422","D4","4/mmm",te},
new[]{"","C4v^1","P4-2","P4mm","P4mm","","P","4","","","m","","m","4mm","C4v","4/mmm",te},
new[]{"","C4v^2","P4-2ab","P4bm","P4bm","","P","4","","","b","","m","4mm","C4v","4/mmm",te},
new[]{"","C4v^3","P4c-2c","P4sub2cm","P4sub2cm","","P","4s2","","","c","","m","4mm","C4v","4/mmm",te},
new[]{"","C4v^4","P4n-2n","P4sub2nm","P4sub2nm","","P","4s2","","","n","","m","4mm","C4v","4/mmm",te},
new[]{"","C4v^5","P4-2c","P4cc","P4cc","","P","4","","","c","","c","4mm","C4v","4/mmm",te},
new[]{"","C4v^6","P4-2n","P4nc","P4nc","","P","4","","","n","","c","4mm","C4v","4/mmm",te},
new[]{"","C4v^7","P4c-2","P4sub2mc","P4sub2mc","","P","4s2","","","m","","c","4mm","C4v","4/mmm",te},
new[]{"","C4v^8","P4c-2ab","P4sub2bc","P4sub2bc","","P","4s2","","","b","","c","4mm","C4v","4/mmm",te},
new[]{"","C4v^9","I4-2","I4mm","I4mm","","I","4","","","m","","m","4mm","C4v","4/mmm",te},
new[]{"","C4v^10","I4-2c","I4cm","I4cm","","I","4","","","c","","m","4mm","C4v","4/mmm",te},
new[]{"","C4v^11","I4bw-2","I4sub1md","I4sub1md","","I","4s1","","","m","","d","4mm","C4v","4/mmm",te},
new[]{"","C4v^12","I4bw-2c","I4sub1cd","I4sub1cd","","I","4s1","","","c","","d","4mm","C4v","4/mmm",te},
new[]{"","D2d^1","P-42","P-42m","P-42m","","P","-4","","2","","","m","-42m","D2d","4/mmm",te},
new[]{"","D2d^2","P-42c","P-42c","P-42c","","P","-4","","2","","","c","-42m","D2d","4/mmm",te},
new[]{"","D2d^3","P-42ab","P-42sub1m","P-42sub1m","","P","-4","","2s1","","","m","-42m","D2d","4/mmm",te},
new[]{"","D2d^4","P-42n","P-42sub1c","P-42sub1c","","P","-4","","2s1","","","c","-42m","D2d","4/mmm",te},
new[]{"","D2d^5","P-4-2","P-4m2","P-4m2","","P","-4","","","m","2","","-42m","D2d","4/mmm",te},
new[]{"","D2d^6","P-4-2c","P-4c2","P-4c2","","P","-4","","","c","2","","-42m","D2d","4/mmm",te},
new[]{"","D2d^7","P-4-2ab","P-4b2","P-4b2","","P","-4","","","b","2","","-42m","D2d","4/mmm",te},
new[]{"","D2d^8","P-4-2n","P-4n2","P-4n2","","P","-4","","","n","2","","-42m","D2d","4/mmm",te},
new[]{"","D2d^9","I-4-2","I-4m2","I-4m2","","I","-4","","","m","2","","-42m","D2d","4/mmm",te},
new[]{"","D2d^10","I-4-2c","I-4c2","I-4c2","","I","-4","","","c","2","","-42m","D2d","4/mmm",te},
new[]{"","D2d^11","I-42","I-42m","I-42m","","I","-4","","2","","","m","-42m","D2d","4/mmm",te},
new[]{"","D2d^12","I-42bw","I-42d","I-42d","","I","-4","","2","","","d","-42m","D2d","4/mmm",te},
new[]{"","D4h^1","-P42","P4/mmm","P4/m2/m2/m","","P","4","m","2","m","2","m","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^2","-P42c","P4/mcc","P4/m2/c2/c","","P","4","m","2","c","2","c","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^3","P42-1ab","P4/nbm(1)","P4/n2/b2/m","","P","4","n","2","b","2","m","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^3","-P4a2b","P4/nbm(2)","P4/n2/b2/m","","P","4","n","2","b","2","m","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^4","P42-1n","P4/nnc(1)","P4/n2/n2/c","","P","4","n","2","n","2","c","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^4","-P4a2bc","P4/nnc(2)","P4/n2/n2/c","","P","4","n","2","n","2","c","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^5","-P42ab","P4/mbm","P4/m2sub1/bm","","P","4","m","2s1","b","","m","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^6","-P42n","P4/mnc","P4/m2sub1/nc","","P","4","m","2s1","n","","c","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^7","P4ab2ab-1ab","P4/nmm(1)","P4/n2sub1/mm","","P","4","n","2s1","m","","m","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^7","-P4a2a","P4/nmm(2)","P4/n2sub1/mm","","P","4","n","2s1","m","","m","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^8","P4ab2n-1ab","P4/ncc(1)","P4/n2sub1/cc","","P","4","n","2s1","c","","c","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^8","-P4a2ac","P4/ncc(2)","P4/n2sub1/cc","","P","4","n","2s1","c","","c","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^9","-P4c2","P4sub2/mmc","P4sub2/m2/m2/c","","P","4s2","m","2","m","2","c","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^10","-P4c2c","P4sub2/mcm","P4sub2/m2/c2/m","","P","4s2","m","2","c","2","m","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^11","P4n2c-1n","P4sub2/nbc(1)","P4sub2/n2/b2/c","","P","4s2","n","2","b","2","c","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^11","-P4ac2b","P4sub2/nbc(2)","P4sub2/n2/b2/c","","P","4s2","n","2","b","2","c","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^12","P4n2-1n","P4sub2/nnm(1)","P4sub2/n2/n2/m","","P","4s2","n","2","n","2","m","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^12","-P4ac2bc","P4sub2/nnm(2)","P4sub2/n2/n2/m","","P","4s2","n","2","n","2","m","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^13","-P4c2ab","P4sub2/mbc","P4sub2/m2sub1/b2/c","","P","4s2","m","2s1","b","2","c","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^14","-P4n2n","P4sub2/mnm","P4sub2/m2sub1/n2/m","","P","4s2","m","2s1","n","2","m","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^15","P4n2n-1n","P4sub2/nmc(1)","P4sub2/n2sub1/m2/c","","P","4s2","n","2s1","m","2","c","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^15","-P4ac2a","P4sub2/nmc(2)","P4sub2/n2sub1/m2/c","","P","4s2","n","2s1","m","2","c","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^16","P4n2ab-1n","P4sub2/ncm(1)","P4sub2/n2sub1/c2/m","","P","4s2","n","2s1","c","2","m","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^16","-P4ac2ac","P4sub2/ncm(2)","P4sub2/n2sub1/c2/m","","P","4s2","n","2s1","c","2","m","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^17","-I42","I4/mmm","I4/m2/m2/m","","I","4","m","2","m","2","m","4/mmm","D4h","4/mmm",te},
new[]{"","D4h^18","-I42c","I4/mcm","I4/m2/c2/m","","I","4","m","2","c","2","m","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^19","I4bw2bw-1bw","I4sub1/amd(1)","I4sub1/a2/m2/d","","I","4s1","a","2","m","2","d","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^19","-I4bd2","I4sub1/amd(2)","I4sub1/a2/m2/d","","I","4s1","a","2","m","2","d","4/mmm","D4h","4/mmm",te},
new[]{"1","D4h^20","I4bw2aw-1bw","I4sub1/acd(1)","I4sub1/a2/c2/d","","I","4s1","a","2","c","2","d","4/mmm","D4h","4/mmm",te},
new[]{"2","D4h^20","-I4bd2c","I4sub1/acd(2)","I4sub1/a2/c2/d","","I","4s1","a","2","c","2","d","4/mmm","D4h","4/mmm",te},
new[]{"","C3^1","P3","P3","P3","","P","3","","1","","1","","3","C3","-3",tr},
new[]{"","C3^2","P31","P3sub1","P3sub1","","P","3s1","","1","","1","","3","C3","-3",tr},
new[]{"","C3^3","P32","P3sub2","P3sub2","","P","3s2","","1","","1","","3","C3","-3",tr},
new[]{"H","C3^4","R3","R3Hex","R3","","R","3","","1","","1","","3","C3","-3",tr},
new[]{"R","C3^4","P3*","R3Rho","R3","","R","3","","1","","1","","3","C3","-3",tr},
new[]{"","C3i^1","-P3","P-3","P-3","","P","-3","","1","","1","","-3","C3i","-3",tr},
new[]{"H","C3i^2","-R3","R-3Hex","R-3","","R","-3","","1","","1","","-3","C3i","-3",tr},
new[]{"R","C3i^2","-P3*","R-3Rho","R-3","","R","-3","","1","","1","","-3","C3i","-3",tr},
new[]{"","D3^1","P32","P312","P312","","P","3","","1","","2","","32","D3","-32m",tr},
new[]{"","D3^2","P32\"","P321","P321","","P","3","","2","","1","","32","D3","-32m",tr},
new[]{"","D3^3","P312c(001)","P3sub112","P3sub112","","P","3s1","","1","","2","","32","D3","-32m",tr},
new[]{"","D3^4","P312\"","P3sub121","P3sub121","","P","3s1","","2","","1","","32","D3","-32m",tr},
new[]{"","D3^5","P322c(00-1)","P3sub212","P3sub212","","P","3s2","","1","","2","","32","D3","-32m",tr},
new[]{"","D3^6","P322\"","P3sub221","P3sub221","","P","3s2","","2","","1","","32","D3","-32m",tr},
new[]{"H","D3^7","R32\"","R32Hex","R32","","R","3","","2","","1","","32","D3","-32m",tr},
new[]{"R","D3^7","P3*2","R32Rho","R32","","R","3","","2","","1","","32","D3","-32m",tr},
new[]{"","C3v^1","P3-2\"","P3m1","P3m1","","P","3","","","m","1","","3m","C3v","-32m",tr},
new[]{"","C3v^2","P3-2","P31m","P31m","","P","3","","1","","","m","3m","C3v","-32m",tr},
new[]{"","C3v^3","P3-2\"c","P3c1","P3c1","","P","3","","","c","1","","3m","C3v","-32m",tr},
new[]{"","C3v^4","P3-2c","P31c","P31c","","P","3","","1","","","c","3m","C3v","-32m",tr},
new[]{"H","C3v^5","R3-2\"","R3mHex","R3m","","R","3","","","m","1","","3m","C3v","-32m",tr},
new[]{"R","C3v^5","P3*-2","R3mRho","R3m","","R","3","","","m","1","","3m","C3v","-32m",tr},
new[]{"H","C3v^6","R3-2\"c","R3cHex","R3c","","R","3","","","c","1","","3m","C3v","-32m",tr},
new[]{"R","C3v^6","P3*-2n","R3cRho","R3c","","R","3","","","c","1","","3m","C3v","-32m",tr},
new[]{"","D3d^1","-P32","P-31m","P-312/m","","P","-3","","1","","2","m","-3m","D3d","-32m",tr},
new[]{"","D3d^2","-P32c","P-31c","P-312/c","","P","-3","","1","","2","c","-3m","D3d","-32m",tr},
new[]{"","D3d^3","-P32\"","P-3m1","P-32/m1","","P","-3","","2","m","1","","-3m","D3d","-32m",tr},
new[]{"","D3d^4","-P32\"c","P-3c1","P-32/c1","","P","-3","","2","c","1","","-3m","D3d","-32m",tr},
new[]{"H","D3d^5","-R32\"","R-3mHex","R-32/m","","R","-3","","2","m","1","","-3m","D3d","-32m",tr},
new[]{"R","D3d^5","-P3*2","R-3mRho","R-32/m","","R","-3","","2","m","1","","-3m","D3d","-32m",tr},
new[]{"H","D3d^6","-R32\"c","R-3cHex","R-32/c","","R","-3","","2","c","1","","-3m","D3d","-32m",tr},
new[]{"R","D3d^6","-P3*2n","R-3cRho","R-32/c","","R","-3","","2","c","1","","-3m","D3d","-32m",tr},
new[]{"","C6^1","P6","P6","P6","","P","6","","1","","1","","6","C6","6/m",h},
new[]{"","C6^2","P61","P6sub1","P6sub1","","P","6s1","","1","","1","","6","C6","6/m",h},
new[]{"","C6^3","P65","P6sub5","P6sub5","","P","6s5","","1","","1","","6","C6","6/m",h},
new[]{"","C6^4","P62","P6sub2","P6sub2","","P","6s2","","1","","1","","6","C6","6/m",h},
new[]{"","C6^5","P64","P6sub4","P6sub4","","P","6s4","","1","","1","","6","C6","6/m",h},
new[]{"","C6^6","P6c","P6sub3","P6sub3","","P","6s3","","1","","1","","6","C6","6/m",h},
new[]{"","C3h^1","P-6","P-6","P-6","","P","-6","","1","","1","","-6","C3h","6/m",h},
new[]{"","C6h^1","-P6","P6/m","P6/m","","P","6","m","1","","1","","6/m","C6h","6/m",h},
new[]{"","C6h^2","-P6c","P6sub3/m","P6sub3/m","","P","6s3","m","1","","1","","6/m","C6h","6/m",h},
new[]{"","D6^1","P62","P622","P622","","P","6","","2","","2","","622","D6","6/mmm",h},
new[]{"","D6^2","P612(00-1)","P6sub122","P6sub122","","P","6s1","","2","","2","","622","D6","6/mmm",h},
new[]{"","D6^3","P652(001)","P6sub522","P6sub522","","P","6s5","","2","","2","","622","D6","6/mmm",h},
new[]{"","D6^4","P622c(001)","P6sub222","P6sub222","","P","6s2","","2","","2","","622","D6","6/mmm",h},
new[]{"","D6^5","P642c(00-1)","P6sub422","P6sub422","","P","6s4","","2","","2","","622","D6","6/mmm",h},
new[]{"","D6^6","P6c2c","P6sub322","P6sub322","","P","6s3","","2","","2","","622","D6","6/mmm",h},
new[]{"","C6v^1","P6-2","P6mm","P6mm","","P","6","","","m","","m","6mm","C6v","6/mmm",h},
new[]{"","C6v^2","P6-2c","P6cc","P6cc","","P","6","","","c","","c","6mm","C6v","6/mmm",h},
new[]{"","C6v^3","P6c-2","P6sub3cm","P6sub3cm","","P","6s3","","","c","","m","6mm","C6v","6/mmm",h},
new[]{"","C6v^4","P6c-2c","P6sub3mc","P6sub3mc","","P","6s3","","","m","","c","6mm","C6v","6/mmm",h},
new[]{"","D3h^1","P-62","P-6m2","P-6m2","","P","-6","","","m","2","","-6m2","D3h","6/mmm",h},
new[]{"","D3h^2","P-6c2","P-6c2","P-6c2","","P","-6","","","c","2","","-6m2","D3h","6/mmm",h},
new[]{"","D3h^3","P-6-2","P-62m","P-62m","","P","-6","","2","","","m","-6m2","D3h","6/mmm",h},
new[]{"","D3h^4","P-6c-2c","P-62c","P-62c","","P","-6","","2","","","c","-6m2","D3h","6/mmm",h},
new[]{"","D6h^1","-P62","P6/mmm","P6/m2/m2/m","","P","6","m","2","m","2","m","6/mmm","D6h","6/mmm",h},
new[]{"","D6h^2","-P62c","P6/mcc","P6/m2/c2/c","","P","6","m","2","c","2","c","6/mmm","D6h","6/mmm",h},
new[]{"","D6h^3","-P6c2","P6sub3/mcm","P6sub3/m2/c2/m","","P","6s3","m","2","c","2","m","6/mmm","D6h","6/mmm",h},
new[]{"","D6h^4","-P6c2c","P6sub3/mmc","P6sub3/m2/m2/c","","P","6s3","m","2","m","2","c","6/mmm","D6h","6/mmm",h},
new[]{"","T^1","P223","P23","P23","","P","2","","3","","1","","23","T","m-3",c},
new[]{"","T^2","F223","F23","F23","","F","2","","3","","1","","23","T","m-3",c},
new[]{"","T^3","I223","I23","I23","","I","2","","3","","1","","23","T","m-3",c},
new[]{"","T^4","P2ac2ab3","P2sub13","P2sub13","","P","2s1","","3","","1","","23","T","m-3",c},
new[]{"","T^5","I2b2c3","I2sub13","I2sub13","","I","2s1","","3","","1","","23","T","m-3",c},
new[]{"","Th^1","-P223","Pm-3","P2/m-3","","P","2","m","-3","","1","","m-3","Th","m-3",c},
new[]{"1","Th^2","P223-1n","Pn-3(1)","P2/n-3","","P","2","n","-3","","1","","m-3","Th","m-3",c},
new[]{"2","Th^2","-P2ab2bc3","Pn-3(2)","P2/n-3","","P","2","n","-3","","1","","m-3","Th","m-3",c},
new[]{"","Th^3","-F223","Fm-3","F2/m-3","","F","2","m","-3","","1","","m-3","Th","m-3",c},
new[]{"1","Th^4","F223-1d","Fd-3(1)","F2/d-3","","F","2","d","-3","","1","","m-3","Th","m-3",c},
new[]{"2","Th^4","-F2uv2vw3","Fd-3(2)","F2/d-3","","F","2","d","-3","","1","","m-3","Th","m-3",c},
new[]{"","Th^5","-I223","Im-3","I2/m-3","","I","2","m","-3","","1","","m-3","Th","m-3",c},
new[]{"","Th^6","-P2ac2ab3","Pa-3","P2sub1/a-3","","P","2s1","a","-3","","1","","m-3","Th","m-3",c},
new[]{"","Th^7","-I2b2c3","Ia-3","I2sub1/a-3","","I","2s1","a","-3","","1","","m-3","Th","m-3",c},
new[]{"","O^1","P423","P432","P432","","P","4","","3","","2","","432","O","m-3m",c},
new[]{"","O^2","P4n23","P4sub232","P4sub232","","P","4s2","","3","","2","","432","O","m-3m",c},
new[]{"","O^3","F423","F432","F432","","F","4","","3","","2","","432","O","m-3m",c},
new[]{"","O^4","F4d23","F4sub132","F4sub132","","F","4s1","","3","","2","","432","O","m-3m",c},
new[]{"","O^5","I423","I432","I432","","I","4","","3","","2","","432","O","m-3m",c},
new[]{"","O^6","P4acd2ab3","P4sub332","P4sub332","","P","4s3","","3","","2","","432","O","m-3m",c},
new[]{"","O^7","P4bd2ab3","P4sub132","P4sub132","","P","4s1","","3","","2","","432","O","m-3m",c},
new[]{"","O^8","I4bd2c3","I4sub132","I4sub132","","I","4s1","","3","","2","","432","O","m-3m",c},
new[]{"","Td^1","P-423","P-43m","P-43m","","P","-4","","3","","","m","-43m","Td","m-3m",c},
new[]{"","Td^2","F-423","F-43m","F-43m","","F","-4","","3","","","m","-43m","Td","m-3m",c},
new[]{"","Td^3","I-423","I-43m","I-43m","","I","-4","","3","","","m","-43m","Td","m-3m",c},
new[]{"","Td^4","P-4n23","P-43n","P-43n","","P","-4","","3","","","n","-43m","Td","m-3m",c},
new[]{"","Td^5","F-4c23","F-43c","F-43c","","F","-4","","3","","","c","-43m","Td","m-3m",c},
new[]{"","Td^6","I-4bd2c3","I-43d","I-43d","","I","-4","","3","","","d","-43m","Td","m-3m",c},
new[]{"","Oh^1","-P423","Pm-3m","P4/m-32/m","","P","4","m","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"1","Oh^2","P423-1n","Pn-3n(1)","P4/n-32/n","","P","4","n","-3","","2","n","m-3m","Oh","m-3m",c},
new[]{"2","Oh^2","-P4a2bc3","Pn-3n(2)","P4/n-32/n","","P","4","n","-3","","2","n","m-3m","Oh","m-3m",c},
new[]{"","Oh^3","-P4n23","Pm-3n","P4sub2/m-32/n","","P","4s2","m","-3","","2","n","m-3m","Oh","m-3m",c},
new[]{"1","Oh^4","P4n23-1n","Pn-3m(1)","P4sub2/n-32/m","","P","4s2","n","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"2","Oh^4","-P4bc2bc3","Pn-3m(2)","P4sub2/n-32/m","","P","4s2","n","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"","Oh^5","-F423","Fm-3m","F4/m-32/m","","F","4","m","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"","Oh^6","-F4c23","Fm-3c","F4/m-32/c","","F","4","m","-3","","2","c","m-3m","Oh","m-3m",c},
new[]{"1","Oh^7","F4d23-1d","Fd-3m(1)","F4sub1/d-32/m","","F","4s1","d","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"2","Oh^7","-F4vw2vw3","Fd-3m(2)","F4sub1/d-32/m","","F","4s1","d","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"1","Oh^8","F4d23-1cd","Fd-3c(1)","F4sub1/d-32/c","","F","4s1","d","-3","","2","c","m-3m","Oh","m-3m",c},
new[]{"2","Oh^8","-F4cvw2vw3","Fd-3c(2)","F4sub1/d-32/c","","F","4s1","d","-3","","2","c","m-3m","Oh","m-3m",c},
new[]{"","Oh^9","-I423","Im-3m","I4/m-32/m","","I","4","m","-3","","2","m","m-3m","Oh","m-3m",c},
new[]{"","Oh^10","-I4bd2c3","Ia-3d","I4sub1/a-32/d","","I","4s1","a","-3","","2","d","m-3m","Oh","m-3m",c},
new[]{"","Ci^1","-C1","C-1","C-1","","C","-1","","1","","1","","-1","Ci","-1",t},
new[]{"","Ci^1","-I1","I-1","I-1","","I","-1","","1","","1","","-1","Ci","-1",t},
new[]{"","Ci^1","-A1","A-1","A-1","","A","-1","","1","","1","","-1","Ci","-1",t},
new[]{"","Ci^1","-B1","B-1","B-1","","B","-1","","1","","1","","-1","Ci","-1",t},
new[]{"","Ci^1","-F1","F-1","F-1","","F","-1","","1","","1","","-1","Ci","-1",t},
new[]{"","C1^1","A1","A1","A1","","A","1","","1","","1","","1","Ci","1",t},
new[]{"","C1^1","B1","B1","B1","","B","1","","1","","1","","1","Ci","1",t},
new[]{"","C1^1","C1","C1","C1","","C","1","","1","","1","","1","Ci","1",t},
new[]{"","C1^1","F1","F1","F1","","F","1","","1","","1","","1","Ci","1",t},
            #endregion
        };

    /// <summary>
    /// 0:通し番号 1:空間群番号 2:空間群のSub番号 3:点群番号 4:ラウエ群番号 5:結晶系番号
    /// </summary>
    public static readonly ushort[][] NumArray = new ushort[][]
        {
				#region numArrayの定義
new ushort[]{0,0,0,0,0,0},
new ushort[]{1,1,1,1,1,1},
new ushort[]{2,2,1,2,1,1},
new ushort[]{3,3,1,3,2,2},
new ushort[]{4,3,2,3,2,2},
new ushort[]{5,3,3,3,2,2},
new ushort[]{6,4,1,3,2,2},
new ushort[]{7,4,2,3,2,2},
new ushort[]{8,4,3,3,2,2},
new ushort[]{9,5,1,3,2,2},
new ushort[]{10,5,2,3,2,2},
new ushort[]{11,5,3,3,2,2},
new ushort[]{12,5,4,3,2,2},
new ushort[]{13,5,5,3,2,2},
new ushort[]{14,5,6,3,2,2},
new ushort[]{15,5,7,3,2,2},
new ushort[]{16,5,8,3,2,2},
new ushort[]{17,5,9,3,2,2},
new ushort[]{18,6,1,4,2,2},
new ushort[]{19,6,2,4,2,2},
new ushort[]{20,6,3,4,2,2},
new ushort[]{21,7,1,4,2,2},
new ushort[]{22,7,2,4,2,2},
new ushort[]{23,7,3,4,2,2},
new ushort[]{24,7,4,4,2,2},
new ushort[]{25,7,5,4,2,2},
new ushort[]{26,7,6,4,2,2},
new ushort[]{27,7,7,4,2,2},
new ushort[]{28,7,8,4,2,2},
new ushort[]{29,7,9,4,2,2},
new ushort[]{30,8,1,4,2,2},
new ushort[]{31,8,2,4,2,2},
new ushort[]{32,8,3,4,2,2},
new ushort[]{33,8,4,4,2,2},
new ushort[]{34,8,5,4,2,2},
new ushort[]{35,8,6,4,2,2},
new ushort[]{36,8,7,4,2,2},
new ushort[]{37,8,8,4,2,2},
new ushort[]{38,8,9,4,2,2},
new ushort[]{39,9,1,4,2,2},
new ushort[]{40,9,2,4,2,2},
new ushort[]{41,9,3,4,2,2},
new ushort[]{42,9,4,4,2,2},
new ushort[]{43,9,5,4,2,2},
new ushort[]{44,9,6,4,2,2},
new ushort[]{45,9,7,4,2,2},
new ushort[]{46,9,8,4,2,2},
new ushort[]{47,9,9,4,2,2},
new ushort[]{48,9,10,4,2,2},
new ushort[]{49,9,11,4,2,2},
new ushort[]{50,9,12,4,2,2},
new ushort[]{51,9,13,4,2,2},
new ushort[]{52,9,14,4,2,2},
new ushort[]{53,9,15,4,2,2},
new ushort[]{54,9,16,4,2,2},
new ushort[]{55,9,17,4,2,2},
new ushort[]{56,9,18,4,2,2},
new ushort[]{57,10,1,5,2,2},
new ushort[]{58,10,2,5,2,2},
new ushort[]{59,10,3,5,2,2},
new ushort[]{60,11,1,5,2,2},
new ushort[]{61,11,2,5,2,2},
new ushort[]{62,11,3,5,2,2},
new ushort[]{63,12,1,5,2,2},
new ushort[]{64,12,2,5,2,2},
new ushort[]{65,12,3,5,2,2},
new ushort[]{66,12,4,5,2,2},
new ushort[]{67,12,5,5,2,2},
new ushort[]{68,12,6,5,2,2},
new ushort[]{69,12,7,5,2,2},
new ushort[]{70,12,8,5,2,2},
new ushort[]{71,12,9,5,2,2},
new ushort[]{72,13,1,5,2,2},
new ushort[]{73,13,2,5,2,2},
new ushort[]{74,13,3,5,2,2},
new ushort[]{75,13,4,5,2,2},
new ushort[]{76,13,5,5,2,2},
new ushort[]{77,13,6,5,2,2},
new ushort[]{78,13,7,5,2,2},
new ushort[]{79,13,8,5,2,2},
new ushort[]{80,13,9,5,2,2},
new ushort[]{81,14,1,5,2,2},
new ushort[]{82,14,2,5,2,2},
new ushort[]{83,14,3,5,2,2},
new ushort[]{84,14,4,5,2,2},
new ushort[]{85,14,5,5,2,2},
new ushort[]{86,14,6,5,2,2},
new ushort[]{87,14,7,5,2,2},
new ushort[]{88,14,8,5,2,2},
new ushort[]{89,14,9,5,2,2},
new ushort[]{90,15,1,5,2,2},
new ushort[]{91,15,2,5,2,2},
new ushort[]{92,15,3,5,2,2},
new ushort[]{93,15,4,5,2,2},
new ushort[]{94,15,5,5,2,2},
new ushort[]{95,15,6,5,2,2},
new ushort[]{96,15,7,5,2,2},
new ushort[]{97,15,8,5,2,2},
new ushort[]{98,15,9,5,2,2},
new ushort[]{99,15,10,5,2,2},
new ushort[]{100,15,11,5,2,2},
new ushort[]{101,15,12,5,2,2},
new ushort[]{102,15,13,5,2,2},
new ushort[]{103,15,14,5,2,2},
new ushort[]{104,15,15,5,2,2},
new ushort[]{105,15,16,5,2,2},
new ushort[]{106,15,17,5,2,2},
new ushort[]{107,15,18,5,2,2},
new ushort[]{108,16,1,6,3,3},
new ushort[]{109,17,1,6,3,3},
new ushort[]{110,17,2,6,3,3},
new ushort[]{111,17,3,6,3,3},
new ushort[]{112,18,1,6,3,3},
new ushort[]{113,18,2,6,3,3},
new ushort[]{114,18,3,6,3,3},
new ushort[]{115,19,1,6,3,3},
new ushort[]{116,20,1,6,3,3},
new ushort[]{117,20,2,6,3,3},
new ushort[]{118,20,3,6,3,3},
new ushort[]{119,21,1,6,3,3},
new ushort[]{120,21,2,6,3,3},
new ushort[]{121,21,3,6,3,3},
new ushort[]{122,22,1,6,3,3},
new ushort[]{123,23,1,6,3,3},
new ushort[]{124,24,1,6,3,3},
new ushort[]{125,25,1,7,3,3},
new ushort[]{126,25,2,7,3,3},
new ushort[]{127,25,3,7,3,3},
new ushort[]{128,26,1,7,3,3},
new ushort[]{129,26,2,7,3,3},
new ushort[]{130,26,3,7,3,3},
new ushort[]{131,26,4,7,3,3},
new ushort[]{132,26,5,7,3,3},
new ushort[]{133,26,6,7,3,3},
new ushort[]{134,27,1,7,3,3},
new ushort[]{135,27,2,7,3,3},
new ushort[]{136,27,3,7,3,3},
new ushort[]{137,28,1,7,3,3},
new ushort[]{138,28,2,7,3,3},
new ushort[]{139,28,3,7,3,3},
new ushort[]{140,28,4,7,3,3},
new ushort[]{141,28,5,7,3,3},
new ushort[]{142,28,6,7,3,3},
new ushort[]{143,29,1,7,3,3},
new ushort[]{144,29,2,7,3,3},
new ushort[]{145,29,3,7,3,3},
new ushort[]{146,29,4,7,3,3},
new ushort[]{147,29,5,7,3,3},
new ushort[]{148,29,6,7,3,3},
new ushort[]{149,30,1,7,3,3},
new ushort[]{150,30,2,7,3,3},
new ushort[]{151,30,3,7,3,3},
new ushort[]{152,30,4,7,3,3},
new ushort[]{153,30,5,7,3,3},
new ushort[]{154,30,6,7,3,3},
new ushort[]{155,31,1,7,3,3},
new ushort[]{156,31,2,7,3,3},
new ushort[]{157,31,3,7,3,3},
new ushort[]{158,31,4,7,3,3},
new ushort[]{159,31,5,7,3,3},
new ushort[]{160,31,6,7,3,3},
new ushort[]{161,32,1,7,3,3},
new ushort[]{162,32,2,7,3,3},
new ushort[]{163,32,3,7,3,3},
new ushort[]{164,33,1,7,3,3},
new ushort[]{165,33,2,7,3,3},
new ushort[]{166,33,3,7,3,3},
new ushort[]{167,33,4,7,3,3},
new ushort[]{168,33,5,7,3,3},
new ushort[]{169,33,6,7,3,3},
new ushort[]{170,34,1,7,3,3},
new ushort[]{171,34,2,7,3,3},
new ushort[]{172,34,3,7,3,3},
new ushort[]{173,35,1,7,3,3},
new ushort[]{174,35,2,7,3,3},
new ushort[]{175,35,3,7,3,3},
new ushort[]{176,36,1,7,3,3},
new ushort[]{177,36,2,7,3,3},
new ushort[]{178,36,3,7,3,3},
new ushort[]{179,36,4,7,3,3},
new ushort[]{180,36,5,7,3,3},
new ushort[]{181,36,6,7,3,3},
new ushort[]{182,37,1,7,3,3},
new ushort[]{183,37,2,7,3,3},
new ushort[]{184,37,3,7,3,3},
new ushort[]{185,38,1,7,3,3},
new ushort[]{186,38,2,7,3,3},
new ushort[]{187,38,3,7,3,3},
new ushort[]{188,38,4,7,3,3},
new ushort[]{189,38,5,7,3,3},
new ushort[]{190,38,6,7,3,3},
new ushort[]{191,39,1,7,3,3},
new ushort[]{192,39,2,7,3,3},
new ushort[]{193,39,3,7,3,3},
new ushort[]{194,39,4,7,3,3},
new ushort[]{195,39,5,7,3,3},
new ushort[]{196,39,6,7,3,3},
new ushort[]{197,40,1,7,3,3},
new ushort[]{198,40,2,7,3,3},
new ushort[]{199,40,3,7,3,3},
new ushort[]{200,40,4,7,3,3},
new ushort[]{201,40,5,7,3,3},
new ushort[]{202,40,6,7,3,3},
new ushort[]{203,41,1,7,3,3},
new ushort[]{204,41,2,7,3,3},
new ushort[]{205,41,3,7,3,3},
new ushort[]{206,41,4,7,3,3},
new ushort[]{207,41,5,7,3,3},
new ushort[]{208,41,6,7,3,3},
new ushort[]{209,42,1,7,3,3},
new ushort[]{210,42,2,7,3,3},
new ushort[]{211,42,3,7,3,3},
new ushort[]{212,43,1,7,3,3},
new ushort[]{213,43,2,7,3,3},
new ushort[]{214,43,3,7,3,3},
new ushort[]{215,44,1,7,3,3},
new ushort[]{216,44,2,7,3,3},
new ushort[]{217,44,3,7,3,3},
new ushort[]{218,45,1,7,3,3},
new ushort[]{219,45,2,7,3,3},
new ushort[]{220,45,3,7,3,3},
new ushort[]{221,46,1,7,3,3},
new ushort[]{222,46,2,7,3,3},
new ushort[]{223,46,3,7,3,3},
new ushort[]{224,46,4,7,3,3},
new ushort[]{225,46,5,7,3,3},
new ushort[]{226,46,6,7,3,3},
new ushort[]{227,47,1,8,3,3},
new ushort[]{228,48,1,8,3,3},
new ushort[]{229,48,2,8,3,3},
new ushort[]{230,49,1,8,3,3},
new ushort[]{231,49,2,8,3,3},
new ushort[]{232,49,3,8,3,3},
new ushort[]{233,50,1,8,3,3},
new ushort[]{234,50,2,8,3,3},
new ushort[]{235,50,3,8,3,3},
new ushort[]{236,50,4,8,3,3},
new ushort[]{237,50,5,8,3,3},
new ushort[]{238,50,6,8,3,3},
new ushort[]{239,51,1,8,3,3},
new ushort[]{240,51,2,8,3,3},
new ushort[]{241,51,3,8,3,3},
new ushort[]{242,51,4,8,3,3},
new ushort[]{243,51,5,8,3,3},
new ushort[]{244,51,6,8,3,3},
new ushort[]{245,52,1,8,3,3},
new ushort[]{246,52,2,8,3,3},
new ushort[]{247,52,3,8,3,3},
new ushort[]{248,52,4,8,3,3},
new ushort[]{249,52,5,8,3,3},
new ushort[]{250,52,6,8,3,3},
new ushort[]{251,53,1,8,3,3},
new ushort[]{252,53,2,8,3,3},
new ushort[]{253,53,3,8,3,3},
new ushort[]{254,53,4,8,3,3},
new ushort[]{255,53,5,8,3,3},
new ushort[]{256,53,6,8,3,3},
new ushort[]{257,54,1,8,3,3},
new ushort[]{258,54,2,8,3,3},
new ushort[]{259,54,3,8,3,3},
new ushort[]{260,54,4,8,3,3},
new ushort[]{261,54,5,8,3,3},
new ushort[]{262,54,6,8,3,3},
new ushort[]{263,55,1,8,3,3},
new ushort[]{264,55,2,8,3,3},
new ushort[]{265,55,3,8,3,3},
new ushort[]{266,56,1,8,3,3},
new ushort[]{267,56,2,8,3,3},
new ushort[]{268,56,3,8,3,3},
new ushort[]{269,57,1,8,3,3},
new ushort[]{270,57,2,8,3,3},
new ushort[]{271,57,3,8,3,3},
new ushort[]{272,57,4,8,3,3},
new ushort[]{273,57,5,8,3,3},
new ushort[]{274,57,6,8,3,3},
new ushort[]{275,58,1,8,3,3},
new ushort[]{276,58,2,8,3,3},
new ushort[]{277,58,3,8,3,3},
new ushort[]{278,59,1,8,3,3},
new ushort[]{279,59,2,8,3,3},
new ushort[]{280,59,3,8,3,3},
new ushort[]{281,59,4,8,3,3},
new ushort[]{282,59,5,8,3,3},
new ushort[]{283,59,6,8,3,3},
new ushort[]{284,60,1,8,3,3},
new ushort[]{285,60,2,8,3,3},
new ushort[]{286,60,3,8,3,3},
new ushort[]{287,60,4,8,3,3},
new ushort[]{288,60,5,8,3,3},
new ushort[]{289,60,6,8,3,3},
new ushort[]{290,61,1,8,3,3},
new ushort[]{291,61,2,8,3,3},
new ushort[]{292,62,1,8,3,3},
new ushort[]{293,62,2,8,3,3},
new ushort[]{294,62,3,8,3,3},
new ushort[]{295,62,4,8,3,3},
new ushort[]{296,62,5,8,3,3},
new ushort[]{297,62,6,8,3,3},
new ushort[]{298,63,1,8,3,3},
new ushort[]{299,63,2,8,3,3},
new ushort[]{300,63,3,8,3,3},
new ushort[]{301,63,4,8,3,3},
new ushort[]{302,63,5,8,3,3},
new ushort[]{303,63,6,8,3,3},
new ushort[]{304,64,1,8,3,3},
new ushort[]{305,64,2,8,3,3},
new ushort[]{306,64,3,8,3,3},
new ushort[]{307,64,4,8,3,3},
new ushort[]{308,64,5,8,3,3},
new ushort[]{309,64,6,8,3,3},
new ushort[]{310,65,1,8,3,3},
new ushort[]{311,65,2,8,3,3},
new ushort[]{312,65,3,8,3,3},
new ushort[]{313,66,1,8,3,3},
new ushort[]{314,66,2,8,3,3},
new ushort[]{315,66,3,8,3,3},
new ushort[]{316,67,1,8,3,3},
new ushort[]{317,67,2,8,3,3},
new ushort[]{318,67,3,8,3,3},
new ushort[]{319,67,4,8,3,3},
new ushort[]{320,67,5,8,3,3},
new ushort[]{321,67,6,8,3,3},
new ushort[]{322,68,1,8,3,3},
new ushort[]{323,68,2,8,3,3},
new ushort[]{324,68,3,8,3,3},
new ushort[]{325,68,4,8,3,3},
new ushort[]{326,68,5,8,3,3},
new ushort[]{327,68,6,8,3,3},
new ushort[]{328,68,7,8,3,3},
new ushort[]{329,68,8,8,3,3},
new ushort[]{330,68,9,8,3,3},
new ushort[]{331,68,10,8,3,3},
new ushort[]{332,68,11,8,3,3},
new ushort[]{333,68,12,8,3,3},
new ushort[]{334,69,1,8,3,3},
new ushort[]{335,70,1,8,3,3},
new ushort[]{336,70,2,8,3,3},
new ushort[]{337,71,1,8,3,3},
new ushort[]{338,72,1,8,3,3},
new ushort[]{339,72,2,8,3,3},
new ushort[]{340,72,3,8,3,3},
new ushort[]{341,73,1,8,3,3},
new ushort[]{342,73,2,8,3,3},
new ushort[]{343,74,1,8,3,3},
new ushort[]{344,74,2,8,3,3},
new ushort[]{345,74,3,8,3,3},
new ushort[]{346,74,4,8,3,3},
new ushort[]{347,74,5,8,3,3},
new ushort[]{348,74,6,8,3,3},
new ushort[]{349,75,1,9,4,4},
new ushort[]{350,76,1,9,4,4},
new ushort[]{351,77,1,9,4,4},
new ushort[]{352,78,1,9,4,4},
new ushort[]{353,79,1,9,4,4},
new ushort[]{354,80,1,9,4,4},
new ushort[]{355,81,1,10,4,4},
new ushort[]{356,82,1,10,4,4},
new ushort[]{357,83,1,11,4,4},
new ushort[]{358,84,1,11,4,4},
new ushort[]{359,85,1,11,4,4},
new ushort[]{360,85,2,11,4,4},
new ushort[]{361,86,1,11,4,4},
new ushort[]{362,86,2,11,4,4},
new ushort[]{363,87,1,11,4,4},
new ushort[]{364,88,1,11,4,4},
new ushort[]{365,88,2,11,4,4},
new ushort[]{366,89,1,12,5,4},
new ushort[]{367,90,1,12,5,4},
new ushort[]{368,91,1,12,5,4},
new ushort[]{369,92,1,12,5,4},
new ushort[]{370,93,1,12,5,4},
new ushort[]{371,94,1,12,5,4},
new ushort[]{372,95,1,12,5,4},
new ushort[]{373,96,1,12,5,4},
new ushort[]{374,97,1,12,5,4},
new ushort[]{375,98,1,12,5,4},
new ushort[]{376,99,1,13,5,4},
new ushort[]{377,100,1,13,5,4},
new ushort[]{378,101,1,13,5,4},
new ushort[]{379,102,1,13,5,4},
new ushort[]{380,103,1,13,5,4},
new ushort[]{381,104,1,13,5,4},
new ushort[]{382,105,1,13,5,4},
new ushort[]{383,106,1,13,5,4},
new ushort[]{384,107,1,13,5,4},
new ushort[]{385,108,1,13,5,4},
new ushort[]{386,109,1,13,5,4},
new ushort[]{387,110,1,13,5,4},
new ushort[]{388,111,1,14,5,4},
new ushort[]{389,112,1,14,5,4},
new ushort[]{390,113,1,14,5,4},
new ushort[]{391,114,1,14,5,4},
new ushort[]{392,115,1,14,5,4},
new ushort[]{393,116,1,14,5,4},
new ushort[]{394,117,1,14,5,4},
new ushort[]{395,118,1,14,5,4},
new ushort[]{396,119,1,14,5,4},
new ushort[]{397,120,1,14,5,4},
new ushort[]{398,121,1,14,5,4},
new ushort[]{399,122,1,14,5,4},
new ushort[]{400,123,1,15,5,4},
new ushort[]{401,124,1,15,5,4},
new ushort[]{402,125,1,15,5,4},
new ushort[]{403,125,2,15,5,4},
new ushort[]{404,126,1,15,5,4},
new ushort[]{405,126,2,15,5,4},
new ushort[]{406,127,1,15,5,4},
new ushort[]{407,128,1,15,5,4},
new ushort[]{408,129,1,15,5,4},
new ushort[]{409,129,2,15,5,4},
new ushort[]{410,130,1,15,5,4},
new ushort[]{411,130,2,15,5,4},
new ushort[]{412,131,1,15,5,4},
new ushort[]{413,132,1,15,5,4},
new ushort[]{414,133,1,15,5,4},
new ushort[]{415,133,2,15,5,4},
new ushort[]{416,134,1,15,5,4},
new ushort[]{417,134,2,15,5,4},
new ushort[]{418,135,1,15,5,4},
new ushort[]{419,136,1,15,5,4},
new ushort[]{420,137,1,15,5,4},
new ushort[]{421,137,2,15,5,4},
new ushort[]{422,138,1,15,5,4},
new ushort[]{423,138,2,15,5,4},
new ushort[]{424,139,1,15,5,4},
new ushort[]{425,140,1,15,5,4},
new ushort[]{426,141,1,15,5,4},
new ushort[]{427,141,2,15,5,4},
new ushort[]{428,142,1,15,5,4},
new ushort[]{429,142,2,15,5,4},
new ushort[]{430,143,1,16,6,5},
new ushort[]{431,144,1,16,6,5},
new ushort[]{432,145,1,16,6,5},
new ushort[]{433,146,1,16,6,5},
new ushort[]{434,146,2,17,6,5},
new ushort[]{435,147,1,17,6,5},
new ushort[]{436,148,1,17,6,5},
new ushort[]{437,148,2,17,6,5},
new ushort[]{438,149,1,18,7,5},
new ushort[]{439,150,1,18,7,5},
new ushort[]{440,151,1,18,7,5},
new ushort[]{441,152,1,18,7,5},
new ushort[]{442,153,1,18,7,5},
new ushort[]{443,154,1,18,7,5},
new ushort[]{444,155,1,18,7,5},
new ushort[]{445,155,2,18,7,5},
new ushort[]{446,156,1,19,7,5},
new ushort[]{447,157,1,19,7,5},
new ushort[]{448,158,1,19,7,5},
new ushort[]{449,159,1,19,7,5},
new ushort[]{450,160,1,19,7,5},
new ushort[]{451,160,2,19,7,5},
new ushort[]{452,161,1,19,7,5},
new ushort[]{453,161,2,19,7,5},
new ushort[]{454,162,1,20,7,5},
new ushort[]{455,163,1,20,7,5},
new ushort[]{456,164,1,20,7,5},
new ushort[]{457,165,1,20,7,5},
new ushort[]{458,166,1,20,7,5},
new ushort[]{459,166,2,20,7,5},
new ushort[]{460,167,1,20,7,5},
new ushort[]{461,167,2,20,7,5},
new ushort[]{462,168,1,21,8,6},
new ushort[]{463,169,1,21,8,6},
new ushort[]{464,170,1,21,8,6},
new ushort[]{465,171,1,21,8,6},
new ushort[]{466,172,1,21,8,6},
new ushort[]{467,173,1,21,8,6},
new ushort[]{468,174,1,22,8,6},
new ushort[]{469,175,1,23,8,6},
new ushort[]{470,176,1,23,8,6},
new ushort[]{471,177,1,24,9,6},
new ushort[]{472,178,1,24,9,6},
new ushort[]{473,179,1,24,9,6},
new ushort[]{474,180,1,24,9,6},
new ushort[]{475,181,1,24,9,6},
new ushort[]{476,182,1,24,9,6},
new ushort[]{477,183,1,25,9,6},
new ushort[]{478,184,1,25,9,6},
new ushort[]{479,185,1,25,9,6},
new ushort[]{480,186,1,25,9,6},
new ushort[]{481,187,1,26,9,6},
new ushort[]{482,188,1,26,9,6},
new ushort[]{483,189,1,26,9,6},
new ushort[]{484,190,1,26,9,6},
new ushort[]{485,191,1,27,9,6},
new ushort[]{486,192,1,27,9,6},
new ushort[]{487,193,1,27,9,6},
new ushort[]{488,194,1,27,9,6},
new ushort[]{489,195,1,28,10,7},
new ushort[]{490,196,1,28,10,7},
new ushort[]{491,197,1,28,10,7},
new ushort[]{492,198,1,28,10,7},
new ushort[]{493,199,1,28,10,7},
new ushort[]{494,200,1,29,10,7},
new ushort[]{495,201,1,29,10,7},
new ushort[]{496,201,2,29,10,7},
new ushort[]{497,202,1,29,10,7},
new ushort[]{498,203,1,29,10,7},
new ushort[]{499,203,2,29,10,7},
new ushort[]{500,204,1,29,10,7},
new ushort[]{501,205,1,29,10,7},
new ushort[]{502,206,1,29,10,7},
new ushort[]{503,207,1,30,11,7},
new ushort[]{504,208,1,30,11,7},
new ushort[]{505,209,1,30,11,7},
new ushort[]{506,210,1,30,11,7},
new ushort[]{507,211,1,30,11,7},
new ushort[]{508,212,1,30,11,7},
new ushort[]{509,213,1,30,11,7},
new ushort[]{510,214,1,30,11,7},
new ushort[]{511,215,1,31,11,7},
new ushort[]{512,216,1,31,11,7},
new ushort[]{513,217,1,31,11,7},
new ushort[]{514,218,1,31,11,7},
new ushort[]{515,219,1,31,11,7},
new ushort[]{516,220,1,31,11,7},
new ushort[]{517,221,1,32,11,7},
new ushort[]{518,222,1,32,11,7},
new ushort[]{519,222,2,32,11,7},
new ushort[]{520,223,1,32,11,7},
new ushort[]{521,224,1,32,11,7},
new ushort[]{522,224,2,32,11,7},
new ushort[]{523,225,1,32,11,7},
new ushort[]{524,226,1,32,11,7},
new ushort[]{525,227,1,32,11,7},
new ushort[]{526,227,2,32,11,7},
new ushort[]{527,228,1,32,11,7},
new ushort[]{528,228,2,32,11,7},
new ushort[]{529,229,1,32,11,7},
new ushort[]{530,230,1,32,11,7},
new ushort[]{531,2,2,2,1,1},
new ushort[]{532,2,3,2,1,1},
new ushort[]{533,2,4,2,1,1},
new ushort[]{534,2,5,2,1,1},
new ushort[]{535,2,6,2,1,1}
,new ushort[]{536,1,2,1,1,1}
,new ushort[]{537,1,3,1,1,1}
,new ushort[]{538,1,4,1,1,1}
,new ushort[]{539,1,5,1,1,1}
#endregion
        };

    public enum CrystalSystem { Unknown = 0, Triclinic = 1, Monoclinic = 2, Orthorhombic = 3, Tetragonal = 4, Trigonal = 5, Hexagonal = 6, Cubic = 7 };

    public static readonly int TotalSpaceGroupNumber;
    public static readonly string[] SpaceGroupListWithoutSpace;
    #endregion

    #region static コンストラクタ
    /// <summary>
    /// 静的コンストラクタ
    /// </summary>
    static SymmetryStatic()
    {
        TotalSpaceGroupNumber = BelongingNumberOfSymmetry.Sum(b1 => b1.Sum(b2 => b2.Length));

        #region PositionGeneratorListの仲間たちを初期化
        var PositionGeneratorListP = PositionGeneratorList.AsParallel();
        PositionGeneratorListA = PositionGeneratorListP.Select(f => new Func<double, double, double, (double X, double Y, double Z)>((x, y, z) =>
        {
            var (X, Y, Z) = f(x, y, z);
            return (X, Y + 0.5, Z + 0.5);
        })).ToArray();
        PositionGeneratorListB = PositionGeneratorListP.Select(f => new Func<double, double, double, (double X, double Y, double Z)>((x, y, z) =>
        {
            var (X, Y, Z) = f(x, y, z);
            return (X + 0.5, Y, Z + 0.5);
        })).ToArray();
        PositionGeneratorListC = PositionGeneratorListP.Select(f => new Func<double, double, double, (double X, double Y, double Z)>((x, y, z) =>
        {
            var (X, Y, Z) = f(x, y, z);
            return (X + 0.5, Y + 0.5, Z);
        })).ToArray();
        PositionGeneratorListI = PositionGeneratorListP.Select(f => new Func<double, double, double, (double X, double Y, double Z)>((x, y, z) =>
        {
            var (X, Y, Z) = f(x, y, z);
            return (X + 0.5, Y + 0.5, Z + 0.5);
        })).ToArray();
        PositionGeneratorListR1 = PositionGeneratorListP.Select(f => new Func<double, double, double, (double X, double Y, double Z)>((x, y, z) =>
        {
            var (X, Y, Z) = f(x, y, z);
            return (X + 1.0 / 3.0, Y + 2.0 / 3.0, Z + 2.0 / 3.0);
        })).ToArray();
        PositionGeneratorListR2 = PositionGeneratorListP.Select(f => new Func<double, double, double, (double X, double Y, double Z)>((x, y, z) =>
        {
            var (X, Y, Z) = f(x, y, z);
            return (X + 2.0 / 3.0, Y + 1.0 / 3.0, Z + 1.0 / 3.0);
        })).ToArray();
        #endregion

        WyckoffPositions = new WyckoffPosition[TotalSpaceGroupNumber][];

        #region WyckoffPositionsを初期化

        for (int i = 0; i < TotalSpaceGroupNumber; i++)
        {
            var wyckoff = new List<WyckoffPosition>(PositionsDictionary[i].Length);
            var lattice = StrArray[i][6];
            if (lattice == "R")
                lattice += StrArray[i][0];//extra表記にHがあればRHにする

            for (int j = 0; j < PositionsDictionary[i].Length; j++)
            {
                //PositionGeneratorとPositionStringをセット
                var PosGen = new List<Func<double, double, double, (double X, double Y, double Z)>>();
                var posStr = new List<string>();
                foreach (var p in PositionsDictionary[i][j])
                {
                    posStr.Add(PositionStringList[p]);
                    PosGen.AddRange(lattice switch
                    {
                        "A" => new[] { PositionGeneratorList[p], PositionGeneratorListA[p] },
                        "B" => new[] { PositionGeneratorList[p], PositionGeneratorListB[p] },
                        "C" => new[] { PositionGeneratorList[p], PositionGeneratorListC[p] },
                        "I" => new[] { PositionGeneratorList[p], PositionGeneratorListI[p] },
                        "F" => new[] { PositionGeneratorList[p], PositionGeneratorListA[p], PositionGeneratorListB[p], PositionGeneratorListC[p] },
                        "RH" => new[] { PositionGeneratorList[p], PositionGeneratorListR1[p], PositionGeneratorListR2[p] },
                        _ => new[] { PositionGeneratorList[p] }
                    });
                }

                //Symmetry Operationをセット
                var operations = new List<SO>();
                if (j == 0)
                {
                    foreach (var p in OperationDictionary[i])
                    {
                        var op = OperationList[p];
                        operations.AddRange(lattice switch
                        {
                            "A" => new[] { new SO(op, i, 0, 0, 0), new SO(op, i, 0, 0.5, 0.5) },
                            "B" => new[] { new SO(op, i, 0, 0, 0), new SO(op, i, 0.5, 0, 0.5) },
                            "C" => new[] { new SO(op, i, 0, 0, 0), new SO(op, i, 0.5, 0.5, 0) },
                            "I" => new[] { new SO(op, i, 0, 0, 0), new SO(op, i, 0.5, 0.5, 0.5) },
                            "F" => new[] { new SO(op, i, 0, 0, 0), new SO(op, i, 0, 0.5, 0.5), new SO(op, i, 0.5, 0, 0.5), new SO(op, i, 0.5, 0.5, 0) },
                            "RH" => new[] { new SO(op, i, 0, 0, 0), new SO(op, i, 1d / 3d, 2d / 3d, 2d / 3d), new SO(op, i, 2d / 3d, 1d / 3d, 1d / 3d) },
                            _ => new[] { op }
                        });
                    }
                }

                //Wyckoff Letterをセット
                char let = (char)(PositionsDictionary[i].Length - j + 96);
                if (let > 'z')
                    let = (char)(let - 58);

                wyckoff.Add(new WyckoffPosition(i, lattice, let.ToString(), j, SiteSymmetryList[SiteSymmetryDictionary[i][j]], posStr.ToArray(), PosGen.ToArray(), j == 0 ? operations.ToArray() : null));
            }
            WyckoffPositions[i] = wyckoff.ToArray();
        }
        #endregion

        SpaceGroupListWithoutSpace = StrArray.Select(s => s[3].Replace(" ", "")).ToArray();

        Symmetries = new Symmetry[TotalSpaceGroupNumber];
        for (int i = 0; i < Symmetries.Length; i++)
            Symmetries[i] = new Symmetry(i);
    }
    #endregion

    #region static メソッド
    /// <summary>
    /// seriesNumberを与えられたとき、その空間群が属する、結晶系・点群・空間群のコンボボックス上の順番をかえす
    /// </summary>
    /// <param name="seriesNumber"></param>
    /// <returns></returns>
    public static (int CrystalSystem, int PointGroup, int SpaceGroup) GetSytemAndGroupFromSeriesNumber(int seriesNumber)
    {
        for (int i = 0; i < BelongingNumberOfSymmetry.Length; i++)
        {
            for (int j = 0; j < BelongingNumberOfSymmetry[i].Length; j++)
            {
                for (int k = 0; k < BelongingNumberOfSymmetry[i][j].Length; k++)
                {
                    if (seriesNumber == BelongingNumberOfSymmetry[i][j][k])
                    {
                        return (i, j, k);
                    }
                }
            }
        }
        return (0, 0, 0);
    }

    /// <summary>
    /// 空間群のInternationalTable番号とそのサブシリーズ番号をもとに通し番号を返す
    /// </summary>
    /// <param name="number">InternationalTable番号</param>
    /// <param name="sub">サブシリーズ番号</param>
    /// <returns>通し番号</returns>
    public static int GetSeriesNumber(int number, int sub)
    {
        for (int i = 0; i < NumArray.Length; i++)
            if (NumArray[i][1] == number && NumArray[i][2] == sub)
                return i;
        return -1;
    }

    /// <summary>
    /// ラウエ群に従って基底の面指数を返す
    /// </summary>
    /// <param name="index"></param>
    /// <param name="sym"></param>
    /// <returns></returns>

    public static (int H, int K, int L) GetRootPlaneIndex((int H, int K, int L) index, Symmetry sym)
    {
        #region
        int h = index.H, k = index.K, l = index.L;
        int m, i;
        switch (sym.LaueGroupNumber)
        {
            case 0://	unknown
                break;

            case 1://	-1
                if (h < 0 || (h == 0 && k < 0) || (h == 0 && k == 0 && l < 0))
                {
                    h = -h; k = -k; l = -l;
                }
                break;

            case 2://	2/m
                if (sym.MainAxis == "a")
                {
                    if (h < 0)
                    {
                        h = -h;
                    }
                    if (k < 0 || (k == 0 && l < 0))
                    {
                        k = -k; l = -l;
                    }
                }
                else if (sym.MainAxis == "b")
                {
                    if (k < 0)
                    {
                        k = -k;
                    }
                    if (h < 0 || (h == 0 && l < 0))
                    {
                        h = -h; l = -l;
                    }
                }
                else if (sym.MainAxis == "c")
                {
                    if (l < 0)
                    {
                        l = -l;
                    }
                    if (h < 0 || (h == 0 && k < 0))
                    {
                        h = -h; k = -k;
                    }
                }

                break;

            case 3://	mmm
                h = Math.Abs(h);
                k = Math.Abs(k);
                l = Math.Abs(l);
                break;

            case 4://	4/m
                l = Math.Abs(l);
                while (!(h >= 0 && k >= 0))
                {
                    m = h; h = -k; k = m;
                }
                if (h == 0)
                {
                    m = h; h = k; k = m;
                }

                break;

            case 5:// 4/mmm
                h = Math.Abs(h);
                k = Math.Abs(k);
                l = Math.Abs(l);
                while (!(h <= k))
                {
                    m = h; h = k; k = m;
                }
                break;

            case 6:// -3
                i = -h - k;
                if (l != 0)
                {//lが0ではないとき
                    if (l < 0)
                    {//lが0以下のとき
                        h = -h; k = -k; i = -i; l = -l;
                    }

                    if (h * k * i == 0)
                    {//h,k,iの中で一つでも0を含んでいるとき
                        while (h != 0)
                        {
                            m = h; h = k; k = i; i = m;
                        }
                        break;
                    }
                    else
                    {//h,k,iがすべて0以外の整数のとき
                        while (!(Math.Abs(h) <= Math.Abs(i) && Math.Abs(k) < Math.Abs(i)))
                        {//iの絶対値を最大にする
                            m = h; h = k; k = i; i = m;
                        }
                        break;
                    }
                }
                else
                {//lが0のとき
                    if (h * k * i == 0)
                    {//h,k,iの中で一つでも0を含んでいるとき
                        while (h != 0)
                        {
                            m = h; h = k; k = i; i = m;
                        }
                        if (k < 0)
                        {
                            k = -k;
                        }

                        break;
                    }
                    else
                    {//h,k,iがすべて0以外の整数のとき
                        if (h * k * i < 0)
                        {
                            h = -h; k = -k; i = -i;
                        }
                        while (!(Math.Abs(h) <= i && Math.Abs(k) < Math.Abs(i)))
                        {//iの絶対値を最大にする
                            m = h; h = k; k = i; i = m;
                        }
                        break;
                    }
                }

            case 7://	-3m
                i = -h - k;
                if (l != 0)
                {//lが0ではないとき
                    if (l < 0)
                    {//lが0以下のとき
                        h = -h; k = -k; i = -i; l = -l;
                    }

                    if (h * k * i == 0)
                    {//h,k,iの中で一つでも0を含んでいるとき
                        while (h != 0)
                        {
                            m = h; h = k; k = i; i = m;
                        }
                        break;
                    }
                    else
                    {//h,k,iがすべて0以外の整数のとき
                        if (h * k * i < 0)
                        {
                            h = -h; m = k; k = -i; i = -m;
                        }
                        while (!(Math.Abs(h) <= Math.Abs(i) && Math.Abs(k) < Math.Abs(i)))
                        {//iの絶対値を最大にする
                            m = h; h = k; k = i; i = m;
                        }
                        break;
                    }
                }
                else
                {//lが0のとき
                    if (h * k * i == 0)
                    {//h,k,iの中で一つでも0を含んでいるとき
                        while (h != 0)
                        {
                            m = h; h = k; k = i; i = m;
                        }
                        if (k < 0)
                        {
                            k = -k;
                        }

                        break;
                    }
                    else
                    {//h,k,iがすべて0以外の整数のとき
                        if (h * k * i < 0)
                        {
                            h = -h; k = -k; i = -i;
                        }
                        while (!(Math.Abs(h) <= i && Math.Abs(k) < Math.Abs(i)))
                        {//iの絶対値を最大にする
                            m = h; h = k; k = i; i = m;
                        }
                        if (h > k)
                        {
                            m = h; h = k; k = m;
                        }
                        break;
                    }
                }

            case 8:// 6/m
                i = -h - k;
                if (l < 0)
                {//lが0以下のとき
                    h = -h; k = -k; i = -i; l = -l;
                }

                if (h * k * i == 0)
                {//h,k,iの中で一つでも0を含んでいるとき
                    while (h != 0)
                    {
                        m = h; h = k; k = i; i = m;
                    }
                    if (k < 0)
                    {
                        k = -k;
                    }

                    break;
                }
                else
                {//h,k,iがすべて0以外の整数のとき
                    if (h * k * i < 0)
                    {
                        h = -h; k = -k; i = -i;
                    }
                    while (!(Math.Abs(h) <= Math.Abs(i) && Math.Abs(k) < Math.Abs(i)))
                    {//iの絶対値を最大にする
                        m = h; h = k; k = i; i = m;
                    }
                    break;
                }

            case 9://	6/mmm
                i = -h - k;
                if (l < 0)
                {//lが0以下のとき
                    h = -h; k = -k; i = -i; l = -l;
                }

                if (h * k * i == 0)
                {//h,k,iの中で一つでも0を含んでいるとき
                    while (h != 0)
                    {
                        m = h; h = k; k = i; i = m;
                    }
                    if (k < 0)
                    {
                        k = -k;
                    }

                    break;
                }
                else
                {//h,k,iがすべて0以外の整数のとき
                    if (h * k * i < 0)
                    {
                        h = -h; k = -k; i = -i;
                    }
                    while (!(Math.Abs(h) <= Math.Abs(i) && Math.Abs(k) < Math.Abs(i)))
                    {//iの絶対値を最大にする
                        m = h; h = k; k = i; i = m;
                    }
                    if (h > k)
                    {
                        m = h; h = k; k = m;
                    }
                    break;
                }

            case 10:// m3 lに最大の指数がくるようにする
                h = Math.Abs(h);
                k = Math.Abs(k);
                l = Math.Abs(l);
                while (!(l >= h && l >= k))
                {
                    m = h; h = k; k = l; l = m;
                }
                if (h == l)
                {//(2,1,2)を(1,2,2)にする
                    m = h; h = k; k = m;
                }
                break;

            case 11:// m3m 例(-4, 3,-5)を(3,4,5)に
                h = Math.Abs(h);
                k = Math.Abs(k);
                l = Math.Abs(l);
                if (h > k)
                {
                    m = h; h = k; k = m;
                }
                if (k > l)
                {
                    m = k; k = l; l = m;
                }
                if (h > k)
                {
                    m = h; h = k; k = m;
                }
                break;
        }
        return (h, k, l);
        #endregion
    }

    //[uvw]に等価な軸を返す
    /// <summary>
    ///  ラウエ群に従って基底の軸指数を返す
    /// </summary>
    /// <param name="index"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static (int U, int V, int W) GetRootAxisIndex((int U, int V, int W) index, Symmetry sym)
    {
        #region
        int u = index.U, v = index.V, w = index.W;
        int m, n, o;

        switch (sym.LaueGroupNumber)
        {
            case 0://	unknown
                break;

            case 1://	-1
                if (u < 0 || (u == 0 && v < 0) || (u == 0 && v == 0 && w < 0))
                {
                    u = -u; v = -v; w = -w;
                }
                break;

            case 2://	2/m

                if (sym.MainAxis == "a")
                {
                    if (u < 0)
                    {
                        u = -u;
                    }
                    if (v < 0 || (v == 0 && w < 0))
                    {
                        v = -v; w = -w;
                    }
                }
                else if (sym.MainAxis == "b")
                {
                    if (v < 0)
                    {
                        v = -v;
                    }
                    if (u < 0 || (u == 0 && w < 0))
                    {
                        u = -u; w = -w;
                    }
                }
                else if (sym.MainAxis == "c")
                {
                    if (w < 0)
                    {
                        w = -w;
                    }
                    if (u < 0 || (u == 0 && v < 0))
                    {
                        u = -u; v = -v;
                    }
                }

                break;

            case 3://	mmm
                u = Math.Abs(u);
                v = Math.Abs(v);
                w = Math.Abs(w);
                break;

            case 4://	4/m
                w = Math.Abs(w);
                while (!(u >= 0 && v >= 0))
                {
                    m = u; u = -v; v = m;
                }
                if (u == 0)
                {
                    m = u; u = v; v = m;
                }

                break;

            case 5:// 4/mmm
                u = Math.Abs(u);
                v = Math.Abs(v);
                w = Math.Abs(w);
                while (!(u <= v))
                {
                    m = u; u = v; v = m;
                }
                break;

            case 6:// -3
                if (w != 0)
                {//wが0ではないとき
                    if (w < 0)
                    {//wが0以下のとき
                        u = -u; v = -v; w = -w;
                    }
                    if (u == 0 && v == 0)
                    {
                        break;
                    }

                    while (!(u >= 0 && v >= 0))
                    {
                        m = u; n = v; u = -n; v = m - n;
                    }

                    if (u == 0)
                    {
                        m = u; u = v; v = m;
                    }
                    break;
                }
                else
                {//wが0のとき
                    if (u == 0 && v == 0)
                    {
                        break;
                    }
                    else if (u == 0 || v == 0 || u == v)
                    { //(200),(020),(-2-20)の様な場合
                        while (u != 0)
                        {
                            m = u; n = v; u = -n; v = m - n;
                        }
                        if (v <= 0)
                        {
                            v = -v;
                        }

                        break;
                    }
                    else
                    {   //(-210),(-1-30),(320),(2-10),(130),(-3-20)の様な場合
                        while (!(u >= 0 && v >= 0))
                        {
                            m = u; n = v; u = -n; v = m - n;
                        }
                        if (u > v)
                        {
                            u = -u; v = -v; w = -w;
                            while (!(u >= 0 && v >= 0))
                            {
                                m = u; n = v; u = -n; v = m - n;
                            }
                        }
                        break;
                    }
                }

            case 7://	-3m
                if (w != 0)
                {//wが0ではないとき
                    if (w < 0)
                    {//wが0以下のとき
                        u = -u; v = -v; w = -w;//wを1以上にする
                    }

                    if (u == 0 && v == 0)//(00w)のときは
                    {
                        break;          //そのまま終了
                    }
                    else if (u == 0 || v == 0 || u == v)
                    { //(20w),(02w),(-2-2w),(22w),(-20w),(0-2w)の様な場合
                        while (u != 0)
                        {
                            m = u; n = v; u = -n; v = m - n;
                        }//ループ終了時には(02w)か(0-2w)になっている
                        if (v <= 0)
                        {
                            v = -v;
                        }

                        break;
                    }
                    else
                    {
                        while (!(u >= 0 && v >= 0))
                        {//まずuとvが正になるように
                            m = u; n = v; u = -n; v = m - n;
                        }
                        o = u + v;//このときのu+vをoに代入
                        v = u - v;//ミラー対称要素を適用
                        while (!(u >= 0 && v >= 0))
                        {//もう一回uとvが正になるように
                            m = u; n = v; u = -n; v = m - n;
                        }
                        if (o <= u + v)//ミラー対称を適用後uとvの和が小さかったら
                        {
                            break;
                        }
                        else
                        {
                            v = u - v;
                            while (!(u >= 0 && v >= 0))
                            {//まずuとvが正になるように
                                m = u; n = v; u = -n; v = m - n;
                            }
                            break;
                        }
                    }
                }
                else
                {//wが0のとき
                    if (u == 0 && v == 0)
                    {
                        break;
                    }
                    else if (u == 0 || v == 0 || u == v)
                    { //(200),(020),(-2-20)の様な場合
                        while (u != 0)
                        {
                            m = u; n = v; u = -n; v = m - n;
                        }
                        if (v <= 0)
                        {
                            v = -v;
                        }

                        break;
                    }
                    else
                    {   //(-210),(-1-30),(320),(2-10),(130),(-3-20)の様な場合
                        while (!(u >= 0 && v >= 0))
                        {//まずuとvが正になるように
                            m = u; n = v; u = -n; v = m - n;
                        }
                        o = u + v;//このときのu+vをoに代入
                        v = u - v;//ミラー対称要素を適用
                        while (!(u >= 0 && v >= 0))
                        {//もう一回uとvが正になるように
                            m = u; n = v; u = -n; v = m - n;
                        }
                        if (o <= u + v)
                        {//ミラー対称を適用後uとvの和が小さかったら
                            if (u > v)
                            {
                                m = u; u = v; v = m;
                            }
                            break;
                        }
                        else
                        {
                            v = u - v;
                            while (!(u >= 0 && v >= 0))
                            {//まずuとvが正になるように
                                m = u; n = v; u = -n; v = m - n;
                            }
                            if (u > v)
                            {
                                m = u; u = v; v = m;
                            }
                            break;
                        }
                    }
                }

            case 8:// 6/m
                if (w < 0)
                {//wが0以下のとき
                    u = -u; v = -v; w = -w;
                }
                if (u == 0 && v == 0)
                {
                    break;
                }
                else if (u == 0 || v == 0 || u == v)
                {
                    while (u != 0)
                    {
                        m = u; n = v; u = -n; v = m - n;
                    }
                    if (v <= 0)
                    {
                        v = -v;
                    }

                    break;
                }
                else
                {
                    while (!(u >= 0 && v >= 0))
                    {//まずuとvが正になるように
                        m = u; n = v; u = -n; v = m - n;
                    }
                    if (u > v)
                    {
                        u = -u; v = -v;
                        while (!(u >= 0 && v >= 0))
                        {//まずuとvが正になるように
                            m = u; n = v; u = -n; v = m - n;
                        }
                    }
                    break;
                }

            case 9://	6/mmm
                if (w < 0)
                {//wが0以下のとき
                    u = -u; v = -v; w = -w;
                }
                if (u == 0 && v == 0)
                {
                    break;
                }
                else if (u == 0 || v == 0 || u == v)
                {
                    while (u != 0)
                    {
                        m = u; n = v; u = -n; v = m - n;
                    }
                    if (v <= 0)
                    {
                        v = -v;
                    }

                    break;
                }
                else
                {
                    while (!(u >= 0 && v >= 0))
                    {//まずuとvが正になるように
                        m = u; n = v; u = -n; v = m - n;
                    }
                    o = u + v;//このときのu+vをoに代入
                    v = u - v;//ミラー対称要素を適用
                    while (!(u >= 0 && v >= 0))
                    {//もう一回uとvが正になるように
                        m = u; n = v; u = -n; v = m - n;
                    }
                    if (o <= u + v)
                    {//ミラー対称を適用後uとvの和が小さかったら
                        if (u > v)
                        {
                            m = u; u = v; v = m;
                        }
                        break;
                    }
                    else
                    {
                        v = u - v;
                        while (!(u >= 0 && v >= 0))
                        {//まずuとvが正になるように
                            m = u; n = v; u = -n; v = m - n;
                        }
                        if (u > v) { m = u; u = v; v = m; }
                        break;
                    }
                }

            case 10:// m3 wに最大の指数がくるようにする
                u = Math.Abs(u);
                v = Math.Abs(v);
                w = Math.Abs(w);
                while (!(w >= u && w >= v))
                {
                    m = u; u = v; v = w; w = m;
                }
                if (u == w)
                {//(2,1,2)を(1,2,2)にする
                    m = u; u = v; v = m;
                }
                break;

            case 11:// m3m 例(-4, 3,-5)を(3,4,5)に
                u = Math.Abs(u);
                v = Math.Abs(v);
                w = Math.Abs(w);
                if (u > v)
                {
                    m = u; u = v; v = m;
                }
                if (v > w)
                {
                    m = v; v = w; w = m;
                }
                if (u > v)
                {
                    m = u; u = v; v = m;
                }
                break;
        }
        return (u, v, w);
        #endregion
    }

    /// <summary>
    /// 入力された面が基底のものであるかどうか判定する。
    /// 基底とは可能な限り h >= k >= l かつ h>0, k>0, l>0 に近づくような指数をさす
    /// </summary>
    /// <param name="h"></param>
    /// <param name="k"></param>
    /// <param name="l"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static bool IsRootIndex((int h, int k, int l) index, Symmetry sym)
    {
        var indices = new List<(int H, int K, int L)>();
        return IsRootIndex(index, sym, ref indices, false);
    }

    /// <summary>
    /// 入力された面が基底のものであるかどうか判定する。
    /// 基底とは可能な限り h >= k >= l かつ h>0, k>0, l>0 に近づくような指数をさす
    /// 既定であるときは多重度(multi)も同時に返す。
    /// </summary>
    /// <param name="h">面指数 h</param>
    /// <param name="k">面指数 k</param>
    /// <param name="l">面指数 l</param>
    /// <param name="sym">対称性</param>
    /// <param name="multi">多重度</param>
    /// <returns>基底のときはtrue</returns>
    public static bool IsRootIndex((int h, int k, int l) index, Symmetry sym, ref int multi)
    {
        var indices = new List<(int H, int K, int L)>();
        bool result = IsRootIndex(index, sym, ref indices, false);
        multi = indices.Count;
        return result;
    }

    #region お蔵入り?
    /*
    public static PlaneIndex GetEquivalentPlanes(PlaneIndex index, Symmetry sym)
    {
        int h = index.h, k = index.k, l = index.l;
        bool result = true;
        if (h == 0 && k == 0 && l == 0)
        {
            return new PlaneIndex(0, 0, 0);
        }

        switch (sym.LaueGroupNumber)
        {
            #region
            case 0://unknown
                return new PlaneIndex(+h, +k, +l);

            case 1://-1
                if (h > 0 || (h == 0 && k > 0) || (h == 0 && k == 0 && l > 0))
                    return index;
                else
                    return new PlaneIndex(-h, -k, -l);

            case 2:// 2/m
                switch (sym.MainAxis)
                {
                    //case "a":
                    //    if( h >= 0 && (k > 0 || (k == 0 && l >= 0)))

//                            break;
                    case "b":
                        result = (k >= 0 && (h > 0 || (h == 0 && l >= 0)));
                        break;

                    case "c":
                        result = (l >= 0 && (h > 0 || (h == 0 && k >= 0)));
                        break;
                }
                break;

            case 3:// mmm
                result = ((l >= 0 && h >= 0 && k >= 0));
                break;

            case 4: //4/m
                result = ((l >= 0 && h >= 0 && k >= 0));
                break;

            case 5: //4/mmm
                result = ((l >= 0 && h >= k && k >= 0));
                break;

            case 6: //-3
                if (sym.SpaceGroupHMsub != "R")//Hexaセルの場合
                {
                    result = ((h >= 0 && k >= 0 && (!(h == 0 && k == 0))) || (l > 0 && h == 0 && k == 0));
                    break;
                }
                else
                {//Rhomboセルの場合
                    result = (h > 0 && k == 0 && l == 0) //2つが0のとき
                        || (h > 0 && k != 0 && l == 0) //1つが0のとき
                        || (h > 0 && k > 0 && l < 0) //1つが負のとき
                        || (h > 0 && k > 0 && l > 0 && h >= k && h >= l && h != k && k != l && l != h) //全部正で、全部が異なるとき
                        || (h > 0 && k > 0 && l > 0 && h >= k && h >= l && h == k && k > l) //全部正で、2つが同じとき①
                        || (h > 0 && k > 0 && l > 0 && h >= k && h >= l && h > k && k == l) //全部正で、2つが同じとき①
                        || (h > 0 && k > 0 && l > 0 && h == k && h == l); //全部正で、3つが同じとき

                    break;
                }

            case 7: //-3m1
                if (sym.SpaceGroupHMsub != "R")//Hexaセルの場合
                {
                    result = ((l > 0 && h >= 0 && k >= 0) || (l == 0 && h <= k && h >= 0));
                    break;
                }
                else
                {//Rhomboセルの場合
                    result = (h > 0 && k == 0 && l == 0)
                            || (h > 0 && Math.Abs(h) >= Math.Abs(k) && k != 0 && l == 0)
                            || (h >= k && k >= l && h > 0 && k > 0 && l != 0)
                        ;
                    break;
                }

            case 8://6/m
                result = (l >= 0 && h > 0 && k >= 0)
                    || (l > 0 && h == 0 && k == 0);
                break;

            case 9://6/mmm
                result = (l >= 0 && k >= h && h >= 0);
                break;

            case 10://m3
                result = (h >= 0 && k >= 0 && l >= 0 && l <= h && k <= h && !(h == l && l > k));
                break;

            case 11://m3m
                result = (h >= k && k >= l && l >= 0);
                break;
            #endregion
        }

        return new PlaneIndex();
    }
    */
    #endregion

    /// <summary>
    /// 入力された面が基底のものであるかどうか判定する。
    /// 基底とは可能な限り h >= k >= l かつ h>0, k>0, l>0 に近づくような指数をさす。
    /// 規定であるときは多重度(multi)も同時に返す。
    /// </summary>
    /// <param name="h">面指数 h</param>
    /// <param name="k">面指数 k</param>
    /// <param name="l">面指数 l</param>
    /// <param name="sym">対称性</param>
    /// <param name="indices">等価な面指数の群</param>
    /// <param name="CalcNotEvenRoot">基底でなくても等価な面指数を計算するときはtrue</param>
    /// <returns>基底のときはtrue</returns>
    public static bool IsRootIndex((int h, int k, int l) index, Symmetry sym, ref List<(int H, int K, int L)> indices, bool CalcNotEvenRoot)
    {
        #region
        (int h, int k, int l) = index;
        bool result = true;
        if (h == 0 && k == 0 && l == 0)
        {
            indices.Add((0, 0, 0));
            return false;
        }

        switch (sym.LaueGroupNumber)
        {
            case 0://unknown
                indices.Add((+h, +k, +l));
                return true;

            case 1://-1
                result = h > 0 || (h == 0 && k > 0) || (h == 0 && k == 0 && l > 0);
                break;

            case 2:// 2/m
                result = sym.MainAxis switch
                {
                    "a" => h >= 0 && (k > 0 || (k == 0 && l >= 0)),
                    "b" => (k >= 0 && (h > 0 || (h == 0 && l >= 0))),
                    _ => (l >= 0 && (h > 0 || (h == 0 && k >= 0)))
                };
                break;

            case 3:// mmm
                result = ((l >= 0 && h >= 0 && k >= 0));
                break;

            case 4: //4/m
                result = ((l >= 0 && h > 0 && k >= 0) || (l > 0 && h == 0 && k == 0));
                break;

            case 5: //4/mmm
                result = ((l >= 0 && h >= k && k >= 0));
                break;

            case 6: //-3
                if (sym.SpaceGroupHMsubStr != "R" )//Hexaセルの場合
                    result = (h == 0 && k == 0 && l > 0) || (h > 0 && k >= 0);
                else//Rhomboセルの場合
                    result = (h > 0 && l == 0) || (h > 0 && k > 0 && l < 0) || (h >= k && k >= l && l > 0) || (h > l && l > k && k > 0);
                break;

            case 7: //-3m1
                if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    result = ((l > 0 && h >= 0 && k >= 0) || (l == 0 && h >= k && k >= 0));
                else//Rhomboセルの場合
                    result =  (h > 0 && h >= Math.Abs(k) && l == 0) || (h >= k && k >= l && k > 0 && l != 0);
                break;

            case 8://6/m
                result = (l >= 0 && h > 0 && k >= 0) || (l > 0 && h == 0 && k == 0);
                break;

            case 9://6/mmm
                result = (l >= 0 && k >= h && h >= 0);
                break;

            case 10://m3
                result = (h >= 0 && k >= 0 && l >= 0 && l <= h && k <= h && !(h == l && l > k));
                break;

            case 11://m3m
                result = (h >= k && k >= l && l >= 0);
                break;
        }

        if (result || CalcNotEvenRoot)
        {
            indices.AddRange(GenerateEquivalentPlanes(h, k, l, sym));
        }

        return result;
        #endregion
    }

    /// <summary>
    /// 対称性symに従って(hkl)と等価な結晶面を生成する
    /// </summary>
    /// <param name="h"></param>
    /// <param name="k"></param>
    /// <param name="l"></param>
    /// <param name="sym"></param>
    /// <param name="inversionCenter">対称心を仮定するか。デフォルトはTrue（つまりラウエ群で面を生成する）</param>
    /// <returns></returns>
    public static (int H, int K, int L)[] GenerateEquivalentPlanes(int h, int k, int l, Symmetry sym, bool inversionCenter =true)
    {
        if (h == 0 && k == 0 && l == 0) return new[] { (0, 0, 0) };

        var indices = new HashSet<(int H, int K, int L)>();
        int i;

        if (inversionCenter)
        {
            #region 対称心があると仮定して、結晶面を生成  
            switch (sym.LaueGroupNumber)
            {
                case 0://unknown
                    indices.Add((+h, +k, +l));
                    break;

                case 1://-1
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, -l));
                    break;

                case 2:// 2/m
                    switch (sym.MainAxis)
                    {
                        case "a":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, -l));

                            indices.Add((-h, +k, +l));
                            indices.Add((+h, -k, -l));
                            break;

                        case "b":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, -l));

                            indices.Add((+h, -k, +l));
                            indices.Add((-h, +k, -l));
                            break;

                        case "c":

                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, -l));

                            indices.Add((+h, +k, -l));
                            indices.Add((-h, -k, +l));
                            break;
                    }
                    break;

                case 3:// mmm
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, +k, +l));
                    indices.Add((+h, -k, +l));
                    indices.Add((+h, +k, -l));

                    indices.Add((-h, -k, +l));
                    indices.Add((+h, -k, -l));
                    indices.Add((-h, +k, -l));
                    indices.Add((-h, -k, -l));
                    break;

                case 4: //4/m

                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((-h, -k, -l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));
                    break;

                case 5: //4/mmm

                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));

                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));
                    indices.Add((+k, +h, +l));
                    indices.Add((-k, -h, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((-h, -k, -l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));

                    indices.Add((+h, -k, -l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+k, +h, -l));
                    indices.Add((-k, -h, -l));
                    break;

                case 6: //-3
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        i = -h - k;
                        indices.Add((+h, +k, +l));
                        indices.Add((+i, +h, +l));
                        indices.Add((+k, +i, +l));

                        indices.Add((-h, -k, -l));
                        indices.Add((-i, -h, -l));
                        indices.Add((-k, -i, -l));
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));

                        indices.Add((-h, -k, -l));
                        indices.Add((-l, -h, -k));
                        indices.Add((-k, -l, -h));
                        break;
                    }

                case 7: //-3m1, -31m, -3m(rhombo)の場合
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        if (sym.SpaceGroupHallStr.Contains("\""))//-3m1の場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((+k, +h, -l));
                            indices.Add((+h, +i, -l));
                            indices.Add((+i, +k, -l));

                            indices.Add((-h, -k, -l));
                            indices.Add((-i, -h, -l));
                            indices.Add((-k, -i, -l));

                            indices.Add((-k, -h, +l));
                            indices.Add((-h, -i, +l));
                            indices.Add((-i, -k, +l));
                        }
                        else//-31mの場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((-k, -h, -l));
                            indices.Add((-h, -i, -l));
                            indices.Add((-i, -k, -l));

                            indices.Add((-h, -k, -l));
                            indices.Add((-i, -h, -l));
                            indices.Add((-k, -i, -l));

                            indices.Add((+k, +h, +l));
                            indices.Add((+h, +i, +l));
                            indices.Add((+i, +k, +l));
                        }
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));

                        indices.Add((-k, -h, -l));
                        indices.Add((-h, -l, -k));
                        indices.Add((-l, -k, -h));

                        indices.Add((-h, -k, -l));
                        indices.Add((-l, -h, -k));
                        indices.Add((-k, -l, -h));

                        indices.Add((+k, +h, +l));
                        indices.Add((+h, +l, +k));
                        indices.Add((+l, +k, +h));
                        break;
                    }
                case 8://6/m
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));
                    indices.Add((-i, -h, +l));
                    indices.Add((-k, -i, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((+i, +h, -l));
                    indices.Add((+k, +i, -l));

                    indices.Add((-h, -k, -l));
                    indices.Add((-i, -h, -l));
                    indices.Add((-k, -i, -l));
                    break;

                case 9://6/mmm
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));
                    indices.Add((-i, -h, +l));
                    indices.Add((-k, -i, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((+i, +h, -l));
                    indices.Add((+k, +i, -l));

                    indices.Add((-h, -k, -l));
                    indices.Add((-i, -h, -l));
                    indices.Add((-k, -i, -l));

                    indices.Add((+k, +h, +l));
                    indices.Add((+h, +i, +l));
                    indices.Add((+i, +k, +l));

                    indices.Add((-k, -h, +l));
                    indices.Add((-h, -i, +l));
                    indices.Add((-i, -k, +l));

                    indices.Add((+k, +h, -l));
                    indices.Add((+h, +i, -l));
                    indices.Add((+i, +k, -l));

                    indices.Add((-k, -h, -l));
                    indices.Add((-h, -i, -l));
                    indices.Add((-i, -k, -l));
                    break;

                case 10://m3
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+h, -k, -l));

                    indices.Add((+l, +h, +k));
                    indices.Add((-l, -h, +k));
                    indices.Add((-l, +h, -k));
                    indices.Add((+l, -h, -k));

                    indices.Add((+k, +l, +h));
                    indices.Add((-k, -l, +h));
                    indices.Add((-k, +l, -h));
                    indices.Add((+k, -l, -h));

                    indices.Add((-h, -k, -l));
                    indices.Add((+h, +k, -l));
                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));

                    indices.Add((-l, -h, -k));
                    indices.Add((+l, +h, -k));
                    indices.Add((+l, -h, +k));
                    indices.Add((-l, +h, +k));

                    indices.Add((-k, -l, -h));
                    indices.Add((+k, +l, -h));
                    indices.Add((+k, -l, +h));
                    indices.Add((-k, +l, +h));
                    break;

                case 11://m3m
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+h, -k, -l));

                    indices.Add((+l, +h, +k));
                    indices.Add((-l, -h, +k));
                    indices.Add((-l, +h, -k));
                    indices.Add((+l, -h, -k));

                    indices.Add((+k, +l, +h));
                    indices.Add((-k, -l, +h));
                    indices.Add((-k, +l, -h));
                    indices.Add((+k, -l, -h));

                    indices.Add((-h, -k, -l));
                    indices.Add((+h, +k, -l));
                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));

                    indices.Add((-l, -h, -k));
                    indices.Add((+l, +h, -k));
                    indices.Add((+l, -h, +k));
                    indices.Add((-l, +h, +k));

                    indices.Add((-k, -l, -h));
                    indices.Add((+k, +l, -h));
                    indices.Add((+k, -l, +h));
                    indices.Add((-k, +l, +h));

                    indices.Add((+k, +h, +l));
                    indices.Add((-k, -h, +l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));

                    indices.Add((+l, +k, +h));
                    indices.Add((-l, -k, +h));
                    indices.Add((-l, +k, -h));
                    indices.Add((+l, -k, -h));

                    indices.Add((+h, +l, +k));
                    indices.Add((-h, -l, +k));
                    indices.Add((-h, +l, -k));
                    indices.Add((+h, -l, -k));

                    indices.Add((-k, -h, -l));
                    indices.Add((+k, +h, -l));
                    indices.Add((+k, -h, +l));
                    indices.Add((-k, +h, +l));

                    indices.Add((-l, -k, -h));
                    indices.Add((+l, +k, -h));
                    indices.Add((+l, -k, +h));
                    indices.Add((-l, +k, +h));

                    indices.Add((-h, -l, -k));
                    indices.Add((+h, +l, -k));
                    indices.Add((+h, -l, +k));
                    indices.Add((-h, +l, +k));
                    break;
            }
            #endregion
        }
        else
        {
            #region 対称心がないと仮定して、結晶面を生成 
            switch (sym.PointGroupNumber)
            {
                case 0://unknown
                    indices.Add((+h, +k, +l));
                    break;
                
                case 1://1
                    indices.Add((+h, +k, +l));
                    break;

                case 2://1
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, -l));
                    break;

                case 3:// 2
                    switch (sym.MainAxis)
                    {
                        case "a":
                            indices.Add((+h, +k, +l));
                            indices.Add((+h, -k, -l));
                            break;

                        case "b":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, +k, -l));
                            break;

                        case "c":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, +l));
                            break;
                    }
                    break;
                    
                case 4:// m
                    switch (sym.MainAxis)
                    {
                        case "a":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, +k, +l));
                            break;

                        case "b":
                            indices.Add((+h, +k, +l));
                            indices.Add((+h, -k, +l));
                            break;

                        case "c":
                            indices.Add((+h, +k, +l));
                            indices.Add((+h, +k, -l));
                            break;
                    }
                    break;
                case 5:// 2/m
                    switch (sym.MainAxis)
                    {
                        case "a":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, -l));

                            indices.Add((-h, +k, +l));
                            indices.Add((+h, -k, -l));
                            break;

                        case "b":
                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, -l));

                            indices.Add((+h, -k, +l));
                            indices.Add((-h, +k, -l));
                            break;

                        case "c":

                            indices.Add((+h, +k, +l));
                            indices.Add((-h, -k, -l));
                            indices.Add((+h, +k, -l));
                            indices.Add((-h, -k, +l));
                            break;
                    }
                    break;

                case 6:// 222
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((+h, -k, -l));
                    indices.Add((-h, +k, -l));
                    break;

                case 7:// mm2
                    if (sym.StrSE1p.Contains("2"))//2mmの場合
                    {
                        indices.Add((+h, +k, +l));//
                        indices.Add((+h, -k, +l));//
                        indices.Add((+h, +k, -l));//
                        indices.Add((+h, -k, -l));//
                    }
                    else if (sym.StrSE2p.Contains("2"))//m2mの場合
                    {
                        indices.Add((+h, +k, +l));//
                        indices.Add((-h, +k, +l));//
                        indices.Add((+h, +k, -l));//
                        indices.Add((-h, +k, -l));//
                    }
                    else//mm2の場合
                    {
                        indices.Add((+h, +k, +l));//
                        indices.Add((-h, +k, +l));//
                        indices.Add((+h, -k, +l));//
                        indices.Add((-h, -k, +l));//
                    }
                        break;

                case 8:// mmm
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, +k, +l));
                    indices.Add((+h, -k, +l));
                    indices.Add((+h, +k, -l));

                    indices.Add((-h, -k, +l));
                    indices.Add((+h, -k, -l));
                    indices.Add((-h, +k, -l));
                    indices.Add((-h, -k, -l));
                    break;

                case 9: // 4
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));
                    break;

                case 10: // -4
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));
                    break;
                case 11: //4/m
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((-h, -k, -l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));
                    break;

                case 12: // 422
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));

                    indices.Add((+h, -k, -l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+k, +h, -l));
                    indices.Add((-k, -h, -l));
                    break;

                case 13: // 4mm
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));

                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));
                    indices.Add((+k, +h, +l));
                    indices.Add((-k, -h, +l));
                    break;

                case 14: // -42m
                    if (sym.StrSE2p.Contains("2"))// -42mの場合
                    {
                        indices.Add((+h, +k, +l));//
                        indices.Add((-h, -k, +l));//
                        indices.Add((-h, +k, -l));//
                        indices.Add((+h, -k, -l));//

                        indices.Add((+k, -h, -l));//
                        indices.Add((-k, +h, -l));//
                        indices.Add((-k, -h, +l));//
                        indices.Add((+k, +h, +l));//
                    }
                    else// -4m2の場合
                    {
                        indices.Add((+h, +k, +l));//
                        indices.Add((-h, -k, +l));//
                        indices.Add((+h, -k, +l));//
                        indices.Add((-h, +k, +l));//
                        
                        indices.Add((-k, +h, -l));//
                        indices.Add((+k, -h, -l));//
                        indices.Add((+k, +h, -l));//
                        indices.Add((-k, -h, -l));//
                    }
                    break;

                case 15: // 4/mmm
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-k, +h, +l));
                    indices.Add((+k, -h, +l));

                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));
                    indices.Add((+k, +h, +l));
                    indices.Add((-k, -h, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((-h, -k, -l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));

                    indices.Add((+h, -k, -l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+k, +h, -l));
                    indices.Add((-k, -h, -l));
                    break;

                case 16: // 3
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        i = -h - k;
                        indices.Add((+h, +k, +l));
                        indices.Add((+i, +h, +l));
                        indices.Add((+k, +i, +l));
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));
                        break;
                    }
                case 17: //-3
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        i = -h - k;
                        indices.Add((+h, +k, +l));
                        indices.Add((+i, +h, +l));
                        indices.Add((+k, +i, +l));

                        indices.Add((-h, -k, -l));
                        indices.Add((-i, -h, -l));
                        indices.Add((-k, -i, -l));
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));

                        indices.Add((-h, -k, -l));
                        indices.Add((-l, -h, -k));
                        indices.Add((-k, -l, -h));
                        break;
                    }

                case 18: // 312, 321, 32(rhombo)の場合
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        if (sym.SpaceGroupHallStr.Contains("\""))// 321の場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((+k, +h, -l));//
                            indices.Add((+h, +i, -l));//
                            indices.Add((+i, +k, -l));//
                        }
                        else// 312の場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((-k, -h, -l));
                            indices.Add((-h, -i, -l));
                            indices.Add((-i, -k, -l));
                        }
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));

                        indices.Add((-k, -h, -l));
                        indices.Add((-h, -l, -k));
                        indices.Add((-l, -k, -h));
                        break;
                    }

                case 19: // 3m1,  31m, 3m(rhombo)の場合
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        if (sym.SpaceGroupHallStr.Contains("\""))// 3m1の場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((-k, -h, +l));
                            indices.Add((-h, -i, +l));
                            indices.Add((-i, -k, +l));
                        }
                        else//-31mの場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((+k, +h, +l));
                            indices.Add((+h, +i, +l));
                            indices.Add((+i, +k, +l));
                        }
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));

                        indices.Add((+k, +h, +l));
                        indices.Add((+h, +l, +k));
                        indices.Add((+l, +k, +h));
                        break;
                    }

                case 20: //-3m1, -31m, -3m(rhombo)の場合
                    if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                    {
                        if (sym.SpaceGroupHallStr.Contains("\""))//-3m1の場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((+k, +h, -l));
                            indices.Add((+h, +i, -l));
                            indices.Add((+i, +k, -l));

                            indices.Add((-h, -k, -l));
                            indices.Add((-i, -h, -l));
                            indices.Add((-k, -i, -l));

                            indices.Add((-k, -h, +l));
                            indices.Add((-h, -i, +l));
                            indices.Add((-i, -k, +l));
                        }
                        else//-31mの場合
                        {
                            i = -h - k;
                            indices.Add((+h, +k, +l));
                            indices.Add((+i, +h, +l));
                            indices.Add((+k, +i, +l));

                            indices.Add((-k, -h, -l));
                            indices.Add((-h, -i, -l));
                            indices.Add((-i, -k, -l));

                            indices.Add((-h, -k, -l));
                            indices.Add((-i, -h, -l));
                            indices.Add((-k, -i, -l));

                            indices.Add((+k, +h, +l));
                            indices.Add((+h, +i, +l));
                            indices.Add((+i, +k, +l));
                        }
                        break;
                    }
                    else
                    {//Rhomboセルの場合
                        indices.Add((+h, +k, +l));
                        indices.Add((+l, +h, +k));
                        indices.Add((+k, +l, +h));

                        indices.Add((-k, -h, -l));
                        indices.Add((-h, -l, -k));
                        indices.Add((-l, -k, -h));

                        indices.Add((-h, -k, -l));
                        indices.Add((-l, -h, -k));
                        indices.Add((-k, -l, -h));

                        indices.Add((+k, +h, +l));
                        indices.Add((+h, +l, +k));
                        indices.Add((+l, +k, +h));
                        break;
                    }

                case 21:// 6
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));
                    indices.Add((-i, -h, +l));
                    indices.Add((-k, -i, +l));
                    break;

                case 22:// -6
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((+i, +h, -l));
                    indices.Add((+k, +i, -l));
                    break;

                case 23:// 6/m
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));
                    indices.Add((-i, -h, +l));
                    indices.Add((-k, -i, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((+i, +h, -l));
                    indices.Add((+k, +i, -l));

                    indices.Add((-h, -k, -l));
                    indices.Add((-i, -h, -l));
                    indices.Add((-k, -i, -l));
                    break;

                case 24:// 622
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));//
                    indices.Add((-i, -h, +l));//
                    indices.Add((-k, -i, +l));//

                    indices.Add((+k, +h, -l));//
                    indices.Add((+h, +i, -l));//
                    indices.Add((+i, +k, -l));//

                    indices.Add((-k, -h, -l));//
                    indices.Add((-h, -i, -l));//
                    indices.Add((-i, -k, -l));//
                    break;

                case 25://6mm
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));
                    indices.Add((-i, -h, +l));
                    indices.Add((-k, -i, +l));

                    indices.Add((+k, +h, +l));
                    indices.Add((+h, +i, +l));
                    indices.Add((+i, +k, +l));

                    indices.Add((-k, -h, +l));
                    indices.Add((-h, -i, +l));
                    indices.Add((-i, -k, +l));
                    break;

                case 26://-6m2
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((+h, +k, -l));//
                    indices.Add((+i, +h, -l));//
                    indices.Add((+k, +i, -l));//

                    indices.Add((-k, -h, +l));//
                    indices.Add((-h, -i, +l));//
                    indices.Add((-i, -k, +l));//

                    indices.Add((-k, -h, -l));//
                    indices.Add((-h, -i, -l));//
                    indices.Add((-i, -k, -l));//
                    break;

                case 27:// 6/mmm
                    i = -h - k;
                    indices.Add((+h, +k, +l));
                    indices.Add((+i, +h, +l));
                    indices.Add((+k, +i, +l));

                    indices.Add((-h, -k, +l));
                    indices.Add((-i, -h, +l));
                    indices.Add((-k, -i, +l));

                    indices.Add((+h, +k, -l));
                    indices.Add((+i, +h, -l));
                    indices.Add((+k, +i, -l));

                    indices.Add((-h, -k, -l));
                    indices.Add((-i, -h, -l));
                    indices.Add((-k, -i, -l));

                    indices.Add((+k, +h, +l));
                    indices.Add((+h, +i, +l));
                    indices.Add((+i, +k, +l));

                    indices.Add((-k, -h, +l));
                    indices.Add((-h, -i, +l));
                    indices.Add((-i, -k, +l));

                    indices.Add((+k, +h, -l));
                    indices.Add((+h, +i, -l));
                    indices.Add((+i, +k, -l));

                    indices.Add((-k, -h, -l));
                    indices.Add((-h, -i, -l));
                    indices.Add((-i, -k, -l));
                    break;

                case 28:// 23
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+h, -k, -l));

                    indices.Add((+l, +h, +k));
                    indices.Add((-l, -h, +k));
                    indices.Add((-l, +h, -k));
                    indices.Add((+l, -h, -k));

                    indices.Add((+k, +l, +h));
                    indices.Add((-k, -l, +h));
                    indices.Add((-k, +l, -h));
                    indices.Add((+k, -l, -h));
                    break;

                case 29:// m3
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+h, -k, -l));

                    indices.Add((+l, +h, +k));
                    indices.Add((-l, -h, +k));
                    indices.Add((-l, +h, -k));
                    indices.Add((+l, -h, -k));

                    indices.Add((+k, +l, +h));
                    indices.Add((-k, -l, +h));
                    indices.Add((-k, +l, -h));
                    indices.Add((+k, -l, -h));

                    indices.Add((-h, -k, -l));
                    indices.Add((+h, +k, -l));
                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));

                    indices.Add((-l, -h, -k));
                    indices.Add((+l, +h, -k));
                    indices.Add((+l, -h, +k));
                    indices.Add((-l, +h, +k));

                    indices.Add((-k, -l, -h));
                    indices.Add((+k, +l, -h));
                    indices.Add((+k, -l, +h));
                    indices.Add((-k, +l, +h));
                    break;

                case 30:// 432
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+h, -k, -l));

                    indices.Add((+l, +h, +k));//
                    indices.Add((-l, -h, +k));//
                    indices.Add((-l, +h, -k));//
                    indices.Add((+l, -h, -k));//

                    indices.Add((+k, +l, +h));//
                    indices.Add((-k, -l, +h));//
                    indices.Add((-k, +l, -h));//
                    indices.Add((+k, -l, -h));//

                    indices.Add((-k, -h, -l));//
                    indices.Add((+k, +h, -l));//
                    indices.Add((+k, -h, +l));//
                    indices.Add((-k, +h, +l));//

                    indices.Add((-l, -k, -h));//
                    indices.Add((+l, +k, -h));//
                    indices.Add((+l, -k, +h));//
                    indices.Add((-l, +k, +h));//

                    indices.Add((-h, -l, -k));//
                    indices.Add((+h, +l, -k));//
                    indices.Add((+h, -l, +k));//
                    indices.Add((-h, +l, +k));//
                    break;

                case 31:// -43m
                    indices.Add((+h, +k, +l));//
                    indices.Add((-h, -k, +l));//
                    indices.Add((-h, +k, -l));//
                    indices.Add((+h, -k, -l));//

                    indices.Add((+l, +h, +k));//
                    indices.Add((-l, -h, +k));//
                    indices.Add((-l, +h, -k));//
                    indices.Add((+l, -h, -k));//

                    indices.Add((+k, +l, +h));//
                    indices.Add((-k, -l, +h));//
                    indices.Add((-k, +l, -h));//
                    indices.Add((+k, -l, -h));//

                    indices.Add((+k, +h, +l));//
                    indices.Add((-k, -h, +l));//
                    indices.Add((-k, +h, -l));//
                    indices.Add((+k, -h, -l));//

                    indices.Add((+l, +k, +h));//
                    indices.Add((-l, -k, +h));//
                    indices.Add((-l, +k, -h));//
                    indices.Add((+l, -k, -h));//

                    indices.Add((+h, +l, +k));//
                    indices.Add((-h, -l, +k));//
                    indices.Add((-h, +l, -k));//
                    indices.Add((+h, -l, -k));//
                    break;

                case 32://m3m
                    indices.Add((+h, +k, +l));
                    indices.Add((-h, -k, +l));
                    indices.Add((-h, +k, -l));
                    indices.Add((+h, -k, -l));

                    indices.Add((+l, +h, +k));
                    indices.Add((-l, -h, +k));
                    indices.Add((-l, +h, -k));
                    indices.Add((+l, -h, -k));

                    indices.Add((+k, +l, +h));
                    indices.Add((-k, -l, +h));
                    indices.Add((-k, +l, -h));
                    indices.Add((+k, -l, -h));

                    indices.Add((-h, -k, -l));
                    indices.Add((+h, +k, -l));
                    indices.Add((+h, -k, +l));
                    indices.Add((-h, +k, +l));

                    indices.Add((-l, -h, -k));
                    indices.Add((+l, +h, -k));
                    indices.Add((+l, -h, +k));
                    indices.Add((-l, +h, +k));

                    indices.Add((-k, -l, -h));
                    indices.Add((+k, +l, -h));
                    indices.Add((+k, -l, +h));
                    indices.Add((-k, +l, +h));

                    indices.Add((+k, +h, +l));
                    indices.Add((-k, -h, +l));
                    indices.Add((-k, +h, -l));
                    indices.Add((+k, -h, -l));

                    indices.Add((+l, +k, +h));
                    indices.Add((-l, -k, +h));
                    indices.Add((-l, +k, -h));
                    indices.Add((+l, -k, -h));

                    indices.Add((+h, +l, +k));
                    indices.Add((-h, -l, +k));
                    indices.Add((-h, +l, -k));
                    indices.Add((+h, -l, -k));

                    indices.Add((-k, -h, -l));
                    indices.Add((+k, +h, -l));
                    indices.Add((+k, -h, +l));
                    indices.Add((-k, +h, +l));

                    indices.Add((-l, -k, -h));
                    indices.Add((+l, +k, -h));
                    indices.Add((+l, -k, +h));
                    indices.Add((-l, +k, +h));

                    indices.Add((-h, -l, -k));
                    indices.Add((+h, +l, -k));
                    indices.Add((+h, -l, +k));
                    indices.Add((-h, +l, +k));
                    break;
            }
            #endregion
        }
        return indices.ToArray();
    }

    /// <summary>
    /// 二つの面(h1,k1,l1), (h2,k2,l2)が等価かどうかを判定する
    /// </summary>
    /// <param name="h1"></param>
    /// <param name="k1"></param>
    /// <param name="l1"></param>
    /// <param name="h2"></param>
    /// <param name="k2"></param>
    /// <param name="l2"></param>
    /// <param name="sym"></param>
    /// <returns>等価だった場合はTrue</returns>
    public static bool CheckEquivalentPlanes(int h1, int k1, int l1, int h2, int k2, int l2, Symmetry sym)
        => new List<(int H, int K, int L)>(GenerateEquivalentPlanes(h1, k1, l1, sym)).Contains((h2, k2, l2));

    /// <summary>
    /// 二つの面(index1), (index2)が等価かどうかを判定する
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static bool CheckEquivalentPlanes((int H, int K, int L) index1, (int H, int K, int L) index2, Symmetry sym)
        => CheckEquivalentAxes(index1.H, index1.K, index1.L, index2.H, index2.K, index2.L, sym);

    /// <summary>
    /// 対称性に従って[uvw]と等価な結晶軸を生成する
    /// </summary>
    /// <param name="u"></param>
    /// <param name="v"></param>
    /// <param name="w"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static (int U, int V, int W)[] GenerateEquivalentAxes(int u, int v, int w, Symmetry sym)
    {
        #region
        var indices = new HashSet<(int U, int V, int W)>();

        if (u == 0 && v == 0 && w == 0)
        {
            indices.Add((0, 0, 0));
            return indices.ToArray();
        }
        int x;
        switch (sym.LaueGroupNumber)
        {
            case 0://unknown
                indices.Add((+u, +v, +w));
                break;

            case 1://-1
                indices.Add((+u, +v, +w));
                indices.Add((-u, -v, -w));
                break;

            case 2:// 2/m
                switch (sym.MainAxis)
                {
                    case "a":
                        indices.Add((+u, +v, +w));
                        indices.Add((-u, -v, -w));

                        indices.Add((-u, +v, +w));
                        indices.Add((+u, -v, -w));
                        break;

                    case "b":
                        indices.Add((+u, +v, +w));
                        indices.Add((-u, -v, -w));

                        indices.Add((+u, -v, +w));
                        indices.Add((-u, +v, -w));
                        break;

                    case "c":

                        indices.Add((+u, +v, +w));
                        indices.Add((-u, -v, -w));

                        indices.Add((+u, +v, -w));
                        indices.Add((-u, -v, +w));
                        break;
                }
                break;

            case 3:// mmm
                indices.Add((+u, +v, +w));
                indices.Add((-u, +v, +w));
                indices.Add((+u, -v, +w));
                indices.Add((+u, +v, -w));

                indices.Add((-u, -v, +w));
                indices.Add((+u, -v, -w));
                indices.Add((-u, +v, -w));
                indices.Add((-u, -v, -w));
                break;

            case 4: //4/m

                indices.Add((+u, +v, +w));
                indices.Add((-u, -v, +w));
                indices.Add((-v, +u, +w));
                indices.Add((+v, -u, +w));

                indices.Add((+u, +v, -w));
                indices.Add((-u, -v, -w));
                indices.Add((-v, +u, -w));
                indices.Add((+v, -u, -w));
                break;

            case 5: //4/mmm

                indices.Add((+u, +v, +w));
                indices.Add((-u, -v, +w));
                indices.Add((-v, +u, +w));
                indices.Add((+v, -u, +w));

                indices.Add((+u, -v, +w));
                indices.Add((-u, +v, +w));
                indices.Add((+v, +u, +w));
                indices.Add((-v, -u, +w));

                indices.Add((+u, +v, -w));
                indices.Add((-u, -v, -w));
                indices.Add((-v, +u, -w));
                indices.Add((+v, -u, -w));

                indices.Add((+u, -v, -w));
                indices.Add((-u, +v, -w));
                indices.Add((+v, +u, -w));
                indices.Add((-v, -u, -w));
                break;

            case 6: //-3
                if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                {
                    x = v - u;
                    indices.Add((+u, +v, +w));
                    indices.Add((+x, -u, +w));
                    indices.Add((-v, -x, +w));

                    indices.Add((-u, -v, -w));
                    indices.Add((-x, +u, -w));
                    indices.Add((+v, +x, -w));
                    break;
                }
                else
                {//Rhomboセルの場合
                    indices.Add((+u, +v, +w));
                    indices.Add((+w, +u, +v));
                    indices.Add((+v, +w, +u));

                    indices.Add((-u, -v, -w));
                    indices.Add((-w, -u, -v));
                    indices.Add((-v, -w, -u));
                    break;
                }

            case 7: //-3m1
                if (sym.SpaceGroupHMsubStr != "R")//Hexaセルの場合
                {
                    x = v - u;
                    indices.Add((+u, +v, +w));
                    indices.Add((+x, -u, +w));
                    indices.Add((-v, -x, +w));

                    indices.Add((-u, -v, +w));
                    indices.Add((-x, +u, +w));
                    indices.Add((+v, +x, +w));

                    indices.Add((+u, +v, -w));
                    indices.Add((+x, -u, -w));
                    indices.Add((-v, -x, -w));

                    indices.Add((-u, -v, -w));
                    indices.Add((-x, +u, -w));
                    indices.Add((+v, +x, -w));

                    break;
                }
                else
                {//Rhomboセルの場合
                    indices.Add((+u, +v, +w));
                    indices.Add((+w, +u, +v));
                    indices.Add((+v, +w, +u));

                    indices.Add((-v, -u, -w));
                    indices.Add((-u, -w, -v));
                    indices.Add((-w, -v, -u));

                    indices.Add((-u, -v, -w));
                    indices.Add((-w, -u, -v));
                    indices.Add((-v, -w, -u));

                    indices.Add((+v, +u, +w));
                    indices.Add((+u, +w, +v));
                    indices.Add((+w, +v, +u));
                    break;
                }
            case 8://6/m
                x = v - u;
                indices.Add((+u, +v, +w));
                indices.Add((+x, -u, +w));
                indices.Add((-v, -x, +w));

                indices.Add((-u, -v, +w));
                indices.Add((-x, +u, +w));
                indices.Add((+v, +x, +w));

                indices.Add((+u, +v, -w));
                indices.Add((+x, -u, -w));
                indices.Add((-v, -x, -w));

                indices.Add((-u, -v, -w));
                indices.Add((-x, +u, -w));
                indices.Add((+v, +x, -w));
                break;

            case 9://6/mmm
                x = v - u;
                indices.Add((+u, +v, +w));
                indices.Add((+x, -u, +w));
                indices.Add((-v, -x, +w));

                indices.Add((-u, -v, +w));
                indices.Add((-x, +u, +w));
                indices.Add((+v, +x, +w));

                indices.Add((+u, +v, -w));
                indices.Add((+x, -u, -w));
                indices.Add((-v, -x, -w));

                indices.Add((-u, -v, -w));
                indices.Add((-x, +u, -w));
                indices.Add((+v, +x, -w));

                indices.Add((+v, +u, +w));
                indices.Add((-u, +x, +w));
                indices.Add((-x, -v, +w));

                indices.Add((-v, -u, +w));
                indices.Add((+u, -x, +w));
                indices.Add((+x, +v, +w));

                indices.Add((+v, +u, -w));
                indices.Add((-u, +x, -w));
                indices.Add((-x, -v, -w));

                indices.Add((-v, -u, -w));
                indices.Add((+u, -x, -w));
                indices.Add((+x, +v, -w));
                break;

            case 10://m3
                indices.Add((+u, +v, +w));
                indices.Add((-u, -v, +w));
                indices.Add((-u, +v, -w));
                indices.Add((+u, -v, -w));

                indices.Add((+w, +u, +v));
                indices.Add((-w, -u, +v));
                indices.Add((-w, +u, -v));
                indices.Add((+w, -u, -v));

                indices.Add((+v, +w, +u));
                indices.Add((-v, -w, +u));
                indices.Add((-v, +w, -u));
                indices.Add((+v, -w, -u));

                indices.Add((-u, -v, -w));
                indices.Add((+u, +v, -w));
                indices.Add((+u, -v, +w));
                indices.Add((-u, +v, +w));

                indices.Add((-w, -u, -v));
                indices.Add((+w, +u, -v));
                indices.Add((+w, -u, +v));
                indices.Add((-w, +u, +v));

                indices.Add((-v, -w, -u));
                indices.Add((+v, +w, -u));
                indices.Add((+v, -w, +u));
                indices.Add((-v, +w, +u));
                break;

            case 11://m3m
                indices.Add((+u, +v, +w));
                indices.Add((-u, -v, +w));
                indices.Add((-u, +v, -w));
                indices.Add((+u, -v, -w));

                indices.Add((+w, +u, +v));
                indices.Add((-w, -u, +v));
                indices.Add((-w, +u, -v));
                indices.Add((+w, -u, -v));

                indices.Add((+v, +w, +u));
                indices.Add((-v, -w, +u));
                indices.Add((-v, +w, -u));
                indices.Add((+v, -w, -u));

                indices.Add((-u, -v, -w));
                indices.Add((+u, +v, -w));
                indices.Add((+u, -v, +w));
                indices.Add((-u, +v, +w));

                indices.Add((-w, -u, -v));
                indices.Add((+w, +u, -v));
                indices.Add((+w, -u, +v));
                indices.Add((-w, +u, +v));

                indices.Add((-v, -w, -u));
                indices.Add((+v, +w, -u));
                indices.Add((+v, -w, +u));
                indices.Add((-v, +w, +u));

                indices.Add((+v, +u, +w));
                indices.Add((-v, -u, +w));
                indices.Add((-v, +u, -w));
                indices.Add((+v, -u, -w));

                indices.Add((+w, +v, +u));
                indices.Add((-w, -v, +u));
                indices.Add((-w, +v, -u));
                indices.Add((+w, -v, -u));

                indices.Add((+u, +w, +v));
                indices.Add((-u, -w, +v));
                indices.Add((-u, +w, -v));
                indices.Add((+u, -w, -v));

                indices.Add((-v, -u, -w));
                indices.Add((+v, +u, -w));
                indices.Add((+v, -u, +w));
                indices.Add((-v, +u, +w));

                indices.Add((-w, -v, -u));
                indices.Add((+w, +v, -u));
                indices.Add((+w, -v, +u));
                indices.Add((-w, +v, +u));

                indices.Add((-u, -w, -v));
                indices.Add((+u, +w, -v));
                indices.Add((+u, -w, +v));
                indices.Add((-u, +w, +v));
                break;
        }
        return indices.ToArray();
        #endregion
    }

    /// <summary>
    /// 二つの軸[index1]と[index2]が等価な軸であるかどうかを判定
    /// </summary>
    /// <param name="index1"></param>
    /// <param name="index2"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static bool CheckEquivalentAxes((int U, int V, int W) index1, (int U, int V, int W) index2, Symmetry sym)
        => CheckEquivalentAxes(index1.U, index1.V, index1.W, index2.U, index2.V, index2.W, sym);

    /// <summary>
    /// 二つの軸[u1,v1,w1]と[u2,v2,w2]が等価な軸であるかどうかを判定
    /// </summary>
    /// <param name="u1"></param>
    /// <param name="v1"></param>
    /// <param name="w1"></param>
    /// <param name="u2"></param>
    /// <param name="v2"></param>
    /// <param name="w2"></param>
    /// <param name="sym"></param>
    /// <returns></returns>
    public static bool CheckEquivalentAxes(int u1, int v1, int w1, int u2, int v2, int w2, Symmetry sym)
        => new List<(int U, int V, int W)>(GenerateEquivalentAxes(u1, v1, w1, sym)).Contains((u2, v2, w2));
    #endregion
}
