using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Stateless;

namespace StateMachine
{
    public enum State
    {
        IsimKoku,
        Cogul,
        Iyelik,
        Iyelik3,
        Durum1,
        Durum2,
        Ilgi,
        Cikis
    }

    class Stately
    {
        Dictionary<char, List<char>> table;
        StateMachine<State , string > machine;

        public Stately(State beginningState)
        {
            table = new Dictionary<char,List<char>>();
            machine = new StateMachine<State,string>(beginningState);
            createTable();
        }

        public void createTable()
        {
            List<char> list = new List<char>();
            List<char> list2 = new List<char>();
            List<char> list3 = new List<char>();
            List<char> list4 = new List<char>();
            List<char> list5 = new List<char>();


            list.Add('a');
            list.Add('e');
            table.Add('A', list);

            list2.Add('c');
            list2.Add('ç');
            table.Add('C', list2);

            list3.Add('d');
            list3.Add('t');
            table.Add('D', list3);

            list4.Add('ı');
            list4.Add('i');
            list4.Add('u');
            list4.Add('ü');
            table.Add('H', list4);

            list5.Add('ı');
            list5.Add('i');
            table.Add('I', list5);
        }

        public void permitizer(State sFrom, State sTo, List<string> strList)
        {
            foreach (string s in strList)
            {
                machine.Configure(sFrom)
                    .Permit(s, sTo);
            }
        }

        public void permitizer(State sFrom, State sTo, string trig)
        {
            machine.Configure(sFrom)
                    .Permit(trig, sTo);
        }

        public void filter(State sFrom, State sTo, List<string> transition)
        {
            string suffix = "";
            bool flag = false;
            for (int i = 0; i < transition.Count; i++)
            {
                if (flag)
                {
                    i = 0;
                    flag = false;
                }
                suffix = transition[i];
                for (int j = 0; j < suffix.Length; j++)
                {
                    suffix = transition[i];
                    char c = suffix[j];
                    if (c >= 65 && c <= 90)
                    {
                        flag = true;
                        if (!table.ContainsKey(c)) throw new Exception("(1)Error: Key is not exist in table");
                        transition.RemoveAt(i);
                        List<char> tmp = table[c];
                        foreach (var item in tmp)
                        {
                            suffix = suffix.Remove(j, 1);
                            suffix = suffix.Insert(j, item.ToString());
                            transition.Add(suffix);
                        }

                    }

                }
            }
            permitizer(sFrom, sTo, transition);
        }
    
        public void setState(State s)
        {
            string trigger = s.ToString();
            if (!machine.CanFire(trigger))
            {
                permitizer(machine.State, s, trigger);
                machine.Fire(trigger);
            }
        }

        public bool CanFire(string trigger)
        {
            return machine.CanFire(trigger);
        }

        public void Fire(string trigger)
        {
            try
            {
                machine.Fire(trigger);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public State getState()
        {
            return machine.State;
        }

    }
}
