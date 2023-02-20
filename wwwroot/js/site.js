<script src="~/lib/signalr/dist/browser/signalr.min.js"></script>
<script src="~/lib/signalr/dist/browser/signalr.js"></script>

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("ReceiveMessage", function (fromUser, message) {
    var msg = fromUser + ": " + message;
    var li = document.createElement("li");
    li.textContent = message;
    $("#list").prepend(li);
});

connection.start();   

$("#btnSend").on("click", function () {
    var fromUser = $("#txtUser").val();
    var message = $("#txtMsg").val();
    connection.invoke("SendMessage", fromUser, message);
});

let toggle = document.getElementsById('toggle');
let label_toggle=document.getElementById("label_toggle")
toggle.addEventListener('change', (event) => {
    let checked = event.target.checked;
    document.body.classList.toggle('dark');
});

