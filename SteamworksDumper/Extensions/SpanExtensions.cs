using System.Runtime.InteropServices;
using System.Text;

namespace SteamworksDumper.Extensions;

public static class SpanExtensions
{
    public static Span<TTarget> As<TSource, TTarget>(this Span<TSource> source) where TSource : struct where TTarget : struct
        => MemoryMarshal.Cast<TSource, TTarget>(source);

    public static TTarget Read<TSource, TTarget>(this Span<TSource> source) where TSource : struct where TTarget : struct
        => source.As<TSource, TTarget>()[0];
    
    public static bool ContainsSequence<TSource>(this Span<TSource> source, ReadOnlySpan<TSource> sequence) where TSource : struct, IEquatable<TSource>
        => source.IndexOf(sequence) >= 0;

    public static string ReadString(this Span<byte> source)
        => Encoding.UTF8.GetString(source[..source.IndexOf(byte.MinValue)]);
}