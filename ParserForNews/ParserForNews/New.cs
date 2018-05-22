using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParserForNews
{
    class New
    {
        public int output;
        public double devlet;
        public double düşüş;
        public double düzey;
        public double eğilim;
        public double ekonomi;
        public double enflasyon;
        public double firma;
        public double fiyat;
        public double fuar;
        public double ihale;
        public double ihraç;
        public double kalkınma;
        public double kamu;
        public double petrol;
        public double taahhüt;
        public double tutma;
        public double ürün;
        public double yatırım;
        public double yükseliş;
        public double yüzde;
        public double aşk;
        public double kilo;
        public double arkadaş;
        public double film;
        public double televizyon;
        public double program;
        public double yıldız;
        public double tatil;
        public double kostüm;
        public double oyuncu;
        public double dizi;
        public double sevgili;
        public double parti;
        public double rol;
        public double genç;
        public double çekim;
        public double başrol;
        public double defile;
        public double albüm;
        public double yayın;
        public double tıp;
        public double hastane;
        public double sağlık;
        public double ilaç;
        public double ameliyat;
        public double hasta;
        public double doktor;
        public double bebek;
        public double tespit;
        public double tedavi;
        public double insan;
        public double çocuk;
        public double kanser;
        public double vitamin;
        public double ağrı;
        public double cerrah;
        public double kontrol;
        public double diyabet;
        public double kalp;
        public double tansiyon;
        public double bakan;
        public double hükümet;
        public double meclis;
        public double seçim;
        public double oy;
        public double halk;
        public double demokrasi;
        public double anayasa;
        public double yetki;
        public double yargı;
        public double savcı;
        public double yasak;
        public double ceza;
        public double slogan;
        public double miting;
        public double laik;
        public double mahkeme;
        public double ulus;
        public double elçi;
        public double heyet;
        public double fark;
        public double fikstür;
        public double forma;
        public double futbol;
        public double galibiyet;
        public double gol;
        public double hakem;
        public double kart;
        public double lider;
        public double lig;
        public double maç;
        public double menajer;
        public double pozisyon;
        public double puan;
        public double saha;
        public double spor;
        public double stad;
        public double şampiyon;
        public double teşvik;
        public double transfer;

        public New()
        {
            double devlet = 0;
            double düşüş = 0;
            double düzey = 0;
            double eğilim = 0;
            double ekonomi = 0;
            double enflasyon = 0;
            double firma = 0;
            double fiyat = 0;
            double fuar = 0;
            double ihale = 0;
            double ihraç = 0;
            double kalkınma = 0;
            double kamu = 0;
            double petrol = 0;
            double taahhüt = 0;
            double tutma = 0;
            double ürün = 0;
            double yatırım = 0;
            double yükseliş = 0;
            double yüzde = 0;
            double aşk = 0;
            double kilo = 0;
            double arkadaş = 0;
            double film = 0;
            double televizyon = 0;
            double program = 0;
            double yıldız = 0;
            double tatil = 0;
            double kostüm = 0;
            double oyuncu = 0;
            double dizi = 0;
            double sevgili = 0;
            double parti = 0;
            double rol = 0;
            double genç = 0;
            double çekim = 0;
            double başrol = 0;
            double defile = 0;
            double albüm = 0;
            double yayın = 0;
            double tıp = 0;
            double hastane = 0;
            double sağlık = 0;
            double ilaç = 0;
            double ameliyat = 0;
            double hasta = 0;
            double doktor = 0;
            double bebek = 0;
            double tespit = 0;
            double tedavi = 0;
            double insan = 0;
            double çocuk = 0;
            double kanser = 0;
            double vitamin = 0;
            double ağrı = 0;
            double cerrah = 0;
            double kontrol = 0;
            double diyabet = 0;
            double kalp = 0;
            double tansiyon = 0;
            double bakan = 0;
            double hükümet = 0;
            double meclis = 0;
            double seçim = 0;
            double oy = 0;
            double halk = 0;
            double demokrasi = 0;
            double anayasa = 0;
            double yetki = 0;
            double yargı = 0;
            double savcı = 0;
            double yasak = 0;
            double ceza = 0;
            double slogan = 0;
            double miting = 0;
            double laik = 0;
            double mahkeme = 0;
            double ulus = 0;
            double elçi = 0;
            double heyet = 0;
            double fark = 0;
            double fikstür = 0;
            double forma = 0;
            double futbol = 0;
            double galibiyet= 0;
            double gol = 0;
            double hakem = 0;
            double kart = 0;
            double lider = 0;
            double lig = 0;
            double maç = 0;
            double menajer = 0;
            double pozisyon = 0;
            double puan = 0;
            double saha = 0;
            double spor = 0;
            double stad = 0;
            double şampiyon = 0;
            double teşvik = 0;
            double transfer = 0;
 
        }

        public void Parse(int output, string s, double[] frequency, ref int wordCount)
        {
            this.output = output;
            s = s.ToLower();
            string[] words = s.Split(' ');
            int totalWordInNew = 0;

            wordCount += words.Length;

            foreach (string word in words)
            {
                if (word.Contains("devlet"))
                {
                    devlet++;
                    frequency[0]++; 
                }

                if (word.Contains("düşüş"))
                {
                    düşüş++;
                    frequency[1]++;
                }

                if (word.Contains("düzey"))
                {
                    düzey++;
                    frequency[2]++;
                }

                if (word.Contains("eğilim"))
                {
                    eğilim++;
                    frequency[3]++;
                }

                if (word.Contains("ekonomi"))
                {
                    ekonomi++;
                    frequency[4]++;
                }

                if (word.Contains("enflasyon"))
                {
                    enflasyon++;
                    frequency[5]++;
                }

                if (word.Contains("firma"))
                {
                    firma++;
                    frequency[6]++;
                }

                if (word.Contains("fiyat"))
                {
                    fiyat++;
                    frequency[7]++;
                }

                if (word.Contains("fuar"))
                {
                    fuar++;
                    frequency[8]++;
                }

                if (word.Contains("ihale"))
                {
                    ihale++;
                    frequency[9]++;
                }

                if (word.Contains("ihraç"))
                {
                    ihraç++;
                    frequency[10]++;
                }
                else 
                {
                    if (word.Contains("ihrac"))
                    {
                        ihraç++;
                        frequency[10]++;
                    }
                }

                if (word.Contains("kalkınma"))
                {
                    kalkınma++;
                    frequency[11]++;
                }

                if (word.Contains("kamu"))
                {
                    kamu++;
                    frequency[12]++;
                }

                if (word.Contains("petrol"))
                {
                    petrol++;
                    frequency[13]++;
                }

                if (word.Contains("taahhüt"))
                {
                    taahhüt++;
                    frequency[14]++;
                }

                if (word.Contains("tutma"))
                {
                    tutma++;
                    frequency[15]++;
                }

                if (word.Contains("ürün"))
                {
                    ürün++;
                    frequency[16]++;
                }

                if (word.Contains("yatırım"))
                {
                    yatırım++;
                    frequency[17]++;
                }

                if (word.Contains("yükseliş"))
                {
                    yükseliş++;
                    frequency[18]++;
                }

                if (word.Contains("yüzde"))
                {
                    yüzde++;
                    frequency[19]++;
                }

                if (word.Contains("aşk"))
                {
                    aşk++;
                    frequency[20]++;
                }

                if (word.Contains("kilo"))
                {
                    kilo++;
                    frequency[21]++;
                }

                if (word.Contains("arkadaş"))
                {
                    arkadaş++;
                    frequency[22]++;
                }

                if (word.Contains("film"))
                {
                    film++;
                    frequency[23]++;
                }

                if (word.Contains("televizyon"))
                {
                    televizyon++;
                    frequency[24]++;
                }

                if (word.Contains("program"))
                {
                    program++;
                    frequency[25]++;
                }

                if (word.Contains("yıldız"))
                {
                    yıldız++;
                    frequency[26]++;
                }

                if (word.Contains("tatil"))
                {
                    tatil++;
                    frequency[27]++;
                }

                if (word.Contains("kostüm"))
                {
                    kostüm++;
                    frequency[28]++;
                }

                if (word.Contains("oyuncu"))
                {
                    oyuncu++;
                    frequency[29]++;
                }

                if (word.Contains("dizi"))
                {
                    dizi++;
                    frequency[30]++;
                }

                if (word.Contains("sevgili"))
                {
                    sevgili++;
                    frequency[31]++;
                }

                if (word.Contains("parti"))
                {
                    parti++;
                    frequency[32]++;
                }

                if (word.Contains("rol"))
                {
                    rol++;
                    frequency[33]++;
                }

                if (word.Contains("genç"))
                {
                    genç++;
                    frequency[34]++;
                }
                else 
                {
                    if (word.Contains("genc"))
                    {
                        genç++;
                        frequency[35]++;
                    }
                }

                if (word.Contains("çekim"))
                {
                    çekim++;
                    frequency[35]++;
                }

                if (word.Contains("başrol"))
                {
                    başrol++;
                    frequency[36]++;
                }

                if (word.Contains("defile"))
                {
                    defile++;
                    frequency[37]++;
                }

                if (word.Contains("albüm"))
                {
                    albüm++;
                    frequency[38]++;
                }

                if (word.Contains("yayın"))
                {
                    yayın++;
                    frequency[39]++;
                }

                if (word.Contains("tıp"))
                {
                    tıp++;
                    frequency[40]++;
                }

                if (word.Contains("hastane"))
                {
                    hastane++;
                    frequency[41]++;
                }
 

                if (word.Contains("sağlık"))
                {
                    sağlık++;
                    frequency[42]++;
                }

                if (word.Contains("ilaç"))
                {
                    ilaç++;
                    frequency[43]++;
                }
                else
                {
                    if (word.Contains("ilac"))
                    {
                        ilaç++;
                        frequency[43]++;
                    }
                }

                if (word.Contains("ameliyat"))
                {
                    ameliyat++;
                    frequency[44]++;
                }

                if (word.Contains("hasta"))
                {
                    hasta++;
                    frequency[45]++;
                }

                if (word.Contains("doktor"))
                {
                    doktor++;
                    frequency[46]++;
                }

                if (word.Contains("bebek"))
                {
                    bebek++;
                    frequency[47]++;
                }

                if (word.Contains("tespit"))
                {
                    tespit++;
                    frequency[48]++;
                }

                if (word.Contains("tedavi"))
                {
                    tedavi++;
                    frequency[49]++;
                }

                if (word.Contains("insan"))
                {
                    insan++;
                    frequency[50]++;
                }

                if (word.Contains("çocuk"))
                {
                    çocuk++;
                    frequency[51]++;
                }

                if (word.Contains("kanser"))
                {
                    kanser++;
                    frequency[52]++;
                }

                if (word.Contains("vitamin"))
                {
                    vitamin++;
                    frequency[53]++;
                }

                if (word.Contains("ağrı"))
                {
                    ağrı++;
                    frequency[54]++;
                }

                if (word.Contains("cerrah"))
                {
                    cerrah++;
                    frequency[55]++;
                }

                if (word.Contains("kontrol"))
                {
                    kontrol++;
                    frequency[56]++;
                }

                if (word.Contains("diyabet"))
                {
                    diyabet++;
                    frequency[57]++;
                }

                if (word.Contains("kalp"))
                {
                    kalp++;
                    frequency[58]++;
                }

                if (word.Contains("tansiyon"))
                {
                    tansiyon++;
                    frequency[59]++;
                }

                if (word.Contains("bakan"))
                {
                    bakan++;
                    frequency[60]++;
                }

                if (word.Contains("hükümet"))
                {
                    hükümet++;
                    frequency[61]++;
                }

                if (word.Contains("meclis"))
                {
                    meclis++;
                    frequency[62]++;
                }

                if (word.Contains("seçim"))
                {
                    seçim++;
                    frequency[63]++;
                }

                if (word.Contains("oy"))
                {
                    oy++;
                    frequency[64]++;
                }

                if (word.Contains("halk"))
                {
                    halk++;
                    frequency[65]++;
                }

                if (word.Contains("demokrasi"))
                {
                    demokrasi++;
                    frequency[66]++;
                }

                if (word.Contains("anayasa"))
                {
                    anayasa++;
                    frequency[67]++;
                }

                if (word.Contains("yetki"))
                {
                    yetki++;
                    frequency[68]++;
                }

                if (word.Contains("yargı"))
                {
                    yargı++;
                    frequency[69]++;
                }

                if (word.Contains("savcı"))
                {
                    savcı++;
                    frequency[70]++;
                }

                if (word.Contains("yasak"))
                {
                    yasak++;
                    frequency[71]++;
                }

                if (word.Contains("ceza"))
                {
                    ceza++;
                    frequency[72]++;
                }

                if (word.Contains("slogan"))
                {
                    slogan++;
                    frequency[73]++;
                }

                if (word.Contains("miting"))
                {
                    miting++;
                    frequency[74]++;
                }

                if (word.Contains("laik"))
                {
                    laik++;
                    frequency[75]++;
                }

                if (word.Contains("mahkeme"))
                {
                    mahkeme++;
                    frequency[76]++;
                }

                if (word.Contains("ulus"))
                {
                    ulus++;
                    frequency[77]++;
                }

                if (word.Contains("elçi"))
                {
                    elçi++;
                    frequency[78]++;
                }

                if (word.Contains("heyet"))
                {
                    heyet++;
                    frequency[79]++;
                }

                if (word.Contains("fark"))
                {
                    fark++;
                    frequency[80]++;
                }

                if (word.Contains("fikstür"))
                {
                    fikstür++;
                    frequency[81]++;
                }

                if (word.Contains("forma"))
                {
                    forma++;
                    frequency[82]++;
                }

                if (word.Contains("futbol"))
                {
                    futbol++;
                    frequency[83]++;
                }

                if (word.Contains("galibiyet"))
                {
                    galibiyet++;
                    frequency[84]++;
                }

                if (word.Contains("gol"))
                {
                    gol++;
                    frequency[85]++;
                }

                if (word.Contains("hakem"))
                {
                    hakem++;
                    frequency[86]++;
                }

                if (word.Contains("kart"))
                {
                    kart++;
                    frequency[87]++;
                }

                if (word.Contains("lider"))
                {
                    lider++;
                    frequency[88]++;
                }

                if (word.Contains("lig"))
                {
                    lig++;
                    frequency[89]++;
                }

                if (word.Contains("maç"))
                {
                    maç++;
                    frequency[90]++;
                }
                else
                {
                    if (word.Contains("mac"))
                    {
                        maç++;
                        frequency[90]++;
                    }
                }

                if (word.Contains("menajer"))
                {
                    menajer++;
                    frequency[91]++;
                }

                if (word.Contains("pozisyon"))
                {
                    pozisyon++;
                    frequency[92]++;
                }

                if (word.Contains("puan"))
                {
                    puan++;
                    frequency[93]++;
                }

                if (word.Contains("saha"))
                {
                    saha++;
                    frequency[94]++;
                }

                if (word.Contains("spor"))
                {
                    spor++;
                    frequency[95]++;
                }

                if (word.Contains("stad"))
                {
                    stad++;
                    frequency[96]++;
                }

                if (word.Contains("şampiyon"))
                {
                    şampiyon++;
                    frequency[97]++;
                }

                if (word.Contains("teşvik"))
                {
                    teşvik++;
                    frequency[98]++;
                }

                if (word.Contains("transfer"))
                {
                    transfer++;
                    frequency[99]++;
                }
            }

            devlet = devlet / words.Length;
            düşüş = düşüş / words.Length;
            düzey = düzey / words.Length;
            eğilim = eğilim / words.Length;
            ekonomi = ekonomi / words.Length;
            enflasyon = enflasyon / words.Length;
            firma = firma / words.Length;
            fiyat = fiyat / words.Length;
            fuar = fuar / words.Length;
            ihale = ihale / words.Length;
            ihraç = ihraç / words.Length;
            kalkınma = kalkınma / words.Length;
            kamu = kamu / words.Length;
            petrol = petrol / words.Length;
            taahhüt = taahhüt / words.Length;
            tutma = tutma / words.Length;
            ürün = ürün / words.Length;
            yatırım = yatırım / words.Length;
            yükseliş = yükseliş / words.Length;
            yüzde = yüzde / words.Length;
            aşk = aşk / words.Length;
            kilo = kilo / words.Length;
            arkadaş = arkadaş / words.Length;
            film = film / words.Length;
            televizyon = televizyon / words.Length;
            program = program / words.Length;
            yıldız = yıldız / words.Length;
            tatil = tatil / words.Length;
            kostüm = kostüm / words.Length;
            oyuncu = oyuncu / words.Length;
            dizi = dizi / words.Length;
            sevgili = sevgili / words.Length;
            parti = parti / words.Length;
            rol = rol / words.Length;
            genç = genç / words.Length;
            çekim = çekim / words.Length;
            başrol = başrol / words.Length;
            defile = defile / words.Length;
            albüm = albüm / words.Length;
            yayın = yayın / words.Length;
            tıp = tıp / words.Length;
            hastane = hastane / words.Length;
            sağlık = sağlık / words.Length;
            ilaç = ilaç / words.Length;
            ameliyat = ameliyat / words.Length;
            hasta = hasta / words.Length;
            doktor = doktor / words.Length;
            bebek = bebek / words.Length;
            tespit = tespit / words.Length;
            tedavi = tedavi / words.Length;
            insan = insan / words.Length;
            çocuk = çocuk / words.Length;
            kanser = kanser / words.Length;
            vitamin = vitamin / words.Length;
            ağrı = ağrı / words.Length;
            cerrah = cerrah / words.Length;
            kontrol = kontrol / words.Length;
            diyabet = diyabet / words.Length;
            kalp = kalp / words.Length;
            tansiyon = tansiyon / words.Length;
            bakan = bakan / words.Length;
            hükümet = hükümet / words.Length;
            meclis = meclis / words.Length;
            seçim = seçim / words.Length;
            oy = oy / words.Length;
            halk = halk / words.Length;
            demokrasi = demokrasi / words.Length;
            anayasa = anayasa / words.Length;
            yetki = yetki / words.Length;
            yargı = yargı / words.Length;
            savcı = savcı / words.Length;
            yasak = yasak / words.Length;
            ceza = ceza / words.Length;
            slogan = slogan / words.Length;
            miting = miting / words.Length;
            laik = laik / words.Length;
            mahkeme = mahkeme / words.Length;
            ulus = ulus / words.Length;
            elçi = elçi / words.Length;
            heyet = heyet / words.Length;
            fark = fark / words.Length;
            fikstür = fikstür / words.Length;
            forma = forma / words.Length;
            futbol = futbol / words.Length;
            galibiyet = galibiyet / words.Length;
            gol = gol / words.Length;
            hakem = hakem / words.Length;
            kart = kart / words.Length;
            lider = lider / words.Length;
            lig = lig / words.Length;
            maç = maç / words.Length;
            menajer = menajer / words.Length;
            pozisyon = pozisyon / words.Length;
            puan = puan / words.Length;
            saha = saha / words.Length;
            spor = spor / words.Length;
            stad = stad / words.Length;
            şampiyon = şampiyon / words.Length;
            teşvik = teşvik / words.Length;
            transfer = transfer / words.Length;
        }
    }
}