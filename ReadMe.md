OPIS PROJEKTNOG ZADATKA

Za projektni zadatak smo odluèili napraviti web aplikaciju za igranje kartaške igre tresete.
 Aplikaciji ce korisnici pristupati kroz nekoliko faza.
1.	Faza
Prijava za koristiti aplikaciju korisnici se mogu prijaviti kao gost ili mogu napraviti korisnièki raèun 
s korisnièkim raèunom dolazi rejting igraæa koji se mijenja ovisno o tome koliko je igraè uspješan.
2.	Faza
Nakon prve faze korisnik dolazi do faze u kojoj može odabrati sobu za igru kada uðe 
u sobu igraè mora èekati da se soba napuni 4 ili 2 igraæa.
3.	Faza
Aktivan faza igraè partiju i može koristiti chat za komunikaciju s drugim 
igraèima po završetku partije dobije opciju da igra revanš ili da se vrati u 2. Fazu.


Koristiti æemo signalR library za komunikaciju klijenta i poslužitelja. SignalR library
 omoguæuje komunikaciju u oba smjera klijent->poslužitelj i poslužitelj-> klijent to radi pomoæu WebSockets .
 
Naš æe programski sustav biti povezan s bazom podataka u kojoj æe biti spremljeni podatci korisnika i njihov osobni rejting.
 Rejting ce se smanjivati poveæavati ovisno o pobjedama/porazima.
Koristi æemo se oblikovnim obrascem MVC (Model – View – Controller) koji, iako je jedan od 
jednostavnijih, dobro doèarava svu moæ i prednost objektno orijentiranog jezika.
MVC obrazac odvaja prezentacijski, logièki i podatkovni dio aplikacije.

Podijelili smo si zadatak i 4 djela:
1.Login i registracija
2.Pronalazak i ulazak u sobu
3.Chat
4. Aktivni dio igre