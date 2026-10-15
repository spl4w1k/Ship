LOW-POLY SAILBOAT — DREWNIANY STER / KOLO STEROWE — UNITY 6 URP
================================================================

Pakiet prawdziwych siatek 3D OBJ, wygenerowanych tak jak poprzedni statek.
Uzywa DOKLADNIE TEJ SAMEJ palety kolorow (sailboat_palette.png) co w
LowPoly_Sailboat_FIXED, aby drewno i metal pasowaly do kadluba.

MODELE
------
Helm_Wheel.obj          - osobne kolo sterowe, srodek obrotu = (0,0,0).
Helm_Pedestal.obj       - drewniana podstawa / stojak steru; stopa na y=0.
Helm_Complete_Static.obj - stojak + kolo razem, nieruchoma dekoracja.
Rudder_Blade.obj        - opcjonalna pletwa sterowa przy rufie.
sailboat_palette.png    - oryginalny atlas kolorow statku.
sailboat_palette.mtl    - wskazuje atlas dla OBJ.
Editor/SailboatSteeringURPColors.cs - narzedzie 1-kliku do URP/Lit.
Preview_Steering.png    - podglad wygenerowanej geometrii.

INSTALACJA
----------
1. Rozpakuj paczke i skopiuj caly folder LowPoly_Sailboat_Steering_Unity6 do
   Assets/ShipProject/Models/ (razem z PNG, MTL i podfolderem Editor).
2. NIE przenos skryptow ruchu do nowego modelu. ShipController zostaje na Ship.
3. Jesli chcesz PO PROSTU dekoracje bez animacji: przeciagnij
   Helm_Complete_Static.obj jako dziecko BoatHull lub Ship.
   Ustaw localPosition mniej wiecej (0, 0.84, -1.4), rotation (0,0,0), scale (1,1,1).
4. Jesli chcesz OBRACAJACE SIE KOLO sterowe, nie uzywaj Complete.
   Utworz pod Ship pusty GameObject 'HelmMount' z localPosition (0,0.84,-1.4).
   Pod nim dodaj Helm_Pedestal.obj lokalnie (0,0,0), a Helm_Wheel.obj lokalnie
   (0,0.80,-0.37). Kolo ma pivot w srodku, jego lokalna os obrotu to Z.
5. Opcjonalna podwodna pletwa Rudder_Blade.obj: pod Ship przy rufie np.
   localPosition (0, -0.05, -2.7). Sprawdz model w widoku Scene i dopasuj.
6. Zaznacz modele dodane do Hierarchy, wybierz
   Tools > Sailboat > Apply URP Colors to Steering Parts.
   Skrypt utworzy Steering_URP.mat uzywajac atlasu i przypisze kolor.

UWAGI
-----
- Nie przypinaj HelmMount do SailPivot, bo wtedy kolo obracaloby sie z zaglem.
- Kierunek dziobu statku to lokalne +Z. Kolo obraca sie wokol lokalnej osi Z,
  NIE wokol Y (statek jako calosc obracamy wokol osi Y).
- Pletwa sterowa jest opcjonalna — do mechaniki skrętu nie trzeba jej animowac.
- Podstawka steru ma wysokosc ok. 0.8 i kolo ma srednice ok. 1.37 z uchwytami.
- Modele nie maja Rigidbody ani Colliderow.
- Gotowe OBJ i atlas sa wystarczajace: Python ani Blender nie sa potrzebne do importu.
- Nie uzywaj jednoczesnie Helm_Complete_Static oraz osobnych Helm_Wheel i
  Helm_Pedestal w tym samym miejscu (geometrycznie by sie nakladaly).
