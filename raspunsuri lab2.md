1.Modificați valoarea constantei „MatrixMode.Projection”. Ce observați?
Aceste valori vor defini cum sunt proiectate obiectele pe ecran astfel ca daca GL.Ortho(-1.0, 15.0, -1.0, 1.0, 0.0, 4.0) are valorile anterioare obiectul nostru va fi plasat in partea stanga a ecranului


1.Ce este un viewport?
Un viewport reprezintă o regiune a ecranului sau a ferestrei de afișare în care este randată grafica. Acesta definește coordonatele și dimensiunile în care se va afișa scena 3D. Un viewport permite să se controleze cum și unde sunt randate obiectele în fereastra de afișare.


2.Ce reprezintă conceptul de frames per second (FPS) din punctul de vedere al bibliotecii OpenGL?
Frames per second (cadre pe secundă) reprezintă numărul de imagini (cadre) randate și afișate pe ecran în fiecare secundă. În contextul OpenGL, este un indicator al performanței aplicației și arată cât de eficientă este randarea grafică. Cu cât numărul FPS este mai mare, cu atât aplicația este mai fluidă și mai reactivă.


3.Când este rulată metoda OnUpdateFrame()?
Metoda `OnUpdateFrame()` este rulată în fiecare cadru (frame) al aplicației OpenGL, înainte de randarea scenei 3D. Această metodă este destinată logicii aplicației, cum ar fi actualizarea pozițiilor obiectelor sau gestionarea interacțiunilor cu utilizatorul.


4.Ce este modul imediat de randare?
Modul imediat de randare este o tehnică mai veche de randare în OpenGL în care desenarea se face direct într-o buclă de randare folosind funcții cum ar fi `GL.Begin()` și `GL.Vertex()`. Această abordare este considerată învechită și ineficientă în comparație cu tehnici mai moderne, precum randarea cu buffer.


5.Care este ultima versiune de OpenGL care acceptă modul imediat?
Ultima versiune de OpenGL care suportă modul imediat este OpenGL 3.0. După această versiune, modul imediat a fost eliminat și a fost introdus un nou model de randare, bazat pe buffer, care oferă performanțe mai bune.


6.Când este rulată metoda OnRenderFrame()?
Metoda `OnRenderFrame()` este rulată în fiecare cadru (frame) al aplicației OpenGL, imediat după ce metoda `OnUpdateFrame()` a fost apelată. Această metodă este destinată randării scenei 3D și afișării rezultatului pe ecran.


7.De ce este nevoie ca metoda OnResize() să fie executată cel puțin o dată?
Metoda `OnResize()` trebuie executată cel puțin o dată pentru a inițializa viewport-ul grafic și pentru a defini spațiul în care se va desfășura randarea scenei 3D. Aceasta trebuie să fie apelată la început, și ulterior ori de câte ori fereastra OpenGL este redimensionată pentru a asigura afișarea corectă a obiectelor pe ecran.


8.Ce reprezintă parametrii metodei CreatePerspectiveFieldOfView() și care este domeniul de valori pentru aceștia?
Metoda `CreatePerspectiveFieldOfView()` este folosită pentru a crea o matrice de proiecție într-o perspectivă în OpenGL. Parametrii acestei metode reprezintă:
- `fieldOfView`: Este un unghi care specifică câmpul de vedere (FOV) în grade. Domeniul de valori este de obicei între 0 și 180 grade.
- `aspectRatio`: Reprezintă raportul aspectului, adică raportul dintre lățimea și înălțimea ferestrei sau viewport-ului grafic.
- `zNear` și `zFar`: Reprezintă distanța la care obiectele se vor randat în perspectivă, cu `zNear` fiind distanța cea mai apropiată și `zFar` cea mai îndepărtată. Aceste valori pot varia în funcție de cerințele aplicației.
