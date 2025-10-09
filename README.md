# BoodschappenApp Sprint 5 - Peter Tarcsai s1188507

## Branching strategie (Gitflow)

Ik gebruik **Gitflow** als branching strategie:

- **`main`**  
  Bevat de meest stabiele productiecode, met alleen getest en goedgekeurde code. 
  Wordt gebruik als basis voor het maken van de echte Release.  

- **`develop`**  
  Hier worden alle nieuwe features samengebracht na het mergen van de Use Case feature branches. 

- **`feature/*`**  
  Voor iedere Use Case wordt een aparte feature branch aangemaakt vanaf `develop`.  
  Na afronding wordt deze terug gemerged in `develop`.  

- **`release`**  
  Wordt gemaakt vanuit `develop` en wordt gebruikt voor een laatste check voordat naar main gepusht kan worden.  

- **`hotfix`**  
  Wordt gemaakt vanuit `main` om urgente bugs direct te kunnen oplossen.  
  Na fixen wordt de branch terug gemerged naar `main` of eventueel `develop`.  

---

## Projectstructuur
Projectstructuur is uitgewerkt volgens **Clean Architecture**
- `Grocery.App`: Views en ViewModels **(MVVM)**
- `Grocery.Core`: Modellen en Services
- `Grocery.Core.Data`: Repositories
- `TestCore`: Unit tests

---

## Use Cases van release

### UC12 Toevoegen Categorieën
Compleet. Verder testen.

### UC14 Toevoegen prijs
Compleet.

### UC15 Toevoegen THT datum  
Compleet. 
