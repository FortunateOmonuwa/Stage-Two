# Stage-Two

#Project Documentation

## Introduction

This documentation outlines the endpoints, request formats, and expected responses for this Rest API.


Here's a link to the UML diagram https://lucid.app/lucidchart/0dce4372-34bd-4211-8c36-690b2f4f2a86/edit?viewport_loc=-12%2C76%2C2552%2C1256%2CHWEp-vi-RSFO&invitationId=inv_9f79219a-1835-4b41-8939-c4ce3fdc7709

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
        Description: Retrieve user details by ID.

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
        Description: Update user details by ID.

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
        Description: Delete user by ID.

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
