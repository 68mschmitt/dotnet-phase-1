@startuml
skinparam linetype ortho
skinparam componentStyle rectangle

actor "Client" as C

rectangle "ASP.NET Controller" as Controller {
    [Http Endpoint]
}

rectangle "MediatR" as Mediator {
    [IMediator.Send()]
}

package "Requests" {
    [GetAllProductsQuery]
}

package "Handlers" {
    [GetAllProductsHandler]
}

package "Infrastructure" {
    [IProductRepository]
    [EF Core / In-Memory DB]
}

C --> Controller : HTTP GET /products
Controller --> Mediator : Send(GetAllProductsQuery)
Mediator --> GetAllProductsHandler : Dispatch
GetAllProductsHandler --> IProductRepository : GetAllAsync()
IProductRepository --> [EF Core / In-Memory DB] : Query products
[EF Core / In-Memory DB] --> IProductRepository : Product List
IProductRepository --> GetAllProductsHandler : Product List
GetAllProductsHandler --> Mediator : Product List
Mediator --> Controller : Return Result
Controller --> C : HTTP 200 OK + JSON

@enduml

