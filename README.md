# OrderManagment
This is clean core architecture implimented in .net 6. 
Application is only depended on domain and not on the UI or Infrastructure

###### Steps to setup
- Publish the db **OrderManagment.SQL**
- Verify the db tables contain data if not run the loaddata script /OrderManagment.SQL/Scripts/LoadData.sql
- Set as Starup Project **OrderManagment.API**
- Run or publish to interact with swagger

## Project Include
- Product module
- Order module
- Dapper Repository
- Unit tests
- Clean core architecture
- swagger
- docker
- Exception handling
- Automapper
- API models
- Dapper query models
- SQL database setup script

## Pending items
> Customer module,
> Billing module,
> Integration tests.
