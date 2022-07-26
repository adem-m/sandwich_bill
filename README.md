# Sandwicherie Francky Vincent  
Étudiants: Paul BARRIÉ, Paolo MANAOIS, Adem MRIZAK  

## Utilisation  
```
dotnet run --project client
```  

## Commande du CLI  
Quand le boss Francky vous demandera votre commande, voici les formats possibles:  
```
pour un sandwich normal
<quantité> <nom sandwich> -o [xml|json|console|text]

pour un sandwich custom
<quantité> <ingrédientA>:<quantitéA> ... <ingrédientN>:<quantitéN> -o [xml|json|console|text]

pour un fichier avec les commandes
<chemin du fichier> -o [xml|json|console|text]
```  
Vous pouvez combiner les commandes de sandwichs normaux et customs avec une séparation par virgule ;)