# Countdown

Minimalistischer Countdown. Ein Item pro Minute. Tippen auf ein Item lässt es pulsieren,
Tippen daneben wechselt Darstellung (10 Modi) und Farben (12 Paletten).

```
docs/         die App (reines HTML/JS, kein Build nötig) – auch der webDir für Capacitor
resources/    icon.png (1024×1024) für App-Store-Icons
```

## Lokal ansehen

```
cd docs
py -m http.server 8765
```
→ http://localhost:8765 · Direktstart: `?m=37&t=Lunch` oder `?bis=18:30` · bestimmter Look: `&look=3.5` (Modus.Palette)

## Online

https://sinalaura.github.io/countdown/ – GitHub Pages veröffentlicht bei jedem Push auf `main` den Ordner `docs/`
(Settings → Pages → „Deploy from a branch“, `main`, `/docs`).

## Weg in den App Store (Capacitor)

Der Code in `docs/` wird unverändert in eine native App verpackt.

1. [Node.js LTS](https://nodejs.org) installieren
2. Im Projektordner:
   ```
   npm init -y
   npm install @capacitor/core @capacitor/cli @capacitor/local-notifications
   npx cap init Countdown com.DEINNAME.countdown --web-dir docs
   npm install @capacitor/android @capacitor/ios
   npx cap add android
   npx cap add ios
   npx @capacitor/assets generate --assetPath resources
   ```
3. Nach jeder Änderung in `docs/`: `npx cap sync`

Die App nutzt im nativen Build automatisch `LocalNotifications` (Alarm auch bei gesperrtem Handy),
siehe `scheduleAlarm()` in `docs/index.html`.

**Android / Google Play:** geht komplett unter Windows mit Android Studio. Konto: 25 $ einmalig.

**iOS / App Store:** braucht einen Mac mit Xcode (oder einen Cloud-Mac-Dienst wie Codemagic)
und ein Apple-Developer-Konto (99 $/Jahr). Apple lehnt sehr simple „Web-in-App“-Apps
manchmal ab (Richtlinie 4.2) – native Benachrichtigungen und Haptik helfen dagegen.
