# REST API 

> This API is responsible for managing requests made by students at a higher education institution. It allows the registration, tracking, and management of requests, organizing them by types and statuses.

## Skills

<div style="display: flex; gap: 10px;">
  <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/Microsoft_SQL_Server-CC2927?style=for-the-badge&logo=microsoft-sql-server&logoColor=white"/>
</div>
<br>

<details>
  <summary>RequestType</summary>

## Get All RequestType

### Request

`GET /RequestType/GetAll/`

    [curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/RequestType/GetAll'

### Response   
   
    Status: 200 OK
    []

## Get RequestType by id

### Request

`GET /RequestType/1`

    [curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/RequestType/1'

### Response    
   
    Status: 200 OK         
    []

## Delete a RequestType

### Request

`DELETE /RequestType/0/`

    curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/RequestType/0   

### Response

    Status: 200 OK  

## Create a new RequestType

### Request

`POST /RequestType/`

    curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/RequestType
     {
       "description": "Description here..."
     }

### Response

    Status: 200 OK    

## Update a RequestType

### Request

`PUT /RequestType/`

    curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/RequestType
     {
       "id" : 1,
       "description": "Description here..."
     }

### Response

    Status: 200 OK    
 
</details>

<details>
  <summary>Solicitation</summary>
</details>  

<details>
  <summary>Status</summary>
</details>  

<details>
  <summary>StudentCenterBase</summary>

  ## Get All StudentCenterBase

### Request

`GET /StudentCenterBase/`

    [curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/StudentCenterBase'

### Response   
   
    Status: 200 OK
    []

## Delete a StudentCenterBase

### Request

`DELETE /StudentCenterBase/0/`

    curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/StudentCenterBase/0   

### Response

    Status: 200 OK  

## Create a new StudentCenterBase

### Request

`POST /StudentCenterBase/`

    curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/StudentCenterBase
     {
       "description": "Description here...",
       "page":"Description of page here..."
     }

### Response

    Status: 200 OK    

## Update a StudentCenterBase

### Request

`PUT /StudentCenterBase/`

    curl -i -H 'Accept: application/json' https://localhost:9999/api/v1/StudentCenterBase
     {
       "id" : 1,
       "description": "Description here...",
       "page":"Description of page here..."
     }

### Response

    Status: 200 OK   
    
</details>




