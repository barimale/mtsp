# Design
![Architecture concept for design.png](./design.jpg)

## Prereqs:
- .NET 6.0 SDK

# Architectural challenges
```
- Use saga redux and implement event sourcing and cqrs at the backend and make it async with UI,
- microservices solution:
-- workflows engine as a separate service having its own database + save request and response in db,
-- route server on premise + custom routes registration service(* - optional),
-- map server on premise,
-- lease service for postcenter registration, publishing lease requests with its own db,
- Mobile app(expo framework) for salesman:
-- Route for Today,
-- Notification about being relocated/leased to another postcenter,
-- Tracker worker for route server (in case there is more optimal/comfortable way then already calculated)
- Main App UI:
-- wizard-form fully customizable by using react dynamic grid layout npm package,
-- steps avalaible depending on the user - type,
-- External Data Source and Mapping, Salespersons and Regions only by Manager and SuperAdmin, Custom Workflows also,
-- Some steps visible in conditional way,
-- maybe Stats step  
-- for salesperson read-only access only,
-- possibility to download mobile app from the main app.
- solution fully dockerized to have nice developer environment + Azure Devops + UAT.
- Log Server, Map Server, Route Server, Delivery Server, Main Server: PostCenterRegistration,LeaseWorkersService, Workflow service,
- builders for the rest of domain definitions,
- put them to factory, 
```

# Main Algorithm approaches:
- OR.Tools linear constraint programming,
- HCALS TSP,
- REST API to quantum computing equivalent of the solution A or B(Qiskit Quantum TSP).

# Some optional features for the next stage:
- fuel eco contraint,
- delivery by car/scrooter/motorcycle.

# Packages to use and some ideas:
```
- react dynamic grid layout + table for custom user configuration,
- linqtodb nuget,
- slapper.automapper nuget,
- .net core workflow for automatization background tasks + document-based db for configuration / or by using fluent AP
- table for tunned params in the context of specific postperson (*- optional)
```

# Scenario
- [STEP A] Provide list of postpersons,
- [STEP B] Provide main spot together with places which have to be visited (raw json only),
- [STEP C] Provide some assumptions like: maximal limit of hours per route - optional,
- [STEP D] Display them on map as a form of review,
- [STEP D -> STEP E] Send data to backend to calculate subroutes per postperson,
- [STEP E] Display result on map.
- [STEP F] Send result via email - optional

# Improvements
- Maximal weight of backpack,
- Typical time per building spending for maintenance,
- Field with summarized break per shift - maximal limit of hours per route is going to be reduced by that value
- Investigate: private map server with private route service:
-- possibility to define custom routes to optimize route later on.
- postperson amount advisor - suggest how many postpersons should maintain the route in optimal way based on historical data.
