1.Care este ordinea de desenare a vertexurilor pentru aceste metode (orar sau anti-orar)? Desenați axele de coordonate din aplicația- template folosind un singur apel GL.Begin().
Ordinea în care desenați vârfurile pentru metoda orar sau anti-orar depinde de ce orientare a triunghiurilor doriți. De obicei, aceasta este controlată de modul în care sunt specificate vârfurile într-o listă de vârfuri (de exemplu, vertex buffer object, VBO) și ordinea în care sunt specificate într-un șir de triunghiuri (de exemplu, folosind glDrawArrays sau glDrawElements).
Pentru a controla orientarea, puteți folosi funcții precum glFrontFace pentru a specifica sensul de rotație (orar sau anti-orar) pentru triunghiuri și glCullFace pentru a specifica care fețe ale triunghiurilor să fie eliminate în funcție de orientare.


2.Anti-aliasing este o tehnică utilizată în grafică computerizată pentru a reduce sau elimina efectul de aliasing, care apare atunci când liniile sau marginile dure ale obiectelor sunt afișate pe un ecran sau într-o imagine digitală cu rezoluție limitată. Aliasul este o apariție nedorită a denticulelor sau a jocurilor de culoare la marginile sau în detaliile obiectelor.
Anti-aliasing funcționează prin adăugarea informației suplimentare la imagine pentru a îmbunătăți calitatea marginilor. 


3.Comanda `GL.LineWidth(float)` setează grosimea liniilor desenate în OpenGL, iar comanda `GL.PointSize(float)` setează dimensiunea punctelor desenate. Aceste comenzi controlează modul în care liniile și punctele sunt desenate și funcționează în cadrul unui apel `GL.Begin()` pentru desenare primitivă.
1) `GL.LineWidth(float)`:
   - Această comandă stabilește grosimea liniilor pentru obiectele desenate în interiorul unui apel `GL.Begin()` cu moduri precum `GL_LINES` sau `GL_LINE_STRIP`.
2) `GL.PointSize(float)`:
   - Această comandă stabilește dimensiunea punctelor pentru obiectele desenate în interiorul unui apel `GL.Begin()` cu moduri precum `GL_POINTS`.
Aceste comenzi controlează aspectul vizual al liniilor și punctelor desenate, și efectul lor va fi vizibil doar în cadrul apelului `GL.Begin()`.


4.Directivele LineLoop, LineStrip, TriangleFan și TriangleStrip sunt moduri de desenare a segmentelor sau a triunghiurilor în OpenGL:
1) **GL_LINE_LOOP**:
   - Cu GL_LINE_LOOP, puteți desena o serie de segmente de dreaptă conectate, unde ultimul punct se va conecta la primul punct, formând astfel o buclă închisă. Efectul este acela că se creează o formă poligonală închisă cu liniile care se conectează pentru a închide conturul.
2) **GL_LINE_STRIP**:
   - GL_LINE_STRIP permite desenarea unei serii de segmente de dreaptă conectate într-o ordine specifică. Aici, punctele sunt legate în ordine, formând un lanț continuu de linii. Fiecare segment de dreaptă se conectează la cel precedent.
3) **GL_TRIANGLE_FAN**:
   - GL_TRIANGLE_FAN vă permite să desenați triunghiuri folosind o serie de puncte, unde primul punct este considerat centrul "abanicului" și triunghiurile sunt generate conectând fiecare punct la centrul. Acest lucru creează o formă în formă de evantai sau un disc. Este util pentru a crea forme radiale.
4) **GL_TRIANGLE_STRIP**:
   - GL_TRIANGLE_STRIP vă permite să desenați triunghiuri conectate într-o secvență specifică. Fiecare nou triunghi împarte două puncte cu triunghiul anterior, astfel încât o succesiune de triunghiuri sunt generate conectate în mod continuu.
