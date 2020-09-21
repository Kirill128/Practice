package java.linkedlist.list; 
public class List<E>{
	private  Node<E> head;
	private  int lenght;
	public List(){
		head = new Node<E>(null,head,head);
		length =0;
	}
	public void  add(E val){// must return boolean
		Node<E> node= new Node<E>(val,this.head.getPrevious(),this.head,this.length);
		this.head.setPrevious(node);
		length++;
	}	
	public void add(int position , E val){
	   	`:Node<E> buf=head;
		if(position<=length){
			for(int j=0;j=position;j++){
				buf=buf.getNext();	
				if(i==position-1){
					Node<E> new_node=new Node<E>(val,buf,buf.getNext(),position);	
					buf.setNext(new_node);
					buf=buf.getNext();
					buf.setPrevious(new_node);
					this.length++;
					for(int i=0;i<this.length;i++){
						buf.setPosition(position+i);
						buf=buf.getNext();
					}
				}
			}
		}
	}
	public	void addFirst() {
	
	}
	public void addLast(){
	
	}
	public void  clear{
	
	}
	public boolean contains(){
	
	}
	public E element(){
	
	}
	public E get(int index){
	
	}

	public getFirst(){
	
	}
	public getLast(){
	
	}

	public int indexOf(){
	
	}

	public int lastIndexOf(){
	
	}
	public E peekFirst(){
	
	}
	public E peekLast(){
	
	}









}
