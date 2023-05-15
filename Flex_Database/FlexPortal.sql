Create Database Flex;
-- Drop Database Flex;

use Flex;

Create Table Users
(
	Username varchar(7),
	Passwd varchar(255),
	Name1 varchar(255),
	Role1 int Check (Role1=1 OR Role1 =2 OR Role1=3),			-- 1 for Academic, 2 for faculty, 3 for student

	Primary Key(Username)
);

Create Table Student
(
	Username varchar(7),
	Email varchar(255),
	Degree varchar(40),
	DOB date,
	MobileNo varchar(11),
	Address1 varchar(255),
	CNIC varchar(13),

	Primary Key(Username),
	Foreign Key(Username) References Users(Username)
);

Create Table Academic
(
	Username varchar(7),

	Primary Key(Username),
	Foreign Key(Username) References Users(Username)
);

Create Table Faculty
(
	Username varchar(7),

	Primary Key(Username),
	Foreign Key(Username) References Users(Username)
);

Create Table Course
(
	CourseID varchar(6),
	Title varchar(255),
	PreReq varchar(6),
	CreditHrs int Check (CreditHrs=1 OR CreditHrs=2 OR CreditHrs=3),
	CType varchar(255) Check (CType='Core' or CType='Elective'),
	Coordinator varchar(7),

	Primary Key(CourseID),
	Foreign Key(Coordinator) References Faculty(Username)
);

CREATE TABLE Section
(
	Strength NUMERIC(2) CHECK(Strength>=10 AND STRENGTH<=50),
	Room_Number VARCHAR(4),
	Course VARCHAR(6) FOREIGN KEY REFERENCES Course(CourseId),
	Sec_Name CHAR,
	Instructor varchar(7),

	Primary Key(Course, Sec_Name),
	Foreign Key(Instructor) References Faculty(Username)

);

Create Table Attendance
(
	Username varchar(7),
	CourseID varchar(6),
	SecName char,
	ADate date,
	P_A char Check (P_A = 'P' or P_A ='A'),

	Primary Key(Username, CourseID, SecName, ADate),

	Foreign Key(Username) References Student(Username),
	Foreign Key(CourseID, SecName) References Section(Course, Sec_Name)

);


CREATE TABLE Marks_Distribution
(
	Course VARCHAR(6),
	Sec_Name CHAR,
	Assignments_Distr NUMERIC(3) CHECK(Assignments_Distr>=0 AND Assignments_Distr<=100),
	Sessional_Distr NUMERIC(3) CHECK(Sessional_Distr>=0 AND Sessional_Distr<=100),
	Quizes_Distr NUMERIC(3) CHECK(Quizes_Distr>=0 AND Quizes_Distr<=100),
	Finals_Distr NUMERIC(3)  CHECK(Finals_Distr>=0 AND Finals_Distr<=100),
	

	Primary Key(Course, Sec_Name),
	Foreign Key(Course, Sec_Name) References Section(Course, Sec_Name)


);


CREATE TABLE MARKS
(
	StudentID varchar(7),
	Course varchar(6),
	Sec_Name char,
	Assignments_Marks NUMERIC(3),
	Sessional_Marks NUMERIC(3),
	Quizes_Marks NUMERIC(3),
	Finals_Marks NUMERIC(3),
	

	Primary Key(StudentID, Course, Sec_Name),
	Foreign Key(StudentID) References Student(Username),
	Foreign Key(Course, Sec_Name) References Marks_Distribution(Course, Sec_Name)
);

CREATE TABLE Record
(
	Student_Name VARCHAR(7) FOREIGN KEY REFERENCES Student(USERNAME),
	Course VARCHAR(6) FOREIGN KEY REFERENCES Course(CourseId),
	Grade VARCHAR(2),

	Primary Key(Student_Name, Course, Grade)

);

CREATE TABLE Feedback
(
	StudentID varchar(7),
	FacultyID varchar(7),
	Course varchar(6),
	Section CHAR,
	Date_F DATE,
	Percentage_F NUMERIC(3) CHECK(PERCENTAGE_F>=0 AND PERCENTAGE_F<=100),
	Comment VARCHAR(255),

	Primary Key(StudentID, FacultyID, Course, Section),
	Foreign Key(StudentID) References Student(Username),
	Foreign Key(FacultyID) References Faculty(Username),
	Foreign Key(Course, Section) References Section(Course, Sec_Name),

);

Create Table Registers
(
	StudentID varchar(7),
	Course varchar(6),
	Section char,

	Primary Key(StudentID, Course, Section),
	Foreign Key(StudentID) References Student(Username),
	Foreign Key(Course, Section) References Section(Course, Sec_Name)


);



