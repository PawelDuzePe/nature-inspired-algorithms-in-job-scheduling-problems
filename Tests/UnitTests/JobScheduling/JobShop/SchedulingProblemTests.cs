using Core.JobScheduling.JobShop;
using NUnit.Framework;

namespace Tests.UnitTests.JobShop
{
    [TestFixture]
    public class SchedulingProblemTests
    {
        [Test, TestCaseSource("creating_scheduling_problem_test_cases")]
        public void test_creating_scheduling_problem_from_string_input(string dataString, int jobs, int machines, int timeSeed, int machineSeed, int upperBound, int lowerBound)
        {
            // Act
            var schedulingProblem = new SchedulingProblem(dataString);

            // Assert
            Assert.AreEqual(jobs, schedulingProblem.Jobs.Count);
            Assert.IsTrue(schedulingProblem.Jobs.TrueForAll(j => j.Operations.Count == machines));
            Assert.AreEqual(timeSeed, schedulingProblem.ComparativeData.TimeSeed);
            Assert.AreEqual(machineSeed, schedulingProblem.ComparativeData.MachineSeed);
            Assert.AreEqual(upperBound, schedulingProblem.ComparativeData.UpperBound);
            Assert.AreEqual(lowerBound, schedulingProblem.ComparativeData.LowerBound);
        }

