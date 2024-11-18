using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjProgAssignment_1
{
    class Jarmu
    {
        public string   azonosito;                  //Azonosito
        private string  fajta;                      //Fajtaja           -- Ez ugye most privat -- ugyhogy nem lehetne hozzaferni a Jarmu classon kivulrol
        public DateTime gyev;                       //Gyartasi eve
        private string  ovezet;                     //Hasznalati ovezet -- Ez ugye most privat -- ugyhogy nem lehetne hozzaferni a Jarmu classon kivulrol
        public int      ujar;                       //Ujkori ara

        public Jarmu(string egyAzonosito, string egyFajta, DateTime egyGyev, string egyOvezet, int egyUjar)   //Ez konstruktor mert publiccal es az osztaly nevevel kezdodik
        {
            azonosito = egyAzonosito;
            Fajta = egyFajta;                 //Nagybetuvel irjuk, mert gettersetteres
            gyev = egyGyev;
            Ovezet = egyOvezet;                //Nagybetuvel irjuk, mert gettersetteres
            ujar = egyUjar;
        }

        public string Ovezet
        {
            get { return ovezet; }                  //De a getter miatt le lehet kerdezni az ovezetet
            set                                     //Sot, a setter miatt be is lehet allitani -- itt most epp feltetelesen (csak megfelelo ertekekkel)
            {
                if (value == "belvaros" || value == "kulvaros" || value == "vegyes")
                {
                    ovezet = value;
                }
                else
                {
                    ovezet = "HibasOvezet";
                }
            }
        }

        public string Fajta
        {
            get { return fajta; }                   //De a getter miatt le lehet kerdezni az fajtat
            set                                     //Sot, a setter miatt be is lehet allitani -- itt most epp feltetelesen (csak megfelelo ertekekkel)
            {
                if (value == "villamos" || value == "autobusz" || value == "trolibusz")
                {
                    fajta = value;
                }
                else
                {
                    fajta = "HibasFajta";
                }
            }
        }

        public int AktualErtek()
        {
            //double jelen = DateTime.Now.Year;       //Ezt eredetileg a Jarmu class elejere raktam de sztem valami baj van azzal
            double faktor = 0;
            int AktErt;                             //Ebbe szamoljuk ki a fuggveny visszateresi erteket (hiba eseten -1)

            if (this.fajta == "villamos")
            {
                if (this.ovezet == "belvaros") { faktor = 1.0; }
                else if (this.ovezet == "kulvaros") { faktor = 0.9; }
                else if (this.ovezet == "vegyes") { faktor = 1.2; }
            }
            else if (this.fajta == "autobusz")
            {
                if (this.ovezet == "belvaros") { faktor = 2.0; }
                else if (this.ovezet == "kulvaros") { faktor = 2.0; }
                else if (this.ovezet == "vegyes") { faktor = 2.5; }
            }
            else if (this.fajta == "trolibusz")
            {
                if (this.ovezet == "belvaros") { faktor = 3.0; }
                else if (this.ovezet == "kulvaros") { faktor = 3.1; }
                else if (this.ovezet == "vegyes") { faktor = 2.8; }
            }
            else { Console.WriteLine("LehetetlenFajta"); }

            if (faktor == 0) { Console.WriteLine("LehetetlenOvezet"); }

            AktErt = (int)Math.Round((this.ujar * (100 - (DateTime.Now.Year - this.gyev.Year)) / (100.0 * faktor)) + 0.0); //Azert adok hozza 0.0-t mert kulonben sir a kerekito fuggveny, hogy nem tudja, hogy double e

            return AktErt;                          //Ez amugy siman lehet negativ ertek, ha a kocsi olcso es regi -- pl 101 eves 100 forintos belvarosi villamos erteke = -1

        }

        //Tervezze meg az allapot-atmeneteket megvalosito tevekenysegeket,
        //amelyeket majd  a jármu  osztaly metodusaikent  definialhat.      <- mivel a jarmu legtobb tulajdonsaga (fajta, gyartasi ev, stb) nem valtozik, ezert az ovezetvaltoztatasra irok fuggvenyt
        public static void OvezetValtas(Jarmu[] jarmuvek, int index, string ujovezet)
        {
            if (ujovezet == "belvaros" || ujovezet == "kulvaros" || ujovezet == "vegyes")
            {
                try
                {
                    jarmuvek[index - 1].ovezet = ujovezet;
                    Console.WriteLine("\n\t!Sikeres Ovezetatallitas!\n\tA jarmuvek listaja igy:\n");
                    Jarmupark.JarmuKiiras(jarmuvek);
                }
                catch(Exception)
                {
                    Console.WriteLine("\nOsszesen {0} jarmu van, es ezeknek csak belvaros / kulvaros / vegyes lehet az ovezete!\n",jarmuvek.Length);
                } 
            }
            else
            {
                Console.WriteLine("\n\t!Ilyen ovezetet nem lehet megadni!\n\t(Megadhato ovezetek: belvaros / kulvaros / vegyes)\n\tA jarmuvek listaja igy:\n");
                Jarmupark.JarmuKiiras(jarmuvek);
            }
        }
    }
}