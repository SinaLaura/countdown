# Next steps

Write what you want next under **To do**, one line each, top = most important (or use `/later <task>`, `/later !<task>` for urgent).
Start working through the list with `/next`, or keep it running with `/loop 15m /next`.
Claude picks up the top open item whenever it is free, moves it to **In progress** (with its session name, so parallel sessions don't take the same one), and to **Done** with the commit and a localhost link to check it when finished (needs `cd docs && py -m http.server 8765`).

## To do

- [ ] After I picked the app icon: export it to icon-192, icon-512 and apple-touch-icon in docs/ and bump the cache name in sw.js. (waiting for your pick: lab/icons.html)
- [ ] (Bigger task for when everything else is finished): make it pomodoro, repeating endlessly. Show a preview of the new look. (The mode without pomodoro should still be available). (not started: needs your call on the cycle, e.g. 25 min work + 5 min break, long break after 4?)
- [ ] What is the classical pomodoro technique? Choose that (for the pomodoro task above).

## In progress
- [ ] Generate more icon ideas, and then open it for me together with the old ones. (session opus, started 15:40)


## Done

- [x] For the car, clicking should not make a surrounding thing, but some puff from the exhaust (Auspuff). (433f8ca) → http://localhost:8765/?m=10&look=cars (tap a car)
- [x] From the removed boring themes re-introduce the 5 best of them. And tell me how many are thrown out now. (11b2b8b) → http://localhost:8765/?m=20&look=spiral (back: spiral, clock, honey, rings, diamonds; 4 thrown out: dots, squares, bars, tiles)

- [x] App icon: draw 3 logo suggestions based on the Ankabuti spider logo (../GoGirls-homepage/images/ankabuti-logo.jpg): (1) spider with a clock-face belly with two hands, no numbers, (2) spider hanging on its thread into a thin partly filled countdown ring, (3) round smiling spider body with tiny legs and a thin arc around it showing time left. Show the three on a localhost page (lab page) so I can pick. (4c9126d) → lab/icons.html (open the file directly)
- [x] When clicking items most themes make a circle around it, which is fine. But for shapes that are not round choose another suitable thing in shape and size that fits the shape and theme. (ffdf32a) → http://localhost:8765/?m=10&look=cars (tap a car; also ducks, flower, chocolate, abacus, hedgehog)
- [x] Same for the more advanced themes: a car or duck can leave using the whole screen, the dead spider legs or spikes of the hedgehog can spread more over the bottom of the whole screen, the star-net can go through the whole screen. (73b8ebe) → http://localhost:8765/?m=10&look=ducks (also cars, hedgehog with &passed=6, stars)
- [x] In general the items should be proportional and fill up the space. That is almost always not the case with the basic boring themes. Add that general instruction to CLAUDE.md and change it for the boring themes: use the full size of the browser (not necessarily filling it completely, but use it). (e578f70) → http://localhost:8765/?m=10&look=snake (offline themes were enlarged too, they're just not in rotation)
- [x] The caterpillar already gets a laughing mouth when clicked. A similar theme (maybe snake or so) should also react when clicked: smile, look sad, or pull in its feelers. The reaction is chosen randomly each time the theme appears, but stays the same for that whole run (every click in one iteration gives the same reaction). (bc6c6fb) → http://localhost:8765/?m=10&look=snake (tap the snake)
- [x] Saturn: include an animation for clicking Saturn. (8c36d09) → http://localhost:8765/?m=10&look=orbit (tap the planet or its ring)
- [x] Hourglass: make the bubbles bigger. It looks a little bit weird how they are stuck before free fall but just in the air, in the bottleneck, without actual physical limitation. (3777308) → http://localhost:8765/?m=10&look=hourglass
- [x] Hourglass: make the bigness of the circles proportional. The total size of them could/should fill up the whole half of the hourglass, to be proportionate to time, which it always (in general) should be. (3777308) → http://localhost:8765/?m=40&look=hourglass
- [x] Remove some of the boring themes (3852e51) → http://localhost:8765/?m=10 (tap the background a few times: only the 16 advanced themes + snake appear)
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

