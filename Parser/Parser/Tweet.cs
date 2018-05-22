using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Parser
{
    class Tweet
    {
        public double output;
        public double reklam;
        public double kampanya;
        public double kontör;
        public double mesaj;
        public double sms;
        public double müşteri;
        public double fatura;
        public double geçirmek;
        public double hizmet;
        public double çekim;
        public double kalite;
        public double paket;
        public double tarife;
        public double sponsor;
        public double nefret;
        public double küfür;
        public double bayi;
        public double tim;
        public double lanet;
        public double iletişim;
        public double operatör;
        public double para;
        public double kazık;
        public double lig;
        public double baz;
        public double bis;
        public double internet;
        public double iphone;

        public Tweet()
        {
            reklam = 0;
            kampanya = 0;
            kontör = 0;
            mesaj = 0;
            sms = 0;
            müşteri = 0;
            fatura = 0;
            geçirmek = 0;
            hizmet = 0;
            çekim = 0;
            kalite = 0;
            paket = 0;
            tarife = 0;
            sponsor = 0;
            nefret = 0;
            küfür = 0;
            bayi = 0;
            tim = 0;
            lanet = 0;
            iletişim = 0;
            operatör = 0;
            para = 0;
            kazık = 0;
            lig = 0;
            baz = 0;
            bis = 0;
            internet = 0;
            iphone = 0;
 
        }

        public void Parse(string tweet, double[] frequency, ref int words)
        {

            tweet = tweet.ToLower();
            string[] strArray = tweet.Split(' ');
            int totalWordInTweet = 0;

            foreach (string str in strArray)
            {
                if (str != "")
                {
                    words++;
                    totalWordInTweet++;

                    if (str.Contains("reklam"))
                    {
                        reklam++;
                        frequency[0]++;
                        continue;;
                    }
                    else
                    {
                        if (str.Contains("reklm")) 
                        {
                            reklam++;
                            frequency[0]++;
                            continue;
                        }
                        else
                        {
                            if (str.Contains("rklm")) 
                            {
                                reklam++;
                                frequency[0]++;
                                continue;
                            }
                            else 
                            {
                                if (str.Contains("rklam")) 
                                {
                                    reklam++;
                                    frequency[0]++;
                                    continue;
                                } 
                            }
                        }
                    }

                    if (str.Contains("kampanya"))
                    {
                        kampanya++;
                        frequency[1]++;
                        continue;
                    }
                    else 
                    {
                        if (str.Contains("kampny")) 
                        {
                            kampanya++;
                            frequency[1]++;
                            continue;
                        }
                        else
                        {
                            if (str.Contains("kampy")) 
                            {
                                kampanya++;
                                frequency[1]++;
                                continue;
                            }
                            else
                            {
                                if (str.Contains("kampaya"))
                                {
                                    kampanya++; 
                                    frequency[1]++;
                                    continue;
                                }
                            }
                        }
                    }

                    if(str.Contains("kont"))
                    {
                        kontör++;
                        frequency[2]++;
                        continue;
                    }

                    if (str.Contains("mesaj"))
                    {
                        mesaj++;
                        frequency[3]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("mesj"))
                        {
                            mesaj++;
                            frequency[3]++;
                            continue;
                        }
                        
                    }

                    if (str.Contains("sms"))
                    {
                        sms++;
                        frequency[4]++;
                        continue;
                    }

                    if (str.Contains("musteri"))
                    {
                        müşteri++;
                        frequency[5]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("muşteri"))
                        {
                            müşteri++;
                            frequency[5]++;
                            continue;
                        }
                        else
                        {
                            if (str.Contains("müsteri"))
                            {
                                müşteri++;
                                frequency[5]++;
                                continue;
                            }
                            else
                            {
                                if (str.Contains("müşteri"))
                                {
                                    müşteri++;
                                    frequency[5]++;
                                    continue;
                                }
                            }
                        }
                    }

                    if (str.Contains("fatura"))
                    {
                        fatura++;
                        frequency[6]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("fatra"))
                        {
                            fatura++;
                            frequency[6]++;
                            continue;
                        }
                    }

                    if (str.Contains("geçir"))
                    {
                        geçirmek++;
                        frequency[7]++;
                        continue;
                    }
                    else 
                    {
                        if (str.Contains("gecir"))
                        {
                            geçirmek++;
                            frequency[7]++;
                            continue;
                        }
                    }

                    if (str.Contains("hizmet"))
                    {
                        hizmet++;
                        frequency[8]++;
                        continue;
                    }
                    else 
                    {
                        if (str.Contains("hizmt"))
                        {
                            hizmet++;
                            frequency[8]++;
                            continue;
                        }
                    }


                    if (str.Contains("çekim"))
                    {
                        çekim++;
                        frequency[9]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("çekm"))
                        {
                            çekim++;
                            frequency[9]++;
                            continue;
                        }
                        else
                        {
                            if (str.Contains("cekm"))
                            {
                                çekim++;
                                frequency[9]++;
                                continue;
                            }
                            else
                            {
                                if (str.Contains("cekim"))
                                {
                                    çekim++;
                                    frequency[9]++;
                                    continue;
                                }
                            }
                        }
                    }

                    if (str.Contains("kalite"))
                    {
                        kalite++;
                        frequency[10]++;
                        continue;
                    }

                    if (str.Contains("paket"))
                    {
                        paket++;
                        frequency[11]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("pakt"))
                        {
                            paket++;
                            frequency[11]++;
                            continue;
                        }
                    }

                    if (str.Contains("tarife"))
                    {
                        tarife++;
                        frequency[12]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("tarfe"))
                        {
                            tarife++;
                            frequency[12]++;
                            continue;
                        }
                    }

                    if (str.Contains("sponsor"))
                    {
                        sponsor++;
                        frequency[13]++;
                        continue;
                    }

                    if (str.Contains("nefret"))
                    {
                        nefret++;
                        frequency[14]++;
                        continue;
                    }


                    if (str.Contains("küfür"))
                    {
                        küfür++;
                        frequency[15]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("küfr"))
                        {
                            küfür++;
                            frequency[15]++;
                            continue;
                        }
                    }

                    if (str.Contains("bayi"))
                    {
                        bayi++;
                        frequency[16]++;
                        continue;
                    }

                    if (str.Contains("tim"))
                    {
                        tim++;
                        frequency[17]++;
                        continue;
                    }

                    if (str.Contains("lanet"))
                    {
                        lanet++;
                        frequency[18]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("lant"))
                        {
                            lanet++;
                            frequency[18]++;
                            continue;
                        }
                    }

                    if (str.Contains("iletiş"))
                    {
                        iletişim++;
                        frequency[19]++;
                        continue;
                    }
                    else
                    {
                        if (str.Contains("iletis"))
                        {
                            iletişim++;
                            frequency[19]++;
                            continue;
                        }
                        else
                        {
                            if (str.Contains("ilets"))
                            {
                                iletişim++;
                                frequency[19]++;
                                continue;
                            }
                            else
                            {
                                if (str.Contains("iletş"))
                                {
                                    iletişim++;
                                    frequency[19]++;
                                    continue;
                                }
                            }
                        }
                    }

                    if (str.Contains("operat"))
                    {
                        operatör++;
                        frequency[20]++;
                        continue;
                    }

                    if (str.Contains("para"))
                    {
                        para++;
                        frequency[21]++;
                        continue;
                    }

                    if (str.Contains("kazık"))
                    {
                        kazık++;
                        frequency[22]++;
                        continue;
                    }

                    if (str.Contains("lig"))
                    {
                        lig++;
                        frequency[23]++;
                        continue;
                    }

                    if (str.Contains("baz"))
                    {
                        baz++;
                        frequency[24]++;
                        continue;
                    }

                    if (str.Contains("bis"))
                    {
                        bis++;
                        frequency[25]++;
                        continue;
                    }

                    if (str.Contains("intern"))
                    {
                        internet++;
                        frequency[26]++;
                        continue;
                    }

                    if (str.Contains("iphone"))
                    {
                        iphone++;
                        frequency[27]++;
                        continue;
                    }
                }
            }

            //reklam = reklam / totalWordInTweet;
            //kampanya = kampanya / totalWordInTweet;
            //kontör = kontör / totalWordInTweet;
            //mesaj = mesaj / totalWordInTweet;
            //sms = sms / totalWordInTweet;
            //müşteri = müşteri / totalWordInTweet;
            //fatura = fatura / totalWordInTweet;
            //geçirmek = geçirmek / totalWordInTweet;
            //hizmet = hizmet / totalWordInTweet;
            //çekim = çekim / totalWordInTweet;
            //kalite = kalite / totalWordInTweet;
            //paket = paket / totalWordInTweet;
            //tarife = tarife / totalWordInTweet;
            //sponsor = sponsor / totalWordInTweet;
            //nefret = nefret / totalWordInTweet;
            //küfür = küfür / totalWordInTweet;
            //bayi = bayi / totalWordInTweet;
            //tim = tim / totalWordInTweet;
            //lanet = lanet / totalWordInTweet;
            //lanet = lanet / totalWordInTweet;
            //iletişim = iletişim / totalWordInTweet;
            //operatör = operatör / totalWordInTweet;
            //para = para / totalWordInTweet;
            //kazık = kazık / totalWordInTweet;
            //lig = lig / totalWordInTweet;
            //baz = baz / totalWordInTweet;
            //bis = bis / totalWordInTweet;
            //internet = internet / totalWordInTweet;
            //iphone = iphone / totalWordInTweet;

        }
    }
}
