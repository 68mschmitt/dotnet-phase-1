# Notes

Span<T> is a ref struct that is allocated on the stack rather than the managed heap

There are a number of restrictions to ensure that it will not be promoted to the heap

It cannot be boxed. What does "boxed" mean?
- Boxing is when a value type is promoted to the managed heap
- It happens by implicitly wrapping a value type in an object (reference type)
- boxing is implicit, unboxing is explicit

They cannot be used across await and yield boundaries


A Span<T> represents a contiguout region of arbitrary memory.
They are often used to hold elements of an array or a portion of an array
Unlike an array, it can point to managed memory, native memory, or memory managed on the stack.

Looks like the stack imlementation, using the stackalloc, run much faster than the managed heap version

This is confirmed with the stopwatch times

stackalloc is used in place of the new keyword to allocate memory on the stack instead of the heap
it can only be used with a span or readonlyspan

It is best practice to set a limit to the buffer size when allocating stack memory, since it is limited
If you allocate more memory than the stack has available, then a stack overflow exception will be thrown
Examle of limiting the buffer size
int length = 1000;
Span<byte> buffer = length <= 1024 ? stackalloc byte[length] : new byte[length];
