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

| Roles         | 
| ------------- |
| Author        | 
| Reviewer      | 
| Administrator | 

### Functional Requirements

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

| **Category** | **Priority** | **The system shall permit a Reviewer to…** |
|--------------|--------------|--------------------------------------------|
| Mandatory    | 1            | Log in to account                          |
| Mandatory    | 1            | Retrieve forgotten passwords               |
| Mandatory    | 1            | Register with given information            |
| Mandatory    | 1            | Download papers matched with them          |
| Mandatory    | 1            | Submit reviews for papers                  |
| Mandatory    | 2            | Edit account information                   |

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
1. The first time you run the code of Visual Studio, run the sql query file named `CPMS Database Creation Script.sql`

...You can have properly indented paragraphs within list items. Notice the blank line above, and the leading spaces (at least one, but we'll use three here to also align the raw Markdown).
