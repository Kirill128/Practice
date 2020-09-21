package java.linkedlist.node;
public class Node<E> 
{
    private E value;
    private Node next;
    private Node previous;
    private int position=0;

    Node(E val,Node pr,Node next,int en){
        this.value=val;
        this.previous=pr;
	this.next=next;
	this.position=en;
    }
    Node(E val,Node pr,Node next){
        this.value=val;
        this.previous=pr;
        this.next=next;
    }
    public void setValue(E v){
        this.value=v;
    }
    public void setNext(Node n){
        this.next=n;
    }
    public void setPrevious(Node p){
        this.previous=p;
    }
    public void setPosition(int e){
        this.position=e;
    }

    public E getValue(){
        return this.value;
    }
    public Node getNext(){
        return this.next;
    }
    public Node getPrevious(){
        return this.previous;
    }
    public int getPosition(){
        return this.position;
    }

}
