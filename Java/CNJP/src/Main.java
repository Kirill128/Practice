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
        LinkedList<String[]> database=getDatabase("/home/kirill/Practice/Java/CNJP/Database.txt");
        if (database!=null)
	    {
            LinkedList<String> res=getFromDatabase(database,UserQuantity,Speed,Moneu);

        }
        else 
        {
            System.out.println("Database error!");
        }
    }
    public static LinkedList<String> getFromDatabase(LinkedList<String[]> list,int quantity,int speed,int moneu)
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
    	return null;	
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
