CREATE TABLE Users(
ID INT NOT NULL IDENTITY (14785,1) PRIMARY KEY,
Mail VARCHAR(50) NOT NULL,
Pwd VARCHAR(50) NOT NULL
);

CREATE TABLE Tasks(
ID INT NOT NULL IDENTITY (15987,1) PRIMARY KEY,
TaskState VARCHAR(50) NOT NULL,
CreateDate DATE,
DeadLine DATE,
Note VARCHAR(50) NOT NULL,
IDUserCreator INT NOT NULL,
FOREIGN KEY(IDUserCreator) REFERENCES Users(id),
);

CREATE TABLE Task_User(
IDTask INT NOT NULL,
FOREIGN KEY(IDTask) REFERENCES Tasks(id),
IDUser INT NOT NULL,
FOREIGN KEY(IDUser) REFERENCES Users(id),
Primary key(IDTask,IDUser)
);

CREATE TABLE Comments(
ID INT NOT NULL IDENTITY (14785,1) PRIMARY KEY,
Content VARCHAR(50) NOT NULL,
CreateDate DATE,
IDUser INT NOT NULL,
FOREIGN KEY(IDUser) REFERENCES Users(id),
IDTask INT NOT NULL,
FOREIGN KEY(IDTask) REFERENCES Tasks(id)
);





