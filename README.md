# GraphQL-Mongo
## POC for graphql with dotnet core and mongodb
## Query
![image](https://user-images.githubusercontent.com/26926642/161582751-f72f0719-3430-4eeb-a433-452bdebc2435.png)

## Mutation
![image](https://user-images.githubusercontent.com/26926642/161669120-a8657c3e-7af6-401a-82a3-31159d7cd834.png)
## Prequisite to run the project
dotnet core(version 3.2) and mongodb should be install on machine

## Steps to run 
1) create database with name "dotnetgraphql"
2) dotnet-cli dotnet run 
   or 
  visual studio 
3) open application url "https://localhost:44322/graphql/" for "Banana cake Pop" 
4) Currently 2 graphql operation are there 
      # 1) Query - use to fetch/read data from server
          query{
              GetWeather {
              id,
              temperatureC,
              date
              }
            }
            
            

      # 2) Mutation - use to insert/update/delete data on server
        
        mutation{
                CreateWeather(weatherInput:{
                  temperatureC:45,
                  summary:"Hot",
                  date:"12/12/12"
                }),
                {
                  id
                  temperatureC
                }
            }
        
        

 
