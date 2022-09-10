var connection = new signalR.HubConnectionBuilder().withUrl("/MySignalRTest").build();
connection.start().then(function () {
    console.log("Signalr conected");
}).catch(function (err) {
    return console.error(err.toString());
});

function SendTestMsg() {
    var message = "This is Test Message";
    connection.invoke("SendTestMessage", message).then(function () {
        console.log("Success call");
    }).catch(function (err) {
        return console.error(err.toString());
    });
}

connection.on("RecieveRequestTest", function (msg) {
    alert(msg);
});


connection.on("RecieveOddMsg", function (msg) {
    alert(msg);
});

connection.on("RecieveEvenMsg", function (msg) {
    alert(msg);
});

connection.on("Notification", function (msg) {
    alert(msg);
});