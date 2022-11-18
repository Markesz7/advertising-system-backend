namespace AdvertisingSystem.Dal.Helper
{
    // Stackoverflow: 1474863
    public static class CollectionHelpers
    {
        public static void AddRange<T>(this ICollection<T> dest, IEnumerable<T> source)
        {
            if(dest is List<T> list)
            {
                list.AddRange(source);
            }
            else
            {
                foreach (T item in source)
                {
                    dest.Add(item);
                }
            }
        }
    }
}
