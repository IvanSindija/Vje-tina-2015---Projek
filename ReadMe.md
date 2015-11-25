OPIS PROJEKTNOG ZADATKA

Za projektni zadatak smo odlu�ili napraviti web aplikaciju za igranje karta�ke igre tresete.
 Aplikaciji ce korisnici pristupati kroz nekoliko faza.
1.	Faza
Prijava za koristiti aplikaciju korisnici se mogu prijaviti kao gost ili mogu napraviti korisni�ki ra�un 
s korisni�kim ra�unom dolazi rejting igra�a koji se mijenja ovisno o tome koliko je igra� uspje�an.
2.	Faza
Nakon prve faze korisnik dolazi do faze u kojoj mo�e odabrati sobu za igru kada u�e 
u sobu igra� mora �ekati da se soba napuni 4 ili 2 igra�a.
3.	Faza
Aktivan faza igra� partiju i mo�e koristiti chat za komunikaciju s drugim 
igra�ima po zavr�etku partije dobije opciju da igra revan� ili da se vrati u 2. Fazu.


Koristiti �emo signalR library za komunikaciju klijenta i poslu�itelja. SignalR library
 omogu�uje komunikaciju u oba smjera klijent->poslu�itelj i poslu�itelj-> klijent to radi pomo�u WebSockets .
 
Na� �e programski sustav biti povezan s bazom podataka u kojoj �e biti spremljeni podatci korisnika i njihov osobni rejting.
 Rejting ce se smanjivati pove�avati ovisno o pobjedama/porazima.
Koristi �emo se oblikovnim obrascem MVC (Model � View � Controller) koji, iako je jedan od 
jednostavnijih, dobro do�arava svu mo� i prednost objektno orijentiranog jezika.
MVC obrazac odvaja prezentacijski, logi�ki i podatkovni dio aplikacije.

Podijelili smo si zadatak i 4 djela:
1.Login i registracija
2.Pronalazak i ulazak u sobu
3.Chat
4. Aktivni dio igre