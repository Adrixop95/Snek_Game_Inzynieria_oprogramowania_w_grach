
### Inżynieria Oprogramowania w Grach 

## Zespół:
- Laura Dymarczyk
- Agata Dziurka
- Kamil Karpiński
- Adrian Rupala


## Koncept gry:
Nasz projekt ma na celu zaprojektowanie i stworzenie gry w węża (ang. Snake), jest to nasza interpretacji klasycznej gry istniejącej od 1976 roku. 
Gra polega na poruszaniu tytułowym wężem po prostokątnej planszy, na której pojawiają się punkty (jabłka), które są pożywieniem naszego zwierzątka. Pożywienie pozwala wężu się rozrastać, a celem gry jest zapełnienie całej przestrzeni planszy ciałem naszego węża.
W grze można ponieść porażkę poprzez dobicie do zewnętrznych krawędzi planszy, tzw. “ścian”.

## Wykorzystane w projekcie wzorce projektowe
### Wzorce konstrukcyjne:
- Prototyp - użyty przy tworzeniu instancji jabłek i kolejnych segmentów węża.
- Singleton - użyty do stworzenia instancji planszy, której pojedynczy obiekt jest wystarczający dla działania całej rozgrywki, używany do stworzenia aktualnego stanu poruszania się węża oraz obiekt służący do zliczania punktów w rozgrywce.

### Wzorce strukturalne:
- Kompozycja - użyty do reprezentowania węża poprzez liniową strukturę rekurencyjną. Pomaga to przy przesuwaniu całego ciała węża w sposób ciągły.

### Wzorce operacyjne:
- Stan - wąż może znajdować się w jednym z czterech stanów poruszania się: do góry (przyrost y), do dołu (zmniejszanie y), w lewo (zmniejszenie x) lub w prawo (przyrost x). Istnieje również stan rozgrywki, który może być wartością wygraną, przegraną bądź w toku.
- Komenda - pozwala zmienić stan ruchu węża, reaguje na wydarzenia klawiatury.
- Obserwator - Istnieją dwie instancje obserwatorów. Jeden z nich obserwuje węża względem jabłka i daje im sygnał, gdy spotkają się w tym samym polu. Drugi obserwator obserwuje węża i ścianę, wysyła on sygnał do węża, aby poinformować go o zderzeniu.

### Wzorce sekwencjonowania:
- Metoda aktualizująca - zliczanie wykorzystane podczas kalkulowania punktów.
- Renderer