BULK INSERT Users
FROM 'C:\Users\Abher\Desktop\Flex_Database\Users.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Student
FROM 'C:\Users\Abher\Desktop\Flex_Database\Student.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Academic
FROM 'C:\Users\Abher\Desktop\Flex_Database\Academic.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Faculty
FROM 'C:\Users\Abher\Desktop\Flex_Database\Faculty.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Course
FROM 'C:\Users\Abher\Desktop\Flex_Database\Course.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Section
FROM 'C:\Users\Abher\Desktop\Flex_Database\Section.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Attendance
FROM 'C:\Users\Abher\Desktop\Flex_Database\Attendance.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Marks_Distribution
FROM 'C:\Users\Abher\Desktop\Flex_Database\Marks_Distribution.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO




BULK INSERT Marks
FROM 'C:\Users\Abher\Desktop\Flex_Database\Marks.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Record
FROM 'C:\Users\Abher\Desktop\Flex_Database\Record.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Feedback
FROM 'C:\Users\Abher\Desktop\Flex_Database\Feedback.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

BULK INSERT Registers
FROM 'C:\Users\Abher\Desktop\Flex_Database\Registers.tsv' --location with filename
WITH
(
   FIELDTERMINATOR = '\t',
   ROWTERMINATOR = '\n',
    FIRSTROW = 2
);
GO

--select * from dbo.Marks_Distribution

--select * from Faculty
--join Users on Faculty.Username = Users.Username
--where Name1 = 'Thomas Underwood'

--select * from Section
--inner join Faculty on Faculty.Username = Section.Instructor
--inner join users on Faculty.Username = users.Username
--where Name1 = 'Thomas Underwood'

Select COUNT(Course.CourseID) from Course;

Select Course.Title from Course;


Select Section.Sec_Name from Section
inner join Course on Section.Course = Course.CourseID
where Course = 'FG5012';

select * from Users;

Select Users.Name1 from Users
Inner Join Faculty on Users.Username = Faculty.Username;

Select CONCAT(Users.Username, '  ' , Users.Name1) as Teachers from Users
where Users.Role1 = 2;

Select Users.Username from Users
where Users.Role1 = 2
and CONCAT(Users.Username, '  ' , Users.Name1)  = '10T4012  Thomas Underwood';

Update Section
Set Section.Instructor = (Select Users.Username from Users where Users.Role1 = 2
and CONCAT(Users.Username, '  ' , Users.Name1)  = '10T4012  Thomas Underwood')
where Section.Course = ''
and Section.Sec_Name = ''

select * from Section

Select COUNT(*) as Secs from Section
where Section.Instructor = (Select Users.Username from Users where Users.Role1 = 2
and CONCAT(Users.Username, '  ' , Users.Name1)  = '10T4012  Thomas Underwood');

Select Course.CourseID, Course.Title, Course.CreditHrs from Course;

Select Student.Username, Section.Course, Section.Sec_Name
from Student inner join registers on Student.Username = Registers.StudentID
inner join Section on Section.Course = Registers.Course and Section.Sec_Name = Registers.Section


Select Course.CourseID, Course.Title, Course.CreditHrs, Section.Sec_Name, u2.Name1, u1.Name1
from Course inner join Section on Course.CourseID = Section.Course
inner join Users as u1 on Course.Coordinator = u1.Username
inner join Users as u2 on Section.Instructor = u2.Username
group by Course.CourseID, Course.Title, Course.CreditHrs, Section.Sec_Name, u2.Name1, u1.Name1


-- check to see if student exists in DB
Select * from Student
where Student.Username = ''

-- check for pre req

Select * from Course
where Course.PreReq in (Select Record.Course from Record
inner join Student on Student.Username = Record.Student_Name
inner join Course on Course.CourseID = Record.Course
where Student.Username = ''
and Record.Grade not like 'F')
and Course.CourseID = ''

-- 6 courses CHECK

Select COUNT(*) from Registers
where Registers.StudentID = ''
and Registers.Course = ''
and Registers.Section = ''

-- check if already registered

Select * from Registers
where Registers.StudentID = ''
and Registers.Course = ''
and Registers.Section = ''


-- Insertion query

Insert Into Registers Values
('', '', '');



Select * from Registers

Select * from Registers
Select * from record

Select * from Users

select * from Academic inner join Users on Academic.Username = USERs.Username

select * from Faculty

-- /////////////////////////////////////////////////////

-- to check if course already present or not
Select CourseID from Course
where Course.CourseID = ''

-- if pre req not null then check does it even  exist

Select CourseID from Course
where Course.CourseID = ''

-- check coordinator exists or not

