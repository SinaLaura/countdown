# Next steps

Write what you want next under **To do**, one line each, top = most important (or use `/later <task>`, `/later !<task>` for urgent).
Start working through the list with `/next`, or keep it running with `/loop 15m /next`.
Claude picks up the top open item whenever it is free, moves it to **In progress** (with its session name, so parallel sessions don't take the same one), and to **Done** with the commit and a localhost link to check it when finished (needs `cd docs && py -m http.server 8765`).

## To do

- [ ] Hourglass: make the bubbles bigger. It looks a little bit weird how they are stuck before free fall but just in the air, in the bottleneck, without actual physical limitation.
- [ ] Hourglass: make the bigness of the circles proportional. The total size of them could/should fill up the whole half of the hourglass, to be proportionate to time, which it always (in general) should be.
- [ ] Remove some of the boring themes (don't delete, we will re-use them maybe later, but take them offline).
- [ ] (Bigger task for when everything else is finished): make it pomodoro, repeating endlessly. Show a preview of the new look. (The mode without pomodoro should still be available).

## In progress


## Done

- [x] In the browser when I don't click in the centered void the theme doesn't change. Change that. (priority task) (20967f8) → http://localhost:8765/?m=10 (in a wide window, tap the empty space left or right of the column)
- [x] Fullscreen should start only after someone presses Start. (6c49cc7) → http://localhost:8765/ (first tap does nothing, Start goes fullscreen)
- [x] I like the new physics of the hourglass, but make the bubbles circles. (c745ece) → lab/hourglass-matter.html (open the file directly)
- [x] Make my app fullscreen by default (854294d) → http://localhost:8765/ (first tap or Start goes fullscreen)
- [x] The repo https://github.com/SinaLaura/countdown exists now. Bring it online (pushed; Pages workflow 42e67d5 – one click left for you: Settings → Pages → Source „GitHub Actions“) → https://sinalaura.github.io/countdown/
- [x] Hourglass: let's try to use threejs.org to make the physics for the hourglass better. But just as a test (separate test page, the app itself stays free of external libraries). Open it for me then (2D with Matter.js as chosen; c278d50) → lab/hourglass-matter.html (open the file directly, needs internet for Matter.js)
- [x] For the "solar system" make it collapse in the center during pause (ad7e6f9) → http://localhost:8765/?m=30&look=orbit
- [x] Solar system: same (collapse in the center during pause) for the solar system's stars arrangement (ad7e6f9) → http://localhost:8765/?m=30&look=stars
- [x] Jar: when a bubble jumps out of the jar on its own, it still looks different than when I tap it myself. Make it look more like tapping it myself (d8cb9a2) → http://localhost:8765/?m=10&look=jar
- [x] Die Raupe soll kurz einen lächelnden Mund bekommen, wenn man sie anklickt, dann geht es wieder weg (9146ad2) → http://localhost:8765/?m=10&look=caterpillar
- [x] The slider in the hourglass should be centered (dde30ae) → http://localhost:8765/?m=10&look=hourglass
- [x] Implement the next theme: Kugelbahn: Pro Minute rollt eine Kugel durch eine Zickzack-Bahn nach unten. (d54daf7) → http://localhost:8765/?m=10&look=marbles
- [x] Jar (meant: hourglass): the slider should be the same color as the jar's line (91804c9) → http://localhost:8765/?m=10&look=hourglass
- [x] Jar (meant: hourglass): the line should not be bigger in size (91804c9) → http://localhost:8765/?m=10&look=hourglass

