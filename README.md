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

- [X] Die restlichen Formen in das aktuelle Programm einfügen
- [X] Programm zur Seitwärtsbewegung der Formen bei Tastendruck schreiben
- [X] Design des Gameplays verbessern
- [X] Titelmusik ins Spiel einfügen
      
Zu beginn habe ich heute die restlichen Tetris-Formen ins spiel eingefügt und auch programmiert, dass mithilfe eines randoms zufällig eine Form ausgewählt wird. Als ich damit fertig war, implementierte ich eine Funktion um die Blöcke jeweils automatisch nach unten zu bewegen und anschliessend eine Möglichkeit um die Formen mithilfe der Pfeiltasten hin und her zu bewegen. Dann fügte ich den Blöcken mein selbst erstelltes Block-Design hinzu, um das aussehen des Gameplays etwas zu verschönern. Ich machte mich dann noch auf die Suche nach einem gratis Download für die Tetris-Titelmusik und installierte das Nuget-Packet NAudio, um die Musik nach belieben abzuspielen.

## 07.03.2025: Kern-Funktionalität
- [X] Hitboxen
- [ ] Automatisches löschen der Pictureboxen einer Zeile wenn diese voll ist
- [ ] Pausierfunktion
- [ ] weiteres Verschönern des Gameplays
      
Heute habe ich mich einen grossen Teil der Zeit mit Hitboxen beschäftigt. Ich implementierte das ganze, indem ich die Position der Picturebox mit der Position des jeweiligen anderen Objekts verglich (Rand oder andere Form). Danach veränderte ich das Programm so, dass die Formen nach ereichen des Bodens (unteres Ende des Fensters) in einem anderen Array gespeichert werden und anschliessend eine neue Form erstellt wird. Das ganze funktionierte mehrheitlich ohne Probleme, jedoch musste ich feststellen, dass die Formen am Rechten Rand sowie am Boden nicht richtig anhielten, da das Fenster-Format falsch war. Ich probierte also etwas mit verschiedenen Grössen und schaffte es so diesen Fehler zu beheben. Dann begann ich noch damit, den Rotier-Mechanismus für die Formen zu entwickeln. Dazu schrieb ich zunächst alle Koordinaten für die verschiedenen Positionen auf. Dann erstellte ich mithilfe von ChatGPT eine Funktion, welche die Formen beim drücken der Arrow-UP-Taste rotiert. Anschliessend testete ich das Ganze nochmals, und musste feststellen, das die Positionen der Formen immer wieder zurückgesetzt werden. Da ich aber keine Zeit mehr hatte diesen Fehler zu beheben, beschloss ich, dies nächste Woche zu machen.
## 14.03.2025: Architektur ausbauen
- [ ] Rotiermechanismus (korrigierte Version)
- [ ] Pausierfunktion
- [X] Entfernen voller Zeilen
- [X] Punktesystem

Heute habe ich vorallem an dem automatischen Entfernen voller Zeilen gearbeitet. Dabei hatte ich relativ lange mit einer System.NullReferenceException zu kämpfen. Es gelang mir aber glücklicherweise diesen nach einigem Experimentieren zu lösen. Danach funktionierte das Löschen von Zeilen eigentlich problemlos, jedoch wurden komischerweise immer statt nur einer Form mehrere Formen eingefügt, was zu einem "Blockup" im oberen Bereich des Fensters führte. Ich fand glücklicherweise bald heraus, dass das ganze daran lag, dass ich ausversehen einen Methoden-Aufruf in eine For-Schleife gepackt hatte. Anschliessend versuchte ich noch das problem mit dem Positions-Reseten bei Rotation zu beheben, dies gelang mir jedoch nicht richtig und die vorherigen Positionen wurden nicht richtig gespeichert. Als ich damit nicht weiter kam, beschloss ich dann zum Schluss noch kurz ein Punktesystem ins Spiel einzufügen. Dies setzte ich mithilfe eines Labels um, bei welchem ich immer beim vervollständigen einer Zeile die Beschriftung änderte. Im Moment erhält man pro vervollständigte Zeile 500 Punkte. Ich werde dies aber nächstes Mal noch etwas anpassen.
## 21.03.2025: Architektur ausbauen
- [X] besseres Punktesystems
- [ ] Pausierfunktion
- [ ] Mehr Soundeffekte
- [X] korrigierter Rotiermechanismus

