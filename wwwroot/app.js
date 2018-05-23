"use strict";

var _hubConnection = new signalR.HubConnectionBuilder();

var connectBtn = document.getElementById("connect");

connectBtn.onclick = (e) => {

    var jwt = document.getElementById("jwt").value;

    console.log(jwt);
    if (jwt) {
        _hubConnection = _hubConnection.withUrl(`http://localhost:5000/notifications?token=${jwt}`)
            .configureLogging(signalR.LogLevel.Information)
            .build();

        _hubConnection
            .start()
            .then(() => { document.getElementById("connected").innerText = "Connected"; })
            .catch(err => console.error(err.toString()));

        bindHubtopics(_hubConnection);
    }
};

var bindHubtopics = (_connection) => {
    _connection.on('Notify', (user, message) => {
        const received = `Received: ${user} ${message}`;

        var actions = document.getElementById("notifications");
        var action = document.createElement("p");
        action.classList.add("notification");
        action.innerText = received;
        actions.appendChild(action);

        console.log(received);

        console.log(received);
    });

    _connection.on('SocketAction', (connectionId, action) => {
        const received = `Action: ${connectionId} ${action}`;

        var actions = document.getElementById("server-actions");
        var action = document.createElement("p");
        action.classList.add("server-action");
        action.innerText = received;
        actions.appendChild(action);

        console.log(received);
    });

};

