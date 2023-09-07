# CarRent von Patrick Nef

## Big Picture

### Context-Diagramm

Es soll ein neues Autovermeitungssystem "CarRent" erstellt werden. Von folgenden Benutzern soll das System verwendet werden können.
- Sachbearbeiter
- Kunde

Es soll in den bereits bestehenden Web-Server integriert werden. Somit wird es bei der CarRent-Software um eine Webapplikation handeln.

![](docs/Images/Context.png)

### Container

Da der bereits bestehende Web-Server verwendet werden soll, wird es sich bei der CarRent-Software defintiiv um eine Webapplikation handeln.
Der Sachbearbeiter verwendet die Webapplikation CarRent. Die Software lädt und bearbeitet die Daten über eine API. Die API selbst lädt die Daten aus der Datenbank oder schreibt diese auf die Datenbank.
Code muss in allen Containern geschrieben werden, wobei der Code für die Datenbank, in den API-Aufrüfen verwendet werden wird.

![](docs/Images/Container.png)

### Components

Das System besteht aus den in folgendem Bild sichtbaren Komponenten.

![](docs/Images/Components.png)

### Domain Model

![](docs/Images/Domain_Model.png)