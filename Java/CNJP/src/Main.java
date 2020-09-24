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
        String Speed=in.nextInt();
        System.out.println("Input moneu:");
        int Moneu=in.nextInt();
        LinkedList<String[]> database=getDatabase("/home/kirill/Practice/Java/CNJP/Database.txt");
        if (database!=null)
	    {
            getFromDatabase(database,UserQuantity,Speed,Moneu);
        }
        else 
        {
            System.out.println("Database error!");
        }
    }
    public static void getFromDatabase(LinkedList<String[]> list,int quantity,String speed,int moneu)
    {
        int a=list.size();
        int b=list.getLast().length;
        ListIterator<String[]> iter=list.listIterator();
        String [][] database= new String [a][b];
        for(int i=0;iter.hasNext();i++)
        {
            String [] str=iter.next();
            for(int j=0;j<b;j++)
            {
                database[i][j]=str[j];
            }
        }
        int firstSwitch=8;
        int firstCable=17;
        for(int rout=0,m=0,q=0;rout<8;i++)
        {   
            m=database[i][5];
            if(database[i][4]==speed )
                for(int switch=firstSwitch;switch<17;i++)
                {
                    while()
                    {    
                        for(int cable=firsCable;cable<19;cable++ )
                        {
                            
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
	        return resList;
       }
       catch(IOException ex)
       {	
       	   System.out.println(ex.getMessage());
	       return null;
       }  
    }

}
