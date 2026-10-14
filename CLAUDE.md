# Countdown – Regeln

Generelle Regeln für diese App. Gelten immer, wenn der User nichts Genaueres sagt.
Neue generelle Wünsche des Users hier ergänzen. Theme-Ideen und -Stand stehen in [THEMES.md](THEMES.md).

## Projekt
- Die App ist eine PWA in `web/`: reines HTML/JS in `web/index.html`, kein Build. Vorschau: `cd web && py -m http.server 8765` (Port 8000 belegt auf diesem Rechner die Go-Girls-Seite).
- Später soll sie mit Capacitor in den App Store (siehe [README.md](README.md)). Deshalb keine externen Abhängigkeiten oder CDNs, alles bleibt lokal.
- Ein Theme ist ein Eintrag in `MODES` in `web/index.html`, mit Layout (`lay`) und optionalen Hooks (`pos`, `item`, `before`, `after`, `step`, `tap`, `bodyTap`, `endArt`, `noHead` …).
- Testen: `?m=10&look=<index oder name>.<palette>`, z.B. `?m=10&look=ducks`. Mit `&passed=5` sind schon 5 Minuten vorbei (nur in der lokalen Vorschau, online und in der App wirkungslos).
- Die alten Dateien `Countdown.cs`/`.exe`, `build.cmd` und `countdown.ps1` stammen aus der ersten Windows-Version und werden nicht mehr gepflegt.

## Texte
- Die App ist englisch, sehr knapp und minimalistisch.
- Keine Beispiele oder Vorschläge in Eingabefeldern („What for?“ steht ohne Vorschlag).
- Die Anzeige lautet „N left“, ohne „min“.
- Buttons: „Start“, „Exit“ (im Countdown und am Ende). Der Pause-Button zeigt jeden Tag einen anderen „ich bin kurz weg“-Text aus `AWAY` und in der Pause „I'm back“.

## Aussehen und Tippen
- Es gibt keine Design-Einstellungen. Das Aussehen ändert sich nur durch Tippen.
- Pro Minute gibt es ein Item.
- **Tipp auf ein aktives Item:** kurze Reaktion (Puls, manchmal eine leicht andere Farbe nahe der Palettenfarbe, ggf. themespezifisch). Sonst passiert nichts.
- Der Puls-Ring beim Antippen bleibt proportional zum Item: Er liegt eng um das, was man sieht, und ist nie viel größer (bei ungewöhnlichen Formen `p.ring` setzen).
- **Tipp auf ein vergangenes Item:** nichts.
- **Tipp auf ein neutrales Element** (Deko, Körper, Rahmen, Linien, Überschrift): nichts, außer das Theme hat bewusst eine eigene Reaktion (z.B. der Igel hüpft, `bodyTap`).
- **Nur ein Tipp auf leeren Hintergrund** wechselt zufällig Theme und Palette.
- Vergangene Items bleiben sichtbar (blass, klein, am Boden …), wenn es zum Theme passt.
- Themes mit Gesicht sind niedlich, im Stil von Raupe, Spinne und Igel.
- Ein Theme darf die Überschrift ersetzen (`noHead`) und die Zeit selbst zeigen, wie das Kino auf der Leinwand.
- Farben kommen immer aus der aktuellen Palette (`P.fg`, `P.bg`, `P.dim`, `P.text`), nie fest im Theme.

## Pause (Standard, wenn nichts anderes gewünscht)
- Der Countdown friert ein, und das Ende verschiebt sich um die Pausendauer.
- Die Pause übersteht Neuladen und Schließen der App.
- Die Fläche wird blass (ca. 30 %), und der Untertitel zeigt „paused“. Themes mit `noHead` zeigen „paused“ selbst.
- Bewegungen kommen sanft zur Ruhe (`calm` geht gegen 0) und laufen danach weiter. Neue bewegte Themes nehmen deshalb `X.t` als Zeit, nicht `X.now`.
- Ein Theme darf eine eigene, ruhige Pausen-Reaktion haben (z.B. der Igel schläft, die Autos parken).
- Zeigt ein Theme die Pause selbst deutlich genug, bleibt die Fläche mit `noDim` hell (z.B. die Sanduhr mit ihrem Schieber).

## Ende
- Groß steht das Label in Großbuchstaben mit „!“ (ohne Label „DONE!“), dazu der Button „Exit“.
- Der Endton ist zufällig futuristisch, kein Piepen.
- Das letzte Item geht wie alle anderen mit seiner Animation ab, während der Endton spielt. Erst danach (je nach `goneMs`, max. 3 s) kommt der End-Bildschirm.
- Ein Theme darf eine End-Animation haben (`endArt`, z.B. Schmetterling nach der Raupe, Knall nach der Lunte).

## Barrierefreiheit
- Bei `prefers-reduced-motion` gibt es keine Dauer-Animationen (`still`).

## Zusammenarbeit (mehrere Claude-Sitzungen arbeiten parallel)
- `web/index.html` direkt vor dem Bearbeiten frisch lesen und nie aus einem alten Stand komplett neu schreiben.
- Nach jeder fertigen Änderung sofort committen, und zwar nur die eigenen Dateien mit expliziten Pfaden, kein `git add -A`.
- Bei Code-Änderungen den Cache-Namen in `web/sw.js` hochzählen.
- Wird ein Theme gebaut oder eine Idee verworfen, `THEMES.md` aktualisieren.
