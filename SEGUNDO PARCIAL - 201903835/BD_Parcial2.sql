CREATE DATABASE PROBLEMA1;

USE PROBLEMA1;

CREATE TABLE Vuelo(
Codigo INTEGER PRIMARY KEY IDENTITY(1,1),
Subtotal INTEGER,
Descuento FLOAT,
Total FLOAT
);


SELECT * FROM Vuelo