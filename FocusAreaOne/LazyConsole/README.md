# Notes

Lazy<T> is used to specify an object initialization or process, but delay the actual initialization until the .value function is called on the object

This is useful for instances where we are using a configuration file and want to lazy load the data


# Better understanding
Lazy<T> is a C# type that lets you define how to initialize an object, but postpones that initialization until the first time it's actually needed
Specifically when the '.Value' property is called

This is useful for when initialization is expensive. (Reading a file, loading data, building a complex object)

A common use for this is loading a configuration file. The configuration data is read when needed and then it's cached for future use


# Advanced Concepts
Thread Safety
There are three thread safety modes that can be specified when using lazy.
1. ExecutionAndPublication
    - Safest option
    - Only one thread executes the factory and the others wait for the result
    - Once it's initialized, all threads use the same result
    - Analogy - Multiple workers want coffee, the first one to the pot brews it and the rest wait. When it's done, the waiting workers serve
                from the finished pot
2. PublicationOnly
    - Multiple threads can execute the factory simultaneously
    - Only one result is stored, the first to finish
    - The rest are discarded 
    - Analogy - Multiple workers go to serve themselves coffee, but there isn't a pot. So until there is a pot ready, anyone that wants a cup will
                start brewing a pot. When the first pot is ready, anyone actively brewing a pot will throw their pot away and get a cup from the
                finished pot. Potential for lots of waste
3. None
    - No thread safety at all
    - Two threads will execute the factory method at the same time or will cause a race condition
    - only use when you're certain only one thread will access it, or you're managing synchronization yourself

Comparison With Factory
1. Factory Pattern
    - Used to create a new instance of a complex object each time you need one
2. Lazy<T>
    - Used to create one instance of an object and cache it. Then re-use the cached instance anytime you need it afterwards

Alternatives
1. Manual initialization
2. Double-checking logic
3. Factory pattern with caching
4. Lazy initialization with ValueTask or Task<T>

Disposal
Lazy will not dispose of your object. So you need to dispose of it yourself.

# Teaching others
Analogy - Like writing the instructions for making coffee, but only brewing a pot when someone wants a cup (.Value is called)
In this case, once the coffee is brewed, it will not run out. Anyone can get a cup when they want it, since it is already brewed

When to not use - When DI containers are used or an object needs to be disposed

Value property behavior - Performs the initialization when first called, then returns the cached value when called any time after the first
