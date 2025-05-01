namespace ValueTaskConsole;

public class CarState
{
    private string? m_Make;

    public ValueTask<string> GetMakeAsync()
    {
        if (m_Make is null)
            return new ValueTask<string>(LoadAsync());

        return new ValueTask<string>(m_Make);

    }

    private async Task<string> LoadAsync()
    {
        await Task.Delay(50);
        m_Make = "Mazda";
        return m_Make;
    }
}

