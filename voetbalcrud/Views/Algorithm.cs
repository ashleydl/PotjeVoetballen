using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using voetbalcrud.Models;

namespace voetbalcrud.Views
{
    public class Algorithm
    {
        /*In deze berekening hebben we het aantal spelers, teamnamen, positiescores per speler en de opstelling. 
         * 
         * 
         * De aantal spelers moeten geteld worden om te kunnen delen. 
         * Zijn de aantal spelers niet deelbaar door 2, dan wordt 1 speler reserve gezet. Dit gaat random. De speler wordt reserve gezet op de positie waar hij 5 of 4 voor heeft, in een random team. 
         * 
         * Berekening 1.
         * Als er 1 speler is die het getal 5 heeft voor {positie} wordt er gekeken of 1 speler het getal 4 heeft voor {positie}. 
         * Als er 2 spelers zijn met getal 5 worden de 2 spelers bij {positie} gezet. 
         * Als er boven de 2 spelers zijn met getal 5 worden er daarvan random 2 gekozen.
         * Als er 1 speler is die het getal 4 heeft voor {positie} wordt de speler bij keep gezet. Als er 0 spelers het getal 4 hebben wordt er gekeken over 1 speler het getal 3 heeft.
         * Als er 1 speler is die het getal 3 heeft voor {positie} wordt de speler bij keep gezet. Als er 0 spelers het getal 3 hebben wordt er gekeken over 1 speler het getal 2 heeft.
         * Als er 1 speler is die het getal 2 heeft voor {positie} wordt de speler bij keep gezet. Als er 0 spelers het getal 2 hebben wordt er gekeken over 1 speler het getal 3 heeft.
         * 
         * 
         * In de database staat aangegeven hoeveel spelers per team per positie zijn ingedeeld. Na keep (keep heeft standaard 1) wordt er gekeken of er nog een positie is die 1 speler gebruikt. Als er meer posities zijn
         * die 1 speler gebruiken wordt er daarvan een random positie gekozen om als eerst mee te zoeken naar een speler. 
         * De naam van de positie wordt gebruikt om door de spelers heen te zoeken naar het getal 5. Hier wordt berekening 1 gebruikt.
         * 
         * Berekening 2.
         * Als er geen posities meer zijn die (1) speler nodig hebben, wordt er gekeken naar een positie die (2) spelers nodig hebben, als er meerdere posities (2) spelers nodig hebben wordt er daarvan een random positie gekozen
         * om als eerst mee te zoeken naar een speler. 
         * Hier wordt berekening 1 weer bij gebruikt, maar dan met een andere positienaam.
         * 
         * Berekening 2 wordt uitgevoerd tot 16 spelers. 
         * 
         * 
         * 
        */
        
    }
}