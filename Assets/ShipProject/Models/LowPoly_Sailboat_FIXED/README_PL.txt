LOW-POLY SAILBOAT — POPRAWIONA WERSJA DO UNITY 6000.6.5f1 (URP)
================================================================

Ta wersja NAPRAWIA problem przezroczystego pokładu: w poprzedniej wersji
trójkąty pokładu miały odwrócone normalne/winding i Unity ukrywało je od góry.
Nowa wersja ma prawidłowo widoczny, pełny drewniany pokład.

Dodatkowo model ma jeden atlas kolorów (sailboat_palette.png) i UV dla
każdego elementu, więc kolory nie zależą od importowania kilkunastu
materiałów zapisanych w pliku MTL.

ZAWARTOŚĆ
---------
BoatHull.obj              — kadłub, POKŁAD, maszt, flaga, detale
SailAssembly.obj          — osobno obracany żagiel z rejami
sailboat_palette.png      — atlas wszystkich kolorów
sailboat_palette.mtl      — wspólny materiał OBJ z map_Kd
Editor/SailboatURPColors.cs — narzędzie jednego kliknięcia do przypisania
                             materiału URP/Lit
Preview_FIXED.png         — podgląd rzeczywistej siatki z perspektywy góry

SĄ TYLKO DWA MODELE .OBJ. Nie ma duplikatów GLB ani FullBoat.

JAK ZASTĄPIĆ STARĄ WERSJĘ W UNITY
--------------------------------
1. Zatrzymaj Play. Zapisz scenę i najlepiej zrób kopię/commit.
2. W Hierarchy usuń WYŁĄCZNIE dwie instancje starego modelu:
   BoatHull i SailAssembly, które były z poprzedniej paczki.
   NIE usuwaj GameObject Ship, SailPivot, kamery ani skryptów.
3. Skopiuj CAŁY folder LowPoly_Sailboat_FIXED do:
   Assets/ShipProject/Models/LowPoly_Sailboat_FIXED/
   (nie mieszaj tych plików ze starą paczką o tych samych nazwach).
4. Przeciągnij NOWY BoatHull.obj do Ship (jako dziecko).
   Ustaw Transform LOCAL Position=(0,0,0), Rotation=(0,0,0), Scale=(1,1,1).
5. Ustaw istniejący SailPivot LOCAL Position=(0,2.65,0), Rotation=(0,0,0).
   Przeciągnij NOWY SailAssembly.obj do SailPivot (jako dziecko).
   SailAssembly: LOCAL Position=(0,0,0), Rotation=(0,0,0), Scale=(1,1,1).
6. Ukryj lub usuń TYLKO stare kostki wizualne Hull, Sail i Flagstaff.
   Pozostaw SailController na SailPivot i ShipController na Ship.
7. Ustaw pozycję Ship względem Water tak, aby woda przecinała kadłub
   około lokalnego Y=0 (dno statku jest około -0.85).

JAK PRZYPISAĆ KOLORY — JEDNO KLIKNIĘCIE
---------------------------------------
1. Plik Editor/SailboatURPColors.cs musi leżeć wewnątrz folderu Editor
   w Assets. Poczekaj na kompilację Unity (bez błędów Console).
2. W Hierarchy zaznacz Ctrl+klik OBA nowe obiekty:
   BoatHull oraz SailAssembly.
3. Z górnego menu Unity wybierz:
   Tools > Sailboat > Apply URP Colors to Selected Parts
4. Skrypt znajdzie sailboat_palette.png, utworzy Sailboat_URP.mat
   i przypisze go do wybranych rendererów.
5. Kadłub powinien być brązowy, żagiel kremowy, a flaga czerwona.

Ten skrypt to wyłącznie NARZĘDZIE EDITORA. Nie jest dodawany jako
komponent do statku, nie wykonuje się w buildzie i nie dodaje fizyki.

Jeśli NIE widać pokładu:
- Upewnij się, że w Hierarchy wybrałeś NOWĄ wersję BoatHull,
  nie stary prefab z poprzedniej paczki.
- Wyłącz stare Hull/Cube, jeśli nachodzą na nowy model.
- Nie twórz drugiego SailPivot; skrypt musi zostać na starym SailPivot.

ZGODNOŚĆ
--------
- Dwa OBJ, każdy ma jedną złączoną siatkę i jedną paletę kolorów.
- Jeden maszt, osobny żagiel obracany wokół osi Y.
- Kierunek dziobu lokalne +Z.
- Nie wymaga Rigidbody ani Colliderów.
- Nie musisz modyfikować ShipController/SailController.
- Żagiel pozostaje wizualnie rozwinięty niezależnie od procentu otwarcia.

Pliki źródłowe generatora i podglądu są opcjonalne — Unity ich nie używa.
