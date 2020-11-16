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
Pour ajouter des données tests à l'api, il existe une classe "PrepDB" dans les models, qui permet de run la dernière migration au lancement de l'api, et de seed des data pour pour les entités sans données. Il est recommandé d'y ajouter ses données de tests afin que tout le monde puisse en profiter.
