# koc-finans
@PelinAkpinar

Credit Score App

Getting Started
1) First clone the project
>git clone https://github.com/PelinAkpinar/koc-finans.git

2) Restore the project 🔨
dotnet restore

3) .NET 3.1  required for building the project

4) Open the folder(solution) in IDE(Visual Studio 2019 I preferred) and rebuild the .sln

5) Then press Start, it will run microservices(You should see Health:OK status in seperate windows and a terminal for push notification).
Or you can seperately start all microservices by open each micro service's path on desired console end write dotnet run.

There are 3 main services and 1 worker service for notification. These are;
	1 CreditScoreMicroService - It is a layer between mongoDb and gateway. The db stores credits scores by identity no(TCKN no).
Filled with dummy data for ids between 1-1000;
	2 CredıtsMicroService - It is a layer between mongoDb and gateway too. But data is approved credit applications, 
with necessity attributes.
	3 Gateway - It is an entry point for users and frontend applications. It connects everthing together and inserts notification message to
rabbitmq queue;
	4 NotificationWorker - Simple console app which reads the rabbitmq queue and prints notification to the user

6) KocFinans/KocFinansFrontend folder is for project's frontend, open terminal in this folder and run the command:
>>ng serve --o (npm and node.js required)

7)I used a mongodb collection for database, datas for testing:

**One sample for declined credit
    _id
    :"2b8ffcab-b7c1-4099-a912-569a97b6448f"
    IdentityNo
    :7
    CreditScore
    :229

**One sample for approved credit
    _id
    :"92eaf3e2-a817-40dc-9fc5-21012d8202d5"
    IdentityNo
    :8
    CreditScore
    :519328369

8) Just be sure that you entered the information from samples to related fields correctly(For example you should give numbers to phone field).

9) If the credit approved, you can see the notification via notification worker project`s terminal(SMS notification).
