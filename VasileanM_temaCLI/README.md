## Tema Laborator 2

### 1. Ce este un viewport?
În OpenGL, un viewport este regiunea dreptunghiulară de pe fereastră în care sunt desenate cadrele generate. Este definit prin coordonate (x, y) care indică colțul din stânga jos al ferestrei și dimensiunile (lățime și înălțime). Se setează folosind funcția glViewport().

### 2. Ce reprezintă conceptul de frames per seconds din punctul de vedere al bibliotecii OpenGL?
Frames per second (FPS) măsoară numărul de cadre pe care aplicația le poate randarea și afișa într-o secundă. Este un indicator al performanței aplicației și depinde de complexitatea scenelor, performanța hardware-ului, optimizarea codului și driverelor OpenGL.

### 3. Când este rulată metoda OnUpdateFrame()?
Metoda OnUpdateFrame() este apelată înainte de fiecare cadru randat. Scopul ei este să actualizeze starea aplicației, precum poziția obiectelor, rotații, calcule fizice sau alte schimbări necesare înainte de randare.

### 4. Ce este modul imediat de randare?
Modul imediat de randare (Immediate Mode) este o tehnică veche din OpenGL în care fiecare primitiv (punct, linie, triunghi) este descris pas cu pas. Se foloseau apeluri precum glBegin(), glVertex(), glEnd(). Este simplu de utilizat, dar ineficient, deoarece implică multiple apeluri CPU-GPU pentru fiecare cadru.

### 5. Care este ultima versiune de OpenGL care acceptă modul imediat?
Modul imediat este suportat până la OpenGL 3.2, însă utilizarea lui este considerată depreciată începând cu OpenGL 3.0 și eliminată în versiunile care folosesc doar profilul Core.

### 6. Când este rulată metoda OnRenderFrame()?
Metoda OnRenderFrame() este apelată pentru fiecare cadru randat. Aici se execută instrucțiunile de desenare, cum ar fi configurarea shader-elor, trimiterea obiectelor la GPU și apelurile de randare.

### 7. De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Metoda OnResize() este executată pentru a ajusta viewport-ul și proiecția scenei la noile dimensiuni ale ferestrei. Fără această ajustare, desenarea nu va fi scalată corect, iar imaginea ar putea apărea distorsionată sau tăiată.

### 8. Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
Metoda CreatePerspectiveFieldOfView() este utilizată pentru a configura o matrice de proiecție în perspectivă. Parametrii sunt:
- Field of View (FoV): Unghiul vertical al câmpului vizual, exprimat în radiani. Domeniu tipic: (0, π).
- Aspect Ratio: Raportul lățime/înălțime al ferestrei. Este un număr pozitiv.
- Near Plane: Distanța minimă la care obiectele devin vizibile. Domeniu: (0, +∞).
- Far Plane: Distanța maximă până la care obiectele sunt vizibile. Domeniu: (Near, +∞).
