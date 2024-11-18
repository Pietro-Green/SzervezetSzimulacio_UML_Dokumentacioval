using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;                //A Beolvasasos metodusoknak kell

namespace ObjProgAssignment_1
{
    class Jarmupark
    {
        public static Munkalap[]    MunkalapBeolvasas(string fajlNev)      //Ez a metodus megkapja a Munkalapos txt nevet bemenetnek, abbol peldanyosit egy tombb elemei kent munkalap objekteket
        {
            int jelen = DateTime.Now.Year;

            try
            {
                //  A  villamosnak  es  az  egyik  autobusznak  mar  2-2 szervizeleset  igazolo munkalapja is legyen, amelyek kozul az egyik meg befejezetlen.
                //      L__-> Igy 4 el nagyobb Munkalap tombot kell letrehozni, mint amennyi a filebol beolvasaskor kell, hogy az elejere kezzel be tudjuk szurni ezt a 4 peldanyt

                string[] sorok = File.ReadAllLines(fajlNev);                //Txt-bol beolvasas teszteleshez
                int mennyiseg = sorok.Length+4;
                Munkalap[] munkalapok = new Munkalap[mennyiseg];            //Beolvasott adatok tarolasahoz  (Munkalap tipusu) tomb (akkora hosszal, ahany soros txt-t olvastunk be)

                munkalapok[0] = new Munkalap(new DateTime(2019, 1, 1), "ferrar", "C19BA#12", new DateTime(2019, 1, 2), new DateTime(2019,   1, 3),  15000000,    "javitas");
                munkalapok[1] = new Munkalap(new DateTime(2019, 7, 7), "ferrar", "C19BA#12", new DateTime(2019, 7, 8), new DateTime(2019,   7, 9),  16000000,    "javitas");
                munkalapok[2] = new Munkalap(new DateTime(2020, 4, 4), "suzuka", "B19BC#12", new DateTime(2020, 4, 4), new DateTime(2020,   4, 4),  17000000,    "javitas");
                munkalapok[3] = new Munkalap(new DateTime(2020, 8, 8), "toyoti", "B19BC#12", new DateTime(2020, 8, 9), new DateTime(1,      1, 1),  0,           "javitas");

                for (int i = 0; i < mennyiseg-4; i++)                         //Vegigmegyunk a fileon
                {
                    string[] sor = sorok[i].Split(' ');                     //Ahol az adatok szokozzel vannak elvalasztva

                    DateTime adatum = DateTime.ParseExact(sor[0], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None);
                    DateTime bdatum = DateTime.ParseExact(sor[3], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None);
                    DateTime cdatum = DateTime.ParseExact(sor[4], "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None);

                    Munkalap egymunkalap = new Munkalap(adatum,
                                                        sor[1],
                                                        sor[2],
                                                        bdatum,
                                                        cdatum,
                                            int.Parse(  sor[5]),
                                                        sor[6]);
                    munkalapok[i+4] = egymunkalap;
                }
                return munkalapok;
            }
            catch (Exception)
            {
                Console.WriteLine("\n\tAjaj! ez a Munkalapos file nem letezik\n\t\t(Vagy nem megfelelo a tartalma, vagy a kiterjesztese)!\n\t\t\t !Ez helytelen eredmenyekhez vezethet!");
                Munkalap[] munkalapok = new Munkalap[0];
                return munkalapok;
            }


        }

        public static void          MunkalapKiiras(Munkalap[] munkalapok)                           //Ez a metodus megkapja a munkalaptombkent tarolt adatokat, es kiiratja minden tulajdnonsagukat (gusztusosan formazva)
        {
            for (int i = 0; i < munkalapok.Length; i++)
            {
                Console.WriteLine("\n\n{0}.munkalap:           \n", i + 1);

                Console.WriteLine("\tMunkalap {0} datuma    :   {1}   ", i + 1, munkalapok[i].datum.ToString("yyyy-MM-dd"));
                Console.WriteLine("\tMunkalap {0} cege      :   {1}   ", i + 1, munkalapok[i].ceg);
                Console.WriteLine("\tMunkalap {0} jarmuje   :   {1}   ", i + 1, munkalapok[i].jarmuAzonosito);
                Console.WriteLine("\tMunkalap {0} kezdete   :   {1}   ", i + 1, munkalapok[i].kezdet.ToString("yyyy-MM-dd"));
                Console.WriteLine("\tMunkalap {0} vege      :   {1}   ", i + 1, munkalapok[i].veg.ToString("yyyy-MM-dd"));
                Console.WriteLine("\tMunkalap {0} osszege   :   {1}   ", i + 1, munkalapok[i].osszeg);
                Console.WriteLine("\tMunkalap {0} tipusa    :   {1}   ", i + 1, munkalapok[i].Tipus);

                Console.Write("\n");
            }
        }

        public static Jarmu[]       JarmuBeolvasas(string fajlNev)                                  //Ez a metodus megkapja a Jarmuves txt nevet bemenetnek, abbol peldanyosit egy tombb elemei kent Jarmu objekteket
        {
            try
            {
                string[] sorok = File.ReadAllLines(fajlNev);                                            //Txt-bol beolvasas teszteleshez
                int mennyiseg = sorok.Length;
                Jarmu[] jarmuvek = new Jarmu[mennyiseg];                                                //Beolvasott adatok tarolasahoz  (Jarmu tipusu) tomb (akkora hosszal, ahany soros txt-t olvastunk be)

                for (int i = 0; i < mennyiseg; i++)                                                     //Vegigmegyunk a fileon
                {
                    string[] sor = sorok[i].Split(' ');                                                 //Ahol az adatok szokozzel vannak elvalasztva
                    DateTime egydatum = new DateTime(int.Parse(sor[2]), 1, 1, 0, 0, 0);                 //Igazabol csak (a gyartasi) evet akartam datumkent tarolni azert ilyen ocsmany
                    Jarmu egyjarmu = new Jarmu(sor[0],
                                                sor[1],
                                                egydatum,
                                                sor[3],
                                    int.Parse(sor[4]));
                    jarmuvek[i] = egyjarmu;
                }

                return jarmuvek;
            }
            catch (Exception)
            {
                Console.WriteLine("\n\tAjaj! ez a Jarmuves file nem letezik\n\t\t(Vagy nem megfelelo a tartalma, vagy a kiterjesztese)!\n\t\t\t !Ez helytelen eredmenyekhez vezethet!");
                Jarmu[] jarmuvek = new Jarmu[0];
                return jarmuvek;
            }

            
        }

        public static void          JarmuKiiras(Jarmu[] jarmuvek)
        {
            for (int i = 0; i < jarmuvek.Length; i++)       //kicsi l- el irni a lengthet hatalmas idopazarlas aaaa
            {
                Console.WriteLine("\n\n{0}.jarmu:           \n", i + 1);

                Console.WriteLine("\tJarmu{0} Azonositoja :     {1}   ", i + 1, jarmuvek[i].azonosito);
                Console.WriteLine("\tJarmu{0} Fajtaja     :     {1}   ", i + 1, jarmuvek[i].Fajta);
                Console.WriteLine("\tJarmu{0} Gyartasi eve:     {1}   ", i + 1, jarmuvek[i].gyev.Year);
                Console.WriteLine("\tJarmu{0} Ovezete     :     {1}   ", i + 1, jarmuvek[i].Ovezet);
                Console.WriteLine("\tJarmu{0} Uj  Ara     :     {1}   ", i + 1, jarmuvek[i].ujar);

                Console.WriteLine("                         ");

                Console.WriteLine("\tJarmu{0} aktualerteke:     {1}    ", i + 1, jarmuvek[i].AktualErtek());
            }
            Console.Write("\n");
        }

        public static void          Eloregedettseg(Jarmu[] jarmuvek)
        {
            int oreg = 0;

            DateTime jelen = new DateTime(2022, 1, 1);
            try                 {   jelen = DateTime.Now;}
            catch (Exception)   {   Console.WriteLine("\n\tProblema adodott az idomeghatarozassal!\n\t\ta (!a szamitasokhoz innentol 2022 januar elsejet hasznal a program!)"); }
            
            for (int i = 0; i < jarmuvek.Length; i++)
            {
                if ((jelen.Year - jarmuvek[i].gyev.Year) > 15) { oreg += 1; }
            }

            if (oreg == 0) { Console.WriteLine("\t\tNincs egy db 15 évnél öregebb busz se!"); }
            else { Console.WriteLine("\t\t{0} db öreg busz van a(z) {1}-ből, azaz arányuk: {2:0.00}%\n", oreg, jarmuvek.Length, (double)oreg / (double)jarmuvek.Length); }  //Legalabb az egyiket doublenek kell nyomoritani, kulonben intben adja az eredmenyt, es levagja siman 0-nak (meg a kiiratashoz hasznaltam a meno kerekitve formazos trukkot)
        }

        public static void          LegertekesebbJarmu(Jarmu[] jarmuvek)
        {

            int maxert = 0;
            try
            {
                maxert = jarmuvek[0].AktualErtek();                 //Az elso beolvasott jarmu erteket vesszuk minimumnak (azert nem 0-t mert az ertek keplet kepes negativ szamokat is adni)
            }
            catch (Exception)   {   Console.WriteLine("Az elso Jarmu erteke hianyzik, vagy hibasan lett megadva!"); }

            string  maxid = "nincs";
            try                 {   maxid = jarmuvek[0].azonosito;  }
            catch (Exception)   {   Console.WriteLine("Az elso Jarmu azonositoja hianyzik, vagy hibasan lett megadva!"); }

            int index = 0;

            for (int i = 0; i < jarmuvek.Length; i++)
            {
                if (jarmuvek[i].AktualErtek() > maxert)
                {
                    maxert  = jarmuvek[i].AktualErtek();
                    maxid   = jarmuvek[i].azonosito;
                    index   = i;
                }
            }

            Console.WriteLine("\t\tA(z) {0}. jarmu a legertekesebb (erteke: {1}ft) Azonositoja: {2}\n", index + 1, maxert, maxid);
        }

        public static void          JavitasArany(Munkalap[] munkalapok, int hossz)
        {
            double javitasAlattiak = 0;                             //Azert double, hogy az osztasnal ne legyen bena
            for (int i = 0; i < munkalapok.Length; i++)
            {
                if (munkalapok[i].Tipus == "javitas")
                {
                    javitasAlattiak += 1;
                }
            }
            double  arany = 0;
            try {   arany = javitasAlattiak / hossz;
                    Console.WriteLine("\t\tA javitas alatt allo ({0}) es az osszes jarmu ({1}) hanyadosa: {2:0.00}%\n", javitasAlattiak, hossz, arany); }   //Meno formazos trukk a kiiratasnal
            catch (Exception){ Console.WriteLine("\n\t!Az arany szamitasahoz osztunk az osszes jarmu szamaval, ezert az nem lehet 0!"); }
        }

        public static void          LegKoltsegesebb(Munkalap[] munkalapok)
        {
            string  legdragabb = "";                                //Ebben lesz annak az azonositoja, amelyik javitasara a legtobbet kellett kolteni (2022-ben)
            int     legdragabbTeljesKoltese = 0;                    //Ebben a konkret ertek, amit rakoltottek
            foreach (Munkalap m in munkalapok)                      //Minden munkalapra
            {
                if (m.veg.Year == 2022)                             //Ha a javitasa 2022-ben ert veget (azaz akkor fizettek ki)
                {
                    int koltes = 0;                                 //Megnezzuk mennyit koltott
                    foreach (Munkalap n in munkalapok)              //Meghozza ugy, hogy az osszes azonos azonositoju adatrekordon vegigmegyunk
                    {
                        if (    n.jarmuAzonosito== m.jarmuAzonosito //Es ha ugyanaz az azonosito
                            ||  n.veg.Year      == 2022)            //es az is 2022 ben lett kifizetve
                        {
                            koltes += n.osszeg;                     //Akkor hozzadjuk a koltekezesehez az osszeget
                        }
                    }
                    if (koltes > legdragabbTeljesKoltese)           //Es ha a koltese nagyobb, mint az eddig talalt legnagyobb
                    {
                        legdragabb = m.jarmuAzonosito;              //Akkor persze ove a legnagyobb
                        legdragabbTeljesKoltese = koltes;           //Es konkretan ennyi
                    }
                }
            }
            Console.WriteLine("\t\tAz overe: {0}\n", legdragabb);
        }

        public static void          Menu(Munkalap[] munkalapok, Jarmu[] jarmuvek)
        {
            Console.WriteLine("\nValasszon a feladat kerdesei kozul (a b c d (extrak: e)) vagy lepjen ki (q)\n");

            bool kilep = false;
            while (!kilep)
            {
                char bemenet = Char.ToLower(Console.ReadKey().KeyChar); //Kacifantos beolvasas (billyentyunyomasokra azonnal reagal, nagbetu / kisbetu nem szamit)

                switch (bemenet)
                {
                    case 'a':
                        Console.WriteLine(".:\tMennyire eloregedett az autobusz park?\n");  //Azert igy formaztam, mert a felhasznalo altal beirt betu is ott marad a terminalon
                        Jarmupark.Eloregedettseg(jarmuvek);
                        break;

                    case 'b':
                        Console.WriteLine(".:\tMelyik a legnagyobb erteku jarmu?\n");
                        Jarmupark.LegertekesebbJarmu(jarmuvek);
                        break;

                    case 'c':
                        Console.WriteLine(".:\tMekkora a javitas alatt allo jarmuvek aranya az osszes jarmuhoz kepest?\n");
                        Jarmupark.JavitasArany(munkalapok, jarmuvek.Length);
                        break;

                    case 'd':
                        Console.WriteLine(".:\tMelyik jarmu szervizelesere koltotte az onkormanyzat a legtobb penzt 2022-ben?\n");
                        Jarmupark.LegKoltsegesebb(munkalapok);
                        break;

                    case 'e':
                        Console.WriteLine("xtrak:\n\tJ <- Jarmuvek   minden adatanak kiiratasa\n\tM <- Munkalapok minden adatanak kiiratasa\n\tO <- Ovezetvaltas adott jarmure\n\tQ <- Quilepes az almenubol \n");
                        bool esc = false;
                        while (!esc)
                        {
                            bemenet = Char.ToLower(Console.ReadKey().KeyChar);  //Szinten
                            switch (bemenet)
                            {
                                case 'j':
                                    Jarmupark.JarmuKiiras(jarmuvek);
                                    break;

                                case 'm':
                                    Jarmupark.MunkalapKiiras(munkalapok);
                                    break;

                                case 'o':
                                    Console.Write("vezetvaltas! Kerem adja meg a jarmu sorszamat!\t>"); //
                                    int index = Convert.ToInt32(Console.ReadLine());
                                    Console.Write("\tes a beallitani kivant uj ovezetet\t>");
                                    string ujovezet = Console.ReadLine();
                                    Jarmu.OvezetValtas(jarmuvek, index, ujovezet);
                                    break;

                                case 'q':
                                    esc = true;
                                    Console.WriteLine("uilepett az almenubol a fomenube!\n");
                                    break;

                                default:
                                    Console.WriteLine(" <- Ez helytelen bemenet :(  Helyes bemenetek: j m o (& kilepeshez: q)\n");
                                    break;
                            }
                        }
                        break;

                    case 'q':
                        kilep = true;
                        Console.WriteLine("uit program due to user request (bye bye)");
                        break;

                    default:
                        Console.WriteLine(" <- Ez helytelen bemenet :(  Helyes bemenetek: a b c d e (es kilepeshez a q)\n");
                        break;
                }
            }
        }

        public static void          RegiTesztek()
        {
            double jelen = DateTime.Now.Year;
            double number = 1.0;
            int roundedNumber = (int)Math.Round(jelen * number);
            Console.WriteLine("Krisztus urunk {0}. eveben vagyunk jelenleg", roundedNumber);

            Jarmu jarmu1 = new Jarmu("A19BC#12", "trollibusz",  new DateTime(1651, 1, 1), "vegyes",     9000000);
            Jarmu jarmu2 = new Jarmu("B21FA#44", "autobusz",    new DateTime(1969, 1, 1), "kulvaros",   500000);

            jarmu2.Ovezet = "hablaty";

            jarmu2.azonosito = "C22FD#48";
            jarmu2.Fajta = "villamos";
            jarmu2.gyev = new DateTime(1989, 1, 1);
            //jarmu2.Ovezet = "belvaros";
            jarmu2.ujar = 1000000;      //Ketmillio haromszazhuszonnyolcezer forint

            Console.WriteLine("Jarmu2 azonositoja   :   " + jarmu2.azonosito);
            Console.WriteLine("Jarmu2 fajtaja       :   " + jarmu2.Fajta);
            Console.WriteLine("Jarmu2 gyartasi eve  :   " + jarmu2.gyev);
            Console.WriteLine("Jarmu2 ovezete       :   " + jarmu2.Ovezet); //ugye mostmar nagybetuvel kell ezt meghivni a gettersetteres dolog miatt
            Console.WriteLine("Jarmu2 ara           :   " + jarmu2.ujar);

            Console.WriteLine("                         ");

            Console.WriteLine("Jarmu2 aktualerteke  :   " + jarmu2.AktualErtek());
        }
    }
}