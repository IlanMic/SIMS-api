# SIMS-API Documentation

##### Learn how to use the API and its resource to keep track of the use of open data in Sweden. This API is provided by DIGG and the group 7 of the SIMS project from the Mittuniversitetet.
###### This document describes the resources that are part of the SIMS api.


## Schema

The API can be accessed via HTTPS from `https://localhost:7076/swagger/index.html`. All data is transferred as JSON format.

Instead of omitting blank attributes, they are included as blank.

## HTTP verbs

This API use HTTP verbs for each action in order to be considered a REST API. 

| HTTP Verb |         Description         |
|-----------|-----------------------------|
| `GET`     | Used for obtaining resources|
| `POST`    | Used for creating resources |
| `PUT`     | Used for updating resources |
| `DELETE`  | Used for removing resources |

Currently, only three of those HTTP verbs can be used: `GET`, `PUT`and `POST`.
Concerning the `DELETE`method, it is under development and this feature will be added soon.

A user can now:
* Get all resources
* Get a resource by its identifier
* Post a resource
* Update a resource

Additionally, an user will be able to:
* Delete a resource

## Resources

To this version of the API, ten different resources are available to access. Accessing the base url, `https://localhost:7076/api/`, followed by the endpoint in your web browser will get you all instances of the resource you are looking for. 

The resources of the API are the following ones:

| Resource | Endpoint | Description |
|----------|----------|-------------|
| __Data Format__ | _dataformats_ | Represents the format of a file (CSV, JSON or HTML, etc for example) |
| __Data Language__ | _datalanguages_ | Represents the language of a file (English or Swedish for instance) |
| __Data Owner__ | _dataowners_ | Represents the data provider of an open data file |
| __Data Theme__ | _datathemes_ | Represents the theme of an open data subject (transports, energy or health for example ) |
|  __Data Usage__ | _datausages_ | Represents how the data has been used (downloaded or not, the date of usage, the user if known, ...) |
| __Open Data__ | _opendatum_ | Represents the used data with the access url. It can be accessed in different way but that will be for the data usage resource. |
| __Update Frequency__ | _updatefrequencies_ | Represents the regularity in which a file is updated |



## Usage of the resources

This section will contain a guide to use these resources. As an example, we will use the resource _datalanguages_.

### GET

###### In this case, all languages will be returned in the response body.

* Curl:
``` 
    curl -X 'GET' \
    'https://localhost:7076/api/datalanguages' \
        -H 'accept: text/plain' 
```
* Request URL:
```
https://localhost:7076/api/datalanguages
``` 
* Response:
```
StatusCode: 200
      Content-Type: application/json; charset=utf-8
      Date: Mon, 10 Oct 2022 09:33:10 GMT
      Server: Kestrel
```

* Response body: 
```
[
  {
    "idDataLanguage": 1,
    "dataLanguageName": "Svenska"
  },
  {
    "idDataLanguage": 2,
    "dataLanguageName": "English"
  },
  {
    "idDataLanguage": 3,
    "dataLanguageName": "Deutsch"
  },
  {
    "idDataLanguage": 4,
    "dataLanguageName": "French"
  }
]
```


### GETByID

###### In this case, only the second language will be returned in the response body.

* Curl:
``` 
curl -X 'GET' \
  'https://localhost:7076/api/datalanguages/2' \
  -H 'accept: text/plain'
```
* Request URL:
```
https://localhost:7076/api/datalanguages/2
```
* Response:
```
StatusCode: 200
      Content-Type: application/json; charset=utf-8
      Date: Mon, 10 Oct 2022 09:43:24 GMT
      Server: Kestrel
```

* Response body: 
```
{
  "idDataLanguage": 2,
  "dataLanguageName": "English"
}
```


### POST

###### In this case, we will create a resource 'datalanguage' for the language 'Dutch'.


* Curl:
```
curl -X 'POST' \
  'https://localhost:7076/api/datalanguages' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "idDataLanguage": 0,
  "dataLanguageName": "Dutch"
}'
```

* Request URL:
``` 
https://localhost:7076/api/datalanguages
```
* Response:
```
StatusCode: 200
      Content-Type: application/json; charset=utf-8
      Date: Mon, 10 Oct 2022 09:47:54 GMT
      Server: Kestrel
```

* Response body: 
```
201
```

### PUT

###### In this case, we will update the 'Dutch' language to be the 'Portuguese' language.

* Curl:
```
curl -X 'PUT' \
  'https://localhost:7076/api/datalanguages/5' \
  -H 'accept: text/plain' \
  -H 'Content-Type: application/json' \
  -d '{
  "idDataLanguage": 5,
  "dataLanguageName": "Portuguese"
}'
```
* Request URL:
```
https://localhost:7076/api/datalanguages/5
```
* Response:
```
StatusCode: 200
      Content-Type: application/json; charset=utf-8
      Date: Mon, 10 Oct 2022 09:53:32 GMT
      Server: Kestrel
```

* Response body: 
```
200
```

## HTTP Status Codes

| HTTP Status Code |         Meaning         | Description                                                                    |
|------------------|-------------------------|--------------------------------------------------------------------------------|
| __200__          | _OK_                    | The request was successfully executed                                           |
| __201__          | _Created_               | The resource was successfully created (POST method)                             |
| __400__          | _Bad Request_           | The input of the request is wrong and thus, the request cannot be executed     |
| __404__          | _Not Found_             | The researched resource doesn't exist and thus the request cannot be executed  |
| __500__          | _Internal Server Error_ | An issue happened server-side and thus, the request cannot be executed         |
