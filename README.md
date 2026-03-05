# GuildManager

Projet mélangeant une API REST développée avec ASP.NET Core et une application Unity.
Permet de gérer une guilde d'aventuriers : création, modification et suppression de personnages.
Projet réalisé dans le cadre de mon portfolio pour démontrer mes compétences en .NET et architecture backend.

## Fonctionnalités

### API REST

- Gestion des Personnages (Création, Récupération, Modification, Suppression)
- Récupération des données persistantes (Equipement, Race, Job)

### Application Unity

- Récupération des données persistantes au lancement
- Récupération et affichage des Personnages
- Création de Personnage
- Modification de Personnage
- Suppression de Personnage

## Stack technique

### API REST

- .NET 10.0
- ASP.NET Core
- Entity Framework Core
- SQLite

### Application Unity

- Unity 6.3

## Architecture du projet

Le projet se divise en 2 projets :
- API REST pour la partie back-end
- Application Unity pour la partie front-end

### API REST

Architecture :
- Controllers --> Gère les requêtes HTTP. Récupère les données sous forme de DTO et les envois au service sous forme de Command
- Services --> Récupère les Command, les mappe en Domain et applique la logique métier, puis les envoi au Repositories sous forme de Model
- Repositories --> Gère la base de donnée à partir du Model reçu

Flux de données :

DTO (Controller)
   ↓
Command (Service)
   ↓
Domain (Logique métier)
   ↓
Model (Persistence)

## Installation et lancement

### API

git clone https://github.com/username/guildmanager.git

cd GuildManager/Server/GuildManagerServer

dotnet restore

dotnet ef database update

dotnet run

#### Accès à l'API

Une fois l'API lancée, elle est accessible à l'adresse :

http://localhost:5181

### Application Unity

Ouvrir le dossier `UnityClient` avec Unity Hub.

## Aperçu

![Screenshot](docs/screenshot.png)

## Objectif

Ce projet a pour but de démontrer :

- la création d'une API REST avec ASP.NET Core
- une architecture backend en couches
- l'utilisation d'Entity Framework Core
- la consommation d'une API depuis une application Unity

## Améliorations

Plus tard, on pourrait rajouter :

- Authentification JWT
- Pagination / Filtres des Personnages (Job, Race, ...)
- Système de combat basique côté serveur

## Choix techniques

### SQLite

SQLite a été choisi pour ce projet car il permet de mettre en place rapidement une base de données légère, idéale pour un projet de démonstration.

## Exemple d'utilisation de l'API

### Récupérer tous les Personnages
GET http://localhost:5181/api/Character

### Récupérer toutes les Races
GET http://localhost:5181/api/Race

### Récupérer tous les Jobs
GET http://localhost:5181/api/Job

### Récupérer tous les Équipements
GET http://localhost:5181/api/Equipment

### Récupérer un Personnage
GET http://localhost:5181/api/Character/Details/1 (Récupère les données calculées d'un Personnage)
GET http://localhost:5181/api/Character/Raw/1 (Récupère les données non calculées d'un Personnage)
GET http://localhost:5181/api/Character/Resume/1 (Récupère un résumé des données d'un Personnage)

### Créer un Personnage
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

### Modifier un Personnage
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

### Supprimer un Personnage
DELETE http://localhost:5181/api/Character/1

## Auteur

Nom Prénom  
Développeur C# d'applications interactives en transition vers .NET

LinkedIn : https://linkedin.com/in/username  
Portfolio : https://username.dev