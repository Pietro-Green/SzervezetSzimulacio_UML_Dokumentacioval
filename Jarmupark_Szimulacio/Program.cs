using System;           // ebbe van az  int.Parse
using System.IO;        // ebbe van a   File.ReadAllLines
using System.Reflection;

namespace ObjProgAssignment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /* Feladatok:

            a.Mennyire eloregedett az autobusz park?                                    (15 evnél regebbi buszok es az osszes busz szamainak aranya)
            b.Melyik a legnagyobb erteku jarmu?                                         (a jelenlegi ertek szerint)
            c.Mekkora a javitas alatt allo jarmuvek aranya az osszes jarmuhoz kepest?   (idoszakos atvizsgalast nem szamitva)
            d.Melyik jarmu szervizelesere koltotte az onkormanyzat a legtobb penzt 2022-ben?

            //int jelen = DateTime.Now.Year;
            //Jarmupark.RegiTesztek();          //A feladat kezdetekor csinalt, mostmar tobbnyire irrelevans teszteket gyujtottem ossze ezen metodusba
            */

            //Inicializalas
            Munkalap[] munkalapok = Jarmupark.MunkalapBeolvasas("PeldaMunkalapok.txt"); //Beolvasas metodus (Lasd: Jarmupark.cs)
            //Jarmupark.MunkalapKiiras(munkalapok);                                     //Kiiratas (beolvasas sikeressegenek tesztelesere)
            Jarmu[] jarmuvek = Jarmupark.JarmuBeolvasas("PeldaJarmuvek.txt");
            //Jarmupark.JarmuKiiras(jarmuvek);                                          //Kiiratas (beolvasas sikeressegenek tesztelesere)

            /*  Menu elotti verzio
            //a
            Console.WriteLine("\na.:\tMennyire eloregedett az autobusz park?\n");
            Jarmupark.Eloregedettseg(jarmuvek);

            //b
            Console.WriteLine("\nb.:\tMelyik a legnagyobb erteku jarmu?\n");
            Jarmupark.LegertekesebbJarmu(jarmuvek);

            //c
            Console.WriteLine("\nc.:\tMekkora a javitas alatt allo jarmuvek aranya az osszes jarmuhoz kepest?\n");
            Jarmupark.JavitasArany(munkalapok, jarmuvek.Length);

            //d
            Console.WriteLine("\nd.:\tMelyik jarmu szervizelesere koltotte az onkormanyzat a legtobb penzt 2022-ben?\n");
            Jarmupark.LegKoltsegesebb(munkalapok);


            //Close
            Console.WriteLine("\n\tEnterrel zarul");
            Console.ReadLine();
            */

            Jarmupark.Menu(munkalapok, jarmuvek);
        }
    }
}