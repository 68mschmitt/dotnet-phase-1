# Notes

CancellationToken and CancellationTokenSource

What is the difference and how do I use them?

CancellationToken
This is the message that we check to see if there is a cancellation request

CancellationTokenSource
This is initialized in the 'caller' to the task

What does this look like?

void FunctionCaller()
{
    var tokenSource = new CancellationTokenSource();
    Task.Run(() => FunctionTaskToCancel(tokenSource.Token));
}
