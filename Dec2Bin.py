#---------------------------------------------------------------
# Conversion décimal vers binaire
# ISN Montesquieu
# Thème ' Codage de l'information'
#---------------------------------------------------------------

# Initialisation des variables
nombreDec = 0
nombreBin = ""

# Récupération du décimal à convertir
nombreDec = int(input("Entrez un entier positif (en base 10) "))
nombre = nombreDec
# Conversion
#------ Ecrire ici le script de conversion----
while nombre >= 1:
    nombreBin = str(nombre%2) + nombreBin
##    print(nombre%2)
##    print("nombre =",nombreBin)
    if nombre%2 == 1:
        nombre = int((nombre-1)/2)
    else:
        nombre = int(nombre/2)
##    print("nombre =",nombre)


# --------------------------------------------

# Affichage du résultat
print (nombreDec, " s'écrit ", nombreBin, " en binaire.")
