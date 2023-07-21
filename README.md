# order-management-rest-api

This is an order management REST API

## Database setup

    docker pull mcr.microsoft.com/mssql/server
    
    docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=yourStrongPassword!2" -p 1433:1433 -d mcr.microsoft.com/mssql/server:latest

## Run the application

    dotnet run
    
## Insomnia collection

    Insomnia_order_management.json at the repository root folder

# REST API

The REST API to the order management is described below.


## Customer registration

### Request

`POST /api/auth/register`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/auth/register

    {
      "username": "jamilson_junior",
      "email": "jamilson@junior.com",
      "password": "dVV@Vp1OH7Xzyr"
    }

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

    {
      "status": "Success",
      "message": "User created successfully!"
    }

## Customer authentication

### Request

`POST /api/auth/login`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/auth/login

    {
      "username": "jamilson_junior",
      "password": "dVV@Vp1OH7Xzyr"
    }

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

    {
      "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9....",
      "expiration": "2023-07-21T04:27:49Z"
    }

## List of Products

### Request

`GET /api/product`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/product

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

    [
      {
        "id": 1,
        "name": "Apple Iphone 12",
        "price": 200.00
      },
      {
        "id": 2,
        "name": "Samsung S22",
        "price": 300.00
      }
    ]


## Product details

### Request

`GET /api/product/2`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/product/2

### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

    {
      "id": 2,
      "name": "Samsung S22",
      "price": 300.00
    }

## Create new order

### Request

`POST /api/order`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/order
      -H "Authorization: Bearer {token}"
      
    {
      "productId": 2,
      "quantityOfProducts": 2
    }

### Response

    HTTP/1.1 201 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

## List of Orders

### Request

`GET /api/order`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/order
      -H "Authorization: Bearer {token}"
      
### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

    [
      {
        "id": 7,
        "customerId": 2,
        "productId": 1,
        "quantityOfProducts": 2,
        "totalCost": 400.00
      },
      {
        "id": 8,
        "customerId": 2,
        "productId": 2,
        "quantityOfProducts": 2,
        "totalCost": 600.00
      },
    ]


## Order details

### Request

`GET /api/order/2`

    curl -i -H 'Accept: application/json' https://localhost:7108/api/order/2
      -H "Authorization: Bearer {token}"
      
### Response

    HTTP/1.1 200 OK
    Date: Thu, 24 Feb 2011 12:36:30 GMT
    Status: 200 OK
    Connection: close
    Content-Type: application/json
    Content-Length: 2

    {
      "id": 10,
      "customerId": 2,
      "productId": 2,
      "quantityOfProducts": 2,
      "totalCost": 600.00
    }

