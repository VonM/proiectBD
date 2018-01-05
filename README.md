# Ticket Manager

- Calea catre fisierul database.mdf cu baza de date trebuie specificata in clasa  
```
Program.cs:26: Database.Instance().SetConnection("C:\\Madalin\\TicketManager\\database.mdf");   
```
- La fiecare rulare, baza de date este populata cu doua tabele "tickets" si "users" in cele doua query-uri sql aflate in fisierele PopulateTicketsTable.sql si PopulateUsersTable.sql.

- Tranzitia intre mai multe form-uri se face cu ajutorul clasei FormStorer care retine static un Dictionar si o Stiva cu form-urile accesate anterior.

### Login
- Utilizatorii impliciti din baza de date au parola "pass" + username, de exemplu pentru utilizatorul "madalin" parola este "passmadalin", pentru utilizatorul "cristi", parola este "passcristi".
- Parolele utilizatorilor nu sunt retinute in clar in baza de date, ci sunt retinute hash-urile sha256 ale acestora. La logare se compara hash-ul parolei introduse cu cel din baza de date. De exemplu, daca utilizatorul "madalin" introduce parola X atunci se verifica daca sha256(X) == sha256("passmadalin").

### Dashboard
- Daca logarea s-a realizat cu success, utilizatorul intra in form-ul Dashboard. Aici, el poate observa in coltul din dreapta sus username-ul sau, rolul sau (Admin, Employee sau Ticket_Editor) si departamentul in care se afla. Utilizatorul curent impreuna cu caracteristicile sale sunt retinuti static in clasa LocalStore si actualizati la fiecare logare realizata cu succes.
- De asemenea, in dashboard utilizatorul are acces la un nou form in care poate vizualiza/modifica utilizatorii, un form in care poate crea tickete si un form in care poate raspunde la ticketele adresate acestuia si/sau poate vizualiza alte tickete create anterior.


### Users Panel
- Acest form contine un tabel cu toti utilizatorii din sistem. Daca utilizatorul logat este admin, atunci el are dreptul de a modifica proprietatile oricarui utilizator, de a sterge utilizatori sau de a adauga utilizatori in sistem. 
- La fiecare accesare a acestui form (apasarea butonului Users Panel din Dashboard) se face un query in baza de date si se selecteaza toti utilizatorii.

### Create Ticket
- In acest form orice utilizator poate crea un tichet adresat unui utilizator cu rolul de Ticket_Editor.

### Tickets Panel
- In acest form un utilizator poate vizualiza tichetele create in sistem. La apasarea butonului Filter, acestea sunt afisate intr-un tabel in functie de filtrele alese. 
- Daca utilizatorul logat este admin, el va putea vizualiza toate tichetele din sistem si le poate actualiza starea + descrierea. 
- Daca utilizatorul este un Ticket_Editor, el va putea vizualiza doar tichetele adresate acestuia si tichetele pe care el le-a scris. De asemenea, poate actualiza starea + descrierea acestora. 
- Daca utilizatorul este un Employee atunci el poate vizualiza doar tichetele scrise de el.
- La apasarea butonului "Update", tichetele sunt actualizate in baza de date.
- In coltul din dreapta sus, tabelul de tichete curent poate fi exportat intr-un fisier intr-un format preferat.
