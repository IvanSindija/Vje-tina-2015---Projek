OPIS PROJEKTNOG ZADATKA

Za projektni zadatak smo odlučili napraviti web aplikaciju za igranje kartaške igre tresete.
 Aplikaciji ce korisnici pristupati kroz nekoliko faza.
 
Prijava za koristiti aplikaciju korisnici se mogu prijaviti kao gost ili mogu napraviti korisnički račun 
s korisničkim računom dolazi rejting igraća koji se mijenja ovisno o tome koliko je igrač uspješan.

Nakon prijavljivanja korisnik dolazi do faze u kojoj može odabrati sobu za igru kada uđe 
u sobu igrač mora čekati da se soba napuni 4 ili 2 igraća.

Aktivan faza igrač partiju i može koristiti chat za komunikaciju s drugim 
igračima po završetku partije dobije opciju da igra revanš ili da se vrati u odabir soba.


Koristiti ćemo signalR library za komunikaciju klijenta i poslužitelja. SignalR library
 omogućuje komunikaciju u oba smjera klijent->poslužitelj i poslužitelj-> klijent to radi pomoću WebSockets .
 
Naš će programski sustav biti povezan s bazom podataka u kojoj će biti spremljeni podatci korisnika i njihov osobni rejting.
 Rejting ce se smanjivati povećavati ovisno o pobjedama/porazima.
Koristi ćemo se oblikovnim obrascem MVC (Model – View – Controller) koji, iako je jedan od 
jednostavnijih, dobro dočarava svu moć i prednost objektno orijentiranog jezika.
MVC obrazac odvaja prezentacijski, logički i podatkovni dio aplikacije.

Podijelili smo si zadatak i 4 djela:
-Login i registracija
-Pronalazak i ulazak u sobu
-Chat
-Aktivni dio igre
