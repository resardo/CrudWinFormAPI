CREATE TABLE Employee(
    EmployeeID uniqueidentifier NOT NULL PRIMARY KEY,
    Username varchar(20) NOT NULL,
	Password varchar(20) NOT NULL,
)

Create Table Form(
	FormId uniqueidentifier  NOT NULL PRIMARY KEY,
	Emri varchar(20) NOT NULL,
	Mbiemri varchar(20) NOT NULL,
	Datelindja date NOT NULL,
	Telefon varchar(20) NOT NULL,
	Gjinia varchar(20) NOT NULL CHECK (Gjinia IN('M', 'F')),
	IPunesuar int NOT NULL ,
	GjendjaMartesore varchar(255) NOT NULL,
	Vendlindja varchar(255) NOT NULL,
	EmployeeID uniqueidentifier FOREIGN KEY REFERENCES Employee(EmployeeID)
)

Create Table Role(
	RoleId uniqueidentifier  NOT NULL PRIMARY KEY,
	Name varchar(20) NOT NULL
)

Create Table EmployeeRole(
	EmployeeRoleID INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeID uniqueidentifier ,
    RoleId uniqueidentifier ,
    FOREIGN KEY (EmployeeID) REFERENCES Employee(EmployeeID),
    FOREIGN KEY (RoleId) REFERENCES Role(RoleId)
)