Select Faculty.Username from Faculty
where Faculty.Username = ''

-- insert into course

Insert Into Course Values
('', '', '',int, '', '');	    -- CourseID, Title, PreReq, CreditHrs, Ctype, Coordinator

-- all students registered in a course

select * from Registers
where Registers.Course = ''

-- /////////////////////////////////////////////////

Select Section.Course from Section where Section.Instructor = '10T'
Select Section.Sec_Name from Section where Section.Instructor = ''

-- use old code to grab course and sec

Select Registers.StudentID from Registers
where Registers.Course = ''
and Registers.Section = ''

-- query to check if present of a student in a course on a specific day already present or not
Select * from Attendance
where Attendance.Username = ''
and Attendance.CourseID = ''
and Attendance.SecName = ''
and Attendance.ADate = '' -- in fromat YYYY/MM/DD

Insert Into Attendance Values
('', '', '', '');				-- Student Username, CourseID, Section, Date in format YYYY/MM/DD



select * from Faculty
select * from users


-- ////////////////////////////////////////////////////

Select * from Marks_Distribution
where Marks_Distribution.Course = ''
and Marks_Distribution.Sec_Name = ''

Insert Into Marks_Distribution Values
('', '', int, int, int, int);	-- CourseID, Section,assignment, sessional,quizzes, final  

Update Marks_Distribution
Set Assignments_Distr = int, Sessional_Distr = int, Quizes_Distr = int, Finals_Distr = int
where Marks_Distribution.Course = ''
and Marks_Distribution.Sec_Name = ''

Select * from Marks_Distribution

Insert Into Section Values
(14, 'C301', 'BP6801', 'C', '13T1592');

Select * from Registers where Registers.Course = 'LU3423'

Insert Into Registers Values
('21S4328', 'BP6801', 'C')


-- /////////////////////////

-- to check if marks record already exists or not

Select * from MARKS
where MARKS.Course = ''
and MARKS.Sec_Name = ''
and MARKS.StudentID = ''

-- if doesnt exist insert new entry

Insert Into MARKS Values
('', '', '', int, int, int, int);	-- StudentID, Course, Section, Assignment, Sessional, Quizzes, Finals

-- else update old marks

Update MARKS
Set Assignments_Marks = int, Sessional_Marks = int, Quizes_Marks = int, Finals_Marks = int
Where MARKS.StudentID = ''
and MARKS.Course = ''
and MARKS.Sec_Name = ''

Select Marks_Distribution.Assignments_Distr
from Marks_Distribution
where Marks_Distribution.Course = ''
and Marks_Distribution.Sec_Name = ''

Select Marks_Distribution.Sessional_Distr
from Marks_Distribution
where Marks_Distribution.Course = ''
and Marks_Distribution.Sec_Name = ''

Select Marks_Distribution.Quizes_Distr
from Marks_Distribution
where Marks_Distribution.Course = ''
and Marks_Distribution.Sec_Name = ''

Select Marks_Distribution.Finals_Distr
from Marks_Distribution
where Marks_Distribution.Course = 'BP6801'
and Marks_Distribution.Sec_Name = 'A'


-- ///////////////////////////////////////////////////////////////////////////////

Select Registers.StudentID from Registers
where Registers.Course = ''
and Registers.Section = ''

 

Select (MARKS.Assignments_Marks + MARKS.Sessional_Marks + MARKS.Quizes_Marks + MARKS.Finals_Marks) as marks1, course, Sec_Name from MARKS
order by marks1 asc
where MARKS.StudentID = ''
and MARKS.Course = ''
and MARKS.Sec_Name = ''


Select MARKS.StudentID, (MARKS.Assignments_Marks + MARKS.Sessional_Marks + MARKS.Quizes_Marks + MARKS.Finals_Marks) as 'Marks'
Into #temp_table
from MARKS
where MARKS.Course = 'BP6801'
and MARKS.Sec_Name = 'A'

SELECT StudentID, Marks,
  CASE
    WHEN marks >= 90 THEN 'A+'
    WHEN marks >= 86 AND marks <= 89 THEN 'A'
    WHEN marks >= 82 AND marks <= 85 THEN 'A-'
    WHEN marks >= 78 AND marks <= 81 THEN 'B+'
    WHEN marks >= 74 AND marks <= 77 THEN 'B'
    WHEN marks >= 70 AND marks <= 73 THEN 'B-'
    WHEN marks >= 66 AND marks <= 69 THEN 'C+'
    WHEN marks >= 62 AND marks <= 65 THEN 'C'
    WHEN marks >= 58 AND marks <= 61 THEN 'C-'
    WHEN marks >= 54 AND marks <= 57 THEN 'D+'
    WHEN marks >= 50 AND marks <= 53 THEN 'D'
    ELSE 'F'
  END AS grade
