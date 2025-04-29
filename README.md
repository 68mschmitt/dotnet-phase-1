# 📘 Phase 1: C#/.NET Advanced Reinforcement Plan

This learning plan is designed to reinforce existing knowledge and fill identified conceptual and practical gaps in .NET and C#.  
The plan is organized into 3 focus areas: **Async & Memory Performance**, **Architectural Patterns**, and **Domain-Driven Design**.

---

## 🔷 Focus Area 1: Async Programming & Memory Performance

**Goal:** Improve understanding and application of async programming internals and high-performance memory handling.

### 🔑 Key Concepts to Learn
- `Span<T>` and `Memory<T>` for stack-allocated, non-allocating operations
- `ValueTask` and how it compares to `Task`
- `CancellationTokenSource` and advanced token usage
- `Lazy<T>` for deferred initialization
- `ConfigureAwait(false)` and sync context behavior

### ✅ Hands-On Tasks
- [x] Write a method that parses and transforms a byte array using `Span<byte>` with no allocations
- [ ] Create a cancellable async method using `CancellationToken` and `CancellationTokenSource`
- [ ] Refactor an async method to avoid context capture using `ConfigureAwait(false)`
- [ ] Use `Lazy<T>` to defer initialization of an expensive resource
- [ ] Explore scenarios where `ValueTask` offers performance benefits

### 📚 Learning Resources
- 🔗 [Microsoft Docs: Span<T>](https://learn.microsoft.com/en-us/dotnet/api/system.span-1)
- 🔗 [Async/Await Best Practices](https://devblogs.microsoft.com/dotnet/configureawait-faq/)
- 🔗 [ValueTask explained](https://learn.microsoft.com/en-us/dotnet/standard/asynchronous-programming-patterns/valuetask-type)
- 🔗 [Cancellation in .NET](https://learn.microsoft.com/en-us/dotnet/standard/threading/cancellation-in-managed-threads)
- 🔗 [High-performance C# with Span and Memory](https://devblogs.microsoft.com/dotnet/understanding-span-t/)

---

## 🟡 Focus Area 2: Architectural Patterns & Clean Design

**Goal:** Formalize knowledge of common patterns and improve system modularity and testability.

### 🔑 Key Concepts to Learn
- Repository Pattern (for separation of persistence)
- CQRS (Command Query Responsibility Segregation)
- MediatR (simplified in-process messaging)
- SOLID principles (focus on Open/Closed, SRP)
- Clean Architecture layering

### ✅ Hands-On Tasks
- [ ] Build a small ASP.NET Core app using MediatR and CQRS
- [ ] Implement an `IRepository<T>` abstraction and swap in-memory vs database implementations
- [ ] Apply Open/Closed Principle to a class that uses a strategy pattern
- [ ] Write unit tests for a command handler using MediatR + mocking dependencies

### 📚 Learning Resources
- 🔗 [MediatR GitHub](https://github.com/jbogard/MediatR)
- 🔗 [Clean Architecture in .NET](https://github.com/jasontaylordev/CleanArchitecture)
- 🔗 [SOLID Principles (Microsoft)](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/common-web-application-architectures#solid-principles)
- 🔗 [Repository Pattern in .NET](https://deviq.com/design-patterns/repository-pattern)

---

## 🔶 Focus Area 3: Domain-Driven Design & System Thinking

**Goal:** Understand DDD principles and how they apply to scalable service boundaries and system modeling.

### 🔑 Key Concepts to Learn
- Bounded Contexts and context mapping
- Aggregates and transactional consistency
- Value Objects vs Entities
- Domain Events
- CQRS in domain separation

### ✅ Hands-On Tasks
- [ ] Define a bounded context diagram for a domain you know (e.g., car wash, metrics tool)
- [ ] Implement value objects (e.g., `Email`, `Money`, `Coordinates`) in C#
- [ ] Use domain events and handlers in a modular service design
- [ ] Break an existing CRUD service into a CQRS-style pattern

### 📚 Learning Resources
- 🔗 [DDD Reference by Eric Evans (Free summary)](https://domainlanguage.com/ddd/reference/)
- 🔗 [Microsoft’s DDD Guide](https://learn.microsoft.com/en-us/dotnet/architecture/modern-web-apps-azure/architectural-principles#domain-driven-design)
- 🔗 [DDD & Bounded Contexts (Martin Fowler)](https://martinfowler.com/bliki/BoundedContext.html)
- 🔗 [CQRS + DDD in Practice](https://docs.microsoft.com/en-us/azure/architecture/patterns/cqrs)

---

## 📆 Recommended Weekly Flow (Flexible)

| Day | Activity |
|-----|----------|
| Mon | Read 1–2 articles or docs from a single focus area |
| Tue | Code hands-on task (small 30–60 min prototype) |
| Wed | Review concept, reimplement from memory |
| Thu | Study cross-topic link (e.g., how async + DI work together) |
| Fri | Summarize key takeaways in a journal or blog |
| Weekend | Optional: Refactor something old using new concepts |

---

> 🧭 **Track Progress:** Use checkboxes above. Aim for 4–6 weeks for Phase 1, then reassess strengths and shift to Phase 2 (e.g., observability, performance tuning, distributed systems).

