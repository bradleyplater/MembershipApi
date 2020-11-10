<h1 align="center">Welcome to Membership Api  👋</h1>
![.NET Core](https://github.com/bradleyplater/MembershipApi/workflows/.NET%20Core/badge.svg)

### 🏠 [Homepage](https://github.com/bradleyplater/MembershipApi)

## Pre-Requisites
In order to run this Api you need the following installed on your machine - 

### To Run from Docker(Recommended) - 
Docker
Postman (Any Application which can make called to an Api)

### To Run from Machine(Not recommended) 
.Net core 3.1 SDK
MongoDb
An understanding on how to connecting to a local MongoDb and setting up the tests accordingly


## Install 
To install the application run the following command - 
```sh
docker-compose /f ./docker-compose-local.yml up --build
```

## Usage
To use the api run the following endpoints in Postman - 
### Get Balance
```sh
GET - http://localhost:9000/api/accounts/{UserId}/balance
```

### Create Account
```sh
POST - http://localhost:9000/api/accounts
BODY - {
    "Name" : "Bradley"
}
```
### TopUp Account
```sh
PATCH - http://localhost:9000/api/accounts/{UserId}
BODY - {
    "Amount" : 11.22
}
```
### Purchase Item Account
```sh
PATCH - http://localhost:9000/api/accounts/{UserId}
BODY - {
    "Amount" : 11.22
}
```
#### Menu
```sh
ITEMS - {
    "Orange" : 1.25,
    "Tea" : 0.99
}
```


## Run tests
The tests are automatically run whne spun up into the Docker container

To manually run the tests however this will require connecting to a local Mongo instance -
```sh
dotnet test
```

## Author

👤 **Bradley Plater **

* Github: [@bradleyplater](https://github.com/bradleyplater)

## Show your support

Give a ⭐️ if this project helped you!
