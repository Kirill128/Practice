import java.io.*;
import java.util.*;
public class Main
{
    public static void main(String [] args)
    {   
        Scanner in =new Scanner(System.in);
        System.out.println("Input num of users:");
        int UserQuantity=in.nextInt();
        System.out.println("Input speed:");
        int Speed=in.nextInt();
        System.out.println("Input moneu:");
        int Moneu=in.nextInt();
        LinkedList<String[]> database=getDatabase("I:\\Practice\\Java\\CNJP\\Database.txt");
        //"/home/kirill/Practice/Java/CNJP/Database.txt"
        if (database!=null)
	    {
            getFromDatabase(database,UserQuantity,Speed,Moneu);
        }
        else 
        {
            System.out.println("Database error!");
        }
    }
    public static void getFromDatabase(LinkedList<String[]> list,int quantity,int speed,int moneu)
    {

        int a=list.size();
        int b=list.getLast().length;
        ListIterator<String[]> iter=list.listIterator();
        String [] nameBase= new String [a];
        int [][] dataBase=new int[a][b-1];
        System.out.println(a+"  "+b);
        for(int i=0;iter.hasNext();i++)
        {
            String [] str=iter.next();
            nameBase[i]=str[0];
            for(int j=0;j<b-1;j++)
            {
                dataBase[i][j]=Integer.valueOf(str[j+1]);
            }
        }
        int routerCost=0,switchCost=0,cableCost=0,freePortsThisRout=0,quanSwitch=0,resCost=0;
        int firstSwitch=8;
        int firstCable=17;

        for(int rout=0;rout<8;rout++)
        {   

            if(dataBase[rout][3]>=speed && dataBase[rout][4]<moneu)
            {
                routerCost=dataBase[rout][4];
                
                freePortsThisRout=dataBase[rout][1]-1;
                System.out.println("routerCOst:"+routerCost + " res:"+resCost);
                for(int swich=firstSwitch,freePortsThisSwich;swich<17;swich++)
                {    
                    resCost=routerCost;        
                    if(dataBase[swich][3]>=speed )
                    {
                        freePortsThisSwich=dataBase[swich][1]-2;
                        quanSwitch=(quantity-freePortsThisRout)/freePortsThisSwich;
                        if((quantity-freePortsThisRout)%freePortsThisSwich!=0)
                            quanSwitch++;

                        switchCost=(quanSwitch*dataBase[swich][4]);
                        System.out.println("routerCOst:"+routerCost+" Switchcost:"+switchCost+" res:"+resCost);
                        resCost+=switchCost;
                        System.out.println("routerCOst:"+routerCost+" Switchcost:"+switchCost+" res:"+resCost);
                        if(resCost<moneu)
                        {
                            System.out.println("routerCOst:"+routerCost+" Switchcost:"+switchCost+"Cablecost:"+" SSSSSSSSSSSSS");
                            for(int cable=firstCable;cable<19;cable++ )
                            {
                                cableCost=dataBase[cable][4]*(quanSwitch+1);
                                resCost+=cableCost;
                                System.out.println("routerCOst:"+routerCost+" Switchcost:"+switchCost+"Cablecost:"+cableCost);
                                if(dataBase[cable][3]>=speed && resCost<=moneu )
                                {
                                    
                                    System.out.println("Rout:"+dataBase[rout][0]+"\nSwitch:"+dataBase[swich][0]+" X"+quanSwitch+"\nCable:"+dataBase[cable][0]+"\nCost:"+resCost+"\n");
                                }
                                resCost-=cableCost;
                            }
                        }


                    } 
                    
                }
                
            }
        }
    }
    public static  LinkedList<String[]> getDatabase(String path)
    {
       try(BufferedReader File=new BufferedReader(new FileReader(path)))
       {
	        LinkedList<String[]> resList=new LinkedList<String[]>();
	        for(String str=File.readLine();str!=null;str=File.readLine())
	        {
	   	        resList.addLast(str.split(" "));
		        System.out.println(str);
	        }
            for(String [] s : resList)
            {  for(String a : s)
                    System.out.print(a+" ");
                System.out.println();
            }
            return resList;
       }
       catch(IOException ex)
       {	
       	   System.out.println(ex.getMessage());
	       return null;
       }  
    }

}
