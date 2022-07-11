# OrderManagment
This is clean core architecture implimented in .net 6 
Application is only depended on domain and not on the UI or Infrastructure

###### Steps to setup
- Publish the db **OrderManagment.SQL**
- Verify the db tables contain data if not run the loaddata script /OrderManagment.SQL/Scripts/LoadData.sql
- Set as Starup Project **OrderManagment.API**
- Run or publish to interact with swagger

## Project Include
- SQL database setup script
- Product module
- Order module
- Dapper Repository
- Clean core architecture
- swagger
- docker
- Exception handling
- Automapper
- API models
- Dapper query models

## Pending items
> Customer module
> Billing module
> Unit tests
> Integration tests
