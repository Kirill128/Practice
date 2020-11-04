using System;
using System.IO;
using System.Collections.Generic;

namespace Attestation
{
    class AbiturientList{
        const int minNote=4;
        Abiturient[] Abiturients{get;set;}
        public AbiturientList(int length){
            Abiturients=new Abiturient[length];
            getAbiturientsFromConsole(Abiturients);
        }
        
        public static Abiturient[] abiturWithBadNotes(AbiturientList abiturients){
            List<Abiturient> badAbitur=new List<Abiturient>();
            for(int i=0;i<abiturients.Abiturients.Length;i++){
                for(int j=0;j<abiturients.Abiturients[i].Notes.Length;j++){
                    if(abiturients.Abiturients[i].Notes[j]<minNote)badAbitur.Add(abiturients.Abiturients[i]);
                }
            }
            return badAbitur.ToArray();
        }
        public static Abiturient[] abiturWithNotesNoLessThenInput(AbiturientList abiturients,int inputNote){
            List<Abiturient> resAbitur=new List<Abiturient>();
            for(int i=0,sum;i<abiturients.Abiturients.Length;i++){
                sum=sumOfNotes(abiturients.Abiturients[i]);
                if(sum<=inputNote)resAbitur.Add(abiturients.Abiturients[i]);
            }
            return resAbitur.ToArray();
        }
        public static void sortByNotes(AbiturientList abiturients,int inputNote){
            Abiturient[] sortedAbitur=abiturients.Abiturients;
            for(int abit1=0;abit1<sortedAbitur.Length;abit1++){
                for(int abit2=abit1;abit2<sortedAbitur.Length;abit2++){
                    if(sumOfNotes(sortedAbitur[abit1])<sumOfNotes(sortedAbitur[abit2])){
                        Abiturient buf=sortedAbitur[abit1];
                        sortedAbitur[abit1]=sortedAbitur[abit2];
                        sortedAbitur[abit2]=buf;
                    }
                }
            }   
        }

        public static int sumOfNotes(Abiturient ab){
            int sum=0;
                for(int j=0;j<ab.Notes.Length;j++){
                    sum+=ab.Notes[j];
                }
            return sum;
        }
        public static void getAbiturientsFromConsole(Abiturient[] abiturients){
            for(int i=0;i<abiturients.Length;i++){
                Console.WriteLine(i+" Abiturient:");
                Console.WriteLine("Input name (e.g. Anna Lisa Egorovna):");
                string name=Console.ReadLine();
                Console.WriteLine("Input num of notes:");
                int[]notes=new int[getINT()];
                for(int j=0;j<notes.Length;j++){
                    Console.WriteLine("Input note "+j+":");
                    notes[j]=getINT();
                }
                Console.WriteLine("Get Adress:");
                string adress=Console.ReadLine();
                abiturients[i]=new Abiturient(name.Split(new Char[]{' '}),notes,adress);
            }
        }
        
        public static int getINT()
        {
            int wordlength = 0;
            try
            {
                wordlength = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return wordlength;
        }

    }
}