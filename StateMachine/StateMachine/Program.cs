using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stateless;

namespace StateMachine
{
    class Program
    {
        
        struct data
        {
            public int x;
            public int y;
            public State state;
        }
        
        static bool flag = false;

        public static void initilizeMachine(Stately obj)//İsim Çekim Ekleri
        {
            //IsimKoku -> Cogul
            List<string> sList = new List<string>();
            sList.Add("lAr");
            sList.Add("");
            obj.filter(State.IsimKoku, State.Cogul, sList);
            
            //IsimKoku -> Iyelik3
            sList = new List<string>();
            sList.Add("lArI");
            obj.filter(State.IsimKoku, State.Iyelik3, sList);

            //Cogul -> Iyelik
            sList = new List<string>();
            sList.Add("m");
            sList.Add("Hm");
            sList.Add("n");
            sList.Add("Hn");
            sList.Add("mHz");
            sList.Add("HmHz");
            sList.Add("nHz");
            sList.Add("HnHz");
            sList.Add("");
            obj.filter(State.Cogul, State.Iyelik, sList);

            //Cogul -> Iyelik3
            sList = new List<string>();
            sList.Add("H");
            sList.Add("sH");
            obj.filter(State.Cogul, State.Iyelik3, sList);

            //Iyelik -> Durum1
            sList = new List<string>();
            sList.Add("A");
            sList.Add("yA");
            sList.Add("DA");
            sList.Add("DAn");
            sList.Add("Hn");
            sList.Add("nHn");
            sList.Add("lA");
            sList.Add("ylA");
            sList.Add("");
            obj.filter(State.Iyelik, State.Durum1, sList);

            //Iyelik -> Cikis
            sList = new List<string>();
            sList.Add("H");
            sList.Add("yH");
            sList.Add("cA");
            sList.Add("ncA");
            obj.filter(State.Iyelik, State.Cikis, sList);

            //Iyelik3 -> Durum1
            sList = new List<string>();
            sList.Add("nA");
            sList.Add("nDA");
            sList.Add("nD");
            sList.Add("An");
            sList.Add("Hn");
            sList.Add("nHn");
            sList.Add("lA");
            sList.Add("ylA");
            sList.Add("");
            obj.filter(State.Iyelik3, State.Durum1, sList);

            //Iyelik3 -> Cikis
            sList = new List<string>();
            sList.Add("nH");
            sList.Add("cA");
            sList.Add("ncA");
            obj.filter(State.Iyelik3, State.Cikis, sList);

            //Durum1 -> Ilgi
            sList = new List<string>();
            sList.Add("ki");
            obj.filter(State.Durum1, State.Ilgi, sList);

            //Durum1 -> Cikis
            sList = new List<string>();
            sList.Add("");
            obj.filter(State.Durum1, State.Cikis, sList);

            //Ilgi -> Durum1
            sList = new List<string>();
            sList.Add("nA");
            sList.Add("nDA");
            sList.Add("nDAn");
            sList.Add("Hn");
            sList.Add("nHn");
            sList.Add("lA");
            sList.Add("ylA");
            sList.Add("");
            obj.filter(State.Ilgi, State.Durum1, sList);

            //Ilgi -> Cogul
            sList = new List<string>();
            sList.Add("lAr");
            obj.filter(State.Ilgi, State.Cogul, sList);
        }

        static void Main(string[] args)
        {
            Stately stateMachine = new Stately(State.IsimKoku);          
            Stack<data> stack = new Stack<data>();
            string suffix = "lerindeki";
            int i = 0, j = 1;

            initilizeMachine (stateMachine);

            while(true)
            {
                string s = suffix.Substring(i, j - i);
                Console.WriteLine("s: " + s);
                Console.ReadLine();
                if (stateMachine.CanFire(s))
                {
                    data d = new data();
                    d.x = i;
                    d.y = j;
                    d.state = stateMachine.getState();

                    stateMachine.Fire(s);
                    stack.Push(d);
                    Console.WriteLine("Ek: " + s);
                    Console.ReadLine();
                    i = j;
                    j++;
                    if (j == suffix.Length + 1)
                    {
                        if (stack.Count != 0)
                        {
                            data daTa = new data();
                            daTa = stack.Pop();
                            i = daTa.x;
                            j = daTa.y + 1;
                            stateMachine.setState(daTa.state);
                        }
                        else
                        {

                            break;
                        }
                    }
                }
                else
                {
                    j++;
                    if (j == suffix.Length + 1)
                    {
                        if (stack.Count != 0)
                        {
                            data daTa = new data();
                            daTa = stack.Pop();
                            i = daTa.x;
                            j = daTa.y + 1;
                            stateMachine.setState(daTa.state);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
        }
    }
}
