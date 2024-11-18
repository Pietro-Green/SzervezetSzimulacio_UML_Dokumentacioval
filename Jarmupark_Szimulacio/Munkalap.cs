using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObjProgAssignment_1
{
    class Munkalap
    {
        public DateTime datum;              //Mikor             --Ez nem redundans a mettol&meddig miatt??
        public string   ceg;                //Melyik ceg
        public string   jarmuAzonosito;     //Melyik (azonositoju) jarmu szervizeleset vegezte
        public DateTime kezdet;             //Mettol
        public DateTime veg;                //Meddig            (Csak lezarult szervizelesek eseten ismert!)
        public int      osszeg;             //Mekkora osszegert (Csak lezarult szervizelesek eseten ismert!)
        private string  tipus;              //Javitas vagy idoszakos atvizsgalas volt e a tipusa -- Ez ugye most privat -- ugyhogy nem lehetne hozzaferni a Munkalap classon kivulrol

        public Munkalap(DateTime egyDatum, string egyCeg, string egyJarmuAzonosito, DateTime egyKezdet, DateTime egyVeg, int egyOsszeg, string egyTipus)
        {
            datum   = egyDatum;
            ceg     = egyCeg;
            jarmuAzonosito = egyJarmuAzonosito;
            kezdet  = egyKezdet;
            veg     = egyVeg;
            osszeg  = egyOsszeg;
            Tipus   = egyTipus;                     //Nagybetuvel irjuk, mert gettersetteres
        }

        public string Tipus
        {
            get { return tipus; }                   //De a getter miatt le lehet kerdezni az tipust
            set                                     //Sot, a setter miatt be is lehet allitani -- itt most epp feltetelesen (csak megfelelo ertekekkel)
            {
                if (value == "javitas" || value == "idoszakosAtvizsgalas")
                {
                    tipus = value;
                }
                else
                {
                    tipus = "HibasTipus";
                }
            }
        }
    }
}