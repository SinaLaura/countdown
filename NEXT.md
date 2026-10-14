# Next steps

Write what you want next under **To do**, one line each, top = most important (or use `/later <task>`, `/later !<task>` for urgent).
Start working through the list with `/next`, or keep it running with `/loop 15m /next`.
Claude picks up the top open item whenever it is free, moves it to **In progress** (with its session name, so parallel sessions don't take the same one), and to **Done** with the commit and a localhost link to check it when finished (needs `cd web && py -m http.server 8765`).

## To do

- [ ] The repo https://github.com/SinaLaura/countdown exists now. Bring it online
- [ ] Make my app fullscreen by default

## In progress

- [ ] Hourglass: let's try to use threejs.org to make the physics for the hourglass better. But just as a test (separate test page, the app itself stays free of external libraries). Open it for me then (user chose 2D with Matter.js instead; session 406605b7, started 13:06)

## Done

- [x] For the "solar system" make it collapse in the center during pause (ad7e6f9) → http://localhost:8765/?m=30&look=orbit
- [x] Solar system: same (collapse in the center during pause) for the solar system's stars arrangement (ad7e6f9) → http://localhost:8765/?m=30&look=stars
- [x] Jar: when a bubble jumps out of the jar on its own, it still looks different than when I tap it myself. Make it look more like tapping it myself (d8cb9a2) → http://localhost:8765/?m=10&look=jar
- [x] Die Raupe soll kurz einen lächelnden Mund bekommen, wenn man sie anklickt, dann geht es wieder weg (9146ad2) → http://localhost:8765/?m=10&look=caterpillar
- [x] The slider in the hourglass should be centered (dde30ae) → http://localhost:8765/?m=10&look=hourglass
- [x] Implement the next theme: Kugelbahn: Pro Minute rollt eine Kugel durch eine Zickzack-Bahn nach unten. (d54daf7) → http://localhost:8765/?m=10&look=marbles
- [x] Jar (meant: hourglass): the slider should be the same color as the jar's line (91804c9) → http://localhost:8765/?m=10&look=hourglass
- [x] Jar (meant: hourglass): the line should not be bigger in size (91804c9) → http://localhost:8765/?m=10&look=hourglass

