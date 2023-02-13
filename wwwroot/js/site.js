var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Tomamos los ids del Chat.cshtml para Conectarlos
connection.on("ReceiveMessage", function (fromUser, message) {
    var msg = fromUser + ": " + message;
    var li = document.createElement("li");
    li.textContent = msg;
    $("#list").prepend(li);
});


connection.start();

//Tomamos también el id del botón para poder enviar los mensajes de cliente a servidor
$("#btnSend").on("click", function () {
   var fromUser = $("#txtUser").val();
    var message = $("#txtMsg").val();
    connection.invoke("SendMessage", fromUser, message);
});
