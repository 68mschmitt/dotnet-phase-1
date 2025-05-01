using BenchmarkDotNet.Attributes;

namespace ValueTaskConsole;

[MemoryDiagnoser]
public class CarStateBenchmarks
{
    private readonly CarState_ValueTask _carValueTask = new();
    private readonly CarState_Task _carTask = new();

    [GlobalSetup]
    public async Task WarmUp()
    {
        // Warm cache for cached benchmarks
        await _carValueTask.GetMakeAsync();
        await _carTask.GetMakeAsync();
    }

    [Benchmark]
    public async Task<string> ValueTask_Cached()
    {
        return await _carValueTask.GetMakeAsync();
    }

    [Benchmark]
    public async Task<string> ValueTask_Cold()
    {
        var car = new CarState_ValueTask(); // force new instance
        return await car.GetMakeAsync();
    }

    [Benchmark]
    public async Task<string> Task_Cached()
    {
        return await _carTask.GetMakeAsync();
    }

    [Benchmark]
    public async Task<string> Task_Cold()
    {
        var car = new CarState_Task(); // force new instance
        return await car.GetMakeAsync();
    }
}

public class CarState_ValueTask
{
    private string? _make;

    public ValueTask<string> GetMakeAsync()
    {
        if (_make is not null)
            return new ValueTask<string>(_make);

        return new ValueTask<string>(LoadAsync());
    }

    private async Task<string> LoadAsync()
    {
        await Task.Delay(10);
        _make = "Mazda";
        return _make;
    }
}

public class CarState_Task
{
    private string? _make;

    public Task<string> GetMakeAsync()
    {
        if (_make is not null)
            return Task.FromResult(_make);

        return LoadAsync();
    }

    private async Task<string> LoadAsync()
    {
        await Task.Delay(10);
        _make = "Mazda";
        return _make;
    }
}

