using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TP2_Minecraft
{
    internal class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Veuillez mettre cette page en plein ecran pour une meilleure experience.");
            Console.ReadLine();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGray;

            MenuChargement();
        }


        static void ProgrammeCoffre()
        {


            // VOTRE CODE (n'oublier pas de bien le commenter)

            // ===========================================================================================
            // 2.Lecture du fichier inventaire_depart.txt et chargement des données dans votre programme (variables vecteurs)
            // ===========================================================================================

            // VOTRE CODE (n'oublier pas de bien le commenter)

            string cheminAccesFichier = @"C:\data\420-04A-FX\inventaire_depart.txt";

            StreamReader fichierEnEntree = new StreamReader(cheminAccesFichier);


            // =========================================================================================
            // 3.Affichage de l'inventaire une fois chargé dans votre programme
            // =========================================================================================

            // VOTRE CODE (n'oublier pas de bien le commenter)

            string lireLigne;

            // Creer un vecteur item
            string[] item = new string[9];
            // Lis la ligne des items
            lireLigne = fichierEnEntree.ReadLine();
            // Separe les item de les ";"
            item = lireLigne.Split(';');

            // Creer un vecteur durabilite
            string[] durabilite = new string[9];
            // Lis la ligne des durabilites
            lireLigne = fichierEnEntree.ReadLine();
            // Separe les durabilite de les ";"
            durabilite = lireLigne.Split(';');

            // Creer un vecteur force
            string[] force = new string[9];
            // Lis la ligne des force
            lireLigne = fichierEnEntree.ReadLine();
            // Separe les force de les ";"
            force = lireLigne.Split(';');

            // Change couleur en gray
            Console.ForegroundColor = ConsoleColor.DarkGray;

            //Petite interface
            Console.WriteLine("======================");
            Console.WriteLine("Voici votre inventaire");
            Console.WriteLine("======================");
            Console.WriteLine("");

            // Boucle qui parcours le fichier ligne par ligne
            for (int i = 0; i < item.Length; i++)
            {
                //Ecrit les items, les durabilites et les forces
                Console.ForegroundColor = ConsoleColor.DarkGray; Console.WriteLine("Nom de l'objet: " + item[i] + " | Durabilité de l'objet: " + durabilite[i] + " | Force de l'objet: " + force[i]);
            }

            Console.WriteLine("");
            Console.WriteLine("");


            // ============================================================================
            // 4.Calcul et affichage de la FORCE DE DOMMAGE TOTALE COMBINÉE de tous les items
            // ============================================================================

            // VOTRE CODE (n'oublier pas de bien le commenter)

            // Creation dune variable forceTotale qui est definie a 0
            int forceTotale = 0;

            // Boucle qui parcours une seule ligne
            for (int i = 0; i < force.Length; i++)
            {
                // Aditionne les forces
                forceTotale = forceTotale + Convert.ToInt32(force[i]);
            }
            Console.WriteLine("======================");
            Console.WriteLine("Force totale des items");
            Console.WriteLine("======================");
            Console.WriteLine("");
            // Ecrit l'adition des forces totales
            Console.WriteLine("Force totale: " + forceTotale);
            Console.WriteLine("");

            // ============================================================================
            // 5.Items ayant une durabilité de moins de 50 %
            // ============================================================================

            // VOTRE CODE (n'oublier pas de bien le commenter)

            Console.WriteLine("==========================================");
            Console.WriteLine("Item avec une durabilite en dessous de 50%");
            Console.WriteLine("==========================================");
            Console.WriteLine("");


            // Parcours le fichier ligne d'une ligne
            for (int i = 0; i < durabilite.Length; i++)
            {
                // Tous les items avec une durabilite en dessous de 50 : 
                if (Convert.ToInt32(durabilite[i]) < 50)
                {

                    // Ecrit les item
                    Console.Write(item[i] + " | ");
                }
            }

            Console.WriteLine();

            // ============================================================================
            // 6.Déterminer si un item en particulier est présent dans l’inventaire 
            // ============================================================================

            // VOTRE CODE (n'oublier pas de bien le commenter)

            // Creation de variables pour recherche item
            string itemRechercher;
            // Creer une variable itemRecherche designer a 0
            int itemRecherche = 0;

            Console.WriteLine("=======================================");
            Console.WriteLine("Recherche d'item à travers l'inventaire");
            Console.WriteLine("=======================================");
            Console.WriteLine("");

            Console.Write("Item que vous voulez rechercher? : ");
            // Enregistre l'item rechercher avec la variable itemRecherche
            itemRechercher = Console.ReadLine();

            // Boucle qui parcours le code
            for (int i = 0; i < item.Length; i++)
            {
                // Si l'item rechercher est pareil qu'un item dans le code
                if (itemRechercher == item[i])
                {
                    // Ecrit que l'item est present
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("L'item est bien présent dans l'inventaire!");
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                // Sinon l'item rechercher n'existe pas, ca ajoute dans un compteur 1 9 fois alors 9
                else if (itemRechercher != item[i])
                {
                    
                    itemRecherche++;
                }
            }

            // Si la variable item rechercher a un compteur de 9, ecrit cela
            if (itemRecherche >= 9)
            {
                // Message que l'item n'est pas present
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("L'item n'est pas présent dans l'inventaire!");
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

            Console.ReadLine();

            // =========================================================================================
            // 7.MODE CRÉATIF ! : Modification des durabilités et forces de chaque item par l'utilisateur.
            // =========================================================================================

            // VOTRE CODE (n'oublier pas de bien le commenter)

            // Creation de variables
            string itemModifier, modification;
            // Creation de variables definie a 0
            int itemModifierExistePas = 0, nouvelItemErreur = 0;

            Console.Write("Quel item voulez-vous modifier? : ");
            // Sauvegarde dans le code l'item choisi pour le modifier
            itemModifier = Console.ReadLine();

            // Parcours le fichier pour trouver l'item
            for (int i = 0; i < item.Length; i++)
            {
                // Si l'item choisi est dans le fichier, fait cela
                if (itemModifier == item[i])
                {

                    Console.WriteLine("L'item (" + item[i] + ") à une durabilité de " + durabilite[i] + " et une force de " + force[i]);
                    Console.ReadLine();
                    Console.Write("Que souhaitez vous modifier dans cet item? (Durabilité, Force OU Les deux) : ");
                    // Sauvegarde dans le code ce qu'on veut modifier
                    modification = Console.ReadLine();

                    // Si la personne a ecrit Durabilité, fais cela
                    if (modification == "Durabilité")
                    {
                        Console.Write("Quelle durabilité voulez-vous mettre à cet item? (Entre 0 et 100): ");
                        // Enregistre la nouvelle durabilite dans le vecteur
                        durabilite[i] = Console.ReadLine();
                        Console.Write("Vos modification ont été sauvegarder: ");
                    }
                    // Si la personne a ecrit Force, fais cela
                    else if (modification == "Force")
                    {
                        Console.Write("Quelle force voulez-vous mettre à cet item? (Entre 0 et 10): ");
                        // Enregistre la nouvelle force dans le vecteur
                        force[i] = Console.ReadLine();
                        Console.Write("Vos modification ont été sauvegarder: ");

                    }
                    // Si la personne a ecrit Les deux, fais cela
                    else if (modification == "Les deux")
                    {
                        Console.Write("Quelle durabilité voulez-vous mettre à cet item? (Entre 0 et 100): ");
                        // Enregistre la nouvelle durabilite dans le vecteur
                        durabilite[i] = Console.ReadLine();
                        Console.Write("Quelle Force voulez-vous mettre à cet item? (Entre 0 et 10): ");
                        // Enregistre la nouvelle force dans le vecteur
                        force[i] = Console.ReadLine();
                        Console.Write("Vos modification ont été sauvegarder: ");
                    }
                    else
                    {
                        // Si ce que l'on veut changer n'existe pas, +1 
                        nouvelItemErreur++;
                    }
                }

                // Si l'item que l'on veut modifier n'est pas dans le fichier, +1
                else if (itemModifier != item[i])
                {
                    itemModifierExistePas++;
                }
            }

            // Si la variable itemModifierExistePas a un compteur de 9, fais cela
            if (itemModifierExistePas >= 9) {

                // Message que item introuvable
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Item introuvable, il ne peut donc pas etre modifié!");
                    Console.ForegroundColor= ConsoleColor.DarkGray;
            }

            // Si la variable nouvelItemErreur a un compteur de 1, fais cela
            else if (nouvelItemErreur >= 1)
            {
                // Message erreur que modification impossible
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cette modification est impossible!");
                Console.ForegroundColor = ConsoleColor.DarkGray;
            }

            
            // Ferme le fichier
            fichierEnEntree.Close();
            Console.ReadKey();
 
        // =================================================================================================
        // 8.Enregistrement des modifications dans UN NOUVEAU FICHIER 
        // =================================================================================================

            // Trouve le chemin d'acces et creer un nouveau fichier
        string cheminFichierSortie = @"C:\data\420-04A-FX\inventaire_modifier.txt";
        StreamWriter fichierSortie = new StreamWriter(cheminFichierSortie);

            // Parcours le premier fichier
            for (int i = 0; i < item.Length; i++)
            {
                // Reecris tous les items
                fichierSortie.Write(item[i] + ";");
            }

            // Saut de ligne
                fichierSortie.WriteLine();

            // Parcours le premier fichier
            for (int i = 0; i < item.Length; i++)
            {
                // Reecris toutes les durabilites et modifie celle choisi au paravant
                fichierSortie.Write(durabilite[i] + ";");
            }

            // Saut de ligne
            fichierSortie.WriteLine();

            // Parcours le premier fichier
            for (int i = 0; i < item.Length; i++)
            {
                // Reecris toutes les force et modifie celle choisi au paravant
                fichierSortie.Write(force[i] + ";");
            }

            // Ferme le fichier
            fichierSortie.Close();
            // VOTRE CODE (n'oublier pas de bien le commenter) 
        }










        // ===========================================================================
        // 1.Création de l’en-tête du programme. Présentation, visuel, etc. 
        // ===========================================================================

        static void MenuChargement()
        {
            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 	          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@".........."); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                      ...                   ..                        ...               =
	     =         "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"-************+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@%=     .*@%.  .*%@@@@@#=. -%@@@@@@-    -@@+     =@#:    *@*.  -*%@@@@%#=            =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=***+++***"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"***+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@+.  :#@@%. +@@#-:.:=#@%- ....=%@-   .%@@@-    =@@%=   *@*..*@@+-..:+%@#:          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". .---"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@".-"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@@*.-%@@@%.=@@-      .+@%:    :#@-   #@#*@%.   =@@@@+..*@*.*@%:   .  ....          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"*****"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"-."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#=#@@@@=*@%.#@#        :%@=    :#@-  +@@: %@*   +@#=%@*:*@*-%@+   *@@@@@@%-         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"******+**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:.*@%- +@%.+@@.       -@%-    -#@- :%@%**#@@= .+@#.:#@%%@*:#@*.  :----*@%:         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". :"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*******+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%..#@@-.   .=@@+    .*@%..%@%#####@%: +@#. .+@@@*.-%@#:    :*@%=          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%.  +@@@@@@@@%= -%@@@@#: *@%.     #@%.=@#.   =@@*. .#@@@@@@@@#:           =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" -++++++++++=:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"   .=-.      :--     .=**+-.   .--:.   .-=.      .==::=-     :-:     :+**+:             =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =   .---------------------------------------:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::-:    =
             =   ."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" +*************************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                                                                          :.  =
             =   .=+++++++++++++++++++++++++++++++++++=:::...........................................................-:-.   =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

            Thread.Sleep(750);
            Console.Clear();

            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 	          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@".........."); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                      ...                   ..                        ...               =
	     =         "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"-************+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@%=     .*@%.  .*%@@@@@#=. -%@@@@@@-    -@@+     =@#:    *@*.  -*%@@@@%#=            =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=***+++***"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"***+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@+.  :#@@%. +@@#-:.:=#@%- ....=%@-   .%@@@-    =@@%=   *@*..*@@+-..:+%@#:          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". .---"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@".-"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@@*.-%@@@%.=@@-      .+@%:    :#@-   #@#*@%.   =@@@@+..*@*.*@%:   .  ....          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"*****"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"-."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#=#@@@@=*@%.#@#        :%@=    :#@-  +@@: %@*   +@#=%@*:*@*-%@+   *@@@@@@%-         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"******+**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:.*@%- +@%.+@@.       -@%-    -#@- :%@%**#@@= .+@#.:#@%%@*:#@*.  :----*@%:         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". :"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*******+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%..#@@-.   .=@@+    .*@%..%@%#####@%: +@#. .+@@@*.-%@#:    :*@%=          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%.  +@@@@@@@@%= -%@@@@#: *@%.     #@%.=@#.   =@@*. .#@@@@@@@@#:           =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" -++++++++++=:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"   .=-.      :--     .=**+-.   .--:.   .-=.      .==::=-     :-:     :+**+:             =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =   .---------------------------------------:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::-:    =
             =   ."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" +*********************************************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                                                      :.  =
             =   .=+++++++++++++++++++++++++++++++++++=:::...........................................................-:-.   =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

            Thread.Sleep(750);
            Console.Clear();

            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 	          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@".........."); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                      ...                   ..                        ...               =
	     =         "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"-************+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@%=     .*@%.  .*%@@@@@#=. -%@@@@@@-    -@@+     =@#:    *@*.  -*%@@@@%#=            =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=***+++***"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"***+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@+.  :#@@%. +@@#-:.:=#@%- ....=%@-   .%@@@-    =@@%=   *@*..*@@+-..:+%@#:          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". .---"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@".-"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@@*.-%@@@%.=@@-      .+@%:    :#@-   #@#*@%.   =@@@@+..*@*.*@%:   .  ....          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"*****"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"-."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#=#@@@@=*@%.#@#        :%@=    :#@-  +@@: %@*   +@#=%@*:*@*-%@+   *@@@@@@%-         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"******+**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:.*@%- +@%.+@@.       -@%-    -#@- :%@%**#@@= .+@#.:#@%%@*:#@*.  :----*@%:         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". :"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*******+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%..#@@-.   .=@@+    .*@%..%@%#####@%: +@#. .+@@@*.-%@#:    :*@%=          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%.  +@@@@@@@@%= -%@@@@#: *@%.     #@%.=@#.   =@@*. .#@@@@@@@@#:           =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" -++++++++++=:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"   .=-.      :--     .=**+-.   .--:.   .-=.      .==::=-     :-:     :+**+:             =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =   .---------------------------------------:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::-:    =
             =   ."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" +*****************************************************************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                                  :.  =
             =   .=+++++++++++++++++++++++++++++++++++=:::...........................................................-:-.   =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

            Thread.Sleep(750);
            Console.Clear();

            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 	          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@".........."); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                      ...                   ..                        ...               =
	     =         "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"-************+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@%=     .*@%.  .*%@@@@@#=. -%@@@@@@-    -@@+     =@#:    *@*.  -*%@@@@%#=            =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=***+++***"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"***+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@+.  :#@@%. +@@#-:.:=#@%- ....=%@-   .%@@@-    =@@%=   *@*..*@@+-..:+%@#:          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". .---"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@".-"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@@*.-%@@@%.=@@-      .+@%:    :#@-   #@#*@%.   =@@@@+..*@*.*@%:   .  ....          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"*****"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"-."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#=#@@@@=*@%.#@#        :%@=    :#@-  +@@: %@*   +@#=%@*:*@*-%@+   *@@@@@@%-         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"******+**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:.*@%- +@%.+@@.       -@%-    -#@- :%@%**#@@= .+@#.:#@%%@*:#@*.  :----*@%:         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". :"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*******+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%..#@@-.   .=@@+    .*@%..%@%#####@%: +@#. .+@@@*.-%@#:    :*@%=          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%.  +@@@@@@@@%= -%@@@@#: *@%.     #@%.=@#.   =@@*. .#@@@@@@@@#:           =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" -++++++++++=:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"   .=-.      :--     .=**+-.   .--:.   .-=.      .==::=-     :-:     :+**+:             =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =   .---------------------------------------:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::-:    =
             =   ."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" +***************************************************************************************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"            :.  =
             =   .=+++++++++++++++++++++++++++++++++++=:::...........................................................-:-.   =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");
            Thread.Sleep(750);
            Console.Clear();

            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 	          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@".........."); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                      ...                   ..                        ...               =
	     =         "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"-************+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@%=     .*@%.  .*%@@@@@#=. -%@@@@@@-    -@@+     =@#:    *@*.  -*%@@@@%#=            =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=***+++***"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"***+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@+.  :#@@%. +@@#-:.:=#@%- ....=%@-   .%@@@-    =@@%=   *@*..*@@+-..:+%@#:          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". .---"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@".-"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@@@@*.-%@@@%.=@@-      .+@%:    :#@-   #@#*@%.   =@@@@+..*@*.*@%:   .  ....          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"*****"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"-."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#=#@@@@=*@%.#@#        :%@=    :#@-  +@@: %@*   +@#=%@*:*@*-%@+   *@@@@@@%-         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"******+**+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:.*@%- +@%.+@@.       -@%-    -#@- :%@%**#@@= .+@#.:#@%%@*:#@*.  :----*@%:         =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@". :"); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*******+"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%..#@@-.   .=@@+    .*@%..%@%#####@%: +@#. .+@@@*.-%@#:    :*@%=          =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"+*************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@" -@#:      +@%.  +@@@@@@@@%= -%@@@@#: *@%.     #@%.=@#.   =@@*. .#@@@@@@@@#:           =
	     =	      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" -++++++++++=:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"   .=-.      :--     .=**+-.   .--:.   .-=.      .==::=-     :-:     :+**+:             =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =   .---------------------------------------:::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::-:    =
             =   ."); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@" +***************************************************************************************************:"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@":.  =
             =   .=+++++++++++++++++++++++++++++++++++=:::...........................................................-:-.   =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");
            Thread.Sleep(1500);
            Console.Clear();
            Console.Write("");
            Thread.Sleep(500);

            MenuMinecraft();
        }

        static void MenuMinecraft()
        {

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =           @@@@@   :@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%@@%@@@@@%%@@%%%%%@@%@            =
             =          *#-.*@@#@@+. @*  -@+ .=@@@=: @-   -=-=#@   :==--@@ - -=   @@        @+   =*+-*@*-*   *=#            =
             =          *    @@@=.=+*@   +@.   :@:  .@   =@@@@@@ .:@@@@@@@ =:%@  -@@  +@@@  @@   @@@@@@@@@-  .@             =
             =          =            @@   @@   @%    *@      . +@.  *@@@@@@       .#@. .= #  +@:     : -@@@@   %            =
             =          *#  @= :@.  :@=   @=.:-@@# ..@@   @@@@@@@   #:    @ :.*@-  -@=       .@*   @@@@@@@@@+  =+           =
             =          # :.@@@@@@   #@ . *@   +@@= : @# .   :-:@@        :@-  .@:  .@#   @@   @@   %@@- @@@@@   +          =
             =          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@     @@@@@@@@          =
             =           @@@@@@  -@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@.            =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =            _____ _         _         _                             =                    =
             =                    =           |   __|_|___ ___| |___ ___| |___ _ _ ___ ___             =                    =
             =                    =           |__   | |   | . | | -_| . | | .'| | | -_|  _|            =                    =
             =                    =           |_____|_|_|_|_  |_|___|  _|_|__,|_  |___|_|              =                    =
             =                    =                       |___|     |_|       |___|                    =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =              _____     _ _   _     _                               =                    =
             =                    =             |     |_ _| | |_|_|___| |___ _ _ ___ ___               =                    =
             =                    =             | | | | | | |  _| | . | | .'| | | -_|  _|              =                    =
             =                    =             |_|_|_|___|_|_| |_|  _|_|__,|_  |___|_|                =                    =
             =                    =                               |_|       |___|                      =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                             Appuyer sur [1] pour lancer le mode Singleplayer                                 =
             =                             Appuyer sur [2] pour lancer le mode Multiplayer                                  =
             =                                                                                                              =
             =                                                                                                              =
             =                        _____       _        _              _____               ___                           =
             =                       |     |___ _| |___   | |_ _ _       |   __|_____ _ _ ___|  _|                          =
             =                       | | | | .'| . | -_|  | . | | |     _|__   |     | | |  _|  _|                          =
             =                       |_|_|_|__,|___|___|  |___|_  |    |_|_____|_|_|_|___|_| |_|  _____                     =
             =                                                |___|                              |_____|                    =
             =                                                                                                              =
             ================================================================================================================");

            var chiffreChoisi = Console.ReadKey(true).Key;

            if (chiffreChoisi == ConsoleKey.D1)
            {
                Console.Clear();
                Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =           @@@@@   :@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%@@%@@@@@%%@@%%%%%@@%@            =
             =          *#-.*@@#@@+. @*  -@+ .=@@@=: @-   -=-=#@   :==--@@ - -=   @@        @+   =*+-*@*-*   *=#            =
             =          *    @@@=.=+*@   +@.   :@:  .@   =@@@@@@ .:@@@@@@@ =:%@  -@@  +@@@  @@   @@@@@@@@@-  .@             =
             =          =            @@   @@   @%    *@      . +@.  *@@@@@@       .#@. .= #  +@:     : -@@@@   %            =
             =          *#  @= :@.  :@=   @=.:-@@# ..@@   @@@@@@@   #:    @ :.*@-  -@=       .@*   @@@@@@@@@+  =+           =
             =          # :.@@@@@@   #@ . *@   +@@= : @# .   :-:@@        :@-  .@:  .@#   @@   @@   %@@- @@@@@   +          =
             =          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@     @@@@@@@@          =
             =           @@@@@@  -@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@.            =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"======================================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=            _____ _         _         _                             ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=           |   __|_|___ ___| |___ ___| |___ _ _ ___ ___             ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=           |__   | |   | . | | -_| . | | .'| | | -_|  _|            ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=           |_____|_|_|_|_  |_|___|  _|_|__,|_  |___|_|              ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=                       |___|     |_|       |___|                    ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"======================================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =              _____     _ _   _     _                               =                    =
             =                    =             |     |_ _| | |_|_|___| |___ _ _ ___ ___               =                    =
             =                    =             | | | | | | |  _| | . | | .'| | | -_|  _|              =                    =
             =                    =             |_|_|_|___|_|_| |_|  _|_|__,|_  |___|_|                =                    =
             =                    =                               |_|       |___|                      =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                             "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"Appuyer sur [1] pour lancer le mode Singleplayer"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                                 =
             =                             Appuyer sur [2] pour lancer le mode Multiplayer                                  =
             =                                                                                                              =
             =                                                                                                              =
             =                        _____       _        _              _____               ___                           =
             =                       |     |___ _| |___   | |_ _ _       |   __|_____ _ _ ___|  _|                          =
             =                       | | | | .'| . | -_|  | . | | |     _|__   |     | | |  _|  _|                          =
             =                       |_|_|_|__,|___|___|  |___|_  |    |_|_____|_|_|_|___|_| |_|  _____                     =
             =                                                |___|                              |_____|                    =
             =                                                                                                              =
             ================================================================================================================");
                Thread.Sleep(500);
                Console.Clear();
                MenuCreation();
            }


            else if (chiffreChoisi == ConsoleKey.D2)
            {
                Console.Clear();
                Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =           @@@@@   :@@@@@@@@@@@@@@ @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@%@@%@@@@@%%@@%%%%%@@%@            =
             =          *#-.*@@#@@+. @*  -@+ .=@@@=: @-   -=-=#@   :==--@@ - -=   @@        @+   =*+-*@*-*   *=#            =
             =          *    @@@=.=+*@   +@.   :@:  .@   =@@@@@@ .:@@@@@@@ =:%@  -@@  +@@@  @@   @@@@@@@@@-  .@             =
             =          =            @@   @@   @%    *@      . +@.  *@@@@@@       .#@. .= #  +@:     : -@@@@   %            =
             =          *#  @= :@.  :@=   @=.:-@@# ..@@   @@@@@@@   #:    @ :.*@-  -@=       .@*   @@@@@@@@@+  =+           =
             =          # :.@@@@@@   #@ . *@   +@@= : @# .   :-:@@        :@-  .@:  .@#   @@   @@   %@@- @@@@@   +          =
             =          @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@     @@@@@@@@          =
             =           @@@@@@  -@@@@@@@@@@@@@@@.@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@      @@@@@@.            =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =            _____ _         _         _                             =                    =
             =                    =           |   __|_|___ ___| |___ ___| |___ _ _ ___ ___             =                    =
             =                    =           |__   | |   | . | | -_| . | | .'| | | -_|  _|            =                    =
             =                    =           |_____|_|_|_|_  |_|___|  _|_|__,|_  |___|_|              =                    =
             =                    =                       |___|     |_|       |___|                    =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"======================================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=              _____     _ _   _     _                               ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=             |     |_ _| | |_|_|___| |___ _ _ ___ ___               ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=             | | | | | | |  _| | . | | .'| | | -_|  _|              ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=             |_|_|_|___|_|_| |_|  _|_|__,|_  |___|_|                ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=                               |_|       |___|                      ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"======================================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                    =
             =                                                                                                              =
             =                                                                                                              =
             =                             Appuyer sur [1] pour lancer le mode Singleplayer                                 =
             =                             "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"Appuyer sur [2] pour lancer le mode Multiplayer"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                                  =
             =                                                                                                              =
             =                                                                                                              =
             =                        _____       _        _              _____               ___                           =
             =                       |     |___ _| |___   | |_ _ _       |   __|_____ _ _ ___|  _|                          =
             =                       | | | | .'| . | -_|  | . | | |     _|__   |     | | |  _|  _|                          =
             =                       |_|_|_|__,|___|___|  |___|_  |    |_|_____|_|_|_|___|_| |_|  _____                     =
             =                                                |___|                              |_____|                    =
             =                                                                                                              =
             ================================================================================================================");

                Thread.Sleep(500);
                Console.Clear();
                Program.MenuErreurMultijoueur();
            }
        }

        static void MenuCreation()
        {


            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                ____                _         _   _                __        __         _     _               =
             =               / ___|_ __ ___  __ _| |_ ___  | \ | | _____      __ \ \      / /__  _ __| | __| |              =
             =              | |   | '__/ _ \/ _` | __/ _ \ |  \| |/ _ \ \ /\ / /  \ \ /\ / / _ \| '__| |/ _` |              =
             =              | |___| | |  __/ (_| | ||  __/ | |\  |  __/\ V  V /    \ V  V / (_) | |  | | (_| |              =
             =               \____|_|  \___|\__,_|\__\___| |_| \_|\___| \_/\_/      \_/\_/ \___/|_|  |_|\__,_|              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =                    _____ ____      _  _  ____                      =                    =
             =                    =                   |_   _|  _ \   _| || ||___ \                     =                    =
             =                    =                     | | | |_) | |_  ..  _|__) |                    =                    =
             =                    =                     | | |  __/  |_      _/ __/                     =                    =
             =                    =                     |_| |_|       |_||_||_____                     =                    =
             =                    =                                                                    =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                  Appuyer sur [1] pour créer un nouveau monde                                 =
             =                          Appuyer sur [2] pour annuler et retourner au menu principal                         =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =    ================================================      ================================================    =
             =    =          ____                _               =      =          ____                     _          =    =
             =    =         / ___|_ __ ___  __ _| |_ ___         =      =         / ___|__ _ _ __   ___ ___| |         =    =
             =    =        | |   | '__/ _ \/ _` | __/ _ \        =      =        | |   / _` | '_ \ / __/ _ \ |         =    =
             =    =        | |___| | |  __/ (_| | ||  __/        =      =        | |__| (_| | | | | (_|  __/ |         =    =
             =    =         \____|_|  \___|\__,_|\__\___|        =      =         \____\__,_|_| |_|\___\___|_|         =    =
             =    =                                              =      =                                              =    =
             =    ================================================      ================================================    =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

            var chiffreChoisi = Console.ReadKey(true).Key;

            if (chiffreChoisi == ConsoleKey.D1)
            {
                Console.Clear();
                Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                ____                _         _   _                __        __         _     _               =
             =               / ___|_ __ ___  __ _| |_ ___  | \ | | _____      __ \ \      / /__  _ __| | __| |              =
             =              | |   | '__/ _ \/ _` | __/ _ \ |  \| |/ _ \ \ /\ / /  \ \ /\ / / _ \| '__| |/ _` |              =
             =              | |___| | |  __/ (_| | ||  __/ | |\  |  __/\ V  V /    \ V  V / (_) | |  | | (_| |              =
             =               \____|_|  \___|\__,_|\__\___| |_| \_|\___| \_/\_/      \_/\_/ \___/|_|  |_|\__,_|              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =                    _____ ____      _  _  ____                      =                    =
             =                    =                   |_   _|  _ \   _| || ||___ \                     =                    =
             =                    =                     | | | |_) | |_  ..  _|__) |                    =                    =
             =                    =                     | | |  __/  |_      _/ __/                     =                    =
             =                    =                     |_| |_|       |_||_||_____                     =                    =
             =                    =                                                                    =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                  "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"Appuyer sur [1] pour créer un nouveau monde"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                                 =
             =                          Appuyer sur [2] pour annuler et retourner au menu principal                         =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      ================================================    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=          ____                _               ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      =          ____                     _          =    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=         / ___|_ __ ___  __ _| |_ ___         ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      =         / ___|__ _ _ __   ___ ___| |         =    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=        | |   | '__/ _ \/ _` | __/ _ \        ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      =        | |   / _` | '_ \ / __/ _ \ |         =    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=        | |___| | |  __/ (_| | ||  __/        ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      =        | |__| (_| | | | | (_|  __/ |         =    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=         \____|_|  \___|\__,_|\__\___|        ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      =         \____\__,_|_| |_|\___\___|_|         =    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"=                                              ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      =                                              =    =
             =    "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"      ================================================    =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

                Thread.Sleep(500);
                Console.Clear();
                PageDeChargement();
            }

            else if (chiffreChoisi == ConsoleKey.D2)
            {
                Console.Clear();
                Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                ____                _         _   _                __        __         _     _               =
             =               / ___|_ __ ___  __ _| |_ ___  | \ | | _____      __ \ \      / /__  _ __| | __| |              =
             =              | |   | '__/ _ \/ _` | __/ _ \ |  \| |/ _ \ \ /\ / /  \ \ /\ / / _ \| '__| |/ _` |              =
             =              | |___| | |  __/ (_| | ||  __/ | |\  |  __/\ V  V /    \ V  V / (_) | |  | | (_| |              =
             =               \____|_|  \___|\__,_|\__\___| |_| \_|\___| \_/\_/      \_/\_/ \___/|_|  |_|\__,_|              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                    ======================================================================                    =
             =                    =                    _____ ____      _  _  ____                      =                    =
             =                    =                   |_   _|  _ \   _| || ||___ \                     =                    =
             =                    =                     | | | |_) | |_  ..  _|__) |                    =                    =
             =                    =                     | | |  __/  |_      _/ __/                     =                    =
             =                    =                     |_| |_|       |_||_||_____                     =                    =
             =                    =                                                                    =                    =
             =                    ======================================================================                    =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                  Appuyer sur [1] pour créer un nouveau monde                                 =
             =                          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"Appuyer sur [2] pour annuler et retourner au menu principal"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"                         =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =    ================================================      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    =          ____                _               =      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=          ____                     _          ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    =         / ___|_ __ ___  __ _| |_ ___         =      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=         / ___|__ _ _ __   ___ ___| |         ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    =        | |   | '__/ _ \/ _` | __/ _ \        =      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=        | |   / _` | '_ \ / __/ _ \ |         ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    =        | |___| | |  __/ (_| | ||  __/        =      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=        | |__| (_| | | | | (_|  __/ |         ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    =         \____|_|  \___|\__,_|\__\___|        =      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=         \____\__,_|_| |_|\___\___|_|         ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    =                                              =      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=                                              ="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =    ================================================      "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"================================================"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"    =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

                Thread.Sleep(500);
                Console.Clear();
                MenuMinecraft();
            }
        }

        static void MenuErreurMultijoueur()
        {
            Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 						 ===========================                                        =
             =                                           =                         =                                        =
	     =						 =  "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"/!\ ERREUR /!\"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@":        =                                        =
	     =						 =  Ce mode de jeu n'est   =                                        =
	     =						 =  pas encore disponible  =                                        =
	     =						 =  pour le moment.   	   =                                        =
	     =						 =  Attendez la version    =                                        =
	     =	 					 =  1.2 pour pouvoir	   =                                        =
	     =	 					 =  acceder à ce mode de   =                                        =
	     =						 =  jeu.	           =                                        =
	     =						 =	    =====          =                                        =
             =                                           =          =[1]=          =                                        =
             =                                           =          =====          =                                        =
	     =						 =		           =                                        =
             =                                           ===========================                                        =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================ ");

            var chiffreChoisi = Console.ReadKey(true).Key;

            if (chiffreChoisi == ConsoleKey.D1)
            {
                Console.Clear();
                Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
	     = 						 ===========================                                        =
             =                                           =                         =                                        =
	     =						 =  "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"/!\ ERREUR /!\"); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@":        =                                        =
	     =						 =  Ce mode de jeu n'est   =                                        =
	     =						 =  pas encore disponible  =                                        =
	     =						 =  pour le moment.   	   =                                        =
	     =						 =  Attendez la version    =                                        =
	     =	 					 =  1.2 pour pouvoir	   =                                        =
	     =	 					 =  acceder à ce mode de   =                                        =
	     =						 =  jeu.	           =                                        =
	     =						 =	    "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"====="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"          =                                        =
             =                                           =          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"=[1]="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"          =                                        =
             =                                           =          "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"====="); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"          =                                        =
	     =						 =		           =                                        =
             =                                           ===========================                                        =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================ ");
                Thread.Sleep(500);
                Console.Clear();
                MenuMinecraft();


            }
        }

        static void PageDeChargement()
        {

            for (int i = 0; i <= 100; i++)
            {

                if (i <= 99)
                {

                    Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                       "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(i + "%"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                                    =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

                    Thread.Sleep(10);
                    Console.Clear();
                }

                else
                {

                    Console.Write(@"             ================================================================================================================
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                       "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(i + "%"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                                   =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                         =============================                                        =
             =                                                                                                              =
             =                                                                                                              =
             =                                              "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"DOWNLOAD COMPLETED!"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                             =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");
                    Thread.Sleep(400);
                    Console.Clear();
                    InterfaceJeu();
                }
            }
        }

        static void InterfaceJeu()
        {

            Console.Write(@"             ================================================================================================================
             =                                                                                   "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@".                    ."); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"     =
             =                                                                                    "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@".                  ."); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"      =
             =                                                                                     "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"=================="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =          "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"======================="); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"                                                    "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =          "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"                     "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                                    "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =          "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"                     "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"=================="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                   "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =          "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"                                      "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                        "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"'''''''''''="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"='''''''"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"=
             =          "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"                                      "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                   "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =          "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"========================================"); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"                                   "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =                                                                                     "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.Yellow; Console.Write(@"                "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =                                 "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"==============="); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"                                     =================="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"       =
             =                                 "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"             "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                    "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"'                  '"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"      =
             =                                 "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"             "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                   "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"'                    '"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"     =
             =                                 "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"             "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                  "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"'                      '"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"    =
             =                                 "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"="); Console.BackgroundColor = ConsoleColor.White; Console.Write(@"             "); Console.BackgroundColor = ConsoleColor.Black; Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                 "); Console.ForegroundColor = ConsoleColor.Yellow; Console.Write(@"'                        '"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"   =
             =                                 "); Console.ForegroundColor = ConsoleColor.White; Console.Write(@"==============="); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             ="); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"_________"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                                                                                     =
             =         "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"-----_____                          ______________________________________----------------___________"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"=
             =                   "); Console.ForegroundColor = ConsoleColor.Green; Console.Write(@"--------------------------"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                                                                 =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                                                                                                              =
             =                 "); Console.ForegroundColor = ConsoleColor.Red; Console.Write(@"<3 <3 <3 <3 <3 <3 <3 <3 <3 <3"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"        "); Console.ForegroundColor = ConsoleColor.DarkGreen; Console.Write(@"lvl 17    "); Console.ForegroundColor = ConsoleColor.DarkGray; Console.Write(@"\ \ \ \ \ \ \ \ \ \"); Console.ForegroundColor = ConsoleColor.Gray; Console.Write(@"                           =
             =                                                                                                              =
             =          ==========================================================================================          =
             =          ="); Console.BackgroundColor = ConsoleColor.DarkGreen; Console.Write(@"      |       |       |       |       |       |       |       |  "); Console.BackgroundColor = ConsoleColor.Black; Console.Write(@"     |        |        =          =
             =          ==========================================================================================          =
             =                                                                                                              =
             =          ==========================================================================================          =
             =          =          =          =          =          =           =          =          =          =          =
             =          =          =          =          =          =           =          =          =          =          =
             =          =          =          =          =          =           =          =          =          =          =
             =          =          =          =          =          =           =          =          =          =          =
             =          ==========================================================================================          =
             =                                                                                                              =
             =                                 Appuyer sur [E] pour ouvrir l'inventaire                                     =
             =                                                                                                              =
             =                                                                                                              =
             ================================================================================================================");

            var chiffreChoisi = Console.ReadKey(true).Key;

            if (chiffreChoisi == ConsoleKey.E)
            
                Console.Clear();
                ProgrammeCoffre();

            }
        }

    }