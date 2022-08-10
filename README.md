# dotnetWebApp

A simple `dotnet=6.0` mvc app with mysql db connection.


# Database

Requires db setup that is outlined in below. The credentials can be modified in the /Daos/StudentDao.cs file.

```roomsql
CREATE DATABASE StudentDB;

use StudentDB;

CREATE TABLE students (
id INTEGER PRIMARY KEY,
name TEXT NOT NULL,
gpa double NOT NULL
);

INSERT INTO students (id, name, gpa) values
(1, 'Daniel', 89),
(2, 'Samuel', 76),
(3, 'Sanele', 96);
```

# Running the application

Execute the command `bash start.sh tagname`. This will create a docker image and push it to remote repository. Make sure you change docker repository in `start.sh`and `deployment.yaml` with your own repo. Remember to change docker image in deployment file to match your tagname. To check if the application successfully deployed, go to `http://localhost:7146`. Alternatively, run the command `dotnet run`