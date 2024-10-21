import * as signalR from "@microsoft/signalr";

const connection = new signalR.HubConnectionBuilder()
    .withUrl("https://your-notification-service-url/notificationHub")
    .build();

connection.on("ReceiveNotification", (message) => {
    console.log("Notification received:", message);
    // Display the notification to the user here
});

connection.start().catch(err => console.error(err.toString()));
