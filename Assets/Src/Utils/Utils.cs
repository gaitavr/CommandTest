using Random = System.Random;
using System.Collections.Generic;

namespace Company.Project.Utils
{
    public static class Utils
    {
        public static void Shuffle<T>(this List<T> list)
        {
            var random = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                var randomIndex = i;
                while (randomIndex == i)
                {
                    randomIndex = random.Next(0, list.Count);
                }
                var temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
    }
}
