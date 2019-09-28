#---------------------------------------------------------------
# Conversion binaire vers décimale
# ISN Montesquieu
# Thème ' Codage de l'information'
#---------------------------------------------------------------

# Initialisation des variables
nombreDec = 0
nombreBin = ""

# Récupération du binaire à convertir
nombreBin = input("Entrez un nombre binaire (en base 2) ")
longueurBin =len(nombreBin)
# Conversion
#------ Ecrire ici le script de conversion----
for i in range(0,longueurBin-1):
    nombreDec = nombreDec + 2^(longueurBin - i)*(int(nombreBin[i]))
# --------------------------------------------

# Affichage du résultat
print (nombreBin, " s'écrit ", nombreDec, " en binaire.")
