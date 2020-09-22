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
	    LinkedList<String[]> res=getFromDatabase(getDatabase("/home/kirill/Practice/Java/CNJP/Database.txt"));

    }
    public static LinkedList<String[]> getFromDatabase(LinkedList<String[]> list,int quantity,int speed,int moneu)
    {
        Iterator<String[]> iter=list.iterator();
        for(int quantScore,speedScore,moneuScore;iter.hasNext();)
        {


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
