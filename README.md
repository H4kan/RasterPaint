-------------------------------------------------------------------
Krótki opis obsługi aplikacji
-------------------------------------------------------------------

Aplikacja oparta jest o tryby działania.
Podstawowe tryby to:

- Add polygon
- Add circle
- Relation mode
- Polygon mode
- Circle mode

W każdym z trybów możliwe jest wykonywanie konkretnych działań związanych z tym trybem i tylko ich,
między trybami można przęłączać się w dowolnym momencie. Jeśli w trakcie przełączania w poprzednim
trybie wykonywana była akcja, zostanie ona anulowana (np. wybrana zostanie pierwsza krawędź do 
relacji prostopadłości, ale nie druga).

Opis poszczególnych trybów:

1. Add polygon

W tryb Add polygon można wejść klikając przycisk "Add polygon".

Będąc w trybie, klikając w kolejnych wybranych przez nas punktach LPM wybieramy kolejne wierzchołki 
nowo tworzonego wielokąta, by zakończyć tworzenie wielokąta należy kliknąć PPM.
Po zakończeniu tworzenia wielokąta automatycznie opuszczamy tryb Add polygon.

2. Add circle 

W tryb Add circle można wejść klikając przycisk "Add circle".

Będąc w trybie, klikając LPM wybieramy położenie środka nowo tworzonego okręgu, drugim kliknięciem LPM
definiujemy promień okręgu.
Po zakończeniu tworzenia okręgu automatycznie opuszczamy tryb Add circle.


3. Relation mode

W tryb Relation mode można wejść klikając przycisk "Relation mode".

Będąc w trybie, widoczne jest podmenu relacji, w którym możemy wybrać relację, którą chcemy dodać do figur,
po wybraniu relacji, klikamy w punkty, związane krawędziami/okręgami, aby nadać im relację.
Po nadaniu relacji widnieje ona jako ikonka nad elementem w relacji z odpowiednią literką:
S - równa długość krawędzi
L - ustalona długość krawędzi
R - ustalona długość promienia
T - styczność krawędzi z okręgiem
P - prostopadłość krawędzi
W podtrybie Delete Relation możemy usuwać relacje klikając w odpowiadające im ikonki.
Opuszczenie trybu możliwe jest przez ponowne kliknięcie przycisku "Relation Mode" lub przez wybranie dowolnego
innego trybu.
Szczegóły na temat dodawania wielu relacji przedstawione są w sekcji Algorytm relacji.


4. Polygon mode

W tryb Polygon mode można wejść wybierając wielokąt z listy wielokątów.
Będąc w trybie, widoczne jest podmenu edycji, w którym możemy wybrać edycję, którą chcemy zaaplikować do
wybranego wielokąta. W przypadku poruszania krawędzią lub wierzchołkiem, jeśli sąsiadująca z wierzchołkiem/krawędzią
krawędź ma nadaną relację, poruszony zostanie cały wielokąt, w przeciwnym wypadku tylko sąsiadujące krawędzie.
Opuszczenie trybu możliwe jest przez zdjęcie wyboru z wielokąta na liście lub przejście do jakiegokolwiek innego
trybu.


5. Circle mode 

W tryb Circle mode można wejść wybierając okrąg z listy okręgów.
Będąc w trybie, widoczne jest podmenu edycji, w którym możemy wybrać edycję, którą chcemy zaaplikować do
wybranego okręga. Opuszczenie trybu możliwe jest przez zdjęcie wyboru z okręgu na liście lub przejście do jakiegokolwiek innego
trybu.


-------------------------------------------------------------------
Algorytm relacji
-------------------------------------------------------------------
Założenia:
- Co najwyżej jedna relacja dla krawędzi (z zadania)
- Co najmniej jedna krawędź bez relacji w wielokącie
- Co najwyżej jedna relacja styczności i co najwyżej jedna relacja ustalonej długości promienia dla okręgu

Omówmy teraz algorytm działania, gdy w wielokącie znajdują się relacje, a my dodajemy nowe. Chcemy to robić tak,
by nie zaburzyć już istniejących relacji. W tym celu przydatna będzie następująca obserwacja:
"Dla zadanych w zadaniu relacji, przesuwanie krawędzi bez zmiany ich kąta nachylenia, czy długości, nie zaburza relacji."
Korzystając z powyższej obserwacji w momencie wstawiania relacji na określonej krawędzi możemy wykonać następujące operacje:
- obliczyć wektor v_1 o jaki przesunięty został jeden z wierzchołków krawędzi na którą nakładana jest relacja,
- obliczyć wektor v_2 o jaki przesunięty został drugi z wierzchołków krawędzi na którą nakładana jest relacja,
- przechodzić po kolejnych krawędziach wielokąta, poczynając od krawędzi do której dodajemy relację, w kierunku
od drugiego do pierwszego wierzchołka, aż natrafimy na krawędź dla której nie mamy zdefiniowanej relacji, z założeń
istnieje taka krawędź. W każdej iteracji przesunąć krawędź, po której przechodzimy o v_1.
- przechodzić po kolejnych krawędziach wielokąta, poczynając od krawędzi do której dodajemy relację, w kierunku
od pierwszego do drugiego wierzchołka, aż natrafimy na krawędź dla której nie mamy zdefiniowanej relacji, z założeń
istnieje taka krawędź. W każdej iteracji przesunąć krawędź, po której przechodzimy o v_2.

W ten sposób z obserwacji nie psujemy żadnej z już istniejących relacji, dodatkowo przez przesunięcie krawędzi, nasz
wielokąt jest spójny z krawędzią po nałożeniu relacji.

Dodatkowo, w przypadku, gdy krawędź która jest w relacji styczności z okręgiem jest przesuwana o wektor, okrąg do którego
jest styczna też jest przesuwany o ten wektor. Zachowuje to relacje styczności i relacje nałożone na okrąg.
