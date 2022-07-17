# Conference Paper Management System (CPMS)

<dl>
  <dt>Preface</dt>
  <dd>This project is an assignment created for USF's CEN 4020 (Software Engineering) Course.</dd>
  
  <dt>Objective</dt>
  <dd>The created system will automate the reviewer registration process, the author registration process, the paper submission process, the paper matching process, the paper distribution process, the paper review process, and the report generation process.</dd>
  
  <dt>Team</dt>
  <dd>Team 12 (Khoa Doan, Reubin George, Andric Tam)</dd>
  
  <dt>System Requirements</dt>
  <dd>Windows 10 (Any Edition), Visual Studio 2019 (or higher), MS SQL</dd>
  
  <dt>Programming Languages</dt>
  <dd>C# (ASP.NET), Javascript/ jQuery, HTML, CSS (Bootstrap)</dd>
</dl>

---
### System Description

The system will allow only three types of users who have the following privileges:

| Roles         | Privileges                   |
| ------------- |:---------------------:|
| Author        | Edit Profile, Submit Papers |
| Reviewer      | Edit Profile, Submit Reviews |
| Administrator | <p>CRUD operation of Authors</p> <p>CRUD operation of Reviewers</p> <p>Match Papers with Reviewers</p> <p>Turn off Paper Submission</p> <p>Turn off Review Submission</p>|

---
###

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
