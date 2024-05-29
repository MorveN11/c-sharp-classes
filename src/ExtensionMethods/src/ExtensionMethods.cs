public static class ExtensionMethods
{
    public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
    {
        foreach (var item in collection)
        {
            if (predicate(item))
            {
                yield return item;
            }
        }
    }

    public static IEnumerable<TResult> Map<T, TResult>(
        this IEnumerable<T> collection,
        Func<T, TResult> selector
    )
    {
        foreach (var item in collection)
        {
            yield return selector(item);
        }
    }

    public static TResult Reduce<T, TResult>(
        this IEnumerable<T> collection,
        Func<TResult, T, TResult> reducer,
        TResult initial
    )
    {
        var result = initial;

        foreach (var item in collection)
        {
            result = reducer(result, item);
        }

        return result;
    }
}
