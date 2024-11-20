# Task Management API with JWT Authentication

### This ASP.NET Core Web API allows users to manage tasks securely with JWT Authentication. It includes endpoints for authenticating users and performing CRUD (Create, Read, Update, Delete) operations on tasks. The API is designed to be easy to use with tools like Postman for testing.

## Features
### JWT Authentication:

- Users log in with their username and password to receive a JWT token.
- The token is then used to authenticate API requests by passing it in the Authorization header as a Bearer token.
  
### Task Management:

- Create Task: Users can create new tasks by providing task details.
- Get All Tasks: Users can retrieve a list of all tasks.
- Update Task: Users can update the details of an existing task.
- Delete Task: Users can delete a task by its ID.

### Security:

- All task management routes are protected by the [Authorize] attribute, requiring valid authentication via JWT.

## How to Use

To interact with the API, you can use Postman to test the endpoints.

### Step 1: Log In to Get the Token
Send a POST request to https://localhost:7028/api/auth/login with the following body:

{
    "Username": "admin",
    "Password": "admin"
}

If the credentials are correct, the response will include a JWT token:

{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiYWRtaW4iLCJleHAiOjE3MzIxMjE4NjMsImlzcyI6IlRhc2ttYW4iLCJhdWQiOiJUYXNrbWFuIn0.10tA36ic6rekQcJhTKltoPPB6m0nchm34XjaQRqrSUE"
}

Save the token for use in subsequent requests.

### Step 2: Test Task CRUD Operations

Get All Tasks
Send a GET request to https://localhost:7028/api/Task.

In Postman, go to the Authorization tab, select Bearer Token, and paste the JWT token received from the login step in the field.
Send the request to view all tasks.
