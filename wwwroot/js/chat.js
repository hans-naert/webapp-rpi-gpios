"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();

connection.on("ReceiveMessage", function (user, message) {
    console.log("Message received from " + user + ": " + message);
});

document.getElementById("sendButton").disabled = true;
connection.start().then(function () {   
    document.getElementById("sendButton").disabled = false;


    document.getElementById("sendButton").addEventListener("click", function (event) {
        var user = "ClientUser";
        var message = "Hello from client!"; 
        connection.invoke("SendMessage", user, message).catch(function (err) {
            return console.error(err.toString());
        });
        event.preventDefault();
    });
}
);   


