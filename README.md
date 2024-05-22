# C# övning - Flöde via loopar och strängmanipulation
Övningen kan skrivas helt i programklassen med menyn i Main-metoden.  

## Huvudmeny
Skapa en huvudmeny för programmet som håller det vid liv och informerar användaren.  
  
För att skapa programmets huvudmeny ska ni göra följande:  
* Berätta för användaren att de har kommit till huvudmenyn och de kommer navigera
genom att skriva in siffror för att testa olika funktioner.  
* Skapa skalet till en Switch-sats som till en början har Två Cases. Ett för ”0” som
stänger ner programmet och ett default som berättar att det är felaktig input.  
* Skapa en oändlig iteration, alltså något som inte tar slut innan vi säger till att den
ska ta slut. Detta löser ni med att skapa en egen bool med tillhörande while-loop.  
* Bygg ut menyn med val att exekvera de övriga övningarna.  

### Menyval 1: Ungdom eller pensionär
För att exemplifiera if-satser skall ni implementera, på uppdrag av en teoretisk lokal bio, ett program som kollar om en person är pensionär eller ungdom vid angiven ålder. För att komma till denna funktion skall ett case i huvudmenyn skapas för ”1”, detta skall även framgå i texten som förklarar menyn.  
  
För att göra detta skall ni använda er av en nästlad if-sats. Det skall ske enligt följande förlopp:
* Användaren anger en ålder i siffror
* Programmet konverterar detta från en sträng till en int
* Programmet ser om personen är ungdom (under 20 år)
* Om det ovanstående är sant skall programmet skriva ut: Ungdomspris: 80kr
* Annars kollar programmet om personen är en pensionär (över 64 år)
* Om ovanstående är sant skall programmet skruva ut: Pensionärspris: 90kr 
* Annars skall programmet skriva ut: Standardpris: 120kr  
  
Vi vill även få möjlighet att kunna räkna ut priset för ett helt sällskap. Lägg till det alternativet i huvudmenyn (ett case “2”). Det är även ok att ha alternativet i en undermeny. Vi anger då först hur många vi är som ska gå på bio. Frågar sedan efter ålder på var och en och skriver sedan ut en sammanfattning i konsolen som ska innehålla följande:
* Antal personer
* Samt totalkostnad för hela sällskapet  
  
### Menyval 2: Upprepa tio gånger
För att använda en annan typ av iteration skall ni här implementera en for-loop. Detta ska ni skapa för att upprepa något en användare skriver in tio gånger. Det ska alltså inte skrivas via tio stycken ”Console.Write(Input);” utan via en loop som gör detta tio gånger. För att komma till den här funktionen skall ni lägga till ett case för ”3” i er huvudmeny samt text som förklarar detta.
  
Händelseförloppet visas nedan:
* Användaren anger en godtycklig text
* Programmet sparar texten som en variabel
* Programmet skriver, via en for-loop ut denna text tio gånger på rad, alltså UTAN radbrott. Exempel på output: 1. Input, 2. Input, 3. Input osv.  
  
### Menyval 3: Det tredje ordet
Ni har tidigare lärt er hur vi omvandlar strängar till integers (tex int.Parse, int.TryParse) men nu ska vi dela upp en sträng. Användaren skall ange en mening, som programmet delar upp i ord via strängens .Split(char)-metod. Ni skall dela strängen på varje mellanslag. För att enkelt lagra detta bör input sparas som en var, då ni kommer få tillbaka mer än en sträng. För att testa det här skall ni skapa case ”4” i er huvudmeny samt skriva en förklaring i texten.  
  
Händelseförloppet förklaras nedan:
* Användaren anger en mening med minst 3 ord
* Programmet delar upp strängen med split-metoden på varje mellanslag
* Programmet plockar ut den tredje strängen (ordet) ur input
* Programmet skriver ut den tredje strängen (ordet)
   
## Dokumentera
Glöm inte att kommentera er kod noga så att ni eller andra enkelt kan förstå den i framtiden.  
  
Extra uppgifter för de som har tid över:
* Validera alla inputs från användaren. Se till att programmet inte kraschar vid felaktig input.
* Barn under fem och pensionärer över 100 går gratis.
* Hantera flera mellanslag i rad i del 3.
* Vad du tycker verkar vara intressant att få med eller vill träna på!  
  
Lycka till!