        private static object[] creating_scheduling_problem_test_cases = 
        {
            new object[] {
                @"Nb of jobs, Nb of Machines, Time seed, Machine seed, Upper bound, Lower bound
                        15        15  840612802  398197754      1231      1005
                Times
                94 66 10 53 26 15 65 82 10 27 93 92 96 70 83
                74 31 88 51 57 78  8  7 91 79 18 51 18 99 33
                4 82 40 86 50 54 21  6 54 68 82 20 39 35 68
                73 23 30 30 53 94 58 93 32 91 30 56 27 92  9
                78 23 21 60 36 29 95 99 79 76 93 42 52 42 96
                29 61 88 70 16 31 65 83 78 26 50 87 62 14 30
                18 75 20  4 91 68 19 54 85 73 43 24 37 87 66
                32 52  9 49 61 35 99 62  6 62  7 80  3 57  7
                85 30 96 91 13 87 82 83 78 56 85  8 66 88 15
                5 59 30 60 41 17 66 89 78 88 69 45 82  6 13
                90 27  1  8 91 80 89 49 32 28 90 93  6 35 73
                47 43 75  8 51  3 84 34 28 60 69 45 67 58 87
                65 62 97 20 31 33 33 77 50 80 48 90 75 96 44
                28 21 51 75 17 89 59 56 63 18 17 30 16  7 35
                57 16 42 34 37 26 68 73  5  8 12 87 83 20 97
                Machines
                7 13  5  8  4  3 11 12  9 15 10 14  6  1  2
                5  6  8 15 14  9 12 10  7 11  1  4 13  2  3
                2  9 10 13  7 12 14  6  1  3  8 11  5  4 15
                6  3 10  7 11  1 14  5  8 15 12  9 13  2  4
                8  9  7 11  5 10  3 15 13  6  2 14 12  1  4
                6  4 13 14 12  5 15  8  3  2 11  1 10  7  9
                13  4  8  9 15  7  2 12  5  6  3 11  1 14 10
                12  6  1  8 13 14 15  2  3  9  5  4 10  7 11
                11 12  7 15  1  2  3  6 13  5  9  8 10 14  4
                7 12 10  3  9  1 14  4 11  8  2 13 15  5  6
                5  8 14  1  6 13  7  9 15 11  4  2 12 10  3
                3 15  1 13  7 11  8  6  9 10 14  2  4 12  5
                6  9 11  3  4  7 10  1 14  5  2 12 13  8 15
                9 15  5 14  6  7 10  2 13  8 12 11  4  3  1
                11  9 13  7  5  2 14 15 12  1  8  4  3 10  6",
                15, 15, 840612802, 398197754, 1231, 1005
            },
            new object[] {
                @"Nb of jobs, Nb of Machines, Time seed, Machine seed, Upper bound, Lower bound
                        30        15   98640593 1981283465      1770      1764
                Times
                99 43  6 99 23 98 84 24 30 53 34 95 50 48 38
                19 24 65 16 94  9 60 32 59 85  9 36 22 25  5
                54 62 93 78 59 71 49 88 40 13 17 88 47 30 56
                60 16 79 84 84 42 59 14 74 60 98 17 42 31 19
                49 52 46 50  1 14  2 56 64 51 75 28  9 37  6
                59 65 85 40 23 39 99 46 17 94  6 67 69 86  8
                10  7 22 36 31 75 57 49 44 21 77 70 64 46 69
                53 74 93 26 54 89 82 66 37 63 71 17 58  4 46
                76 72 42 17 27 56 78  5 72 19 90 46 43 56 17
                18 79 93 71 48 23 20 90 94 87  6 36 84 25 83
                52 61 45 60 15 74 49 26 94 54  1 58 56 54 72
                63 73 82 84 15 54 52 52 36 21 45 41 21 97 50
                90 90 77 33 31 26 14 75 92 70 55 56 39 49 23
                87 47 58 34 29 83 24 48 97 89 84 82 53 99 10
                35 32 30 93 58 28 88 16 98  4 82 98 26 29 77
                18 92 62 59  3 94 34 56 24 18 66 53 30 41 10
                2 26 17 18 60 39 23 95 81 56 34  8 47 72 56
                6 79 65 58 94 45 80  3 29 80 27 60 94 14 76
                31 79 87 79 57 48 33 42 93 86 54 32  8 16 63
                96  1 75 42 45 51 10 58 71 92 23 18 63 27 63
                84 82 16 61 43 75 28 15 19 93 22  1 62  9  5
                46 29 50 12 72 18 79 73 23  1 58  1 95 25 71
                10 39 49 56 71 40 90 28 89 42  9 92 52  6 20
                70 63 68 97 86 81 38  7 53 48 43 59 88 29 87
                81 97 65 60 15 29  9 80 78 85 95 85 91 28 92
                39  6 59 34 34 32 12  7 35  4 53 69 89  3 40
                98 85 51  9 24  7 59 98 50 98 64 31 31 29  1
                59 68  3  8  2  9 69 14 72 84 69 54 45 59  7
                92 21 53 64 59 79 52 14 61 86 82 98 83 24 87
                51 70 94 80 35 56  8 94 11  3 60 73 26 21 45
                Machines
                4 11 15  2  6  9  5 12 14 13  3 10  8  1  7
                7  5  3  4 15  6  8 14 10  1 12 13  9 11  2
                5  3 11  6 13 14  4 12 10  8  9  7 15  2  1
                1 14  5  2 15 10 13  4  9  6  3  7 11  8 12
                7  2 11  5  9  6  3 10  8  1 14 12  4 15 13
                6  7 13  4  1  5  3  9  2 14 12 10 15  8 11
                12 14  2  7  5 13 15  1 11  9  6  8  3 10  4
                6  3  2  5 10 14  9 11 12  4  8  1  7 13 15
                8 14 13  6 11 10  1 12  9  5  3  2 15  7  4
                7  8 15  2 10 12  4  6 11  3  9  1 14 13  5
                11  1  4  5  6 12  8 13 14 15  9  2  7  3 10
                6  1 10 12 13  7 11 15  9  5  8  4 14  2  3
                9  1  8  5  4  2 14  6  7 13 12 10  3 15 11
                5 10 14 13  7  3  8  2 12 11  9 15  1  6  4
                8 15 12  3 11 13  2  4 14 10  5  9  6  1  7
                14 13  5 12  2  1 11  7  6 10  3  8  4 15  9
                1  8 13 15  4  3  9 12 14 10  5  2  6  7 11
                6  7  8  5 13 10 12  4 11  9  2  1  3 15 14
                13  5  4 14 12  7  6  1 11  2  3 10  8  9 15
                1  8  4 12 11  2  9 13  6  7  3 15 10 14  5
                15  6  8  2 11  7 10  4 13  1 12 14  5  3  9
                13 12  7  9 14 11  2  8 15 10  5  4  3  1  6
                9 10 12  4  5 14 11  3  1 13  6  7  8  2 15
                13  9  7 10 12  6  3  8 15  1  5  2  4 14 11
                15 12  9  5 11  6  4  3  7 10 13 14  1  2  8
                8 15  5  1 13 11  9  6  4  2  7 10  3 12 14
                12 13  5 15 14  2  6  9  1  8 11 10  3  7  4
                15  9  8  2  1  7 10 13  6 11  5 14 12  3  4
                9  8 11 15  6 13 10  3 12  2  4  1 14  7  5
                3 13 14  4  1 15  7  6 11 12  9 10  2  8  5",
                30, 15, 98640593, 1981283465, 1770, 1764
            }
        };
    }
}