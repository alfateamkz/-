namespace Alfateam.CRM2_0.Extensions
{
    public static class SortedSetExtensions 
    {
        public static void AddRange<T>(this SortedSet<T> set,IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                set.Add(item);
            }
        }
    }
}
