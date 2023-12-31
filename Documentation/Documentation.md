#Project Documentation

## Introduction

This documentation outlines the endpoints, request formats, and expected responses for this Rest API.

## ###Endpoints and Usage

    Create a New User

    --HTTP Method: POST
        ...Endpoint: /api

        Description: Create a new user.

        Request:
                {
                "Name": "John Doe"
                }
        Response (Success): Status Code 201 (Created)
                {
                "Id": 1,
                "Name": "John Doe"
                }
        Response (Error): Status Code 400 (Bad Request)
                {
                "message": "Invalid data provided"
                }

---

    Get User by ID

    --HTTP Method: GET
        Endpoint: /api/{user_id}
        Description: Retrieve user details by ID {ID in this case is dynamic. Input can either be the Id:integer or Id:string(name)}.

        Response (Success): Status Code 200 (OK)
            {
            "Id": 1,
            "Name": "John Doe"
            }

        Response (Error): Status Code 404 (Not Found)
        {
        "message": "User with ID {user_id} doesn't exist"
        }

---

    Get All Users

    --HTTP Method: GET
        Endpoint: /api
        Description: Retrieve a list of all users.

        Response (Success): Status Code 200 (OK)
            [
                {
                    "Id": 1,
                    "Name": "John Doe"
                },
                {
                    "Id": 2,
                    "Name": "Jane Smith"
                }
            ]

        Response (Error): Status Code 404 (Not Found)
            {
            "message": "No users were found"
            }

---

    Update User

    --HTTP Method: PUT
        Endpoint: /api/{user_id}
        Description: Update user details by ID. {ID in this case is dynamic. Input can either be the Id:integer or Id:string(name)}.

        Request:
            {
            "Name": "Updated Name"
            }

        Response (Success): Status Code 200 (OK)
            {
            "Id": 1,
            "Name": "Updated Name"
            }

        Response (Error): Status Code 400 (Bad Request)
            {
            "message": "Invalid data provided"
            }

---

    Delete User
    --HTTP Method: DELETE
        Endpoint: /api/{user_id}
        Description: Delete user by ID. {ID in this case is dynamic. Input can either be the Id:integer or Id:string(name)}.

        Response (Success): Status Code 200 (OK)
            {
            "message": "User successfully deleted"
            }

        Response (Error): Status Code 404 (Not Found)
            {
            "message": "User with ID {user_id} doesn't exist"
            }

---

#### Known Limitations and Assumptions

    ---The API assumes that the user's name contains only alphabets and spaces. Invalid names will result in a "Bad Request" response.

    ---Error responses provide descriptive error messages to help identify issues.

##### Setting up and Deploying the API

    ---Clone the project repository from GitHub.

    ---Configure the database connection in the appsettings.json file.

    ---Build and run the API project using your preferred development environment.

    ---Use a tool like Postman to test the API endpoints.
