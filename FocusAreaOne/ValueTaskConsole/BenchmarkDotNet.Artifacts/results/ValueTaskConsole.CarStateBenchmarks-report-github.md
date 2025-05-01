```

BenchmarkDotNet v0.14.0, Windows 10 (10.0.19045.3930/22H2/2022Update)
AMD Ryzen 7 5800X, 1 CPU, 16 logical and 8 physical cores
.NET SDK 9.0.201
  [Host]     : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2
  DefaultJob : .NET 9.0.3 (9.0.325.11113), X64 RyuJIT AVX2


```
| Method           | Mean              | Error           | StdDev          | Median            | Gen0   | Allocated |
|----------------- |------------------:|----------------:|----------------:|------------------:|-------:|----------:|
| ValueTask_Cached |          9.536 ns |       0.1640 ns |       0.1280 ns |          9.517 ns | 0.0043 |      72 B |
| ValueTask_Cold   | 14,849,338.477 ns | 295,138.8422 ns | 383,763.8941 ns | 14,979,760.938 ns |      - |     478 B |
| Task_Cached      |         13.064 ns |       0.1462 ns |       0.1221 ns |         13.052 ns | 0.0086 |     144 B |
| Task_Cold        | 15,137,388.357 ns | 300,599.6666 ns | 459,047.4768 ns | 15,421,284.375 ns |      - |     467 B |
