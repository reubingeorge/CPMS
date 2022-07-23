# Conference Paper Management System (CPMS)

### Project Description

<dl>
  <dt><h4>Preface</h4></dt>
  <dd>This project is an assignment created for USF's CEN 4020 (Software Engineering) Course.</dd>
  
  <dt><h4>Objective</h4></dt>
  <dd>The created system will automate the reviewer registration process, the author registration process, the paper submission process, the paper matching process, the paper distribution process, the paper review process, and the report generation process.</dd>
  
  <dt><h4>Team</h4></dt>
  <dd>Team 12 (<a href="https://github.com/KDchimken12">Khoa Doan</a>, <a href = "https://github.com/reubingeorge">Reubin George</a>, <a href="https://github.com/andrictam">Andric Tam</a>)</dd>
  
  <dt><h4>System Requirements</h4></dt>
  <dd>Windows 10 (Any Edition), Visual Studio 2019 (or higher), MS SQL</dd>
  
  <dt><h4>Programming Languages</h4></dt>
  <dd>C# (ASP.NET), Javascript/ jQuery, HTML, CSS (Bootstrap)</dd>
  
  <dt><h4>Backstory</h4></dt>
  <dd>The Consortium for Computing Sciences in Colleges (CCSC) is a non-profit organization focused on promoting quality computing curricula and the effective use of computing in colleges and universities. The CCSC encourages the sharing of research, effective curricula, teaching expertise, and efficient technological applications in the classroom. Generally speaking, the CCSC is concerned with the advancement of curricular programs in Computer Science, Computer Information Systems, Software Engineering, and any other discipline in which software development is the focus. At its annual conference, they have a number of paper sessions, where professors (or sometimes others) present their research, teaching ideas, and so forth. All papers are judged according to the same standard. The paper has to be academically sound and be something of interest to the conference attendees. This is because any accepted paper is published in their journal—the Journal of Computing Sciences in Colleges—and the high quality and focus of this journal must be maintained.</dd>
</dl>

---
### System Description

The system will allow only three types of users who have the following privileges:

| Roles         | 
| ------------- |
| Author        | 
| Reviewer      | 
| Administrator | 

### Functional Requirements For Administrator

| **Category** | **Priority** | **The system shall permit an Administrator to…**                 |
|--------------|--------------|------------------------------------------------------------------|
| Mandatory    | 1            | Log in to account.                                               |
| Mandatory    | 1            | Start paper and reviewer matching process.                       |
| Mandatory    | 1            | Edit paper and reviewer matching results.                        |
| Mandatory    | 1            | Distribute the correct papers to the reviewer.                   |
| Mandatory    | 1            | Generate a report for each paper based off submitted reviews.    |
| Mandatory    | 1            | Generate authors report.                                         |
| Mandatory    | 1            | Generate reviewers report.                                       |
| Mandatory    | 1            | Generate reviewer’s comment report.                              |
| Mandatory    | 2            | Prevent papers from being submitted after a specified deadline.  |
| Mandatory    | 2            | Prevent reviews from being submitted after a specified deadline. |
| Optional     | 1            | Maintain the paper database table.                               |
| Optional     | 1            | Maintain the reviewer database table.                            |
| Optional     | 1            | Maintain the author database table.                              |
| Optional     | 1            | Maintain the reviews database table.                             |

### Functional Requirements For Reviewer

| **Category** | **Priority** | **The system shall permit a Reviewer to…** |
|--------------|--------------|--------------------------------------------|
| Mandatory    | 1            | Log in to account                          |
| Mandatory    | 1            | Retrieve forgotten passwords               |
| Mandatory    | 1            | Register with given information            |
| Mandatory    | 1            | Download papers matched with them          |
| Mandatory    | 1            | Submit reviews for papers                  |
| Mandatory    | 2            | Edit account information                   |

### Functional Requirements For Author

| **Category** | **Priority** | **The system shall permit an Author to...** |
|--------------|--------------|---------------------------------------------|
| Mandatory    | 1            | Log in to account                           |
| Mandatory    | 1            | Retrieve forgotten passwords                |
| Mandatory    | 1            | Register with given information             |
| Mandatory    | 1            | Submit a paper                              |
| Mandatory    | 2            | Edit account information                    |

### Non-Functional Requirements

| **Category** | **Priority** | **Requirements**                                                                            |
|--------------|--------------|---------------------------------------------------------------------------------------------|
| Mandatory    | 1            | Availability: System should be available 24/7                                               |
| Mandatory    | 1            | Compatibility: System should be able to operate on Edge, Firefox, Chrome, Safari, and Opera |
| Mandatory    | 1            | Robustness: System will not allow the user to input bad data                                |
| Mandatory    | 1            | Security: System will be inaccessible without login credentials                             |
| Mandatory    | 1            | Usability: System should be intuitive and easy to use                                       |

---
### Setup

1. The first time you run the code on Visual Studio, run the sql query file named `CPMS_Database.sql`
![SQL QUERY](https://github.com/reubingeorge/CPMS/blob/master/Screenshots/run_sql_query.png?raw=true "Running SQL Query to create a database")

2. Ensure that the database has been created with the following tables in it. ![SQL Tables](https://github.com/reubingeorge/CPMS/blob/master/Screenshots/database_creations.png?raw=true "Database Tables")

3. Navigate to the properties panel of the CPMS database. ![SQL DB Properites](https://github.com/reubingeorge/CPMS/blob/master/Screenshots/sql_database_properties.png?raw=true "SQL DB Properties Panel")

4. Copy the connection string of the CPMS database. ![DB Connection String](https://github.com/reubingeorge/CPMS/blob/master/Screenshots/sql_database_connection_string.png?raw=true "SQL DB Connection String")

5. Navigate to the `DAO.cs` file under the `Data` folder and paste the connection string between the quotes. ![DAO.cs file](https://github.com/reubingeorge/CPMS/blob/master/Screenshots/sql_DAO_connection_string.png?raw=true "Connection string in DAO.cs")

6. In the Menu Bar, navigate to Build and click build to ensure that no errors are created. ![Successful Build](https://github.com/reubingeorge/CPMS/blob/master/Screenshots/successful_build.png?raw=true "Successful Build")

---
### Security Concerns

1. The sign in controllers access <b>TWO</b> different tables to verify if a logged in user is either a reviewer or an author. Ideally, we want to access only <b>ONE</b> table to verify user authentication and role.

2. Both Reviewer and Author table do not hash user's password.

3. None of page that accesses the database checks whether a <b>VIABLE</b> and <b>VALID</b> connection to the SQL database exists. 

4. The reviewer and the author are allowed to create a password of max length of 5.

---
### Potential Improvements

1. The tables in this project are normalized to Norm Form 3. It might be better to normalize the table to Norm Form 4. The reason why this was not done in the first place was because the database template was provided by the instructor.

2. We used Data Access Object to perform CRUD operations on the database. We should be using Entity Framework instead. 

3. We should be using <a href="https://reactjs.org/">React</a> or <a href="https://angular.io/">Angular</a> to create the web components.

4. We want to run WebAssembly using <a href="https://dotnet.microsoft.com/en-us/apps/aspnet/web-apps/blazor">Blazor</a>. This will help add additional functionality without changing too much of the old code. 

5. We want to host the database on a server rather than use a localhost because every contributor needs to create a new database on the system with entirely new set of records for every table. 

6. No integration, system, accceptance or production tests were performed throughout the course of this project. 
