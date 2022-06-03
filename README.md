# Travel With Me
## Table of Contents
* [Background](#background)
* [Requirement](#requirement)
* [Feature](#feature)
* [Creator](#creator)

## Background
<img src="https://github.com/Bayunova28/Travel_With_Me/blob/master/UAS/cover.png" height="450" width="1100">
<p align="justify">TravelWithMe is an airline ticket buying and selling service. On the official website, it says that TravelWithMe is a ticket reservation system that 
is integrated with the airline's own booking system, through trusted partners. By providing ticket transaction security as well as ease of ordering through an automated system, without having to go through manual ordering. TravelWIthMe collaborates with official travel agents for airlines that are trusted to issue tickets. This allows consumers who will order tickets to get preferred seller choice, as well as guaranteed comfort and safety. The airlines that collaborate with TravelWithMe in issuing tickets include are Merpati, Garuda, Lion Air, Air Asia. Tiger Water, etc.</p>

## Requirement
### Database
<img src="https://github.com/Bayunova28/Travel_With_Me/blob/master/UAS/erd.png" height="500" width="800">

```mysql
-- create database travel with me
CREATE DATABASE Travel_With_Me;
  
-- create table customer
CREATE TABLE Customer (
  Customer_ID INT NOT NULL PRIMARY KEY,
  Nama VARCHAR(50) NOT NULL,
  Tujuan VARCHAR(30) NOT NULL,
  Jenis_Airline VARCHAR(30) NOT NULL,
  Jenis_Tiket VARCHAR(30) NOT NULL,
  Jumlah INT NOT NULL,
  Total_Biaya INT NOT NULL,
  Payment VARCHAR(10) NOT NULL);

-- create table destination
CREATE TABLE Destination (
  Destination_ID INT NOT NULL PRIMARY KEY,
  Customer_ID INT NOT NULL,
  Tujuan VARCHAR(30) NOT NULL,
  Jenis_Airline VARCHAR(30) NOT NULL,
  FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID));
  
-- create table system
CREATE TABLE System (
  Order_ID INT NOT NULL PRIMARY KEY,
  Customer_ID INT NOT NULL,
  Admin VARCHAR(20) NOT NULL,
  Staff VARCHAR(20) NOT NULL,
  FOREIGN KEY (Customer_ID) REFERENCES Customer(Customer_ID));
 
-- create table invoice
CREATE TABLE Invoice (
  Invoice_ID INT NOT NULL PRIMARY KEY,
  Order_ID INT NOT NULL,
  Jenis_Tiket VARCHAR(30) NOT NULL,
  Jumlah INT NOT NULL,
  Destination VARCHAR(20) NOT NULL,
  Total_Biaya INT NOT NULL,
  FOREIGN KEY (Order_ID) REFERENCES System(Order_ID));
```

## Feature
* Login & Logout
* Signup
* CRUD Database (Create, Read, Update & Delete)
* Generate File Report

## Creator
* Elisabet Dela Marcela
* James Tutan
* Reny Regita Rosari
* Willibrordus Bayu
