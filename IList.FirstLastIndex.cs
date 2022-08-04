// A part of the C# Language Syntactic Sugar suite.

using System;
using System.Collections.Generic;

namespace CLSS
{
  public static partial class IListFirstLastIndex
  {
    /// <summary>
    /// Returns the index of the first element in a sequence that satisfies a
    /// specified condition.
    /// </summary>
    /// <typeparam name="TSource">The type of the elements of
    /// <paramref name="source"/>.</typeparam>
    /// <param name="source">An <see cref="IEnumerable{T}"/> to return an
    /// element from.</param>
    /// <param name="predicate">A function to test each element for a condition.
    /// </param>
    /// <returns>The index of the first element that satisfies a specified
    /// condition.</returns>
    /// <exception cref="ArgumentNullException"><paramref name="source"/> or
    /// <paramref name="predicate"/> is null.</exception>
    /// <exception cref="InvalidOperationException">No element satisfies the condition in predicate.
    /// 
    /// -or-
    ///
    /// The source sequence is empty.</exception>
    public static int FirstIndex<TSource>(this IEnumerable<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (predicate == null) throw new ArgumentNullException("predicate");
      int index = 0;
      foreach (var e in source)
      {
        if (predicate(e)) return index;
        ++index;
      }
      throw new InvalidOperationException("Sequence contains no matching element");
    }

    /// <summary>
    /// Returns the index of the last element in a sequence that satisfies a
    /// specified condition.
    /// </summary>
    /// <typeparam name="TSource">
    /// <inheritdoc cref="FirstIndex{TSource}(IEnumerable{TSource}, Func{TSource, bool})"
    /// path="/typeparam[@name='TSource']"/></typeparam>
    /// <param name="source">An <see cref="IList{T}"/> to return an element
    /// from.</param>
    /// <param name="predicate">
    /// <inheritdoc cref="FirstIndex{TSource}(IEnumerable{TSource}, Func{TSource, bool})"
    /// path="/param[@name='predicate']"/></param>
    /// <returns>The index of the last element that satisfies a specified
    /// condition.</returns>
    /// <exception cref="ArgumentNullException">
    /// <inheritdoc cref="FirstIndex{TSource}(IEnumerable{TSource}, Func{TSource, bool})"
    /// path="/exception[@cref='ArgumentNullException']"/></exception>
    /// <exception cref="InvalidOperationException">
    /// <inheritdoc cref="FirstIndex{TSource}(IEnumerable{TSource}, Func{TSource, bool})"
    /// path="/exception[@cref='InvalidOperationException']"/></exception>
    public static int LastIndex<TSource>(this IList<TSource> source,
      Func<TSource, bool> predicate)
    {
      if (source == null) throw new ArgumentNullException("source");
      if (predicate == null) throw new ArgumentNullException("predicate");
      for (int i = source.Count - 1; i >= 0; --i)
      { if (predicate(source[i])) return i; }
      throw new InvalidOperationException("Sequence contains no matching element");
    }
  }
}