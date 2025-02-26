namespace Examples
{
    internal class SlidingWindow
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }

        #region Пример 1. Дан массив положительных целых чисел nums и целое число k. Найдите длину самого длинного подмассива, сумма элементов которого меньше или равна k. Это задача, о которой мы говорили выше. Теперь мы решим её формально.
        // Учитывая, что подмассив начинается с left и заканчивается на right, его длина составляет right - left + 1. Как упоминалось ранее, временная сложность этого алгоритма составляет O(n), поскольку вся работа, выполняемая внутри цикла for, амортизируется O(1), где n — длина nums. Пространственная сложность постоянна, поскольку мы используем только 3 целочисленные переменные.


        public static int findLength(int[] nums, int k)
        {
            int left = 0;
            int curr = 0; // curr is the current sum of the window
            int ans = 0;

            for (int right = 0; right < nums.Length; right++)
            {
                curr += nums[right];
                while (curr > k)
                {
                    curr -= nums[left];
                    left++;
                }

                ans = Math.Max(ans, right - left + 1);
            }

            return ans;
        }
        #endregion

        #region Пример 2. Вам дана двоичная строка s (строка, содержащая только "0" и "1"). Вы можете выбрать до одного "0" и заменить его на "1". Какова длина самой длинной достижимой подстроки, содержащей только "1"?
        // Например, если дана строка s = "1101100111", то ответом будет 5. Если выполнить переворот по индексу 2, то строка станет 1111100111.
        // Как и в предыдущем примере, эта задача решается за O(n) времени, где n — длина s, так как работа, выполняемая на каждой итерации цикла, амортизируется константой. Также используется лишь несколько целочисленных переменных, что означает, что этот алгоритм использует O(1) памяти.

        public static int findLength(String s)
        {
            // curr is the current number of zeros in the window
            int left = 0, curr = 0, ans = 0;

            for (int right = 0; right < s.Length; right++)
            {
                if (s[right] == '0') curr++;

                while (curr > 1)
                {
                    if (s[left] == '0') curr--;

                    left++;
                }

                ans = Math.Max(ans, right - left + 1);
            }

            return ans;
        }


        #endregion

        #region Пример 3: Произведение подмассивов меньше K. Дан массив положительных целых чисел nums и целое число k. Верните количество подмассивов, в которых произведение всех элементов подмассива строго меньше k.
        // Например, при вводе nums = [10, 5, 2, 6], k = 100 ответом будет 8. Подмассивы с произведением меньше k:
        // [10], [5], [2], [6], [10, 5], [5, 2], [2, 6], [5, 2, 6]

        // Опять же, работа, выполняемая на каждой итерации цикла, амортизируется, поэтому время выполнения этого алгоритма составляет O(n), где n — длина nums, а пространство — O(1).

        public static int numSubarrayProductLessThanK(int[] nums, int k)
        {
            if (k <= 1) return 0;

            int ans = 0, left = 0, curr = 1;

            for (int right = 0; right < nums.Length; right++)
            {
                curr *= nums[right];
                while (curr >= k)
                    curr /= nums[left++];

                ans += right - left + 1;
            }

            return ans;
        }

        #endregion

        #region Пример 4. Дан целочисленный массив nums и целое число k. Найдите сумму подмассива с наибольшей суммой, длина которого равна k.
        // Общее количество итераций цикла for равно n, где n — длина nums, а работа, выполняемая на каждой итерации, постоянна, что даёт этому алгоритму временную сложность O(n) при использовании памяти O(1).


        public static int findBestSubarray(int[] nums, int k)
        {
            int curr = 0;
            for (int i = 0; i < k; i++) curr += nums[i];

            int ans = curr;
            for (int i = k; i < nums.Length; i++)
            {
                curr += nums[i] - nums[i - k];
                ans = Math.Max(ans, curr);
            }

            return ans;
        }

        #endregion
    }
}
