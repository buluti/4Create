# 4Create Api Srevice Test Project
[TOC]
## Employee

#### Create
```js
POST /api/employees 
```

#### Create Request

```json
{
    "email":"1@test.com",    
    "title":"developer",
    "companies": [
        "d9f84dc0-aa0a-4bdf-bb3f-5204d616afcb",
        "b39d1385-6dff-4f0c-a1aa-efd7581f7bc8", 
        "57593814-0e15-4d63-8957-9bf883f65547", 
        "e8df3567-2f41-4239-8f20-8382b1d271b6"]
}
```

#### Create Response

```js
200 OK
```

```json
{
    "id":"2acbcc1f-fac7-4bad-a5ab-0738b2941e32",
    "title":"developer",
    "email":"1@test.com",
    "created_at":"11/01/2023 16:32:52"
}
```

## Company
#### Create
```js
POST /api/companies
```

#### Create Request

```json
{
    "companyName":"top string ltd",
    "employees":[
        {"email":"new_employee@test.com", "title": 0},
        {"id":"d9f84dc0-aa0a-4bdf-bb3f-5204d616afcb"},
        {"id":"11382325-fa93-4fc7-8b4b-6a2d94c58e57"}
        ]
}
```

#### Create Response

```json
{
    "id":"d9f84dc0-aa0a-4bdf-bb3f-5204d616afcb",
    "name":"Company name ltd.",
    "created_at":"11/01/2023 16:32:52"
}
```