BEGIN TRANSACTION;
CREATE TABLE IF NOT EXISTS "SERVICE_STATION" (
	"id"	integer,
	"Name"	varchar(20),
	"Address"	varchar(20),
	"Phone"	integer,
	"Working_hours"	integer,
	PRIMARY KEY("id")
);
CREATE TABLE IF NOT EXISTS "EMPLOYEE" (
	"id"	integer,
	"Name"	varchar(20),
	"Position"	varchar(20),
	"Salary"	integer,
	"Working_hours"	integer,
	PRIMARY KEY("id")
);
CREATE TABLE IF NOT EXISTS "SERVICE" (
	"id"	integer,
	"Name"	varchar(20),
	"price"	integer,
	PRIMARY KEY("id")
);
CREATE TABLE IF NOT EXISTS "MOTORIST" (
	"id"	integer,
	"Name"	varchar(20),
	"Address"	varchar(20),
	"Phone"	integer,
	"Driving_license_number"	integer,
	PRIMARY KEY("id")
);
CREATE TABLE IF NOT EXISTS "INVOICE" (
	"id"	integer,
	"Date"	varchar(20),
	"Amount"	integer,
	PRIMARY KEY("id")
);
INSERT INTO "SERVICE_STATION" VALUES (1,'Beaty','Tele 5',45686869,8);
INSERT INTO "SERVICE_STATION" VALUES (2,'Shit','Cool 3',234567834,2);
INSERT INTO "SERVICE_STATION" VALUES (3,'Unlimited ','Null 3',23546789,5);
INSERT INTO "EMPLOYEE" VALUES (1,'Greg Blask','mechanic',30000,40);
INSERT INTO "EMPLOYEE" VALUES (2,'Simon Hunter','technical',32000,35);
INSERT INTO "EMPLOYEE" VALUES (3,'Alex Parker','mechanic ',25000,35);
INSERT INTO "SERVICE" VALUES (1,'Replace oil ',500);
INSERT INTO "SERVICE" VALUES (2,'Wash car',250);
INSERT INTO "SERVICE" VALUES (3,'Destroy car',1000000);
INSERT INTO "MOTORIST" VALUES (1,'Bob Chief ','Solomka 4',66666666,567835476465);
INSERT INTO "MOTORIST" VALUES (2,'Taylor Kor','Home',998857544,214455655786);
INSERT INTO "MOTORIST" VALUES (3,'Hell Red','Line 4',32547389,874398760375);
INSERT INTO "INVOICE" VALUES (1,'2023-01-23',1);
INSERT INTO "INVOICE" VALUES (2,'2023-01-15',2);
INSERT INTO "INVOICE" VALUES (3,'2023-02-02',1);
COMMIT;
