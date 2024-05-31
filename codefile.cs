//C# code the give problem with two test cases

using System;
using System.Collections.Generic;

class HelloWorld {
  static void Main(string[] args)
    {
        // Test case 1
        List<int> enemyPowers1 = new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
        int abhimanyuPower1 = 15;
        int skipBattles1 = 2;
        int rechargeTimes1 = 1;
        int rechargePower1 = 5;
        Console.WriteLine(CanAbhimanyuCrossChakravyuha(enemyPowers1, abhimanyuPower1, skipBattles1, rechargeTimes1, rechargePower1));//prints true

        // Test case 2
        List<int> enemyPowers2 = new List<int> { 10, 20, 5, 15, 10, 5, 20, 15, 10, 5, 10 };
        int abhimanyuPower2 = 30;
        int skipBattles2 = 3;
        int rechargeTimes2 = 2;
        int rechargePower2 = 10;
        Console.WriteLine(CanAbhimanyuCrossChakravyuha(enemyPowers2, abhimanyuPower2, skipBattles2, rechargeTimes2, rechargePower2));//prints false
    }

    static bool CanAbhimanyuCrossChakravyuha(List<int> enemyPowers, int abhimanyuPower, int skipBattles, int rechargeTimes, int rechargePower)
    {
        int n = enemyPowers.Count;
        bool[] regenerated = new bool[n];

        for (int i = 0; i < n; i++)
        {
            if (i == 2 || i == 6)
            {
                if (!regenerated[i])
                {
                    enemyPowers[i] += enemyPowers[i] / 2;
                    regenerated[i] = true;
                }
            }

            if (skipBattles > 0)
            {
                skipBattles--;
                continue;
            }

            if (rechargeTimes > 0 && abhimanyuPower < enemyPowers[i])
            {
                abhimanyuPower += rechargePower;
                rechargeTimes--;
            }

            if (abhimanyuPower < enemyPowers[i])
            {
                return false;
            }
            else
            {
                abhimanyuPower -= enemyPowers[i];
            }

            if (i == 3 && regenerated[2])
            {
                if (abhimanyuPower < enemyPowers[2])
                {
                    return false;
                }
                abhimanyuPower -= enemyPowers[2];
            }
            if (i == 7 && regenerated[6])
            {
                if (abhimanyuPower < enemyPowers[6])
                {
                    return false;
                }
                abhimanyuPower -= enemyPowers[6];
            }
        }

        return true; 
    }
}


