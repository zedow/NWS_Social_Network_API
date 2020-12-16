# NWS_Social_Network API
 Projet éducatif dont le but est de développer une application web faisant office de réseau social pour l'école.
 
 Base de données MySQL localhost, les données de connexion sont établies dans le fichier appsettings.json si la configuration doit être changée
 
 Run "dotnet ef database update <Migration>" pour mettre à jour la base de données

## Lancer le backend
Il faut aller dans le repertoire ou le code est présent (NWSSocial), veiller à ce qu'aucune base mysql ne soit lancer (via wamp ou autres) et lancer cette commande :
```bash
docker-compose up -d
```
L'application est maintenant lancée et accessible via le port 8081

## Mettre à jour la base de données avec docker
Récupérez l'id du container via la commande suivante
```bash
docker ps
```

Lancez ensuite cette commande pour lancer les migrations
```bash
docker exec -it "ID DU CONTAINER" dotnet ef database update <Migration> 
```

## Accéder à PHPMyAdmin
il suffit d'aller sur l'url : http://localhost:8000/

## Seed la database
Pour ajouter des données tests à l'api, il existe un dossier Seed, avec une classe de seeding par modèle (Entité dans la base de données), et une classe static DbSeed, qui lance le seeding de toutes les classes citées précédemment dans l'ordre désiré.

## Requêtes paginées
Depuis la factorisation du code, les requêtes paginées nécessitent un body, même lorsque la pagination n'est pas nécessaire (body vide).
