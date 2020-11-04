using System;
using System.IO;
using System.Collections.Generic;

namespace Attestation
{ 
    class Abiturient{
        public string [] Name{get;set;}
        public int [] Notes{set;get;}
        public string Adress{get;set;}
        public Abiturient(string [] name,int  [] notes,string adress){
            this.Name=name;
            this.Notes=notes;
            this.Adress=adress;
        }
    }
}