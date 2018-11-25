namespace StagesCycling.BLL.Converters
{
    using System.Collections.Generic;

    public static class Mapper
    {
        public static List<T> MapLists<T>(IEnumerable<T> sourceList)
        {
            var entities = new List<T>();

            foreach (var item in sourceList)
            {
                entities.Add(item);
            }

            return entities;
        }
    }
}
