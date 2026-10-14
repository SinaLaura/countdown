---
name: next
description: Work through the countdown task list in NEXT.md, top item first, until nothing open is left. Use when the user types /next, says "continue with the list", or a /loop fires it.
argument-hint: (optional) "one" to do only a single item
---

Work through `NEXT.md` (repo root). Follow [CLAUDE.md](../../../CLAUDE.md) for everything you build.

Repeat for each item:

1. **Pick.** Read `NEXT.md` fresh. Take the top `- [ ]` line under **To do** that no session has claimed. If there is none, check **In progress** for an item with your own session name (left over from an interrupted run) and finish that. If nothing is left, say "NEXT.md is empty" in one line and stop.
2. **Claim.** Move that line to **In progress** as `- [ ] <task> (<your session name>, started <HH:MM>)`. Change no other line. Commit only `NEXT.md` right away, so parallel sessions don't take it.
3. **Do it.** Follow CLAUDE.md: read `web/index.html` fresh right before each edit; test in the browser (headless Edge works: `--headless --dump-dom`, or export the canvas with `toDataURL` for a look); bump the cache in `web/sw.js` after code changes; update `THEMES.md` for theme work. If the task is unclear or needs a decision only the user can make, don't guess: move it back to the top of **To do** with a short question in parentheses, commit, and go on to the next item.
4. **Commit** your work with explicit paths (no `git add -A`).
5. **Done.** Read `NEXT.md` fresh again, move the line to **Done** as `- [x] <task> (<commit hash>)`, commit only `NEXT.md`.
6. Write the user a short note for this item: what changed, how to see it (a `http://localhost:8765/?look=...&m=...` link if useful), what was tested and what was not.

Then go back to step 1, unless the argument was "one". New lines the user adds while you work are picked up at the next step 1.
