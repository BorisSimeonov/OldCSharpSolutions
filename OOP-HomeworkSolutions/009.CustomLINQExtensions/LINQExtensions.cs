using System;
using System.Linq;
using System.Collections.Generic;

public static class LINQExtensions
{
    public static IEnumerable<TSource> WhereNot<TSource>(
        this IEnumerable<TSource> source, Func<TSource, bool> predicate)
    {
        foreach (var indexedItem in source)
        {
            if (!predicate(indexedItem))
            {
                yield return indexedItem;
            }
        }
    }

    public static TSelector MaxValue<TSource, TSelector>(
        this IEnumerable<TSource> source, Func<TSource, TSelector> function)
        where TSelector : IComparable<TSelector>
    {
        var minHolder = function(source.First());
        foreach (var item in source.Where(item => 
        minHolder.CompareTo(function(item)) == -1))
        {
            minHolder = function(item);
        }
        return minHolder;
    }

    public static TSelector MinValue<TSource, TSelector>(
       this IEnumerable<TSource> source, Func<TSource, TSelector> function)
       where TSelector : IComparable<TSelector>
    {
        var minHolder = function(source.First());
        foreach (var item in source.Where(item =>
        minHolder.CompareTo(function(item)) > 0))
        {
            minHolder = function(item);
        }
        return minHolder;
    }
}