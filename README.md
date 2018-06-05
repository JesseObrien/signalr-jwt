# ASP.NET Core 2.1 SignalR  Test Project

This project shows a simple and rudamentary example of using a POST API to interact with a websocket.

It also uses JWT validation for protecting the routes and the websocket.

## Install

For Dotnet Core:

`dotnet restore`

For signalr javascript client:

`cd wwwroot`

`npm install`


## Run

`dotnet run`

## Use

The default run will opeen a document in your browser that *should* connect to the socket by default.

(If not, visit [http://localhost:5000](http://localhost:5000))

Two things you can then do:

1. Authenticate:

`POST http://localhost:5000/token username/password`

2. Use the token to send a message:

`Add 'Authorization: Bearer {token}' header`

`POST http://localhost:5000/messages/share message`

3. Observe signalr winning
