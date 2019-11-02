using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ProjectEulerSolve
{
    public static class NumSolve
    {
        /// <summary>
        /// 计算n以内3或者5以内倍数的数值综合
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static int GetMul3Or5(int n)
        {
            int sum = 0;
            for (int i = 1; i < n; i++)
            {
                if (i % 3 == 0 || i % 5 == 0)
                {
                    sum += i;
                }
            }
            return sum;
        }

        public static long GetSumEvenFibonacci(int n)
        {
            long sum = 0;
            for (int i = 1; i < n; i++)
            {
                var term = GetFibonacciForLoop(i);

                if (term > n)
                {
                    break;
                }
                if (term % 2 == 0)
                {
                    Console.WriteLine("DateTime:{1},Calculate Fibo:{0},Sum value:{2}", i, DateTime.Now.ToLongTimeString(), sum);
                    sum += term;
                }
            }
            return sum;
        }

        /// <summary>
        /// 获取Fibonacci数据（递归方式，速度太慢）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        private static long GetFibonacci(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }

        /// <summary>
        /// 获取Fibonacci数据（循环方式）
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long GetFibonacciForLoop(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }
            //定义n-1,n-2的值
            long lastValue = 1;
            long curValue = 1;
            long fibo = 1;
            for (int i = 3; i <= n; i++)
            {
                fibo = curValue + lastValue;
                lastValue = curValue;
                curValue = fibo;
            }

            return fibo;
        }

        /// <summary>
        /// 获取最大质数因数
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public static long GetLargestFactor(long n)
        {
            //因数不会超过平方根倍
            long maxFactor = 0;
            long minNum = (long)Math.Sqrt(n + 1);
            for (long i = 2; i < minNum; i++)
            {
                while (n % i == 0)
                {
                    n /= i;
                    if (maxFactor < i)
                    {
                        maxFactor = i;
                    }
                }
            }

            return maxFactor;
        }

        public static int Palindrome3Dig()
        {
            /*
             在本题中求得的是两个三位数乘积的最大回文数，我们通过三位数的边界，
             我们可以确定这个两个三位数至少可以形成一个5位数，至多可以形成一个6位数。 
             由于我们所求的是最大的回文数，所以我们只考虑6位的情况即可。
             */
            int max = 0;
            for (int i = 999; i >= 100; i--)
            {
                for (int j = i - 1; j >= 100; j--)
                {
                    //我们发现所有6位回文数，他一定能够被11整除，借此我们优化我们的程序。
                    int genNum = i * j;
                    if (genNum % 11 != 0) continue;


                    string numStr = genNum.ToString();
                    string pattern = @"([0-9])([0-9])([0-9])\3\2\1";
                    if (Regex.IsMatch(numStr, pattern) && max < genNum)
                    {
                        max = genNum;
                    }
                }
            }

            return max;
        }


        public static long SmallestMultiple(int n)
        {
            int x = 2520;
            while (true)
            {
                bool isMul = true;
                for (int i = 1; i < n; i++)
                {
                    if (x % i != 0)
                    {
                        x++;
                        isMul = false;
                        break;
                    }
                }
                if (isMul) return x;
            }
        }

        public static long SumSquareDifference()
        {
            int m = 100;

            long numSquare = 0;
            for (int i = 1; i <= m; i++)
            {
                numSquare += (long)Math.Pow(i, 2);
            }

            long squareNum = 0;
            for (int i = 1; i <= m; i++)
            {
                squareNum += i;
            }
            squareNum = (long)Math.Pow(squareNum, 2);

            return squareNum - numSquare;
        }

        public static long The10001stPrime()
        {
            int x = 2;
            int times = 0;
            while (true)
            {
                if (!IsPrime(x))
                {
                    x++;
                    continue;
                }
                else
                {
                    times++;
                }
                Console.WriteLine("times:{0},primer:{1}", times, x);
                if (times == 10001) return x;
                x++;
            }
        }

        private static bool IsPrime(long p)
        {
            long max = (long)Math.Sqrt(p);
            for (long i = 2; i <= max; i++)
            {
                if (p % i == 0) return false;
            }
            return true;
        }

        public static long Get13Production()
        {
            #region string
            string numStr =
@"73167176531330624919225119674426574742355349194934" +
"96983520312774506326239578318016984801869478851843" +
"85861560789112949495459501737958331952853208805511" +
"12540698747158523863050715693290963295227443043557" +
"66896648950445244523161731856403098711121722383113" +
"62229893423380308135336276614282806444486645238749" +
"30358907296290491560440772390713810515859307960866" +
"70172427121883998797908792274921901699720888093776" +
"65727333001053367881220235421809751254540594752243" +
"52584907711670556013604839586446706324415722155397" +
"53697817977846174064955149290862569321978468622482" +
"83972241375657056057490261407972968652414535100474" +
"82166370484403199890008895243450658541227588666881" +
"16427171479924442928230863465674813919123162824586" +
"17866458359124566529476545682848912883142607690042" +
"24219022671055626321111109370544217506941658960408" +
"07198403850962455444362981230987879927244284909188" +
"84580156166097919133875499200524063689912560717606" +
"05886116467109405077541002256983155200055935729725" +
"71636269561882670428252483600823257530420752963450";
            #endregion
            int numProduct = 13;
            char[] numCharArrary = numStr.ToArray();
            long maxProduct = 0;
            for (int i = 0; i < numCharArrary.Length; i++)
            {
                // int num = int.Parse(numCharArrary[i].ToString());
                long product13 = 1;
                for (int j = 0; j < numProduct && (i + j) < numCharArrary.Length; j++)
                {
                    int curValue;
                    if (!int.TryParse(numCharArrary[i + j].ToString(), out curValue)) continue;

                    product13 *= curValue;
                }
                if (product13 > maxProduct)
                {
                    maxProduct = product13;
                }
            }

            return maxProduct;
        }


        public static int SpecialPythagoreanTriplet()
        {
            int result = 0;
            for (int a = 1; a < 334; a++)
            {
                for (int c = 334; c < 1000; c++)
                {
                    int b = 1000 - c - a;
                    if (a * a + b * b == c * c)
                    {
                        result = a * b * c;
                    }
                }
            }
            return result;
        }


        public static long SummationOfPrimes()
        {
            long total = 0;
            for (int i = 2; i <= 2000000; i++)
            {
                if (IsPrime(i))
                {
                    total += i;
                    // k++;  
                }
            }
            return total;
        }


        public static long LargestProductInGrid()
        {
            int[,] grid = new int[,]{
                          { 8,2,22,97,38,15,0,40,0,75,4,5,7,78,52,12,50,77,91,8},
                          { 49,49,99,40,17,81,18,57,60,87,17,40,98,43,69,48,4,56,62,0},
                          { 81,49,31,73,55,79,14,29,93,71,40,67,53,88,30,3,49,13,36,65},
                          { 52,70,95,23,4,60,11,42,69,24,68,56,1,32,56,71,37,2,36,91},
                          { 22,31,16,71,51,67,63,89,41,92,36,54,22,40,40,28,66,33,13,80},
                          { 24,47,32,60,99,3,45,2,44,75,33,53,78,36,84,20,35,17,12,50},
                          { 32,98,81,28,64,23,67,10,26,38,40,67,59,54,70,66,18,38,64,70},
                          { 67,26,20,68,2,62,12,20,95,63,94,39,63,8,40,91,66,49,94,21},
                          { 24,55,58,5,66,73,99,26,97,17,78,78,96,83,14,88,34,89,63,72},
                          { 21,36,23,9,75,0,76,44,20,45,35,14,0,61,33,97,34,31,33,95},
                          { 78,17,53,28,22,75,31,67,15,94,3,80,4,62,16,14,9,53,56,92},
                          { 16,39,5,42,96,35,31,47,55,58,88,24,0,17,54,24,36,29,85,57},
                          { 86,56,0,48,35,71,89,7,5,44,44,37,44,60,21,58,51,54,17,58},
                          { 19,80,81,68,5,94,47,69,28,73,92,13,86,52,17,77,4,89,55,40},
                          { 4,52,8,83,97,35,99,16,7,97,57,32,16,26,26,79,33,27,98,66},
                          { 88,36,68,87,57,62,20,72,3,46,33,67,46,55,12,32,63,93,53,69},
                          { 4,42,16,73,38,25,39,11,24,94,72,18,8,46,29,32,40,62,76,36},
                          { 20,69,36,41,72,30,23,88,34,62,99,69,82,67,59,85,74,4,36,16},
                          { 20,73,35,29,78,31,90,1,74,31,49,71,48,86,81,16,23,57,5,54},
                          { 1,70,54,71,83,51,54,69,16,92,33,48,61,43,52,1,89,19,67,48}};

            const int N = 20;
            int m = 0;
            for (int i = 0; i < 20 - 3; i++)
            {
                for (int j = 0; j < 20 - 3; j++)
                {
                    int h = grid[i, j] * grid[i, j + 1] * grid[i, j + 2] * grid[i, j + 3]; //行 
                    int v = grid[j, i] * grid[j + 1, i] * grid[j + 2, i] * grid[j + 3, i]; //列 
                    int d1 = grid[i, j] * grid[i + 1, j + 1] * grid[i + 2, j + 2] * grid[i + 3, j + 3]; //右下斜 
                    int d2 = grid[i, N - j - 1] * grid[i + 1, N - j - 2] * grid[i + 2, N - j - 3] * grid[i + 3, N - j - 4];//左下斜 

                    m = Max(m, Max(d2, Max(d1, Max(h, v))));
                }
            }
            return m;
        }

        public static int Max(int x, int y)
        {
            return x >= y ? x : y;
        }


        public static long DivisibleTriangularNumber()
        {
            const int factorNum = 500;
            int index = 1;
            while (true)
            {
                long triangularNum = GetTriangularNum(index);
                //1和数值本身就是2个了
                int count = 2;
                int sqrt = (int)Math.Floor(Math.Sqrt(triangularNum));

                for (int i = 2; i <= sqrt; i++)
                {
                    if (triangularNum % i == 0)
                    {
                        count += 2;
                    }
                }
                //如果平方数，则重复，需要-1
                if ((int)Math.Pow(sqrt, 2) == triangularNum) count -= 1;

                Console.WriteLine("Num:{0},count:{1}", triangularNum, count);
                if (count >= factorNum)
                {
                    return triangularNum;
                }
                index++;
            }
        }

        public static long GetTriangularNum(int n)
        {
            long sum = 0;
            for (int i = 0; i <= n; i++)
            {
                sum += i;
            }

            return sum;
        }

        public static long SumLargeNum()
        {

            string[] largeNums = new string[] {
                "37107287533902102798797998220837590246510135740250",
                "46376937677490009712648124896970078050417018260538",
                "74324986199524741059474233309513058123726617309629",
                "91942213363574161572522430563301811072406154908250",
                "23067588207539346171171980310421047513778063246676",
                "89261670696623633820136378418383684178734361726757",
                "28112879812849979408065481931592621691275889832738",
                "44274228917432520321923589422876796487670272189318",
                "47451445736001306439091167216856844588711603153276",
                "70386486105843025439939619828917593665686757934951",
                "62176457141856560629502157223196586755079324193331",
                "64906352462741904929101432445813822663347944758178",
                "92575867718337217661963751590579239728245598838407",
                "58203565325359399008402633568948830189458628227828",
                "80181199384826282014278194139940567587151170094390",
                "35398664372827112653829987240784473053190104293586",
                "86515506006295864861532075273371959191420517255829",
                "71693888707715466499115593487603532921714970056938",
                "54370070576826684624621495650076471787294438377604",
                "53282654108756828443191190634694037855217779295145",
                "36123272525000296071075082563815656710885258350721",
                "45876576172410976447339110607218265236877223636045",
                "17423706905851860660448207621209813287860733969412",
                "81142660418086830619328460811191061556940512689692",
                "51934325451728388641918047049293215058642563049483",
                "62467221648435076201727918039944693004732956340691",
                "15732444386908125794514089057706229429197107928209",
                "55037687525678773091862540744969844508330393682126",
                "18336384825330154686196124348767681297534375946515",
                "80386287592878490201521685554828717201219257766954",
                "78182833757993103614740356856449095527097864797581",
                "16726320100436897842553539920931837441497806860984",
                "48403098129077791799088218795327364475675590848030",
                "87086987551392711854517078544161852424320693150332",
                "59959406895756536782107074926966537676326235447210",
                "69793950679652694742597709739166693763042633987085",
                "41052684708299085211399427365734116182760315001271",
                "65378607361501080857009149939512557028198746004375",
                "35829035317434717326932123578154982629742552737307",
                "94953759765105305946966067683156574377167401875275",
                "88902802571733229619176668713819931811048770190271",
                "25267680276078003013678680992525463401061632866526",
                "36270218540497705585629946580636237993140746255962",
                "24074486908231174977792365466257246923322810917141",
                "91430288197103288597806669760892938638285025333403",
                "34413065578016127815921815005561868836468420090470",
                "23053081172816430487623791969842487255036638784583",
                "11487696932154902810424020138335124462181441773470",
                "63783299490636259666498587618221225225512486764533",
                "67720186971698544312419572409913959008952310058822",
                "95548255300263520781532296796249481641953868218774",
                "76085327132285723110424803456124867697064507995236",
                "37774242535411291684276865538926205024910326572967",
                "23701913275725675285653248258265463092207058596522",
                "29798860272258331913126375147341994889534765745501",
                "18495701454879288984856827726077713721403798879715",
                "38298203783031473527721580348144513491373226651381",
                "34829543829199918180278916522431027392251122869539",
                "40957953066405232632538044100059654939159879593635",
                "29746152185502371307642255121183693803580388584903",
                "41698116222072977186158236678424689157993532961922",
                "62467957194401269043877107275048102390895523597457",
                "23189706772547915061505504953922979530901129967519",
                "86188088225875314529584099251203829009407770775672",
                "11306739708304724483816533873502340845647058077308",
                "82959174767140363198008187129011875491310547126581",
                "97623331044818386269515456334926366572897563400500",
                "42846280183517070527831839425882145521227251250327",
                "55121603546981200581762165212827652751691296897789",
                "32238195734329339946437501907836945765883352399886",
                "75506164965184775180738168837861091527357929701337",
                "62177842752192623401942399639168044983993173312731",
                "32924185707147349566916674687634660915035914677504",
                "99518671430235219628894890102423325116913619626622",
                "73267460800591547471830798392868535206946944540724",
                "76841822524674417161514036427982273348055556214818",
                "97142617910342598647204516893989422179826088076852",
                "87783646182799346313767754307809363333018982642090",
                "10848802521674670883215120185883543223812876952786",
                "71329612474782464538636993009049310363619763878039",
                "62184073572399794223406235393808339651327408011116",
                "66627891981488087797941876876144230030984490851411",
                "60661826293682836764744779239180335110989069790714",
                "85786944089552990653640447425576083659976645795096",
                "66024396409905389607120198219976047599490197230297",
                "64913982680032973156037120041377903785566085089252",
                "16730939319872750275468906903707539413042652315011",
                "94809377245048795150954100921645863754710598436791",
                "78639167021187492431995700641917969777599028300699",
                "15368713711936614952811305876380278410754449733078",
                "40789923115535562561142322423255033685442488917353",
                "44889911501440648020369068063960672322193204149535",
                "41503128880339536053299340368006977710650566631954",
                "81234880673210146739058568557934581403627822703280",
                "82616570773948327592232845941706525094512325230608",
                "22918802058777319719839450180888072429661980811197",
                "77158542502016545090413245809786882778948721859617",
                "72107838435069186155435662884062257473692284509516",
                "20849603980134001723930671666823555245252804609722",
                "53503534226472524250874054075591789781264330331690"
            };

            long sum = 0; ;
            foreach (var num in largeNums)
            {
                //取前15位足够了,前10位最多收13位影响
                long subValue = long.Parse(num.Substring(0, 15));
                sum += subValue;
            }
            return sum;
        }

        public static long LongestCollatzSeq()
        {
            int numMax = 1000000;
            long maxChainCount = 0;
            long theValue = 0;
            for (int i = 0; i <= numMax; i++)
            {
                long chainCount = 0;
                long curValue = i;
                while (true)
                {
                    if (curValue == 1)
                    {
                        chainCount++;
                        break;
                    }
                    if (curValue % 2 == 0)
                    {
                        if (IsPower(curValue))
                        {
                            chainCount += (int)Math.Log(2, curValue);
                            break;
                        }
                        else
                        {
                            curValue = curValue / 2;
                        }
                    }
                    else
                    {
                        curValue = 3 * curValue + 1;
                    }
                    chainCount++;
                }

                if (chainCount > maxChainCount)
                {
                    maxChainCount = chainCount;
                    theValue = i;
                    Console.WriteLine("num:{0},count:{1}", i, maxChainCount);
                }
            }

            return theValue;
        }
        /// <summary>
        /// 判断n是否为2的幂
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public static bool IsPower(long v)
        {
            if ((v & (v - 1)) == 0) return true;
            else return false;
        }

        public static long Pow1000()
        {
            const int num = 2;

            //2^1000的值太大了，不能直接计算

            //16598*2
            //465487984654313132154654855465420
            string curValue = 1.ToString();

            for (int i = 1; i <= 2000; i++)
            {
                //每一位计算
                bool addOne = false;
                string combineString = string.Empty;
                //2056
                for (int index = curValue.Length - 1; index >= 0; index--)
                {
                    int posNum = int.Parse(curValue[index].ToString()) * 2 + (addOne ? 1 : 0);
                    string posStr = posNum.ToString();
                    if (posNum >= 10)
                    {
                        addOne = true;
                        if (index > 0)
                        {
                            posStr = (posNum % 10).ToString();
                        }
                    }
                    else
                    {
                        addOne = false;
                    }
                    combineString = posStr + combineString;
                }
                curValue = combineString;
            }

            long total = 0;

            foreach (char temp in curValue)
            {
                total += long.Parse(temp.ToString());
            }

            return total;
        }

        public static long CountingSundays()
        {
            long count = 0;
            for (int year = 1901; year <= 2000; year++)
            {
                for (int month = 1; month <= 12; month++)
                {
                    DateTime dt = new DateTime(year, month, 1);
                    if (dt.DayOfWeek == DayOfWeek.Sunday)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public static int FactorialDigitSum()
        {
            string factor100 = LargeNumCalc.Factor(100);

            int sum = 0;
            for (int i = 0; i < factor100.Length; i++)
            {
                sum += int.Parse(factor100[i].ToString());
            }

            return sum;
        }

        public static int AmicableNumbers()
        {
            int sum = 0;
            for (int i = 2; i < 10000; i++)
            {
                if (IsAmicableNum(i))
                {
                    sum += i;
                }
            }

            return sum;
        }

        private static bool IsAmicableNum(int n)
        {
            if (n <= 2) return false;

            List<int> lstNumA = new List<int>();
            //
            for (int i = 1; i < n; i++)
            {
                if (n % i == 0 && !lstNumA.Contains(i))
                {
                    lstNumA.Add(i);
                }
            }

            var sumValue = lstNumA.Sum();
            if (sumValue == n) return false;
            List<int> lstNumB = new List<int>();
            for (int j = 1; j < sumValue; j++)
            {
                if (sumValue % j == 0 && !lstNumB.Contains(j))
                {
                    lstNumB.Add(j);
                }
            }
            var sumValueB = lstNumB.Sum();
            bool isAmicalble = sumValueB == n;
            return isAmicalble;
        }

        public static long NamesScores()
        {
            string letters = "0ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string filePath = @"Res\p022_names.txt";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException(filePath);
            }
            var nameList = File.ReadAllText(filePath).Replace("\"", "").Split(',').ToList();
            //sort
            nameList.Sort();

            long sum = 0;
            for (int index = 0; index < nameList.Count; index++)
            {
                string name = nameList[index];
                for (int i = 0; i < name.Length; i++)
                {
                    var pos = letters.IndexOf(name[i].ToString(), StringComparison.OrdinalIgnoreCase);
                    sum += pos * (index+1);
                }
            }
            return sum;
        }


    }


}