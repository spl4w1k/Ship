LOW-POLY OCEAN ENVIRONMENT — ZESTAW MODELI 3D DO UNITY 6000.6 (URP)
===================================================================

Zestaw wygenerowany proceduralnie, specjalnie w stylu statku LowPoly_Sailboat_FIXED:
proste plaskie powierzchnie, stonowane kolory, malo wielokatow.
Kazdy plik OBJ to PRAWDZIWA siatka 3D, nie obrazek.

ZAWARTOSC (9 OSOBNYCH MODELI OBJ)
---------------------------------
Island_01_Palm.obj    - wieksza, wypukla zolto-piaskowa wysepka z palma
Island_02_Sand.obj    - mala piaskowa wysepka ze skalami
Palm_01.obj           - dodatkowa palma do samodzielnego ustawienia
Rock_01.obj           - wysoka skala
Rock_02.obj           - szeroka niska skala
Rock_03.obj           - mniejsza wysoka skala
Buoy_01.obj           - czerwono-biala boja
Crate_01.obj          - drewniana skrzynka
Barrel_01.obj         - drewniana beczka z metalowymi obreczami

environment_palette.png       - wspolna paleta kolorow UV (wymagana)
environment_palette.mtl       - material OBJ wskazujacy na palete
Editor/OceanEnvironmentURPColors.cs - narzedzie Unity przypisujace URP/Lit
Preview_Assets.png           - podglad wszystkich 9 modeli

IMPORT KROK PO KROKU
-------------------
1. ZATRZYMAJ PLAY. W Unity zapisz scene (Ctrl+S).
2. Skopiuj CALY rozpakowany folder LowPoly_Ocean_Environment_Unity6 do:
   Assets/ShipProject/Models/LowPoly_Ocean_Environment_Unity6/
3. Poczekaj na import i kompilacje. Do Unity wystarcza OBJ + MTL + PNG + Editor/.
4. W oknie Project przeciagaj wybrane .obj do Hierarchy, najlepiej pod
   nowy PUSTY GameObject o nazwie Environment (poza Ship!).
5. W Hierarchy zaznacz wybrane modele, mozesz zaznaczyc wszystkie Ctrl+klik.
6. Na gorze wybierz Tools > Ocean Environment > Apply URP Colors to Selected Props.
7. Powinny pojawic sie zolty piasek, zielona palma, szare skaly,
   czerwono-biala boja, brazowe skrzynki i beczki.

UWAGA NA KOLORY:
- Dla modeli przygotowano wspolny atlas environment_palette.png i UV.
- Nie wystarczy sam .obj: jesli model jest szary, skopiuj tez pliki PNG i MTL
  i uruchom opcje Tools > Ocean Environment > Apply URP Colors to Selected Props.
- Narzedzie utworzy material OceanEnvironment_URP.mat obok palety.
- Shader to Universal Render Pipeline/Lit, Surface Opaque, z plaskimi kolorami.

USTAWIENIE MODELI NA WODZIE
--------------------------
- Wszystkie pozycje i rozmiary w jednostkach Unity; os Y = gora.
- Woda ma wysokosc Y=0 (jesli jest inaczej, dopasuj polozenie obiektow).
- Wyspy maja dolna czesc zanurzona pod Y=0; zostaw LOCAL SCALE (1,1,1)
  na pierwsza probe. Wyspy maja srednice okolo 10 i 6 jednostek.
- Skaly, skrzynka, beczka i palma maja podstawe blisko Y=0.
- Boja ma zanurzony dol i wystajaca ponad wode gore.
- Jesli statek leci do przodu w osi +Z, ustaw wyspy po obu stronach trasy.

PRZYKLADOWA HIERARCHIA
----------------------
MainScene
  Ship (bez zmian)
  Water (bez zmian)
  Wind (bez zmian)
  HUD (bez zmian)
  Environment   <- NOWY PUSTY GameObject
    Island_01_Palm
    Island_02_Sand
    Rock_01
    Rock_02
    Rock_03
    Buoy_01
    Crate_01
    Barrel_01

PRZYKLADOWE POZYCJE DLA STATKU PORUSZAJACEGO SIE W +Z
----------------------------------------------------
Island_01_Palm  (-16, 0, 34)
Island_02_Sand  ( 19, 0, 68)
Rock_01         ( -5, 0, 20)
Rock_02         (  8, 0, 48)
Rock_03         ( -9, 0, 73)
Buoy_01         (  4, 0, 15)

KRYTYCZNE INFORMACJE
--------------------
- Nie umieszczaj otoczenia wewnatrz Ship, bo zacznie poruszac sie razem
  ze statkiem i stracisz punkty odniesienia ruchu.
- Zadnych Rigidbody, Collider ani skryptow ruchu nie wymagaja te modele.
- Sa to dekoracje; nie zmieniaja ShipController, SailController ani HUD.
- Kolory i geometria sa oryginalnie przygotowane do tego zestawu.
- Modele sa statyczne i NIE zawieraja animacji palm ani fal.
- Skrypt Editor dziala tylko w edytorze Unity, NIE w buildzie.
- Mozesz dowolnie uzywac i modyfikowac wygenerowane modele we wlasnym projekcie.
