OPIS PROJEKTNOG ZADATKA

Za projektni zadatak smo odlučili napraviti web aplikaciju za igranje kartaške igre trešete.
 Aplikaciji će korisnici pristupati kroz nekoliko faza.  

Nakon prijavljivanja korisnik dolazi do sučelja gdje može birati kakvu vrstu igre želi igrati:  
1) Protiv drugih igrača:  
Igrač će ući u sobu gdje će čekati da se skupi dovoljno igrača za početak partije. Minimalan broj igrača potreban za početak partije je 4.  
Igrači igraju u timovima (2 na 2). Tim koji prvi ostvari traženi prag bodova je pobjednik. Ako oba tima pređu prag bodova, pobjednik je tim koji ima više bodova. Inače je nerješeno.  
Za vrijeme igranja igrači mogu koristiti chat za međusobnu komunikaciju.  

2) Protiv računala:  
Ova opcija će biti u svrhu vježbanja igre protiv računala. Igrač ne dobiva nikakav rejting niti bodove. 
Za razliku od opcije "Igranje protiv drugih igrača" gdje se igra u parovima, u ovoj opciji igrač će igrati protiv računala 1 na 1.

Također postojat će opcija biranja tutoriala gdje će igraču biti objašnjena pravila igre i upute za korištenje same aplikacije.


Koristiti ćemo signalR library za komunikaciju klijenta i poslužitelja. SignalR library
 omogućuje komunikaciju u oba smjera klijent -> poslužitelj i poslužitelj -> klijent. To radi pomoću WebSockets.
 
Koristi ćemo se oblikovnim obrascem MVC (Model – View – Controller) koji, iako je jedan od 
jednostavnijih, dobro dočarava svu moć i prednost objektno orijentiranog jezika.
MVC obrazac odvaja prezentacijski, logički i podatkovni dio aplikacije.

Podijelili smo si zadatak u sljedeće dijelove:  
-Izrada sučelja za login 
-Izrada glavnog sučelja (pronalazak soba, profil igrača, biranje vrste igre)  
-Izrada chata  
-Izrada aktivnog dijela igre:  
	Igranje protiv drugih igrača  
	Igranje protiv računala  
	Pisanje tutoriala  