Heute habe ich gleich damit begonnen, den Rotiermechanismus zu verändern. Dazu prüfte ich mithilfe einer skizze auch nochmals, ob alle rotationen der verschiedenen Formen richtig waren oder ob ich fehler gemacht hatte. Anschliessend codierte ich den Rotiermechanismus neu und schaffte es glücklicherweise, ihn stark zu verbessern. Leider hatte ich aber noch das Problem, dass wenn die Formen sich am Rand oder in der Nähe einer anderen Form drehten, sich in die andere Form / in den Bereich ausserhalb des Fensters drehten. Ich beschloss zunächst aber, diesen Fehler später zu beheben und begann mit dem verbessern des Punktesystems. Ich veränderte es so, dass der Spieler pro Linie 10 Punkte erhält und immer beim erreichen einer durch 100 teilbaren Zahl das level erhöht wird, also das interval des Falltimers verkürzt wird. Als ich damit fertig war, testete ich das Spiel nochmals und entdeckte einen Fehler bei der Linien-löschung. Es wurden komischerweise manchmal volle Linien nicht gelöscht. Ich untersuchte meinen Code nochmals und entdeckte einen Fehler in dem dafür zuständigen Abschnitt. Ich konnte diesen anschliessend beheben. Dann viel mir ein, dass es im echten Tetris spiel möglich ist, die Formen mit drücken der Pfeil nach Unten-Taste die jeweilige Form zu beschleunigen. Ich programmierte codierte also einen Abschnitt, in welchem bei drücken der Pfeil nach Unten-Taste ein bool auf True gesetzt wird und änderte die FallTimer_Tick funktion so, dass
wenn dieser Bool auf True ist, das Intervall 50 statt 500 millisekunden beträgt. Als ich damit fertig war, wollte ich noch den vorher erwähnten Fehler bei Rotation beheben. Dafür schrieb ich einen Code, welcher bevor die neuen Koordinaten gesetzt werden prüft, ob eine bereits bestehende Form die gleichen Koordinaten wie die Rotation hätte und falls ja mithilfe eines Bools die Rotation verhindert wird. Leider reichte es mir Zeitlich anschliessend nicht mehr eine Pausierfunktion zu entwickeln und weitere Soundeffekte einzufügen, weshalb ich diese Tätigkeiten mit sicherheit nächste Woche erledigen werde. Ausserdem hält die Musik nach einer gewissen Zeit einfach an und es gibt noch kein Game Over bei einem Block-Up.
## 28.03.2025: Auspolieren
- [X] Pausierfunktion
- [ ] Mehr Soundeffekte
- [ ] Game-Over mit Menü
- [X] Loopen der Tetrismuskik
- [X] Testen und gefundene Fehler beheben
Heute habe ich mich zunächst daran gemacht, ein Pausenmenü zu designen. Anschliessend fügte ich dieses als Picturebox in das Spiel ein und erstellte 4 Buttons. Einen fürs Pausieren und drei welche nur im Pausenmenü sichtbar sind. Einen Button um die Settings anzupassen, einen um weiterzuspielen und einen um ins Hauptmenü zurückzukehren. Ich pausierte das Spiel indem ich den Falltimer stoppte. Anschliessend hatte ich dann aber lange das Problem, das die Steuerung nicht funktionierte. Denn ich bemerkte am Anfang nicht, dass das drücken der Pfeiltasten dazu führte, dass der Pausier-Button in den Fokus gestellt wurde, wodurch die KeyDown erkennung nicht mehr richtig funktionierte. Nach dem ich eine gewisse Zeit verzweifelt versuchte dieses Problem zu beheben, viel mir ein, dass ich ja einfach die KeyBinds ändern könnte. Anstatt den Pfeiltasten verwendete ich also WASD und tatsächlich funktionierte das Spiel anschliessend wieder reibungslos. Anschliessend machte ich mich auf die Suche nach einer gut Loopbaren mp3 file für die Ingame-Musik. Ich fand schliesslich einen Remix von Tetris namens "Tetris Phonk" welcher auch bereits Alexander schon in seinem Tetris-Spiel verwendet hatte. Für das Hauptmenü wählte ich einen anderen Soundtrack welcher mir gut gefiel und ebenfalls gut geloopt werden konnte. Beim Testen fand ich dann herauss dass das Stoppen des Music-Players noch nicht korrekt funktionierte.

## 04.04.2025: Auspolieren & Abschluss
- [ ] Beheben des Errors beim MusicPlayer und einfügen weiterer Sounds
- [ ] GameOver fertig implementieren
