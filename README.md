# MTTP-Seminar

U ovome seminaru su korišteni NUnit Framework i Selenium Framework za izradu automatskih testova UI sučelja i funkcionalnosti na Amazon stranici. Projekt se sastoji od 2 klase: testne FirstTest klase u kojoj se nalaze svi testovi i pomoćne metode za testove te pomoćne Product klase koja predstavlja pojedini proizvod na stranici.

FirstTest klasa se sastoji od 2 atributa, 6 zasebnih testova, 3 pomoćne metode i metoda za postavljanje i "rastavljanje" Webdriver-a. 

![image](https://user-images.githubusercontent.com/54780312/216853439-699d941f-9f28-463b-903d-c3788ca7fe5b.png)

Atribut "driver" služi za spremanje instance Webdriver-a, dok svojstvo "DriverPath"  sadrži putanju do njega.

![image](https://user-images.githubusercontent.com/54780312/216853476-aa175cc2-9754-46ca-adb3-82d72fc1fa17.png)

Pomoćna metoda "SearchOnAmazon" upisuje u tražilicu zadani pojam.
Metoda "AddFirstProductToCard" dodaje prvi proizvod u karticu u zadanoj količini i kreira Product koji trenutno služi za spremanje naslova i cijene proizvoda, a može biti proširen sa bilo kojim podatcima koji su vezani za proizvod i koji se mogu dohvatiti sa stranice proizvoda.
"ChangeQuantity" mijenja količinu na stranici proizvoda.

![image](https://user-images.githubusercontent.com/54780312/216854201-a68f56a3-bd9e-45fe-b11a-cb231d457cd3.png)

Test 1 - Traženje proizvoda
U testu 1 koristi se metoda "SearchOnAmazon" kojoj je predan parametar "Headphones", nakon toga uspoređuje se je li traženje pojma bilo uspješno.

![image](https://user-images.githubusercontent.com/54780312/216854215-fa79b00d-a2d8-42bb-b887-0437871a562f.png)

Test 2 - Dodavanje proizvoda u karticu
U testu 2 dodaje se 1 proizvod u karticu korištenjem metode "AddFirstProductToCart", a uspješnost se provjerava je li se cijena u kartici ispravno promijenila.

![image](https://user-images.githubusercontent.com/54780312/216854307-f2cc5798-3aa1-4b84-ba57-170f2d305d43.png)

Test 3 - Dodavanje više proizvoda u karticu
U testu 3 dodaje se 3 proizvod u karticu korištenjem metode "AddFirstProductToCart", a uspješnost se provjerava je li se cijena u kartici ispravno promijenila.

![image](https://user-images.githubusercontent.com/54780312/216854380-889c278d-5240-447e-9deb-08e3c5de0da6.png)

Test 4 - Odlazak u karticu
U testu 4 testira se gumb za pregled kartice, a uspješnost se potvrđuje naslovom stranice.

![image](https://user-images.githubusercontent.com/54780312/216854759-d939f12f-662b-49c2-93be-7803bdbae565.png)

Test 5 - Izmjena količine u kartici
U testu 5 testira se izmjena količine proizvoda u kartici.

![image](https://user-images.githubusercontent.com/54780312/216854821-5cf1a787-f5ea-4c95-a4af-3c9318fb5827.png)

Test 6 - Checkout
U testu 6 testira se gumb "Checkout" nakon dodavanja proizvoda.
