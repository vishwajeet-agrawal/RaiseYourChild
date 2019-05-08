using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionBankScript : MonoBehaviour {

    // Use this for initialization
    public static Dictionary<string,int> empty_dics;
    public static Dictionary<string, Event> questions;

    public string child_name;

	void Start(){
		child_name = PlayerPrefs.GetString ("Child_Name", "Lakshay");
	}
    public void initialize_all()
    {
        empty_dics = new Dictionary<string, int>();
        questions = new Dictionary<string, Event>();
        empty_dics.Add("Wisdom",0);
        empty_dics["Satisfaction"] = 0;
        empty_dics["Respect"] = 0;
        empty_dics["Confidence"] = 0;
        empty_dics["PhysicalHealth"] = 0;
        empty_dics["Motivation"] = 0;
        empty_dics["Awareness"] = 0;
        empty_dics["Experience"] = 0;
        generateEvents();
       
    }

   
    public class Choice{
		public string choice_text;
		public string choice_implication="";
		public string choice_notification_text;
		public int choice_notification_time;
		public Dictionary<string, int> statEffectImpulse; //For changing the stats
		public Dictionary<string, int> statEffectRate; //For changing the stats
        public Choice(string text,string imply,int[] stats, int[] statrate)
        {
            choice_text = text;
            statEffectImpulse = new Dictionary<string, int>();
            statEffectImpulse["Wisdom"] = stats[0];
            statEffectImpulse["Satisfaction"] = stats[1];
            statEffectImpulse["Respect"] = stats[2];
            statEffectImpulse["Confidence"] = stats[3];
            statEffectImpulse["PhysicalHealth"] = stats[4];
            statEffectImpulse["Motivation"] = stats[5];
            statEffectImpulse["Awareness"] = stats[6];
            statEffectImpulse["Experience"] = stats[7];
            statEffectRate = new Dictionary<string, int>();
            statEffectRate["Wisdom"] = statrate[0];
            statEffectRate["Satisfaction"] = statrate[1];
            statEffectRate["Respect"] = statrate[2];
            statEffectRate["Confidence"] = statrate[3];
            statEffectRate["PhysicalHealth"] = statrate[4];
            statEffectRate["Motivation"] = statrate[5];
            statEffectRate["Awareness"] = statrate[6];
            statEffectRate["Experience"] = statrate[7];
            choice_implication = imply;
        }
        public Choice(string s)
        {
            choice_text = s;
            choice_implication = "";
            statEffectImpulse = empty_dics;
            statEffectRate = empty_dics;
        }
        public Choice(string s,int[] stats)
        {
            choice_text = s;
            choice_implication = "";
            statEffectImpulse = new Dictionary<string, int>();
            statEffectImpulse["Wisdom"] = stats[0];
            statEffectImpulse["Satisfaction"] = stats[1];
            statEffectImpulse["Respect"] = stats[2];
            statEffectImpulse["Confidence"] = stats[3];
            statEffectImpulse["PhysicalHealth"] = stats[4];
            statEffectImpulse["Motivation"] = stats[5];
            statEffectImpulse["Awareness"] = stats[6];
            statEffectImpulse["Experience"] = stats[7];
        
        }
        public Choice(string s,int[] stats,int[] statrate)
        {
            choice_text = s;
            choice_implication = "";
            statEffectImpulse = new Dictionary<string, int>();
            statEffectImpulse["Wisdom"] = stats[0];
            statEffectImpulse["Satisfaction"] = stats[1];
            statEffectImpulse["Respect"] = stats[2];
            statEffectImpulse["Confidence"] = stats[3];
            statEffectImpulse["PhysicalHealth"] = stats[4];
            statEffectImpulse["Motivation"] = stats[5];
            statEffectImpulse["Awareness"] = stats[6];
            statEffectImpulse["Experience"] = stats[7];
            statEffectRate = new Dictionary<string, int>();
            statEffectRate["Wisdom"] = statrate[0];
            statEffectRate["Satisfaction"] = statrate[1];
            statEffectRate["Respect"] = statrate[2];
            statEffectRate["Confidence"] = statrate[3];
            statEffectRate["PhysicalHealth"] = statrate[4];
            statEffectRate["Motivation"] = statrate[5];
            statEffectRate["Awareness"] = statrate[6];
            statEffectRate["Experience"] = statrate[7];
        }
	}

	public class Question{
        
		public string question_text;
		public Choice choice_1;
		public Choice choice_2;
        public Question(string s1,string c1,string c1impl,int[] statc1, int[] statc1rate,string c2,string c2impl, int[] statc2, int[] statc2rate)
        {
            question_text = s1;
            choice_1 = new Choice(c1,c1impl,statc1,statc1rate);
            choice_2 = new Choice(c2,c2impl,statc2,statc2rate);
        }
        public Question(string s1,string c1,string c2)
        {
            question_text = s1;
            choice_1 = new Choice(c1);
            choice_2 = new Choice(c2);
        }
	}

	public class Notification{
        
		public string notification_text;
        public Dictionary<string, int> statEffectImpulse;
        public Notification(string s1,int[] stats)
        {
            statEffectImpulse = new Dictionary<string, int>();
            statEffectImpulse["Wisdom"] = stats[0];
            statEffectImpulse["Satisfaction"] = stats[1];
            statEffectImpulse["Respect"] = stats[2];
            statEffectImpulse["Confidence"] = stats[3];
            statEffectImpulse["PhysicalHealth"] = stats[4];
            statEffectImpulse["Motivation"] = stats[5];
            statEffectImpulse["Awareness"] = stats[6];
            statEffectImpulse["Experience"] = stats[7];
            notification_text = s1;
        }
	}
    public int[] make_array(int wis,int sat,int res,int conf,int health,int motivation,int social_aware,int exp)
    {
        int[] ans = new int[8];
        ans[0] = wis;
        ans[1] = sat;
        ans[2] = res;
        ans[3] = conf;
        ans[4] = health;
        ans[5] = motivation;
        ans[6] = social_aware;
        ans[7] = exp;
        return ans;
    }
    
    public class Event
    {
		public bool is_display = true;
        public int time;
        public int type_of_event;
        public int wait_time;
        public Question qs;
        public Notification not;
        public Event (int t,int wt, int type)
        {
            time = t;
            wait_time = wt;
            type_of_event = type;
        }
        public Event(int t,int wt, Question qs1)
        {
            time = t;
            wait_time = wt;
            type_of_event = 1;
            qs = qs1;
        }
        public Event(int t,int wt, Notification n1)
        {
            time = t;
            wait_time = wt;
            type_of_event = 0;
            not = n1;
        }
        public Question getQs()
        {
            return qs;
        }
        public Notification getnots()
        {
            return not;
        }
        public int getType()
        {
            return type_of_event;
        }
        public int getWait()
        {
            return wait_time;
        }
    }

    /*public class WhatToShow<T> 
	{
		int is_question_or_notif;	//0 for question, 1 for notif
		public T question_or_notif;


		public WhatToShow(){
			if(typeof(T) == typeof(Notification)){
				
			}
		}
	}*/
    //public Node current_event_node=null;
	public class TimeTTuple
	{
		public int time;
		public Event to_be_displayed;

		public TimeTTuple(){
			
		}

		public TimeTTuple(int _time, Event _to_be_displayed){
			time = _time;
			to_be_displayed = _to_be_displayed;
		}
	}

    public class Node
    {
        public string code = "";
        public Node left_child = null;
        public Node right_child = null;
        public Node(string e1)
        {
            code = e1;

        }
        public Node(Node n1, Node n2)
        {
            left_child = n1;
            right_child = n2;
        }
        public Node(Node n1)
        {
            left_child = n1;
        }
        public Node(string e1, Node n1)
        {
            code = e1;
            left_child = n1;
        }
        public Node(string e1, Node n1, Node n2)
        {
            code = e1;
            left_child = n1;
            right_child = n2;
        }
        public Node(string s1,string s2,string s3)
        {
            code = s1;
            left_child = new Node(s2);
            right_child = new Node(s3);
        }
    }

	public class Tree
	{
		public Node root = null;
        public Node current_node = null;
        public void update_current(Node n)
        {
            current_node = n;
        }
	}


	Tree events = new Tree();
	//Define questions here


	public Event GetNextEvent(int inp){
        string to_search;
        if (inp == 0)
        {
            Node n = events.current_node.left_child;
            to_search = n.code;
            events.update_current(n);
        }   
        else
        {
            Node n = events.current_node.right_child;
            to_search = n.code;
            events.update_current(n);
        }
        return questions[to_search];
	}
    public int[] make_null()
    {
        int[] a = new int[8];
        for (int i = 0; i < 8; i++)
        {
            a[i] = 0;
        }
        return a;
    }

    public void addnotif(string code,string text,int[] statc,int time,int gap)
    {
        Notification n1 = new Notification(text, statc);
        Event e1 = new Event(time, gap, n1);
        questions.Add(code,e1);
    }
    public void addnotif(string code,string text,int time,int gap)
    {

        Notification n1 = new Notification(text, make_null());
        Event e1 = new Event(time, gap, n1);
        questions.Add(code,e1);
    }
    public void addnotif(string code,string text,int time)
    {
        Notification n1 = new Notification(text, make_null());
        Event e1 = new Event(time, 5, n1);
        questions.Add(code,e1);
    }
    public void addnotif(string code,string text,int[] statc, int time)
    {
        Notification n1 = new Notification(text, statc);
        Event e1 = new Event(time, 5, n1);
        questions.Add(code ,e1);
    }
    public void addqs(string code,string t1,string t2,string t3,int time,int gap)
    {
        Question q1 = new Question(t1, t2, t3);
        Event e1 = new Event(time, gap, q1);
        questions.Add(code, e1);
    }
    public void addqs(string code,string t1,string t2,string t2im, string t3,string t3im, int[] c1,int[] c2, int[] r1, int[] r2, int time, int gap)
    {
        Question q1 = new Question(t1, t2, t2im, c1, r1, t3, t3im, c2, r2);
        Event e1 = new Event(time, gap, q1);
        questions.Add(code,e1);
    }
    public void generateEvents()
    {
        string N0_1 = "Raise your child is a decision making game for your child. What decisions you take for him will change the course of his life substantially. Each decision will have an immediate effect and a lasting effect on your child. Before taking a decision you will be presented with a dilemma describing the possible consequences of the particular choice. So choose wisely and raise your child wisely. ";
        string N1_1 = "You have just given a birth to a boy. Look he is so cute just like his father. The omens says he is going to become a great man and make everyone proud. You sure are going to play a major role in deciding his destiny. Make good decisions and don’t let your child let out of your hand. At the same time, let him also be free to make his own decisions when he wants to! Oh! by the way; what is the beautiful name you want to give to your child ?";
        string Q2_1 = "It is his first birthday! and " + "has already started walking. Must be thinking to gift him with a beautiful present? Let’s gift him with something!";
        string Q2_1C1 = "Gift him with a wooden horse";
        string Q2_1C2 = "Gift him with a building block game";
        string N2_2 = "He liked the horse!";
        string N2_3 = "You just noticed, he swallowed a plastic piece and you have to rush to the doctor! His health is hit badly. Better careful next time not to give any potentially harmful toy to the child.";
        int[] N2_2I = make_array(0, 20, 0, 0, 0, 0, 0, 10);
        int[] N2_3I = make_array(0, 10, 0, 0, -30, 0, 0, 10);
        string N3_1 = "It is his second birthday! You had a beutiful celebration and "+child_name +" just got a lot of candies to eat";
        string N4_1 = "This year the spring seems very beutiful and no one would like to leave the lap of the nature! How about going out to a park with " + child_name + " ! He sure will like the warm breeze.";
        string Q4_2 = "You see that your child is so happy playing with other kids. You think of sending him to a play school to bring more joy to him.";
        string Q4_2C1 = "What are the different schools available ?";
        string Q4_2C2 = "No, it is too early to send him to school, let him play regularly in the picnic only.";
        string Q4_2C1I = "Since there are kids who are come to picnic, he will have a good time there";
        string Q4_2C2I = "Since he is just about 3 years old, it might be too early to send him out of the home.";
        int[] nullar = make_array(0, 0, 0, 0, 0, 0, 0, 0);
        int[] Q4_2_C1SI = make_array(0,0,0,0,0,0,0,0);
        int[] Q4_2_C1SR = make_array(0, 2, 0, 0, 0, 0, 0, 1);
        int[] Q4_2_C2SI = make_array(0, 0, 0, 0, -5, 0, 0, 0);
        int[] Q4_2_C2SR = make_array(1, 1, 0, 0, 0, 0, 0, 2);
        Notification n1 = new Notification(N0_1, make_null());
        Event e1 = new Event(0,2, n1);
        questions.Add("N0_1",e1);
        n1 = new Notification(N1_1, make_null());
        e1 = new Event(1,5, n1);
        questions.Add("N1_1",e1);
        Question qs1 = new Question(Q2_1,Q2_1C1,"",nullar,nullar,Q2_1C2,"",nullar,nullar);
        e1 = new Event(12,1, qs1);
        questions.Add("Q2_1",e1);

        addnotif("N2_2", N2_2, N2_2I, 12, 5);
        addnotif("N2_3", N2_3, N2_3I, 12, 5);
        addnotif("N3_1", N3_1, 24, 5);
        addnotif("N4_1", N4_1, 34, 3);
        addqs("Q4_2", Q4_2, Q4_2C1, Q4_2C1I, Q4_2C2, Q4_2C2I, Q4_2_C1SI, Q4_2_C2SI, Q4_2_C1SR, Q4_2_C2SR, 35, 5);
        
        


        events.root = new Node("N0_1");
        events.current_node = events.root;
        Node nd1 = events.root;
        nd1.left_child = new Node("N1_1");
        nd1 = nd1.left_child;
        nd1.left_child = new Node("Q2_1");
        nd1 = nd1.left_child;
        nd1.left_child = new Node("N2_2");
        nd1.right_child = new Node("N2_3");
        Node nd2 = nd1.left_child;
        nd2.left_child = new Node("N3_1");
        Node nd3 = nd1.right_child;
        nd3.left_child = nd2.left_child;
        nd1 = nd2.left_child;
        nd1.left_child = new Node("N4_1");
        nd1 = nd1.left_child;
        nd1.left_child = new Node("Q4_2");
        nd1 = nd1.left_child;
        nd1.left_child = new Node("Q4_3");
        nd1.right_child = new Node("N4_4");
        nd2 = nd1.left_child;
        nd3 = nd1.right_child;
        nd3.left_child = new Node("Q4_5");
        nd2.left_child = new Node("N5_1");
        nd2.right_child = new Node("N5_2");
        nd3 = nd3.left_child;
        nd3.left_child = new Node("N5_1");
        nd3.right_child = new Node("N5_2");
        nd2 = nd3.left_child;
        nd3 = nd3.right_child;
        nd2.left_child = new Node("N6_1");
        nd3.left_child = nd2.left_child;
        nd1 = nd3.left_child;
        nd1.left_child = new Node("Q6_2");
        nd1 = nd1.left_child;
        nd1.left_child = new Node("N7_1");
        nd2 = nd1.left_child;
        nd1.right_child = new Node("N7_2");
        nd3 = nd1.right_child;
        nd2.left_child = new Node("N8_1");
        nd3.left_child = new Node("N8_2");
        nd2 = nd2.left_child;
        nd3 = nd3.left_child;
        nd2.left_child = new Node("Q8_3");
        nd3.left_child = nd2.left_child;
        nd1 = nd2.left_child;
        nd1.left_child = new Node("N9_1");
        nd1.right_child = new Node("N9_2");
        nd2 = nd1.left_child;
        nd3 = nd1.right_child;
        nd2.left_child = new Node("N9_3");
        nd3.left_child = new Node("N9_4");
        nd2 = nd2.left_child;
        nd3 = nd3.left_child;
        nd2.left_child = new Node("Q10_1");
        nd3.left_child = nd2.left_child;
        nd1 = nd3.left_child;



        string N4_3 = "The spring has just ended and the temperature is rising. The other kids that came to the park have started going to schools and there is hardly any child that comes now. Maybe it is also the time to send" + child_name + "to school now.";
        addnotif("N4_4", N4_3, 37, 2);
        string Q4_4 = "The town has two play schools!";
        string Q4_4C1 = "The first school is an expensive air conditioned and with modern facilities. It has high fees. The school assures full security of your child";
        string Q4_4C2 = "The second school is just nearby the home. It has modest infastructure but you may not feel very safe sending the child alone, so you will have to be present there with the child full time.";
        string Q4_4C1I = "";
        string Q4_4C2I = "";
        int[] stat1 = make_array(2,2,0,2,0,0,0,5);
        int[] stat2 = make_array(4,1,0,2,0,0,4,5);
        int[] statrate1 = make_array(2, 2, 0, 2, 0, 0, 0, 5);
        int[] statrate2 = make_array(4, 1, 0, 2, 0, 0, 4, 5);
        addqs("Q4_5", Q4_4, Q4_4C1,  Q4_4C1I, Q4_4C2, Q4_4C2I, stat1, stat2, statrate1, statrate2, 37, 5);
        addqs("Q4_3", Q4_4, Q4_4C1,  Q4_4C1I, Q4_4C2, Q4_4C2I, stat1, stat2, statrate1, statrate2, 35, 5);
        string s1 = "You are having a hard time in paying fees of the play school as it very expensive. You wander if there is any additional effect on the child because of going to the modern school. You got to know that the peers of your child are very rich and with high contacts.";
        
        stat2 = make_array(0,0,0,0,0,0,0,0);
        addnotif("N5_1", s1, stat1, 48, 5);
        string s2 = "You are happy with the play school of your child. The play school has very good teacher who patiently teach children how to walk, write and talk properly. The kid has learnt many good habits";
        stat1 = make_array(0, 0, 0, 0, 0, 0, 0, 0);
        addnotif("N5_2", s2, stat2, 48, 5);
  
        s1 = "It has been 2 years now and " + child_name + " has already grown to 5. It's time to put him in the primary school now!";
        addnotif("N6_1", s1, 60, 1);
        s1 = "There are two primary schools in the town. ";
        s2 = "The first school is a little far off from home. It requires half an hour to reach there by van. The school boasts modern infrastructure, and qualified faculty. The fees is very high and only a few can afford to put their child in this school. The school has various extra subjects like French, German, Guitar, Piano etc. enrolling in which will make your child an allrounder.";
        string s3 = "The second school is only 2 blocks away from home. A walk takes 5 minutes to reach. The school although doesn’t has a very good infrastructure but the faculty is group of senior wise people who belong to this town and is very good. Children from all background study in this school and the principal of this school has dedicated few seats in every class for children who can’t afford a penny. These children come from nearby villages.";
        string si2 = "Do you want your child to learn modern subjects and have a company of rich kids. Remember the child may feel bad seeing their top amenities";
        string si3 = "Or do you want to keep your child grounded and let him enjoy with the poor kids of the villages. You fear that your child is sensitive and might not be able to adjust with the rough behavior and lifestyle of the village kids";

        stat1 = make_array(2,-1,0,2,0,2,0,10);
        stat2 = make_array(2,1,0,2,0,2,0,10);
        statrate1 = make_array(4, -1, 0, 2, 0, 2, 0, 10);
        statrate2 = make_array(5, 1, 0, 4 , 0, 2, 4, 10);
        addqs("Q6_2", s1, s2,  si2,s3, si3, stat1, stat2, statrate1, statrate2, 60, 5);
        s1 = "The new school is good, but he does not seem to very happy. He has frequently started demanding expensive goods from the parents";
        stat1 = make_array(3,-7,0,4,0,0,0,5);
        
        addnotif("N7_1",s1,stat1,72);
        s1 = "The old school has a very good atmomsphere with children from all economic background. " +child_name+ " He has made a lot of good friends.";
        stat1 = make_array(1,10,3,4,0,2,6,6);
        addnotif("N7_2",s1,stat1,72);
        stat1 = make_array(3,6,0,6,0,4,0,7);
        s1 = child_name + "is showing great academic excellence. May want to send him to Maths tution";
        addnotif("N8_1",s1,stat1,84);
        stat1 = make_array(4,5,13,5,0,10,9,10);
        s1 = "The teacher visited your home to give review on "+child_name+ " performance. He seems happy with the child and had remarked that he is very sincere, hardworking and helping";
        addnotif("N8_2",s1,stat1,84);

        s1 = "You see that there is a lot of time when " + child_name + " remains free. You think of sending him to some place to visit in the evenings.";
        s2 = "Send him to the music classes! ";
        s3 = "Send him daily in the evening to the nearby gurudwara for helping with the langar";
        si2 = "Music is good for mind and it will make him quiet and more more focussed";
        si3 = "Sending him to gurudwara and helping selflsessly will maintain the values in him.";
        stat1 = make_array(1,4,2,5,0,2,0,10);
        stat2 = make_array(3,5,1,2,0,6,10,8);
        statrate1 = make_null();
        statrate2 = make_null();

        addqs("Q8_3", s1, s2, si2,s3, si3, stat1, stat2, statrate1, statrate2, 90, 5);
        s1 = "Music had a very good impact on him. He has all become more quiet and focussed and he just won a music award in the school";
        stat1 = make_array(1, 4, 2, 5, 0, 2, 0, 10);
        addnotif("N9_1", s1, stat1, 97);
        s1 = "He has become very thoughtfull and kind. The blessings receiveed from poor people have also maintained his good physical health";
        stat1 = make_array(3,5,1,3,10,3,5,5);
        addnotif("N9_2", s1, stat1, 97);
        s1 = child_name + " got a complain from the school that he is behaving arrogantly with the kids";
        stat1 = make_array(0,0,0,-1,0,-1,-1,0);
        addnotif("N9_3", s1, stat1, 100);
        s1 = child_name + "was just made the headboy of the class with everyone's agreement. Everyone praises him. He sure has become very mature";
        stat1 = make_array(5,5,1,5,0,5,5,5);
        addnotif("N9_4", s1, stat1, 101);
        s1 = "Your child told to you that your friends were talking something about sex. He ask him about it";
        s2 = "Tell him to ignore it";
        s3 = "Tell him that it is a process that enables birth of new living beings. Everyone is born by that process";
        si2 = "Ignoring might simply make him search for the truth more";
        si3 = "If you tell him, he may have more curiosity which can make him prone to unwanted talks with his friends/";
        stat1 = make_array(0, -4, -1, 0, 0, 0, -1, 0);
        stat2 = make_array(1, 2,0,3,0,0,0,5);
        statrate1 = make_null();
        statrate2 = make_null();
        addqs("Q10_1", s1, s2, si2,s3, si3, stat1, stat2, statrate1, statrate2, 108, 5); //9 years old



    }
   
    
}
