
									JukkaSignalRMvc

This solution is base on Tutorial: Real-time chat with SignalR 2 and MVC 5 and has been modified 
for my learning purposes.  https://docs.microsoft.com/en-us/aspnet/signalr/overview/getting-started/tutorial-getting-started-with-signalr-and-mvc

JukkaSIgnalRMvc is a WebAPI project with a SignalRConsoleClient and SignalRMvc server.

The SignalRConsoleClinet is a console program to invoke the web api and then the SignalR code.

It is based from the Microsoft examples meaning the ValuesController is from the MS sample
which I have enhanced for my edification.

The SignalRConsoleClient invokes the SignalRMvc actions first and then starts and invokes 
the SignalR stuff.

The URL is http://localhost:8080/.  You can change the port in the SitnalRMvc project properties 'Project Url'.

SignalRConsoleClient will connect to the SignalRMvc webapi and then the HUB of the SignalRMvc project SimpleHub in SignalRMvc

The solution properties are set to start the SignalrRMVC Web API project and then the SignalRConsoleClient project.
Clicking F5 will start both projects and a console window will be displayed

After the first run you can simply run SignalRConsoleClient again without restarting SignalRMvc, it seems!
Clicking Stop Debugging will stop both projects

Debugging tracing of this solution can be problematic because of the asynchronous nature of the project. 
Have fun and take Tylenol if SignalR gives you headache.