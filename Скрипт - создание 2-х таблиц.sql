/****** Скрипт для команды SelectTopNRows из среды SSMS  ******/
CREATE TABLE CONTAINER(
id INT IDENTITY PRIMARY KEY NOT NULL,
Number FLOAT NOT NULL,
Type VARCHAR(100) NOT NULL,
Length FLOAT NOT NULL,
Width FLOAT NOT NULL,
Height FLOAT NOT NULL,
Weight FLOAT NOT NULL,
EmptyNotEmpty bit NOT NULL,
DateOfReceipt smalldatetime NOT NULL);


CREATE TABLE OPERATIONS(
id INT IDENTITY NOT NULL,
Id_container INT,
StartDateOfTheOperation smalldatetime NOT NULL,
EndDateOfTheOperation smalldatetime NOT NULL,
Type_operation VARCHAR(100) NOT NULL,
Operator_name VARCHAR(50) NOT NULL,
PlaceOfInspection VARCHAR(256) NOT NULL,
FOREIGN KEY(Id_container) REFERENCES container(id),
PRIMARY KEY (id,Id_container));
