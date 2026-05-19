# Guild Manager

Project combining a REST API developed with ASP.NET Core and a Unity application.  
Allows users to manage a guild of adventurers: creating, editing, and deleting characters.  
This project was created as part of my portfolio to demonstrate my skills in .NET and backend architecture.

## Features

### REST API

- Character management (Create, Read, Update, Delete)
- Retrieval of persistent data (Equipment, Race, Job)

### Unity Application

- Retrieval of persistent data at startup
- Fetching and displaying characters
- Character creation
- Character editing
- Character deletion

\## Tech Stack

\### REST API

- .NET 10.0
- ASP.NET Core
- Entity Framework Core
- SQLite

### Unity Application

- Unity 6.3

## Project Architecture

The project is split into 2 parts:
- REST API for the backend
- Unity application for the frontend

### REST API

Architecture:

- Controllers → Handle HTTP requests. Receive data as DTOs and send it to services as Commands
- Services → Receive Commands, map them to Domain objects, apply business logic, then send them to repositories as Models
- Repositories → Handle database operations using Models

Data flow:

DTO (Controller) → Command (Service) → Domain (Business logic) → Model (Persistence)

## Installation and Launch

### API

git clone https://github.com/Linkazer/GuildManager.git

cd GuildManager/Server/GuildManagerServer

dotnet restore

dotnet ef database update

dotnet run

#### Accessing the API

Once the API is launched, it can be accessed at:

http://localhost:5181

### Unity Application

#### Using the executable

Run the executable in the ‘UnityClient\\Build’ folder.

#### Using the Unity Editor

Open the ‘UnityClient’ folder using Unity Hub.

## Objective
This project aims to demonstrate :

- building a REST API with ASP.NET Core
- a layered backend architecture
- the use of Entity Framework Core
- consuming an API from a Unity application

## Improvements

In the future, we could add :

- JWT authentication
- pagination / filtering of characters (Job, Race, etc.)
- a basic server-side combat system

## Technical Choices

### SQLite

SQLite was chosen for this project because it allows for the quick setup of a lightweight database, making it ideal for a demonstration project.

## Example API Usage

### Retrieve all Characters

GET http://localhost:5181/api/Character

### Retrieve all Races

GET http://localhost:5181/api/Race

### Retrieve all Jobs

GET http://localhost:5181/api/Job

### Retrieve all Equipments

GET http://localhost:5181/api/Equipment

### Retrieve a Character
GET http://localhost:5181/api/Character/Details/1 (Retrieves the calculated data for a character)
GET http://localhost:5181/api/Character/Raw/1 (Retrieves the uncalculated data for a Character)
GET http://localhost:5181/api/Character/Resume/1 (Retrieves a summary of a Character's data)

### Create a Character
POST http://localhost:5181/api/Character
Content-Type: application/json

{
  "Name": "Eliza",
  "RaceId": 2,
  "JobId": 3,
  "Level": 1,
  "Strength": -1,
  "Spirit": 2,
  "Presence": 1,
  "Dexterity": 0,
  "Instinct": 0,
  "BodyId": 1,
  "HairId": 4,
  "HairColorId": 3,
  "EquipmentId": 1
}

### Modify a Character
PUT http://localhost:5181/api/Character/1
Content-Type: application/json

{
  "Name": "Thomas",
  "RaceId": 1,
  "JobId": 1,
  "Level": 1,
  "Strength": 2,
  "Spirit": 0,
  "Presence": -1,
  "Dexterity": 1,
  "Instinct": 0,
  "BodyId": 3,
  "HairId": 2,
  "HairColorId": 5,
  "EquipmentId": 1
}

### Delete a Character
DELETE http://localhost:5181/api/Character/1

## Overview

<img width="1282" height="752" alt="image" src="https://github.com/user-attachments/assets/0c51fa95-3eda-44c4-be5b-50f7406dc861" />

## Author

Lafranche Timothé

Portfolio : https://timothelafranche.wixsite.com/portfolio/eng