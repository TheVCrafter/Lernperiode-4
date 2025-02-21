# Lern-Periode 4

14.2 bis 4.4

## Grob-Planung

#### Wo stehen Sie mit Ihren Noten?
Im allgemeinen ist mein Notenschnitt in Informatik sehr gut. Ich hatte bis jetzt keine ungenügenden Noten und bin sehr zufrieden mit meiner bisherigen Leistung
#### Was wäre ein geeignetes Projekt für diese LP4?
Da diese Lernperiode ja etwas länger ist, habe ich mir überlegt wieder etwas anspruchsvolleres zu programmieren und da ich auch mal ein programm mit Winforms entwickeln möchte, habe ich mir vorgenommen Tetris in Winforms zu programmieren. Das ganze sollte ein gut gestalltetes GUI haben und im grossen und ganzen genauso funktionieren wie das Original. Das ganze sollte eigentlich möglich sein. Obwohl die Umsetzung wahrscheinlich relativ anspruchsvoll sein wird, bin ich bereit dieser Herausforderung entgegenzutreten.

## 14.02.2025: Explorativer Wegwerf-Prototyp

- [X] mich besser zu WinForms informieren
- [ ] Mit verschiedenen Desingns experimentieren

Heute habe ich mir zu beginn überlegt, was ich in dieser Lernperiode ereichen möchte. Schon ziemlich bald kam ich zum schluss, das ich gerne den Umgang mit WinForms erlernen möchte. Da die Lernperiode relativ lange ist, wählte ich anschliessend auch ein anspruchsvolles Projekt, indem ich beschloss, ein Tetris-Spiel zu entwickeln. Da ich noch beinahe keine Erfahrung mit WinForms habe, beschloss ich, mir zunächst einige Tutorials und Erklärvideos auf YouTube anzusehen um so diese API besser zu verstehen. Anschliessend wollte ich noch kurz mit dem 2. Arbeitspaket beginnen, da die Zeit aber bereits relativ knapp war, habe ich nichts entscheidendes mehr erreicht.

## 21.02.2025: Explorativer Wegwerf-Prototyp

- [X] Eine Skizze dazu erstellen, wie das GUI des Spiels schlussendlich aussehen sollte
- [X] Das GUI de Hauptmenüs in WinForms realisieren und eventuell noch anpassen
- [X] Grundlegende Funktionen Implementieren (z.B. drücken des Start-Knopfes öffnet ein neues Form und versteckt das aktuelle, ausserdem die klassische Titelmusik und weiteres)
- [X] Das geschriebene Programm auf Bugs testen und falls welche vorhanden sind, diese anschliessend beheben.

Heute habe ich zuerst daran gearbeitet, ein Passendes GUI für mein Spiel zu entwerfen. Ich beschloss das Spiel vom Aussehen her ähnlich wie das Original zu machen, jedoch hauptsächlich die Farbe Rot zu verwenden. Während dem Designen fiel mir auch ein Toller Name für mein Spiel ein. Ich beschloss das Spiel "Wintris" zu nennen. Anschliessend begann ich damit das Design in WinForms zu realisieren. Dafür Designte ich zunächst in Canva ein Hintergrundbild und fügte dieses anschliessend mit einer Picture-Box ins WinForms ein. Ausserdem erstellte ich zwei Knöpfe. Einen zum Starten des Spiels und einen um zu den Einstellungen zu gelangen. Dann erstellte ich noch ein neues Form für das Gameplay und programmierte, dass sich bei drücken das Startknopfes das Hauptmenü schliesst und anschliessend das Form für das Gameplay geöffnet wird. Dann versuchte ich herauszufinden, wie ich die verschiedenen Tetris-Formen darstellen könnte und beschloss schliesslich das ganze mit PictureBoxes anzustellen. Dann musste ich noch einen Weg finden das ganze zu bewegen. Ich fand heraus das ich die Position einer PictureBox mit dem PictureBoxNamen und **.top/.left** verändern kann. Da eine Figur jedoch aus mehreren PictureBoxen zusammengesetzt ist, musste ich jedoch noch herausfinden, wie ich die ganze Figur  auf einmal bewegen könnte. Dafür nahm ich ChatGPT zur Hilfe und fand heraus, das ich mir das Ganze mithilfe von Listen ermöglichen könnte. Als ich das Programm zum Bewegen der Figuren geschrieben hatte, testete ich das Programm und glücklicherweise funktionierte das Ganze ohne Probleme.

## 28.02.2025: Kern-Funktionalität

- [ ] Die restlichen Formen in das aktuelle Programm einfügen
- [ ] Programm zur Seitwärtsbewegung der Formen bei Tastendruck schreiben
- [ ] Design des Gameplays verbessern
- [ ] Titelmusik ins Spiel einfügen
## 07.03.2025: Kern-Funktionalität

## 14.03.2025: Architektur ausbauen

## 21.03.2025: Architektur ausbauen

## 28.03.2025: Auspolieren

## 04.04.2025: Auspolieren & Abschluss