FROM #temp_table;

drop table #temp_table;


-- check if record already present or not

Select * from Record
where Record.Student_Name = ''
and Record.Course = ''
and Record.Grade = ''

Insert Into Record Values
('', '', '');	-- studentid, course, grade

Select * from MARKS

-- ATTENDANCE

Select Username as 'StudentID', ADate as 'Date' from Attendance
where Attendance.CourseID = ''
and Attendance.SecName = ''


-- EVALUATION REPORT

Select MARKS.StudentID, MARKS.Assignments_Marks, MARKS.Sessional_Marks, MARKS.Quizes_Marks, MARKS.Finals_Marks from MARKS
where MARKS.Course = ''
and MARKS.Sec_Name = ''

-- GRADE COUNT REPORT


Select MARKS.StudentID, (MARKS.Assignments_Marks + MARKS.Sessional_Marks + MARKS.Quizes_Marks + MARKS.Finals_Marks) as 'Marks'
Into #temp_table
from MARKS
where MARKS.Course = 'BP6801'
and MARKS.Sec_Name = 'A'

SELECT 
  CASE
    WHEN marks >= 90 THEN 'A+'
    WHEN marks >= 86 AND marks <= 89 THEN 'A'
    WHEN marks >= 82 AND marks <= 85 THEN 'A-'
    WHEN marks >= 78 AND marks <= 81 THEN 'B+'
    WHEN marks >= 74 AND marks <= 77 THEN 'B'
    WHEN marks >= 70 AND marks <= 73 THEN 'B-'
    WHEN marks >= 66 AND marks <= 69 THEN 'C+'
    WHEN marks >= 62 AND marks <= 65 THEN 'C'
    WHEN marks >= 58 AND marks <= 61 THEN 'C-'
    WHEN marks >= 54 AND marks <= 57 THEN 'D+'
    WHEN marks >= 50 AND marks <= 53 THEN 'D'
    ELSE 'F'
  END AS grade
 Into #temp_table2
FROM #temp_table;

drop table #temp_table;

Select #temp_table2.grade, COUNT(grade) as 'Count' from #temp_table2
group by grade

drop table #temp_table2;

--------------------------

select * from Users;


-- --------------------------------------

Select Registers.Course from Registers
where Registers.StudentID = 

Select Section.Sec_Name from Section
where Section.Course = 

Select Attendance.ADate from Attendance
where Attendance.CourseID = 'BP6801'
and Attendance.Username = '18S7140'

Select * from MARKS

Select MARKS.Assignments_Marks, MARKS.Sessional_Marks, MARKS.Quizes_Marks, MARKS.Finals_Marks
from MARKS
where MARKS.StudentID = @stud
and MARKS.Course = @course


Select * from Record where Record.Course = 'CO1531' 

Select * from registers where Registers.StudentID = '23S4647'
Select * from Course


Select * from Section

Insert Into Section Values(30, 'C301', '123450', 'A', '13T7595');

-- /////////////////////////////////////////////


-- to fetch student name

Select Users.Name1 from Users
where Users.Username =

-- to fetch student data

Select Student.Email, Student.Degree, Student.DOB as 'Date Of Birth', Student.MobileNo, Student.Address1 as 'Address', Student.CNIC from Student
where Student.Username = 

-- //////////////////////////////////////////////

select * from Feedback

-- fetch course for drop down

Select Registers.Course from Registers
where Registers.StudentID = 

-- fetch section to insert 

Select Registers.Section from Registers
where Registers.StudentID = 
and Registers.Course = 

-- fetch instructor name to insert

Select Section.Instructor from Section
where Section.Course = 
and Section.Sec_Name = 

-- check if student has already given feeback or not

Select * from Feedback
where Feedback.StudentID = 
and Feedback.Course = 
and Feedback.Section = 


-- if not given feedback insert

Insert into Feedback Values
('', '', '', '', '', int, '');		-- studentid, instructorid, course, section, date, percentage, comment



-- query to find course records of student
-- use same query to first check if any record exists or not(if no record exists gpa will be 0)
Select Course, Grade from Record
where Record.Student_Name = ''

Select Course.CreditHrs from Course
where Course.CourseID = ;

---------------------------------

Select SUM(Feedback.Percentage_F) / COUNT(*) as 'Feedback Percentage' from Feedback
where Feedback.Course = ''
and Feedback.Section = ''
and Feedback.FacultyID = ''


Select Feedback.Comment from Feedback
where Feedback.Course = ''
and Feedback.Section = ''
and Feedback.FacultyID = ''

Select * from Attendance