# ImpedanceMismatchSample






## Table Schema

Here is the Table Schema required for the Sample:

```sql

CREATE TABLE Team(
    ID int PRIMARY KEY IDENTITY(1, 1),
    Name nvarchar(255) NOT NULL
);

CREATE TABLE TeamMember (
    ID int PRIMARY KEY IDENTITY(1,1),
    Name nvarchar(255) NOT NULL,
    TeamID int,
    FOREIGN KEY (TeamID) REFERENCES Team(ID)
);
```
 
