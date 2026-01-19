Start

Create Klinika

Print "Wybierz cyfrę"

Switch ( input ):
1. [Z] Zarządzanie kliniką:
   - [D] Dodaj:
      - [1] Lekarza (Imie, Nazwisko, NrTelefonu, ?Specjalizacja)
      - [2] Zwierze (Imie, Gatunek, ?DataUrodzenia, ?Wlasciciel)
      - [3] Wlasciciela (Imie, Nazwisko, ?NrTelefonu)
      - [4] Lek (Nazwa, ?Konflikty)
      - [Q] Wróć do "Zarządzanie"
   - [A] Archiwizuj: 
        > *dalej jest ich historia w klinice, nie można już dodawać do wizyt*
      - [1] Lekarza
        > *wyszukiwanie, po czym można __[S] Wybrać po Id__ lub __[Q] Wrócić do Archiwizuj__*
      - [2] Zwierze 
      - [3] Lek
      - [Q] Wróć do "Zarządzanie"
   - [C] (Change) Zmień dane:
      - [1] Lekarza
        > *wyszukiwanie, po czym można __[S] Wybrać po Id__ lub __[Q] Wrócić do Zmień dane__*
        >
        > *wpisz __Imię__ Enter | wpisz __Nazwisko__ Enter | wpisz __NrTelefonu__ Enter | wpisz __Specjalizacje__ Enter | wywołanie metody*
      - [2] Zwierzęcia
        - [D] Dodaj Właściciela
            > *wpisz __Id__*
        - [R] (Remove) Usuń Właściciela
            > *wpisz __Id__*
        - [U] (Update) Zaktualizuj dane
            > *wpisz __Imię__, wpisz __DatęUrodzenia__* 
      - [3] Właściciela 
      - [Q] Wróć do "Zarządzanie"
   - [Q] Wróć do "Ekran główny"
2. [W] Wyszukaj:
    - [1] Zwierzę:
        > *wpisz __Imię__ Enter | wpisz __Gatunek__ Enter, wyświetlają się matche w formacie: __Id__, __Imię__, __Gatunek__, __Właściciele__ (Imię Nazwisko, Imię Nazwisko...), __Wiek__*
        - [S] (Select) Wybierz
            > *można pisać __Id__, po wcisnieciu Enter przechodzi do ekranu Zwierzę:*
            - [V] (Visit) Dodaj wizytę
                > *wpisz __Zalecenia__ Enter | wpisz __Diagnozę__ Enter |  wpisz __Datę__ | wywołanie metody*
            - [H] (History) Historia wizyt
                > *wyświetla __Id__ i __Datę__*
                - [S] Wybierz
                    > *można pisać __Id__, po wcisnieciu Enter otwiera plik w folderze Dokumenty* 
            - [M] (Meds) Przepisz lek
        - [W] Wyszukaj ponownie w "Zwierzęta"
        - [Q] Wróć do "Wyszukaj"
    - [2] Właściciela
        > *wpisz __Imię__ Enter | wpisz __Nazwisko__ Enter, wyświetlają się matche w formacie: __Id_Zwierzęcia__, __Imię_Zwierzęcia__, __Gatunek__, __Właściciele__ (Imię Nazwisko, Imię Nazwisko...), __Wiek__*
        - [S] (Select) Wybierz
            > *można pisać __Id__, po wcisnieciu Enter przechodzi do ekranu Zwierzę:*
        - [W] Wyszukaj ponownie w "Właściciele"
        - [Q] Wróć do "Wyszukaj"
3. [Q] Zamknij program i zapisz stan do JSON

END


kazde dodanie wizyty, zmiana danych, dodanie, archiwizacja zapisuje stan kliniki do JSON
