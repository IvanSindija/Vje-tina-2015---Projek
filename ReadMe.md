OPIS PROJEKTNOG ZADATKA

Za projektni zadatak smo odlučili napraviti web aplikaciju za igranje kartaške igre trešete.
 Aplikaciji će korisnici pristupati kroz nekoliko faza.
 
Prijava za koristiti aplikaciju:  
Korisnik se može prijaviti kao gost ili može napraviti korisnički račun.  
S korisničkim računom dolazi rejting igrača koji se mijenja ovisno o tome koliko je igrač uspješan.  

Nakon prijavljivanja korisnik dolazi do sučelja gdje može birati kakvu vrstu igre želi igrati:  
1) Protiv drugih igrača:  
Igrač će ući u sobu gdje će čekati da se skupi dovoljno igrača za početak partije. Minimalan broj igrača potreban za početak partije je 4.  
Igrači igraju u timovima (2 na 2). Igrač koji je stvorio sobu može birati do koliko bodova će se igrati (opcije su 21, 31 i 41 bod).  
Tim koji prvi ostvari traženi prag bodova je pobjednik. Ako oba tima pređu prag bodova, pobjednik je tim koji ima više bodova. Inače je nerješeno.  
Igračima koji su u pobjedničkom timu podiže se rejting. Ako je nerješeno svim igračima se podiže rejting, ali manje nego što bi bilo u slučaju da su pobijedili.  
Za vrijeme igranja igrači mogu koristiti chat za međusobnu komunikaciju.  
Po završetku igre igrači mogu birati žele li revanš ili će se vratiti u odabir soba. Revanš će nastupiti samo ako sva 4 igrača izraze želju za time.  

2) Protiv računala:  
Ova opcija će biti u svrhu vježbanja igre protiv računala. Igrač ne dobiva nikakav rejting niti bodove. 
Za razliku od opcije "Igranje protiv drugih igrača" gdje se igra u parovima, u ovoj opciji igrač će igrati protiv računala 1 na 1.

Također postojat će opcija biranja tutoriala gdje će igraču biti objašnjena pravila igre i upute za korištenje same aplikacije.


Koristiti ćemo signalR library za komunikaciju klijenta i poslužitelja. SignalR library
 omogućuje komunikaciju u oba smjera klijent -> poslužitelj i poslužitelj -> klijent. To radi pomoću WebSockets.
 
Naš će programski sustav biti povezan s bazom podataka u kojoj će biti spremljeni podatci korisnika i njihov osobni rejting.
 Rejting će se povećavati/smanjivati ovisno o pobjedama/porazima.
Koristi ćemo se oblikovnim obrascem MVC (Model – View – Controller) koji, iako je jedan od 
jednostavnijih, dobro dočarava svu moć i prednost objektno orijentiranog jezika.
MVC obrazac odvaja prezentacijski, logički i podatkovni dio aplikacije.

Podijelili smo si zadatak u sljedeće dijelove:  
-Izrada sučelja za login i registraciju  
-Izrada glavnog sučelja (pronalazak soba, profil igrača, biranje vrste igre)  
-Izrada chata  
-Izrada aktivnog dijela igre:  
	Igranje protiv drugih igrača  
	Igranje protiv računala  
	Pisanje tutoriala  
