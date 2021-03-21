# Customer Message
Background on the task

The challenge is to look for a solution that supports all existing (and new /future integrations)
partied with plug and play formatting services. Note that there are countless customers, with different preferences in their communication channel (handled by MessagingService and provided in the attached customer notification zip file).
For example, one customer may accept a message via SMS, whose body is of type JSON, whereas another customer may accept XML over an HTTP call or CSV over FTP, etc.
Message structure:
The structure is simple, it is a string format that has a specified Type for the message and Data which contains the various fields we need for each message.
As an example, in json format our data may be presented as follow
{
   “messageType”: “UserDeleted”,
   “data”: {
            “customerId”: “9f9b1a81-2f94-44b7-994d-50cb60738f93” 
    }
}
While the same message can be presented in the CSV format as
“UserDeleted”,”9f9b1a81-2f94-44b7-994d-50cb60738f93” 
Message types and content:
All messages should contain the following information –
- A message type that indicates the context of the notification. It is expected that the API should support the following Types
o NewUserRegistered 
o UserDeleted
o UserBlocked
- A message body that may contain different information depends on the message type. 
The following list illustrates the potential content of these messages
<H2>1. Message when a user registered</H2>
    Type: NewUserRegistered  Body type:
    string UserId 
    string Email 
    string Firstname 
    string LastName
               
    {
       "messageType":"NewUserRegistered",
       "data" : { 
          "UserId": "abcd",
          "Email": "ken.park@hotmail.com",
          "Firstname": "ken",
          "Lastname":"Park"
    
       }
    }


<H2>2. Message when a user deleted</H2>
    Type: UserDeleted Body type:
    string UserId
   
    
    {
        "messageType": "UserDeleted",
        "data" : {
            "UserId": "comkwang"

        }
    }

<H2>3. Message when a user blocked</H2> 
   Type: UserAccessBlocked Body type: 
   string UserId
   
    
    {
        "messageType": "UserBlocked", 
        "data" : {
            "UserId": "comkwang"
        }
    }

<h2>All Pakages I used</h2>
Microsoft.EntityFrameworkCore<br>
Microsoft.EntityFrameworkCore.Sqlserver<br>
Microsoft.EntityFrameworkCore.Tools<br>
Microsoft.VisualStudio.Web.CodeGeneration.Design<br>


![image](https://user-images.githubusercontent.com/13435196/111920612-0cfcc200-8ae4-11eb-99b5-3f55e47fd764.png)


![image](https://user-images.githubusercontent.com/13435196/111920446-1f2a3080-8ae3-11eb-8d82-fe86a83e5982.png)


![image](https://user-images.githubusercontent.com/13435196/111920464-408b1c80-8ae3-11eb-88fa-d624cff719ab.png)


![image](https://user-images.githubusercontent.com/13435196/111920481-5862a080-8ae3-11eb-9f30-e831f5ea9ece.png)
